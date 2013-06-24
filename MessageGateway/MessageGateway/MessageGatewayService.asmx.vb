Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Services.Description
Imports System.Web.Services.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Threading
Imports System.Runtime.Remoting.Messaging
'<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.None)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class MessageGatewayService
    Inherits System.Web.Services.WebService
    Private msgCenter As MessageCenterService.MessageCenterService
    Private Shared UserConnection As New System.Collections.Generic.Dictionary(Of String, String)
    ''' <summary> 
    ''' 发送短信
    ''' </summary>
    ''' <param name="Usercode">用户编码</param>
    ''' <param name="Password">用户密码</param>
    ''' <param name="Recipients">消息接收列表,分号分隔多个号码,最多不超过5000个</param>
    ''' <param name="Content">消息正文</param>
    ''' <param name="Format">消息格式 0:纯文本</param>
    ''' <param name="MessageType">消息类型,短信请传1</param>
    ''' <param name="RetryOnError">发生错误时是否重试</param>
    ''' <param name="Reportflag">消息报告标志0:不报告 1:成功报告 2:失败报告 3:成功和失败都报告(需要注册和发布消息回执接口)</param>
    ''' <param name="MessageID">应用程序提供的消息唯一标志,可为一个GUID,用于回执和报告消息状态时应用区分消息</param>
    ''' <returns>返回消息发送状态,0为正常 -1:余额不足 -2:用户错误 -3:密码错误 -4:用户或密码错误  -5:传入参数不合法、超长、类型错误 -6:暂停服务 -7:系统错误</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessage(Usercode As String, Password As String, Recipients As String, MessageType As Integer, _
                                Title As String, Content As String, Format As Integer, RetryOnError As Boolean, Reportflag As Integer) As Integer
        Dim IPAddress As String, CONNID As String, NodeUsercode As String, NodePassword As String, TerminalID As String, MessageID As String
        Dim Sender As String, SenderName As String, CC As String, BCC As String
        Dim sql As String, cmd As SqlCommand, dr As SqlDataReader
        Dim NodeID As String = "", Node_Usercode As String = "", Node_Password As String, Node_InterfaceID As String = "", Node_MessageId As String = ""
        Dim Node_CONNID As String = "", Node_TerminalID As String = "", Node_IPAddress As String, Node_RetryOnError As Boolean, Node_Reportflag As Integer
        '身份验证
        Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection(Web.Configuration.WebConfigurationManager.ConnectionStrings("MessageGagewayDB").ConnectionString)
            sql = "Select * From fn_checkUserLogin(@Usercode,@Password)"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            With cmd
                .Parameters.Add("@Usercode", SqlDbType.VarChar, 50)
                .Parameters.Add("@Password", SqlDbType.VarChar, 50)
                .Parameters("@Usercode").Value = Usercode
                .Parameters("@Password").Value = Password
                dr = .ExecuteReader(CommandBehavior.SingleRow)
            End With
            '若无数据行返回则说明用户名或密码错误
            If dr.HasRows = 0 Then Return -4
            '余额判断
            '数据写回数据库
            dr.Close()
            cmd.Dispose()
            cmd = Nothing
            cmd = New SqlCommand("sp_AddNewMessage", conn)
            With cmd
                '获取调用者的IP地址
                If IPAddress = "" Then
                    If Not (System.Web.HttpContext.Current.Request.ServerVariables("HTTP_VIA") Is Nothing) Then
                        IPAddress = System.Web.HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR").ToString
                    Else
                        IPAddress = System.Web.HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString
                    End If
                End If
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Usercode
                .Parameters.Add("@SessionID", SqlDbType.VarChar, 50).Value = MessageID
                .Parameters.Add("@MessageType", SqlDbType.VarChar, 50).Value = MessageType
                .Parameters.Add("@Recipients", SqlDbType.VarChar).Value = Recipients
                .Parameters.Add("@Title", SqlDbType.VarChar, 200).Value = Title
                .Parameters.Add("@Content", SqlDbType.VarChar, 8000).Value = Content
                .Parameters.Add("@MessageFormat", SqlDbType.Int).Value = Format
                .Parameters.Add("@RetryOnError", SqlDbType.Bit).Value = RetryOnError
                .Parameters.Add("@CONNID", SqlDbType.VarChar, 50).Value = CONNID
                .Parameters.Add("@TerminalID", SqlDbType.VarChar, 50).Value = TerminalID
                .Parameters.Add("@IPAddress", SqlDbType.VarChar, 20).Value = IPAddress
                .Parameters.Add("@ReportFlag", SqlDbType.Int).Value = Reportflag
                Dim p As SqlClient.SqlParameter = .Parameters.Add("@MessageID", SqlDbType.VarChar, 50)
                p.Direction = ParameterDirection.InputOutput
                .ExecuteNonQuery()
                '返回消息ID
                Node_MessageId = p.Value.ToString
            End With
            conn.Close()
        End Using
        msgCenter = New MessageCenterService.MessageCenterService
        Dim sendSMS As New SendMessage_MessageCenterDelegate(AddressOf msgCenter.SendMessage)

        sendSMS.BeginInvoke(NodeID, Node_Usercode, Node_Password, Usercode, Password, Sender, SenderName, Recipients, CC, BCC, MessageType, Title, Content, Format, Node_RetryOnError, Node_Reportflag, Node_MessageId, _
                            Node_InterfaceID, Node_CONNID, Node_TerminalID, Node_IPAddress, MessageID, New System.AsyncCallback(AddressOf SendMessage_MessageCenter_Compelted), Nothing)
        Return 0
    End Function
    <WebMethod()> _
    <SoapRpcMethod(Action:="SendEmail", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public 
    <WebMethod()> _
    <SoapRpcMethod(Action:="SendEmail", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendEmail(Usercode As String, Password As String, Sender As String, SenderName As String, Recipients As String, CC As String, BCC As String, _
                                Title As String, Content As String, Format As Integer) As Integer
        Dim IPAddress As String, CONNID As String, NodeUsercode As String, NodePassword As String, TerminalID As String, MessageID As String

    End Function
    <WebMethod()> _
    <SoapRpcMethod(Action:="SendSMS", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendSMS(Usercode As String, Password As String, Recipients As String, Content As String) As Integer
        Dim IPAddress As String, CONNID As String, NodeUsercode As String, NodePassword As String, TerminalID As String, MessageID As String

    End Function

    '声名发送消息到消息中心的委托，用于异步调用
    Private Delegate Function SendMessage_MessageCenterDelegate(NodeID As String, NodeUsercode As String, NodePassword As String, _
                                       Usercode As String, Password As String, Sender As String, SenderName As String, _
                                       Recipients As String, CC As String, Bcc As String, MessageType As Integer, Title As String, Content As String, _
                                       Format As Integer, RetryOnError As Boolean, Reportflag As Integer, MessageID As String, _
                                InterfaceID As String, CONNID As String, TerminalID As String, IPAddress As String, Param As String) As Integer

    '发送消息结束时的事件
    Private Sub SendMessage_MessageCenter_Compelted(ByVal itfAR As IAsyncResult)
        Dim ar As AsyncResult = CType(itfAR, AsyncResult)
        Dim sms_d As SendMessage_MessageCenterDelegate = CType(ar.AsyncDelegate, SendMessage_MessageCenterDelegate)

    End Sub
 

End Class