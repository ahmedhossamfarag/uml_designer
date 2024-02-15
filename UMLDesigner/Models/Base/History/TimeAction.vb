Public Class TimeAction

    Public Action As Action(Of Object)

    Public Param As Object

    Public Sub Invoke()
        Action?.Invoke(Param)
    End Sub

End Class
