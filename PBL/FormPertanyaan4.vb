Public Class FormPertanyaan4
    Private Sub FormPertanyaan4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonLanjut_Click(sender As Object, e As EventArgs) Handles ButtonLanjut.Click
        Dim FormPertanyaan5 As New FormPertanyaan5()
        FormPertanyaan5.Show()
        Me.Hide()
    End Sub

    Private Sub ButtonSebelumnya_Click(sender As Object, e As EventArgs) Handles ButtonSebelumnya.Click
        Dim FormPertanyaan3 As New FormPertanyaan3()
        FormPertanyaan3.Show()
        Me.Hide()
    End Sub

End Class