Public Class UMLAttrView
    Implements Focusable

    Public Controller As UMLAttrController
    Public WriteOnly Property Model As UMLAttribute
        Set(m As UMLAttribute)
            AName.Text = m.ToString()
        End Set
    End Property

    Public Sub FocusIn() Implements Focusable.FocusIn
        Me.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Public Sub FocusOut() Implements Focusable.FocusOut
        Me.BorderStyle = BorderStyle.None
    End Sub

    Private Sub AName_Click(sender As Object, e As EventArgs) Handles AName.Click
        Controller.View_Click()
    End Sub
End Class
