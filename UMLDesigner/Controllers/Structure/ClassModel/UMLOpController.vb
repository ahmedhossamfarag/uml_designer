Public Class UMLOpController
    Inherits SubController(Of UMLOperation, UMLOpView, UMLClassController)
    Implements Focusable, HasProperties, HasActions

    Private WithEvents NameP, TypeP As TextProperty
    Private WithEvents AccessP As EnumProperty(Of UMLAccess)
    Private WithEvents ParamList As UMLParamListProperty

    Private WithEvents Delete As Button

    Public Sub New(ByRef mdl As UMLOperation, ByRef cnt As UMLClassController)
        MyBase.New(mdl, cnt)
    End Sub

    Public Overrides Sub CreateView()
        View = New UMLOpView With {.Controller = Me, .Model = Model}
        NameP = New TextProperty("Name", Model.Name)
        TypeP = New TextProperty("Return Type", Model.ReturnType)
        AccessP = New EnumProperty(Of UMLAccess)("Access", Model.Access)
        ParamList = New UMLParamListProperty("Parameters", Model.Parameters)
        Delete = New ActionButton("Delete")
    End Sub

#Region "Model"

    Public Sub ValidateName(name As String) Handles NameP.Validate
        If Model.Name <> name Then
            If SuperController.Model.Operations.Any(Function(c) c.Name = name) Then
                Throw New Exception
            End If
        End If
    End Sub

    Public Sub SetName(name As String) Handles NameP.Change
        Model.Name = name
        View.Model = Model
    End Sub

    Public Sub SetAccess(a As UMLAccess) Handles AccessP.Change
        Model.Access = a
        View.Model = Model
    End Sub

    Public Sub SetType(t As String) Handles TypeP.Change
        Model.ReturnType = t
        View.Model = Model
    End Sub

    Public Sub SetParam(list As List(Of UMLParameter)) Handles ParamList.Change
        Model.Parameters = list
        View.Model = Model
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
            Return New List(Of HasView) From {NameP, TypeP, AccessP, ParamList}
        End Get
    End Property

    Public ReadOnly Property Actions As List(Of Button) Implements HasActions.Actions
        Get
            Return New List(Of Button) From {Delete}
        End Get
    End Property

#End Region

    Public Sub DeleteMe(sender As Object, e As EventArgs) Handles Delete.Click
        SuperController.RemoveOp(Me)
    End Sub

    Friend Sub View_Click()
        SuperController.FocusOn(Me)
    End Sub
End Class
