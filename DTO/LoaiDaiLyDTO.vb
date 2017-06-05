Namespace DTO
    Public Class LoaiDaiLyDTO
        Private _maLoaiDaiLy As String
        Private _tenLoaiDaiLy As String
        Private _noToiDa As Single
        Public Sub New(Optional maLoaiDaiLy As String = "", Optional tenLoaiDaiLy As String = "", Optional noToiDa As Single = 0F)
            _maLoaiDaiLy = maLoaiDaiLy
            _tenLoaiDaiLy = tenLoaiDaiLy
            _noToiDa = noToiDa
        End Sub
        Public Property MaLoaiDaiLy() As String
            Get
                Return _maLoaiDaiLy
            End Get
            Set
                _maLoaiDaiLy = value
            End Set
        End Property
        Public Property TenLoaiDaiLy() As String
            Get
                Return _tenLoaiDaiLy
            End Get
            Set
                _tenLoaiDaiLy = value
            End Set
        End Property
        Public Property NoToiDa() As Single
            Get
                Return _noToiDa
            End Get
            Set
                _noToiDa = value
            End Set
        End Property
    End Class
End Namespace
