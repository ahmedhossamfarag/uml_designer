Public Class LineAdaptor

    Public Shared Function Adapt(ByRef r1 As Rectangle, ByRef r2 As Rectangle) As LineAdapt
        Dim ad = New LineAdapt
        Dim y1 = r1.Y - r2.Height
        Dim y2 = r1.Y + r1.Height
        Dim x1 = r1.X + r2.Width
        If r1.Location = r2.Location Then
            ad.D1 = Direction.Right
            ad.D2 = Direction.Right
            ad.P1 = New Point(r1.X + r1.Width, r1.Y + r1.Height / 2)
            ad.P2 = New Point(r1.X + r1.Width, r1.Y + r1.Height / 4)
            ad.M = LineMode.CL
            Return ad
        ElseIf r2.Y < y1 Then
            ad.D1 = Direction.Up
            ad.D2 = Direction.Down
            ad.M = LineMode.N
        ElseIf r2.Y > y2 Then
            ad.D1 = Direction.Down
            ad.D2 = Direction.Up
            ad.M = LineMode.N
        ElseIf r2.X > x1 Then
            ad.D1 = Direction.Right
            ad.D2 = Direction.Left
            ad.M = LineMode.Z
        Else
            ad.D1 = Direction.Left
            ad.D2 = Direction.Right
            ad.M = LineMode.Z
        End If
        ad.P1 = MapDir(r1, ad.D1)
        ad.P2 = MapDir(r2, ad.D2)
        Return ad
    End Function

    Public Shared Function Adapt(ByRef r1 As Rectangle, ByRef r2 As Rectangle, mode As LineMode) As LineAdapt
        Dim ad = New LineAdapt With {.M = mode}
        Select Case mode
            Case LineMode.L
                ad.D2 = If(r2.X > r1.X, Direction.Left, Direction.Right)
                ad.D1 = If(r2.Y > r1.Y, Direction.Down, Direction.Up)
                Exit Select
            Case LineMode.T
                ad.D2 = If(r2.Y > r1.Y, Direction.Up, Direction.Down)
                ad.D1 = If(r2.X > r1.X, Direction.Right, Direction.Left)
                Exit Select
            Case LineMode.N
                ad.D2 = If(r2.Y > r1.Y, Direction.Up, Direction.Down)
                ad.D1 = If(r2.Y > r1.Y, Direction.Down, Direction.Up)
                Exit Select
            Case LineMode.Z
                ad.D2 = If(r2.X > r1.X, Direction.Left, Direction.Right)
                ad.D1 = If(r2.X > r1.X, Direction.Right, Direction.Left)
                Exit Select
            Case LineMode.UD
                ad.D1 = Direction.Up
                ad.D2 = Direction.Up
            Case LineMode.OD
                ad.D1 = Direction.Up
                ad.D2 = Direction.Left
        End Select
        ad.P1 = MapDir(r1, ad.D1)
        ad.P2 = MapDir(r2, ad.D2)
        Return ad
    End Function

    Public Shared Function MapDir(r As Rectangle, dir As Direction)
        Select Case dir
            Case Direction.Up
                Return New Point(r.X + r.Width / 2, r.Y)
            Case Direction.Down
                Return New Point(r.X + r.Width / 2, r.Y + r.Height)
            Case Direction.Right
                Return New Point(r.X + r.Width, r.Y + r.Height / 2)
            Case Else
                Return New Point(r.X, r.Y + r.Height / 2)
        End Select
    End Function

End Class
