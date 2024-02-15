Public Class UMLTransitionView
    Inherits Arrow

    Public WithEvents FromS, ToS As UMLStateView

    Public Controller As UMLTransitionController

    Public DiagramController As UMLStateDiagramController

    Public Model As UMLTransition

    Public Sub New(ad As LineAdapt)
        MyBase.New(ad.P1, ad.P2, ad.D2, ad.M)
    End Sub

    Private Sub AdaptChange() Handles FromS.FullBoundsChange, ToS.FullBoundsChange
        Dim ad = LineAdaptor.Adapt(FromS.FullBounds, ToS.FullBounds, Mode)
        ArrowDir = ad.D2
        FromP = ad.P1
        ToP = ad.P2
        DiagramController.AdaptChange()
    End Sub

    Public Overrides Sub Paint(g As Graphics)
        MyBase.Paint(g)
        If Not String.IsNullOrEmpty(Model.Action) Then
            DrawAction(g, Model.Action)
        End If
    End Sub

    Private Sub DrawAction(g As Graphics, action As String)
        Dim l = action.Length / 2 * CLength
        Dim p As Point
        Select Case Mode
            Case LineMode.OD, LineMode.N, LineMode.UD
                p = P3 + P4
                Exit Select
            Case LineMode.L
                p = P3 + P2
                Exit Select
            Case LineMode.T
                p = P1 + P3
                Exit Select
            Case LineMode.Z
                p = P2 + P4
                Exit Select
            Case Else
                Dim bn = Bounds
                p = bn.Location + bn.Location + bn.Size
        End Select
        p = New Point(p.X / 2, p.Y / 2)
        p.Offset(-l, 0)
        g.DrawString(action, Parent.Font, Pen.Brush, p)
    End Sub

    Public Sub Me_Click() Handles Me.Click
        DiagramController.FocusOn(Controller)
    End Sub

End Class
