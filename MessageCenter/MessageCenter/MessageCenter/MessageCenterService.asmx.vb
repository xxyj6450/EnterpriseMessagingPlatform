Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Services.Description
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.None)> _
<ToolboxItem(False)> _
Public Class MessageCenterService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessage(NodeID As String, Usercode As String, Password As String, Recipients As String, MessageType As Integer, _
                                Title As String, Content As String, Format As Integer, RetryOnError As Boolean, Reportflag As Integer, MessageID As String, _
                                InterfaceID As String, CONNID As String, TerminalID As String, IPAddress As String, Param As String) As Integer
        MessageCenter.SendMessage(NodeID, Usercode, Password, Recipients, MessageType, Title, Content, Format, RetryOnError, Reportflag, MessageID, InterfaceID, CONNID, TerminalID, IPAddress, Param)
    End Function
    <WebMethod()> _
    <SoapRpcMethod(Action:="NotifyStatus", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function NotifyStatus(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, NotifyType As Integer, Status As Integer, Text As String, ByRef Reserve As String) As Integer
        'WriteLog("收到通知:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & NotifyType & "," & Status & "," & Text)
        Return 0
    End Function
 
    <WebMethod()> _
    <SoapRpcMethod(Action:="EchoOfSendSMS", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function EchoOfSendSMS(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, Status As Integer, ErrorCode As Integer, ByRef Reserve As String) As Integer
        'WriteLog("收到回执:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & Status & "," & ErrorCode)
        Return 0
    End Function
    
    <WebMethod()> _
    <SoapRpcMethod(Action:="RecieveMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function RecieveMessage(SPNumber As String, RecieveNumber As String, Sender As String, Content As String, RecieveTime As Date) As Integer
        'WriteLog("收到消息:" & SPNumber & "," & Sender & "," & RecieveTime & "," & Content)
        Return 0
    End Function
End Class