Imports System.Data.SQLite
Imports DTO

Public Class BaoCaoCongNoDAO
    Public Shared Function InsertBaoCaoCongNo(baoCaoCongNo As BaoCaoCongNoDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaBaoCaoCongNo", baoCaoCongNo.MaBaoCaoCongNo), 
                    New SQLiteParameter("@ThangBaoCaoCongNo", baoCaoCongNo.ThangBaoCaoCongNo.[Date]) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Insert into BaoCaoCongNo values(@MaBaoCaoCongNo, @ThangBaoCaoCongNo, 1)", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function UpdateBaoCaoCongNo(baoCaoCongNo As BaoCaoCongNoDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaBaoCaoCongNo", baoCaoCongNo.MaBaoCaoCongNo), 
                    New SQLiteParameter("@ThangBaoCaoCongNo", baoCaoCongNo.ThangBaoCaoCongNo.[Date]) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update BaoCaoCongNo Set ThangBaoCaoCongNo = @ThangBaoCaoCongNo where MaBaoCaoCongNo = @MaBaoCaoCongNo and IsAvailable = 1", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function DeleteBaoCaoCongNoByMaBaoCaoCongNo(maBaoCaoCongNo As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaBaoCaoCongNo", maBaoCaoCongNo) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update BaoCaoCongNo Set IsAvailable = 0 Where MaBaoCaoCongNo = @MaBaoCaoCongNo", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function SelectBaoCaoCongNoAll() As List(Of BaoCaoCongNoDTO)
        Dim list = New List(Of BaoCaoCongNoDTO)()
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaBaoCaoCongNo, ThangBaoCaoCongNo From BaoCaoCongNo Where IsAvailable = 1")
            list.AddRange(From dr In dt.Rows Select New BaoCaoCongNoDTO() With { 
                                                                           .MaBaoCaoCongNo = dr("MaBaoCaoCongNo").ToString(), 
                                                                           .ThangBaoCaoCongNo = DateTime.Parse(dr("ThangBaoCaoCongNo").ToString()) 
                                                                       })
        Catch ex As Exception
        Throw ex
        End Try
        Return list
    End Function
    Public Shared Function SelectBaoCaoCongNoByMaBaoCaoCongNo(maBaoCaoCongNo As String) As BaoCaoCongNoDTO
        Dim BaoCaoCongNo = New BaoCaoCongNoDTO()
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaBaoCaoCongNo", maBaoCaoCongNo) 
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaBaoCaoCongNo, ThangBaoCaoCongNo From BaoCaoCongNo Where MaBaoCaoCongNo = @MaBaoCaoCongNo and IsAvailable = 1", parameters)
            Dim dr = dt.Rows(0)
            BaoCaoCongNo.MaBaoCaoCongNo = dr("MaBaoCaoCongNo").ToString()
            BaoCaoCongNo.ThangBaoCaoCongNo = DateTime.Parse(dr("ThangBaoCaoCongNo").ToString())
        Catch ex As Exception
            Throw ex
        End Try
        Return BaoCaoCongNo
    End Function
    Public Shared Function CheckBaoCaoCongNoByMaBaoCaoCongNo(maBaoCaoCongNo As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaBaoCaoCongNo", maBaoCaoCongNo) 
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select MaBaoCaoCongNo From BaoCaoCongNo where MaBaoCaoCongNo = @MaBaoCaoCongNo and IsAvailable = 1", parameters)
            If dt.Rows.Count = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function GenerateNewMaBaoCaoCongNo() As String
        Dim newMaBaoCaoCongNo = 0
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MAX(CAST(REPLACE(MaBaoCaoCongNo , 'BCN', '') as int)) + 1 as NewMaBaoCaoCongNo from BaoCaoCongNo")
            newMaBaoCaoCongNo = If(dt.Rows(0)("NewMaBaoCaoCongNo").ToString() = "", 1, Integer.Parse(dt.Rows(0)("NewMaBaoCaoCongNo").ToString()))
        Catch ex As Exception
            Throw ex
        End Try
        Return String.Format("BCN{0:000}", newMaBaoCaoCongNo)
    End Function
End Class