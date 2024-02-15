Public Class CompositControl
    Inherits UserControl

    Public Event FullBoundsChange()

    Public Overridable ReadOnly Property FullBounds As Rectangle
        Get
            Return Bounds
        End Get
    End Property

    Private Sub Control_BoundsChanged() Handles Me.LocationChanged, Me.SizeChanged
        RaiseEvent FullBoundsChange()
    End Sub

    Public Sub RaiseFullBoundsChanged()
        RaiseEvent FullBoundsChange()
    End Sub

End Class
