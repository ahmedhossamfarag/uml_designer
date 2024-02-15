Public Class UMLIFStateController
    Inherits SubController(Of UMLState, UMLIFStateView, UMLStateDiagramController)
    Implements HasProperties, HasActions, Focusable


    Private WithEvents Delete As Button

    Public Sub New(ByRef mdl As UMLState, ByRef cnt As UMLStateDiagramController)
        MyBase.New(mdl, cnt)
    End Sub


    Public Overrides Sub CreateView()
        View = New UMLIFStateView With {
         .DiagramController = SuperController,
         .Controller = Me,
         .Model = Model
        }
        Delete = New ActionButton("Delete")
    End Sub

#Region "Model"

    Private Sub DeleteMe() Handles Delete.Click
        SuperController.RemoveState(Model)
    End Sub

#End Region

#Region "Interface"

    Public Sub FocusIn() Implements Focusable.FocusIn
        View.FocusIn()
    End Sub

    Public Sub FocusOut() Implements Focusable.FocusOut
        View.FocusOut()
    End Sub

    Public ReadOnly Property Properties As List(Of HasView) Implements HasProperties.Properties
        Get
            Return New List(Of HasView)
        End Get
    End Property

    Public ReadOnly Property Actions As List(Of Button) Implements HasActions.Actions
        Get
            Return New List(Of Button) From {Delete}
        End Get
    End Property

#End Region

End Class
