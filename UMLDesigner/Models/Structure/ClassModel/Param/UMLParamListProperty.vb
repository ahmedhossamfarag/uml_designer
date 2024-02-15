Public Class UMLParamListProperty
    Inherits PProperty(Of List(Of UMLParameter))

    Public Sub New(name As String, val As List(Of UMLParameter))
        MyBase.New(name, val)
        View = New UMLParamListProView(Me)
    End Sub

End Class
