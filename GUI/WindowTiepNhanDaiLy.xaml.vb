Imports DTO
Imports BUS

Imports MahApps.Metro.Controls.Dialogs

Namespace GUI
    ''' <summary>
    ''' Interaction logic for WindowTiepNhanDaiLy.xaml
    ''' </summary>
    Public Partial Class WindowTiepNhanDaiLy
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Async Sub TiepNhan_Click(sender As Object, e As RoutedEventArgs)
            If MaDaiLy.Text.Trim() = "" OrElse TenDaiLy.Text.Trim() = "" OrElse LoaiDaiLy.SelectedItem Is Nothing OrElse SoDienThoai.Text.Trim() = "" OrElse DiaChi.Text.Trim() = "" OrElse Quan.SelectedItem Is Nothing OrElse Email.Text.Trim() = "" Then
                Await ShowMessageAsync("Lỗi", "Các field còn trống")

                Return
            End If

            Try
                DaiLyBUS.InsertDaiLy(GetDaiLyFromInput())
                RefreshWindow()
                Await ShowMessageAsync("Thành công", "Tiếp nhận đại lý thành công")
            Catch ex As Exception
                ShowMessageAsync("Lỗi", ex.Message)
            End Try
        End Sub

        Private Sub DaiLyMoi_Click(sender As Object, e As RoutedEventArgs)
            RefreshWindow()
        End Sub

        Private Async Sub CapNhat_Click(sender As Object, e As RoutedEventArgs)
            If MaDaiLy.Text.Trim() = "" OrElse TenDaiLy.Text.Trim() = "" OrElse LoaiDaiLy.SelectedItem Is Nothing OrElse SoDienThoai.Text.Trim() = "" OrElse DiaChi.Text.Trim() = "" OrElse Quan.SelectedItem Is Nothing OrElse Email.Text.Trim() = "" Then
                Await ShowMessageAsync("Lỗi", "Các field còn trống")

                Return
            End If

            Try
                DaiLyBUS.UpdateDaiLy(GetDaiLyFromInput())
                RefreshWindow()
                Await ShowMessageAsync("Thành công", "Cập nhật đại lý thành công")
            Catch ex As Exception
                ShowMessageAsync("Lỗi", ex.Message)
            End Try
        End Sub

        Private Async Sub XoaDaiLy_Click(sender As Object, e As RoutedEventArgs)
            Dim daiLy = DirectCast(DataGridDaiLy.SelectedItem, DaiLyDTO)

            Try
                DaiLyBUS.DeleteDaiLyByMaDaiLy(daiLy.MaDaiLy)
                RefreshWindow()
                Await ShowMessageAsync("Thành công", "Xoá đại lý thành công")
            Catch ex As Exception
                ShowMessageAsync("Lỗi", ex.Message)
            End Try
        End Sub

        Private Async Sub Thoat_Click(sender As Object, e As RoutedEventArgs)
            Dim result = Await ShowMessageAsync("Thoát", "Bạn có đồng ý thoát?", MessageDialogStyle.AffirmativeAndNegative)

            If result = MessageDialogResult.Affirmative Then
                Close()
            End If
        End Sub

        Private Sub SoDienThoai_TextChanged(sender As Object, e As TextChangedEventArgs)
            SoDienThoai.Text = New String(SoDienThoai.Text.Where(Function(x) Char.IsDigit(x)).ToArray())
        End Sub

        Private Sub MetroWindow_Loaded(sender As Object, e As RoutedEventArgs)
            RefreshWindow()
        End Sub

        Private Sub DataGridDaiLy_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
            Dim daiLy = DirectCast(DataGridDaiLy.SelectedItem, DaiLyDTO)
            If daiLy IsNot Nothing Then
                UpdateTextBoxesWithDaiLy(daiLy)
            End If
        End Sub

        Private Sub DataGridDaiLy_CurrentCellChanged(sender As Object, e As EventArgs)
            Dim daiLy = DirectCast(DataGridDaiLy.SelectedItem, DaiLyDTO)
            If daiLy IsNot Nothing Then
                UpdateTextBoxesWithDaiLy(daiLy)
            End If
        End Sub

        Private Sub UpdateTextBoxesWithDaiLy(daiLy As DaiLyDTO)
            MaDaiLy.Text = daiLy.MaDaiLy.ToString()
            TenDaiLy.Text = daiLy.TenDaiLy
            LoaiDaiLy.SelectedItem = LoaiDaiLy.Items.Cast(Of LoaiDaiLyDTO)().FirstOrDefault(Function(x) x.MaLoaiDaiLy = daiLy.MaLoaiDaiLy)
            SoDienThoai.Text = daiLy.SoDienThoai
            DiaChi.Text = daiLy.DiaChi
            Quan.SelectedItem = Quan.Items.Cast(Of QuanDTO)().FirstOrDefault(Function(x) x.MaQuan = daiLy.MaQuan)
            NgayTiepNhan.SelectedDate = daiLy.NgayTiepNhan
            Email.Text = daiLy.Email
        End Sub

        Private Function GetDaiLyFromInput() As DaiLyDTO
            Return New DaiLyDTO() With { 
                .MaDaiLy = MaDaiLy.Text, 
                .TenDaiLy = TenDaiLy.Text, 
                .MaLoaiDaiLy = DirectCast(LoaiDaiLy.SelectedItem, LoaiDaiLyDTO).MaLoaiDaiLy, 
                .SoDienThoai = SoDienThoai.Text, 
                .DiaChi = DiaChi.Text, 
                .MaQuan = DirectCast(Quan.SelectedItem, QuanDTO).MaQuan, 
                .NgayTiepNhan = If(NgayTiepNhan.SelectedDate, DateTime.Now), 
                .Email = Email.Text 
                }
        End Function

        Private Sub UpdateDataGrid()
            DataGridDaiLy.ItemsSource = DaiLyBUS.SelectDaiLyAll()
        End Sub

        Private Sub RefreshWindow()
            UpdateDataGrid()

            MaDaiLy.Text = DaiLyBUS.GenerateNewMaDaiLy().ToString()
            TenDaiLy.Text = ""
            LoaiDaiLy.SelectedItem = Nothing
            SoDienThoai.Text = ""
            DiaChi.Text = ""
            Quan.SelectedItem = Nothing
            NgayTiepNhan.SelectedDate = DateTime.Now
            Email.Text = ""

            LoaiDaiLy.ItemsSource = LoaiDaiLyBUS.SelectLoaiDaiLyAll()
            Quan.ItemsSource = QuanBUS.SelectQuanAll()
        End Sub
    End Class
End Namespace
