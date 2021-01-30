Imports System.Data.Odbc

Module Module1
    Public Conn As New OdbcConnection
    Public da As New OdbcDataAdapter
    Public Ds As DataSet
    Public Rd As OdbcDataReader
    Public Cmd As OdbcCommand
    Public MyDB As String
    Public Sub Koneksi()
        MyDB = "Driver={MySQL ODBC 3.51 Driver};database=db_penjualan;server=localhost;uid=root"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        'konektornya bukan 3.51 ya? udah donload ka tapi ga bsa di odbms nya ka
    End Sub
End Module
