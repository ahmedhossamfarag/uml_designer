Public Class RecShape
    Inherits Shape

    Private Shared Tol As Integer = 5
    Private Loc As Point
    Private Sz As Size

    Public Property Location As Point
        Get
            Return Loc
        End Get
        Set(value As Point)
            If Loc <> value Then
                Invalidate()
                Loc = value
                Invalidate()
            End If
        End Set
    End Property

    Public Property Size As Size
        Get
            Return Sz
        End Get
        Set(value As Size)
            If Sz <> value Then
                Invalidate()
                Sz = value
                Invalidate()
            End If
        End Set
    End Property

    Public Sub New()
        Loc = New Point
        Size = New Size
    End Sub

    Public Overrides ReadOnly Property Bounds As Rectangle
        Get
            Return New Rectangle(Loc - New Point(Tol, Tol), Sz + New Size(2 * Tol, 2 * Tol))
        End Get
    End Property

    Public Overrides Sub Paint(g As Graphics)
        g.DrawRectangle(Pen, New Rectangle(Loc, Sz))
    End Sub

    Public Overrides Function Contains(p As Point) As Boolean
        Return Bounds.Contains(p)
    End Function
End Class
