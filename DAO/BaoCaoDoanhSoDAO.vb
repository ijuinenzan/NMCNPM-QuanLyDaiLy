Imports System.Data.SQLite
Imports DTO

Public Class BaoCaoDoanhSoDAO
    Public Shared Function InsertBaoCaoDoanhSo(baoCaoDoanhSo As BaoCaoDoanhSoDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaBaoCaoDoanhSo", baoCaoDoanhSo.MaBaoCaoDoanhSo), 
                    New SQLiteParameter("@ThangBaoCaoDoanhSo", baoCaoDoanhSo.ThangBaoCaoDoanhSo.[Date]) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Insert into BaoCaoDoanhSo values(@MaBaoCaoDoanhSo, @ThangBaoCaoDoanhSo, 1)", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function UpdateBaoCaoDoanhSo(baoCaoDoanhSo As BaoCaoDoanhSoDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaBaoCaoDoanhSo", baoCaoDoanhSo.MaBaoCaoDoanhSo), 
                    New SQLiteParameter("@ThangBaoCaoDoanhSo", baoCaoDoanhSo.ThangBaoCaoDoanhSo.[Date]) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update BaoCaoDoanhSo Set ThangBaoCaoDoanhSo = @ThangBaoCaoDoanhSo where MaBaoCaoDoanhSo = @MaBaoCaoDoanhSo and IsAvailable = 1", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function DeleteBaoCaoDoanhSoByMaBaoCaoDoanhSo(maBaoCaoDoanhSo As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaBaoCaoDoanhSo", maBaoCaoDoanhSo) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update BaoCaoDoanhSo Set IsAvailable = 0 Where MaBaoCaoDoanhSo = @MaBaoCaoDoanhSo", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function SelectBaoCaoDoanhSoAll() As List(Of BaoCaoDoanhSoDTO)
        Dim list = New List(Of BaoCaoDoanhSoDTO)()
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaBaoCaoDoanhSo, ThangBaoCaoDoanhSo From BaoCaoDoanhSo Where IsAvailable = 1")
            list.AddRange(From dr In dt.Rows Select New BaoCaoDoanhSoDTO() With { 
                                                                            .MaBaoCaoDoanhSo = dr("MaBaoCaoDoanhSo").ToString(), 
                                                                            .ThangBaoCaoDoanhSo = DateTime.Parse(dr("ThangBaoCaoDoanhSo").ToString()) 
                                                                        })
        Catch ex As Exception
        Throw ex
        End Try
        Return list
    End Function
    Public Shared Function SelectBaoCaoDoanhSoByMaBaoCaoDoanhSo(maBaoCaoDoanhSo As String) As BaoCaoDoanhSoDTO
        Dim BaoCaoDoanhSo = New BaoCaoDoanhSoDTO()
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaBaoCaoDoanhSo", maBaoCaoDoanhSo) 
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaBaoCaoDoanhSo, ThangBaoCaoDoanhSo From BaoCaoDoanhSo Where MaBaoCaoDoanhSo = @MaBaoCaoDoanhSo and IsAvailable = 1", parameters)
            Dim dr = dt.Rows(0)
            BaoCaoDoanhSo.MaBaoCaoDoanhSo = dr("MaBaoCaoDoanhSo").ToString()
            BaoCaoDoanhSo.ThangBaoCaoDoanhSo = DateTime.Parse(dr("ThangBaoCaoDoanhSo").ToString())
        Catch ex As Exception
            Throw ex
        End Try
        Return BaoCaoDoanhSo
    End Function
    Public Shared Function CheckBaoCaoDoanhSoByMaBaoCaoDoanhSo(maBaoCaoDoanhSo As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaBaoCaoDoanhSo", maBaoCaoDoanhSo) 
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaBaoCaoDoanhSo From BaoCaoDoanhSo where MaBaoCaoDoanhSo = @MaBaoCaoDoanhSo and IsAvailable = 1", parameters)
            If dt.Rows.Count = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function GenerateNewMaBaoCaoDoanhSo() As String
        Dim newMaBaoCaoDoanhSo = 0
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MAX(CAST(REPLACE(MaBaoCaoDoanhSo , 'BDS', '') as int)) + 1 as NewMaBaoCaoDoanhSo from BaoCaoDoanhSo")
            newMaBaoCaoDoanhSo = If(dt.Rows(0)("NewMaBaoCaoDoanhSo").ToString() = "", 1, Integer.Parse(dt.Rows(0)("NewMaBaoCaoDoanhSo").ToString()))
        Catch ex As Exception
            Throw ex
        End Try
        Return String.Format("BDS{0:000}", newMaBaoCaoDoanhSo)
    End Function
End Class