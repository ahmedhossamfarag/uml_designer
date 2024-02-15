Public Class UMLCompositStateController
    Inherits SubController(Of UMLCompositState, UMLCompositStateView, UMLStateDiagramController)
    Implements HasProperties, HasActions, Focusable


    Private WithEvents Name As TextProperty
    Private WithEvents Delete, DeleteAll As Button

    Public Sub New(ByRef mdl As UMLCompositState, ByRef cnt As UMLStateDiagramController)
        MyBase.New(mdl, cnt)
    End Sub


    Public Overrides Sub CreateView()
        View = New UMLCompositStateView With {
        .DiagramController = SuperController,
        .Controller = Me,
        .Model = Model
        }
        For Each s In Model.SubStates
            Dim sv = SuperController.States(s)
            sv.ComStateController = Me
            View.SubStates.Add(sv)
        Next
        Name = New TextProperty("Name", Model.Name)
        Delete = New ActionButton("Delete")
        DeleteAll = New ActionButton("Delete All")
    End Sub

#Region "Model"

    Public Sub SetName(val As String) Handles Name.Change
        Model.Name = val
        View.Model = Model
    End Sub

    Public Sub DeleteMe() Handles Delete.Click
        SuperController.RemoveComState(Model)
    End Sub

    Public Sub DeleteMeAll() Handles DeleteAll.Click
        SuperController.RemoveComStateAll(Model)
    End Sub

    Friend Sub Add(s As UMLStateView)
        s.ComStateController = Me
        Model.SubStates.Add(s.BaseModel)
        View.SubStates.Add(s)
        View.Include(s.FullBounds)
    End Sub

    Friend Sub Include(s As UMLStateView)
        If Contains(s.Location) Then
            View.Include(s.FullBounds)
        Else
            s.ComStateController = Nothing
            Model.SubStates.Remove(s.BaseModel)
            View.SubStates.Remove(s)
        End If
    End Sub

    Public Function Contains(location As Point) As Boolean
        If View.FullBounds.Contains(location) Then
            For Each s In View.SubStates
                If TypeOf s Is UMLCompositStateView Then
                    If s.FullBounds.Contains(location) Then
                        Return False
                    End If
                End If
            Next
            Return True
        End If
        Return False
    End Function

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
            Return New List(Of HasView) From {Name}
        End Get
    End Property

    Public ReadOnly Property Actions As List(Of Button) Implements HasActions.Actions
        Get
            Return New List(Of Button) From {Delete, DeleteAll}
        End Get
    End Property

#End Region

End Class
