<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtArgument1 = New System.Windows.Forms.TextBox()
        Me.txtArgument2 = New System.Windows.Forms.TextBox()
        Me.txtArgument3 = New System.Windows.Forms.TextBox()
        Me.txtArgument4 = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnOpenForm = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Information retrieved from Pimphony : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Argument 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Argument 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Argument 3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Argument 4"
        '
        'txtArgument1
        '
        Me.txtArgument1.Location = New System.Drawing.Point(108, 37)
        Me.txtArgument1.Name = "txtArgument1"
        Me.txtArgument1.Size = New System.Drawing.Size(194, 20)
        Me.txtArgument1.TabIndex = 5
        '
        'txtArgument2
        '
        Me.txtArgument2.Location = New System.Drawing.Point(108, 63)
        Me.txtArgument2.Name = "txtArgument2"
        Me.txtArgument2.Size = New System.Drawing.Size(194, 20)
        Me.txtArgument2.TabIndex = 6
        '
        'txtArgument3
        '
        Me.txtArgument3.Location = New System.Drawing.Point(107, 89)
        Me.txtArgument3.Name = "txtArgument3"
        Me.txtArgument3.Size = New System.Drawing.Size(194, 20)
        Me.txtArgument3.TabIndex = 7
        '
        'txtArgument4
        '
        Me.txtArgument4.Location = New System.Drawing.Point(108, 115)
        Me.txtArgument4.Name = "txtArgument4"
        Me.txtArgument4.Size = New System.Drawing.Size(194, 20)
        Me.txtArgument4.TabIndex = 8
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(226, 141)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnOpenForm
        '
        Me.btnOpenForm.Location = New System.Drawing.Point(132, 141)
        Me.btnOpenForm.Name = "btnOpenForm"
        Me.btnOpenForm.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenForm.TabIndex = 10
        Me.btnOpenForm.Text = "&Open Form"
        Me.btnOpenForm.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 170)
        Me.Controls.Add(Me.btnOpenForm)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtArgument4)
        Me.Controls.Add(Me.txtArgument3)
        Me.Controls.Add(Me.txtArgument2)
        Me.Controls.Add(Me.txtArgument1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pimphony Integration Utility"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtArgument1 As System.Windows.Forms.TextBox
    Friend WithEvents txtArgument2 As System.Windows.Forms.TextBox
    Friend WithEvents txtArgument3 As System.Windows.Forms.TextBox
    Friend WithEvents txtArgument4 As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnOpenForm As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog

End Class
