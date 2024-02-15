Public Class UMLClassModel

    Public Name As String

    Public Classes As List(Of UMLClass)

    Public Relations As List(Of UMLRelation)

    Public Sub New()
        Name = Nothing
        Classes = New List(Of UMLClass)
        Relations = New List(Of UMLRelation)
    End Sub

End Class
