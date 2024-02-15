Public Class UMLParameter

    Public Name As String

    Public Type As String

    Public DefaultValue As String

    Public Sub New()
        Name = "Param"
        Type = "String"
    End Sub

    Public Overrides Function ToString() As String
        Return Name & " : " & Type & If(DefaultValue Is Nothing, "", "=" & DefaultValue)
    End Function

End Class
