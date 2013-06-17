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
Public Class HX_Message
    Inherits System.Web.Services.WebService
    Implements IMessage.IMessager

    <WebMethod()> _
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessage(ByRef MessageID As String, Usercode As String, Password As String, Title As String, Content As String, Recipients As String, ByRef Reserve As String) As Integer Implements IMessage.IMessager.SendMessage
        Try
            Using conn As New System.Data.SqlClient.SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("MessageCenterDB").ConnectionString)
                conn.Open()
                Dim cmd As New SqlCommand("sp_Send_HX_Message", conn)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add("@Recipients", SqlDbType.VarChar).Value = Recipients
                    .Parameters.Add("@Content", SqlDbType.VarChar).Value = Content
                    .Parameters.Add("@MsgType", SqlDbType.Int).Value = 1
                    .Parameters.Add("@dept", SqlDbType.VarChar).Value = Options
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

    Public Function NotifyStatus(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, NotifyType As Integer, Status As Integer, Text As String, ByRef Reserve As String) As Integer Implements IMessage.IMessager.NotifyStatus
        WriteLog("收到通知:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & NotifyType & "," & Status & "," & Text)
        Return 0
    End Function
    <WebMethod()> _
    <SoapRpcMethod(Action:="NotifyStatus", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function NotifyStatus(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, NotifyType As Integer, Status As Integer, Text As String) As Integer
        WriteLog("收到通知:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & NotifyType & "," & Status & "," & Text)
        Return 0
    End Function
    Public Function EchoOfSendSMS(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, Status As Integer, ErrorCode As Integer, ByRef Reserve As String) As Integer Implements IMessage.IMessager.EchoOfSendSMS
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
    Public Function RecieveMessage(SPNumber As String, RecieveNumber As String, Sender As String, Content As String, RecieveTime As Date) As Integer Implements IMessage.IMessager.RecieveMessage
        WriteLog("收到消息:" & SPNumber & "," & Sender & "," & RecieveTime & "," & Content)
        Return 0
    End Function



    Public Property Author As String Implements IMessage.IMessager.Author
        Get

        End Get
        Set(value As String)

        End Set
    End Property

    Public Function CheckKeyworkds(Content As String) As Integer Implements IMessage.IMessager.CheckKeyworkds

    End Function

    Public Property CLSID As String Implements IMessage.IMessager.CLSID
        Get
            Return "B9644867-678E-46F6-984C-4BE5E50FEDF7"
        End Get
        Set(value As String)

        End Set
    End Property

    Public Property Content As String Implements IMessage.IMessager.Content
        Get

        End Get
        Set(value As String)

        End Set
    End Property



    Public Property FeeMessageLength As Integer Implements IMessage.IMessager.FeeMessageLength
        Get

        End Get
        Set(value As Integer)

        End Set
    End Property

    Public Property InterfaceID As String Implements IMessage.IMessager.InterfaceID
        Get

        End Get
        Set(value As String)

        End Set
    End Property

    Public Property InvockPerSecond As Long Implements IMessage.IMessager.InvockPerSecond
        Get

        End Get
        Set(value As Long)

        End Set
    End Property

    Public Property Keywords As String Implements IMessage.IMessager.Keywords
        Get

        End Get
        Set(value As String)

        End Set
    End Property

    Public Property LimitPerDay_CM As Long Implements IMessage.IMessager.LimitPerDay_CM
        Get

        End Get
        Set(value As Long)

        End Set
    End Property

    Public Property LimitPerDay_TEL As Long Implements IMessage.IMessager.LimitPerDay_TEL
        Get

        End Get
        Set(value As Long)

        End Set
    End Property

    Public Property LimitPerDay_UN As Long Implements IMessage.IMessager.LimitPerDay_UN
        Get

        End Get
        Set(value As Long)

        End Set
    End Property

    Public Property LimitPerHour_CM As Long Implements IMessage.IMessager.LimitPerHour_CM
        Get

        End Get
        Set(value As Long)

        End Set
    End Property

    Public Property LimitPerHour_TEL As Long Implements IMessage.IMessager.LimitPerHour_TEL
        Get

        End Get
        Set(value As Long)

        End Set
    End Property

    Public Property LimitPerHour_UN As Long Implements IMessage.IMessager.LimitPerHour_UN
        Get

        End Get
        Set(value As Long)

        End Set
    End Property

    Public Property LimitPerMonth_CM As Long Implements IMessage.IMessager.LimitPerMonth_CM
        Get

        End Get
        Set(value As Long)

        End Set
    End Property

    Public Property LimitPerMonth_TEL As Long Implements IMessage.IMessager.LimitPerMonth_TEL
        Get

        End Get
        Set(value As Long)

        End Set
    End Property

    Public Property LimitPerMonth_UN As Long Implements IMessage.IMessager.LimitPerMonth_UN
        Get

        End Get
        Set(value As Long)

        End Set
    End Property

    Public Property MaxLength As String Implements IMessage.IMessager.MaxLength
        Get

        End Get
        Set(value As String)

        End Set
    End Property

    Public Property MaxRecipientCount As Integer Implements IMessage.IMessager.MaxRecipientCount
        Get

        End Get
        Set(value As Integer)

        End Set
    End Property

    Public Property MergeLimit As Boolean Implements IMessage.IMessager.MergeLimit
        Get

        End Get
        Set(value As Boolean)

        End Set
    End Property

    Public Property MessageType As Integer Implements IMessage.IMessager.MessageType
        Get

        End Get
        Set(value As Integer)

        End Set
    End Property



    Public Property Options As String Implements IMessage.IMessager.Options
        Get

        End Get
        Set(value As String)

        End Set
    End Property

    Public Property Password As String Implements IMessage.IMessager.Password
        Get

        End Get
        Set(value As String)

        End Set
    End Property



    Public Property Recipients As String Implements IMessage.IMessager.Recipients
        Get

        End Get
        Set(value As String)

        End Set
    End Property

    Public Sub RefreshInterfaceInfo() Implements IMessage.IMessager.RefreshInterfaceInfo

    End Sub

    Public Property RegistDate As Date Implements IMessage.IMessager.RegistDate
        Get

        End Get
        Set(value As Date)

        End Set
    End Property

    Public Property Remark As String Implements IMessage.IMessager.Remark
        Get

        End Get
        Set(value As String)

        End Set
    End Property


    Public Property Title As String Implements IMessage.IMessager.Title
        Get

        End Get
        Set(value As String)

        End Set
    End Property

    Public Property Usercode As String Implements IMessage.IMessager.Usercode
        Get

        End Get
        Set(value As String)

        End Set
    End Property
    Private Sub WriteLog(Message As String)
        Dim f As System.IO.StreamWriter
        f = System.IO.File.AppendText(Server.MapPath("") & "\Message.txt")
        f.WriteLine(Message & ">>>" & Now.ToString)

        f.Flush()
        f.Close()
    End Sub
End Class