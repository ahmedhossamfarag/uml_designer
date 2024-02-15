Public Class UMLStateDiagram

    Public Name As String

    Public States As List(Of UMLState)

    Public Transitions As List(Of UMLTransition)

    Public Sub New()
        States = New List(Of UMLState)
        Transitions = New List(Of UMLTransition)
    End Sub
End Class
