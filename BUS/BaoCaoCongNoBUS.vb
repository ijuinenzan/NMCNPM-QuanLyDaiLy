Imports DAO
Imports DTO

Public Class BaoCaoCongNoBUS
    Public Shared Function InsertBaoCaoCongNo(baoCaoCongNo As BaoCaoCongNoDTO, listChiTietBaoCaoCongNo As List(Of ChiTietBaoCaoCongNoDTO)) As Boolean
        If BaoCaoCongNoDAO.CheckBaoCaoCongNoByMaBaoCaoCongNo(baoCaoCongNo.MaBaoCaoCongNo) Then
            Throw New Exception("Mã phiếu xuất đã tồn tại")
        End If
        If listChiTietBaoCaoCongNo.Any(Function(chiTietBaoCaoCongNo) Not DaiLyDAO.CheckDaiLyByMaDaiLy(chiTietBaoCaoCongNo.MaDaiLy)) Then
            Throw New Exception("Mã đại lý không tồn tại")
        End If
        BaoCaoCongNoDAO.InsertBaoCaoCongNo(baoCaoCongNo)
        For Each chiTietBaoCaoCongNo In listChiTietBaoCaoCongNo
            chiTietBaoCaoCongNo.MaChiTietBaoCaoCongNo = ChiTietBaoCaoCongNoDAO.GenerateNewMaChiTietBaoCaoCongNo()
            chiTietBaoCaoCongNo.MaBaoCaoCongNo = baoCaoCongNo.MaBaoCaoCongNo
            ChiTietBaoCaoCongNoDAO.InsertChiTietBaoCaoCongNo(chiTietBaoCaoCongNo)
        Next
        Return True
    End Function
    Public Shared Function SelectBaoCaoCongNoAll() As List(Of BaoCaoCongNoDTO)
        Return BaoCaoCongNoDAO.SelectBaoCaoCongNoAll()
    End Function
    Public Shared Function SelectBaoCaoCongNoByMaBaoCaoCongNo(maBaoCaoCongNo As String) As BaoCaoCongNoDTO
        Return If(Not BaoCaoCongNoDAO.CheckBaoCaoCongNoByMaBaoCaoCongNo(maBaoCaoCongNo), Nothing, BaoCaoCongNoDAO.SelectBaoCaoCongNoByMaBaoCaoCongNo(maBaoCaoCongNo))
    End Function
    Public Shared Function GenerateNewMaBaoCaoCongNo() As String
        Return BaoCaoCongNoDAO.GenerateNewMaBaoCaoCongNo()
    End Function
End Class