Public MustInherit Class PProperty(Of T)
    Implements HasView

    Public Name As String

    Private Value_ As T

    Public Event Change(val As T)
    Public Event Validate(val As T)

    Public Property Value As T
        Get
            Return Value_
        End Get
        Set(value As T)
            RaiseEvent Validate(value)
            Dim val = Value_
            Value_ = value
            If Not Value_.Equals(val) Then
                RaiseEvent Change(value)
            End If
        End Set
    End Property

    Protected View As PPropertyView

    Public Sub New(name As String, val As T)
        Me.Name = name
        Value_ = val
    End Sub

    Public Function CreateView() As Control Implements HasView.CreateView
        Return View
    End Function

End Class
