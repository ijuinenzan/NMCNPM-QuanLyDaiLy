Imports System.Data.SQLite
Imports DTO

Public Class DonViTinhDAO
    Public Shared Function InsertDonViTinh(donViTinh As DonViTinhDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaDonViTinh", donViTinh.MaDonViTinh), 
                    New SQLiteParameter("@TenDonViTinh", donViTinh.TenDonViTinh) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Insert into DonViTinh values(@MaDonViTinh, @TenDonViTinh, 1)", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function UpdateDonViTinh(donViTinh As DonViTinhDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaDonViTinh", donViTinh.MaDonViTinh), 
                    New SQLiteParameter("@TenDonViTinh", donViTinh.TenDonViTinh) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update DonViTinh Set TenDonViTinh = @TenDonViTinh where MaDonViTinh = @MaDonViTinh and IsAvailable = 1", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function DeleteDonViTinhByMaDonViTinh(maDonViTinh As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaDonViTinh", maDonViTinh) 
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update DonViTinh Set IsAvailable = 0 Where MaDonViTinh = @MaDonViTinh", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function SelectDonViTinhAll() As List(Of DonViTinhDTO)
        Dim list = New List(Of DonViTinhDTO)()
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select * from DonViTinh where IsAvailable = 1")
            list.AddRange(From dr In dt.Rows Select New DonViTinhDTO() With { 
                                                                        .MaDonViTinh = dr("MaDonViTinh").ToString(), 
                                                                        .TenDonViTinh = dr("TenDonViTinh").ToString() 
                                                                    })
        Catch ex As Exception
        Throw ex
        End Try
        Return list
    End Function
    Public Shared Function SelectDonViTinhByMaDonViTinh(maDonViTinh As String) As DonViTinhDTO
        Dim donViTinh = New DonViTinhDTO()
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaDonViTinh", maDonViTinh) 
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select * from DonViTinh where MaDonViTinh = @MaDonViTinh and IsAvailable = 1", parameters)
            Dim dr = dt.Rows(0)
            donViTinh.MaDonViTinh = dr("MaDonViTinh").ToString()
            donViTinh.TenDonViTinh = dr("TenDonViTinh").ToString()
        Catch ex As Exception
            Throw ex
        End Try
        Return donViTinh
    End Function
    Public Shared Function CheckDonViTinhByMaDonViTinh(maDonViTinh As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From { 
                    New SQLiteParameter("@MaDonViTinh", maDonViTinh) 
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select * from DonViTinh where MaDonViTinh = @MaDonViTinh and IsAvailable = 1", parameters)
            If dt.Rows.Count = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function GenerateNewMaDonViTinh() As String
        Dim newMaDonViTinh = 0
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MAX(CAST(REPLACE(MaDonViTinh , 'DVT', '') as int)) + 1 as NewMaDonViTinh from DonViTinh")
            newMaDonViTinh = If(dt.Rows(0)("NewMaDonViTinh").ToString() = "", 1, Integer.Parse(dt.Rows(0)("NewMaDonViTinh").ToString()))
        Catch ex As Exception
            Throw ex
        End Try
        Return String.Format("DVT{0:000}", newMaDonViTinh)
    End Function
End Class