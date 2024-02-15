Imports System.IO

Public Class SDWriter

    Public Shared Sub Write(m As UMLStateDiagram)
        If m.Name Is Nothing Then
            m.Name = FilesController.FileSave("UML State Diagram", "usd")
            If m.Name Is Nothing Then
                Return
            End If
        End If
        Dim writer = New StreamWriter(m.Name)
        WriteSD(m, writer)
        writer.Close()
    End Sub

    Private Shared Sub WriteSD(m As UMLStateDiagram, writer As StreamWriter)
        writer.WriteLine(m.States.Count)
        For Each s In m.States
            WriteState(s, writer)
        Next
        writer.WriteLine(m.Transitions.Count)
        For Each t In m.Transitions
            WriteTrans(t, writer)
        Next
    End Sub

    Private Shared Sub WriteState(s As UMLState, writer As StreamWriter)
        writer.WriteLine(s.GetHashCode)
        writer.WriteLine(s.Type)
        writer.WriteLine(s.Location.X)
        writer.WriteLine(s.Location.Y)
        If s.Type = UMLStateType.Normal Then
            WriteNS(CType(s, UMLNormalState), writer)
        ElseIf s.Type = UMLStateType.Composit Then
            WriteCS(CType(s, UMLCompositState), writer)
        End If
    End Sub

    Private Shared Sub WriteNS(s As UMLNormalState, writer As StreamWriter)
        writer.WriteLine(s.Name)
        writer.WriteLine(s.EntryClause)
        writer.WriteLine(s.DoClause)
        writer.WriteLine(s.ExitClaue)
    End Sub

    Private Shared Sub WriteCS(s As UMLCompositState, writer As StreamWriter)
        writer.WriteLine(s.Name)
        writer.WriteLine(s.Size.Width)
        writer.WriteLine(s.Size.Height)
        writer.WriteLine(s.SubStates.Count)
        For Each ss In s.SubStates
            writer.WriteLine(ss.GetHashCode)
        Next
    End Sub

    Private Shared Sub WriteTrans(t As UMLTransition, writer As StreamWriter)
        writer.WriteLine(t.FromS.GetHashCode)
        writer.WriteLine(t.ToS.GetHashCode)
        writer.WriteLine(t.Mode)
        writer.WriteLine(t.Action)
    End Sub
End Class
