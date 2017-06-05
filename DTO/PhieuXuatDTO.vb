Namespace DTO
    Public Class PhieuXuatDTO
        Private _maPhieuXuat As String
        Private _maDaiLy As String
        Private _ngayLapPhieu As DateTime
        Private _tongTriGia As Single
        Public Sub New(Optional maPhieuXuat As String = "", Optional maDaiLy As String = "", Optional ngayLapPhieu As DateTime = Nothing, Optional tongTriGia As Single = 0)
            _maPhieuXuat = maPhieuXuat
            _maDaiLy = maDaiLy
            _ngayLapPhieu = ngayLapPhieu
            _tongTriGia = tongTriGia
        End Sub
        Public Property MaPhieuXuat() As String
            Get
                Return _maPhieuXuat
            End Get
            Set
                _maPhieuXuat = value
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
        Public Property NgayLapPhieu() As DateTime
            Get
                Return _ngayLapPhieu
            End Get
            Set
                _ngayLapPhieu = value
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
    End Class
End Namespace
