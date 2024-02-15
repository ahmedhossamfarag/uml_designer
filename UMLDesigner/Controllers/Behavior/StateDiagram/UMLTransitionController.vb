Public Class UMLTransitionController
    Inherits SubController(Of UMLTransition, UMLTransitionView, UMLStateDiagramController)
    Implements HasProperties, HasActions, Focusable

    Private WithEvents ActionP As TextProperty
    Private WithEvents Delete As Button


    Public Sub New(ByRef mdl As UMLTransition, ByRef cnt As UMLStateDiagramController)
        MyBase.New(mdl, cnt)
    End Sub

    Public Overrides Sub CreateView()
        Dim s1 = SuperController.States(Model.FromS)
        Dim s2 = SuperController.States(Model.ToS)
        Dim ad = LineAdaptor.Adapt(s1.FullBounds, s2.FullBounds, Model.Mode)
        View = New UMLTransitionView(ad) With {
        .DiagramController = SuperController,
        .Controller = Me,
        .FromS = s1,
        .ToS = s2,
        .Model = Model
        }
        ActionP = New TextProperty("Action", Model.Action)
        Delete = New ActionButton("Delete")
    End Sub

#Region "Model"

    Public Sub SetAction(val As String) Handles ActionP.Change
        Model.Action = val
        View.Invalidate()
        SuperController.AdaptChange()
    End Sub

    Public Sub DeleteMe() Handles Delete.Click
        SuperController.RemoveTransition(Model)
    End Sub

#End Region

#Region "Interface"

    Public Sub FocusIn() Implements Focusable.FocusIn
        View.FocusIn()
        SuperController.AdaptChange()
    End Sub

    Public Sub FocusOut() Implements Focusable.FocusOut
        View.FocusOut()
        SuperController.AdaptChange()
    End Sub

    Public ReadOnly Property Properties As List(Of HasView) Implements HasProperties.Properties
        Get
            Return New List(Of HasView) From {ActionP}
        End Get
    End Property

    Public ReadOnly Property Actions As List(Of Button) Implements HasActions.Actions
        Get
            Return New List(Of Button) From {Delete}
        End Get
    End Property

#End Region

End Class
