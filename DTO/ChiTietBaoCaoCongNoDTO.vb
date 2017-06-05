
Public Class ChiTietBaoCaoCongNoDTO
    Private _maChiTietBaoCaoCongNo As String
    Private _maBaoCaoCongNo As String
    Private _maDaiLy As String
    Private _noDau As Single
    Private _noPhatSinh As Single
    Private _noCuoi As Single
    Public Sub New(Optional maChiTietBaoCaoCongNo As String = "", Optional maBaoCaoCongNo As String = "", Optional maDaiLy As String = "", Optional noDau As Single = 0F, Optional noPhatSinh As Single = 0F, Optional noCuoi As Single = 0F)
        _maChiTietBaoCaoCongNo = maChiTietBaoCaoCongNo
        _maBaoCaoCongNo = maBaoCaoCongNo
        _maDaiLy = maDaiLy
        _noDau = noDau
        _noPhatSinh = noPhatSinh
        _noCuoi = noCuoi
    End Sub
    Public Property MaChiTietBaoCaoCongNo() As String
        Get
            Return _maChiTietBaoCaoCongNo
        End Get
        Set
            _maChiTietBaoCaoCongNo = value
        End Set
    End Property
    Public Property MaBaoCaoCongNo() As String
        Get
            Return _maBaoCaoCongNo
        End Get
        Set
            _maBaoCaoCongNo = value
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
    Public Property NoDau() As Single
        Get
            Return _noDau
        End Get
        Set
            _noDau = value
        End Set
    End Property
    Public Property NoPhatSinh() As Single
        Get
            Return _noPhatSinh
        End Get
        Set
            _noPhatSinh = value
        End Set
    End Property
    Public Property NoCuoi() As Single
        Get
            Return _noCuoi
        End Get
        Set
            _noCuoi = value
        End Set
    End Property
End Class