Public Class UMLClassModelView

    Public Controller As UMLClassModelController

    Private MoveControl As MoveController

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        ' Add any initialization after the InitializeComponent() call.
        MoveControl = New MoveController(Diagram, Diagram)
    End Sub

    Private Sub AddClass_MouseDown(sender As Object, e As MouseEventArgs) Handles AddClass.MouseDown
        AddClass.BackColor = Color.Aqua
        AddClass.DoDragDrop(New UMLClass, DragDropEffects.Copy Or DragDropEffects.Move)
    End Sub

    Private Sub AddRel_Click(sender As Object, e As EventArgs) Handles AddRel.Click
        AddRel.BackColor = Color.Aqua
        Controller.SetNewRel()
    End Sub

    Private Sub Diagram_DragEnter(sender As Object, e As DragEventArgs) Handles Diagram.DragEnter
        If e.Data.GetDataPresent(GetType(UMLClass)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Diagram_DragDrop(sender As Object, e As DragEventArgs) Handles Diagram.DragDrop
        If e.Data.GetDataPresent(GetType(UMLClass)) Then
            Controller?.AddClass(e.Data.GetData(GetType(UMLClass)), Diagram.PointToClient(New Point(e.X, e.Y)))
        End If
    End Sub

    Public Sub Free()
        AddRel.BackColor = Color.SkyBlue
        AddClass.BackColor = Color.SkyBlue
        PContent.Controls.Clear()
        TMessage.Text = ""
        PMessage.Text = ""
    End Sub

    Private Sub AddClass_QueryContinueDrag(sender As Object, e As QueryContinueDragEventArgs) Handles AddClass.QueryContinueDrag
        If e.Action = DragAction.Drop Then
            AddClass.BackColor = Color.SkyBlue
        ElseIf Not FindForm().DesktopBounds.Contains(Control.MousePosition) Then
            e.Action = DragAction.Cancel
            AddClass.BackColor = Color.SkyBlue
        End If
    End Sub
End Class
