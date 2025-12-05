Imports System.Data.SqlClient

Public Class FormLogin

    Private Shared ReadOnly ConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\folder kuliah\tugas kuliah\semester 3\Pemrograman visual\PBL\PBL\PBL\SistemPakar.mdf;Integrated Security=True"




    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Mengatur posisi form di tengah layar
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Mengatur PasswordChar untuk menyembunyikan input password
        ' Pastikan nama kontrolnya adalah 'txtPassword'
        TextBoxPassword.PasswordChar = "*"
    End Sub

    ' --- Event untuk Tombol Login ---
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles ButtonSignin.Click

        Dim nim As String = TextBoxNIM.Text.Trim()
        Dim password As String = TextBoxPassword.Text

        ' 1. Validasi Input Sederhana
        If nim = "" Or password = "" Then
            MessageBox.Show("NIM dan Password harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Logika Otentikasi dengan Database
        ' Query untuk mengambil password (atau hash) dari tabel Mahasiswa berdasarkan NIM.
        ' ⚠️ Sesuaikan nama tabel (e.g., Mahasiswa) dan kolom (e.g., PasswordHash) dengan database Anda.
        Dim query As String = "SELECT password FROM Mahasiswa WHERE nim = @NIM;"

        ' Menggunakan blok Using memastikan objek koneksi dan command tertutup dengan benar
        Using connection As New SqlConnection(ConnectionString)
            Using command As New SqlCommand(query, connection)

                ' Mencegah SQL Injection dengan menggunakan Parameter
                command.Parameters.AddWithValue("@NIM", nim)

                Try
                    connection.Open()
                    Dim result As Object = command.ExecuteScalar() ' Mengambil satu nilai (PasswordHash)

                    If result IsNot Nothing Then
                        Dim storedPasswordHash As String = result.ToString()

                        ' 3. Verifikasi Password
                        ' Jika Anda TIDAK menggunakan Hashing (Hanya untuk contoh sederhana/tidak aman):
                        If password = storedPasswordHash Then

                            MessageBox.Show("Login Berhasil! Selamat Datang.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' --- Tampilkan Form Utama ---
                            ' Ganti FormMenu() dengan nama form utama aplikasi Anda
                            Me.Hide()
                            Dim formUtama As New FormPertanyaan1()
                            formUtama.Show()

                        Else
                            MessageBox.Show("NIM atau Password salah.", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            TextBoxPassword.Clear()
                            TextBoxPassword.Focus()
                        End If

                    Else
                        ' NIM tidak ditemukan di database
                        MessageBox.Show("NIM tidak terdaftar.", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        TextBoxNIM.Focus()
                    End If

                Catch ex As Exception
                    MessageBox.Show("Terjadi error koneksi database: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End Using
        End Using
        'Me.Close()
    End Sub

    ' --- Event untuk Link Sign-up (lblSignUp) ---
    Private Sub lblSignUp_Click(sender As Object, e As EventArgs) Handles LinkLabelSignup.Click
        Dim formRegister As New FormRegister()
        formRegister.Show()
    End Sub

End Class