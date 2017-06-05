Imports DAO
Imports DTO


Public Class LoaiDaiLyBUS
    Public Shared Function InsertLoaiDaiLy(loaiDaiLy As LoaiDaiLyDTO) As Boolean
        If LoaiDaiLyDAO.CheckLoaiDaiLyByMaLoaiDaiLy(loaiDaiLy.MaLoaiDaiLy) Then
            Throw New Exception("Mã loại đại lý đã tồn tại!")
        End If
        Return LoaiDaiLyDAO.InsertLoaiDaiLy(loaiDaiLy)
    End Function
    Public Shared Function UpdateLoaiDaiLy(loaiDaiLy As LoaiDaiLyDTO) As Boolean
        If Not LoaiDaiLyDAO.CheckLoaiDaiLyByMaLoaiDaiLy(loaiDaiLy.MaLoaiDaiLy) Then
            Throw New Exception("Mã loại đại lý không tồn tại")
        End If
        Return LoaiDaiLyDAO.UpdateLoaiDaiLy(loaiDaiLy)
    End Function
    Public Shared Function DeleteLoaiDaiLyByMaLoaiDaiLy(maLoaiDaiLy As String) As Boolean
        If Not LoaiDaiLyDAO.CheckLoaiDaiLyByMaLoaiDaiLy(maLoaiDaiLy) Then
            Throw New Exception("Mã loại đại lý không tồn tại")
        End If
        If DaiLyDAO.CountDaiLyByMaLoaiDaiLy(maLoaiDaiLy) > 0 Then
            Throw New Exception("Không thể xóa loại đại lý có đại lý")
        End If
        Return LoaiDaiLyDAO.DeleteLoaiDaiLyByMaLoaiDaiLy(maLoaiDaiLy)
    End Function
    Public Shared Function SelectLoaiDaiLyAll() As List(Of LoaiDaiLyDTO)
        Return LoaiDaiLyDAO.SelectLoaiDaiLyAll()
    End Function
    Public Shared Function SelectLoaiDaiLyByMaLoaiDaiLy(maLoaiDaiLy As String) As LoaiDaiLyDTO
        Return LoaiDaiLyDAO.SelectLoaiDaiLyByMaLoaiDaiLy(maLoaiDaiLy)
    End Function
    Public Shared Function GenerateNewMaLoaiDaiLy() As String
        Return LoaiDaiLyDAO.GenerateNewMaLoaiDaiLy()
    End Function
End Class