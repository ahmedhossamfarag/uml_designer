Public Class UMLClassController
    Inherits SubController(Of UMLClass, UMLClassView, UMLClassModelController)
    Implements Focusable, HasProperties, HasActions

    Private WithEvents NameP As TextProperty
    Private WithEvents AbstractP As BoolProperty

    Private WithEvents NewAtt, NewOp, Delete As Button

    Public Sub New(ByRef mdl As UMLClass, ByRef cnt As UMLClassModelController)
        MyBase.New(mdl, cnt)
    End Sub

#Region "View"

    Public Overrides Sub CreateView()
        View = New UMLClassView With {.Controller = Me, .Model = Model}
        ViewAtts()
        ViewOps()
        InitializeProps()
    End Sub

    Private Sub ViewAtts()
        For Each a In Model.Attributes
            ViewAtt(a)
        Next
    End Sub

    Private Sub ViewAtt(a As UMLAttribute)
        Dim cnt = New UMLAttrController(a, Me)
        cnt.CreateView()
        View.AttPanel.Controls.Add(cnt.View)
    End Sub

    Private Sub ViewOps()
        For Each op In Model.Operations
            ViewOp(op)
        Next
    End Sub

    Private Sub ViewOp(op As UMLOperation)
        Dim cnt = New UMLOpController(op, Me)
        cnt.CreateView()
        View.OpPanel.Controls.Add(cnt.View)
    End Sub


    Private Sub InitializeProps()
        NameP = New TextProperty("Name", Model.Name)
        AbstractP = New BoolProperty("Abstract", Model.Abstract)
        NewAtt = New ActionButton("New Attribute")
        NewOp = New ActionButton("New Operation")
        Delete = New ActionButton("Delete")
    End Sub

#End Region

#Region "Model"

    Public Sub ValidateName(name As String) Handles NameP.Validate
        If Model.Name <> name Then
            If SuperController.Model.Classes.Any(Function(c) c.Name = name) Then
                Throw New Exception
            End If
        End If
    End Sub

    Public Sub SetName(name As String) Handles NameP.Change
        Model.Name = name
        View.Model = Model
    End Sub

    Public Sub SetAbstract(flag As Boolean) Handles AbstractP.Change
        Model.Abstract = flag
        View.Model = Model
    End Sub

#End Region

#Region "Attributes"

    Public Sub AddAttr(sender As Object, e As EventArgs) Handles NewAtt.Click
        Dim a = New UMLAttribute
        Dim name = "Att"
        For i = 1 To Model.Attributes.Count
            If Not Model.Attributes.Any(Function(at) at.Name = name) Then
                Exit For
            End If
            name = "Att" & i
        Next
        a.Name = name
        ViewAtt(a)
        Model.Attributes.Add(a)
    End Sub

    Public Sub RemoveAttr(a As UMLAttrController)
        Model.Attributes.Remove(a.Model)
        View.AttPanel.Controls.Remove(a.View)
        SuperController.SetIdeal()
    End Sub

#End Region

#Region "Operations"

    Public Sub AddOp(sender As Object, e As EventArgs) Handles NewOp.Click
        Dim op = New UMLOperation
        Dim name = "Oper"
        For i = 1 To Model.Operations.Count
            If Not Model.Operations.Any(Function(at) at.Name = name) Then
                Exit For
            End If
            name = "Oper" & i
        Next
        op.Name = name
        ViewOp(op)
        Model.Operations.Add(op)
    End Sub

    Public Sub RemoveOp(op As UMLOpController)
        Model.Operations.Remove(op.Model)
        View.OpPanel.Controls.Remove(op.View)
        SuperController.SetIdeal()
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
            Return New List(Of HasView) From {NameP, AbstractP}
        End Get
    End Property

    Public ReadOnly Property Actions As List(Of Button) Implements HasActions.Actions
        Get
            Return New List(Of Button) From {NewAtt, NewOp, Delete}
        End Get
    End Property

#End Region

    Friend Sub View_Click()
        SuperController.FocusOn(Me)
        SuperController.Class_Click(Me)
    End Sub

    Friend Sub FocusOn(f As Focusable)
        SuperController.FocusOn(f)
    End Sub

    Public Sub DeleteMe(sender As Object, e As EventArgs) Handles Delete.Click
        SuperController.RemoveClass(Me)
    End Sub

    Friend Sub AdaptChange()
        SuperController.AdaptChange()
    End Sub

End Class
