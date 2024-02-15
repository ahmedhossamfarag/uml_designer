<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UMLCompositStateView
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
        SuspendLayout()
        ' 
        ' SName
        ' 
        SName.Dock = DockStyle.Fill
        SName.Location = New Point(3, 3)
        SName.Name = "SName"
        SName.Size = New Size(194, 24)
        SName.TabIndex = 0
        SName.Text = "Label1"
        SName.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' UMLCompositStateView
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(SName)
        Name = "UMLCompositStateView"
        Padding = New Padding(3)
        Size = New Size(200, 30)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SName As Label

End Class
