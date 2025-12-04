Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class FormPertanyaan1

    ' =========================================================================
    ' STRUKTUR DATA DAN VARIABEL GLOBAL
    ' =========================================================================

    ' Struktur data untuk menampung data pertanyaan dari database
    Public Class QuestionData
        Public Property IdPertanyaan As String
        Public Property TeksPertanyaan As String
        Public Property Bobot As Integer
    End Class

    ' Dictionary untuk menyimpan semua data pertanyaan, dikelompokkan per Topik (T01, T02, dst)
    Private dataPertanyaanByTopik As New Dictionary(Of String, List(Of QuestionData))
    ' Dictionary untuk menyimpan jawaban pengguna: Key=IdPertanyaan (P001), Value=Jawaban ("Iya" atau "Tidak")
    Private jawabanPengguna As New Dictionary(Of String, String)

    ' Indeks section yang sedang aktif, dimulai dari 1
    Private currentSectionIndex As Integer = 1
    Private Const TOTAL_SECTIONS As Integer = 5
    Private Const TOTAL_QUESTIONS As Integer = 20


    ' =========================================================================
    ' 1. INIALISASI FORM DAN PENGAMBILAN DATA
    ' =========================================================================

    Private Sub FormSistemPakar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Muat semua data dari database
        LoadDataFromDatabase()
        ' 2. Tampilkan section pertama (T01)
        TampilkanSection()
    End Sub

    Private Sub LoadDataFromDatabase()
        Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\folder kuliah\tugas kuliah\semester 3\Pemrograman visual\PBL\PBL\PBL\SistemPakar.mdf;Integrated Security=True"
        Dim query As String = "SELECT Id_pertanyaan, teks_pertanyaan, bobot_pertanyaan, Id_topik FROM Pertanyaan ORDER BY Id_topik, Id_pertanyaan ASC"

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim idTopik As String = reader("Id_topik").ToString()

                            Dim question As New QuestionData() With {
                                .IdPertanyaan = reader("Id_pertanyaan").ToString(),
                                .TeksPertanyaan = reader("teks_pertanyaan").ToString(),
                                .Bobot = CInt(reader("bobot_pertanyaan").ToString())
                            }

                            ' Kelompokkan data berdasarkan Id_topik (T01, T02, dst)
                            If Not dataPertanyaanByTopik.ContainsKey(idTopik) Then
                                dataPertanyaanByTopik.Add(idTopik, New List(Of QuestionData)())
                            End If
                            dataPertanyaanByTopik(idTopik).Add(question)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data pertanyaan: " & ex.Message, "Error Database")
        End Try
    End Sub


    ' =========================================================================
    ' 2. FUNGSI MENAMPILKAN SECTION (KUNCI DINAMIS)
    ' =========================================================================

    Private Sub TampilkanSection()
        ' Bersihkan Panel konten utama
        PanelPertanyaan1.Controls.Clear()

        ' Tentukan Id Topik yang akan ditampilkan
        Dim idTopik As String = $"T0{currentSectionIndex}"

        If Not dataPertanyaanByTopik.ContainsKey(idTopik) Then
            MessageBox.Show($"Data untuk Topik {idTopik} tidak ditemukan!")
            Return
        End If

        Dim questions As List(Of QuestionData) = dataPertanyaanByTopik(idTopik)
        Dim currentY As Integer = 5 ' Posisi Y awal di Panel Konten Utama

        Me.Text = $"Sistem Pakar - Section {currentSectionIndex} / {TOTAL_SECTIONS}"

        For Each question As QuestionData In questions
            ' KUNCI ISOLASI: Buat Panel Individu untuk setiap pertanyaan
            Dim pnlPertanyaanIndividual As New Panel()
            pnlPertanyaanIndividual.Width = PanelPertanyaan1.Width - 10
            pnlPertanyaanIndividual.BorderStyle = BorderStyle.None

            ' 1. Label Teks Pertanyaan
            Dim lblTanya As New Label()
            lblTanya.Text = question.TeksPertanyaan
            lblTanya.Location = New Point(0, 5)
            lblTanya.Font = New Font(lblTanya.Font.FontFamily, 10, FontStyle.Regular)
            lblTanya.AutoSize = False
            lblTanya.Width = pnlPertanyaanIndividual.Width

            ' Hitung tinggi label untuk WordWrap
            Dim requiredSize As Size = TextRenderer.MeasureText(lblTanya.Text, lblTanya.Font, New Size(lblTanya.Width, 0), TextFormatFlags.WordBreak)
            lblTanya.Height = requiredSize.Height + 5
            pnlPertanyaanIndividual.Controls.Add(lblTanya)

            Dim yPosJawaban As Integer = lblTanya.Bottom + 5

            ' 2. RadioButton "Iya"
            Dim rbYa As New RadioButton()
            rbYa.Text = "Iya"
            rbYa.Location = New Point(0, yPosJawaban)
            rbYa.AutoSize = True
            rbYa.Tag = question.IdPertanyaan
            AddHandler rbYa.CheckedChanged, AddressOf RadioButton_CheckedChanged

            If jawabanPengguna.ContainsKey(question.IdPertanyaan) AndAlso jawabanPengguna(question.IdPertanyaan) = "Iya" Then
                rbYa.Checked = True
            End If
            pnlPertanyaanIndividual.Controls.Add(rbYa)

            yPosJawaban += 25

            ' 3. RadioButton "Tidak"
            Dim rbTidak As New RadioButton()
            rbTidak.Text = "Tidak"
            rbTidak.Location = New Point(0, yPosJawaban)
            rbTidak.AutoSize = True
            rbTidak.Tag = question.IdPertanyaan
            AddHandler rbTidak.CheckedChanged, AddressOf RadioButton_CheckedChanged

            If jawabanPengguna.ContainsKey(question.IdPertanyaan) AndAlso jawabanPengguna(question.IdPertanyaan) = "Tidak" Then
                rbTidak.Checked = True
            End If
            pnlPertanyaanIndividual.Controls.Add(rbTidak)

            ' 4. Atur tinggi Panel Individual
            pnlPertanyaanIndividual.Height = rbTidak.Bottom + 10

            ' 5. Atur posisi Panel Individual di Panel Konten Utama
            pnlPertanyaanIndividual.Location = New Point(0, currentY)
            PanelPertanyaan1.Controls.Add(pnlPertanyaanIndividual)

            ' Pindah ke posisi Y berikutnya
            currentY = pnlPertanyaanIndividual.Bottom + 15
        Next

        ' 6. Update status tombol navigasi
        ButtonSebelum.Visible = currentSectionIndex > 1 ' Sembunyikan di section 1
        ButtonLanjut.Text = If(currentSectionIndex = TOTAL_SECTIONS, "Hitung Hasil", "Selanjutnya")
    End Sub


    ' =========================================================================
    ' 3. LOGIKA NAVIGASI DAN JAWABAN
    ' =========================================================================

    Private Sub btnSelanjutnya_Click(sender As Object, e As EventArgs) Handles ButtonLanjut.Click
        If currentSectionIndex = TOTAL_SECTIONS Then
            HitungHasilPakar()
            Return
        End If

        ' Validasi jawaban di section saat ini (4 pertanyaan)
        Dim currentTopicId As String = $"T0{currentSectionIndex}"
        Dim answeredCount As Integer = 0
        For Each q As QuestionData In dataPertanyaanByTopik(currentTopicId)
            If jawabanPengguna.ContainsKey(q.IdPertanyaan) Then
                answeredCount += 1
            End If
        Next

        If answeredCount < dataPertanyaanByTopik(currentTopicId).Count Then
            MessageBox.Show("Harap jawab semua 4 pertanyaan di section ini sebelum melanjutkan.", "Validasi Jawaban", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        currentSectionIndex += 1
        TampilkanSection()
    End Sub

    Private Sub btnSebelumnya_Click(sender As Object, e As EventArgs) Handles ButtonSebelum.Click
        If currentSectionIndex > 1 Then
            currentSectionIndex -= 1
            TampilkanSection()
        End If
    End Sub

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs)
        Dim rb As RadioButton = TryCast(sender, RadioButton)
        If rb IsNot Nothing AndAlso rb.Checked Then
            Dim idPertanyaan As String = rb.Tag.ToString()
            Dim jawaban As String = rb.Text

            ' Simpan jawaban ke dalam Dictionary
            If jawabanPengguna.ContainsKey(idPertanyaan) Then
                jawabanPengguna(idPertanyaan) = jawaban
            Else
                jawabanPengguna.Add(idPertanyaan, jawaban)
            End If
        End If
    End Sub

    ' =========================================================================
    ' 4. PERHITUNGAN HASIL AKHIR
    ' =========================================================================

    Private Sub HitungHasilPakar()
        ' Validasi apakah semua 20 pertanyaan sudah dijawab
        If jawabanPengguna.Count < TOTAL_QUESTIONS Then
            MessageBox.Show($"Harap jawab semua {TOTAL_QUESTIONS} pertanyaan sebelum menghitung hasil.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim totalSkor As Integer = 0

        ' Iterasi semua pertanyaan yang dijawab "Iya"
        For Each item In jawabanPengguna
            Dim idPertanyaan As String = item.Key
            Dim jawaban As String = item.Value

            If jawaban.Equals("Iya", StringComparison.OrdinalIgnoreCase) Then
                ' Cari bobot pertanyaan di seluruh data yang sudah dimuat
                For Each topicEntry In dataPertanyaanByTopik.Values
                    Dim questionData = topicEntry.Find(Function(q) q.IdPertanyaan = idPertanyaan)
                    If questionData IsNot Nothing Then
                        totalSkor += questionData.Bobot
                        Exit For
                    End If
                Next
            End If
        Next

        MessageBox.Show($"Analisis Selesai! Total Skor Anda adalah: {totalSkor}", "Hasil Analisis Sistem Pakar")

        ' TODO: Tambahkan logika untuk menentukan Kesimpulan/Rekomendasi berdasarkan totalSkor
    End Sub

End Class