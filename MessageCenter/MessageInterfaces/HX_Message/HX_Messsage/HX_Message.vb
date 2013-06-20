Imports System.Data
Imports System.Data.SqlClient
Namespace Messsager
    Public Class HX_Message
        Implements MessagerInterfaces.IMessager


        Protected Friend Function RecieveMessage(Reciver As String, SequenceNo As String, Recipients As String, From As String, Sender As String, Title As String, Content As String, Format As Integer, RecieveTime As Date) As Integer Implements MessagerInterfaces.IMessager.RecieveMessage

        End Function

        Public Function SendMessage(ByRef MessageID As String, NodeUsercode As String, NodePassword As String, Usercode As String, Password As String, Sender As String, SenderName As String, Title As String, Content As String, Format As Integer, Recipients As String, CC As String, Bcc As String, ByRef Reserve As String) As String Implements MessagerInterfaces.IMessager.SendMessage
            Return SendMessage(MessageID, Usercode, Password, Content, Recipients, Reserve)
        End Function
        Public Function SendMessage(ByRef MessageID As String, Usercode As String, Password As String, Content As String, Recipients As String, ByRef Reserve As String) As Integer
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