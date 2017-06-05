
Public Class ChiTietBaoCaoDoanhSoDTO
    Private _maChiTietBaoCaoDoanhSo As String
    Private _maBaoCaoDoanhSo As String
    Private _maDaiLy As String
    Private _soPhieuXuat As Integer
    Private _tongTriGia As Single
    Private _tyLe As Single
    Public Sub New(Optional maChiTietBaoCaoDoanhSo As String = "", Optional maBaoCaoDoanhSo As String = "", Optional maDaiLy As String = "", Optional soPhieuXuat As Integer = 0, Optional tongTriGia As Single = 0F, Optional tyLe As Single = 0F)
        _maChiTietBaoCaoDoanhSo = maChiTietBaoCaoDoanhSo
        _maBaoCaoDoanhSo = maBaoCaoDoanhSo
        _maDaiLy = maDaiLy
        _soPhieuXuat = soPhieuXuat
        _tongTriGia = tongTriGia
        _tyLe = tyLe
    End Sub
    Public Property MaChiTietBaoCaoDoanhSo() As String
        Get
            Return _maChiTietBaoCaoDoanhSo
        End Get
        Set
            _maChiTietBaoCaoDoanhSo = value
        End Set
    End Property
    Public Property MaBaoCaoDoanhSo() As String
        Get
            Return _maBaoCaoDoanhSo
        End Get
        Set
            _maBaoCaoDoanhSo = value
        End Set
    End Property
    Public Property MaDaiLy() As String
        Get
            Return _maDaiLy
        End Get
        Set
            _maDaiLy = value
        End Set
    End Property
    Public Property SoPhieuXuat() As Integer
        Get
            Return _soPhieuXuat
        End Get
        Set
            _soPhieuXuat = value
        End Set
    End Property
    Public Property TongTriGia() As Single
        Get
            Return _tongTriGia
        End Get
        Set
            _tongTriGia = value
        End Set
    End Property
    Public Property TyLe() As Single
        Get
            Return _tyLe
        End Get
        Set
            _tyLe = value
        End Set
    End Property
End Class