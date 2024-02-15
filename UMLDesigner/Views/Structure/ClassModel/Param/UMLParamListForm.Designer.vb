<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UMLParamListForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        OkButton = New Button()
        CancelButton = New Button()
        Header = New Panel()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Body = New FlowLayoutPanel()
        Content = New FlowLayoutPanel()
        AddButton = New Button()
        Header.SuspendLayout()
        Body.SuspendLayout()
        SuspendLayout()
        ' 
        ' OkButton
        ' 
        OkButton.Location = New Point(674, 402)
        OkButton.Name = "OkButton"
        OkButton.Size = New Size(94, 29)
        OkButton.TabIndex = 0
        OkButton.Text = "OK"
        OkButton.UseVisualStyleBackColor = True
        ' 
        ' CancelButton
        ' 
        CancelButton.Location = New Point(574, 402)
        CancelButton.Name = "CancelButton"
        CancelButton.Size = New Size(94, 29)
        CancelButton.TabIndex = 1
        CancelButton.Text = "Cancel"
        CancelButton.UseVisualStyleBackColor = True
        ' 
        ' Header
        ' 
        Header.Controls.Add(Label3)
        Header.Controls.Add(Label2)
        Header.Controls.Add(Label1)
        Header.Dock = DockStyle.Top
        Header.Location = New Point(0, 0)
        Header.Name = "Header"
        Header.Size = New Size(800, 30)
        Header.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(595, 3)
        Label3.Name = "Label3"
        Label3.Size = New Size(98, 20)
        Label3.TabIndex = 2
        Label3.Text = "Default Value"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(370, 3)
        Label2.Name = "Label2"
        Label2.Size = New Size(40, 20)
        Label2.TabIndex = 1
        Label2.Text = "Type"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(120, 3)
        Label1.Name = "Label1"
        Label1.Size = New Size(49, 20)
        Label1.TabIndex = 0
        Label1.Text = "Name"
        ' 
        ' Body
        ' 
        Body.AutoScroll = True
        Body.Controls.Add(Content)
        Body.Controls.Add(AddButton)
        Body.Location = New Point(0, 36)
        Body.Name = "Body"
        Body.Size = New Size(800, 360)
        Body.TabIndex = 3
        ' 
        ' Content
        ' 
        Content.AutoSize = True
        Content.Location = New Point(3, 3)
        Content.Name = "Content"
        Content.Size = New Size(0, 0)
        Content.TabIndex = 0
        ' 
        ' AddButton
        ' 
        AddButton.AutoSize = True
        AddButton.FlatAppearance.BorderSize = 0
        AddButton.FlatStyle = FlatStyle.Flat
        AddButton.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        AddButton.Location = New Point(9, 3)
        AddButton.Name = "AddButton"
        AddButton.Size = New Size(61, 30)
        AddButton.TabIndex = 1
        AddButton.Text = "+ Add"
        AddButton.UseVisualStyleBackColor = True
        ' 
        ' UMLParamListForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Body)
        Controls.Add(Header)
        Controls.Add(CancelButton)
        Controls.Add(OkButton)
        Name = "UMLParamListForm"
        Text = "UMLParamListForm"
        Header.ResumeLayout(False)
        Header.PerformLayout()
        Body.ResumeLayout(False)
        Body.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents OkButton As Button
    Friend WithEvents CancelButton As Button
    Friend WithEvents Header As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Body As FlowLayoutPanel
    Friend WithEvents Content As FlowLayoutPanel
    Friend WithEvents AddButton As Button
End Class
