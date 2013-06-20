Namespace MessagerInterfaces
    Public Interface IMessager
        Property InterfaceID As String                          '接口ID 各个短信接口在系统注册后都分配一个接口ID
        Property CLSID As String                                'CLSID
        Property MessageType As Integer                         '表示此接口发送哪种消息
        Property Author As String                               '作者
        Property RegistDate As DateTime                         '注册时间
        Property Remark As String                               '备注信息
        Property Usercode As String                             '发送消息使用的用户名,可以在发送消息时指定,也可以这里指定
        Property Password As String                             '发送消息使用的密码,可以在发送消息时指定,也可以这里指定
        Property Title As String
        Property Content As String
        Property Recipients As String
        Property Options As String
        Property InvockPerSecond As Long                        '每秒调用次数
        Property MaxLength As String                            '短信最大长度
        Property MaxRecipientCount As Integer                   '最大短信接收人数量
        Property LimitPerDay_UN As Long                         '联通日短信量限制
        Property LimitPerHour_UN As Long                        '联通时短信量限制
        Property LimitPerMonth_UN As Long
        Property LimitPerDay_TEL As Long                        '电信日短信量限制
        Property LimitPerHour_TEL As Long                       '电信时短信量限制
        Property LimitPerMonth_TEL As Long
        Property LimitPerDay_CM As Long                         '移动日短信量限制
        Property LimitPerHour_CM As Long                        '移动时短信量限制
        Property LimitPerMonth_CM As Long
        Property MergeLimit As Boolean                          '是否合并运营商限制，即不分运营商限制
        Property FeeMessageLength As Integer                    '收费短信字符长度 即每条短信按多少个字符算一条短信
        Property Keywords As String                             '关键字列表
        ''' <summary>
        ''' 发送消息，对消息发送者身份支持二级验证
        ''' </summary>
        ''' <param name="MessageID">由调用生成的消息ID</param>
        ''' <param name="NodeUsercode">发送消息的主节点ID</param>
        ''' <param name="NodePassword">发送消息的主节点密码</param>
        ''' <param name="Usercode">发送消息者的系统用户名</param>
        ''' <param name="Password">发送消息者的系统用户密码</param>
        ''' <param name="Title">标题</param>
        ''' <param name="Sender">接收者显示的发送人</param>
        ''' <param name="Content">内容</param>
        ''' <param name="Format">格式</param>
        ''' <param name="Recipients">接收人，多个用分号分开</param>
        ''' <param name="Reserve">保留</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function SendMessage(ByRef MessageID As String, NodeUsercode As String, NodePassword As String, Usercode As String, Password As String, Sender As String, SenderName As String, _
                             Title As String, Content As String, Format As Integer, Recipients As String, CC As String, Bcc As String, ByRef Reserve As String) As String
        ''' <summary>
        ''' 接收消息
        ''' </summary>
        ''' <param name="SequenceNo">接收消息的队列ID</param>
        ''' <param name="Recipients">接收人</param>
        ''' <param name="Sender">发送人</param>
        ''' <param name="Title">标题</param>
        ''' <param name="Content">正文</param>
        ''' <param name="RecieveTime">接收时间</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function RecieveMessage(Reciver As String, SequenceNo As String, Recipients As String, From As String, Sender As String, Title As String, Content As String, Format As Integer, RecieveTime As DateTime) As Integer
        ''' <summary>
        ''' </summary>
        ''' <param name="MessageID"></param>
        ''' <param name="Recipient"></param>
        ''' <param name="NotifyType"></param>
        ''' <param name="Status"></param>
        ''' <param name="Text"></param>
        ''' <param name="Reserve"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function NotifyStatus(Reciver As String, SequenceNo As String, MessageID As String, Recipient As String, NotifyType As Integer, Status As Integer, Text As String, ByRef Reserve As String) As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="SequenceNo"></param>
        ''' <param name="MessageID"></param>
        ''' <param name="Recipient"></param>
        ''' <param name="Status"></param>
        ''' <param name="ErrorCode"></param>
        ''' <param name="Reserve"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function EchoOfSendSMS(Reciver As String, SequenceNo As String, MessageID As String, Recipient As String, Status As Integer, ErrorCode As Integer, ByRef Reserve As String) As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Content"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CheckKeyworkds(Content As String) As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Sub RefreshInterfaceInfo()
    End Interface
End Namespace
