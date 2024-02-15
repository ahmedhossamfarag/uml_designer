<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UMLClassModelView
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
        Properties = New Panel()
        PMessage = New Label()
        PContent = New FlowLayoutPanel()
        PHeader = New Label()
        Tools = New Panel()
        TMessage = New Label()
        TContent = New FlowLayoutPanel()
        AddClass = New Label()
        AddRel = New Label()
        THeader = New Label()
        Diagram = New ShapeContainer()
        Properties.SuspendLayout()
        Tools.SuspendLayout()
        TContent.SuspendLayout()
        SuspendLayout()
        ' 
        ' Properties
        ' 
        Properties.Controls.Add(PMessage)
        Properties.Controls.Add(PContent)
        Properties.Controls.Add(PHeader)
        Properties.Dock = DockStyle.Right
        Properties.Location = New Point(1539, 0)
        Properties.Name = "Properties"
        Properties.Size = New Size(300, 799)
        Properties.TabIndex = 0
        ' 
        ' PMessage
        ' 
        PMessage.Dock = DockStyle.Bottom
        PMessage.Location = New Point(0, 774)
        PMessage.Name = "PMessage"
        PMessage.Size = New Size(300, 25)
        PMessage.TabIndex = 4
        ' 
        ' PContent
        ' 
        PContent.Dock = DockStyle.Fill
        PContent.Location = New Point(0, 25)
        PContent.Name = "PContent"
        PContent.Size = New Size(300, 774)
        PContent.TabIndex = 3
        ' 
        ' PHeader
        ' 
        PHeader.BackColor = SystemColors.MenuHighlight
        PHeader.Dock = DockStyle.Top
        PHeader.Location = New Point(0, 0)
        PHeader.Name = "PHeader"
        PHeader.Size = New Size(300, 25)
        PHeader.TabIndex = 1
        PHeader.Text = "Properties"
        ' 
        ' Tools
        ' 
        Tools.Controls.Add(TMessage)
        Tools.Controls.Add(TContent)
        Tools.Controls.Add(THeader)
        Tools.Dock = DockStyle.Left
        Tools.Location = New Point(0, 0)
        Tools.Name = "Tools"
        Tools.Size = New Size(250, 799)
        Tools.TabIndex = 1
        ' 
        ' TMessage
        ' 
        TMessage.Dock = DockStyle.Bottom
        TMessage.Location = New Point(0, 774)
        TMessage.Name = "TMessage"
        TMessage.Size = New Size(250, 25)
        TMessage.TabIndex = 2
        ' 
        ' TContent
        ' 
        TContent.Controls.Add(AddClass)
        TContent.Controls.Add(AddRel)
        TContent.Dock = DockStyle.Fill
        TContent.Location = New Point(0, 25)
        TContent.Name = "TContent"
        TContent.Size = New Size(250, 774)
        TContent.TabIndex = 1
        ' 
        ' AddClass
        ' 
        AddClass.BackColor = Color.SkyBlue
        AddClass.Location = New Point(0, 0)
        AddClass.Margin = New Padding(0)
        AddClass.Name = "AddClass"
        AddClass.Size = New Size(250, 25)
        AddClass.TabIndex = 0
        AddClass.Text = " Class"
        ' 
        ' AddRel
        ' 
        AddRel.BackColor = Color.SkyBlue
        AddRel.Location = New Point(0, 25)
        AddRel.Margin = New Padding(0)
        AddRel.Name = "AddRel"
        AddRel.Size = New Size(250, 25)
        AddRel.TabIndex = 1
        AddRel.Text = "Relation"
        ' 
        ' THeader
        ' 
        THeader.BackColor = SystemColors.MenuHighlight
        THeader.Dock = DockStyle.Top
        THeader.Location = New Point(0, 0)
        THeader.Name = "THeader"
        THeader.Size = New Size(250, 25)
        THeader.TabIndex = 0
        THeader.Text = "Tools"
        ' 
        ' Diagram
        ' 
        Diagram.AllowDrop = True
        Diagram.BackColor = Color.White
        Diagram.Location = New Point(0, 0)
        Diagram.Name = "Diagram"
        Diagram.Size = New Size(2000, 2000)
        Diagram.TabIndex = 2
        ' 
        ' UMLClassModelView
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Tools)
        Controls.Add(Properties)
        Controls.Add(Diagram)
        Name = "UMLClassModelView"
        Size = New Size(1839, 799)
        Properties.ResumeLayout(False)
        Tools.ResumeLayout(False)
        TContent.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Properties As Panel
    Friend WithEvents Tools As Panel
    Friend WithEvents THeader As Label
    Friend WithEvents PMessage As Label
    Friend WithEvents PContent As FlowLayoutPanel
    Friend WithEvents PHeader As Label
    Friend WithEvents TMessage As Label
    Friend WithEvents TContent As FlowLayoutPanel
    Friend WithEvents Diagram As ShapeContainer
    Friend WithEvents AddClass As Label
    Friend WithEvents AddRel As Label

End Class
