Public Class UMLParamListForm

    Public Property ParamList As List(Of UMLParameter)
        Set(value As List(Of UMLParameter))
            For Each p In value
                Content.Controls.Add(New UMLParamView With {.Param = p})
            Next
        End Set
        Get
            Dim list = New List(Of UMLParameter)
            For Each c In Content.Controls
                Dim p = CType(c, UMLParamView).Param
                If String.IsNullOrEmpty(p.Name) Or String.IsNullOrEmpty(p.Type) Then
                    Continue For
                End If
                If Not list.Any(Function(it) it.Name = p.Name) Then
                    list.Add(p)
                End If
            Next
            Return list
        End Get
    End Property

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        Content.Controls.Add(New UMLParamView With {.Param = New UMLParameter})
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class