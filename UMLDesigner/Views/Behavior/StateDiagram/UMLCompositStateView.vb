Public Class UMLCompositStateView
    Implements Focusable

    Public Shared Tol As Integer = 20

    Public Controller As UMLCompositStateController
    Private Model_ As UMLCompositState
    Public Rec As RecShape

    Public SubStates As List(Of UMLStateView)


    Public WriteOnly Property Model As UMLCompositState
        Set(value As UMLCompositState)
            BaseModel = value
            Model_ = value
            SName.Text = value.Name
            Rec.Location = value.Location
            Rec.Size = value.Size
        End Set
    End Property

    Public Overrides ReadOnly Property FullBounds As Rectangle
        Get
            Return New Rectangle(Location, Rec.Size)
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Rec = New RecShape
        Pen = Pens.Black
        MoveControl = New MoveController(SName, Me)
        SubStates = New List(Of UMLStateView)
    End Sub


    Public Overrides Sub FocusIn() Implements Focusable.FocusIn
        Pen = Pens.Blue
        Rec.FocusIn()
        Refresh()
        DiagramController.AdaptChange()
    End Sub

    Public Overrides Sub FocusOut() Implements Focusable.FocusOut
        Pen = Pens.Black
        Rec.FocusOut()
        Refresh()
        DiagramController.AdaptChange()
    End Sub

    Private Sub SName_Click(sender As Object, e As EventArgs) Handles SName.Click
        DiagramController.FocusOn(Controller)
        DiagramController.StateClick(BaseModel)
    End Sub

    Private Sub UMLCompositStateView_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        Rec.Location = Location
        DiagramController.AdaptChange()
    End Sub

    Private Sub MoveControl_MoveEnd(p As Point) Handles MoveControl.MoveEnd
        For Each s In SubStates
            s.Location += p
            Dim cs = TryCast(s, UMLCompositStateView)
            If cs IsNot Nothing Then
                cs.MoveControl_MoveEnd(p)
            End If
        Next
        DiagramController.AdaptChange()
    End Sub

    Private Sub UMLCompositStateView_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ControlPaint.DrawBorder(e.Graphics, New Rectangle(0, 0, Width, Height), Pen.Color, ButtonBorderStyle.Solid)
    End Sub

    Friend Sub Include(r As Rectangle)
        Dim p = r.Location - Location + r.Size
        Dim s = Rec.Size
        Rec.Size = New Size(Math.Max(s.Width, p.X + Tol), Math.Max(s.Height, p.Y + Tol))
        DiagramController.AdaptChange()
        Model_.Size = Rec.Size
        RaiseFullBoundsChanged()
    End Sub

End Class
