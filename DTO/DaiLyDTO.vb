Namespace DTO
    Public Class DaiLyDTO
        Private _maDaiLy As String
        Private _tenDaiLy As String
        Private _maLoaiDaiLy As String
        Private _soDienThoai As String
        Private _diaChi As String
        Private _maQuan As String
        Private _ngayTiepNhan As DateTime
        Private _email As String
        Private _noCuaDaiLy As Single
        Public Sub New(Optional maDaiLy As String = "", Optional tenDaiLy As String = "", Optional maLoaiDaiLy As String = "", Optional soDienThoai As String = "", Optional diaChi As String = "", Optional maQuan As String = "", _
                       Optional ngayTiepNhan As DateTime = Nothing, Optional email As String = "", Optional noCuaDaiLy As Single = 0F)
            _maDaiLy = maDaiLy
            _tenDaiLy = tenDaiLy
            _maLoaiDaiLy = maLoaiDaiLy
            _soDienThoai = soDienThoai
            _diaChi = diaChi
            _maQuan = maQuan
            _ngayTiepNhan = ngayTiepNhan
            _email = email
            _noCuaDaiLy = noCuaDaiLy
        End Sub
        Public Property MaDaiLy() As String
            Get
                Return _maDaiLy
            End Get
            Set
                _maDaiLy = value
            End Set
        End Property
        Public Property TenDaiLy() As String
            Get
                Return _tenDaiLy
            End Get
            Set
                _tenDaiLy = value
            End Set
        End Property
        Public Property MaLoaiDaiLy() As String
            Get
                Return _maLoaiDaiLy
            End Get
            Set
                _maLoaiDaiLy = value
            End Set
        End Property
        Public Property SoDienThoai() As String
            Get
                Return _soDienThoai
            End Get
            Set
                _soDienThoai = value
            End Set
        End Property
        Public Property DiaChi() As String
            Get
                Return _diaChi
            End Get
            Set
                _diaChi = value
            End Set
        End Property
        Public Property MaQuan() As String
            Get
                Return _maQuan
            End Get
            Set
                _maQuan = value
            End Set
        End Property
        Public Property NgayTiepNhan() As DateTime
            Get
                Return _ngayTiepNhan
            End Get
            Set
                _ngayTiepNhan = value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return _email
            End Get
            Set
                _email = value
            End Set
        End Property
        Public Property NoCuaDaiLy() As Single
            Get
                Return _noCuaDaiLy
            End Get
            Set
                _noCuaDaiLy = value
            End Set
        End Property
    End Class
End Namespace
