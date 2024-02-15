Imports System.Diagnostics.Eventing
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Public Class FilesController


	Public Shared Function FileRead(title As String, ext As String) As String
		Dim Dialog = New OpenFileDialog With {.Filter = $"{title} |*.{ext}"}
		If Dialog.ShowDialog() = DialogResult.OK Then
			Return If(String.IsNullOrEmpty(Dialog.FileName), Nothing, Dialog.FileName)
		End If
		Return Nothing
	End Function

	Public Shared Function FileSave(title As String, ext As String) As String
		Dim Dialog = New SaveFileDialog With
				{
					.FileName = title & "." & ext,
					.DefaultExt = ext,
					.AddExtension = True
				}
		If Dialog.ShowDialog() = DialogResult.OK Then
			Return If(String.IsNullOrEmpty(Dialog.FileName), Nothing, Dialog.FileName)
		End If
		Return Nothing
	End Function

	Public Shared Sub RaiseFileWrongFormat()
		MessageBox.Show("File Format Is Wrong")
	End Sub

End Class
