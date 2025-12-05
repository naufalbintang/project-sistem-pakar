<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRegister
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
        Me.TextBoxNIM = New System.Windows.Forms.TextBox()
        Me.TextBoxNama = New System.Windows.Forms.TextBox()
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.ButtonSimpan = New System.Windows.Forms.Button()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LinkLabelSignin = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(413, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Input Data Diri"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(222, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "NIM"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(222, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nama"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(222, 245)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Email"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(222, 310)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Password"
        '
        'TextBoxNIM
        '
        Me.TextBoxNIM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextBoxNIM.Location = New System.Drawing.Point(225, 143)
        Me.TextBoxNIM.Name = "TextBoxNIM"
        Me.TextBoxNIM.Size = New System.Drawing.Size(500, 25)
        Me.TextBoxNIM.TabIndex = 5
        '
        'TextBoxNama
        '
        Me.TextBoxNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextBoxNama.Location = New System.Drawing.Point(225, 212)
        Me.TextBoxNama.Name = "TextBoxNama"
        Me.TextBoxNama.Size = New System.Drawing.Size(500, 25)
        Me.TextBoxNama.TabIndex = 6
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextBoxEmail.Location = New System.Drawing.Point(225, 275)
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(500, 25)
        Me.TextBoxEmail.TabIndex = 7
        '
        'ButtonSimpan
        '
        Me.ButtonSimpan.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ButtonSimpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ButtonSimpan.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonSimpan.Location = New System.Drawing.Point(225, 415)
        Me.ButtonSimpan.Name = "ButtonSimpan"
        Me.ButtonSimpan.Size = New System.Drawing.Size(500, 36)
        Me.ButtonSimpan.TabIndex = 9
        Me.ButtonSimpan.Text = "Simpan"
        Me.ButtonSimpan.UseVisualStyleBackColor = False
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextBoxPassword.Location = New System.Drawing.Point(225, 343)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.Size = New System.Drawing.Size(500, 25)
        Me.TextBoxPassword.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(385, 383)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Sudah punya akun?"
        '
        'LinkLabelSignin
        '
        Me.LinkLabelSignin.AutoSize = True
        Me.LinkLabelSignin.Location = New System.Drawing.Point(516, 383)
        Me.LinkLabelSignin.Name = "LinkLabelSignin"
        Me.LinkLabelSignin.Size = New System.Drawing.Size(48, 16)
        Me.LinkLabelSignin.TabIndex = 13
        Me.LinkLabelSignin.TabStop = True
        Me.LinkLabelSignin.Text = "Sign-in"
        '
        'FormRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 473)
        Me.Controls.Add(Me.LinkLabelSignin)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxPassword)
        Me.Controls.Add(Me.ButtonSimpan)
        Me.Controls.Add(Me.TextBoxEmail)
        Me.Controls.Add(Me.TextBoxNama)
        Me.Controls.Add(Me.TextBoxNIM)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormRegister"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxNIM As TextBox
    Friend WithEvents TextBoxNama As TextBox
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents ButtonSimpan As Button
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents LinkLabelSignin As LinkLabel
End Class
