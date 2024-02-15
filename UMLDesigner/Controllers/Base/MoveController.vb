Public Class MoveController
    Public Shared Tol As Integer = 50

    Public Event MoveEnd(p As Point)

    Public WithEvents Mover As Control
    Public Target As Control

    Private P? As Point
    Private Start As Point

    Public Sub New(mover As Control, targer As Control)
        Me.Mover = mover
        Me.Target = targer
        P = Nothing
    End Sub

    Private Sub Mover_MouseDown(sender As Object, e As MouseEventArgs) Handles Mover.MouseDown
        P = e.Location
        Start = Target.Location
        Mover.Cursor = Cursors.SizeAll
    End Sub

    Private Sub Mover_MouseMove(sender As Object, e As MouseEventArgs) Handles Mover.MouseMove
        If P IsNot Nothing Then
            Dim nl As Point = Target.Location + e.Location - P
            Dim ds = Target.Size - Target.Parent.Size
            Dim o = New Point(Math.Min(0, -ds.Width), Math.Min(0, -ds.Height))
            Target.Location = New Point(Math.Max(o.X, Math.Min(nl.X, Target.Parent.Width - Tol)),
                                        Math.Max(o.Y, Math.Min(nl.Y, Target.Parent.Height - Tol)))
        End If
    End Sub

    Private Sub Mover_MouseUp(sender As Object, e As MouseEventArgs) Handles Mover.MouseUp
        P = Nothing
        Mover.Cursor = Cursors.Default
        RaiseEvent MoveEnd(Target.Location - Start)
        History.AddRecord(AddressOf Move, Target.Location, Start)
    End Sub

    Public Sub Move(p As Point)
        Dim l = Target.Location
        Target.Location = p
        RaiseEvent MoveEnd(p - l)
    End Sub
End Class
