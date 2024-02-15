Public MustInherit Class Shape
    Implements Focusable
    '
    ' Attributes

    Public Parent As ShapeContainer

    Public Pen As Pen = Pens.Black

    '
    ' Events

    Public Event Click(ByRef p As Point)

    '
    ' Abstract Methods

    Public MustOverride ReadOnly Property Bounds As Rectangle

    Public MustOverride Function Contains(p As Point) As Boolean

    Public MustOverride Sub Paint(g As Graphics)

    '
    ' Methods

    Public Sub OnClick(ByRef p As Point)
        RaiseEvent Click(p)
    End Sub

    Public Sub Invalidate()
        Parent?.InvRegion.Union(Bounds)
    End Sub

    Public Sub FocusIn() Implements Focusable.FocusIn
        Pen = Pens.Blue
        Invalidate()
    End Sub

    Public Sub FocusOut() Implements Focusable.FocusOut
        Pen = Pens.Black
        Invalidate()
    End Sub
End Class
