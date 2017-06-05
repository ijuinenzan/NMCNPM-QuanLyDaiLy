Imports System.Data.SQLite

Public Class ParameterDAO
    Public Shared Function UpdateSoDaiLyToiDa(soDaiLyToiDa As Integer) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { _
                    New SQLiteParameter("@SoDaiLyToiDa", soDaiLyToiDa) _
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update ThamSo Set SoDaiLyToiDa = @SoDaiLyToiDa", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function UpdateApDungQuyDinh4(apDungQuyDinh4 As Boolean) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { _
                    New SQLiteParameter("@ApDungQuyDinh4", apDungQuyDinh4) _
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update ThamSo Set ApDungQuyDinh4 = @ApDungQuyDinh4", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function GetSoDaiLyToiDa() As Integer
        Dim soDaiLyToiDa = 0
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select SoDaiLyToiDa from THAMSO")
            Dim dr = dt.Rows(0)
            soDaiLyToiDa = Integer.Parse(dr("SoDaiLyToiDa").ToString())
        Catch ex As Exception
            Throw ex
        End Try
        Return soDaiLyToiDa
    End Function
    Public Shared Function GetApDungQuyDinh4() As Boolean
        Dim apDungQuyDinh4 = True
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select ApDungQuyDinh4 from THAMSO")
            Dim dr = dt.Rows(0)
            apDungQuyDinh4 = Integer.Parse(dr("ApDungQuyDinh4").ToString()) <> 0
        Catch ex As Exception
            Throw ex
        End Try
        Return apDungQuyDinh4
    End Function
End Class