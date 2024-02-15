Public Class UMLCompositState
    Inherits UMLState

    Public Name As String

    Public Size As Size

    Public SubStates As List(Of UMLState)

    Public Sub New()
        MyBase.New(UMLStateType.Composit)
        Name = "Composite State"
        Size = New Size(400, 400)
        SubStates = New List(Of UMLState)
    End Sub
End Class
