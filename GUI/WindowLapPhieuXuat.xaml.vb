
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls

Imports BUS
Imports DTO

Imports MahApps.Metro.Controls.Dialogs

Namespace GUI
    ''' <summary>
    ''' Interaction logic for WindowLapPhieuXuat.xaml
    ''' </summary>
    Public Partial Class WindowLapPhieuXuat
        Private _listChiTietPhieuXuat As List(Of DTO.ChiTietPhieuXuatDTO)

        Public Sub New()
            InitializeComponent()

            _listChiTietPhieuXuat = New List(Of ChiTietPhieuXuatDTO)()
        End Sub

        Private Sub MetroWindow_Loaded(sender As Object, e As RoutedEventArgs)
            MaDaiLy.ItemsSource = DaiLyBUS.SelectDaiLyAll()
            MatHang.ItemsSource = MatHangBUS.SelectMatHangAll()
            DonViTinh.ItemsSource = DonViTinhBUS.SelectDonViTinhAll()
        End Sub

        Private Sub RefreshDataGrid()
            DataGridChiTietPhieuXuat.ItemsSource = _listChiTietPhieuXuat
            DataGridChiTietPhieuXuat.Items.Refresh()
            TongTriGia.Text = "Tổng Trị Giá: " & _listChiTietPhieuXuat.Sum(Function(x) x.ThanhTien)
        End Sub

        Private Sub RefreshFlyout()
            MatHang.SelectedItem = Nothing
            DonViTinh.SelectedItem = Nothing
            DonGiaXuat.Text = ""
            SoLuongXuat.Text = ""
            SoLuongTon.Text = "0"
        End Sub

        Private Async Sub TaoPhieuXuat_Click(sender As Object, e As RoutedEventArgs)
            If DataGridChiTietPhieuXuat.Items.Count <> 0 AndAlso MaDaiLy.SelectedItem IsNot Nothing Then
                Dim temp = New PhieuXuatDTO() With { 
                        .MaDaiLy = DirectCast(MaDaiLy.SelectedItem, DaiLyDTO).MaDaiLy, 
                        .MaPhieuXuat = PhieuXuatBUS.GenerateNewMaPhieuXuat(), 
                        .NgayLapPhieu = CType(NgayLapPhieu.SelectedDate, DateTime), 
                        .TongTriGia = _listChiTietPhieuXuat.Sum(Function(x) x.ThanhTien) 
                        }

                Try
                    PhieuXuatBUS.InsertPhieuXuat(temp, _listChiTietPhieuXuat)
                    MaDaiLy.SelectedItem = Nothing
                    _listChiTietPhieuXuat = New List(Of ChiTietPhieuXuatDTO)()
                    RefreshDataGrid()
                    Await ShowMessageAsync("Thành công", "Lập phiếu xuất thành công")
                    MaDaiLy.ItemsSource = DaiLyBUS.SelectDaiLyAll()
                    MatHang.ItemsSource = MatHangBUS.SelectMatHangAll()
                    RefreshFlyout()
                Catch exception As Exception
                    ShowMessageAsync("Lỗi", exception.Message)
                End Try
            ElseIf DataGridChiTietPhieuXuat.Items.Count = 0 Then
                Await ShowMessageAsync("Lỗi", "Chưa có hàng!")
            Else
                Await ShowMessageAsync("Lỗi", "Chưa chọn đại lý!")
            End If

        End Sub

        Private Sub ThemChiTiet_Click(sender As Object, e As RoutedEventArgs)
            ChiTietPhieuXuat.IsOpen = True
        End Sub

        Private Sub Xoa_Click(sender As Object, e As RoutedEventArgs)
            If DataGridChiTietPhieuXuat.SelectedItem Is Nothing Then
                Return
            End If

            Dim chiTietPhieuXuat = DirectCast(DataGridChiTietPhieuXuat.SelectedItem, ChiTietPhieuXuatDTO)

            _listChiTietPhieuXuat.Remove(chiTietPhieuXuat)

            RefreshDataGrid()
        End Sub

        Private Sub MaDaiLy_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
            NoHienTai.Text = If(MaDaiLy.SelectedItem Is Nothing, "0", String.Format("{0}", DirectCast(MaDaiLy.SelectedItem, DaiLyDTO).NoCuaDaiLy))

            NoToiDa.Text = If(MaDaiLy.SelectedItem Is Nothing, "0", String.Format("{0}", LoaiDaiLyBUS.SelectLoaiDaiLyByMaLoaiDaiLy(DirectCast(MaDaiLy.SelectedItem, DaiLyDTO).MaLoaiDaiLy).NoToiDa))

        End Sub

        Private Async Sub Them_Click(sender As Object, e As RoutedEventArgs)
            If MatHang.SelectedItem Is Nothing OrElse DonViTinh.SelectedItem Is Nothing OrElse DonGiaXuat.Text = "" OrElse SoLuongXuat.Text = "" OrElse Integer.Parse(SoLuongXuat.Text) = 0 Then
                Await ShowMessageAsync("Lỗi", "Chưa đủ thông tin hàng hoặc số lượng hàng xuất bằng 0")

                Return
            End If

            Dim temp = New ChiTietPhieuXuatDTO() With { _
                    .MaMatHang = DirectCast(MatHang.SelectedItem, MatHangDTO).MaMatHang, _
                    .MaDonViTinh = DirectCast(DonViTinh.SelectedItem, DonViTinhDTO).MaDonViTinh, _
                    .SoLuongXuat = Integer.Parse(SoLuongXuat.Text), _
                    .DonGiaXuat = Single.Parse(DonGiaXuat.Text) _
                    }
            temp.ThanhTien = temp.SoLuongXuat * temp.DonGiaXuat

            _listChiTietPhieuXuat.Add(temp)

            RefreshDataGrid()
        End Sub

        Private Sub MatHang_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
            SoLuongTon.Text = If(DirectCast(MatHang.SelectedItem, MatHangDTO) IsNot Nothing, DirectCast(MatHang.SelectedItem, MatHangDTO).SoLuongTon.ToString(), "0")
        End Sub

        Private Sub DonGiaXuat_TextChanged(sender As Object, e As TextChangedEventArgs)
            DonGiaXuat.Text = New String(DonGiaXuat.Text.Where(Function(x) Char.IsDigit(x)).ToArray())
        End Sub

        Private Sub SoLuongXuat_TextChanged(sender As Object, e As TextChangedEventArgs)
            SoLuongXuat.Text = New String(SoLuongXuat.Text.Where(Function(x) Char.IsDigit(x)).ToArray())
        End Sub
    End Class
End Namespace
