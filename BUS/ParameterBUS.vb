Imports DAO

Public Class ParameterBUS
    Public Shared Function UpdateSoDaiLyToiDa(soDaiLyToiDa As Integer) As Boolean
        Return ParameterDAO.UpdateSoDaiLyToiDa(soDaiLyToiDa)
    End Function
    Public Shared Function UpdateApDungQuyDinh4(apDungQuyDinh4 As Boolean) As Boolean
        Return ParameterDAO.UpdateApDungQuyDinh4(apDungQuyDinh4)
    End Function
    Public Shared Function GetSoDaiLyToiDa() As Integer
        Return ParameterDAO.GetSoDaiLyToiDa()
    End Function
    Public Shared Function GetApDungQuyDinh4() As Boolean
        Return ParameterDAO.GetApDungQuyDinh4()
    End Function
End Class