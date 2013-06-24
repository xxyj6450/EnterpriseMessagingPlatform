Public Class MessagerInfo
    Private _InterfaceID As String
    Private _Asm As System.Reflection.Assembly
    Private _asmName As String
    Private _Type As System.Type
    Private _Attribute As MessagerAttribute
    Private _Path As String
    Public Sub New(m_InterfaceID As String, m_Type As System.Type, Attribute As MessagerAttribute, Path As String)
        _InterfaceID = m_InterfaceID
        _Asm = m_Type.Assembly
        _Attribute = Attribute
        _Type = m_Type
        _Path = Path
    End Sub

    Public Property InterfaceID As String
        Get
            Return _InterfaceID
        End Get
        Set(value As String)
            _InterfaceID = value
        End Set
    End Property
    Public Property Path As String
        Get
            Return _Path
        End Get
        Set(value As String)
            _Path = value
        End Set
    End Property
    Public Property Attribute As MessagerAttribute
        Get
            Return _Attribute
        End Get
        Set(value As MessagerAttribute)
            _Attribute = value
        End Set
    End Property
    Public Property AssemblyInfo As System.Reflection.Assembly
        Get
            Return _Asm
        End Get
        Set(value As System.Reflection.Assembly)
            _Asm = value
        End Set
    End Property
    Public Property AssemblyName As String
        Get
            Return _asmName
        End Get
        Set(value As String)
            _asmName = value
        End Set
    End Property
    Public Property Type As System.Type
        Get
            Return _Type
        End Get
        Set(value As System.Type)
            _Type = value
        End Set
    End Property
    Public Function getInstance() As EMP.MessagerInterfaces.IMessager
        If Not (_Asm Is Nothing) Then
            Return _Asm.CreateInstance(_Type.FullName, True)
        Else
            Return Nothing
        End If
    End Function
End Class
