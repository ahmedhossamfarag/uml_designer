<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UMLParamView
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
        Delete = New Button()
        NameBox = New TextBox()
        TypeBox = New TextBox()
        DefaultBox = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' Delete
        ' 
        Delete.FlatAppearance.BorderSize = 0
        Delete.FlatStyle = FlatStyle.Flat
        Delete.Location = New Point(0, 0)
        Delete.Name = "Delete"
        Delete.Size = New Size(30, 30)
        Delete.TabIndex = 0
        Delete.Text = "X"
        Delete.UseVisualStyleBackColor = True
        ' 
        ' NameBox
        ' 
        NameBox.Location = New Point(36, 3)
        NameBox.Name = "NameBox"
        NameBox.Size = New Size(200, 27)
        NameBox.TabIndex = 1
        ' 
        ' TypeBox
        ' 
        TypeBox.Location = New Point(308, 3)
        TypeBox.Name = "TypeBox"
        TypeBox.Size = New Size(200, 27)
        TypeBox.TabIndex = 2
        ' 
        ' DefaultBox
        ' 
        DefaultBox.Location = New Point(577, 3)
        DefaultBox.Name = "DefaultBox"
        DefaultBox.Size = New Size(200, 27)
        DefaultBox.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(275, 5)
        Label1.Name = "Label1"
        Label1.Size = New Size(12, 20)
        Label1.TabIndex = 4
        Label1.Text = ":"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(539, 5)
        Label2.Name = "Label2"
        Label2.Size = New Size(19, 20)
        Label2.TabIndex = 5
        Label2.Text = "="
        ' 
        ' UMLParamView
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(DefaultBox)
        Controls.Add(TypeBox)
        Controls.Add(NameBox)
        Controls.Add(Delete)
        Name = "UMLParamView"
        Size = New Size(780, 30)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Delete As Button
    Friend WithEvents NameBox As TextBox
    Friend WithEvents TypeBox As TextBox
    Friend WithEvents DefaultBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label

End Class
