Imports DAO
Imports DTO

Public Class DonViTinhBUS
    Public Shared Function InsertDonViTinh(donViTinh As DonViTinhDTO) As Boolean
        If DonViTinhDAO.CheckDonViTinhByMaDonViTinh(donViTinh.MaDonViTinh) Then
            Throw New Exception("Mã đơn vị tính đã tồn tại!")
        End If
        Return DonViTinhDAO.InsertDonViTinh(donViTinh)
    End Function
    Public Shared Function UpdateDonViTinh(donViTinh As DonViTinhDTO) As Boolean
        If Not DonViTinhDAO.CheckDonViTinhByMaDonViTinh(donViTinh.MaDonViTinh) Then
            Throw New Exception("Mã đơn vị tính không tồn tại")
        End If
        Return DonViTinhDAO.UpdateDonViTinh(donViTinh)
    End Function
    Public Shared Function DeleteDonViTinhByMaDonViTinh(maDonViTinh As String) As Boolean
        If Not DonViTinhDAO.CheckDonViTinhByMaDonViTinh(maDonViTinh) Then
            Throw New Exception("Mã đơn vị tính không tồn tại")
        End If
        Return DonViTinhDAO.DeleteDonViTinhByMaDonViTinh(maDonViTinh)
    End Function
    Public Shared Function SelectDonViTinhAll() As List(Of DonViTinhDTO)
        Return DonViTinhDAO.SelectDonViTinhAll()
    End Function
    Public Shared Function SelectDonViTinhByMaDonViTinh(maDonViTinh As String) As DonViTinhDTO
        Return DonViTinhDAO.SelectDonViTinhByMaDonViTinh(maDonViTinh)
    End Function
    Public Shared Function GenerateNewMaDonViTinh() As String
        Return DonViTinhDAO.GenerateNewMaDonViTinh()
    End Function
End Class