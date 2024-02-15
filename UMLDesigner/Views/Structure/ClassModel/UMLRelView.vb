Public Class UMLRelView
    Inherits Line


    Public WithEvents FromC, ToC As UMLClassView
    Public Dir, DirE As Direction

    Public Controller As UMLRelController
    Public Model As UMLRelation

    Public Sub New(ad As LineAdapt)
        MyBase.New(ad.P1, ad.P2, ad.M)
        Dir = ad.D1
        DirE = ad.D2
    End Sub

    Public Sub Adapt(seder As Object, e As EventArgs) Handles FromC.LocationChanged, ToC.LocationChanged, FromC.SizeChanged, ToC.SizeChanged
        Dim ad = LineAdaptor.Adapt(FromC.Bounds, ToC.Bounds)
        Adapt(ad)
        Invalidate()
    End Sub

    Public Sub Adapt(ad As LineAdapt)
        FromP = ad.P1
        ToP = ad.P2
        Dir = ad.D1
        DirE = ad.D2
        Mode = ad.M
    End Sub

    Public Sub Rel_Click() Handles Me.Click
        Controller.View_Click()
    End Sub

    Public Overrides Sub Paint(g As Graphics)
        If Model.Type = UMLRelType.Realization Or Model.Type = UMLRelType.Dependency Then
            Pen = New Pen(Pen.Color) With {
                .DashPattern = New Single() {10, 2, 15, 4}
            }
        End If
        MyBase.Paint(g)
        Pen = New Pen(Pen.Color)
        Dim d1, d2, d3 As Point
        Select Case Dir
            Case Direction.Up
                d1 = New Point(-10, 10)
                d2 = New Point(10, 10)
                d3 = New Point(0, 20)
                Exit Select
            Case Direction.Down
                d1 = New Point(-10, -10)
                d2 = New Point(10, -10)
                d3 = New Point(0, -20)
                Exit Select
            Case Direction.Right
                d1 = New Point(-10, -10)
                d2 = New Point(-10, 10)
                d3 = New Point(-20, 0)
                Exit Select
            Case Else
                d1 = New Point(10, -10)
                d2 = New Point(10, 10)
                d3 = New Point(20, 0)
                Exit Select
        End Select
        Select Case Model.Type
            Case UMLRelType.Generalization, UMLRelType.Dependency, UMLRelType.Realization
                Dim ps = New Point() {ToP, ToP + d1, ToP + d2}
                g.FillPolygon(Brushes.White, ps)
                g.DrawPolygon(Pen, ps)
                Exit Select
            Case UMLRelType.Aggregation, UMLRelType.Composition
                Dim ps = New Point() {FromP, FromP - d1, FromP - d3, FromP - d2}
                If Model.Type = UMLRelType.Composition Then
                    g.FillPolygon(Pen.Brush, ps)
                Else
                    g.FillPolygon(Brushes.White, ps)
                    g.DrawPolygon(Pen, ps)
                End If
                Exit Select
        End Select
        If Model.Title IsNot Nothing Then
            DrawTitle(g)
        End If
        If Model.HasCard Then
            DrawCard(g)
        End If
    End Sub

    Private Sub DrawTitle(g As Graphics)
        Dim l = Model.Title.Length / 2 * CLength
        Dim p = FromP + ToP
        p = New Point(p.X / 2, p.Y / 2)
        Select Case Mode
            Case LineMode.Z, LineMode.CL
                g.RotateTransform(90)
                p = New Point(p.Y, -p.X)
        End Select
        p.Offset(-l, -CHeight)
        g.DrawString(Model.Title, Parent.Font, Pen.Brush, p)
        g.ResetTransform()
    End Sub

    Private Sub DrawCard(g As Graphics)
        Dim s = Model.Cardinality.ToString()
        Dim l = s.Length * CLength
        Dim p As Point
        Select Case DirE
            Case Direction.Up
                p = New Point(CTol, -l)
                Exit Select
            Case Direction.Down
                p = New Point(CTol, CTol)
                Exit Select
            Case Direction.Right
                p = New Point(CTol, -CHeight)
                Exit Select
            Case Else
                p = New Point(-l, -CTol)
        End Select
        p += ToP
        If Mode = LineMode.N Then
            g.RotateTransform(90)
            p = New Point(p.Y, -p.X)
        End If
        g.DrawString(s, Parent.Font, Pen.Brush, p)
        g.ResetTransform()
    End Sub
End Class
