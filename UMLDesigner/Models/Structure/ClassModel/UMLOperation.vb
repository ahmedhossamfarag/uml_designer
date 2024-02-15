Public Class UMLOperation

    Public Access As UMLAccess

    Public Name As String

    Public ReturnType As String

    Public Parameters As List(Of UMLParameter)

    Public Sub New()
        Access = UMLAccess.PUBLIC_
        Name = "OpName"
        ReturnType = "String"
        Parameters = New List(Of UMLParameter)
    End Sub

    Public Overrides Function ToString() As String
        Return "" & Char.ConvertFromUtf32(Access) & " " & Name & "(" &
            Join(Parameters.ConvertAll(Function(p) p.ToString()).ToArray(), ", ") & ")" &
            " : " & ReturnType
    End Function

End Class
