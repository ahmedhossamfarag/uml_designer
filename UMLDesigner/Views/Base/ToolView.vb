Public Class ToolView
    Inherits UserControl

    Public Painting As Action(Of Graphics)

    Public DragData As Func(Of Object)

    Public ClickAction As Action(Of ToolView)

    Public Data As Object

    Public Sub New()
        Size = New Size(50, 50)
    End Sub

    Private Sub ME_Paint(s As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Painting?.Invoke(e.Graphics)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ME_MDown(s As Object, e As MouseEventArgs) Handles Me.MouseDown
        BackColor = Color.SkyBlue
        If DragData IsNot Nothing Then
            DoDragDrop(DragData.Invoke(), DragDropEffects.All)
        End If
    End Sub

    Private Sub Me_DragDrop(s As Object, e As QueryContinueDragEventArgs) Handles Me.QueryContinueDrag
        If e.Action = DragAction.Drop Then
            BackColor = Parent.BackColor
        ElseIf Not FindForm().DesktopBounds.Contains(Control.MousePosition) Then
            e.Action = DragAction.Cancel
            BackColor = Parent.BackColor
        End If
    End Sub

    Private Sub Me_Click() Handles Me.Click
        ClickAction?.Invoke(Me)
    End Sub

End Class
