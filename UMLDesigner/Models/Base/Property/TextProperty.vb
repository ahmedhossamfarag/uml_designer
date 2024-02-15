Public Class TextProperty
    Inherits PProperty(Of String)

    Public Sub New(name As String, val As String)
        MyBase.New(name, val)
        View = New TextPropertyView(Me)
    End Sub

End Class
