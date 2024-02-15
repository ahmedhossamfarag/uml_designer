Public Class Program

    Private CurrentScene As SceneLabel

    Public Sub New()

        InitializeComponent()

        Text = My.Resources.ProgramTitle
        MainSceneView.Program = Me
        MainLabel.Program = Me
        MainLabel.Removable = False
        SetScene(MainLabel)
    End Sub

    Public Sub AddScene(scene As Scene)
        Dim label = New SceneLabel With {.Scene = scene, .Program = Me}
        Header.Controls.Add(label)
        Controls.Add(scene.SceneView)
        SetScene(label)
    End Sub

    Public Sub SetScene(label As SceneLabel)
        If label.Equals(CurrentScene) Then
            Return
        End If
        CurrentScene?.Adjust(False)
        label.Adjust(True)
        Dim sc = label.Scene
        Me.CurrentScene = label
        History.SetTimeLine(sc.GetHashCode)
        sc.SceneView.BringToFront()
    End Sub

    Friend Sub RemoveScene(sceneLabel As SceneLabel)
        Controls.Remove(sceneLabel.Scene.SceneView)
        Header.Controls.Remove(sceneLabel)
        History.RemoveTimeLIne(sceneLabel.Scene.GetHashCode)
        CurrentScene = Nothing
        SetScene(MainLabel)
    End Sub

    Private Sub Program_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Select Case e.KeyChar
            Case ChrW(26)
                History.Backward()
                Exit Select
            Case ChrW(25)
                History.Forward()
                Exit Select
            Case ChrW(19)
                CurrentScene?.Scene.Save()
                CurrentScene?.Review()
                Exit Select
            Case ChrW(16)
                CurrentScene?.Scene.Print()
                Exit Select
        End Select
    End Sub

    Private Sub Program_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainSceneView.Focus()
    End Sub
End Class
