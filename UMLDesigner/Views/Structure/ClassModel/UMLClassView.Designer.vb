<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UMLClassView
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
        Mover = New Button()
        Body = New FlowLayoutPanel()
        Header = New Panel()
        CName = New Label()
        AttPanel = New FlowLayoutPanel()
        OpPanel = New FlowLayoutPanel()
        Body.SuspendLayout()
        Header.SuspendLayout()
        SuspendLayout()
        ' 
        ' Mover
        ' 
        Mover.BackColor = Color.SkyBlue
        Mover.FlatStyle = FlatStyle.Flat
        Mover.Location = New Point(0, 0)
        Mover.Name = "Mover"
        Mover.Size = New Size(20, 20)
        Mover.TabIndex = 3
        Mover.UseVisualStyleBackColor = False
        Mover.Visible = False
        ' 
        ' Body
        ' 
        Body.AutoSize = True
        Body.Controls.Add(Header)
        Body.Controls.Add(AttPanel)
        Body.Controls.Add(OpPanel)
        Body.Dock = DockStyle.Top
        Body.Location = New Point(0, 0)
        Body.Name = "Body"
        Body.Padding = New Padding(5)
        Body.Size = New Size(310, 66)
        Body.TabIndex = 4
        ' 
        ' Header
        ' 
        Header.Controls.Add(CName)
        Header.Margin = New Padding(0)
        Header.Name = "Header"
        Header.Size = New Size(300, 50)
        Header.TabIndex = 0
        ' 
        ' CName
        ' 
        CName.Dock = DockStyle.Fill
        CName.Name = "CName"
        CName.Size = New Size(300, 50)
        CName.TabIndex = 0
        CName.Text = "Label1"
        CName.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' AttPanel
        ' 
        AttPanel.AutoSize = True
        AttPanel.Margin = New Padding(0, 10, 0, 0)
        AttPanel.Name = "AttPanel"
        AttPanel.Size = New Size(0, 0)
        AttPanel.TabIndex = 1
        AttPanel.MaximumSize = New Size(300, 0)
        ' 
        ' OpPanel
        ' 
        OpPanel.AutoSize = True
        OpPanel.Margin = New Padding(0, 10, 0, 0)
        OpPanel.Name = "OpPanel"
        OpPanel.Size = New Size(0, 0)
        OpPanel.TabIndex = 2
        OpPanel.MaximumSize = New Size(300, 0)
        ' 
        ' UMLClassView
        ' 
        BackColor = Color.White
        Controls.Add(Mover)
        Controls.Add(Body)
        Name = "UMLClassView"
        Size = New Size(310, 68)
        Body.ResumeLayout(False)
        Body.PerformLayout()
        Header.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Mover As Button
    Friend WithEvents Body As FlowLayoutPanel
    Friend WithEvents Header As Panel
    Friend WithEvents AttPanel As FlowLayoutPanel
    Friend WithEvents OpPanel As FlowLayoutPanel
    Friend WithEvents CName As Label

End Class
