
Public Class ChiTietPhieuXuatDTO
    Private _maChiTietPhieuXuat As String
    Private _maPhieuXuat As String
    Private _maMatHang As String
    Private _maDonViTinh As String
    Private _soLuongXuat As Integer
    Private _donGiaXuat As Single
    Private _thanhTien As Single
    Public Sub New(Optional maChiTietPhieuXuat As String = "", Optional maPhieuXuat As String = "", Optional maMatHang As String = "", Optional maDonViTinh As String = "", Optional soLuongXuat As Integer = 0, Optional donGiaXuat As Single = 0F, _
                   Optional thanhTien As Single = 0F)
        _maChiTietPhieuXuat = maChiTietPhieuXuat
        _maPhieuXuat = maPhieuXuat
        _maMatHang = maMatHang
        _maDonViTinh = maDonViTinh
        _soLuongXuat = soLuongXuat
        _donGiaXuat = donGiaXuat
        _thanhTien = thanhTien
    End Sub
    Public Property MaChiTietPhieuXuat() As String
        Get
            Return _maChiTietPhieuXuat
        End Get
        Set
            _maChiTietPhieuXuat = value
        End Set
    End Property
    Public Property MaPhieuXuat() As String
        Get
            Return _maPhieuXuat
        End Get
        Set
            _maPhieuXuat = value
        End Set
    End Property
    Public Property MaMatHang() As String
        Get
            Return _maMatHang
        End Get
        Set
            _maMatHang = value
        End Set
    End Property
    Public Property MaDonViTinh() As String
        Get
            Return _maDonViTinh
        End Get
        Set
            _maDonViTinh = value
        End Set
    End Property
    Public Property SoLuongXuat() As Integer
        Get
            Return _soLuongXuat
        End Get
        Set
            _soLuongXuat = value
        End Set
    End Property
    Public Property DonGiaXuat() As Single
        Get
            Return _donGiaXuat
        End Get
        Set
            _donGiaXuat = value
        End Set
    End Property
    Public Property ThanhTien() As Single
        Get
            Return _thanhTien
        End Get
        Set
            _thanhTien = value
        End Set
    End Property
End Class