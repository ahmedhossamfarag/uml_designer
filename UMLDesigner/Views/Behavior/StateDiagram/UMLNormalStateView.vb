Public Class UMLNormalStateView
    Implements Focusable

    Public Controller As UMLNormalStateController

    Public WriteOnly Property Model As UMLNormalState
        Set(m As UMLNormalState)
            BaseModel = m
            SName.Text = m.Name
            AdaptLabel(ELabel, m.EntryClause, "Entry")
            AdaptLabel(DLabel, m.DoClause, "Do")
            AdaptLabel(XLabel, m.ExitClaue, "Exit")
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MoveControl = New MoveController(SName, Me)
    End Sub

    Private Sub AdaptLabel(label As Label, txt As String, pre As String)
        If Not String.IsNullOrEmpty(txt) Then
            label.AutoSize = True
            label.Text = pre & ": " & txt
        Else
            label.AutoSize = False
            label.Text = Nothing
            label.Height = 0
        End If
    End Sub

    Private Sub Body_SizeChanged(sender As Object, e As EventArgs) Handles Body.SizeChanged
        Dim pad As Integer
        If Body.Height = 0 Then
            pad = Padding.Top * 2
        Else
            pad = Padding.Top * 3
        End If
        Height = SName.Height + Body.Height + pad
        Refresh()
    End Sub

    Private Sub UMLNormalStateView_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ControlPaint.DrawBorder(e.Graphics, New Rectangle(0, 0, Width, Height), Pen.Color, ButtonBorderStyle.Solid)
        If Body.Height > 0 Then
            Dim y = SName.Location.Y + SName.Height + Padding.Top / 2
            e.Graphics.DrawLine(Pen, New Point(0, y), New Point(Width, y))
        End If
    End Sub

    Private Sub SName_Click(sender As Object, e As EventArgs) Handles SName.Click
        DiagramController.FocusOn(Controller)
        DiagramController.StateClick(BaseModel)
    End Sub
End Class
