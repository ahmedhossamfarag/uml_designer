Public Class UMLIFStateView
    Inherits UMLStateView
    Implements Focusable

    Public Controller As UMLIFStateController
    Public Type As UMLStateType

    Public WriteOnly Property Model As UMLState
        Set(value As UMLState)
            BaseModel = value
            Type = value.Type
            Refresh()
        End Set
    End Property

    Public Sub New()
        Size = New Size(30, 30)
        Pen = Pens.Black
        MoveControl = New MoveController(Me, Me)
    End Sub

    Public Sub ME_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        If Type = UMLStateType.Initial Then
            e.Graphics.FillEllipse(Pen.Brush, 0, 0, Width - 2, Height - 2)
        Else
            e.Graphics.DrawEllipse(Pen, 0, 0, Width - 2, Height - 2)
            e.Graphics.FillEllipse(Pen.Brush, 5, 5, Width - 12, Height - 12)
        End If
    End Sub


    Private Sub Me_Click(s As Object, e As EventArgs) Handles Me.Click
        DiagramController.FocusOn(Controller)
        DiagramController.StateClick(BaseModel)
    End Sub
End Class
