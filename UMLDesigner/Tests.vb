Public Class Tests

    Public Shared Sub CreateCMTest(ByRef form As Program)
        Dim cm = New UMLClassModel
        Dim c1 = New UMLClass With {.Name = "Person", .Location = New Point(300, 100)}
        c1.Attributes.Add(New UMLAttribute With {.Name = "Name"})
        c1.Operations.Add(New UMLOperation With {.Name = "Ride"})
        cm.Classes.Add(c1)
        Dim c2 = New UMLClass With {.Name = "Car", .Location = New Point(800, 300)}
        c2.Attributes.Add(New UMLAttribute With {.Name = "Type"})
        c2.Operations.Add(New UMLOperation With {.Name = "Run"})
        cm.Classes.Add(c2)
        Dim r1 = New UMLRelation With {
            .Src = c1, .Des = c2, .Title = "Drives",
            .Cardinality = New UMLCardinality With {.Min = 0, .Max = 5}
        }
        cm.Relations.Add(r1)
        Dim r2 = New UMLRelation With {
            .Src = c1, .Des = c1, .Title = "Friend",
            .Cardinality = New UMLCardinality With {.Min = 0, .Max = 0}
        }
        cm.Relations.Add(r2)
        Dim cnt = New UMLClassModelController(cm)
        cnt.CreateView()
        form.AddScene(cnt)
    End Sub

    Public Shared Sub CreateSDTest(ByRef form As Program)
        Dim sd = New UMLStateDiagram
        Dim s1 = New UMLNormalState With {
        .Location = New Point(200, 200),
        .Name = "StateName"
        }
        sd.States.Add(s1)
        Dim s2 = New UMLState(UMLStateType.Initial) With {.Location = New Point(100, 200)}
        sd.States.Add(s2)
        Dim s3 = New UMLState(UMLStateType.Final) With {.Location = New Point(500, 200)}
        sd.States.Add(s3)
        Dim s4 = New UMLState(UMLStateType.Initial) With {.Location = New Point(300, 400)}
        sd.States.Add(s4)
        Dim s5 = New UMLCompositState With {.Location = New Point(200, 300)}
        s5.SubStates.Add(s4)
        sd.States.Add(s5)
        Dim t1 = New UMLTransition With {.FromS = s2, .ToS = s1, .Mode = LineMode.Z, .Action = "Hello"}
        sd.Transitions.Add(t1)
        Dim t2 = New UMLTransition With {.FromS = s2, .ToS = s5, .Mode = LineMode.L, .Action = "Hello"}
        sd.Transitions.Add(t2)
        Dim cnt = New UMLStateDiagramController(sd)
        cnt.CreateView()
        form.AddScene(cnt)
    End Sub

End Class
