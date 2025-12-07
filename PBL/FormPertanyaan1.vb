Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Linq 

Public Class FormPertanyaan1

    ' =========================================================================
    ' STRUKTUR DATA DAN VARIABEL GLOBAL
    ' =========================================================================

    ' 1. Struktur data untuk menampung data pertanyaan dari database
    Public Class QuestionData
        Public Property IdPertanyaan As String
        Public Property TeksPertanyaan As String
        Public Property Bobot As Integer
    End Class

    ' 2. Struktur data untuk menampung hasil skor per topik (OUTPUT ARRAY)
    Public Class HasilTopik
        Public Property IdTopik As String
        Public Property TotalSkorTopik As Integer
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
        Dim query As String = "SELECT Id_pertanyaan, teks_pertanyaan, bobot_pertanyaan, Id_topik FROM Pertanyaan ORDER BY Id_topik, Id_pertanyaan ASC"

        Try
            Using connection As SqlConnection = ModuleDB.getConnection()
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
        PanelPertanyaan1.Controls.Clear()

        Dim idTopik As String = $"T0{currentSectionIndex}"

        If Not dataPertanyaanByTopik.ContainsKey(idTopik) Then
            MessageBox.Show($"Data untuk Topik {idTopik} tidak ditemukan!")
            Return
        End If

        Dim questions As List(Of QuestionData) = dataPertanyaanByTopik(idTopik)
        Dim currentY As Integer = 5

        Me.Text = $"Sistem Pakar - Section {currentSectionIndex} / {TOTAL_SECTIONS}"

        For Each question As QuestionData In questions
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
        ButtonSebelum.Visible = currentSectionIndex > 1
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

        ' Validasi jawaban
        Dim currentTopicId As String = $"T0{currentSectionIndex}"
        Dim answeredCount As Integer = 0
        If dataPertanyaanByTopik.ContainsKey(currentTopicId) Then
            For Each q As QuestionData In dataPertanyaanByTopik(currentTopicId)
                If jawabanPengguna.ContainsKey(q.IdPertanyaan) Then
                    answeredCount += 1
                End If
            Next

            If answeredCount < dataPertanyaanByTopik(currentTopicId).Count Then
                MessageBox.Show("Harap jawab semua pertanyaan di section ini sebelum melanjutkan.", "Validasi Jawaban", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
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

            If jawabanPengguna.ContainsKey(idPertanyaan) Then
                jawabanPengguna(idPertanyaan) = jawaban
            Else
                jawabanPengguna.Add(idPertanyaan, jawaban)
            End If
        End If
    End Sub


    ' =========================================================================
    ' 4. PERHITUNGAN HASIL AKHIR (OUTPUT ARRAY)
    ' =========================================================================

    Private Sub HitungHasilPakar()
        If jawabanPengguna.Count < TOTAL_QUESTIONS Then
            MessageBox.Show($"Harap jawab semua {TOTAL_QUESTIONS} pertanyaan sebelum menghitung hasil.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim skorPerTopik As New Dictionary(Of String, Integer)
        ' Variabel OUTPUT: List of Objects yang berisi hasil skor per topik
        Dim hasilOutputArray As New List(Of HasilTopik)

        ' 1. Inisialisasi skor
        For i As Integer = 1 To TOTAL_SECTIONS
            Dim idTopik As String = $"T0{i}"
            If dataPertanyaanByTopik.ContainsKey(idTopik) Then
                skorPerTopik.Add(idTopik, 0)
            End If
        Next

        ' 2. Hitung skor per topik
        For Each topicEntry In dataPertanyaanByTopik
            Dim idTopikSaatIni As String = topicEntry.Key

            For Each q As QuestionData In topicEntry.Value
                If jawabanPengguna.ContainsKey(q.IdPertanyaan) AndAlso jawabanPengguna(q.IdPertanyaan).Equals("Iya", StringComparison.OrdinalIgnoreCase) Then
                    If skorPerTopik.ContainsKey(idTopikSaatIni) Then
                        skorPerTopik(idTopikSaatIni) += q.Bobot
                    End If
                End If
            Next
        Next

        ' 3. Konversi Dictionary ke List/Array of Objects dan Tampilkan
        Dim totalSkorGlobal As Integer = 0
        Dim hasilTeks As New System.Text.StringBuilder()

        For Each item In skorPerTopik.OrderBy(Function(kvp) kvp.Key)
            Dim result As New HasilTopik() With {
                .IdTopik = item.Key,
                .TotalSkorTopik = item.Value
            }
            hasilOutputArray.Add(result)
            totalSkorGlobal += item.Value
            hasilTeks.AppendLine($"{result.IdTopik}: {result.TotalSkorTopik}")
        Next

        MessageBox.Show($"Analisis Selesai! Total Skor Global: {totalSkorGlobal}{Environment.NewLine}{Environment.NewLine}--- Skor Rinci per Topik ---{Environment.NewLine}{hasilTeks.ToString()}", "Hasil Analisis Sistem Pakar")

        '' 4. Tentukan Rekomendasi Akhir
        'TentukanRekomendasi(hasilOutputArray)

    End Sub


    '' =========================================================================
    '' 5. PENENTUAN REKOMENDASI BERDASARKAN SKOR TOPIK
    '' =========================================================================

    'Private Sub TentukanRekomendasi(ByVal hasilSkorRinci As List(Of HasilTopik))

    '    ' Konversi List of Objects menjadi Dictionary agar mudah diakses
    '    Dim skorMap As New Dictionary(Of String, Integer)
    '    For Each hasil In hasilSkorRinci
    '        skorMap.Add(hasil.IdTopik, hasil.TotalSkorTopik)
    '    Next

    '    ' Ambil skor yang spesifik
    '    Dim skorT01 As Integer = If(skorMap.ContainsKey("T01"), skorMap("T01"), 0)
    '    Dim skorT02 As Integer = If(skorMap.ContainsKey("T02"), skorMap("T02"), 0)
    '    Dim skorT03 As Integer = If(skorMap.ContainsKey("T03"), skorMap("T03"), 0)
    '    Dim skorT04 As Integer = If(skorMap.ContainsKey("T04"), skorMap("T04"), 0)
    '    Dim skorT05 As Integer = If(skorMap.ContainsKey("T05"), skorMap("T05"), 0)

    '    Dim rekomendasiFinal As String = "Tidak ada rekomendasi spesifik yang cocok dengan aturan."

    '    ' --- ATURAN SISTEM PAKAR (Contoh) ---

    '    Dim skorTertinggi As Integer = hasilSkorRinci.Max(Function(h) h.TotalSkorTopik)
    '    Dim topikTertinggi As HasilTopik = hasilSkorRinci.First(Function(h) h.TotalSkorTopik = skorTertinggi)

    '    ' Identifikasi semua topik yang memiliki skor tertinggi (untuk kasus skor sama)
    '    Dim topikDenganSkorTertinggi = hasilSkorRinci.Where(Function(h) h.TotalSkorTopik = skorTertinggi).ToList()

    '    If skorTertinggi < 50 Then
    '        ' Aturan: Jika skor tertinggi di bawah 50 (ambang batas rendah)
    '        rekomendasiFinal = "Skor di semua topik relatif rendah. Mungkin diperlukan konsultasi mendalam untuk mengidentifikasi minat."
    '    ElseIf topikDenganSkorTertinggi.Count > 1 Then
    '        ' Aturan: Jika ada skor tertinggi ganda (misal T01 = 80, T02 = 80)
    '        Dim listTopik As New System.Text.StringBuilder()
    '        For Each t In topikDenganSkorTertinggi
    '            listTopik.Append($"{t.IdTopik}, ")
    '        Next
    '        listTopik.Length -= 2 ' Hapus koma terakhir

    '        rekomendasiFinal = $"KECENDERUNGAN GANDA: Anda memiliki kecenderungan kuat di Topik {listTopik.ToString()}. Pertimbangkan jalur karir interdisipliner atau dua fokus sekaligus."
    '    ElseIf topikTertinggi.IdTopik = "T01" Then
    '        rekomendasiFinal = $"KECENDERUNGAN UTAMA: Bidang 1 (T01). Rekomendasi: Fokus pada keahlian inti bidang 1."
    '    ElseIf topikTertinggi.IdTopik = "T02" Then
    '        rekomendasiFinal = $"KECENDERUNGAN UTAMA: Bidang 2 (T02). Rekomendasi: Fokus pada pengembangan keterampilan khusus bidang 2."
    '    ElseIf topikTertinggi.IdTopik = "T03" Then
    '        rekomendasiFinal = $"KECENDERUNGAN UTAMA: Bidang 3 (T03). Rekomendasi: Anda memiliki potensi kuat di bidang manajerial atau kepemimpinan."
    '    ElseIf topikTertinggi.IdTopik = "T04" Then
    '        rekomendasiFinal = $"KECENDERUNGAN UTAMA: Bidang 4 (T04). Rekomendasi: Fokus pada jalur karir yang membutuhkan analisis mendalam dan penelitian."
    '    ElseIf topikTertinggi.IdTopik = "T05" Then
    '        rekomendasiFinal = $"KECENDERUNGAN UTAMA: Bidang 5 (T05). Rekomendasi: Anda cocok untuk peran yang membutuhkan kreativitas dan komunikasi tinggi."
    '    End If

    '    ' Tampilkan Hasil Rekomendasi Akhir
    '    MessageBox.Show($"Kesimpulan Pakar:{Environment.NewLine}{rekomendasiFinal}", "Rekomendasi Sistem Pakar", MessageBoxButtons.OK, MessageBoxIcon.Information)

    'End Sub

End Class