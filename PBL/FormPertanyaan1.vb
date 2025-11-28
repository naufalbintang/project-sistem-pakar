Imports System.Data.SqlClient

Public Class FormPertanyaan1
    Private Sub FormPertanyaan1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampilkanPertanyaan()
    End Sub

    Private Sub tampilkanPertanyaan()
        Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\folder kuliah\tugas kuliah\semester 3\Pemrograman visual\PBL\PBL\PBL\SistemPakar.mdf;Integrated Security=True"
        Dim query As String = "SELECT teks_pertanyaan, id_pertanyaan FROM Pertanyaan ORDER BY ID_pertanyaan"
        Dim yPos As Integer = 10

        Try
            Using connection As New SqlConnection(connectionString)
                Using Command As New SqlCommand(query, connection)
                    connection.Open()
                    Dim reader As SqlDataReader = Command.ExecuteReader()

                    While reader.Read()
                        ' Ambil data
                        Dim teksPertanyaan As String = reader("teks_pertanyaan").ToString()
                        Dim idPertanyaan As Integer = Convert.ToInt32(reader("id_pertanyaan"))

                        ' === Bagian 1: Membuat Label Pertanyaan ===
                        Dim lblPertanyaan As New Label()
                        lblPertanyaan.Text = teksPertanyaan
                        lblPertanyaan.Location = New Point(10, yPos)
                        lblPertanyaan.AutoSize = True
                        lblPertanyaan.MaximumSize = New Size(pnlcontainer.Width - 30, 0) ' Batasi lebar teks
                        lblPertanyaan.Font = New Font(lblPertanyaan.Font, FontStyle.Bold) ' Opsional: bold
                        pnlcontainer.Controls.Add(lblPertanyaan)

                        yPos += lblPertanyaan.Height + 5 ' Naikkan posisi Y untuk Radio Buttons

                        ' === Bagian 2: Membuat Radio Button "Iya" ===
                        Dim rbIya As New RadioButton()
                        rbIya.Text = "Iya"
                        rbIya.Location = New Point(30, yPos)
                        ' Tambahkan Tag untuk menyimpan ID Pertanyaan agar mudah diproses saat submit
                        rbIya.Tag = idPertanyaan.ToString() & "_Iya"
                        rbIya.AutoSize = True
                        pnlcontainer.Controls.Add(rbIya)

                        yPos += rbIya.Height + 5 ' Naikkan posisi Y untuk Radio Button "Tidak"

                        ' === Bagian 3: Membuat Radio Button "Tidak" ===
                        Dim rbTidak As New RadioButton()
                        rbTidak.Text = "Tidak"
                        rbTidak.Location = New Point(30, yPos)
                        rbTidak.Tag = idPertanyaan.ToString() & "_Tidak" ' Tag untuk identifikasi
                        rbTidak.AutoSize = True
                        pnlcontainer.Controls.Add(rbTidak)

                        yPos += rbTidak.Height + 30 ' Tambahkan jarak besar ke pertanyaan berikutnya
                    End While

                    reader.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)

        End Try

    End Sub


    Private Sub ButtonLanjut_Click(sender As Object, e As EventArgs) Handles ButtonLanjut.Click
        For Each ctrl As Control In pnlcontainer.Controls
            If TypeOf ctrl Is RadioButton Then
                Dim rb As RadioButton = DirectCast(ctrl, RadioButton)
                If rb.Checked Then
                    ' rb.Tag berisi ID_Pertanyaan_Jawaban (misal: "1_Iya")
                    Dim result As String() = rb.Tag.ToString().Split("_"c)
                    Dim idPertanyaan As Integer = Convert.ToInt32(result(0))
                    Dim jawaban As String = result(1)

                    ' Di sini Anda bisa menyimpan ID Pertanyaan dan Jawaban ke
                    ' LIST sementara atau langsung ke database Jawaban
                    MessageBox.Show($"Pertanyaan ID: {idPertanyaan}, Jawaban: {jawaban}")

                    ' TODO: Tambahkan kode untuk menyimpan data ini ke database Jawaban Anda
                End If
            End If
        Next

        Dim FormPertanyaan2 As New FormPertanyaan2()
        FormPertanyaan2.Show()
        Me.Hide()
    End Sub

End Class