Public Class UMLAttribute

    Public Access As UMLAccess

    Public Name As String

    Public Type As String

    Public DefaultValue As String

    Public Sub New()
        Access = UMLAccess.PUBLIC_
        Name = "AttName"
        Type = "String"
        DefaultValue = Nothing
    End Sub

    Public Overrides Function ToString() As String
        Return "" & Char.ConvertFromUtf32(Access) & " " & Name & " : " & Type & If(DefaultValue = Nothing, "", " = " & DefaultValue)
    End Function

End Class
