Public Class UMLParamListProView
    Inherits PPropertyView

    Public MyPro As UMLParamListProperty

    Public Sub New(myPro As UMLParamListProperty)
        Me.MyPro = myPro
        InitializeComponent()
        PropName.Text = myPro.Name
    End Sub

    Public Overrides Function GetControl() As Control
        OpenButton = New Button With {
            .Size = New Size(20, 20),
            .Location = New Point(215, 5),
            .FlatStyle = FlatStyle.Flat
        }
        OpenButton.FlatAppearance.BorderSize = 0
        Return OpenButton
    End Function

    Private Sub OpenB_Paint(sender As Object, e As PaintEventArgs) Handles OpenButton.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.FillPolygon(Brushes.Blue, New Point() {
         New Point(0, 20), New Point(20, 20), New Point(10, 0)
        })
    End Sub

    Private Sub OpenB_Click(sender As Object, e As EventArgs) Handles OpenButton.Click
        Dim form = New UMLParamListForm With {.ParamList = MyPro.Value}
        form.ShowDialog()
        If form.DialogResult = DialogResult.OK Then
            MyPro.Value = form.ParamList
        End If
    End Sub

    Friend WithEvents OpenButton As Button
End Class
