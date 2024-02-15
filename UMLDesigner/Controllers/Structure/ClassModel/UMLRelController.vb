Public Class UMLRelController
    Inherits SubController(Of UMLRelation, UMLRelView, UMLClassModelController)
    Implements Focusable, HasProperties, HasActions

    Private WithEvents TitleP As TextProperty
    Private WithEvents TypeP As EnumProperty(Of UMLRelType)
    Private WithEvents CardMin, CardMax As IntProperty

    Private WithEvents Delete As Button

    Public FromC, ToC As UMLClassView

    Public Sub New(ByRef mdl As UMLRelation, ByRef cnt As UMLClassModelController)
        MyBase.New(mdl, cnt)
    End Sub

    Public Overrides Sub CreateView()
        Dim ad = LineAdaptor.Adapt(FromC.Bounds, ToC.Bounds)
        View = New UMLRelView(ad) With {.Controller = Me, .Model = Model, .FromC = FromC, .ToC = ToC}
        TitleP = New TextProperty("Title", Model.Title)
        TypeP = New EnumProperty(Of UMLRelType)("Type", Model.Type)
        CardMin = New IntProperty("Min Cardilaty", Model.Cardinality.Min)
        CardMax = New IntProperty("Max Cardilaty", Model.Cardinality.Max)
        Delete = New ActionButton("Delete")
    End Sub

#Region "Model"

    Public Sub SetTitle(title As String) Handles TitleP.Change
        Model.Title = title
        View.Invalidate()
        AdaptChange()
    End Sub

    Public Sub SetType(type As UMLRelType) Handles TypeP.Change
        Model.Type = type
        View.Invalidate()
        AdaptChange()
    End Sub

    Public Sub SetMin(val As Integer) Handles CardMin.Change
        Model.Cardinality.Min = val
        View.Invalidate()
        AdaptChange()
    End Sub

    Public Sub SetMax(val As Integer) Handles CardMax.Change
        Model.Cardinality.Max = val
        View.Invalidate()
        AdaptChange()
    End Sub

#End Region

#Region "Interface"

    Public Sub FocusIn() Implements Focusable.FocusIn
        View.FocusIn()
        AdaptChange()
    End Sub

    Public Sub FocusOut() Implements Focusable.FocusOut
        View.FocusOut()
        AdaptChange()
    End Sub


    Public ReadOnly Property Properties As List(Of HasView) Implements HasProperties.Properties
        Get
            Return New List(Of HasView) From {TitleP, TypeP, CardMin, CardMax}
        End Get
    End Property

    Public ReadOnly Property Actions As List(Of Button) Implements HasActions.Actions
        Get
            Return New List(Of Button) From {Delete}
        End Get
    End Property

#End Region

    Friend Sub View_Click()
        SuperController.FocusOn(Me)
    End Sub

    Public Sub DeleteMe(sender As Object, e As EventArgs) Handles Delete.Click
        SuperController.RemoveRelation(Model)
    End Sub

    Friend Sub AdaptChange()
        SuperController.AdaptChange()
    End Sub
End Class
