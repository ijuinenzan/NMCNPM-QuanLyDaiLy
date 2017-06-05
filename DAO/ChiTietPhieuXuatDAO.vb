Imports System.Data.SQLite
Imports DTO

Public Class ChiTietPhieuXuatDAO
    Public Shared Function InsertChiTietPhieuXuat(chiTietPhieuXuat As ChiTietPhieuXuatDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietPhieuXuat", chiTietPhieuXuat.MaChiTietPhieuXuat), 
                    New SQLiteParameter("@MaPhieuXuat", chiTietPhieuXuat.MaPhieuXuat), 
                    New SQLiteParameter("@MaMatHang", chiTietPhieuXuat.MaMatHang), 
                    New SQLiteParameter("@MaDonViTinh", chiTietPhieuXuat.MaDonViTinh), 
                    New SQLiteParameter("@SoLuongXuat", chiTietPhieuXuat.SoLuongXuat), 
                    New SQLiteParameter("@DonGiaXuat", chiTietPhieuXuat.DonGiaXuat), 
                    New SQLiteParameter("@ThanhTien", chiTietPhieuXuat.ThanhTien) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Insert into ChiTietPhieuXuat values(@MaChiTietPhieuXuat, @MaPhieuXuat, @MaMatHang, @MaDonViTinh, @SoLuongXuat, @DonGiaXuat, @ThanhTien, 1)", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function UpdateChiTietPhieuXuat(chiTietPhieuXuat As ChiTietPhieuXuatDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietPhieuXuat", chiTietPhieuXuat.MaChiTietPhieuXuat), 
                    New SQLiteParameter("@MaPhieuXuat", chiTietPhieuXuat.MaPhieuXuat), 
                    New SQLiteParameter("@MaMatHang", chiTietPhieuXuat.MaMatHang), 
                    New SQLiteParameter("@MaDonViTinh", chiTietPhieuXuat.MaDonViTinh), 
                    New SQLiteParameter("@SoLuongXuat", chiTietPhieuXuat.SoLuongXuat), 
                    New SQLiteParameter("@DonGiaXuat", chiTietPhieuXuat.DonGiaXuat), 
                    New SQLiteParameter("@ThanhTien", chiTietPhieuXuat.ThanhTien) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update ChiTietPhieuXuat Set MaPhieuXuat = @MaPhieuXuat, MaMatHang = @MaMatHang, MaDonViTinh = @MaDonViTinh, SoLuongXuat = @SoLuongXuat, DonGiaXuat = @DonGiaXuat, ThanhTien = @ThanhTien where MaChiTietPhieuXuat = @MaChiTietPhieuXuat and IsAvailable = 1", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function DeleteChiTietPhieuXuatByMaChiTietPhieuXuat(maChiTietPhieuXuat As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietPhieuXuat", maChiTietPhieuXuat) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update ChiTietPhieuXuat Set IsAvailable = 0 Where MaChiTietPhieuXuat = @MaChiTietPhieuXuat", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function SelectChiTietPhieuXuatAll() As List(Of ChiTietPhieuXuatDTO)
        Dim list = New List(Of ChiTietPhieuXuatDTO)()
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaChiTietPhieuXuat, MaPhieuXuat, MaMatHang, MaDonViTinh, SoLuongXuat, DonGiaXuat, ThanhTien From ChiTietPhieuXuat Where IsAvailable = 1")
            list.AddRange(From dr In dt.Rows Select New ChiTietPhieuXuatDTO() With { 
                                                                               .MaChiTietPhieuXuat = dr("MaChiTietPhieuXuat").ToString(), 
                                                                               .MaPhieuXuat = dr("MaPhieuXuat").ToString(), 
                                                                               .MaMatHang = dr("MaMatHang").ToString(), 
                                                                               .MaDonViTinh = dr("MaDonViTinh").ToString(), 
                                                                               .DonGiaXuat = Single.Parse(dr("DonGiaXuat").ToString()), 
                                                                               .SoLuongXuat = Integer.Parse(dr("SoLuongXuat").ToString()), 
                                                                               .ThanhTien = Single.Parse(dr("ThanhTien").ToString()) 
                                                                           })
        Catch ex As Exception
        Throw ex
        End Try
        Return list
    End Function
    Public Shared Function SelectChiTietPhieuXuatByMaChiTietPhieuXuat(maChiTietPhieuXuat As String) As ChiTietPhieuXuatDTO
        Dim chiTietPhieuXuat = New ChiTietPhieuXuatDTO()
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietPhieuXuat", maChiTietPhieuXuat) 
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaChiTietPhieuXuat, TenChiTietPhieuXuat, MaLoaiChiTietPhieuXuat, SoDienThoai, DiaChi, MaQuan, NgayTiepNhan, Email, NoCuaChiTietPhieuXuat From ChiTietPhieuXuat Where MaChiTietPhieuXuat = @MaChiTietPhieuXuat and IsAvailable = 1", parameters)
            Dim dr = dt.Rows(0)
            chiTietPhieuXuat.MaChiTietPhieuXuat = dr("MaChiTietPhieuXuat").ToString()
            chiTietPhieuXuat.MaPhieuXuat = dr("MaPhieuXuat").ToString()
            chiTietPhieuXuat.MaMatHang = dr("MaMatHang").ToString()
            chiTietPhieuXuat.MaDonViTinh = dr("MaDonViTinh").ToString()
            chiTietPhieuXuat.DonGiaXuat = Single.Parse(dr("DonGiaXuat").ToString())
            chiTietPhieuXuat.SoLuongXuat = Integer.Parse(dr("SoLuongXuat").ToString())
            chiTietPhieuXuat.ThanhTien = Single.Parse(dr("ThanhTien").ToString())
        Catch ex As Exception
            Throw ex
        End Try
        Return chiTietPhieuXuat
    End Function
    Public Shared Function CheckChiTietPhieuXuatByMaChiTietPhieuXuat(maChiTietPhieuXuat As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietPhieuXuat", maChiTietPhieuXuat) 
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaChiTietPhieuXuat From ChiTietPhieuXuat where MaChiTietPhieuXuat = @MaChiTietPhieuXuat and IsAvailable = 1", parameters)
            If dt.Rows.Count = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function GenerateNewMaChiTietPhieuXuat() As String
        Dim newMaChiTietPhieuXuat = 0
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MAX(CAST(REPLACE(MaChiTietPhieuXuat , 'CTX', '') as int)) + 1 as NewMaChiTietPhieuXuat from ChiTietPhieuXuat")
            newMaChiTietPhieuXuat = If(dt.Rows(0)("NewMaChiTietPhieuXuat").ToString() = "", 1, Integer.Parse(dt.Rows(0)("NewMaChiTietPhieuXuat").ToString()))
        Catch ex As Exception
            Throw ex
        End Try
        Return String.Format("CTX{0:000}", newMaChiTietPhieuXuat)
    End Function
End Class