Public Class UMLState

    Public Location As Point

    Public Type As UMLStateType

    Public Id As Integer

    Public Sub New(Optional type As UMLStateType = UMLStateType.Initial)
        Me.Type = type
    End Sub

End Class
