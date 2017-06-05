Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SQLite
Imports System.Linq
Imports DTO
Imports DTO.DTO

Namespace DAO
    Public Class DaiLyDAO
        Public Shared Function InsertDaiLy(daiLy As DaiLyDTO) As Boolean
            Dim result = False
            Try
                Dim parameters = New List(Of SQLiteParameter)() From { 
                        New SQLiteParameter("@MaDaiLy", daiLy.MaDaiLy), 
                        New SQLiteParameter("@TenDaiLy", daiLy.TenDaiLy), 
                        New SQLiteParameter("@MaLoaiDaiLy", daiLy.MaLoaiDaiLy), 
                        New SQLiteParameter("@SoDienThoai", daiLy.SoDienThoai), 
                        New SQLiteParameter("@DiaChi", daiLy.DiaChi), 
                        New SQLiteParameter("@MaQuan", daiLy.MaQuan), 
                        New SQLiteParameter("@NgayTiepNhan", daiLy.NgayTiepNhan.[Date]), 
                        New SQLiteParameter("@Email", daiLy.Email) 
                        }
                Dim n = DataAccessHelper.ExecuteNonQuery("Insert into DaiLy values(@MaDaiLy, @TenDaiLy, @MaLoaiDaiLy, @SoDienThoai, @DiaChi, @MaQuan, @NgayTiepNhan, @Email, 0, 1)", parameters)
                If n = 1 Then
                    result = True
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
        Public Shared Function UpdateDaiLy(daiLy As DaiLyDTO) As Boolean
            Dim result = False
            Try
                Dim parameters = New List(Of SQLiteParameter)() From { 
                        New SQLiteParameter("@MaDaiLy", daiLy.MaDaiLy), 
                        New SQLiteParameter("@TenDaiLy", daiLy.TenDaiLy), 
                        New SQLiteParameter("@MaLoaiDaiLy", daiLy.MaLoaiDaiLy), 
                        New SQLiteParameter("@SoDienThoai", daiLy.SoDienThoai), 
                        New SQLiteParameter("@DiaChi", daiLy.DiaChi), 
                        New SQLiteParameter("@MaQuan", daiLy.MaQuan), 
                        New SQLiteParameter("@NgayTiepNhan", daiLy.NgayTiepNhan.[Date]), 
                        New SQLiteParameter("@Email", daiLy.Email) 
                        }
                Dim n = DataAccessHelper.ExecuteNonQuery("Update DaiLy Set TenDaiLy = @TenDaiLy, MaLoaiDaiLy = @MaLoaiDaiLy, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, MaQuan = @MaQuan, NgayTiepNhan = @NgayTiepNhan, Email = @Email where MaDaiLy = @MaDaiLy and IsAvailable = 1", parameters)
                If n = 1 Then
                    result = True
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
        Public Shared Function DeleteDaiLyByMaDaiLy(maDaiLy As String) As Boolean
            Dim result = False
            Try
                Dim parameters = New List(Of SQLiteParameter)() From { 
                        New SQLiteParameter("@MaDaiLy", maDaiLy) 
                        }
                Dim n = DataAccessHelper.ExecuteNonQuery("Update DaiLy Set IsAvailable = 0 Where MaDaiLy = @MaDaiLy", parameters)
                If n = 1 Then
                    result = True
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
        Public Shared Function SelectDaiLyAll() As List(Of DaiLyDTO)
            Dim list = New List(Of DaiLyDTO)()
            Try
                Dim dt = DataAccessHelper.ExecuteQuery("Select MaDaiLy, TenDaiLy, MaLoaiDaiLy, SoDienThoai, DiaChi, MaQuan, NgayTiepNhan, Email, NoCuaDaiLy From DaiLy Where IsAvailable = 1")
                list.AddRange(From dr In dt.Rows Select New DaiLyDTO() With { 
                                                                        .MaDaiLy = dr("MaDaiLy").ToString(), 
                                                                        .TenDaiLy = dr("TenDaiLy").ToString(), 
                                                                        .MaLoaiDaiLy = dr("MaLoaiDaiLy").ToString(), 
                                                                        .SoDienThoai = dr("SoDienThoai").ToString(), 
                                                                        .DiaChi = dr("DiaChi").ToString(), 
                                                                        .MaQuan = dr("MaQuan").ToString(), 
                                                                        .NgayTiepNhan = DateTime.Parse(dr("NgayTiepNhan").ToString()), 
                                                                        .Email = dr("Email").ToString(), 
                                                                        .NoCuaDaiLy = Single.Parse(dr("NoCuaDaiLy").ToString()) 
                                                                    })
            Catch ex As Exception
            Throw ex
            End Try
            Return list
        End Function
        Public Shared Function SelectDaiLyByMaDaiLy(maDaiLy As String) As DaiLyDTO
            Dim daiLy = New DaiLyDTO()
            Try
                Dim parameters = New List(Of SQLiteParameter)() From { 
                        New SQLiteParameter("@MaDaiLy", maDaiLy) 
                        }
                Dim dt = DataAccessHelper.ExecuteQuery("Select MaDaiLy, TenDaiLy, MaLoaiDaiLy, SoDienThoai, DiaChi, MaQuan, NgayTiepNhan, Email, NoCuaDaiLy From DaiLy Where MaDaiLy = @MaDaiLy and IsAvailable = 1", parameters)
                Dim dr = dt.Rows(0)
                daiLy.MaDaiLy = dr("MaDaiLy").ToString()
                daiLy.TenDaiLy = dr("TenDaiLy").ToString()
                daiLy.MaLoaiDaiLy = dr("MaLoaiDaiLy").ToString()
                daiLy.SoDienThoai = dr("SoDienThoai").ToString()
                daiLy.DiaChi = dr("DiaChi").ToString()
                daiLy.MaQuan = dr("MaQuan").ToString()
                daiLy.NgayTiepNhan = DateTime.Parse(dr("NgayTiepNhan").ToString())
                daiLy.Email = dr("Email").ToString()
                daiLy.NoCuaDaiLy = Single.Parse(dr("NoCuaDaiLy").ToString())
            Catch ex As Exception
                Throw ex
            End Try
            Return daiLy
        End Function
        Public Shared Function CheckDaiLyByMaDaiLy(maDaiLy As String) As Boolean
            Dim result = False
            Try
                Dim parameters = New List(Of SQLiteParameter)() From { 
                        New SQLiteParameter("@MaDaiLy", maDaiLy) 
                        }
                Dim dt = DataAccessHelper.ExecuteQuery("Select MaDaiLy From DaiLy where MaDaiLy = @MaDaiLy and IsAvailable = 1", parameters)
                If dt.Rows.Count = 1 Then
                    result = True
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
        Public Shared Function CountDaiLyByMaLoaiDaiLy(maLoaiDaiLy As String) As Integer
            Dim result = 0
            Try
                Dim parameters = New List(Of SQLiteParameter)() From { 
                        New SQLiteParameter("@MaLoaiDaiLy", maLoaiDaiLy) 
                        }
                Dim dt = DataAccessHelper.ExecuteQuery("Select count(MaDaiLy) As SoLuongDaiLy From DaiLy where MaLoaiDaiLy = @MaLoaiDaiLy and IsAvailable = 1", parameters)
                result = Integer.Parse(dt.Rows(0)("SoLuongDaiLy").ToString())
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
        Public Shared Function GenerateNewMaDaiLy() As String
            Dim newMaDaiLy = 0
            Try
                Dim dt = DataAccessHelper.ExecuteQuery("Select MAX(CAST(REPLACE(MaDaiLy , 'DLY', '') as int)) + 1 as NewMaDaiLy from DaiLy")
                newMaDaiLy = If(dt.Rows(0)("NewMaDaiLy").ToString() = "", 1, Integer.Parse(dt.Rows(0)("NewMaDaiLy").ToString()))
            Catch ex As Exception
                Throw ex
            End Try
            Return String.Format("DLY{0:000}", newMaDaiLy)
        End Function
    End Class
End Namespace
