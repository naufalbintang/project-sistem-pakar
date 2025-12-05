Imports System.Data.SqlClient

Module ModuleDB
    Public ReadOnly Property connectionString As String
        Get
            Return "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SistemPakar.mdf;Integrated Security=True"
        End Get
    End Property

    Public Function getConnection() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function
End Module
