Namespace DTO
    Public Class PhieuThuTienDTO
        Private _maPhieuThu As String
        Private _maDaiLy As String
        Private _ngayThuTien As DateTime
        Private _soTienThu As Single
        Public Sub New(Optional maPhieuThu As String = "", Optional maDaiLy As String = "", Optional ngayThuTien As DateTime = Nothing, Optional soTienThu As Single = 0F)
            _maPhieuThu = maPhieuThu
            _maDaiLy = maDaiLy
            _ngayThuTien = ngayThuTien
            _soTienThu = soTienThu
        End Sub
        Public Property MaPhieuThu() As String
            Get
                Return _maPhieuThu
            End Get
            Set
                _maPhieuThu = value
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
        Public Property NgayThuTien() As DateTime
            Get
                Return _ngayThuTien
            End Get
            Set
                _ngayThuTien = value
            End Set
        End Property
        Public Property SoTienThu() As Single
            Get
                Return _soTienThu
            End Get
            Set
                _soTienThu = value
            End Set
        End Property
    End Class
End Namespace
