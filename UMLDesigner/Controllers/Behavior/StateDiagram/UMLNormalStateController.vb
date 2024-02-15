Public Class UMLNormalStateController
    Inherits SubController(Of UMLNormalState, UMLNormalStateView, UMLStateDiagramController)
    Implements HasProperties, HasActions, Focusable

    Private WithEvents NameP, EntryP, DoP, ExitP As TextProperty
    Private WithEvents Delete As Button

    Public Sub New(ByRef mdl As UMLNormalState, ByRef cnt As UMLStateDiagramController)
        MyBase.New(mdl, cnt)
    End Sub


    Public Overrides Sub CreateView()
        View = New UMLNormalStateView With {
            .DiagramController = SuperController,
            .Controller = Me,
            .Model = Model
        }
        NameP = New TextProperty("Name", Model.Name)
        EntryP = New TextProperty("Entry", Model.EntryClause)
        DoP = New TextProperty("Do", Model.DoClause)
        ExitP = New TextProperty("Exit", Model.ExitClaue)
        Delete = New ActionButton("Delete")
    End Sub

#Region "Model"

    Private Sub SetName(val As String) Handles NameP.Change
        Model.Name = val
        View.Model = Model
    End Sub

    Private Sub SetEntry(val As String) Handles EntryP.Change
        Model.EntryClause = val
        View.Model = Model
    End Sub

    Private Sub SetDo(val As String) Handles DoP.Change
        Model.DoClause = val
        View.Model = Model
    End Sub

    Private Sub SetExit(val As String) Handles ExitP.Change
        Model.ExitClaue = val
        View.Model = Model
    End Sub

    Private Sub DeleteMe(s As Object, e As EventArgs) Handles Delete.Click
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
            Return New List(Of HasView) From {NameP, EntryP, DoP, ExitP}
        End Get
    End Property

    Public ReadOnly Property Actions As List(Of Button) Implements HasActions.Actions
        Get
            Return New List(Of Button) From {Delete}
        End Get
    End Property

#End Region
End Class
