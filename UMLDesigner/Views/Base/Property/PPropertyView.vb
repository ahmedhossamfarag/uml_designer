Public MustInherit Class PPropertyView
    Inherits Panel

    Protected Sub InitializeComponent()
        PropName = New Label()
        SuspendLayout()

        ' 
        ' PropName
        ' 
        PropName.BackColor = SystemColors.ButtonHighlight
        PropName.Location = New Point(0, 0)
        PropName.Size = New Size(150, 30)
        PropName.TextAlign = ContentAlignment.MiddleLeft
        '
        ' Control
        '
        Dim Control = GetControl()
        ' 
        ' Me
        '
        Me.BackColor = SystemColors.Control
        Me.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(PropName)
        Me.Controls.Add(Control)
        Me.Margin = New Padding(0)
        Me.Size = New Size(300, 30)
        ResumeLayout(False)
    End Sub

    Public MustOverride Function GetControl() As Control

    Friend WithEvents PropName As Label

End Class
