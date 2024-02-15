<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UMLOpView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        OpName = New Label()
        SuspendLayout()
        ' 
        ' OpName
        ' 
        OpName.Dock = DockStyle.Fill
        OpName.Location = New Point(5, 5)
        OpName.Name = "OpName"
        OpName.Size = New Size(290, 20)
        OpName.TabIndex = 0
        OpName.Text = "Label1"
        ' 
        ' UMLOpView
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(OpName)
        Margin = New Padding(0)
        Name = "UMLOpView"
        Padding = New Padding(5)
        Size = New Size(300, 30)
        ResumeLayout(False)
    End Sub

    Friend WithEvents OpName As Label

End Class
