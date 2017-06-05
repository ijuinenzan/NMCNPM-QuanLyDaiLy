Imports DAO
Imports DTO

Public Class BaoCaoDoanhSoBUS
    Public Shared Function InsertBaoCaoDoanhSo(baoCaoDoanhSo As BaoCaoDoanhSoDTO, listChiTietBaoCaoDoanhSo As List(Of ChiTietBaoCaoDoanhSoDTO)) As Boolean
        If BaoCaoDoanhSoDAO.CheckBaoCaoDoanhSoByMaBaoCaoDoanhSo(baoCaoDoanhSo.MaBaoCaoDoanhSo) Then
            Throw New Exception("Mã phiếu xuất đã tồn tại")
        End If
        If listChiTietBaoCaoDoanhSo.Any(Function(chiTietBaoCaoDoanhSo) Not DaiLyDAO.CheckDaiLyByMaDaiLy(chiTietBaoCaoDoanhSo.MaDaiLy)) Then
            Throw New Exception("Mã đại lý không tồn tại")
        End If
        BaoCaoDoanhSoDAO.InsertBaoCaoDoanhSo(baoCaoDoanhSo)
        For Each chiTietBaoCaoDoanhSo In listChiTietBaoCaoDoanhSo
            chiTietBaoCaoDoanhSo.MaChiTietBaoCaoDoanhSo = ChiTietBaoCaoDoanhSoDAO.GenerateNewMaChiTietBaoCaoDoanhSo()
            chiTietBaoCaoDoanhSo.MaBaoCaoDoanhSo = baoCaoDoanhSo.MaBaoCaoDoanhSo
            ChiTietBaoCaoDoanhSoDAO.InsertChiTietBaoCaoDoanhSo(chiTietBaoCaoDoanhSo)
        Next
        Return True
    End Function
    Public Shared Function SelectBaoCaoDoanhSoAll() As List(Of BaoCaoDoanhSoDTO)
        Return BaoCaoDoanhSoDAO.SelectBaoCaoDoanhSoAll()
    End Function
    Public Shared Function SelectBaoCaoDoanhSoByMaBaoCaoDoanhSo(maBaoCaoDoanhSo As String) As BaoCaoDoanhSoDTO
        Return If(Not BaoCaoDoanhSoDAO.CheckBaoCaoDoanhSoByMaBaoCaoDoanhSo(maBaoCaoDoanhSo), Nothing, BaoCaoDoanhSoDAO.SelectBaoCaoDoanhSoByMaBaoCaoDoanhSo(maBaoCaoDoanhSo))
    End Function
    Public Shared Function GenerateNewMaBaoCaoDoanhSo() As String
        Return BaoCaoDoanhSoDAO.GenerateNewMaBaoCaoDoanhSo()
    End Function
End Class