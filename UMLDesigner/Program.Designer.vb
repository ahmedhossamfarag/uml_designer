<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Program
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Header = New FlowLayoutPanel()
        MainLabel = New SceneLabel()
        MainSceneView = New MainScene()
        Header.SuspendLayout()
        SuspendLayout()
        ' 
        ' Header
        ' 
        Header.Controls.Add(MainLabel)
        Header.Dock = DockStyle.Top
        Header.Location = New Point(0, 0)
        Header.Name = "Header"
        Header.Size = New Size(964, 36)
        Header.TabIndex = 1
        ' 
        ' MainLabel
        ' 
        MainLabel.Location = New Point(3, 3)
        MainLabel.Name = "MainLabel"
        MainLabel.Scene = MainSceneView
        MainLabel.Size = New Size(200, 30)
        MainLabel.TabIndex = 0
        ' 
        ' MainSceneView
        ' 
        MainSceneView.Dock = DockStyle.Fill
        MainSceneView.Location = New Point(0, 36)
        MainSceneView.Name = "MainSceneView"
        MainSceneView.Size = New Size(964, 580)
        MainSceneView.TabIndex = 2
        ' 
        ' Program
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(964, 616)
        Controls.Add(MainSceneView)
        Controls.Add(Header)
        KeyPreview = True
        Name = "Program"
        Header.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents Header As FlowLayoutPanel
    Friend WithEvents MainLabel As SceneLabel
    Friend WithEvents MainSceneView As MainScene


End Class
