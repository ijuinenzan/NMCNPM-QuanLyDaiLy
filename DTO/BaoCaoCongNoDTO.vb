Namespace DTO
    Public Class BaoCaoCongNoDTO
        Private _maBaoCaoCongNo As String
        Private _thangBaoCaoCongNo As DateTime
        Public Sub New(Optional maBaoCaoCongNo As String = "", Optional thangBaoCaoCongNo As DateTime = Nothing)
            _maBaoCaoCongNo = maBaoCaoCongNo
            _thangBaoCaoCongNo = thangBaoCaoCongNo
        End Sub
        Public Property MaBaoCaoCongNo() As String
            Get
                Return _maBaoCaoCongNo
            End Get
            Set
                _maBaoCaoCongNo = value
            End Set
        End Property
        Public Property ThangBaoCaoCongNo() As DateTime
            Get
                Return _thangBaoCaoCongNo
            End Get
            Set
                _thangBaoCaoCongNo = value
            End Set
        End Property
    End Class
End Namespace
