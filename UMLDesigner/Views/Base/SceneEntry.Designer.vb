<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SceneEntry
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
        ImageView = New Panel()
        Options = New Panel()
        NewButton = New Button()
        OpenButton = New Button()
        Options.SuspendLayout()
        SuspendLayout()
        ' 
        ' ImageView
        ' 
        ImageView.Dock = DockStyle.Top
        ImageView.Location = New Point(0, 0)
        ImageView.Name = "ImageView"
        ImageView.Size = New Size(300, 300)
        ImageView.TabIndex = 0
        ' 
        ' Options
        ' 
        Options.Controls.Add(OpenButton)
        Options.Controls.Add(NewButton)
        Options.Dock = DockStyle.Bottom
        Options.Location = New Point(0, 300)
        Options.Name = "Options"
        Options.Size = New Size(300, 100)
        Options.TabIndex = 1
        ' 
        ' NewButton
        ' 
        NewButton.Dock = DockStyle.Top
        NewButton.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        NewButton.Location = New Point(0, 0)
        NewButton.Name = "NewButton"
        NewButton.Size = New Size(300, 50)
        NewButton.TabIndex = 0
        NewButton.Text = "New"
        NewButton.UseVisualStyleBackColor = True
        ' 
        ' OpenButton
        ' 
        OpenButton.Dock = DockStyle.Bottom
        OpenButton.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        OpenButton.Location = New Point(0, 50)
        OpenButton.Name = "OpenButton"
        OpenButton.Size = New Size(300, 50)
        OpenButton.TabIndex = 1
        OpenButton.Text = "Open"
        OpenButton.UseVisualStyleBackColor = True
        ' 
        ' SceneEntry
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Options)
        Controls.Add(ImageView)
        Name = "SceneEntry"
        Size = New Size(300, 400)
        Options.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents ImageView As Panel
    Friend WithEvents Options As Panel
    Friend WithEvents OpenButton As Button
    Friend WithEvents NewButton As Button

End Class
