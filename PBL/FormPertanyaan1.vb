Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Linq

Public Class FormPertanyaan1

    ' --- VARIABEL GLOBAL ---

    ' Mengambil struktur QuestionData dari ModuleInference
    Private allQuestionsList As New List(Of ModuleInference.QuestionData)

    ' ARRAY OUTPUT (INI YANG AKAN DIKIRIM KE MODUL)
    ' Index 0 = Jawaban Soal 1, dst. Isinya 1 atau 0.
    Private userAnswers(19) As Integer

    ' Navigasi
    Private currentSectionIndex As Integer = 1
    Private Const TOTAL_SECTIONS As Integer = 5
    Private UserNIM As String

    ' --- SETUP ---
    Public Sub New(nim As String)
        InitializeComponent()
        Me.UserNIM = nim
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.UserNIM = 2407411048 ' Ambil dari ModuleDB
    End Sub

    Private Sub FormPertanyaan1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Kuesioner Minat - NIM: " & UserNIM

        ' Pastikan Array bersih (isi 0 semua) saat mulai
        Array.Clear(userAnswers, 0, userAnswers.Length)

        LoadDataFromDatabase()
        TampilkanSection()
    End Sub

    Private Sub LoadDataFromDatabase()
        ' Urutkan P001 - P020 agar index array sinkron
        Dim query As String = "SELECT Id_pertanyaan, teks_pertanyaan, bobot_pertanyaan, Id_topik FROM Pertanyaan ORDER BY Id_pertanyaan ASC"

        Try
            Using connection As SqlConnection = ModuleDB.getConnection()
                connection.Open()
                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            ' Gunakan Class dari Module
                            Dim question As New ModuleInference.QuestionData() With {
                                .IdPertanyaan = reader("Id_pertanyaan").ToString(),
                                .TeksPertanyaan = reader("teks_pertanyaan").ToString(),
                                .Bobot = CInt(reader("bobot_pertanyaan")),
                                .IdTopik = reader("Id_topik").ToString()
                            }
                            allQuestionsList.Add(question)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message)
        End Try
    End Sub

    ' --- UI & LOGIKA INPUT 1/0 ---
    Private Sub TampilkanSection()
        PanelPertanyaan1.Controls.Clear()

        Dim startIndex As Integer = (currentSectionIndex - 1) * 4
        Dim endIndex As Integer = Math.Min(startIndex + 3, allQuestionsList.Count - 1)
        Dim currentY As Integer = 5

        For i As Integer = startIndex To endIndex
            Dim question = allQuestionsList(i)

            Dim pnl As New Panel() With {.Width = PanelPertanyaan1.Width - 40, .BorderStyle = BorderStyle.FixedSingle, .Location = New Point(10, currentY), .AutoSize = True}
            Dim lbl As New Label() With {.Text = question.TeksPertanyaan, .Location = New Point(5, 5), .Width = pnl.Width - 10, .AutoSize = True, .Font = New Font("Segoe UI", 10, FontStyle.Bold)}
            pnl.Controls.Add(lbl)

            ' RADIO BUTTON IYA (VALUE = 1)
            Dim rbYa As New RadioButton() With {.Text = "Iya", .Location = New Point(20, lbl.Bottom + 10), .AutoSize = True}

            ' RADIO BUTTON TIDAK (VALUE = 0)
            Dim rbTidak As New RadioButton() With {.Text = "Tidak", .Location = New Point(20, rbYa.Bottom + 5), .AutoSize = True}

            ' Restore Jawaban (Cek Array)
            If userAnswers(i) = 1 Then
                rbYa.Checked = True
            Else
                ' Default 0 dianggap Tidak/Belum Jawab
                ' rbTidak.Checked = True ' (Opsional: Aktifkan jika ingin default ke "Tidak")
            End If

            ' === LOGIKA PENGISIAN ARRAY ===
            Dim currentIndex As Integer = i
            AddHandler rbYa.CheckedChanged, Sub(sender, e)
                                                If rbYa.Checked Then userAnswers(currentIndex) = 1
                                            End Sub

            AddHandler rbTidak.CheckedChanged, Sub(sender, e)
                                                   If rbTidak.Checked Then userAnswers(currentIndex) = 0
                                               End Sub
            ' ==============================

            pnl.Controls.Add(rbYa)
            pnl.Controls.Add(rbTidak)

            pnl.Size = New Size(pnl.Width, rbTidak.Bottom + 10)
            PanelPertanyaan1.Controls.Add(pnl)
            currentY = pnl.Bottom + 15
        Next

        ButtonSebelum.Enabled = (currentSectionIndex > 1)
        ButtonLanjut.Text = If(currentSectionIndex = TOTAL_SECTIONS, "Selesai", "Lanjut")
    End Sub

    ' --- NAVIGASI & FINALISASI ---
    Private Sub ButtonLanjut_Click(sender As Object, e As EventArgs) Handles ButtonLanjut.Click
        If currentSectionIndex < TOTAL_SECTIONS Then
            currentSectionIndex += 1
            TampilkanSection()
        Else
            KirimKeMesinInferensi()
        End If
    End Sub

    Private Sub ButtonSebelum_Click(sender As Object, e As EventArgs) Handles ButtonSebelum.Click
        If currentSectionIndex > 1 Then
            currentSectionIndex -= 1
            TampilkanSection()
        End If
    End Sub

    ' --- AMBIL DATA AKUN DARI DATABASE ---
    Private Function AmbilDataAkun(ByVal userId As String) As Tuple(Of String, String, String)
        Dim nama As String = "N/A"
        Dim email As String = "N/A"
        Dim nim As String = userId ' NIM adalah Id_user

        Dim query As String = "SELECT nama, email FROM Akun WHERE Id_user = @UserId"

        Try
            Using connection As SqlConnection = ModuleDB.getConnection()
                connection.Open()
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@UserId", userId)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            nama = reader("nama").ToString()
                            email = reader("email").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data Akun: " & ex.Message, "Database Error")
        End Try

        ' Mengembalikan data sebagai Tuple: (Nama, NIM/Id_user, Email)
        Return New Tuple(Of String, String, String)(nama, nim, email)
    End Function


    ' --- KIRIM DATA KE MESIN INFERENSI & TAMPILKAN HASIL ---
    Private Sub KirimKeMesinInferensi()

        ' Variabel untuk Hasil
        Dim SkorHasilRingkasan As String = ""
        Dim hasilRekomendasi As String = ""
        Dim StatistikDetil As String = ""

        ' Ambil Data Akun untuk Ditampilkan di Output
        Dim dataAkun = AmbilDataAkun(Me.UserNIM)
        Dim inputNama As String = dataAkun.Item1
        Dim inputNIM As String = dataAkun.Item2
        Dim inputEmail As String = dataAkun.Item3

        ' 1. Panggil Fungsi di Module
        Dim hasilAkhir As Dictionary(Of String, Integer) = ModuleInference.HitungSkor(allQuestionsList, userAnswers)

        ' 2. Olah Hasil Balikan untuk Ditampilkan
        Dim urutan = hasilAkhir.OrderByDescending(Function(x) x.Value).ToList()

        Dim sbStatistik As New System.Text.StringBuilder()
        Dim totalSkor As Integer = 0

        ' LOOP UNTUK MEMBANGUN STATISTIK DETIL DAN MENGHITUNG TOTAL SKOR
        For Each h In urutan
            Dim namaJurusan As String = ModuleInference.GetNamaTopik(h.Key)
            sbStatistik.AppendLine($"{namaJurusan} : {h.Value} Poin")
            totalSkor += h.Value
        Next

        ' PENGISIAN VARIABEL OUTPUT (MENGATASI Perbedaan 1)
        StatistikDetil = sbStatistik.ToString()

        Dim juara = urutan(0)

        If juara.Value = 0 Then
            hasilRekomendasi = "TIDAK ADA MINAT TERDETEKSI JELAS"
        Else
            hasilRekomendasi = ModuleInference.GetNamaTopik(juara.Key).ToUpper()
        End If

        SkorHasilRingkasan = $"Skor Tertinggi: {juara.Value} Poin (Total Keseluruhan: {totalSkor})"

        ' 3. Tampilkan Hasil ke FormOutput
        Dim OutputForm As New FormOutput()

        OutputForm.TampilkanHasil(
        Nama:=inputNama,
        NIM:=inputNIM,
        Email:=inputEmail,
        SkorHasil:=SkorHasilRingkasan,
        Rekomendasi:=hasilRekomendasi,
        StatistikDetil:=StatistikDetil
    )

        OutputForm.Show()
        Me.Hide()
    End Sub

End Class