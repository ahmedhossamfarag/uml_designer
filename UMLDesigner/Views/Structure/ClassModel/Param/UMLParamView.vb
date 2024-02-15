Public Class UMLParamView

    Public Property Param As UMLParameter

        Set(p As UMLParameter)
            NameBox.Text = p.Name
            TypeBox.Text = p.Type
            DefaultBox.Text = p.DefaultValue
        End Set
        Get
            Return New UMLParameter With {
                .Name = NameBox.Text,
                .Type = TypeBox.Text,
                .DefaultValue = If(String.IsNullOrEmpty(DefaultBox.Text), Nothing, DefaultBox.Text)
            }
        End Get
    End Property

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Parent.Controls.Remove(Me)
    End Sub
End Class
