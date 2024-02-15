Public Class TextPropertyView
    Inherits PPropertyView

    Public MyProp As TextProperty


    Public Sub New(ByRef prop As TextProperty)
        MyProp = prop
        InitializeComponent()
        PropName.Text = prop.Name
        TextBox.Text = prop.Value
    End Sub

    Public Overrides Function GetControl() As Control
        ' 
        ' TextBox
        ' 
        TextBox = New TextBox With {
            .Location = New Point(150, 0),
            .Size = New Size(150, 27)
        }
        Return TextBox
    End Function

    Private Sub TextBox_Leave(sender As Object, e As EventArgs) Handles TextBox.Leave
        Try
            Dim val = MyProp.Value
            MyProp.Value = TextBox.Text
            History.AddRecord(AddressOf SetValue, MyProp.Value, val)
        Catch ex As Exception
            TextBox.Text = MyProp.Value
        End Try
    End Sub

    Private Sub TextBox_KeyPressed(sender As Object, e As KeyPressEventArgs) Handles TextBox.KeyPress
        If e.KeyChar = vbCr Then
            Parent.Focus()
        End If
    End Sub

    Public Sub SetValue(val As String)
        MyProp.Value = val
        TextBox.Text = val
    End Sub

    Friend WithEvents TextBox As TextBox
End Class
