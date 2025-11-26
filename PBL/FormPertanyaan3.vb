Public Class FormPertanyaan3
    Private Sub FormPertanyaan3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonLanjut_Click(sender As Object, e As EventArgs) Handles ButtonLanjut.Click
        Dim FormPertanyaan4 As New FormPertanyaan4()
        FormPertanyaan4.Show()
        Me.Hide()
    End Sub

    Private Sub ButtonSebelumnya_Click(sender As Object, e As EventArgs) Handles ButtonSebelumnya.Click
        Dim FormPertanyaan2 As New FormPertanyaan2()
        FormPertanyaan2.Show()
        Me.Hide()
    End Sub

End Class