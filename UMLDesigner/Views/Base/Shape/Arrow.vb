Public Class Arrow
    Inherits Line

    Public ArrowDir As Direction

    Public Sub New(p1 As Point, p2 As Point, dir As Direction, Optional m As LineMode = LineMode.I)
        MyBase.New(p1, p2, m)
        ArrowDir = dir
    End Sub

    Public Overrides Sub Paint(g As Graphics)
        MyBase.Paint(g)
        Dim d1, d2 As Point
        Select Case ArrowDir
            Case Direction.Down
                d1 = New Point(-10, 10)
                d2 = New Point(10, 10)
                Exit Select
            Case Direction.Up
                d1 = New Point(-10, -10)
                d2 = New Point(10, -10)
                Exit Select
            Case Direction.Left
                d1 = New Point(-10, -10)
                d2 = New Point(-10, 10)
                Exit Select
            Case Else
                d1 = New Point(10, -10)
                d2 = New Point(10, 10)
                Exit Select
        End Select
        g.FillPolygon(Pen.Brush, New PointF() {P2, P2 + d1, P2 + d2})
    End Sub
End Class
