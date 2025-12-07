Module ModuleInference

    ' struktur data soal
    Public Class QuestionData
        Public Property IdPertanyaan As String
        Public Property TeksPertanyaan As String
        Public Property Bobot As Integer
        Public Property IdTopik As String
    End Class

    ' mesin inferensi
    Public Function HitungSkor(ByVal listSoal As List(Of QuestionData), ByVal jawabanUser() As Integer) As Dictionary(Of String, Integer)

        ' wadah skor
        Dim hasilSkor As New Dictionary(Of String, Integer)
        hasilSkor.Add("T01", 0) 'Rekayasa Perangkat Lunak
        hasilSkor.Add("T02", 0) 'AI dan Data Science
        hasilSkor.Add("T03", 0) 'Network dan Security
        hasilSkor.Add("T04", 0) 'Internet Of Things dan Robotika
        hasilSkor.Add("T05", 0) 'Multimedia dan Game Development

        ' looping soal
        For i As Integer = 0 To listSoal.Count - 1
            Dim jawaban As Integer = jawabanUser(i)

            ' jika user menjawab iya, maka
            If jawaban = 1 Then
                Dim dataSoal As QuestionData = listSoal(i)

                ' tambahin bobot ke topik yang sesuai
                If hasilSkor.ContainsKey(dataSoal.IdTopik) Then
                    hasilSkor(dataSoal.IdTopik) += dataSoal.Bobot
                End If
            End If
        Next
        Return hasilSkor
    End Function

    ' translate kode ke nama jurusan
    Public Function GetNamaTopik(kode As String) As String
        Select Case kode
            Case "T01" : Return "Rekayasa Perangkat Lunak"
            Case "T02" : Return "AI & Data Science"
            Case "T03" : Return "Network & Security"
            Case "T04" : Return "IoT & Robotika"
            Case "T05" : Return "Multimedia & Game"
            Case Else : Return "Lainnya"
        End Select
    End Function
End Module
