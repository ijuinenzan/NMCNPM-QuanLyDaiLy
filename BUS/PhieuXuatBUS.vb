Imports DAO
Imports DTO

Public Class PhieuXuatBUS
    Public Shared Function InsertPhieuXuat(phieuXuat As PhieuXuatDTO, listChiTietPhieuXuat As List(Of ChiTietPhieuXuatDTO)) As Boolean
        If PhieuXuatDAO.CheckPhieuXuatByMaPhieuXuat(phieuXuat.MaPhieuXuat) Then
            Throw New Exception("Mã phiếu xuất đã tồn tại")
        End If
        If Not DaiLyDAO.CheckDaiLyByMaDaiLy(phieuXuat.MaDaiLy) Then
            Throw New Exception("Mã đại lý không tồn tại")
        End If
        Dim tempDaiLy = DaiLyDAO.SelectDaiLyByMaDaiLy(phieuXuat.MaDaiLy)
        If tempDaiLy.NoCuaDaiLy + phieuXuat.TongTriGia > LoaiDaiLyDAO.SelectLoaiDaiLyByMaLoaiDaiLy(tempDaiLy.MaLoaiDaiLy).NoToiDa Then
            Throw New Exception("Vi phạm quy định về nợ tối đa")
        End If
        If listChiTietPhieuXuat.Any(Function(chiTietPhieuXuat) listChiTietPhieuXuat.Where(Function(x) x.MaMatHang = chiTietPhieuXuat.MaMatHang).[Select](Function(x) x.SoLuongXuat).Sum() > MatHangBUS.SelectMatHangByMaMatHang(chiTietPhieuXuat.MaMatHang).SoLuongTon) Then
            Throw New Exception("Vi phạm quy định về số lượng tồn")
        End If
        PhieuXuatDAO.InsertPhieuXuat(phieuXuat)
        For Each chiTietPhieuXuat In listChiTietPhieuXuat
            chiTietPhieuXuat.MaChiTietPhieuXuat = ChiTietPhieuXuatDAO.GenerateNewMaChiTietPhieuXuat()
            chiTietPhieuXuat.MaPhieuXuat = phieuXuat.MaPhieuXuat
            ChiTietPhieuXuatDAO.InsertChiTietPhieuXuat(chiTietPhieuXuat)
        Next
        Return True
    End Function
    Public Shared Function SelectPhieuXuatAll() As List(Of PhieuXuatDTO)
        Return PhieuXuatDAO.SelectPhieuXuatAll()
    End Function
    Public Shared Function SelectPhieuXuatByMaPhieuXuat(maPhieuXuat As String) As PhieuXuatDTO
        Return If(Not PhieuXuatDAO.CheckPhieuXuatByMaPhieuXuat(maPhieuXuat), Nothing, PhieuXuatDAO.SelectPhieuXuatByMaPhieuXuat(maPhieuXuat))
    End Function
    Public Shared Function SelectPhieuXuatByThang(thang As DateTime) As List(Of PhieuXuatDTO)
        Return PhieuXuatDAO.SelectPhieuXuatByThang(thang)
    End Function
    Public Shared Function GenerateNewMaPhieuXuat() As String
        Return PhieuXuatDAO.GenerateNewMaPhieuXuat()
    End Function
End Class