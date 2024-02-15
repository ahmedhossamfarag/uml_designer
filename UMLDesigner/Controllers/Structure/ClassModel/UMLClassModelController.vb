Public Class UMLClassModelController
    Inherits Controller(Of UMLClassModel, UMLClassModelView)
    Implements Scene

    Public Classes As Dictionary(Of UMLClass, UMLClassView)

    Public Relations As Dictionary(Of UMLRelation, UMLRelView)

    Public State As UMLCMState

    Private FocusItem As Focusable

    Public Sub New(ByRef mdl As UMLClassModel)
        MyBase.New(mdl)
        Classes = New Dictionary(Of UMLClass, UMLClassView)
        Relations = New Dictionary(Of UMLRelation, UMLRelView)
        State = UMLCMState.Ideal
    End Sub

#Region "View"
    Public Overrides Sub CreateView()
        View = New UMLClassModelView With {.Controller = Me}
        ViewClasses()
        ViewRelations()
        View.Diagram.RePaint()
    End Sub

    Private Sub ViewClasses()
        For Each c In Model.Classes
            ViewClass(c)
        Next
    End Sub

    Private Sub ViewClass(ByRef c As UMLClass)
        Dim cnt = New UMLClassController(c, Me)
        cnt.CreateView()
        Dim v = cnt.View
        View.Diagram.Controls.Add(v)
        Classes.Add(c, v)
    End Sub


    Private Sub ViewRelations()
        For Each r In Model.Relations
            ViewRel(r)
        Next
    End Sub

    Private Sub ViewRel(r As UMLRelation)
        Dim v1 = Classes(r.Src), v2 = Classes(r.Des)
        Dim rc = New UMLRelController(r, Me) With {.FromC = v1, .ToC = v2}
        rc.CreateView()
        Dim v = rc.View
        v.Parent = View.Diagram
        v.Invalidate()
        View.Diagram.Shapes.Add(v)
        Relations.Add(r, v)
    End Sub

#End Region

#Region "Classes"

    Public Sub AddClass(ByRef m As UMLClass, p As Point)
        m.Location = p
        Dim name = "Class"
        For i = 1 To Model.Classes.Count
            If Not Model.Classes.Any(Function(c) c.Name = name) Then
                Exit For
            End If
            name = "Class" & i
        Next
        m.Name = name
        Model.Classes.Add(m)
        ViewClass(m)
    End Sub

    Public Sub RemoveClass(c As UMLClassController)
        RemoveRels(c.Model)
        Model.Classes.Remove(c.Model)
        Classes.Remove(c.Model)
        View.Diagram.Controls.Remove(c.View)
        SetIdeal()
    End Sub

    Private Sub RemoveRels(c As UMLClass)
        Dim rs = Model.Relations.FindAll(Function(r) r.Src.Equals(c) Or r.Des.Equals(c))
        For Each r In rs
            RemoveRel(r)
        Next
        View.Diagram.RePaint()
    End Sub

#End Region

#Region "Relations"

    Public Sub AddRelation(r As UMLRelation)
        ViewRel(r)
        Model.Relations.Add(r)
        View.Diagram.RePaint()
    End Sub

    Public Sub RemoveRelation(r As UMLRelation)
        RemoveRel(r)
        View.Diagram.Invalidate()
        SetIdeal()
    End Sub

    Private Sub RemoveRel(r As UMLRelation)
        Model.Relations.Remove(r)
        Dim v = Relations(r)
        Relations.Remove(r)
        View.Diagram.Shapes.Remove(v)
        v.Invalidate()
    End Sub

#End Region

#Region "New Relation"

    Private NewRel As UMLRelation


    Public Sub Class_Click(c As UMLClassController)
        If State = UMLCMState.AddRelation Then
            If NewRel Is Nothing Then
                NewRel = New UMLRelation With {.Src = c.Model}
                FocusOn(c)
            Else
                NewRel.Des = c.Model
                AddRelation(NewRel)
                SetIdeal()
            End If
        End If
    End Sub

    Public Sub SetNewRel()
        State = UMLCMState.AddRelation
        FocusOut()
        NewRel = Nothing
        DisplayTMessage("Click On Two Classes In Series")
    End Sub

#End Region

#Region "Control&Focus"

    Public Sub SetIdeal()
        FocusOut()
        View.Free()
        State = UMLCMState.Ideal
        NewRel = Nothing
    End Sub

    Public Sub FocusOn(f As Focusable)
        If f.Equals(FocusItem) Then
            Return
        End If
        FocusItem?.FocusOut()
        FocusItem = f
        FocusItem?.FocusIn()
        View.PContent.Controls.Clear()
        Dim hp = TryCast(f, HasProperties)
        If hp IsNot Nothing Then
            Dim ps = hp.Properties
            For Each p In ps
                View.PContent.Controls.Add(p.CreateView())
            Next
        End If
        Dim ha = TryCast(f, HasActions)
        If ha IsNot Nothing Then
            View.PContent.Controls.AddRange(ha.Actions.ToArray)
        End If

    End Sub

    Public Sub FocusOut()
        FocusItem?.FocusOut()
        FocusItem = Nothing
        View.PContent.Controls.Clear()
    End Sub

    Public Sub DisplayTMessage(m As String)
        View.TMessage.Text = m
    End Sub

    Public Sub DisplayPMessage(m As String)
        View.PMessage.Text = m
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
            Return If(Model.Name Is Nothing, "Class Model", Model.Name.Substring(Model.Name.LastIndexOf("\") + 1))
        End Get
    End Property

    Public Sub Save() Implements Scene.Save
        CMWriter.Write(Model)
    End Sub

    Public Sub Print() Implements Scene.Print
        Printer.Print(View.Diagram, SceneName)
    End Sub
#End Region

End Class
