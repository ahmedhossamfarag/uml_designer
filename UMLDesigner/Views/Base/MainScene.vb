Public Class MainScene
    Implements Scene

    Public Program As Program

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CMEntry.Image = My.Resources.CMImage
        SDEntry.Image = My.Resources.SDImage
    End Sub


    Private Sub MainScene_Layout(sender As Object, e As LayoutEventArgs) Handles MyBase.Layout
        Dim gw = Width - CMEntry.Width - SDEntry.Width
        gw = gw / 3
        Dim gh = Height - CMEntry.Height
        gh = gh / 2
        CMEntry.Location = New Point(gw, gh)
        gw += CMEntry.Width + gw
        SDEntry.Location = New Point(gw, gh)
    End Sub



    Private Sub CMEntry_NewClick(sender As Object, e As EventArgs) Handles CMEntry.NewClick
        Dim cnt = New UMLClassModelController(New UMLClassModel)
        cnt.CreateView()
        Program.AddScene(cnt)
    End Sub

    Private Sub CMEntry_OpenClick(sender As Object, e As EventArgs) Handles CMEntry.OpenClick
        Dim cm = CMReader.Read()
        If cm IsNot Nothing Then
            Dim cnt = New UMLClassModelController(cm)
            cnt.CreateView()
            Program.AddScene(cnt)
        End If
    End Sub

    Private Sub SDEntry_NewClick(sender As Object, e As EventArgs) Handles SDEntry.NewClick
        Dim cnt = New UMLStateDiagramController(New UMLStateDiagram)
        cnt.CreateView()
        Program.AddScene(cnt)
    End Sub

    Private Sub SDEntry_OpenClick(sender As Object, e As EventArgs) Handles SDEntry.OpenClick
        Dim sd = SDReader.Read()
        If sd IsNot Nothing Then
            Dim cnt = New UMLStateDiagramController(sd)
            cnt.CreateView()
            Program.AddScene(cnt)
        End If
    End Sub

#Region "Interface"

    Public ReadOnly Property SceneName As String Implements Scene.SceneName
        Get
            Return "Main"
        End Get
    End Property

    Public ReadOnly Property SceneView As Control Implements Scene.SceneView
        Get
            Return Me
        End Get
    End Property

    Public Sub Save() Implements Scene.Save
    End Sub

    Public Sub Print() Implements Scene.Print
    End Sub

#End Region
End Class
