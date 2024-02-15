<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UMLNormalStateView
    Inherits UMLStateView

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        SName = New Label()
        Body = New FlowLayoutPanel()
        ELabel = New Label()
        DLabel = New Label()
        XLabel = New Label()
        Body.SuspendLayout()
        SuspendLayout()
        ' 
        ' SName
        ' 
        SName.Dock = DockStyle.Top
        SName.Location = New Point(10, 10)
        SName.Margin = New Padding(0)
        SName.Name = "SName"
        SName.Size = New Size(180, 25)
        SName.TabIndex = 0
        SName.Text = "Label1"
        SName.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Body
        ' 
        Body.AutoSize = True
        Body.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Body.Controls.Add(ELabel)
        Body.Controls.Add(DLabel)
        Body.Controls.Add(XLabel)
        Body.FlowDirection = FlowDirection.TopDown
        Body.Location = New Point(10, 45)
        Body.Margin = New Padding(0, 10, 0, 0)
        Body.Name = "Body"
        Body.Size = New Size(175, 0)
        Body.TabIndex = 1
        ' 
        ' ELabel
        ' 
        ELabel.Location = New Point(0, 0)
        ELabel.Margin = New Padding(0)
        ELabel.MaximumSize = New Size(175, 0)
        ELabel.MinimumSize = New Size(175, 0)
        ELabel.Name = "ELabel"
        ELabel.Size = New Size(175, 0)
        ELabel.TabIndex = 0
        ELabel.Text = "Entry"
        ' 
        ' DLabel
        ' 
        DLabel.Location = New Point(0, 0)
        DLabel.Margin = New Padding(0)
        DLabel.MaximumSize = New Size(175, 0)
        DLabel.MinimumSize = New Size(175, 0)
        DLabel.Name = "DLabel"
        DLabel.Size = New Size(175, 0)
        DLabel.TabIndex = 1
        DLabel.Text = "Do"
        ' 
        ' XLabel
        ' 
        XLabel.Location = New Point(0, 0)
        XLabel.Margin = New Padding(0)
        XLabel.MaximumSize = New Size(175, 0)
        XLabel.MinimumSize = New Size(175, 0)
        XLabel.Name = "XLabel"
        XLabel.Size = New Size(175, 0)
        XLabel.TabIndex = 2
        XLabel.Text = "Exit"
        ' 
        ' UMLNormalStateView
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(Body)
        Controls.Add(SName)
        Name = "UMLNormalStateView"
        Padding = New Padding(10)
        Size = New Size(200, 45)
        Body.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents SName As Label
    Friend WithEvents Body As FlowLayoutPanel
    Friend WithEvents DLabel As Label
    Friend WithEvents ELabel As Label
    Friend WithEvents XLabel As Label

End Class
