﻿Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging
Imports EMP
Imports EMP.MessagerInterfaces
Imports log4net
Public Class MessageCenter
    Private Shared log As log4net.ILog = log4net.LogManager.GetLogger("SendProgress")
    '实际发送消息
    Public Shared Function SendMessage(CONNID As String, NodeID As String, NodeUsercode As String, NodePassword As String, Sender As String, SenderName As String, _
                                       Recipients As String, CC As String, Bcc As String, MessageType As Integer, Title As String, Content As String, _
                                       Format As Integer, RetryOnError As Boolean, Reportflag As Integer, MessageID As String, _
                                InterfaceID As String, Param As String) As Integer
        Dim ret As Integer, Options As String, sql As String, dt As Data.DataTable
        Dim MsgManager As EMP.MessagerInterfaces.IMessager

        Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection(Web.Configuration.WebConfigurationManager.ConnectionStrings("MessageCenterDB").ConnectionString)
            Dim dr As SqlClient.SqlDataReader, cmd As SqlClient.SqlCommand
            conn.Open()

            '下面开始路由消息,获取路由结果表
            cmd = New SqlCommand("sp_RoutingMessage", conn)
            With cmd
                .CommandText = "sp_RoutingMessage"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@NodeID", SqlDbType.VarChar, 50).Value = NodeID
                .Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = ""
                .Parameters.Add("@Recipients", SqlDbType.VarChar).Value = Recipients
                .Parameters.Add("@MsgLength", SqlDbType.Int).Value = Len(Content)
                .Parameters.Add("@MsgType", SqlDbType.Int).Value = MessageType
                .Parameters.Add("@InterfaceID", SqlDbType.VarChar, 50).Value = InterfaceID
                dr = .ExecuteReader()
            End With
            If dr.HasRows Then
                dt = New Data.DataTable
                dt.Load(dr)
                dr.Close()
                dr = Nothing
            Else
                Throw New Exception("无路由信息,无法继续投递消息.")
                Return -1
            End If

            '路由完毕,下面开始记录消息,并发送消息
            '先初始化好cmd,以免多次初始化
            cmd = Nothing
            cmd = New SqlCommand("sp_AddNewMessage", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = ""
                .Parameters.Add("@SessionID", SqlDbType.VarChar, 50).Value = MessageID
                .Parameters.Add("@MessageType", SqlDbType.VarChar, 50).Value = MessageType
                .Parameters.Add("@Recipients", SqlDbType.VarChar).Value = Recipients
                .Parameters.Add("@Title", SqlDbType.VarChar, 200).Value = Title
                .Parameters.Add("@Content", SqlDbType.VarChar).Value = Content
                .Parameters.Add("@MessageFormat", SqlDbType.Int).Value = Format
                .Parameters.Add("@MessageCount", SqlDbType.Int).Value = 0
                .Parameters.Add("@RetryOnError", SqlDbType.Bit).Value = RetryOnError
                .Parameters.Add("@InterfaceID", SqlDbType.VarChar, 50).Value = InterfaceID
                .Parameters.Add("@CONNID", SqlDbType.VarChar, 50).Value = CONNID

                .Parameters.Add("@ReportFlag", SqlDbType.Int).Value = Reportflag
                Dim p As SqlClient.SqlParameter = .Parameters.Add("@MessageID", SqlDbType.VarChar, 50)
                p.Direction = ParameterDirection.InputOutput

            End With
            '路由完毕就写数据到日志,并发送消息
            If InterfaceID = "" Then
                For Each row As Data.DataRow In dt.Rows()
                    With cmd
                        InterfaceID = row("InterfaceID").ToString
                        .Parameters("@InterfaceID").Value = InterfaceID
                        .Parameters("@Recipients").Value = row("Recipients").ToString
                        .Parameters("@Usercode").Value = row("Usercode").ToString
                        '.Parameters("@Password").Value = row("Password").ToString

                        .ExecuteNonQuery()
                        '将上一次的param和messageid合并在一起,传入下一次消息的param中
                        Try
                            MsgManager = EMP.MessagerFactory.CreateMessager(InterfaceID)
                        Catch ex As Exception
                            log.Error("创建对象失败", ex)
                            Continue For
                        End Try
                        Dim SendSMS As New SendMessage_Delegate(AddressOf MsgManager.SendMessage)
                        SendSMS.BeginInvoke(.Parameters("@MessageID").Value, NodeUsercode, NodePassword, row("Usercode").ToString, row("Password").ToString, Sender, SenderName, Title, Content, Format, row("Recipients").ToString, CC, Bcc, Options + ";" & MessageID, AddressOf SendMessage_Completed, MessageID)
                        'ret = MsgManager.SendMessage(.Parameters("@MessageID").Value, row("Usercode").ToString, row("Password").ToString, Title, Content, row("Recipients").ToString, Options + ";" & MessageID)
                    End With
                Next
            End If
            conn.Close()
        End Using
        Return ret
    End Function

    Private Delegate Function SendMessage_Delegate(ByRef MessageID As String, NodeUsercode As String, NodePassword As String, Usercode As String, Password As String, Sender As String, SenderName As String, _
                             Title As String, Content As String, Format As Integer, Recipients As String, CC As String, Bcc As String, ByRef Reserve As String) As String
    Private Shared Sub SendMessage_Completed(itfAR As IAsyncResult)
        Dim ar As AsyncResult = CType(itfAR, AsyncResult)
        Dim sms_d As SendMessage_Delegate = CType(ar.AsyncDelegate, SendMessage_Delegate)
        Dim ret As Integer, MessageID As String, Options As String, OldMessageID As String
        Try
            ret = sms_d.EndInvoke(OldMessageID, Options, ar)
            MessageID = CType(itfAR.AsyncState, String)
            'RaiseEvent NotifyStatus(OldMessageID, "", 0, ret, "", Options)
        Catch ex As Exception
            'RaiseEvent NotifyStatus(OldMessageID, "", 0, -1, ex.Message, Options)

        End Try
    End Sub

End Class
