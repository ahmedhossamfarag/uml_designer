Public Class IntProperty
    Inherits PProperty(Of Integer)

    Public Sub New(name As String, val As Integer)
        MyBase.New(name, val)
        View = New IntPropertyView(Me)
    End Sub

End Class
