<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SceneLabel
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
        SceneName = New Label()
        RemoveButton = New Button()
        SuspendLayout()
        ' 
        ' SceneName
        ' 
        SceneName.Dock = DockStyle.Fill
        SceneName.Location = New Point(0, 0)
        SceneName.Name = "SceneName"
        SceneName.Size = New Size(200, 30)
        SceneName.TabIndex = 0
        SceneName.Text = "Label1"
        SceneName.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' RemoveButton
        ' 
        RemoveButton.Dock = DockStyle.Right
        RemoveButton.FlatAppearance.BorderSize = 0
        RemoveButton.FlatStyle = FlatStyle.Flat
        RemoveButton.ForeColor = Color.Red
        RemoveButton.Location = New Point(170, 0)
        RemoveButton.Name = "RemoveButton"
        RemoveButton.Size = New Size(30, 30)
        RemoveButton.TabIndex = 1
        RemoveButton.Text = "x"
        RemoveButton.UseVisualStyleBackColor = True
        ' 
        ' SceneLabel
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(RemoveButton)
        Controls.Add(SceneName)
        Name = "SceneLabel"
        Size = New Size(200, 30)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SceneName As Label
    Friend WithEvents RemoveButton As Button

End Class
