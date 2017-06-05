Imports System.Data.SQLite
Imports DTO


Public Class PhieuXuatDAO
    Public Shared Function InsertPhieuXuat(phieuXuat As PhieuXuatDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaPhieuXuat", phieuXuat.MaPhieuXuat),
                    New SQLiteParameter("@MaDaiLy", phieuXuat.MaDaiLy),
                    New SQLiteParameter("@NgayLapPhieu", phieuXuat.NgayLapPhieu.[Date]),
                    New SQLiteParameter("@TongTriGia", phieuXuat.TongTriGia)
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Insert into PhieuXuat values(@MaPhieuXuat, @MaDaiLy, @NgayLapPhieu, @TongTriGia, 1)", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function UpdatePhieuXuat(phieuXuat As PhieuXuatDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaPhieuXuat", phieuXuat.MaPhieuXuat),
                    New SQLiteParameter("@MaDaiLy", phieuXuat.MaDaiLy),
                    New SQLiteParameter("@NgayLapPhieu", phieuXuat.NgayLapPhieu.[Date]),
                    New SQLiteParameter("@TongTriGia", phieuXuat.TongTriGia)
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update PhieuXuat Set MaDaiLy = @MaDaiLy, NgayLapPhieu = @NgayLapPhieu, TongTriGia = @TongTriGia where MaPhieuXuat = @MaPhieuXuat and IsAvailable = 1", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function DeletePhieuXuatByMaPhieuXuat(maPhieuXuat As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaPhieuXuat", maPhieuXuat)
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update PhieuXuat Set IsAvailable = 0 Where MaPhieuXuat = @MaPhieuXuat", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function SelectPhieuXuatAll() As List(Of PhieuXuatDTO)
        Dim list = New List(Of PhieuXuatDTO)()
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaPhieuXuat, MaDaiLy, NgayLapPhieu, TongTriGia From PhieuXuat Where IsAvailable = 1")
            list.AddRange(From dr In dt.Rows Select New PhieuXuatDTO() With {
                                                                        .MaPhieuXuat = dr("MaPhieuXuat").ToString(),
                                                                        .MaDaiLy = dr("MaDaiLy").ToString(),
                                                                        .NgayLapPhieu = DateTime.Parse(dr("NgayLapPhieu").ToString()),
                                                                        .TongTriGia = Single.Parse(dr("TongTriGia").ToString())
                                                                    })
        Catch ex As Exception
            Throw ex
        End Try
        Return list
    End Function
    Public Shared Function SelectPhieuXuatByMaPhieuXuat(maPhieuXuat As String) As PhieuXuatDTO
        Dim phieuXuat = New PhieuXuatDTO()
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaPhieuXuat", maPhieuXuat)
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaPhieuXuat, MaDaiLy, NgayLapPhieu, TongTriGia From PhieuXuat Where MaPhieuXuat = @MaPhieuXuat and IsAvailable = 1", parameters)
            Dim dr = dt.Rows(0)
            phieuXuat.MaPhieuXuat = dr("MaPhieuXuat").ToString()
            phieuXuat.MaDaiLy = dr("MaDaiLy").ToString()
            phieuXuat.NgayLapPhieu = DateTime.Parse(dr("NgayLapPhieu").ToString())
            phieuXuat.TongTriGia = Single.Parse(dr("TongTriGia").ToString())
        Catch ex As Exception
            Throw ex
        End Try
        Return phieuXuat
    End Function
    Public Shared Function SelectPhieuXuatByThang(thang As DateTime) As List(Of PhieuXuatDTO)
        Dim list = New List(Of PhieuXuatDTO)()
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@Thang", thang.Month),
                    New SQLiteParameter("@Nam", thang.Year)
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaPhieuXuat, MaDaiLy, NgayLapPhieu, TongTriGia From PhieuXuat where CAST(strftime('%m', NgayLapPhieu) as INTEGER) = @Thang and CAST(strftime('%Y', NgayLapPhieu) as INTEGER) = @Nam and IsAvailable = 1", parameters)
            list.AddRange(From dr In dt.Rows Select New PhieuXuatDTO() With {
                             .MaPhieuXuat = dr("MaPhieuXuat").ToString(),
                             .MaDaiLy = dr("MaDaiLy").ToString(),
                             .NgayLapPhieu = DateTime.Parse(dr("NgayLapPhieu").ToString()),
                             .TongTriGia = Single.Parse(dr("TongTriGia").ToString())
                             })
        Catch ex As Exception
            Throw ex
        End Try
        Return list
    End Function
    Public Shared Function CheckPhieuXuatByMaPhieuXuat(maPhieuXuat As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaPhieuXuat", maPhieuXuat)
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaPhieuXuat From PhieuXuat where MaPhieuXuat = @MaPhieuXuat and IsAvailable = 1", parameters)
            If dt.Rows.Count = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function GenerateNewMaPhieuXuat() As String
        Dim newMaPhieuXuat = 0
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MAX(CAST(REPLACE(MaPhieuXuat , 'PXU', '') as int)) + 1 as NewMaPhieuXuat from PhieuXuat")
            newMaPhieuXuat = If(dt.Rows(0)("NewMaPhieuXuat").ToString() = "", 1, Integer.Parse(dt.Rows(0)("NewMaPhieuXuat").ToString()))
        Catch ex As Exception
            Throw ex
        End Try
        Return String.Format("PXU{0:000}", newMaPhieuXuat)
    End Function
End Class