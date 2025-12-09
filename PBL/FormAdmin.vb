Imports System.Data.SqlClient
Imports System.Data

Public Class FormAdmin

    ' Variabel ini tetap diperlukan untuk koneksi dan identitas, tapi tidak digunakan untuk menampilkan profil.
    Public AdminNIM As String = ""

    ' ===============================================
    '          EVENT HANDLERS UTAMA & NAVIGASI
    ' ===============================================

    Private Sub FormAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        '  Fokus: Hanya tampilkan panel Manajemen Akun User
        pnlUserManagement.Visible = True

        LoadAkunUser()        ' Memuat data akun ke DataGridView
    End Sub

    ' --- Navigasi Sidebar: Ke Manajemen Akun User (Refresh Data) ---
    Private Sub btnAkunUser_Click(sender As Object, e As EventArgs) Handles btnAkunUser.Click
        pnlUserManagement.Visible = True
        LoadAkunUser() ' Muat ulang data
    End Sub

    ' --- Navigasi Sidebar: Menu Pertanyaan ---
    Private Sub btnPertanyaan_Click(sender As Object, e As EventArgs) Handles btnPertanyaan.Click
        MessageBox.Show("Membuka menu manajemen Pertanyaan...", "Navigasi")
        ' Tambahkan kode untuk menampilkan fitur Pertanyaan di sini
    End Sub

    ' --- Navigasi Sidebar: Menu Hasil ---
    Private Sub btnHasil_Click(sender As Object, e As EventArgs) Handles btnHasil.Click
        MessageBox.Show("Membuka menu Hasil diagnosa...", "Navigasi")
        ' Tambahkan kode untuk menampilkan fitur Hasil di sini
    End Sub

    ' --- Logout ---
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Hide()
        Dim formLogin As New FormLogin()
        formLogin.Show()
    End Sub

    ' --- Event DataGridView (Mengisi TextBox Edit saat sel diklik) ---
    Private Sub dgvAkunUser_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAkunUser.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvAkunUser.Rows(e.RowIndex)

            txtEditIdUser.Text = row.Cells("id_user").Value.ToString()
            txtEditNama.Text = row.Cells("nama").Value.ToString()
            txtEditEmail.Text = row.Cells("email").Value.ToString()
            txtEditRole.Text = row.Cells("role").Value.ToString()

            txtEditPassword.Text = ""
            txtEditIdUser.ReadOnly = True ' ID User tidak bisa diubah saat mode edit
        End If
    End Sub

    ' ===============================================
    '          FUNGSI CRUD AKUN USER
    ' ===============================================

    ' --- READ: Memuat Data Akun ke DataGridView ---
    Private Sub LoadAkunUser()
        ' Ambil semua Akun, kecuali password
        Dim query As String = "SELECT id_user, nama, email, role FROM Akun ORDER BY role DESC;"

        Using connection As New SqlConnection(ModuleDB.connectionString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim dataAdapter As New SqlDataAdapter(command)
                    Dim dataTable As New DataTable()

                    dataAdapter.Fill(dataTable)
                    dgvAkunUser.DataSource = dataTable

                Catch ex As Exception
                    MessageBox.Show("Gagal memuat daftar akun user: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' --- CREATE (Tombol Tambah Baru) ---
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        ClearEditFields()
        txtEditRole.Text = "Mahasiswa" ' Set default role
        txtEditIdUser.ReadOnly = False ' ID User bisa diisi
        txtEditIdUser.Focus()

        MessageBox.Show("Masukkan data user baru lalu klik 'UPDATE'.", "Input Baru", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' --- DELETE (Hapus Akun) ---
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvAkunUser.CurrentRow Is Nothing Then
            MessageBox.Show("Pilih baris yang akan dihapus terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim idUserToDelete As String = dgvAkunUser.CurrentRow.Cells("id_user").Value.ToString()

        If MessageBox.Show($"Yakin ingin menghapus akun {idUserToDelete}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim query As String = "DELETE FROM Akun WHERE id_user = @ID_USER;"

            Using connection As New SqlConnection(ModuleDB.connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ID_USER", idUserToDelete)

                    Try
                        connection.Open()
                        command.ExecuteNonQuery()
                        MessageBox.Show("Akun berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadAkunUser()
                        ClearEditFields()
                    Catch ex As Exception
                        MessageBox.Show("Gagal menghapus akun: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    ' --- UPDATE / INSERT (Tombol UPDATE) ---
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim idUser As String = txtEditIdUser.Text.Trim()
        Dim nama As String = txtEditNama.Text.Trim()
        Dim email As String = txtEditEmail.Text.Trim()
        Dim role As String = txtEditRole.Text.Trim()
        Dim passwordNew As String = txtEditPassword.Text

        If idUser = "" Or nama = "" Or email = "" Or role = "" Then
            MessageBox.Show("Semua kolom (kecuali Password) wajib diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim isExistingUser As Boolean = dgvAkunUser.Rows.Cast(Of DataGridViewRow)().Any(Function(row) row.Cells("id_user").Value.ToString() = idUser)

        If isExistingUser Then
            ' LOGIKA UPDATE
            Dim query As String
            If passwordNew = "" Then
                query = "UPDATE Akun SET nama=@NAMA, email=@EMAIL, role=@ROLE WHERE id_user=@ID_USER;"
            Else
                query = "UPDATE Akun SET nama=@NAMA, email=@EMAIL, role=@ROLE, password=@PASSWORD WHERE id_user=@ID_USER;"
            End If
            ExecuteUpdateOrInsert(query, idUser, nama, email, role, passwordNew, "UPDATE")
        Else
            ' LOGIKA CREATE (INSERT)
            If passwordNew = "" Then
                MessageBox.Show("Untuk user baru, password wajib diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim query As String = "INSERT INTO Akun (id_user, nama, email, role, password) VALUES (@ID_USER, @NAMA, @EMAIL, @ROLE, @PASSWORD);"
            ExecuteUpdateOrInsert(query, idUser, nama, email, role, passwordNew, "INSERT")
        End If

        LoadAkunUser()
        ClearEditFields()
        txtEditIdUser.ReadOnly = True
    End Sub

    ' ===============================================
    '          FUNGSI UTILITY
    ' ===============================================

    Private Sub ClearEditFields()
        txtEditIdUser.Clear()
        txtEditNama.Clear()
        txtEditEmail.Clear()
        txtEditPassword.Clear()
        txtEditRole.Clear()
    End Sub

    Private Sub ExecuteUpdateOrInsert(query As String, idUser As String, nama As String, email As String, role As String, passwordNew As String, action As String)
        Using connection As New SqlConnection(ModuleDB.connectionString)
            Using command As New SqlCommand(query, connection)

                command.Parameters.AddWithValue("@ID_USER", idUser)
                command.Parameters.AddWithValue("@NAMA", nama)
                command.Parameters.AddWithValue("@EMAIL", email)
                command.Parameters.AddWithValue("@ROLE", role)

                If passwordNew <> "" Then
                    command.Parameters.AddWithValue("@PASSWORD", passwordNew)
                End If

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    MessageBox.Show("Data akun berhasil disimpan/diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show($"Gagal melakukan {action}: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

End Class