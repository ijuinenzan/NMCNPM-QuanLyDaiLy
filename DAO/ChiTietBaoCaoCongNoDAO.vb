Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SQLite
Imports System.Linq
Imports DTO

Public Class ChiTietBaoCaoCongNoDAO
    Public Shared Function InsertChiTietBaoCaoCongNo(chiTietBaoCaoCongNo As ChiTietBaoCaoCongNoDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietBaoCaoCongNo", chiTietBaoCaoCongNo.MaChiTietBaoCaoCongNo), 
                    New SQLiteParameter("@MaBaoCaoCongNo", chiTietBaoCaoCongNo.MaBaoCaoCongNo), 
                    New SQLiteParameter("@MaDaiLy", chiTietBaoCaoCongNo.MaDaiLy), 
                    New SQLiteParameter("@NoDau", chiTietBaoCaoCongNo.NoDau), 
                    New SQLiteParameter("@NoPhatSinh", chiTietBaoCaoCongNo.NoPhatSinh), 
                    New SQLiteParameter("@NoCuoi", chiTietBaoCaoCongNo.NoCuoi) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Insert into ChiTietBaoCaoCongNo values(@MaChiTietBaoCaoCongNo, @MaBaoCaoCongNo, @MaDaiLy, @NoDau, @NoPhatSinh, @NoCuoi, 1)", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function UpdateChiTietBaoCaoCongNo(chiTietBaoCaoCongNo As ChiTietBaoCaoCongNoDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietBaoCaoCongNo", chiTietBaoCaoCongNo.MaChiTietBaoCaoCongNo), 
                    New SQLiteParameter("@MaBaoCaoCongNo", chiTietBaoCaoCongNo.MaBaoCaoCongNo), 
                    New SQLiteParameter("@MaDaiLy", chiTietBaoCaoCongNo.MaDaiLy), 
                    New SQLiteParameter("@NoDau", chiTietBaoCaoCongNo.NoDau), 
                    New SQLiteParameter("@NoPhatSinh", chiTietBaoCaoCongNo.NoPhatSinh), 
                    New SQLiteParameter("@NoCuoi", chiTietBaoCaoCongNo.NoCuoi) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update ChiTietBaoCaoCongNo Set MaBaoCaoCongNo = @MaBaoCaoCongNo, MaDaiLy = @MaDaiLy, NoDau = @NoDau, NoPhatSinh = @NoPhatSinh, NoCuoi = @NoCuoi where MaChiTietBaoCaoCongNo = @MaChiTietBaoCaoCongNo and IsAvailable = 1", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function DeleteChiTietBaoCaoCongNoByMaChiTietBaoCaoCongNo(maChiTietBaoCaoCongNo As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietBaoCaoCongNo", maChiTietBaoCaoCongNo) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update ChiTietBaoCaoCongNo Set IsAvailable = 0 Where MaChiTietBaoCaoCongNo = @MaChiTietBaoCaoCongNo", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function SelectChiTietBaoCaoCongNoAll() As List(Of ChiTietBaoCaoCongNoDTO)
        Dim list = New List(Of ChiTietBaoCaoCongNoDTO)()
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaChiTietBaoCaoCongNo, MaBaoCaoCongNo, MaDaiLy, NoDau, NoPhatSinh, NoCuoi From ChiTietBaoCaoCongNo Where IsAvailable = 1")
            list.AddRange(From dr In dt.Rows Select New ChiTietBaoCaoCongNoDTO() With { 
                                                                                  .MaChiTietBaoCaoCongNo = dr("MaChiTietBaoCaoCongNo").ToString(), 
                                                                                  .MaBaoCaoCongNo = dr("MaBaoCaoCongNo").ToString(), 
                                                                                  .MaDaiLy = dr("MaDaiLy").ToString(), 
                                                                                  .NoDau = Single.Parse(dr("NoDau").ToString()), 
                                                                                  .NoPhatSinh = Single.Parse(dr("NoPhatSinh").ToString()), 
                                                                                  .NoCuoi = Single.Parse(dr("NoCuoi").ToString()) 
                                                                              })
        Catch ex As Exception
        Throw ex
        End Try
        Return list
    End Function
    Public Shared Function SelectChiTietBaoCaoCongNoByMaChiTietBaoCaoCongNo(maChiTietBaoCaoCongNo As String) As ChiTietBaoCaoCongNoDTO
        Dim chiTietBaoCaoCongNo = New ChiTietBaoCaoCongNoDTO()
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietBaoCaoCongNo", maChiTietBaoCaoCongNo) 
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaChiTietBaoCaoCongNo, MaBaoCaoCongNo, MaDaiLy, NoDau, NoPhatSinh, NoCuoi From ChiTietBaoCaoCongNo Where MaChiTietBaoCaoCongNo = @MaChiTietBaoCaoCongNo and IsAvailable = 1", parameters)
            Dim dr = dt.Rows(0)
            chiTietBaoCaoCongNo.MaChiTietBaoCaoCongNo = dr("MaChiTietBaoCaoCongNo").ToString()
            chiTietBaoCaoCongNo.MaBaoCaoCongNo = dr("MaBaoCaoCongNo").ToString()
            chiTietBaoCaoCongNo.MaDaiLy = dr("MaMatHang").ToString()
            chiTietBaoCaoCongNo.NoDau = Single.Parse(dr("MaDonViTinh").ToString())
            chiTietBaoCaoCongNo.NoPhatSinh = Single.Parse(dr("DonGiaXuat").ToString())
            chiTietBaoCaoCongNo.NoCuoi = Single.Parse(dr("SoLuongXuat").ToString())
        Catch ex As Exception
            Throw ex
        End Try
        Return chiTietBaoCaoCongNo
    End Function
    Public Shared Function CheckChiTietBaoCaoCongNoByMaChiTietBaoCaoCongNo(maChiTietBaoCaoCongNo As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietBaoCaoCongNo", maChiTietBaoCaoCongNo) 
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaChiTietBaoCaoCongNo From ChiTietBaoCaoCongNo where MaChiTietBaoCaoCongNo = @MaChiTietBaoCaoCongNo and IsAvailable = 1", parameters)
            If dt.Rows.Count = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function GenerateNewMaChiTietBaoCaoCongNo() As String
        Dim newMaChiTietBaoCaoCongNo = 0
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MAX(CAST(REPLACE(MaChiTietBaoCaoCongNo , 'CCN', '') as int)) + 1 as NewMaChiTietBaoCaoCongNo from ChiTietBaoCaoCongNo")
            newMaChiTietBaoCaoCongNo = If(dt.Rows(0)("NewMaChiTietBaoCaoCongNo").ToString() = "", 1, Integer.Parse(dt.Rows(0)("NewMaChiTietBaoCaoCongNo").ToString()))
        Catch ex As Exception
            Throw ex
        End Try
        Return String.Format("CCN{0:000}", newMaChiTietBaoCaoCongNo)
    End Function
End Class