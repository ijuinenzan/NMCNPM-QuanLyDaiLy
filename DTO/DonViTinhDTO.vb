
Public Class DonViTinhDTO
    Private _maDonViTinh As String
    Private _tenDonViTinh As String
    Public Sub New(Optional maDonViTinh As String = "", Optional tenDonViTinh As String = "")
        _maDonViTinh = maDonViTinh
        _tenDonViTinh = tenDonViTinh
    End Sub
    Public Property MaDonViTinh() As String
        Get
            Return _maDonViTinh
        End Get
        Set
            _maDonViTinh = value
        End Set
    End Property
    Public Property TenDonViTinh() As String
        Get
            Return _tenDonViTinh
        End Get
        Set
            _tenDonViTinh = value
        End Set
    End Property
End Class