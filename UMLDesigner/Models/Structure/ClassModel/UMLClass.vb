Public Class UMLClass

    Public Name As String

    Public Abstract As Boolean

    Public Attributes As List(Of UMLAttribute)

    Public Operations As List(Of UMLOperation)

    Public Location As Point

    Public Sub New()
        Name = "ClassName"
        Attributes = New List(Of UMLAttribute)
        Operations = New List(Of UMLOperation)
    End Sub

    Public Overrides Function ToString() As String
        Return Name
    End Function

End Class
