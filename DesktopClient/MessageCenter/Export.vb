﻿Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlTypes
Imports System.Data.OleDb
Public Class Export
    Private Enum enumExportFileType As Long
        TextFile = 0
        csvFile = 1
        Excel = 2
        Excelx = 3
    End Enum
    Public Sub ExportData(dt As DataTable, FileName As String, Filter As String, SheetName As String)
        Dim ExportType As enumExportFileType
        If FileName = "" Then
            Dim a As New SaveFileDialog()
            a.Filter = "Excel(97-2003) 工作簿 (*.xls)|*.xls|Excel(2007/2010/2013)|*.xlsx|文本文档|*.txt|逗号分隔符|*.csv"
            If a.ShowDialog() = DialogResult.OK Then
                FileName = a.FileName
            Else
                Return
            End If
        End If
        Try
            System.IO.File.Delete(FileName)
        Catch generatedExceptionName As Exception
            MessageBox.Show("该文件已经存在，删除文件时出错！", "错误", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End Try
        If Right(FileName, 5) = ".xlsx" Then ExportType = enumExportFileType.Excelx
        If Right(FileName, 4) = ".xls" Then ExportType = enumExportFileType.Excel
        If Right(FileName, 4) = ".txt" Then ExportType = enumExportFileType.TextFile
        If Right(FileName, 4) = ".csv" Then ExportType = enumExportFileType.csvFile
        Try
            Select Case ExportType
                Case enumExportFileType.Excelx
                    SaveExcelx(dt, Filter, FileName, SheetName)
                Case enumExportFileType.Excel
                    SaveExcel(dt, Filter, FileName, SheetName)
            End Select
        Catch ex As Exception
            MsgBox("导出失败" & vbCrLf & ex.Message, vbInformation, "导出数据")
            Return
        End Try
        If MessageBox.Show("数据成功导出到『" + FileName + "』，是否现在打开？", "导出", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            System.Diagnostics.Process.Start(FileName)
        End If
    End Sub
    Public Sub SaveExcel(dt As DataTable, Filter As String, FileName As String, SheetName As String)
        Dim conn_excel As New OleDbConnection()


        Dim ConnStr As String

        ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""" + FileName + """;Extended Properties=""Excel 8.0;HDR=YES"""
        Try
            conn_excel.ConnectionString = ConnStr
            conn_excel.Open()
        Catch
            ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""" & FileName & """;Extended Properties=""Excel 8.0;HDR=YES"";"
            Try
                conn_excel.ConnectionString = ConnStr
                conn_excel.Open()
            Catch
                ConnStr = "Provider=Microsoft.ACE.OLEDB.14.0;Data Source=""" & FileName & """;Extended Properties=""Excel 8.0;HDR=YES"";"
                Try
                    conn_excel.ConnectionString = ConnStr
                    conn_excel.Open()
                Catch

                    ConnStr = "Provider=Microsoft.ACE.OLEDB.11.0;Data Source=""" & FileName & """;Extended Properties=""Excel 8.0;HDR=YES"";"
                    Try
                        conn_excel.ConnectionString = ConnStr
                        conn_excel.Open()
                    Catch
                        conn_excel.ConnectionString = ConnStr
                        ConnStr = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=""" & FileName & """;Extended Properties=""Excel 8.0;HDR=YES"";"
                        Try
                            conn_excel.ConnectionString = ConnStr
                            conn_excel.Open()
                        Catch ex As Exception

                            Throw New Exception("未安装Excel,无法导致Excel格式" & vbCrLf & ex.Message)
                        End Try
                    End Try
                End Try
            End Try
        End Try


        Dim cmd_excel As New OleDbCommand()

        Dim sql As String
        sql = SqlCreate(dt, SheetName)


        cmd_excel.Connection = conn_excel
        cmd_excel.CommandText = sql
        cmd_excel.ExecuteNonQuery()

        conn_excel.Close()

        Dim da_excel As New OleDbDataAdapter("Select * From [" + SheetName + "$]", conn_excel)
        Dim dt_excel As New DataTable()
        da_excel.Fill(dt_excel)

        da_excel.InsertCommand = SqlInsert(SheetName, dt, conn_excel)

        Dim dr_excel As DataRow
        Dim ColumnName As String

        For Each dr As DataRow In dt.[Select](Filter)
            dr_excel = dt_excel.NewRow()

            For Each dc As DataColumn In dt.Columns
                ColumnName = dc.ColumnName

                dr_excel(ColumnName) = dr(ColumnName)
            Next

            dt_excel.Rows.Add(dr_excel)
        Next

        da_excel.Update(dt_excel)
        conn_excel.Close()


    End Sub
    Public Sub SaveExcelx(dt As DataTable, Filter As String, FileName As String, SheetName As String)
        Dim conn_excel As New OleDbConnection()
 

        Dim ConnStr As String
        'ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""" + FileName + """;Extended Properties=""Excel 8.0;HDR=YES"""
        ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""" & FileName & """;Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
        Try
            conn_excel.ConnectionString = ConnStr
            conn_excel.Open()
        Catch
            ConnStr = "Provider=Microsoft.ACE.OLEDB.14.0;Data Source=""" & FileName & """;Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
            Try
                conn_excel.ConnectionString = ConnStr
                conn_excel.Open()
            Catch
                ConnStr = "Provider=Microsoft.ACE.OLEDB.14.0;Data Source=""" & FileName & """;Extended Properties=""Excel 14.0 Xml;HDR=YES"";"
                Try
                    conn_excel.ConnectionString = ConnStr
                    conn_excel.Open()
                Catch ex As Exception

                    Throw New Exception("未安装Excel,无法导致Excel格式" & vbCrLf & ex.Message)

                End Try
            End Try
        End Try
        Dim cmd_excel As New OleDbCommand()
        Dim sql As String
        sql = SqlCreate(dt, SheetName)
        cmd_excel.Connection = conn_excel
        cmd_excel.CommandText = sql
        cmd_excel.ExecuteNonQuery()
        conn_excel.Close()
        Dim da_excel As New OleDbDataAdapter("Select * From [" + SheetName + "$]", conn_excel)
        Dim dt_excel As New DataTable()
        da_excel.Fill(dt_excel)
        da_excel.InsertCommand = SqlInsert(SheetName, dt, conn_excel)

        Dim dr_excel As DataRow
        Dim ColumnName As String

        For Each dr As DataRow In dt.[Select](Filter)
            dr_excel = dt_excel.NewRow()

            For Each dc As DataColumn In dt.Columns
                ColumnName = dc.ColumnName

                dr_excel(ColumnName) = dr(ColumnName)
            Next

            dt_excel.Rows.Add(dr_excel)
        Next

        da_excel.Update(dt_excel)
        conn_excel.Close()

    End Sub
    Private Sub CheckColumn(dt As DataTable, dt_v As DataTable)
        For Each dr As DataRow In dt_v.[Select]()
            If Not dt.Columns.Contains(dr("列名").ToString()) Then
                dr.Delete()
            End If
        Next
        dt_v.AcceptChanges()
    End Sub

    Private Function GetDataType(i As Type) As String
        Dim s As String

        Select Case i.Name
            Case "String"
                s = "Char"
                Exit Select
            Case "Int32"
                s = "Int"
                Exit Select
            Case "Int64"
                s = "Int"
                Exit Select
            Case "Int16"
                s = "Int"
                Exit Select
            Case "Double"
                s = "Double"
                Exit Select
            Case "Decimal"
                s = "Double"
                Exit Select
            Case Else
                s = "Char"
                Exit Select

        End Select
        Return s
    End Function

    Private Function StringToOleDbType(i As Type) As OleDbType
        Dim s As OleDbType

        Select Case i.Name
            Case "String"
                s = OleDbType.[Char]
                Exit Select
            Case "Int32"
                s = OleDbType.[Integer]
                Exit Select
            Case "Int64"
                s = OleDbType.[Integer]
                Exit Select
            Case "Int16"
                s = OleDbType.[Integer]
                Exit Select
            Case "Double"
                s = OleDbType.[Double]
                Exit Select
            Case "Decimal"
                s = OleDbType.[Decimal]
                Exit Select
            Case Else
                s = OleDbType.[Char]
                Exit Select

        End Select
        Return s

    End Function


    Private Function SqlCreate(dt As DataTable, SheetName As String) As String
        Dim sql As String

        sql = "CREATE TABLE " + SheetName + " ("

        For Each dc As DataColumn In dt.Columns
            sql += "[" + dc.ColumnName + "] " + GetDataType(dc.DataType) + " ,"
        Next

        'sql = "CREATE TABLE [" + SheetName + "] (";

        'foreach (C1.Win.C1TrueDBGrid.C1DataColumn dc in grid.Columns)
        '{
        '    sql += "[" + dc.Caption + "] " + GetDataType(dc.DataType) + ",";
        '}
        'sql = sql.Substring(0, sql.Length - 1);
        'sql += ")";

        sql = sql.Substring(0, sql.Length - 1)
        sql += ")"

        Return sql
    End Function


    ' 生成 InsertCommand 并设置参数
    Private Function SqlInsert(SheetName As String, dt As DataTable, conn_excel As OleDbConnection) As OleDbCommand
        Dim i As OleDbCommand
        Dim sql As String

        sql = "INSERT INTO [" + SheetName + "$] ("
        For Each dc As DataColumn In dt.Columns
            sql += "[" + dc.ColumnName + "] "
            sql += ","
        Next
        sql = sql.Substring(0, sql.Length - 1)
        sql += ") VALUES ("
        For Each dc As DataColumn In dt.Columns
            sql += "?,"
        Next
        sql = sql.Substring(0, sql.Length - 1)
        sql += ")"

        i = New OleDbCommand(sql, conn_excel)

        For Each dc As DataColumn In dt.Columns
            i.Parameters.Add("@" + dc.Caption, StringToOleDbType(dc.DataType), 0, dc.Caption)
        Next

        Return i
    End Function

End Class
