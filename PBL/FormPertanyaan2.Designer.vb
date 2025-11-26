<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPertanyaan2
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
        Me.ButtonLanjut = New System.Windows.Forms.Button()
        Me.ButtonSebelumnya = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonLanjut
        '
        Me.ButtonLanjut.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ButtonLanjut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.ButtonLanjut.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonLanjut.Location = New System.Drawing.Point(766, 412)
        Me.ButtonLanjut.Name = "ButtonLanjut"
        Me.ButtonLanjut.Size = New System.Drawing.Size(131, 28)
        Me.ButtonLanjut.TabIndex = 1
        Me.ButtonLanjut.Text = "Lanjut"
        Me.ButtonLanjut.UseVisualStyleBackColor = False
        '
        'ButtonSebelumnya
        '
        Me.ButtonSebelumnya.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ButtonSebelumnya.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.ButtonSebelumnya.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonSebelumnya.Location = New System.Drawing.Point(54, 412)
        Me.ButtonSebelumnya.Name = "ButtonSebelumnya"
        Me.ButtonSebelumnya.Size = New System.Drawing.Size(131, 28)
        Me.ButtonSebelumnya.TabIndex = 2
        Me.ButtonSebelumnya.Text = "Sebelumnya"
        Me.ButtonSebelumnya.UseVisualStyleBackColor = False
        '
        'FormPertanyaan2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 473)
        Me.Controls.Add(Me.ButtonSebelumnya)
        Me.Controls.Add(Me.ButtonLanjut)
        Me.Name = "FormPertanyaan2"
        Me.Text = "FormPertanyaan2"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonLanjut As Button
    Friend WithEvents ButtonSebelumnya As Button
End Class
