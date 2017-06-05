Namespace DTO
    Public Class MatHangDTO
        Private _maMatHang As String
        Private _tenMatHang As String
        Private _soLuongTon As Integer
        Public Sub New(Optional maMatHang As String = "", Optional tenMatHang As String = "", Optional maDonViTinh As String = "", Optional donGia As Single = 0F, Optional soLuongTon As Integer = 0)
            _maMatHang = maMatHang
            _tenMatHang = tenMatHang
            _soLuongTon = soLuongTon
        End Sub
        Public Property MaMatHang() As String
            Get
                Return _maMatHang
            End Get
            Set
                _maMatHang = value
            End Set
        End Property
        Public Property TenMatHang() As String
            Get
                Return _tenMatHang
            End Get
            Set
                _tenMatHang = value
            End Set
        End Property
        Public Property SoLuongTon() As Integer
            Get
                Return _soLuongTon
            End Get
            Set
                _soLuongTon = value
            End Set
        End Property
    End Class
End Namespace
