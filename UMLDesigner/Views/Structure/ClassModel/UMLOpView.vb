Public Class UMLOpView
    Implements Focusable

    Public Controller As UMLOpController
    Public WriteOnly Property Model As UMLOperation
        Set(m As UMLOperation)
            OpName.Text = m.ToString()
        End Set
    End Property

    Public Sub FocusIn() Implements Focusable.FocusIn
        Me.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Public Sub FocusOut() Implements Focusable.FocusOut
        Me.BorderStyle = BorderStyle.None
    End Sub

    Private Sub OpName_Click(sender As Object, e As EventArgs) Handles OpName.Click
        Controller.View_Click()
    End Sub
End Class
