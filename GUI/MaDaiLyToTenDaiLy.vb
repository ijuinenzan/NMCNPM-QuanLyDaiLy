Imports System
Imports System.Globalization
Imports System.Windows.Data
Imports BUS

Public Class MaDaiLyToTenDaiLy
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        Return DaiLyBUS.SelectDaiLyByMaDaiLy(value.ToString()).TenDaiLy
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException
    End Function
End Class
