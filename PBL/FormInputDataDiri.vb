Public Class FormInputDataDiri
    Private Sub FormInputDataDiri_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Input Data Diri Mahasiswa"
    End Sub

    Private Sub ButtonSimpan_click(sender As Object, e As EventArgs) Handles ButtonSimpan.Click
        Dim nim As String = TextBoxNIM.Text
        Dim nama As String = TextBoxNama.Text
        Dim email As String = TextBoxEmail.Text
        Dim noHp As String = TextBoxHP.Text

        If String.IsNullOrEmpty(nim) OrElse String.IsNullOrEmpty(nama) OrElse String.IsNullOrEmpty(email) OrElse String.IsNullOrEmpty(noHp) Then
            MessageBox.Show("Semua field harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim hasilinput As String
        hasilinput = "Data Diri Mahasiswa" & Environment.NewLine & Environment.NewLine &
                      "NIM   : " & nim & Environment.NewLine &
                      "Nama  : " & nama & Environment.NewLine &
                      "Email : " & email & Environment.NewLine &
                      "No HP : " & noHp

        MessageBox.Show(hasilinput, "Konfirmasi Input", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim FormPertanyaan1 As New FormPertanyaan1()
        FormPertanyaan1.Show()
        Me.Hide()
    End Sub


End Class
