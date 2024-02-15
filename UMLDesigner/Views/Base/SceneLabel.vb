Public Class SceneLabel

    Private MySc As Scene

    Public Program As Program

    Public Property Scene As Scene
        Get
            Return MySc
        End Get
        Set(value As Scene)
            MySc = value
            SceneName.Text = value.SceneName
        End Set
    End Property

    Public WriteOnly Property Removable As Boolean
        Set(value As Boolean)
            RemoveButton.Visible = value
        End Set
    End Property

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        Program.RemoveScene(Me)
    End Sub

    Private Sub SceneName_Click(sender As Object, e As EventArgs) Handles SceneName.Click
        Program.SetScene(Me)
    End Sub

    Friend Sub Adjust(v As Boolean)
        BackColor = If(v, Color.Azure, Parent.BackColor)
    End Sub

    Friend Sub Review()
        SceneName.Text = MySc.SceneName
    End Sub
End Class
