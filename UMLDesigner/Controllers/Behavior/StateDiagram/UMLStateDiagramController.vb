Public Class UMLStateDiagramController
    Inherits Controller(Of UMLStateDiagram, UMLStateDiagramView)
    Implements Scene

    Public States As Dictionary(Of UMLState, UMLStateView)
    Public CompStates As Dictionary(Of UMLCompositState, UMLCompositStateView)
    Public Transitions As Dictionary(Of UMLTransition, UMLTransitionView)


    Private FocusItem As Focusable

    Public Sub New(ByRef mdl As UMLStateDiagram)
        MyBase.New(mdl)
        States = New Dictionary(Of UMLState, UMLStateView)
        CompStates = New Dictionary(Of UMLCompositState, UMLCompositStateView)
        Transitions = New Dictionary(Of UMLTransition, UMLTransitionView)
    End Sub

#Region "View"

    Public Overrides Sub CreateView()
        View = New UMLStateDiagramView With {.Controller = Me}
        ViewStates()
        ViewTransitions()
        AdaptChange()
    End Sub

    Private Sub ViewStates()
        For Each s In Model.States
            ViewState(s)
        Next
    End Sub

    Private Sub ViewState(s As UMLState)
        Select Case s.Type
            Case UMLStateType.Normal
                ViewNState(CType(s, UMLNormalState))
                Exit Select
            Case UMLStateType.Composit
                ViewCState(CType(s, UMLCompositState))
                Exit Select
            Case Else
                ViewIFState(s)
        End Select
    End Sub

    Private Sub ViewNState(s As UMLNormalState)
        Dim cnt = New UMLNormalStateController(s, Me)
        cnt.CreateView()
        Dim v = cnt.View
        View.Diagram.Controls.Add(v)
        States.Add(s, v)
    End Sub

    Private Sub ViewCState(s As UMLCompositState)
        Dim cnt = New UMLCompositStateController(s, Me)
        cnt.CreateView()
        Dim v = cnt.View
        View.Diagram.Controls.Add(v)
        View.Diagram.Shapes.Add(v.Rec)
        v.Rec.Parent = View.Diagram
        v.Rec.Invalidate()
        States.Add(s, v)
        CompStates.Add(s, v)
    End Sub

    Private Sub ViewIFState(s As UMLState)
        Dim cnt = New UMLIFStateController(s, Me)
        cnt.CreateView()
        Dim v = cnt.View
        View.Diagram.Controls.Add(v)
        States.Add(s, v)
    End Sub

    Private Sub ViewTransitions()
        For Each t In Model.Transitions
            ViewTrans(t)
        Next
    End Sub

    Private Sub ViewTrans(t As UMLTransition)
        Dim cnt = New UMLTransitionController(t, Me)
        cnt.CreateView()
        Dim v = cnt.View
        View.Diagram.Shapes.Add(v)
        v.Parent = View.Diagram
        v.Invalidate()
        Transitions.Add(t, v)
    End Sub

#End Region

#Region "Model"

    Public Sub NewState(s As UMLState, p As Point)
        s.Location = p
        Model.States.Add(s)
        ViewState(s)
        StateMove(States(s))
        AdaptChange()
    End Sub

    Public Sub RemoveState(s As UMLState)
        Model.States.Remove(s)
        Dim v = States(s)
        View.Diagram.Controls.Remove(v)
        States.Remove(s)
        SetIdeal()
        Dim ts = Model.Transitions.FindAll(Function(t) t.FromS.Equals(s) Or t.ToS.Equals(s))
        For Each t In ts
            RemoveTrans(t)
        Next
        AdaptChange()
    End Sub

    Public Sub RemoveComState(cs As UMLCompositState)
        RemoveState(cs)
        Dim v = CompStates(cs)
        CompStates.Remove(cs)
        Dim r = v.Rec
        r.Invalidate()
        View.Diagram.Shapes.Remove(r)
        AdaptChange()
        For Each s In cs.SubStates
            States(s).ComStateController = Nothing
        Next
    End Sub

    Public Sub RemoveComStateAll(cs As UMLCompositState)
        RemoveComState(cs)
        For Each s In cs.SubStates
            Dim c = TryCast(s, UMLCompositState)
            If c Is Nothing Then
                RemoveState(s)
            Else
                RemoveComStateAll(c)
            End If
        Next
    End Sub


    Private Sub RemoveTrans(t As UMLTransition)
        Model.Transitions.Remove(t)
        Dim tv = Transitions(t)
        View.Diagram.Shapes.Remove(tv)
        Transitions.Remove(t)
        tv.Invalidate()
        SetIdeal()
    End Sub

    Public Sub RemoveTransition(t As UMLTransition)
        RemoveTrans(t)
        AdaptChange()
    End Sub

#End Region

#Region "Transition"

    Private Trans As UMLTransition

    Public Sub NewTransition(m As LineMode)
        Trans = New UMLTransition With {.Mode = m}
    End Sub

    Public Sub StateClick(s As UMLState)
        If Trans IsNot Nothing Then
            If Trans.FromS Is Nothing Then
                Trans.FromS = s
            Else
                Trans.ToS = s
                Model.Transitions.Add(Trans)
                ViewTrans(Trans)
                AdaptChange()
                Trans = Nothing
                View.FreeTools()
            End If
        End If
    End Sub

#End Region

#Region "Control"
    Friend Sub StateMove(s As UMLStateView)
        If s.ComStateController Is Nothing Then
            For Each cs In CompStates.Values
                If Not s.Equals(cs) And cs.Controller.Contains(s.Location) Then
                    cs.Controller.Add(s)
                End If
            Next
        End If
    End Sub

#End Region

#Region "Focus"

    Public Sub SetIdeal()
        FocusItem = Nothing
        View.Properties.Controls.Clear()
    End Sub

    Public Sub FocusOn(f As Focusable)
        If f.Equals(FocusItem) Then
            Return
        End If
        FocusItem?.FocusOut()
        FocusItem = f
        FocusItem?.FocusIn()
        View.Properties.Controls.Clear()
        Dim hp = TryCast(f, HasProperties)
        If hp IsNot Nothing Then
            Dim ps = hp.Properties
            For Each p In ps
                View.Properties.Controls.Add(p.CreateView())
            Next
        End If
        Dim ha = TryCast(f, HasActions)
        If ha IsNot Nothing Then
            View.Properties.Controls.AddRange(ha.Actions.ToArray)
        End If

    End Sub

    Friend Sub AdaptChange()
        View.Diagram.RePaint()
    End Sub
#End Region

#Region "Interface"


    Public ReadOnly Property SceneView As Control Implements Scene.SceneView
        Get
            Return View
        End Get
    End Property

    Public ReadOnly Property SceneName As String Implements Scene.SceneName
        Get
            Return If(Model.Name Is Nothing, "State Diagram", Model.Name.Substring(Model.Name.LastIndexOf("\\") + 1))
        End Get
    End Property

    Public Sub Save() Implements Scene.Save
        SDWriter.Write(Model)
    End Sub

    Public Sub Print() Implements Scene.Print
        Printer.Print(View.Diagram, SceneName)
    End Sub
#End Region
End Class
