Imports System.IO

Public Class CMReader

    Public Shared Function Read() As UMLClassModel
        Dim name = FilesController.FileRead("UML Class Model", "ucm")
        If name Is Nothing Then
            Return Nothing
        End If
        Dim reader = New StreamReader(name)
        Try
            Return ReadCM(reader, name)
        Catch ex As Exception
            FilesController.RaiseFileWrongFormat()
            Return Nothing
        End Try
    End Function

    Private Shared Function ReadCM(reader As StreamReader, name As String) As UMLClassModel
        Dim m = New UMLClassModel With {.Name = name}
        Dim n = Integer.Parse(reader.ReadLine)
        For i = 1 To n
            m.Classes.Add(ReadClass(reader))
        Next
        n = Integer.Parse(reader.ReadLine)
        For i = 1 To n
            m.Relations.Add(ReadRel(reader, m))
        Next
        reader.Close()
        Return m
    End Function

    Private Shared Function ReadClass(reader As StreamReader) As UMLClass
        Dim c = New UMLClass With {
        .Name = reader.ReadLine,
        .Abstract = Boolean.Parse(reader.ReadLine),
        .Location = New Point(Integer.Parse(reader.ReadLine),
                              Integer.Parse(reader.ReadLine))
        }
        Dim n = Integer.Parse(reader.ReadLine)
        For i = 1 To n
            c.Attributes.Add(ReadAtt(reader))
        Next
        n = Integer.Parse(reader.ReadLine)
        For i = 1 To n
            c.Operations.Add(ReadOp(reader))
        Next
        Return c
    End Function

    Private Shared Function ReadAtt(reader As StreamReader) As UMLAttribute
        Return New UMLAttribute With {
        .Access = Integer.Parse(reader.ReadLine),
        .Name = reader.ReadLine,
        .Type = reader.ReadLine,
        .DefaultValue = reader.ReadLine
        }
    End Function

    Private Shared Function ReadOp(reader As StreamReader) As UMLOperation
        Dim o = New UMLOperation With {
        .Access = Integer.Parse(reader.ReadLine),
        .Name = reader.ReadLine,
        .ReturnType = reader.ReadLine
        }
        Dim n = Integer.Parse(reader.ReadLine)
        For i = 1 To n
            o.Parameters.Add(ReadParam(reader))
        Next
        Return o
    End Function

    Private Shared Function ReadParam(reader As StreamReader) As UMLParameter
        Return New UMLParameter With {
        .Name = reader.ReadLine,
        .Type = reader.ReadLine,
        .DefaultValue = reader.ReadLine
        }
    End Function

    Private Shared Function ReadRel(reader As StreamReader, m As UMLClassModel) As UMLRelation
        Dim src = reader.ReadLine, des = reader.ReadLine
        Return New UMLRelation With {
        .Src = m.Classes.Find(Function(c) c.Name = src),
        .Des = m.Classes.Find(Function(c) c.Name = des),
        .Type = Integer.Parse(reader.ReadLine),
        .Title = reader.ReadLine,
        .Cardinality = New UMLCardinality With {
            .Min = Integer.Parse(reader.ReadLine),
            .Max = Integer.Parse(reader.ReadLine)
        }
        }
    End Function
End Class
