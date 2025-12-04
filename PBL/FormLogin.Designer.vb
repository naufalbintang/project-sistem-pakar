<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogin
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
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxNIM = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonSignin = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LinkLabelSignup = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(393, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SELAMAT DATANG"
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextBoxPassword.Location = New System.Drawing.Point(228, 248)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.Size = New System.Drawing.Size(500, 25)
        Me.TextBoxPassword.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(225, 218)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Password"
        '
        'TextBoxNIM
        '
        Me.TextBoxNIM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextBoxNIM.Location = New System.Drawing.Point(228, 172)
        Me.TextBoxNIM.Name = "TextBoxNIM"
        Me.TextBoxNIM.Size = New System.Drawing.Size(500, 25)
        Me.TextBoxNIM.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(225, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "NIM"
        '
        'ButtonSignin
        '
        Me.ButtonSignin.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ButtonSignin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ButtonSignin.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonSignin.Location = New System.Drawing.Point(228, 347)
        Me.ButtonSignin.Name = "ButtonSignin"
        Me.ButtonSignin.Size = New System.Drawing.Size(500, 36)
        Me.ButtonSignin.TabIndex = 10
        Me.ButtonSignin.Text = "Login"
        Me.ButtonSignin.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(393, 309)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Belum punya akun?"
        '
        'LinkLabelSignup
        '
        Me.LinkLabelSignup.AutoSize = True
        Me.LinkLabelSignup.Location = New System.Drawing.Point(515, 309)
        Me.LinkLabelSignup.Name = "LinkLabelSignup"
        Me.LinkLabelSignup.Size = New System.Drawing.Size(53, 16)
        Me.LinkLabelSignup.TabIndex = 12
        Me.LinkLabelSignup.TabStop = True
        Me.LinkLabelSignup.Text = "Sign-up"
        '
        'FormLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 473)
        Me.Controls.Add(Me.LinkLabelSignup)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ButtonSignin)
        Me.Controls.Add(Me.TextBoxNIM)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormLogin"
        Me.Text = "FormLogin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxNIM As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonSignin As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents LinkLabelSignup As LinkLabel
End Class
