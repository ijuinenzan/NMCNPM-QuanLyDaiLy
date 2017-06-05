Namespace DTO
    Public Class QuanDTO
        Private _maQuan As String
        Private _tenQuan As String
        Private _soDaiLyHienTai As Integer
        Public Sub New(Optional maQuan As String = "", Optional tenQuan As String = "")
            _maQuan = maQuan
            _tenQuan = tenQuan
        End Sub
        Public Property MaQuan() As String
            Get
                Return _maQuan
            End Get
            Set
                _maQuan = value
            End Set
        End Property
        Public Property TenQuan() As String
            Get
                Return _tenQuan
            End Get
            Set
                _tenQuan = value
            End Set
        End Property
        Public Property SoDaiLyHienTai() As Integer
            Get
                Return _soDaiLyHienTai
            End Get
            Set
                _soDaiLyHienTai = value
            End Set
        End Property
    End Class
End Namespace
