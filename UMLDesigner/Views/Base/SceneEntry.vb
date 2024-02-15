Public Class SceneEntry

    Public Property Image As Bitmap

    Public Event NewClick As EventHandler
    Public Event OpenClick As EventHandler

    Private Sub ImageView_Paint(sender As Object, e As PaintEventArgs) Handles ImageView.Paint
        If Image IsNot Nothing Then
            e.Graphics.DrawImage(Image, New Rectangle(New Point, ImageView.Size))
        End If
    End Sub

    Private Sub NewButton_Click(sender As Object, e As EventArgs) Handles NewButton.Click
        RaiseEvent NewClick(sender, e)
    End Sub

    Private Sub OpenButton_Click(sender As Object, e As EventArgs) Handles OpenButton.Click
        RaiseEvent OpenClick(sender, e)
    End Sub
End Class
