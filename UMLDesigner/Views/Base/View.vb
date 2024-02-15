Public MustInherit Class View(Of M, C)
    Inherits UserControl

    Public Model As M

    Public Controller As C

    Public Sub New(ByRef mdl As M, ByRef cnt As C)
        Model = mdl
        Controller = cnt
    End Sub

    Public MustOverride Sub InitializeComponent()

End Class
