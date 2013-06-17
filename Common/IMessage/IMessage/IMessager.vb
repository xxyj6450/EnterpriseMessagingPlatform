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
    'Event NotifyStatus(MessageID As String, Recipients As String, NotifyType As Integer, Notify As String, Status As Integer, Param As Object)
    Function SendMessage(ByRef MessageID As String, Usercode As String, Password As String, Title As String, Content As String, Recipients As String, ByRef Reserve As String) As Integer
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="SPNumber"></param>
    ''' <param name="RecieveNumber"></param>
    ''' <param name="Sender"></param>
    ''' <param name="Content"></param>
    ''' <param name="RecieveTime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function RecieveMessage(SPNumber As String, RecieveNumber As String, Sender As String, Content As String, RecieveTime As DateTime) As Integer
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="SPNumber"></param>
    ''' <param name="SequenceNo"></param>
    ''' <param name="MessageID"></param>
    ''' <param name="Recipient"></param>
    ''' <param name="NotifyType"></param>
    ''' <param name="Status"></param>
    ''' <param name="Text"></param>
    ''' <param name="Reserve"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function NotifyStatus(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, NotifyType As Integer, Status As Integer, Text As String, ByRef Reserve As String) As Integer
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="SPNumber"></param>
    ''' <param name="SequenceNo"></param>
    ''' <param name="MessageID"></param>
    ''' <param name="Recipient"></param>
    ''' <param name="Status"></param>
    ''' <param name="ErrorCode"></param>
    ''' <param name="Reserve"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function EchoOfSendSMS(SPNumber As String, SequenceNo As String, MessageID As String, Recipient As String, Status As Integer, ErrorCode As Integer, ByRef Reserve As String) As Integer
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
