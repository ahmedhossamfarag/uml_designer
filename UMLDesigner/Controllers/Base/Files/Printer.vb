Public Class Printer

	Public Shared Sub Print(p As Control, title As String)
		Dim name = FilesController.FileSave(title, "bmp")
		If name Is Nothing Then
			Return
		End If
		Dim m = New Bitmap(p.Width, p.Height)
		Dim g = Graphics.FromImage(m)
		g.Clear(Color.White)
		p.DrawToBitmap(m, New Rectangle(New Point(), p.Size))
		For i = p.Controls.Count - 1 To 0 Step -1
			Dim c = p.Controls(i)
			Dim b = New Bitmap(c.Width, c.Height)
			c.DrawToBitmap(b, New Rectangle(New Point(), c.Size))
			g.DrawImage(b, New Rectangle(c.Location, c.Size))
		Next
		m.Save(name)
	End Sub

End Class
