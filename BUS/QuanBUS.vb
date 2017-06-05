Imports DAO
Imports DTO


Public Class QuanBUS
    Public Shared Function InsertQuan(quan As QuanDTO) As Boolean
        If QuanDAO.CheckQuanByMaQuan(quan.MaQuan) Then
            Throw New Exception("Mã quận đã tồn tại!")
        End If
        Return QuanDAO.InsertQuan(quan)
    End Function
    Public Shared Function UpdateQuan(quan As QuanDTO) As Boolean
        If Not QuanDAO.CheckQuanByMaQuan(quan.MaQuan) Then
            Throw New Exception("Mã quận không tồn tại")
        End If
        Return QuanDAO.UpdateQuan(quan)
    End Function
    Public Shared Function DeleteQuanByMaQuan(maQuan As String) As Boolean
        If Not QuanDAO.CheckQuanByMaQuan(maQuan) Then
            Throw New Exception("Mã quận không tồn tại")
        End If
        If QuanDAO.SelectQuanByMaQuan(maQuan).SoDaiLyHienTai > 0 Then
            Throw New Exception("Không thể xóa quận có đại lý")
        End If
        Return QuanDAO.DeleteQuanByMaQuan(maQuan)
    End Function
    Public Shared Function SelectQuanAll() As List(Of QuanDTO)
        Return QuanDAO.SelectQuanAll()
    End Function
    Public Shared Function SelectQuanByMaQuan(maQuan As String) As QuanDTO
        Return QuanDAO.SelectQuanByMaQuan(maQuan)
    End Function
    Public Shared Function GenerateNewMaQuan() As String
        Return QuanDAO.GenerateNewMaQuan()
    End Function
End Class