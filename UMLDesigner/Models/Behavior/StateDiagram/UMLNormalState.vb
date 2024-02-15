Public Class UMLNormalState
    Inherits UMLState

    Public Name As String

    Public EntryClause As String

    Public DoClause As String

    Public ExitClaue As String

    Public Sub New()
        MyBase.New(UMLStateType.Normal)
        Name = "State"
    End Sub
End Class
