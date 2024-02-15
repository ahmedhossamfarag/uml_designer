Public Class UMLCardinality

    Public Min As Integer

    Public Max As Integer

    Public Sub New()
        Min = 1
        Max = 0
    End Sub

    Public Overrides Function ToString() As String
        If Min = Max And Min <> 0 Then
            Return Min
        ElseIf Max = 0 Then
            If Min = 0 Then
                Return "*"
            Else
                Return Min & "..*"
            End If
        Else
            Return Min & ".." & Max
        End If
    End Function

End Class
