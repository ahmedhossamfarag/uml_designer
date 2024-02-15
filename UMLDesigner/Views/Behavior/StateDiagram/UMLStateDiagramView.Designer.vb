<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UMLStateDiagramView
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
        Tools = New FlowLayoutPanel()
        NStateTool = New ToolView()
        CStateTool = New ToolView()
        IStateTool = New ToolView()
        FStateTool = New ToolView()
        LUTool = New ToolView()
        LTTool = New ToolView()
        LZTool = New ToolView()
        LNTool = New ToolView()
        LUDTool = New ToolView()
        LODTool = New ToolView()
        Properties = New FlowLayoutPanel()
        Diagram = New ShapeContainer()
        Tools.SuspendLayout()
        SuspendLayout()
        ' 
        ' Tools
        ' 
        Tools.Controls.Add(NStateTool)
        Tools.Controls.Add(CStateTool)
        Tools.Controls.Add(IStateTool)
        Tools.Controls.Add(FStateTool)
        Tools.Controls.Add(LUTool)
        Tools.Controls.Add(LTTool)
        Tools.Controls.Add(LZTool)
        Tools.Controls.Add(LNTool)
        Tools.Controls.Add(LUDTool)
        Tools.Controls.Add(LODTool)
        Tools.Dock = DockStyle.Left
        Tools.Location = New Point(0, 0)
        Tools.Name = "Tools"
        Tools.Size = New Size(56, 800)
        Tools.TabIndex = 0
        ' 
        ' NStateTool
        ' 
        NStateTool.Name = "NStateTool"
        ' 
        ' CStateTool
        ' 
        CStateTool.Name = "CStateTool"
        ' 
        ' IStateTool
        ' 
        IStateTool.Name = "IStateTool"
        ' 
        ' FStateTool
        ' 
        FStateTool.Name = "FStateTool"
        ' 
        ' LUTool
        ' 
        LUTool.Name = "LUTool"
        ' 
        ' LTTool
        ' 
        LTTool.Name = "LTTool"
        ' 
        ' LZTool
        ' 
        LZTool.Name = "LZTool"
        ' 
        ' LNTool
        ' 
        LNTool.Name = "LNTool"
        ' 
        ' LUDTool
        ' 
        LUDTool.Name = "LUDTool"
        ' 
        ' LODTool
        ' 
        LODTool.Name = "LODTool"
        ' 
        ' Properties
        ' 
        Properties.Dock = DockStyle.Right
        Properties.Location = New Point(700, 0)
        Properties.Name = "Properties"
        Properties.Size = New Size(300, 800)
        Properties.TabIndex = 1
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
        ' UMLStateDiagramView
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Properties)
        Controls.Add(Tools)
        Controls.Add(Diagram)
        Name = "UMLStateDiagramView"
        Size = New Size(1000, 800)
        Tools.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Tools As FlowLayoutPanel
    Friend WithEvents Properties As FlowLayoutPanel
    Friend WithEvents NStateTool As ToolView
    Friend WithEvents CStateTool As ToolView
    Friend WithEvents IStateTool As ToolView
    Friend WithEvents FStateTool As ToolView
    Friend WithEvents LUTool As ToolView
    Friend WithEvents LTTool As ToolView
    Friend WithEvents LZTool As ToolView
    Friend WithEvents LNTool As ToolView
    Friend WithEvents LUDTool As ToolView
    Friend WithEvents Diagram As ShapeContainer
    Friend WithEvents LODTool As ToolView

End Class
