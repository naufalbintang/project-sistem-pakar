<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPertanyaan5
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
        Me.ButtonSelesai = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonSelesai
        '
        Me.ButtonSelesai.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ButtonSelesai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.ButtonSelesai.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonSelesai.Location = New System.Drawing.Point(766, 418)
        Me.ButtonSelesai.Name = "ButtonSelesai"
        Me.ButtonSelesai.Size = New System.Drawing.Size(131, 28)
        Me.ButtonSelesai.TabIndex = 3
        Me.ButtonSelesai.Text = "Simpan"
        Me.ButtonSelesai.UseVisualStyleBackColor = False
        '
        'FormPertanyaan5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 473)
        Me.Controls.Add(Me.ButtonSelesai)
        Me.Name = "FormPertanyaan5"
        Me.Text = "FormPertanyaan5"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonSelesai As Button
End Class
