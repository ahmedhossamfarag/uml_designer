Public Class History

    Public Shared TLines As Dictionary(Of Integer, TimeLine) = New Dictionary(Of Integer, TimeLine)

    Private Shared CLine As TimeLine

    Public Shared Sub AddTimeLine(id As Integer)
        CLine = New TimeLine
        TLines.Add(id, CLine)
    End Sub

    Public Shared Sub SetTimeLine(id As Integer)
        If TLines.ContainsKey(id) Then
            CLine = TLines(id)
        Else
            AddTimeLine(id)
        End If
    End Sub

    Public Shared Sub Free()
    End Sub

    Public Shared Sub AddRecord(ac1 As Action(Of Object), obj1 As Object, ac2 As Action(Of Object), obj2 As Object)
        Dim ts = New TimeStep With {
        .DoA = New TimeAction With {.Action = ac1, .Param = obj1},
        .UndoA = New TimeAction With {.Action = ac2, .Param = obj2}
        }
        CLine?.AddStep(ts)
    End Sub

    Public Shared Sub AddRecord(ac As Action(Of Object), obj1 As Object, obj2 As Object)
        AddRecord(ac, obj1, ac, obj2)
    End Sub

    Public Shared Sub Forward()
        CLine?.Forward()
    End Sub

    Public Shared Sub Backward()
        CLine?.Backward()
    End Sub

    Friend Shared Sub RemoveTimeLIne(id As Integer)
        If TLines(id).Equals(CLine) Then
            CLine = Nothing
        End If
        TLines.Remove(id)
    End Sub
End Class
