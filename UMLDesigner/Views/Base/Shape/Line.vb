Public Class Line
    Inherits Shape


    Public Shared CLength As Integer = 8
    Public Shared CHeight As Integer = 20
    Public Shared CTol As Integer = 0
    Public Shared Tol As Integer = 10
    Public Shared UCLen As Integer = 50

    Protected P1, P2, P3?, P4?, P5? As Point

    Public Mode As LineMode

    Public Property FromP As Point
        Get
            Return P1
        End Get
        Set(value As Point)
            If value <> P1 Then
                Invalidate()
                P1 = value
                Invalidate()
            Else
                P1 = value
            End If
        End Set
    End Property

    Public Property ToP As Point
        Get
            Return P2
        End Get
        Set(value As Point)
            If value <> P2 Then
                Invalidate()
                P2 = value
                Invalidate()
            Else
                P2 = value
            End If
        End Set
    End Property

    Public Sub New(p1 As Point, p2 As Point, Optional m As LineMode = LineMode.I)
        Me.P1 = p1
        Me.P2 = p2
        Mode = m
    End Sub

    Public Overrides ReadOnly Property Bounds As Rectangle
        Get
            Dim dx = 0, dy = 0, dw = 0, dh = 0
            Select Case Mode
                Case LineMode.CR
                    dx = UCLen
                    dw = UCLen
                    Exit Select
                Case LineMode.CL
                    dw = UCLen
                    Exit Select
                Case LineMode.UU
                    dh = UCLen
                    Exit Select
                Case LineMode.UD
                    dy = UCLen
                    dh = UCLen
                    Exit Select
                Case LineMode.OD
                    dx = UCLen
                    dy = UCLen
                    dw = UCLen
                    dh = UCLen
                    Exit Select
            End Select
            Return New Rectangle(Math.Min(P1.X, P2.X) - CHeight - dx, Math.Min(P1.Y, P2.Y) - CHeight - dy,
                                 Math.Abs(P1.X - P2.X) + CHeight * 2 + dw, Math.Abs(P1.Y - P2.Y) + CHeight * 2 + dh)
        End Get
    End Property

    Public Overrides Sub Paint(g As Graphics)
        Select Case Mode
            Case LineMode.I
                P3 = Nothing
                P4 = Nothing
                P5 = Nothing
                Exit Select
            Case LineMode.L
                P3 = New Point(P1.X, P2.Y)
                P4 = Nothing
                P5 = Nothing
                Exit Select
            Case LineMode.T
                P3 = New Point(P2.X, P1.Y)
                P4 = Nothing
                P5 = Nothing
                Exit Select
            Case LineMode.N
                Dim y = (P1.Y + P2.Y) / 2
                P3 = New Point(P1.X, y)
                P4 = New Point(P2.X, y)
                P5 = Nothing
                Exit Select
            Case LineMode.Z
                Dim x = (P1.X + P2.X) / 2
                P3 = New Point(x, P1.Y)
                P4 = New Point(x, P2.Y)
                P5 = Nothing
                Exit Select
            Case LineMode.CR
                Dim x = Math.Min(P1.X - UCLen, P2.X - UCLen)
                P3 = New Point(x, P1.Y)
                P4 = New Point(x, P2.Y)
                P5 = Nothing
                Exit Select
            Case LineMode.CL
                Dim x = Math.Min(P1.X + UCLen, P2.X + UCLen)
                P3 = New Point(x, P1.Y)
                P4 = New Point(x, P2.Y)
                P5 = Nothing
                Exit Select
            Case LineMode.UU
                Dim y = Math.Min(P1.Y + UCLen, P2.Y + UCLen)
                P3 = New Point(P1.X, y)
                P4 = New Point(P2.X, y)
                P5 = Nothing
                Exit Select
            Case LineMode.UD
                Dim y = Math.Min(P1.Y - UCLen, P2.Y - UCLen)
                P3 = New Point(P1.X, y)
                P4 = New Point(P2.X, y)
                P5 = Nothing
                Exit Select
            Case LineMode.OD
                P3 = New Point(P1.X, P1.Y - UCLen)
                P5 = New Point(P2.X - UCLen, P2.Y)
                P4 = New Point(P5.Value.X, P3.Value.Y)
                Exit Select
        End Select

        If Not P5.HasValue Then
            If Not P4.HasValue Then
                If Not P3.HasValue Then
                    g.DrawLine(Pen, P1, P2)
                Else
                    g.DrawLine(Pen, P1, P3.Value)
                    g.DrawLine(Pen, P3.Value, P2)
                End If
            Else
                g.DrawLine(Pen, P1, P3.Value)
                g.DrawLine(Pen, P3.Value, P4.Value)
                g.DrawLine(Pen, P4.Value, P2)
            End If
        Else
            g.DrawLine(Pen, P1, P3.Value)
            g.DrawLine(Pen, P3.Value, P4.Value)
            g.DrawLine(Pen, P4.Value, P5.Value)
            g.DrawLine(Pen, P5.Value, P2)
        End If

    End Sub

    Public Overrides Function Contains(p As Point) As Boolean
        If Not Bounds.Contains(p) Then
            Return False
        End If
        Select Case Mode
            Case LineMode.I
                Return PointBetween(p, P1, P2)
            Case LineMode.L, LineMode.T
                Return PointBetween(p, P1, P3) Or PointBetween(p, P3, P2)
            Case LineMode.OD
                Return PointBetween(p, P1, P3) Or PointBetween(p, P3, P4) Or PointBetween(p, P4, P5) Or PointBetween(p, P5, P2)
            Case Else
                Return PointBetween(p, P1, P3) Or PointBetween(p, P3, P4) Or PointBetween(p, P4, P2)
        End Select
    End Function

    Private Shared Function PointBetween(p3 As Point, p1 As Point, p2 As Point) As Boolean
        Dim l = p2 - p1
        l = New Point(Math.Abs(l.X), Math.Abs(l.Y))
        Dim d = p3 - p1
        d = New Point(Math.Abs(d.X), Math.Abs(d.Y))
        If l.X = 0 Then
            Return d.X < Tol And d.Y < l.Y
        ElseIf l.Y = 0 Then
            Return d.Y < Tol And d.X < l.X
        Else
            Dim m = CTypeDynamic(Of Double)(d.Y) / d.X
            Return Math.Abs(p1.Y - m * p1.X - (p3.Y - m * p3.X)) < Tol
        End If
    End Function

End Class
