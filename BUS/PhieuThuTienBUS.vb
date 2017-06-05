Imports DAO
Imports DTO

Public Class PhieuThuTienBUS
    Public Shared Function InsertPhieuThuTien(phieuThuTien As PhieuThuTienDTO) As Boolean
        If PhieuThuTienDAO.CheckPhieuThuTienByMaPhieuThu(phieuThuTien.MaPhieuThu) Then
            Throw New Exception("Mã phiếu thu đã tồn tại")
        End If
        If Not DaiLyDAO.CheckDaiLyByMaDaiLy(phieuThuTien.MaDaiLy) Then
            Throw New Exception("Mã đại lý không tồn tại")
        End If
        Dim apDungQuyDinh4 = ParameterDAO.GetApDungQuyDinh4()
        If apDungQuyDinh4 Then
            If phieuThuTien.SoTienThu > DaiLyDAO.SelectDaiLyByMaDaiLy(phieuThuTien.MaDaiLy).NoCuaDaiLy Then
                phieuThuTien.SoTienThu = DaiLyDAO.SelectDaiLyByMaDaiLy(phieuThuTien.MaDaiLy).NoCuaDaiLy
            End If
        End If
        Return PhieuThuTienDAO.InsertPhieuThuTien(phieuThuTien)
    End Function
    Public Shared Function SelectPhieuThuTienAll() As List(Of PhieuThuTienDTO)
        Return PhieuThuTienDAO.SelectPhieuThuTienAll()
    End Function
    Public Shared Function SelectPhieuThuTienByMaPhieuThuTien(maPhieuThu As String) As PhieuThuTienDTO
        Return If(Not PhieuThuTienDAO.CheckPhieuThuTienByMaPhieuThu(maPhieuThu), Nothing, PhieuThuTienDAO.SelectPhieuThuTienByMaPhieuThu(maPhieuThu))
    End Function
    Public Shared Function GenerateNewMaPhieuThu() As String
        Return PhieuThuTienDAO.GenerateNewMaPhieuThu()
    End Function
End Class