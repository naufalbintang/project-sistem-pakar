Public Class FormOutput

    ' Pastikan Subrutin ini dideklarasikan sebagai PUBLIC
    Public Sub TampilkanHasil(ByVal Nama As String,
                              ByVal NIM As String,
                              ByVal Email As String,
                              ByVal SkorHasil As String,
                              ByVal Rekomendasi As String,
                              ByVal StatistikDetil As String)

        ' --- ISI KONTROL DENGAN DATA ---
        Me.lblNama.Text = Nama
        Me.lblNIM.Text = NIM
        Me.lblEmail.Text = Email
        Me.lblSkorHasil.Text = SkorHasil
        Me.lblRekomendasi.Text = Rekomendasi

        Dim headerStatistik As String = Environment.NewLine &
                                        "==========================================" & Environment.NewLine &
                                        "       STATISTIK POIN PER TOPIK" & Environment.NewLine &
                                        "==========================================" & Environment.NewLine

        Me.txtStatistikDetil.Text = headerStatistik & StatistikDetil

    End Sub

    Private Sub FormOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class