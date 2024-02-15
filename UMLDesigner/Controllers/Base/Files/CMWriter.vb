Imports System.IO

Public Class CMWriter

    Public Shared Sub Write(m As UMLClassModel)
        If m.Name Is Nothing Then
            m.Name = FilesController.FileSave("UML Class Model", "ucm")
            If m.Name Is Nothing Then
                Return
            End If
        End If
        Dim writer = New StreamWriter(m.Name)
        WriteCM(m, writer)
        writer.Close()
    End Sub

    Private Shared Sub WriteCM(m As UMLClassModel, writer As StreamWriter)
        writer.WriteLine(m.Classes.Count)
        For Each c In m.Classes
            WriteClass(c, writer)
        Next
        writer.WriteLine(m.Relations.Count)
        For Each r In m.Relations
            WriteRel(r, writer)
        Next
    End Sub

    Private Shared Sub WriteClass(c As UMLClass, writer As StreamWriter)
        writer.WriteLine(c.Name)
        writer.WriteLine(c.Abstract)
        writer.WriteLine(c.Location.X)
        writer.WriteLine(c.Location.Y)
        writer.WriteLine(c.Attributes.Count)
        For Each a In c.Attributes
            WriteAtt(a, writer)
        Next
        writer.WriteLine(c.Operations.Count)
        For Each o In c.Operations
            WriteOp(o, writer)
        Next
    End Sub

    Private Shared Sub WriteAtt(a As UMLAttribute, writer As StreamWriter)
        writer.WriteLine(a.Access)
        writer.WriteLine(a.Name)
        writer.WriteLine(a.Type)
        writer.WriteLine(a.DefaultValue)
    End Sub

    Private Shared Sub WriteOp(o As UMLOperation, writer As StreamWriter)
        writer.WriteLine(o.Access)
        writer.WriteLine(o.Name)
        writer.WriteLine(o.ReturnType)
        writer.WriteLine(o.Parameters.Count)
        For Each p In o.Parameters
            WriteParam(p, writer)
        Next
    End Sub

    Private Shared Sub WriteParam(p As UMLParameter, writer As StreamWriter)
        writer.WriteLine(p.Name)
        writer.WriteLine(p.Type)
        writer.WriteLine(p.DefaultValue)
    End Sub

    Private Shared Sub WriteRel(r As UMLRelation, writer As StreamWriter)
        writer.WriteLine(r.Src)
        writer.WriteLine(r.Des)
        writer.WriteLine(r.Type)
        writer.WriteLine(r.Title)
        writer.WriteLine(r.Cardinality.Min)
        writer.WriteLine(r.Cardinality.Max)
    End Sub
End Class
