Imports System.Data.SqlClient

Public Class FormLogin

    ' =========================================================================
    '                          EVENT HANDLERS UTAMA
    ' =========================================================================

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inisialisasi awal form
        Me.StartPosition = FormStartPosition.CenterScreen
        TextBoxPassword.PasswordChar = "*"
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles ButtonSignin.Click

        Dim idUser As String = TextBoxNIM.Text.Trim() ' Mengambil ID User/NIM
        Dim passwordInput As String = TextBoxPassword.Text

        ' Validasi Input
        If idUser = "" Or passwordInput = "" Then
            MessageBox.Show("ID User dan Password harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Query: Mengambil password dan role dari tabel Akun berdasarkan id_user
        Dim query As String = "SELECT password, role FROM Akun WHERE id_user = @ID_USER;"

        Using connection As New SqlConnection(ModuleDB.connectionString)
            Using command As New SqlCommand(query, connection)

                command.Parameters.AddWithValue("@ID_USER", idUser)

                Try
                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()

                    If reader.Read() Then
                        Dim storedPassword As String = reader("password").ToString()
                        Dim userRole As String = reader("role").ToString()

                        If passwordInput = storedPassword Then

                            MessageBox.Show("Login Berhasil! Selamat Datang.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            reader.Close() ' Tutup reader sebelum navigasi

                            ' Cek Role untuk navigasi
                            If userRole.ToUpper() = "ADMIN" Then
                                Me.Hide()
                                Dim formAdmin As New FormAdmin() ' Asumsi Form Admin bernama FormAdmin
                                formAdmin.AdminNIM = idUser ' Mengirim ID Admin ke FormAdmin
                                formAdmin.Show()
                            Else ' Role Mahasiswa atau lainnya
                                Me.Hide()
                                Dim formUtama As New FormPertanyaan1() ' Ganti FormMenu() dengan nama form utama Mahasiswa
                                formUtama.Show()
                            End If

                        Else
                            ' Password salah
                            MessageBox.Show("ID User atau Password salah.", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            TextBoxPassword.Clear()
                            TextBoxPassword.Focus()
                        End If

                    Else
                        ' ID User tidak ditemukan
                        MessageBox.Show("ID User tidak terdaftar.", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Terjadi error koneksi database: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End Using
        End Using

    End Sub

    Private Sub lblSignUp_Click(sender As Object, e As EventArgs) Handles LinkLabelSignup.Click
        ' Logika untuk membuka Form Registrasi (Input Data Diri)
        Dim formRegis As New FormRegister() ' Asumsi Form Registrasi bernama FormRegister
        formRegis.Show()
    End Sub

End Class