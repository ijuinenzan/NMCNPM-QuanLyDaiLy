Imports System.Data.SQLite
Imports DTO


Public Class MatHangDAO
    Public Shared Function InsertMatHang(matHang As MatHangDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaMatHang", matHang.MaMatHang),
                    New SQLiteParameter("@TenMatHang", matHang.TenMatHang),
                    New SQLiteParameter("@SoLuongTon", matHang.SoLuongTon)
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Insert into MatHang values(@MaMatHang, @TenMatHang, @SoLuongTon, 1)", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function UpdateMatHang(matHang As MatHangDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaMatHang", matHang.MaMatHang),
                    New SQLiteParameter("@TenMatHang", matHang.TenMatHang),
                    New SQLiteParameter("@SoLuongTon", matHang.SoLuongTon)
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update MatHang Set TenMatHang = @TenMatHang, SoLuongTon = @SoLuongTon where MaMatHang = @MaMatHang and IsAvailable = 1", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function DeleteMatHangByMaMatHang(maMatHang As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaMatHang", maMatHang)
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update MatHang Set IsAvailable = 0 Where MaMatHang = @MaMatHang", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function SelectMatHangAll() As List(Of MatHangDTO)
        Dim list = New List(Of MatHangDTO)()
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select * from MatHang where IsAvailable = 1")
            list.AddRange(From dr In dt.Rows Select New MatHangDTO() With {
                             .MaMatHang = dr("MaMatHang").ToString(),
                             .TenMatHang = dr("TenMatHang").ToString(),
                             .SoLuongTon = Integer.Parse(dr("SoLuongTon").ToString())
                             })
        Catch ex As Exception
            Throw ex
        End Try
        Return list
    End Function
    Public Shared Function SelectMatHangByMaMatHang(maMatHang As String) As MatHangDTO
        Dim matHang = New MatHangDTO()
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaMatHang", maMatHang)
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select * from MatHang where MaMatHang = @MaMatHang and IsAvailable = 1", parameters)
            Dim dr = dt.Rows(0)
            matHang.MaMatHang = dr("MaMatHang").ToString()
            matHang.TenMatHang = dr("TenMatHang").ToString()
            matHang.SoLuongTon = Integer.Parse(dr("SoLuongTon").ToString())
        Catch ex As Exception
            Throw ex
        End Try
        Return matHang
    End Function
    Public Shared Function CheckMatHangByMaMatHang(maMatHang As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaMatHang", maMatHang)
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select * from MatHang where MaMatHang = @MaMatHang and IsAvailable = 1", parameters)
            If dt.Rows.Count = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function GenerateNewMaMatHang() As String
        Dim newMaMatHang = 0
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MAX(CAST(REPLACE(MaMatHang , 'MHA', '') as int)) + 1 as NewMaMatHang from MatHang")
            newMaMatHang = If(dt.Rows(0)("NewMaMatHang").ToString() = "", 1, Integer.Parse(dt.Rows(0)("NewMaMatHang").ToString()))
        Catch ex As Exception
            Throw ex
        End Try
        Return String.Format("MHA{0:000}", newMaMatHang)
    End Function
End Class