Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Net
Imports EMP
Imports System.Data
Imports System.Data.SqlClient
Imports log4net
Namespace Messager
    <EMP.Messager("B9644867-678E-46F6-984C-4BE5E50FEDF7", 0, "SP短信", "SYSTEM", "联通SP短信接口")>
    Public Class SP_Message
        Implements MessagerInterfaces.IMessager
        Private Const SP_Message_URL As String = "http://192.168.88.53:8080/JtSgip/JTMessageSend.jsp"

        Protected Friend Function RecieveMessage(Reciver As String, SequenceNo As String, Recipients As String, From As String, _
                                                 Sender As String, Title As String, Content As String, Format As Integer, RecieveTime As Date) As Integer Implements MessagerInterfaces.IMessager.RecieveMessage
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim b() As Byte = System.Text.Encoding.UTF8.GetBytes(Content)
            '身份验证
            Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection(Web.Configuration.WebConfigurationManager.ConnectionStrings("SP_MessageDB").ConnectionString)
                conn.Open()
                cmd = New SqlCommand("sp_RecieveMessage", conn)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add("@InterfaceID", SqlDbType.VarChar).Value = Me.InterfaceID
                    .Parameters.Add("@Reciver", SqlDbType.VarChar).Value = Reciver
                    .Parameters.Add("@SequenceNo", SqlDbType.VarChar).Value = SequenceNo
                    .Parameters.Add("@Recipients", SqlDbType.VarChar).Value = Recipients
                    .Parameters.Add("@From", SqlDbType.VarChar).Value = From
                    .Parameters.Add("@Sender", SqlDbType.VarChar).Value = Sender
                    .Parameters.Add("@Content", SqlDbType.VarChar).Value = Content & "|" & System.Text.UnicodeEncoding.Unicode.GetString(System.Text.Encoding.UTF8.GetBytes(Content))
                    .Parameters.Add("@Title", SqlDbType.VarChar).Value = Title
                    .Parameters.Add("@Format", SqlDbType.Int).Value = Format
                    .Parameters.Add("@RecieveTime", SqlDbType.DateTime).Value = RecieveTime
                    .ExecuteNonQuery()
                End With
                conn.Close()
            End Using
            Return 0
        End Function

        Public Function SendMessage(ByRef MessageID As String, NodeUsercode As String, NodePassword As String, Usercode As String, Password As String, Sender As String, SenderName As String, Title As String, Content As String, Format As Integer, Recipients As String, CC As String, Bcc As String, ByRef Reserve As String) As String Implements MessagerInterfaces.IMessager.SendMessage
            Return SendMessage(MessageID, Usercode, Password, Content, Recipients, Reserve)
        End Function
        Public Function SendMessage(ByRef MessageID As String, Usercode As String, Password As String, Content As String, Recipients As String, ByRef Reserve As String) As Integer
            'http://192.168.88.53:8080/WebSgip/MessageSendPage.jsp?SendTelList=18688639997&SendContext=%E6%B5%8B%E8%AF%95%E7%9F%AD%E4%BF%A1
            Dim url As String, ret As String
            If System.Configuration.ConfigurationManager.AppSettings("SP_Message_URL") = "" Then
                System.Configuration.ConfigurationManager.AppSettings("SP_Message_URL") = SP_Message_URL
            End If
            url = System.Configuration.ConfigurationManager.AppSettings("SP_Message_URL")

            ret = RequestWEB(url, "SendTelList=" & System.Web.HttpUtility.UrlEncode(Recipients) _
                             & "&SendContext=" & System.Web.HttpUtility.UrlEncode(Content) _
                             & "&Usercode=" & System.Web.HttpUtility.UrlEncode(Usercode) _
                             & "&Password=" & System.Web.HttpUtility.UrlEncode(Password) _
                             & "&MessageId=" & System.Web.HttpUtility.UrlEncode(MessageID) _
                             & "&Options=" & System.Web.HttpUtility.UrlEncode(Reserve))
            ' RaiseEvent NotifyStatus(MessageID, Recipients, 0, 0, ret, Options)

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

        Protected Friend Function NotifyStatus(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, NotifyType As Integer, Status As Integer, Text As String, ByRef Reserve As String) As Integer Implements MessagerInterfaces.IMessager.NotifyStatus
            'WriteLog("收到通知:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & NotifyType & "," & Status & "," & Text)
            Return 0
        End Function

        Protected Friend Function EchoOfSendSMS(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, Status As Integer, ErrorCode As Integer, ByRef Reserve As String) As Integer Implements MessagerInterfaces.IMessager.EchoOfSendSMS
            'WriteLog("收到回执:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & Status & "," & ErrorCode)
            Return 0
        End Function
        Public Property Author As String Implements MessagerInterfaces.IMessager.Author
            Get

            End Get
            Set(value As String)

            End Set
        End Property

        Public Function CheckKeyworkds(Content As String) As Integer Implements MessagerInterfaces.IMessager.CheckKeyworkds

        End Function

        Public Property CLSID As String Implements MessagerInterfaces.IMessager.CLSID
            Get
                Return "8a6bfc03-ca7e-49c0-bf72-5c9b7ec7670d"
            End Get
            Set(value As String)

            End Set
        End Property

        Public Property Content As String Implements MessagerInterfaces.IMessager.Content
            Get

            End Get
            Set(value As String)

            End Set
        End Property



        Public Property FeeMessageLength As Integer Implements MessagerInterfaces.IMessager.FeeMessageLength
            Get

            End Get
            Set(value As Integer)

            End Set
        End Property

        Public Property InterfaceID As String Implements MessagerInterfaces.IMessager.InterfaceID
            Get
                Return "B9644867-678E-46F6-984C-4BE5E50FEDF7"
            End Get
            Set(value As String)

            End Set
        End Property

        Public Property InvockPerSecond As Long Implements MessagerInterfaces.IMessager.InvockPerSecond
            Get

            End Get
            Set(value As Long)

            End Set
        End Property

        Public Property Keywords As String Implements MessagerInterfaces.IMessager.Keywords
            Get

            End Get
            Set(value As String)

            End Set
        End Property

        Public Property LimitPerDay_CM As Long Implements MessagerInterfaces.IMessager.LimitPerDay_CM
            Get

            End Get
            Set(value As Long)

            End Set
        End Property

        Public Property LimitPerDay_TEL As Long Implements MessagerInterfaces.IMessager.LimitPerDay_TEL
            Get

            End Get
            Set(value As Long)

            End Set
        End Property

        Public Property LimitPerDay_UN As Long Implements MessagerInterfaces.IMessager.LimitPerDay_UN
            Get

            End Get
            Set(value As Long)

            End Set
        End Property

        Public Property LimitPerHour_CM As Long Implements MessagerInterfaces.IMessager.LimitPerHour_CM
            Get

            End Get
            Set(value As Long)

            End Set
        End Property

        Public Property LimitPerHour_TEL As Long Implements MessagerInterfaces.IMessager.LimitPerHour_TEL
            Get

            End Get
            Set(value As Long)

            End Set
        End Property

        Public Property LimitPerHour_UN As Long Implements MessagerInterfaces.IMessager.LimitPerHour_UN
            Get

            End Get
            Set(value As Long)

            End Set
        End Property

        Public Property LimitPerMonth_CM As Long Implements MessagerInterfaces.IMessager.LimitPerMonth_CM
            Get

            End Get
            Set(value As Long)

            End Set
        End Property

        Public Property LimitPerMonth_TEL As Long Implements MessagerInterfaces.IMessager.LimitPerMonth_TEL
            Get

            End Get
            Set(value As Long)

            End Set
        End Property

        Public Property LimitPerMonth_UN As Long Implements MessagerInterfaces.IMessager.LimitPerMonth_UN
            Get

            End Get
            Set(value As Long)

            End Set
        End Property

        Public Property MaxLength As String Implements MessagerInterfaces.IMessager.MaxLength
            Get

            End Get
            Set(value As String)

            End Set
        End Property

        Public Property MaxRecipientCount As Integer Implements MessagerInterfaces.IMessager.MaxRecipientCount
            Get

            End Get
            Set(value As Integer)

            End Set
        End Property

        Public Property MergeLimit As Boolean Implements MessagerInterfaces.IMessager.MergeLimit
            Get

            End Get
            Set(value As Boolean)

            End Set
        End Property

        Public Property MessageType As Integer Implements MessagerInterfaces.IMessager.MessageType
            Get

            End Get
            Set(value As Integer)

            End Set
        End Property



        Public Property Options As String Implements MessagerInterfaces.IMessager.Options
            Get

            End Get
            Set(value As String)

            End Set
        End Property

        Public Property Password As String Implements MessagerInterfaces.IMessager.Password
            Get

            End Get
            Set(value As String)

            End Set
        End Property



        Public Property Recipients As String Implements MessagerInterfaces.IMessager.Recipients
            Get

            End Get
            Set(value As String)

            End Set
        End Property

        Public Sub RefreshInterfaceInfo() Implements MessagerInterfaces.IMessager.RefreshInterfaceInfo

        End Sub

        Public Property RegistDate As Date Implements MessagerInterfaces.IMessager.RegistDate
            Get

            End Get
            Set(value As Date)

            End Set
        End Property

        Public Property Remark As String Implements MessagerInterfaces.IMessager.Remark
            Get

            End Get
            Set(value As String)

            End Set
        End Property


        Public Property Title As String Implements MessagerInterfaces.IMessager.Title
            Get

            End Get
            Set(value As String)

            End Set
        End Property

        Public Property Usercode As String Implements MessagerInterfaces.IMessager.Usercode
            Get

            End Get
            Set(value As String)

            End Set
        End Property


    End Class
End Namespace
