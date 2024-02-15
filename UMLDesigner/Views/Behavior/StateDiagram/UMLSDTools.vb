Public Class UMLSDTools

    Public Shared Sub NSTool_Paint(g As Graphics)
        g.DrawRectangle(Pens.Black, 10, 10, 30, 30)
    End Sub

    Public Shared Sub CSTool_Paint(g As Graphics)
        g.DrawRectangle(Pens.Black, 10, 10, 10, 10)
        g.DrawRectangle(Pens.Black, 10, 10, 30, 30)
    End Sub

    Public Shared Sub ISTool_Paint(g As Graphics)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.FillEllipse(Brushes.Black, 10, 10, 30, 30)
    End Sub

    Public Shared Sub FSTool_Paint(g As Graphics)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.DrawEllipse(Pens.Black, 10, 10, 30, 30)
        g.FillEllipse(Brushes.Black, 15, 15, 20, 20)
    End Sub

    Public Shared Sub LUTool_Paint(g As Graphics)
        g.DrawLines(Pens.Black, New PointF() {
                    New PointF(10, 10),
                    New PointF(10, 40),
                    New PointF(40, 40)
                    })
    End Sub

    Public Shared Sub LTTool_Paint(g As Graphics)
        g.DrawLines(Pens.Black, New PointF() {
                    New PointF(10, 10),
                    New PointF(40, 10),
                    New PointF(40, 40)
                    })
    End Sub

    Public Shared Sub LZTool_Paint(g As Graphics)
        g.DrawLines(Pens.Black, New PointF() {
                    New PointF(10, 10),
                    New PointF(25, 10),
                    New PointF(25, 40),
                    New PointF(40, 40)
                    })
    End Sub

    Public Shared Sub LNTool_Paint(g As Graphics)
        g.DrawLines(Pens.Black, New PointF() {
                    New PointF(10, 10),
                    New PointF(10, 25),
                    New PointF(40, 25),
                    New PointF(40, 40)
                    })
    End Sub

    Public Shared Sub LUDTool_Paint(g As Graphics)
        g.DrawLines(Pens.Black, New PointF() {
                    New PointF(10, 40),
                    New PointF(10, 10),
                    New PointF(40, 10),
                    New PointF(40, 40)
                    })
    End Sub

    Public Shared Sub LODTool_Paint(g As Graphics)
        g.DrawLines(Pens.Black, New PointF() {
                    New Point(30, 40),
                    New PointF(10, 40),
                    New PointF(10, 10),
                    New PointF(40, 10),
                    New PointF(40, 30)
                    })
    End Sub

    Public Shared Function NSTool_DragData() As UMLStateType
        Return UMLStateType.Normal
    End Function

    Public Shared Function CSTool_DragData() As UMLStateType
        Return UMLStateType.Composit
    End Function

    Public Shared Function ISTool_DragData() As UMLStateType
        Return UMLStateType.Initial
    End Function

    Public Shared Function FSTool_DragData() As UMLStateType
        Return UMLStateType.Final
    End Function

End Class
