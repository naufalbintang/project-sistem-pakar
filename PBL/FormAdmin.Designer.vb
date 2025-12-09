<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAdmin
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
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnHasil = New System.Windows.Forms.Button()
        Me.btnPertanyaan = New System.Windows.Forms.Button()
        Me.btnAkunUser = New System.Windows.Forms.Button()
        Me.lblFeature = New System.Windows.Forms.Label()
        Me.lblAdminTitle = New System.Windows.Forms.Label()
        Me.pnlKonten = New System.Windows.Forms.Panel()
        Me.pnlUserManagement = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEditRole = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEditIdUser = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEditPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEditEmail = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEditNama = New System.Windows.Forms.TextBox()
        Me.dgvAkunUser = New System.Windows.Forms.DataGridView()
        Me.pnlSidebar.SuspendLayout()
        Me.pnlKonten.SuspendLayout()
        Me.pnlUserManagement.SuspendLayout()
        CType(Me.dgvAkunUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSidebar
        '
        Me.pnlSidebar.Controls.Add(Me.btnLogout)
        Me.pnlSidebar.Controls.Add(Me.btnHasil)
        Me.pnlSidebar.Controls.Add(Me.btnPertanyaan)
        Me.pnlSidebar.Controls.Add(Me.btnAkunUser)
        Me.pnlSidebar.Controls.Add(Me.lblFeature)
        Me.pnlSidebar.Controls.Add(Me.lblAdminTitle)
        Me.pnlSidebar.Location = New System.Drawing.Point(13, 13)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(200, 448)
        Me.pnlSidebar.TabIndex = 0
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(19, 422)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(162, 23)
        Me.btnLogout.TabIndex = 6
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnHasil
        '
        Me.btnHasil.BackColor = System.Drawing.SystemColors.Info
        Me.btnHasil.Location = New System.Drawing.Point(19, 205)
        Me.btnHasil.Name = "btnHasil"
        Me.btnHasil.Size = New System.Drawing.Size(162, 23)
        Me.btnHasil.TabIndex = 5
        Me.btnHasil.Text = "Hasil"
        Me.btnHasil.UseVisualStyleBackColor = False
        '
        'btnPertanyaan
        '
        Me.btnPertanyaan.BackColor = System.Drawing.SystemColors.Info
        Me.btnPertanyaan.Location = New System.Drawing.Point(19, 165)
        Me.btnPertanyaan.Name = "btnPertanyaan"
        Me.btnPertanyaan.Size = New System.Drawing.Size(162, 23)
        Me.btnPertanyaan.TabIndex = 4
        Me.btnPertanyaan.Text = "Pertanyaan"
        Me.btnPertanyaan.UseVisualStyleBackColor = False
        '
        'btnAkunUser
        '
        Me.btnAkunUser.BackColor = System.Drawing.SystemColors.Info
        Me.btnAkunUser.Location = New System.Drawing.Point(19, 126)
        Me.btnAkunUser.Name = "btnAkunUser"
        Me.btnAkunUser.Size = New System.Drawing.Size(162, 23)
        Me.btnAkunUser.TabIndex = 3
        Me.btnAkunUser.Text = "Akun User"
        Me.btnAkunUser.UseVisualStyleBackColor = False
        '
        'lblFeature
        '
        Me.lblFeature.AutoSize = True
        Me.lblFeature.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.lblFeature.Location = New System.Drawing.Point(16, 108)
        Me.lblFeature.Name = "lblFeature"
        Me.lblFeature.Size = New System.Drawing.Size(43, 13)
        Me.lblFeature.TabIndex = 2
        Me.lblFeature.Text = "Feature"
        '
        'lblAdminTitle
        '
        Me.lblAdminTitle.AutoSize = True
        Me.lblAdminTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblAdminTitle.Location = New System.Drawing.Point(62, 22)
        Me.lblAdminTitle.Name = "lblAdminTitle"
        Me.lblAdminTitle.Size = New System.Drawing.Size(66, 22)
        Me.lblAdminTitle.TabIndex = 1
        Me.lblAdminTitle.Text = "ADMIN"
        '
        'pnlKonten
        '
        Me.pnlKonten.Controls.Add(Me.pnlUserManagement)
        Me.pnlKonten.Location = New System.Drawing.Point(232, 13)
        Me.pnlKonten.Name = "pnlKonten"
        Me.pnlKonten.Size = New System.Drawing.Size(684, 445)
        Me.pnlKonten.TabIndex = 1
        '
        'pnlUserManagement
        '
        Me.pnlUserManagement.Controls.Add(Me.Label5)
        Me.pnlUserManagement.Controls.Add(Me.txtEditRole)
        Me.pnlUserManagement.Controls.Add(Me.Label6)
        Me.pnlUserManagement.Controls.Add(Me.txtEditIdUser)
        Me.pnlUserManagement.Controls.Add(Me.btnDelete)
        Me.pnlUserManagement.Controls.Add(Me.btnAddNew)
        Me.pnlUserManagement.Controls.Add(Me.btnUpdate)
        Me.pnlUserManagement.Controls.Add(Me.Label4)
        Me.pnlUserManagement.Controls.Add(Me.txtEditPassword)
        Me.pnlUserManagement.Controls.Add(Me.Label3)
        Me.pnlUserManagement.Controls.Add(Me.txtEditEmail)
        Me.pnlUserManagement.Controls.Add(Me.Label1)
        Me.pnlUserManagement.Controls.Add(Me.txtEditNama)
        Me.pnlUserManagement.Controls.Add(Me.dgvAkunUser)
        Me.pnlUserManagement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlUserManagement.Location = New System.Drawing.Point(0, 0)
        Me.pnlUserManagement.Name = "pnlUserManagement"
        Me.pnlUserManagement.Size = New System.Drawing.Size(684, 445)
        Me.pnlUserManagement.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 329)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 16)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Role"
        '
        'txtEditRole
        '
        Me.txtEditRole.Location = New System.Drawing.Point(24, 349)
        Me.txtEditRole.Name = "txtEditRole"
        Me.txtEditRole.Size = New System.Drawing.Size(200, 22)
        Me.txtEditRole.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 221)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "NIM"
        '
        'txtEditIdUser
        '
        Me.txtEditIdUser.Location = New System.Drawing.Point(24, 241)
        Me.txtEditIdUser.Name = "txtEditIdUser"
        Me.txtEditIdUser.Size = New System.Drawing.Size(200, 22)
        Me.txtEditIdUser.TabIndex = 12
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(258, 386)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(113, 23)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(260, 315)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(113, 23)
        Me.btnAddNew.TabIndex = 10
        Me.btnAddNew.Text = "ADD NEW"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(258, 349)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(113, 23)
        Me.btnUpdate.TabIndex = 9
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 382)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Password"
        '
        'txtEditPassword
        '
        Me.txtEditPassword.Location = New System.Drawing.Point(24, 402)
        Me.txtEditPassword.Name = "txtEditPassword"
        Me.txtEditPassword.Size = New System.Drawing.Size(200, 22)
        Me.txtEditPassword.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 273)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Email"
        '
        'txtEditEmail
        '
        Me.txtEditEmail.Location = New System.Drawing.Point(24, 293)
        Me.txtEditEmail.Name = "txtEditEmail"
        Me.txtEditEmail.Size = New System.Drawing.Size(200, 22)
        Me.txtEditEmail.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nama"
        '
        'txtEditNama
        '
        Me.txtEditNama.Location = New System.Drawing.Point(24, 188)
        Me.txtEditNama.Name = "txtEditNama"
        Me.txtEditNama.Size = New System.Drawing.Size(200, 22)
        Me.txtEditNama.TabIndex = 1
        '
        'dgvAkunUser
        '
        Me.dgvAkunUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAkunUser.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvAkunUser.Location = New System.Drawing.Point(0, 0)
        Me.dgvAkunUser.Name = "dgvAkunUser"
        Me.dgvAkunUser.RowHeadersWidth = 53
        Me.dgvAkunUser.RowTemplate.Height = 24
        Me.dgvAkunUser.Size = New System.Drawing.Size(684, 150)
        Me.dgvAkunUser.TabIndex = 0
        '
        'FormAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 473)
        Me.Controls.Add(Me.pnlKonten)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Name = "FormAdmin"
        Me.Text = "FormAdmin"
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout()
        Me.pnlKonten.ResumeLayout(False)
        Me.pnlUserManagement.ResumeLayout(False)
        Me.pnlUserManagement.PerformLayout()
        CType(Me.dgvAkunUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblAdminTitle As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnHasil As Button
    Friend WithEvents btnPertanyaan As Button
    Friend WithEvents btnAkunUser As Button
    Friend WithEvents lblFeature As Label
    Friend WithEvents pnlKonten As Panel
    Friend WithEvents pnlUserManagement As Panel
    Friend WithEvents dgvAkunUser As DataGridView
    Friend WithEvents btnUpdate As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEditPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEditEmail As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEditNama As TextBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtEditRole As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEditIdUser As TextBox
End Class
