Public Class UMLStateView
    Inherits CompositControl
    Implements Focusable

    Public DiagramController As UMLStateDiagramController
    Public ComStateController As UMLCompositStateController
    Private Model As UMLState


    Protected WithEvents MoveControl As MoveController

    Protected Pen As Pen = Pens.Black

    Public Property BaseModel As UMLState
        Get
            Return Model
        End Get
        Set(value As UMLState)
            Model = value
            Location = value.Location
        End Set
    End Property

    Public Sub MEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter

    End Sub

    Public Sub MLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave

    End Sub


    Private Sub Me_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Model IsNot Nothing Then
            Model.Location = Location
        End If
    End Sub

    Private Sub MoveControl_MoveEnd() Handles MoveControl.MoveEnd
        If ComStateController IsNot Nothing Then
            ComStateController.Include(Me)
        End If
        DiagramController.StateMove(Me)
    End Sub

    Public Overridable Sub FocusIn() Implements Focusable.FocusIn
        Pen = Pens.Blue
        Refresh()
    End Sub

    Public Overridable Sub FocusOut() Implements Focusable.FocusOut
        Pen = Pens.Black
        Refresh()
    End Sub
End Class
