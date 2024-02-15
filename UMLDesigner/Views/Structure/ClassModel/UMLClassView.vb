Public Class UMLClassView
    Implements Focusable

    Public Controller As UMLClassController
    Private Model_ As UMLClass

    Public Property Model As UMLClass
        Get
            Return Model_
        End Get
        Set(m As UMLClass)
            Model_ = m
            CName.Text = m.Name
            CName.Font = New Font(CName.Font, If(m.Abstract, FontStyle.Italic, FontStyle.Regular))
            Location = m.Location
        End Set
    End Property

    Public MoveControl As MoveController

    Private Pen As Pen = Pens.Black

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        MoveControl = New MoveController(Mover, Me)
    End Sub

    Public Sub FocusIn() Implements Focusable.FocusIn
        Mover.Visible = True
        Pen = Pens.SkyBlue
        Body.Refresh()
    End Sub

    Public Sub FocusOut() Implements Focusable.FocusOut
        Mover.Visible = False
        Pen = Pens.Black
        Body.Refresh()
    End Sub

    Private Sub Body_SizeChanged(sender As Object, e As EventArgs) Handles Body.SizeChanged
        Height = Body.Height
    End Sub

    Private Sub CName_Click(sender As Object, e As EventArgs) Handles CName.Click
        Controller.View_Click()
    End Sub

    Private Sub Body_Paint(sender As Object, e As PaintEventArgs) Handles Body.Paint
        ControlPaint.DrawBorder(e.Graphics, Body.ClientRectangle, Pen.Color, ButtonBorderStyle.Solid)
        If AttPanel.Height > 0 Then
            Dim y1 = AttPanel.Location.Y - 5
            e.Graphics.DrawLine(Pen, 0, y1, Body.Width, y1)
        End If
        If OpPanel.Height > 0 Then
            Dim y2 = OpPanel.Location.Y - 5
            e.Graphics.DrawLine(Pen, 0, y2, Body.Width, y2)
        End If
    End Sub

    Private Sub UMLClassView_LSChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged, MyBase.SizeChanged
        Controller?.AdaptChange()
        Refresh()
        If Model_ IsNot Nothing Then
            Model_.Location = Location
        End If
    End Sub
End Class
