Public Class SP_Message
    Implements IMessage.IMessager
     
    Private Const SP_Message_URL As String = "http://192.168.88.53:8080/JtSgip/JTMessageSend.jsp"
    Protected Friend Function RecieveMessage(Reciver As String, SequenceNo As String, Recipients As String, From As String, Sender As String, Title As String, Content As String, Format As Integer, RecieveTime As Date) As Integer Implements IMessage.IMessager.RecieveMessage

    End Function

    Public Function SendMessage(ByRef MessageID As String, NodeUsercode As String, NodePassword As String, Usercode As String, Password As String, Sender As String, Title As String, Content As String, Format As Integer, Recipients As String, CC As String, Bcc As String, ByRef Reserve As String) As String Implements IMessage.IMessager.SendMessage
        Return SendMessage(MessageID, Usercode, Password, Content, Recipients, Reserve)
    End Function
    Public Function SendMessage(ByRef MessageID As String, Usercode As String, Password As String, Content As String, Recipients As String, ByRef Reserve As String) As Integer
        'http://192.168.88.53:8080/WebSgip/MessageSendPage.jsp?SendTelList=18688639997&SendContext=%E6%B5%8B%E8%AF%95%E7%9F%AD%E4%BF%A1
        Dim url As String, ret As String
        If System.Configuration.ConfigurationManager.AppSettings("SP_Message_URL") = "" Then
            System.Configuration.ConfigurationManager.AppSettings("SP_Message_URL") = SP_Message_URL
        End If
        url = System.Configuration.ConfigurationManager.AppSettings("SP_Message_URL")
        Try
            ret = RequestWEB(url, "SendTelList=" & System.Web.HttpUtility.UrlEncode(Recipients) _
                             & "&SendContext=" & System.Web.HttpUtility.UrlEncode(Content) _
                             & "&Usercode=" & System.Web.HttpUtility.UrlEncode(Usercode) _
                             & "&Password=" & System.Web.HttpUtility.UrlEncode(Password) _
                             & "&Options=" & System.Web.HttpUtility.UrlEncode(Reserve))
            ' RaiseEvent NotifyStatus(MessageID, Recipients, 0, 0, ret, Options)
            Return 0
        Catch ex As Exception
            'RaiseEvent NotifyStatus(MessageID, Recipients, 0, -8, ex.Message, Options)
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

    Protected Friend Function NotifyStatus(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, NotifyType As Integer, Status As Integer, Text As String, ByRef Reserve As String) As Integer Implements IMessage.IMessager.NotifyStatus
        'WriteLog("收到通知:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & NotifyType & "," & Status & "," & Text)
        Return 0
    End Function

    Protected Friend Function EchoOfSendSMS(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, Status As Integer, ErrorCode As Integer, ByRef Reserve As String) As Integer Implements IMessage.IMessager.EchoOfSendSMS
        'WriteLog("收到回执:" & SPNumber & "," & SequenceNo & "," & MessageID & "," & Recipient & "," & Status & "," & ErrorCode)
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
            Return "8a6bfc03-ca7e-49c0-bf72-5c9b7ec7670d"
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
            Return "B9644867-678E-46F6-984C-4BE5E50FEDF7"
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

   
End Class
