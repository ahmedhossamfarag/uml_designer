Public Class BoolProperty
    Inherits PProperty(Of Boolean)

    Public Sub New(name As String, val As Boolean)
        MyBase.New(name, val)
        View = New BoolPropertyView(Me)
    End Sub

End Class
