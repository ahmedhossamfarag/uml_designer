Public Class TimeLine
    Private Dos, Undos As List(Of TimeStep)

    Public Sub New()
        Dos = New List(Of TimeStep)
        Undos = New List(Of TimeStep)
    End Sub

    Public Sub AddStep(stp As TimeStep)
        Undos.Add(stp)
    End Sub

    Public Sub Forward()
        If Dos.Any() Then
            Dim a = Dos.Last()
            Dos.Remove(a)
            a.Forward()
            Undos.Add(a)
        End If
    End Sub


    Public Sub Backward()
        If Undos.Any() Then
            Dim a = Undos.Last()
            Undos.Remove(a)
            a.Backward()
            Dos.Add(a)
        End If
    End Sub



End Class
