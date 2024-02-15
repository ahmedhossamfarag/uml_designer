<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainScene
    Inherits System.Windows.Forms.UserControl

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
        SDEntry = New SceneEntry()
        CMEntry = New SceneEntry()
        SuspendLayout()
        ' 
        ' SDEntry
        ' 
        SDEntry.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        SDEntry.Image = Nothing
        SDEntry.Location = New Point(465, 50)
        SDEntry.MaximumSize = New Size(300, 400)
        SDEntry.MinimumSize = New Size(300, 400)
        SDEntry.Name = "SDEntry"
        SDEntry.Size = New Size(300, 400)
        SDEntry.TabIndex = 3
        ' 
        ' CMEntry
        ' 
        CMEntry.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        CMEntry.Image = Nothing
        CMEntry.Location = New Point(35, 50)
        CMEntry.MaximumSize = New Size(300, 400)
        CMEntry.MinimumSize = New Size(300, 400)
        CMEntry.Name = "CMEntry"
        CMEntry.Size = New Size(300, 400)
        CMEntry.TabIndex = 0
        ' 
        ' MainScene
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(SDEntry)
        Controls.Add(CMEntry)
        Name = "MainScene"
        Size = New Size(800, 500)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SDEntry As SceneEntry
    Friend WithEvents CMEntry As SceneEntry

End Class
