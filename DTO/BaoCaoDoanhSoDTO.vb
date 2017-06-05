
Public Class BaoCaoDoanhSoDTO
    Private _maBaoCaoDoanhSo As String
    Private _thangBaoCaoDoanhSo As DateTime
    Public Sub New(Optional maBaoCaoDoanhSo As String = "", Optional thangBaoCaoDoanhSo As DateTime = Nothing)
        _maBaoCaoDoanhSo = maBaoCaoDoanhSo
        _thangBaoCaoDoanhSo = thangBaoCaoDoanhSo
    End Sub
    Public Property MaBaoCaoDoanhSo() As String
        Get
            Return _maBaoCaoDoanhSo
        End Get
        Set
            _maBaoCaoDoanhSo = value
        End Set
    End Property
    Public Property ThangBaoCaoDoanhSo() As DateTime
        Get
            Return _thangBaoCaoDoanhSo
        End Get
        Set
            _thangBaoCaoDoanhSo = value
        End Set
    End Property
End Class