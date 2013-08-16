Imports System.Data
Imports System.Data.SqlClient
Module Common
    Public Delegate Function QueryData_Deletegate(sql As String) As DataSet
    Public Sub getDataASYN(sql As String, Callback As System.AsyncCallback)
        Dim f As New QueryData_Deletegate(AddressOf Query)
        f.BeginInvoke(sql, Callback, Nothing)

    End Sub

    Public Function Query(sql As String) As DataSet
        Dim SelectCommand As New MessageCenterservice.Command

        Dim ws As New MessageCenterservice.MessageCenterService
        Try
            SelectCommand.CommandText = sql
            SelectCommand.CommandType = CommandType.Text

            Return ws.getData("", "", SelectCommand)
        Catch ex As Exception
            MsgBox("获取数据异常" & vbCrLf & ex.Message, vbInformation, "提示信息")
            Return Nothing
        End Try

    End Function
    Public Sub main()
        Dim f As New frmMain
        Application.EnableVisualStyles()
        Application.Run(f)

    End Sub
 
End Module
