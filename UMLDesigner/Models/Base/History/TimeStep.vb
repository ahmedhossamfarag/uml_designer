Public Class TimeStep

    Public DoA, UndoA As TimeAction

    Public Sub Forward()
        DoA?.Invoke()
    End Sub

    Public Sub Backward()
        UndoA?.Invoke()
    End Sub

End Class
