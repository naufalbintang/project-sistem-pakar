<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPertanyaan1
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
        Me.SuspendLayout()
        '
        'ButtonLanjut
        '
        Me.ButtonLanjut.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ButtonLanjut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.ButtonLanjut.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonLanjut.Location = New System.Drawing.Point(766, 418)
        Me.ButtonLanjut.Name = "ButtonLanjut"
        Me.ButtonLanjut.Size = New System.Drawing.Size(131, 28)
        Me.ButtonLanjut.TabIndex = 0
        Me.ButtonLanjut.Text = "Lanjut"
        Me.ButtonLanjut.UseVisualStyleBackColor = False
        '
        'FormPertanyaan1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 473)
        Me.Controls.Add(Me.ButtonLanjut)
        Me.Name = "FormPertanyaan1"
        Me.Text = "Form2"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonLanjut As Button
End Class
