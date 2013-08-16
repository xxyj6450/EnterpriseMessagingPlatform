Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Services.Description
Imports System.Data
<WebService(Namespace:="http://xxyj6450.s181.288idc.com/WebService.asmx")> _
<SoapDocumentService(RoutingStyle:=SoapServiceRoutingStyle.RequestElement, Use:=SoapBindingUse.Literal)> _
<WebServiceBinding(ConformsTo:=WsiProfiles.None)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class MessageCenterService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessage(CONNID As String, NodeID As String, NodeUsercode As String, NodePassword As String, Usercode As String, Password As String, _
                                       Sender As String, SenderName As String, Recipients As String, CC As String, Bcc As String, _
                                       MessageType As Integer, Title As String, Content As String, _
                                       Format As Integer, RetryOnError As Boolean, Reportflag As Integer, MessageID As String, _
                                InterfaceID As String, Param As String) As Integer
        MessageCenter.SendMessage(CONNID, NodeID, NodeUsercode, NodePassword, Sender, SenderName, Recipients, CC, Bcc, MessageType, Title, Content, Format, RetryOnError, Reportflag, MessageID, InterfaceID, Param)
    End Function
    <WebMethod()> _
    <SoapRpcMethod(Action:="NotifyStatus", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function NotifyStatus(Reciver As String, SequenceNo As String, MessageID As String, Recipient As String, NotifyType As Integer, Status As Integer, Text As String, ByRef Reserve As String) As Integer
        'WriteLog("收到通知:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & NotifyType & "," & Status & "," & Text)
        Return 0
    End Function

    <WebMethod()> _
    <SoapRpcMethod(Action:="EchoOfSendSMS", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Function EchoOfSendSMS(Reciver As String, SequenceNo As String, MessageID As String, Recipient As String, Status As Integer, ErrorCode As Integer, ByRef Reserve As String) As Integer
        'WriteLog("收到回执:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & Status & "," & ErrorCode)
        Return 0
    End Function

    <WebMethod()> _
    <SoapRpcMethod(Action:="RecieveMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function RecieveMessage(Reciver As String, SequenceNo As String, Recipients As String, From As String, Sender As String, Title As String, Content As String, Format As Integer, RecieveTime As DateTime) As Integer
        'WriteLog("收到消息:" & SPNumber & "," & Sender & "," & RecieveTime & "," & Content)
        Return 0
    End Function
    ''' <summary>
    ''' 验证登录，返回连接ID,其他接口调用都必须使用这个连接ID
    ''' </summary>
    ''' <param name="Usercode"></param>
    ''' <param name="Password"></param>
    ''' <param name="Version"></param>
    ''' <param name="TerminalID"></param>
    ''' <param name="IPAddress"></param>
    ''' <param name="ComputerName"></param>
    ''' <param name="MAC"></param>
    ''' <param name="CPUID"></param>
    ''' <param name="DISKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    <SoapRpcMethod(Action:="Login", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function Login(Usercode As String, Password As String, Version As String, TerminalID As String, IPAddress As String, ComputerName As String, MAC As String, CPUID As String, DISKID As String) As String
        'WriteLog("收到消息:" & SPNumber & "," & Sender & "," & RecieveTime & "," & Content)
        Return 0
    End Function
    Private Function getConnection() As System.Data.SqlClient.SqlConnection
        Return New System.Data.SqlClient.SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("MessageCenterDB").ConnectionString)
    End Function
    <WebMethod()> _
    Public Function getData(Usercode As String, Password As String, QueryString As CommonLib.Command) As System.Data.DataSet

        If QueryString Is Nothing Then Throw New Exception("查询参数不能为空") : Return Nothing
        Using conn As System.Data.SqlClient.SqlConnection = getConnection()
            conn.Open()
            Dim ds As New System.Data.DataSet, da As New System.Data.SqlClient.SqlDataAdapter(QueryString.getCommand())
            da.SelectCommand.Connection = conn
            da.Fill(ds)
            conn.Close()
            Return ds
        End Using

    End Function
End Class