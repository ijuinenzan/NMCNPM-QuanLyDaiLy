Imports System.Data.SQLite
Imports DTO

Public Class ChiTietBaoCaoDoanhSoDAO
    Public Shared Function InsertChiTietBaoCaoDoanhSo(chiTietBaoCaoDoanhSo As ChiTietBaoCaoDoanhSoDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietBaoCaoDoanhSo", chiTietBaoCaoDoanhSo.MaChiTietBaoCaoDoanhSo), 
                    New SQLiteParameter("@MaBaoCaoDoanhSo", chiTietBaoCaoDoanhSo.MaBaoCaoDoanhSo), 
                    New SQLiteParameter("@MaDaiLy", chiTietBaoCaoDoanhSo.MaDaiLy), 
                    New SQLiteParameter("@SoPhieuXuat", chiTietBaoCaoDoanhSo.SoPhieuXuat), 
                    New SQLiteParameter("@TongTriGia", chiTietBaoCaoDoanhSo.TongTriGia), 
                    New SQLiteParameter("@TyLe", chiTietBaoCaoDoanhSo.TyLe) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Insert into ChiTietBaoCaoDoanhSo values(@MaChiTietBaoCaoDoanhSo, @MaBaoCaoDoanhSo, @MaDaiLy, @SoPhieuXuat, @TongTriGia, @TyLe, 1)", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function UpdateChiTietBaoCaoDoanhSo(chiTietBaoCaoDoanhSo As ChiTietBaoCaoDoanhSoDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietBaoCaoDoanhSo", chiTietBaoCaoDoanhSo.MaChiTietBaoCaoDoanhSo), 
                    New SQLiteParameter("@MaBaoCaoDoanhSo", chiTietBaoCaoDoanhSo.MaBaoCaoDoanhSo), 
                    New SQLiteParameter("@MaDaiLy", chiTietBaoCaoDoanhSo.MaDaiLy), 
                    New SQLiteParameter("@SoPhieuXuat", chiTietBaoCaoDoanhSo.SoPhieuXuat), 
                    New SQLiteParameter("@TongTriGia", chiTietBaoCaoDoanhSo.TongTriGia), 
                    New SQLiteParameter("@TyLe", chiTietBaoCaoDoanhSo.TyLe) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update ChiTietBaoCaoDoanhSo Set MaBaoCaoDoanhSo = @MaBaoCaoDoanhSo, MaDaiLy = @MaDaiLy, SoPhieuXuat = @SoPhieuXuat, TongTriGia = @TongTriGia, TyLe = @TyLe where MaChiTietBaoCaoDoanhSo = @MaChiTietBaoCaoDoanhSo and IsAvailable = 1", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function DeleteChiTietBaoCaoDoanhSoByMaChiTietBaoCaoDoanhSo(maChiTietBaoCaoDoanhSo As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietBaoCaoDoanhSo", maChiTietBaoCaoDoanhSo) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update ChiTietBaoCaoDoanhSo Set IsAvailable = 0 Where MaChiTietBaoCaoDoanhSo = @MaChiTietBaoCaoDoanhSo", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function SelectChiTietBaoCaoDoanhSoAll() As List(Of ChiTietBaoCaoDoanhSoDTO)
        Dim list = New List(Of ChiTietBaoCaoDoanhSoDTO)()
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaChiTietBaoCaoDoanhSo, MaBaoCaoDoanhSo, MaDaiLy, SoPhieuXuat, TongTriGia, TyLe From ChiTietBaoCaoDoanhSo Where IsAvailable = 1")
            list.AddRange(From dr In dt.Rows Select New ChiTietBaoCaoDoanhSoDTO() With { 
                             .MaChiTietBaoCaoDoanhSo = dr("MaChiTietBaoCaoDoanhSo").ToString(), 
                             .MaBaoCaoDoanhSo = dr("MaBaoCaoDoanhSo").ToString(), 
                             .MaDaiLy = dr("MaDaiLy").ToString(), 
                             .SoPhieuXuat = Integer.Parse(dr("SoPhieuXuat").ToString()), 
                             .TongTriGia = Single.Parse(dr("TongTriGia").ToString()), 
                             .TyLe = Single.Parse(dr("TyLe").ToString()) 
                             })
        Catch ex As Exception
            Throw ex
        End Try
        Return list
    End Function
    Public Shared Function SelectChiTietBaoCaoDoanhSoByMaChiTietBaoCaoDoanhSo(maChiTietBaoCaoDoanhSo As String) As ChiTietBaoCaoDoanhSoDTO
        Dim chiTietBaoCaoDoanhSo = New ChiTietBaoCaoDoanhSoDTO()
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietBaoCaoDoanhSo", maChiTietBaoCaoDoanhSo) 
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaChiTietBaoCaoDoanhSo, MaBaoCaoDoanhSo, MaDaiLy, SoPhieuXuat, TongTriGia, TyLe From ChiTietBaoCaoDoanhSo Where MaChiTietBaoCaoDoanhSo = @MaChiTietBaoCaoDoanhSo and IsAvailable = 1", parameters)
            Dim dr = dt.Rows(0)
            chiTietBaoCaoDoanhSo.MaChiTietBaoCaoDoanhSo = dr("MaChiTietBaoCaoDoanhSo").ToString()
            chiTietBaoCaoDoanhSo.MaBaoCaoDoanhSo = dr("MaBaoCaoDoanhSo").ToString()
            chiTietBaoCaoDoanhSo.MaDaiLy = dr("MaMatHang").ToString()
            chiTietBaoCaoDoanhSo.SoPhieuXuat = Integer.Parse(dr("MaDonViTinh").ToString())
            chiTietBaoCaoDoanhSo.TongTriGia = Single.Parse(dr("DonGiaXuat").ToString())
            chiTietBaoCaoDoanhSo.TyLe = Single.Parse(dr("SoLuongXuat").ToString())
        Catch ex As Exception
            Throw ex
        End Try
        Return chiTietBaoCaoDoanhSo
    End Function
    Public Shared Function CheckChiTietBaoCaoDoanhSoByMaChiTietBaoCaoDoanhSo(maChiTietBaoCaoDoanhSo As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaChiTietBaoCaoDoanhSo", maChiTietBaoCaoDoanhSo) 
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaChiTietBaoCaoDoanhSo From ChiTietBaoCaoDoanhSo where MaChiTietBaoCaoDoanhSo = @MaChiTietBaoCaoDoanhSo and IsAvailable = 1", parameters)
            If dt.Rows.Count = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function GenerateNewMaChiTietBaoCaoDoanhSo() As String
        Dim newMaChiTietBaoCaoDoanhSo = 0
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MAX(CAST(REPLACE(MaChiTietBaoCaoDoanhSo , 'CDS', '') as int)) + 1 as NewMaChiTietBaoCaoDoanhSo from ChiTietBaoCaoDoanhSo")
            newMaChiTietBaoCaoDoanhSo = If(dt.Rows(0)("NewMaChiTietBaoCaoDoanhSo").ToString() = "", 1, Integer.Parse(dt.Rows(0)("NewMaChiTietBaoCaoDoanhSo").ToString()))
        Catch ex As Exception
            Throw ex
        End Try
        Return String.Format("CDS{0:000}", newMaChiTietBaoCaoDoanhSo)
    End Function
End Class