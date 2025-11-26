Public Class FormPertanyaan5
    Private Sub FormPertanyaan5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonSelesai_Click(sender As Object, e As EventArgs) Handles ButtonSelesai.Click
        Dim FormOutput As New FormOutput()
        FormOutput.Show()
        Me.Hide()
    End Sub

End Class