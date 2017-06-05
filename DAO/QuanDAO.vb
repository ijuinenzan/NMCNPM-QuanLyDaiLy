Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SQLite
Imports System.Linq
Imports DTO
Imports DTO.DTO

Namespace DAO
    Public Class QuanDAO
        Public Shared Function InsertQuan(quan As QuanDTO) As Boolean
            Dim result = False
            Try
                Dim parameters = New List(Of SQLiteParameter)() From { 
                        New SQLiteParameter("@MaQuan", quan.MaQuan), 
                        New SQLiteParameter("@TenQuan", quan.TenQuan), 
                        New SQLiteParameter("@SoDaiLyHienTai", quan.SoDaiLyHienTai) 
                        }
                Dim n = DataAccessHelper.ExecuteNonQuery("Insert into Quan values(@MaQuan, @TenQuan, @SoDaiLyHienTai, 1)", parameters)
                If n = 1 Then
                    result = True
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
        Public Shared Function UpdateQuan(quan As QuanDTO) As Boolean
            Dim result = False
            Try
                Dim parameters = New List(Of SQLiteParameter)() From { 
                        New SQLiteParameter("@MaQuan", quan.MaQuan), 
                        New SQLiteParameter("@TenQuan", quan.TenQuan), 
                        New SQLiteParameter("@SoDaiLyHienTai", quan.SoDaiLyHienTai) 
                        }
                Dim n = DataAccessHelper.ExecuteNonQuery("Update Quan Set TenQuan = @TenQuan, SoDaiLyHienTai = @SoDaiLyHienTai where MaQuan = @MaQuan and IsAvailable = 1", parameters)
                If n = 1 Then
                    result = True
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
        Public Shared Function DeleteQuanByMaQuan(maQuan As String) As Boolean
            Dim result = False
            Try
                Dim parameters = New List(Of SQLiteParameter)() From { 
                        New SQLiteParameter("@MaQuan", maQuan) 
                        }
                Dim n = DataAccessHelper.ExecuteNonQuery("Update Quan Set IsAvailable = 0 Where MaQuan = @MaQuan", parameters)
                If n = 1 Then
                    result = True
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
        Public Shared Function SelectQuanAll() As List(Of QuanDTO)
            Dim list = New List(Of QuanDTO)()
            Try
                Dim dt = DataAccessHelper.ExecuteQuery("Select * from Quan where IsAvailable = 1")
                list.AddRange(From dr In dt.Rows Select New QuanDTO() With { 
                                                                       .MaQuan = dr("MaQuan").ToString(), 
                                                                       .TenQuan = dr("TenQuan").ToString(), 
                                                                       .SoDaiLyHienTai = Integer.Parse(dr("SoDaiLyHienTai").ToString())
                                                                   })
            Catch ex As Exception
            Throw ex
            End Try
            Return list
        End Function
        Public Shared Function SelectQuanByMaQuan(maQuan As String) As QuanDTO
            Dim quan = New QuanDTO()
            Try
                Dim parameters = New List(Of SQLiteParameter)() From { 
                        New SQLiteParameter("@MaQuan", maQuan) 
                        }
                Dim dt = DataAccessHelper.ExecuteQuery("Select * from Quan where MaQuan = @MaQuan and IsAvailable = 1", parameters)
                Dim dr = dt.Rows(0)
                quan.MaQuan = dr("MaQuan").ToString()
                quan.TenQuan = dr("TenQuan").ToString()
                quan.SoDaiLyHienTai = Integer.Parse(dr("SoDaiLyHienTai").ToString())
            Catch ex As Exception
                Throw ex
            End Try
            Return quan
        End Function
        Public Shared Function SelectSoDaiLyHienTaiByMaQuan(maQuan As String) As Integer
            Dim soDaiLyHienTai = 0
            Try
                Dim parameters = New List(Of SQLiteParameter)() From { 
                        New SQLiteParameter("@MaQuan", maQuan) 
                        }
                Dim dt = DataAccessHelper.ExecuteQuery("Select SoDaiLyHienTai from Quan where MaQuan = @MaQuan and IsAvailable = 1 ", parameters)
                Dim dr = dt.Rows(0)
                soDaiLyHienTai = Integer.Parse(dr("SoDaiLyHienTai").ToString())
            Catch ex As Exception
                Throw ex
            End Try
            Return soDaiLyHienTai
        End Function
        Public Shared Function CheckQuanByMaQuan(maQuan As String) As Boolean
            Dim result = False
            Try
                Dim parameters = New List(Of SQLiteParameter)() From { 
                        New SQLiteParameter("@MaQuan", maQuan) 
                        }
                Dim dt = DataAccessHelper.ExecuteQuery("Select * from Quan where MaQuan = @MaQuan and IsAvailable = 1", parameters)
                If dt.Rows.Count = 1 Then
                    result = True
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
        Public Shared Function GenerateNewMaQuan() As String
            Dim newMaQuan = 0
            Try
                Dim dt = DataAccessHelper.ExecuteQuery("Select MAX(CAST(REPLACE(MaQuan , 'QUA', '') as int)) + 1 as NewMaQuan from Quan")
                newMaQuan = If(dt.Rows(0)("NewMaQuan").ToString() = "", 1, Integer.Parse(dt.Rows(0)("NewMaQuan").ToString()))
            Catch ex As Exception
                Throw ex
            End Try
            Return String.Format("QUA{0:000}", newMaQuan)
        End Function
    End Class
End Namespace
