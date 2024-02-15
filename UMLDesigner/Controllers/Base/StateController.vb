Public Class StateController(Of T)

    Public States As Dictionary(Of T, State)
    Public Current? As State

    Public Sub New()
        States = New Dictionary(Of T, State)
        Current = Nothing
    End Sub

    Public Sub AddState(k As T, st As State)
        States.Add(k, st)
    End Sub

    Public Sub SetState(k As T)
        Current?.StateOut?.Invoke()
        Current = States(k)
        Current?.StateIn?.Invoke()
    End Sub

End Class
