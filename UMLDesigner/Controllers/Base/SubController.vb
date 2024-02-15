Public MustInherit Class SubController(Of M, V, C)
    Inherits Controller(Of M, V)

    Public SuperController As C

    Protected Sub New(ByRef mdl As M, ByRef cnt As C)
        MyBase.New(mdl)
        SuperController = cnt
    End Sub
End Class
