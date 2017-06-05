Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class DataAccessHelper
    Public Shared ReadOnly Property ConnectionString() As String
        Get
            Return My.MySettings.Default.ConnectionString()
        End Get
    End Property
    Public Shared Function ExecuteQuery(query As String, Optional parameters As List(Of SQLiteParameter) = Nothing) As DataTable
        Dim dt As New DataTable()
        Try
            Dim connect As New SQLiteConnection(ConnectionString)
            connect.Open()
            Try
                Dim ds As New DataSet()
                ds.Reset()
                Dim adapter As New SQLiteDataAdapter(query, connect)
                If parameters IsNot Nothing Then
                    adapter.SelectCommand.Parameters.AddRange(parameters.ToArray())
                End If
                adapter.Fill(ds)
                dt = ds.Tables(0)
            Catch ex As SqlException
                Throw ex
            Finally
                connect.Close()
            End Try
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function
    Public Shared Function ExecuteNonQuery(query As String, Optional parameters As List(Of SQLiteParameter) = Nothing) As Integer
        Dim n As Integer
        Try
            Dim connect As New SQLiteConnection(ConnectionString)
            connect.Open()
            Try
                Dim command = connect.CreateCommand()
                If parameters IsNot Nothing Then
                    command.Parameters.AddRange(parameters.ToArray())
                End If
                command.CommandText = query
                n = command.ExecuteNonQuery()
            Catch ex As SqlException
                Throw ex
            Finally
                connect.Close()
            End Try
        Catch ex As Exception
            Throw ex
        End Try
        Return n
    End Function
End Class