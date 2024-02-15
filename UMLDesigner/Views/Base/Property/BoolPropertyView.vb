Public Class BoolPropertyView
    Inherits PPropertyView

    Public MyProp As BoolProperty

    Public Sub New(ByRef prop As BoolProperty)
        MyProp = prop
        InitializeComponent()
        PropName.Text = prop.Name
        CheckBox.Checked = prop.Value
    End Sub

    Public Overrides Function GetControl() As Control
        ' 
        ' CheckBox
        ' 
        CheckBox = New CheckBox With {
            .AutoSize = True,
            .Location = New Point(215, 8),
            .Size = New Size(18, 17),
            .UseVisualStyleBackColor = True
        }
        Return CheckBox
    End Function

    Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox.CheckedChanged
        Try
            Dim val = MyProp.Value
            MyProp.Value = CheckBox.Checked
            History.AddRecord(AddressOf SetValue, MyProp.Value, val)
        Catch ex As Exception
            CheckBox.Checked = MyProp.Value
        End Try
    End Sub


    Public Sub SetValue(val As Boolean)
        MyProp.Value = val
        CheckBox.Checked = val
    End Sub

    Friend WithEvents CheckBox As CheckBox
End Class
