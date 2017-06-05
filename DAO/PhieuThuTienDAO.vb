Imports System.Data.SQLite
Imports DTO


Public Class PhieuThuTienDAO
    Public Shared Function InsertPhieuThuTien(phieuThuTien As PhieuThuTienDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaPhieuThu", phieuThuTien.MaPhieuThu),
                    New SQLiteParameter("@MaDaiLy", phieuThuTien.MaDaiLy),
                    New SQLiteParameter("@NgayThuTien", phieuThuTien.NgayThuTien.[Date]),
                    New SQLiteParameter("@SoTienThu", phieuThuTien.SoTienThu)
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Insert into PhieuThuTien values(@MaPhieuThu, @MaDaiLy, @NgayThuTien, @SoTienThu, 1)", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function UpdatePhieuThuTien(phieuThuTien As PhieuThuTienDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaPhieuThu", phieuThuTien.MaPhieuThu),
                    New SQLiteParameter("@MaDaiLy", phieuThuTien.MaDaiLy),
                    New SQLiteParameter("@NgayThuTien", phieuThuTien.NgayThuTien.[Date]),
                    New SQLiteParameter("@SoTienThu", phieuThuTien.SoTienThu)
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update PhieuThuTien Set MaDaiLy = @MaDaiLy, NgayThuTien = @NgayThuTien, SoTienThu = @SoTienThu where MaPhieuThu = @MaPhieuThu and IsAvailable = 1", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function DeletePhieuThuTienByMaPhieuThu(maPhieuThu As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaPhieuThu", maPhieuThu)
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update PhieuThuTien Set IsAvailable = 0 Where MaPhieuThu = @MaPhieuThu", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function SelectPhieuThuTienAll() As List(Of PhieuThuTienDTO)
        Dim list = New List(Of PhieuThuTienDTO)()
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaPhieuThu, MaDaiLy, NgayThuTien, SoTienThu From PhieuThuTien Where IsAvailable = 1")
            list.AddRange(From dr In dt.Rows Select New PhieuThuTienDTO() With {
                             .MaPhieuThu = dr("MaPhieuThu").ToString(),
                             .MaDaiLy = dr("MaDaiLy").ToString(),
                             .NgayThuTien = DateTime.Parse(dr("NgayThuTien").ToString()),
                             .SoTienThu = Single.Parse(dr("SoTienThu").ToString())
                             })
        Catch ex As Exception
            Throw ex
        End Try
        Return list
    End Function
    Public Shared Function SelectPhieuThuTienByMaPhieuThu(maPhieuThu As String) As PhieuThuTienDTO
        Dim phieuThuTien = New PhieuThuTienDTO()
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaPhieuThu", maPhieuThu)
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaPhieuThu, MaDaiLy, NgayThuTien, SoTienThu From PhieuThuTien Where MaPhieuThu = @MaPhieuThu and IsAvailable = 1", parameters)
            Dim dr = dt.Rows(0)
            phieuThuTien.MaPhieuThu = dr("MaPhieuThu").ToString()
            phieuThuTien.MaDaiLy = dr("MaDaiLy").ToString()
            phieuThuTien.NgayThuTien = DateTime.Parse(dr("NgayThuTien").ToString())
            phieuThuTien.SoTienThu = Single.Parse(dr("SoTienThu").ToString())
        Catch ex As Exception
            Throw ex
        End Try
        Return phieuThuTien
    End Function
    Public Shared Function CheckPhieuThuTienByMaPhieuThu(maPhieuThu As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaPhieuThu", maPhieuThu)
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaPhieuThu From PhieuThuTien where MaPhieuThu = @MaPhieuThu and IsAvailable = 1", parameters)
            If dt.Rows.Count = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function GenerateNewMaPhieuThu() As String
        Dim newMaPhieuThu = 0
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MAX(CAST(REPLACE(MaPhieuThu , 'PTH', '') as int)) + 1 as NewMaPhieuThu from PhieuThuTien")
            newMaPhieuThu = If(dt.Rows(0)("NewMaPhieuThu").ToString() = "", 1, Integer.Parse(dt.Rows(0)("NewMaPhieuThu").ToString()))
        Catch ex As Exception
            Throw ex
        End Try
        Return String.Format("PTH{0:000}", newMaPhieuThu)
    End Function
End Class