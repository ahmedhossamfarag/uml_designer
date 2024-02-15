Public Class EnumProperty(Of T)
    Inherits PProperty(Of T)

    Public Sub New(name As String, val As T)
        MyBase.New(name, val)
        View = New EnumPropertyView(Of T)(Me)
    End Sub

End Class
