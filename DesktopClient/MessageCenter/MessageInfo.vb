Public Class MessageInfo
    Private _MessageID As String
    Private _Recipients As String
    Private _Status As String
    Private _ErrorText As String
    Private _SendDate As Date
    Private _SharedObject As MessageInfo
    Public Sub New()
        _MessageID = Guid.NewGuid().ToString
        If Not (_SharedObject Is Nothing) Then _SharedObject = New MessageInfo()
    End Sub
    Public Sub New(m_Recipients As String, m_Status As String, m_ErrorText As String, m_SendDate As Date)
        _MessageID = Guid.NewGuid().ToString
        _Recipients = m_Recipients
        _Status = m_Status
        _ErrorText = m_ErrorText
        _SendDate = m_SendDate
        If Not (_SharedObject Is Nothing) Then _SharedObject = New MessageInfo()
    End Sub
    Public Property MessageID As String
        Get
            Return _MessageID
        End Get
        Set(value As String)
            _MessageID = value
        End Set
    End Property
    Public Property Recipients As String
        Get
            Return _Recipients
        End Get
        Set(value As String)
            _Recipients = value
        End Set
    End Property
    Public Property Status As String
        Get
            Return _Status
        End Get
        Set(value As String)
            _Status = value
        End Set
    End Property
    Public Property ErrorText As String
        Get
            Return _ErrorText
        End Get
        Set(value As String)
            _ErrorText = value
        End Set
    End Property
    Public Property SendDate As Date
        Get
            Return _SendDate
        End Get
        Set(value As Date)
            _SendDate = value
        End Set
    End Property
    Public Shared ReadOnly Property SharedObject() As MessageInfo
        Get

        End Get
 
    End Property
End Class
