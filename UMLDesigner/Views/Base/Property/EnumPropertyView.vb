Public Class EnumPropertyView(Of T)
    Inherits PPropertyView

    Public MyProp As EnumProperty(Of T)

    Public Sub New(ByRef prop As EnumProperty(Of T))
        MyProp = prop
        InitializeComponent()
        PropName.Text = prop.Name
    End Sub

    Public Overrides Function GetControl() As Control
        PropName.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ComboBox
        ' 
        ComboBox = New ComboBox With {
            .FormattingEnabled = True,
            .Location = New Point(150, 0),
            .Size = New Size(151, 28)
        }
        For Each c In [Enum].GetValues(GetType(T))
            ComboBox.Items.Add(c)
        Next
        ComboBox.SelectedItem = MyProp.Value
        Return ComboBox
    End Function

    Private Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox.SelectedIndexChanged
        Try
            Dim val = MyProp.Value
            MyProp.Value = CType(ComboBox.SelectedItem, T)
            History.AddRecord(AddressOf SetValue, MyProp.Value, val)
        Catch ex As Exception
            ComboBox.SelectedItem = MyProp.Value
        End Try
    End Sub


    Public Sub SetValue(val As T)
        MyProp.Value = val
        ComboBox.SelectedItem = val
    End Sub

    Friend WithEvents ComboBox As ComboBox
End Class
