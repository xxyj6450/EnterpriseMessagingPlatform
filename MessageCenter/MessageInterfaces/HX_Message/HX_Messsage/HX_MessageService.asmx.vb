Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web
Imports System.Web.Services.Description
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Xml.Serialization
Imports System.Xml
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=Services.WsiProfiles.None)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<ToolboxItem(False)> _
Public Class HX_MessageService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessage(ByRef MessageID As String, Usercode As String, Password As String, Title As String, Content As String, Recipients As String, ByRef Reserve As String) As Integer
        Try
            Using conn As New System.Data.SqlClient.SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("MessageCenterDB").ConnectionString)
                conn.Open()
                Dim cmd As New SqlCommand("sp_Send_HX_Message", conn)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add("@Recipients", SqlDbType.VarChar).Value = Recipients
                    .Parameters.Add("@Content", SqlDbType.VarChar).Value = Content
                    .Parameters.Add("@MsgType", SqlDbType.Int).Value = 1
                    .Parameters.Add("@dept", SqlDbType.VarChar).Value = Reserve
                    .Parameters.Add("@srcuser", SqlDbType.VarChar).Value = Usercode
                    .ExecuteNonQuery()
                End With
                conn.Close()
            End Using

            Return 0
        Catch ex As Exception

            Return -8
        End Try
    End Function
    Private Function RequestWEB(ByVal URL As String, Optional Data As String = "", Optional ByVal URLRefer As String = "http://esales.10010.com") As String
        Dim httpRequest As System.Net.HttpWebRequest
        Dim httpResponse As System.Net.HttpWebResponse
        Dim html As String
        Dim bytes() As Byte, RequestBytes() As Byte
        httpRequest = System.Net.HttpWebRequest.Create(URL)
        RequestBytes = System.Text.Encoding.UTF8.GetBytes(Data)
        With httpRequest
            .Method = "POST"
            .ContentType = "application/x-www-form-urlencoded"
            .ContentLength = RequestBytes.Length
            .GetRequestStream.Write(RequestBytes, 0, RequestBytes.Length)
            httpResponse = httpRequest.GetResponse
            Using reader As New System.IO.StreamReader(httpResponse.GetResponseStream)
                html = reader.ReadToEnd
            End Using
        End With
        httpRequest.GetResponse.Close()
        httpResponse.Close()
        httpRequest = Nothing
        httpResponse = Nothing
        Return html
    End Function

    Public Function NotifyStatus(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, NotifyType As Integer, Status As Integer, Text As String, ByRef Reserve As String) As Integer
        WriteLog("收到通知:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & NotifyType & "," & Status & "," & Text)
        Return 0
    End Function
    <WebMethod()> _
    <SoapRpcMethod(Action:="NotifyStatus", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function NotifyStatus(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, NotifyType As Integer, Status As Integer, Text As String) As Integer
        WriteLog("收到通知:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & NotifyType & "," & Status & "," & Text)
        Return 0
    End Function
    Public Function EchoOfSendSMS(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, Status As Integer, ErrorCode As Integer, ByRef Reserve As String) As Integer
        WriteLog("收到回执:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & Status & "," & ErrorCode)
        Return 0
    End Function
    <WebMethod()> _
    <SoapRpcMethod(Action:="EchoOfSendSMS", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function EchoOfSendSMS(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, Status As Integer, ErrorCode As Integer) As Integer
        WriteLog("收到回执:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & Status & "," & ErrorCode)
        Return 0
    End Function
    <WebMethod()> _
    <SoapRpcMethod(Action:="RecieveMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function RecieveMessage(SPNumber As String, RecieveNumber As String, Sender As String, Content As String, RecieveTime As Date) As Integer
        WriteLog("收到消息:" & SPNumber & "," & Sender & "," & RecieveTime & "," & Content)
        Return 0
    End Function
    Private Sub WriteLog(Message As String)
        Dim f As System.IO.StreamWriter
        f = System.IO.File.AppendText(Server.MapPath("") & "\Message.txt")
        f.WriteLine(Message & ">>>" & Now.ToString)

        f.Flush()
        f.Close()
    End Sub
End Class