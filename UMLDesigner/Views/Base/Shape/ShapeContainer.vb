Public Class ShapeContainer
    Inherits UserControl

    Public Shapes As List(Of Shape)

    Public InvRegion As Region

    Public Event MClick As MouseEventHandler

    Public Sub New()
        Shapes = New List(Of Shape)
        InvRegion = New Region(New RectangleF)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        For Each s In Shapes
            e.Graphics.SetClip(s.Bounds)
            s.Paint(e.Graphics)
        Next
    End Sub

    Private Sub ShapeContainer_MClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        For Each s In Shapes
            If s.Contains(e.Location) Then
                s.OnClick(e.Location)
                Return
            End If
        Next
        RaiseEvent MClick(sender, e)
    End Sub

    Public Sub RePaint()
        'Refresh()
        Invalidate(InvRegion)
        InvRegion = New Region(New RectangleF)
    End Sub

End Class
