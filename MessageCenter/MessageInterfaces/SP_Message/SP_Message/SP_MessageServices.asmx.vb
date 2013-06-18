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
Public Class SP_MessageService
    Inherits System.Web.Services.WebService
    Private sp_Object As New SP_Message
    <WebMethod()> _
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessage(MessageID As String, Usercode As String, Password As String, Content As String, Recipients As String, ByRef Reserve As String) As Integer
        Return (New SP_Message).SendMessage(MessageID, Usercode, Password, Content, Recipients, Reserve)
    End Function

    <WebMethod()> _
    <SoapRpcMethod(Action:="NotifyStatus", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function NotifyStatus(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, NotifyType As Integer, Status As Integer, Text As String) As Integer
        WriteLog("收到通知:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & NotifyType & "," & Status & "," & Text)
        Return (New SP_Message).NotifyStatus(SPNumber, SequenceNo, MessageID, Recipient, NotifyType, Status, Text, "")
    End Function

    <WebMethod()> _
    <SoapRpcMethod(Action:="EchoOfSendSMS", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function EchoOfSendSMS(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, Status As Integer, ErrorCode As Integer) As Integer
        WriteLog("收到回执:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & Status & "," & ErrorCode)
        Return (New SP_Message).EchoOfSendSMS(SPNumber, SequenceNo, MessageID, Recipient, Status, ErrorCode, "")
    End Function
    <WebMethod()> _
    <SoapRpcMethod(Action:="RecieveMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function RecieveMessage(SPNumber As String, RecieveNumber As String, Sender As String, Content As String, RecieveTime As Date) As Integer
        WriteLog("收到消息:" & SPNumber & "," & Sender & "," & RecieveTime & "," & Content)
        Return (New SP_Message).RecieveMessage(SPNumber, "", RecieveNumber, "", Sender, "", Content, 0, RecieveTime)
    End Function

     
    Private Sub WriteLog(Message As String)
        Dim f As System.IO.StreamWriter
        f = System.IO.File.AppendText(Server.MapPath("") & "\Message.txt")
        f.WriteLine(Message & ">>>" & Now.ToString)

        f.Flush()
        f.Close()
    End Sub
End Class