Imports System
Imports System.Collections.Generic
Imports DAO
Imports DAO.DAO
Imports DTO
Imports DTO.DTO

Namespace BUS
    Public Class DaiLyBUS
        Public Shared Function InsertDaiLy(daiLy As DaiLyDTO) As Boolean
            If DaiLyDAO.CheckDaiLyByMaDaiLy(daiLy.MaDaiLy) Then
                Throw New Exception("Mã đại lý đã tồn tại")
            End If
            If Not LoaiDaiLyDAO.CheckLoaiDaiLyByMaLoaiDaiLy(daiLy.MaLoaiDaiLy) Then
                Throw New Exception("Loại đại lý không tồn tại")
            End If
            If Not QuanDAO.CheckQuanByMaQuan(daiLy.MaQuan) Then
                Throw New Exception("Quận không tồn tại")
            End If
            If QuanDAO.SelectSoDaiLyHienTaiByMaQuan(daiLy.MaQuan) >= ParameterDAO.GetSoDaiLyToiDa() Then
                Throw New Exception(String.Format("Số đại lý hiện tại của {0} vượt quá số đại lý tối đa", QuanDAO.SelectQuanByMaQuan(daiLy.MaQuan).TenQuan))
            End If
            Return DaiLyDAO.InsertDaiLy(daiLy)
        End Function
        Public Shared Function UpdateDaiLy(daiLy As DaiLyDTO) As Boolean
            If Not DaiLyDAO.CheckDaiLyByMaDaiLy(daiLy.MaDaiLy) Then
                Throw New Exception("Mã đại lý không tồn tại")
            End If
            If Not LoaiDaiLyDAO.CheckLoaiDaiLyByMaLoaiDaiLy(daiLy.MaLoaiDaiLy) Then
                Throw New Exception("Loại đại lý không tồn tại")
            End If
            If Not QuanDAO.CheckQuanByMaQuan(daiLy.MaQuan) Then
                Throw New Exception("Quận không tồn tại")
            End If
            Return DaiLyDAO.UpdateDaiLy(daiLy)
        End Function
        Public Shared Function DeleteDaiLyByMaDaiLy(maDaiLy As String) As Boolean
            If Not DaiLyDAO.CheckDaiLyByMaDaiLy(maDaiLy) Then
                Throw New Exception("Mã đại lý không tồn tại")
            End If
            Return DaiLyDAO.DeleteDaiLyByMaDaiLy(maDaiLy)
        End Function
        Public Shared Function SelectDaiLyAll() As List(Of DaiLyDTO)
            Return DaiLyDAO.SelectDaiLyAll()
        End Function
        Public Shared Function SelectDaiLyByMaDaiLy(maDaiLy As String) As DaiLyDTO
            Return If(Not DaiLyDAO.CheckDaiLyByMaDaiLy(maDaiLy), Nothing, DaiLyDAO.SelectDaiLyByMaDaiLy(maDaiLy))
        End Function
        Public Shared Function GenerateNewMaDaiLy() As String
            Return DaiLyDAO.GenerateNewMaDaiLy()
        End Function
    End Class
End Namespace
