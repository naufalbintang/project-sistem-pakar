Imports System.Data.SqlClient

Public Class FormRegister

    Private Shared ReadOnly ConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\folder kuliah\tugas kuliah\semester 3\Pemrograman visual\PBL\PBL\PBL\SistemPakar.mdf;Integrated Security=True"


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inisialisasi: Pusatkan form, atur PasswordChar
        Me.StartPosition = FormStartPosition.CenterScreen
        TextBoxPassword.PasswordChar = "*"
    End Sub

    ' --- Event untuk Tombol Simpan/Daftar ---
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles ButtonSimpan.Click

        ' 1. Ambil Data Input
        Dim nim As String = TextBoxNIM.Text.Trim()
        Dim nama As String = TextBoxNama.Text.Trim()
        Dim email As String = TextBoxEmail.Text.Trim()
        Dim password As String = TextBoxPassword.Text

        ' 2. Validasi Input Dasar
        If nim = "" Or nama = "" Or email = "" Or password = "" Then
            MessageBox.Show("Semua kolom harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 3. Query SQL INSERT
        ' Query ini memasukkan data baru ke tabel Mahasiswa.
        ' Kami menggunakan Parameter (@...) untuk keamanan SQL Injection.
        Dim query As String = "INSERT INTO Mahasiswa (nim, nama, email, password) " &
                              "VALUES (@NIM, @NAMA, @EMAIL, @PASSWORD);"

        Using connection As New SqlConnection(ConnectionString)
            Using command As New SqlCommand(query, connection)

                ' 4. Isi Parameter dengan Nilai dari Form
                command.Parameters.AddWithValue("@NIM", nim)
                command.Parameters.AddWithValue("@NAMA", nama)
                command.Parameters.AddWithValue("@EMAIL", email)
                ' ⚠️ CATATAN KEAMANAN: Password disimpan sebagai Plain Text sesuai skema tabel.
                ' Sebaiknya menggunakan Hashing sebelum disimpan!
                command.Parameters.AddWithValue("@PASSWORD", password)

                Try
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery() ' Menjalankan perintah INSERT

                    If rowsAffected > 0 Then
                        MessageBox.Show("Pendaftaran Berhasil! Silakan Login.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Kosongkan input setelah berhasil
                        TextBoxNIM.Clear()
                        TextBoxNama.Clear()
                        TextBoxEmail.Clear()
                        TextBoxPassword.Clear()
                        TextBoxNIM.Focus()

                        ' Opsional: Tutup form Registrasi dan kembali ke Login
                        Me.Close()
                    Else
                        MessageBox.Show("Data gagal disimpan. Coba lagi.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Catch ex As SqlException
                    ' Menangkap Error SQL spesifik (misal: NIM sudah ada jika NIM Primary Key)
                    If ex.Number = 2627 Then ' Error code untuk Primary Key violation (duplikasi)
                        MessageBox.Show("NIM " & nim & " sudah terdaftar. Gunakan NIM lain.", "Gagal Simpan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("Terjadi error database: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Terjadi error umum: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End Using
        End Using

    End Sub

    Private Sub lblSignUp_Click(sender As Object, e As EventArgs) Handles LinkLabelSignin.Click
        Dim formLogin As New FormLogin()
        formLogin.Show()
    End Sub

End Class