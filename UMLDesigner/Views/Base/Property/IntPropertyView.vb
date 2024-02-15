﻿Public Class IntPropertyView
    Inherits PPropertyView
    Public MyProp As IntProperty


    Public Sub New(ByRef prop As IntProperty)
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
            MyProp.Value = Integer.Parse(TextBox.Text)
            History.AddRecord(AddressOf SetValue, MyProp.Value, val)
        Catch ex As Exception
            TextBox.Text = MyProp.Value
        End Try
    End Sub

    Private Sub TextBox_KeyPressed(sender As Object, e As KeyPressEventArgs) Handles TextBox.KeyPress
        If e.KeyChar = vbCr Then
            Parent.Focus()
        ElseIf Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub


    Public Sub SetValue(val As Integer)
        MyProp.Value = val
        TextBox.Text = val
    End Sub

    Friend WithEvents TextBox As TextBox
End Class
