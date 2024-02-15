Public MustInherit Class Controller(Of M, V)

    Public Model As M

    Public View As V

    Public Sub New(ByRef mdl As M)
        Model = mdl
    End Sub

    Public MustOverride Sub CreateView()

End Class
