Imports System
Imports System.Globalization
Imports System.Windows.Data
Imports BUS
Imports BUS.BUS

Namespace GUI
    Public Class MaLoaiDaiLyToTenLoaiDaiLy
        Implements IValueConverter

        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            Return LoaiDaiLyBUS.SelectLoaiDaiLyByMaLoaiDaiLy(value.ToString()).TenLoaiDaiLy
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException
        End Function
    End Class
End Namespace
