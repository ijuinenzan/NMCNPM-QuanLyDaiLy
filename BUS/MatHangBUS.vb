Imports DAO
Imports DTO

Public Class MatHangBUS
    Public Shared Function InsertMatHang(matHang As MatHangDTO) As Boolean
        If MatHangDAO.CheckMatHangByMaMatHang(matHang.MaMatHang) Then
            Throw New Exception("Mã mặt hàng đã tồn tại!")
        End If
        Return MatHangDAO.InsertMatHang(matHang)
    End Function
    Public Shared Function UpdateMatHang(matHang As MatHangDTO) As Boolean
        If Not MatHangDAO.CheckMatHangByMaMatHang(matHang.MaMatHang) Then
            Throw New Exception("Mã mặt hàng không tồn tại")
        End If
        Return MatHangDAO.UpdateMatHang(matHang)
    End Function
    Public Shared Function DeleteMatHangByMaMatHang(maMatHang As String) As Boolean
        If Not MatHangDAO.CheckMatHangByMaMatHang(maMatHang) Then
            Throw New Exception("Mã quận không tồn tại")
        End If
        Return MatHangDAO.DeleteMatHangByMaMatHang(maMatHang)
    End Function
    Public Shared Function SelectMatHangAll() As List(Of MatHangDTO)
        Return MatHangDAO.SelectMatHangAll()
    End Function
    Public Shared Function SelectMatHangByMaMatHang(maMatHang As String) As MatHangDTO
        Return MatHangDAO.SelectMatHangByMaMatHang(maMatHang)
    End Function
    Public Shared Function GenerateNewMaMatHang() As String
        Return MatHangDAO.GenerateNewMaMatHang()
    End Function
End Class