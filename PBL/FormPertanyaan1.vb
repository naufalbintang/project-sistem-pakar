Public Class FormPertanyaan1
    Private Sub FormPertanyaan1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonLanjut_Click(sender As Object, e As EventArgs) Handles ButtonLanjut.Click
        Dim FormPertanyaan2 As New FormPertanyaan2()
        FormPertanyaan2.Show()
        Me.Hide()
    End Sub

End Class