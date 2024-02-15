Public Class UMLRelation

    Public Src As UMLClass

    Public Des As UMLClass

    Public Type As UMLRelType

    Public Title As String

    Public Cardinality As UMLCardinality

    Public Sub New()
        Title = Nothing
        Type = UMLRelType.Association
        Cardinality = New UMLCardinality
    End Sub

    Public ReadOnly Property HasCard As Boolean
        Get
            Return Type <> UMLRelType.Generalization And Not (Cardinality.Min = 1 And Cardinality.Max = 0)
        End Get
    End Property
End Class
