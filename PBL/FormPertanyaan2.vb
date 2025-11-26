Public Class FormPertanyaan2
    Private Sub FormPertanyaan2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonLanjut_Click(sender As Object, e As EventArgs) Handles ButtonLanjut.Click
        Dim FormPertanyaan3 As New FormPertanyaan3()
        FormPertanyaan3.Show()
        Me.Hide()
    End Sub

    Private Sub ButtonSebelumnya_Click(sender As Object, e As EventArgs) Handles ButtonSebelumnya.Click
        Dim FormPertanyaan1 As New FormPertanyaan1()
        FormPertanyaan1.Show()
        Me.Hide()
    End Sub

End Class