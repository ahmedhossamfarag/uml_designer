Imports System.IO

Public Class SDReader

    Public Shared Function Read() As UMLStateDiagram
        Dim name = FilesController.FileRead("UML State Diagram", "usd")
        If name Is Nothing Then
            Return Nothing
        End If
        Dim reader = New StreamReader(name)
        Try
            Return ReadSD(reader, name)
        Catch ex As Exception
            FilesController.RaiseFileWrongFormat()
            Return Nothing
        End Try
    End Function

    Private Shared Function ReadSD(reader As StreamReader, name As String) As UMLStateDiagram
        Dim m = New UMLStateDiagram With {.Name = name}
        Dim cs = New Dictionary(Of UMLCompositState, List(Of Integer))
        Dim n = Integer.Parse(reader.ReadLine)
        For i = 1 To n
            m.States.Add(ReadState(reader, cs))
        Next
        FillCS(cs, m)
        n = Integer.Parse(reader.ReadLine)
        For i = 1 To n
            m.Transitions.Add(ReadTrans(reader, m))
        Next
        reader.Close()
        Return m
    End Function

    Private Shared Function ReadState(reader As StreamReader, cs As Dictionary(Of UMLCompositState, List(Of Integer))) As UMLState
        Dim s = New UMLState With {
        .Id = Integer.Parse(reader.ReadLine),
        .Type = Integer.Parse(reader.ReadLine),
        .Location = New Point(Integer.Parse(reader.ReadLine),
                               Integer.Parse(reader.ReadLine))
        }
        If s.Type = UMLStateType.Normal Then
            Return ReadNS(reader, s)
        ElseIf s.Type = UMLStateType.Composit Then
            Return ReadCS(reader, s, cs)
        End If
        Return s
    End Function

    Private Shared Function ReadNS(reader As StreamReader, s As UMLState) As UMLState
        Return New UMLNormalState With {
        .Id = s.Id,
        .Location = s.Location,
        .Name = reader.ReadLine,
        .EntryClause = reader.ReadLine,
        .DoClause = reader.ReadLine,
        .ExitClaue = reader.ReadLine
        }
    End Function

    Private Shared Function ReadCS(reader As StreamReader, s As UMLState, cs As Dictionary(Of UMLCompositState, List(Of Integer))) As UMLState
        Dim c = New UMLCompositState With {
        .Id = s.Id,
        .Location = s.Location,
        .Name = reader.ReadLine,
        .Size = New Size(Integer.Parse(reader.ReadLine),
                               Integer.Parse(reader.ReadLine))
        }
        Dim l = New List(Of Integer)
        Dim n = Integer.Parse(reader.ReadLine)
        For i = 1 To n
            l.Add(Integer.Parse(reader.ReadLine))
        Next
        cs.Add(c, l)
        Return c
    End Function

    Private Shared Sub FillCS(cs As Dictionary(Of UMLCompositState, List(Of Integer)), m As UMLStateDiagram)
        For Each kv In cs
            For Each id In kv.Value
                kv.Key.SubStates.Add(m.States.Find(Function(s) s.Id = id))
            Next
        Next
    End Sub

    Private Shared Function ReadTrans(reader As StreamReader, m As UMLStateDiagram) As UMLTransition
        Dim fs = Integer.Parse(reader.ReadLine), ts = Integer.Parse(reader.ReadLine)
        Return New UMLTransition With {
        .FromS = m.States.Find(Function(s) s.Id = fs),
        .ToS = m.States.Find(Function(s) s.Id = ts),
        .Mode = Integer.Parse(reader.ReadLine),
        .Action = reader.ReadLine
        }
    End Function
End Class
