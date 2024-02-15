Public Class UMLStateDiagramView

    Public Controller As UMLStateDiagramController

    Private MoveControl As MoveController
    Private ActiveTool As Control

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dock = DockStyle.Fill
        MoveControl = New MoveController(Diagram, Diagram)

        NStateTool.Painting = AddressOf UMLSDTools.NSTool_Paint
        CStateTool.Painting = AddressOf UMLSDTools.CSTool_Paint
        IStateTool.Painting = AddressOf UMLSDTools.ISTool_Paint
        FStateTool.Painting = AddressOf UMLSDTools.FSTool_Paint
        LUTool.Painting = AddressOf UMLSDTools.LUTool_Paint
        LTTool.Painting = AddressOf UMLSDTools.LTTool_Paint
        LZTool.Painting = AddressOf UMLSDTools.LZTool_Paint
        LNTool.Painting = AddressOf UMLSDTools.LNTool_Paint
        LUDTool.Painting = AddressOf UMLSDTools.LUDTool_Paint
        LODTool.Painting = AddressOf UMLSDTools.LODTool_Paint

        NStateTool.DragData = AddressOf UMLSDTools.NSTool_DragData
        CStateTool.DragData = AddressOf UMLSDTools.CSTool_DragData
        IStateTool.DragData = AddressOf UMLSDTools.ISTool_DragData
        FStateTool.DragData = AddressOf UMLSDTools.FSTool_DragData

        LUTool.ClickAction = AddressOf NewTransition
        LTTool.ClickAction = AddressOf NewTransition
        LZTool.ClickAction = AddressOf NewTransition
        LNTool.ClickAction = AddressOf NewTransition
        LUDTool.ClickAction = AddressOf NewTransition
        LODTool.ClickAction = AddressOf NewTransition

        LUTool.Data = LineMode.L
        LTTool.Data = LineMode.T
        LZTool.Data = LineMode.Z
        LNTool.Data = LineMode.N
        LUDTool.Data = LineMode.UD
        LODTool.Data = LineMode.OD


    End Sub


    Private Sub Diagram_DragEnter(sender As Object, e As DragEventArgs) Handles Diagram.DragEnter
        If e.Data.GetDataPresent(GetType(UMLStateType)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Diagram_DragDrop(sender As Object, e As DragEventArgs) Handles Diagram.DragDrop
        If e.Data.GetDataPresent(GetType(UMLStateType)) Then
            Dim st As UMLStateType = e.Data.GetData(GetType(UMLStateType))
            Dim s As UMLState
            Select Case st
                Case UMLStateType.Normal
                    s = New UMLNormalState
                    Exit Select
                Case UMLStateType.Composit
                    s = New UMLCompositState
                    Exit Select
                Case Else
                    s = New UMLState(st)
            End Select
            Controller.NewState(s, PointToClient(New Point(e.X, e.Y)))
        End If
    End Sub


    Public Sub NewTransition(t As ToolView)
        If ActiveTool IsNot Nothing Then
            FreeTools()
        End If
        ActiveTool = t
        Controller.NewTransition(t.Data)
    End Sub


    Friend Sub FreeTools()
        ActiveTool.BackColor = Tools.BackColor
    End Sub
End Class
