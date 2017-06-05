Imports System.Data.SQLite
Imports DTO


Public Class LoaiDaiLyDAO
    Public Shared Function InsertLoaiDaiLy(loaiDaiLy As LoaiDaiLyDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaLoaiDaiLy", loaiDaiLy.MaLoaiDaiLy),
                    New SQLiteParameter("@TenLoaiDaiLy", loaiDaiLy.TenLoaiDaiLy),
                    New SQLiteParameter("@NoToiDa", loaiDaiLy.NoToiDa)
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Insert into LoaiDaiLy values(@MaLoaiDaiLy, @TenLoaiDaiLy, @NoToiDa, 1)", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function UpdateLoaiDaiLy(loaiDaiLy As LoaiDaiLyDTO) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaLoaiDaiLy", loaiDaiLy.MaLoaiDaiLy),
                    New SQLiteParameter("@TenLoaiDaiLy", loaiDaiLy.TenLoaiDaiLy),
                    New SQLiteParameter("@NoToiDa", loaiDaiLy.NoToiDa)
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update LoaiDaiLy Set TenLoaiDaiLy = @TenLoaiDaiLy, NoToiDa = @NoToiDa where MaLoaiDaiLy = @MaLoaiDaiLy and IsAvailable = 1", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function DeleteLoaiDaiLyByMaLoaiDaiLy(maLoaiDaiLy As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaLoaiDaiLy", maLoaiDaiLy)
                    }
            Dim n = DataAccessHelper.ExecuteNonQuery("Update LoaiDaiLy Set IsAvailable = 0 Where MaLoaiDaiLy = @MaLoaiDaiLy", parameters)
            If n = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function SelectLoaiDaiLyAll() As List(Of LoaiDaiLyDTO)
        Dim list = New List(Of LoaiDaiLyDTO)()
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select * from LoaiDaiLy where IsAvailable = 1")
            list.AddRange(From dr In dt.Rows Select New LoaiDaiLyDTO() With {
                             .MaLoaiDaiLy = dr("MaLoaiDaiLy").ToString(),
                             .TenLoaiDaiLy = dr("TenLoaiDaiLy").ToString(),
                             .NoToiDa = Integer.Parse(dr("NoToiDa").ToString())
                             })
        Catch ex As Exception
            Throw ex
        End Try
        Return list
    End Function
    Public Shared Function SelectLoaiDaiLyByMaLoaiDaiLy(maLoaiDaiLy As String) As LoaiDaiLyDTO
        Dim loaiDaiLy = New LoaiDaiLyDTO()
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaLoaiDaiLy", maLoaiDaiLy)
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select * from LoaiDaiLy where MaLoaiDaiLy = @MaLoaiDaiLy and IsAvailable = 1", parameters)
            Dim dr = dt.Rows(0)
            loaiDaiLy.MaLoaiDaiLy = dr("MaLoaiDaiLy").ToString()
            loaiDaiLy.TenLoaiDaiLy = dr("TenLoaiDaiLy").ToString()
            loaiDaiLy.NoToiDa = Integer.Parse(dr("NoToiDa").ToString())
        Catch ex As Exception
            Throw ex
        End Try
        Return loaiDaiLy
    End Function
    Public Shared Function CheckLoaiDaiLyByMaLoaiDaiLy(maLoaiDaiLy As String) As Boolean
        Dim result = False
        Try
            Dim parameters = New List(Of SQLiteParameter)() From {
                    New SQLiteParameter("@MaLoaiDaiLy", maLoaiDaiLy)
                    }
            Dim dt = DataAccessHelper.ExecuteQuery("Select * from LoaiDaiLy where MaLoaiDaiLy = @MaLoaiDaiLy and IsAvailable = 1", parameters)
            If dt.Rows.Count = 1 Then
                result = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Public Shared Function GenerateNewMaLoaiDaiLy() As String
        Dim newMaLoaiDaiLy = 0
        Try
            Dim dt = DataAccessHelper.ExecuteQuery("Select MAX(CAST(REPLACE(MaLoaiDaiLy , 'LDL', '') as int)) + 1 as NewMaLoaiDaiLy from LoaiDaiLy")
            newMaLoaiDaiLy = If(dt.Rows(0)("NewMaLoaiDaiLy").ToString() = "", 1, Integer.Parse(dt.Rows(0)("NewMaLoaiDaiLy").ToString()))
        Catch ex As Exception
            Throw ex
        End Try
        Return String.Format("LDL{0:000}", newMaLoaiDaiLy)
    End Function
End Class