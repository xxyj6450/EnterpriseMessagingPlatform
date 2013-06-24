Imports System.Attribute
<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Interface)>
Public NotInheritable Class MessagerAttribute
    Inherits System.Attribute
    Private _Author As String
    Private _InterfaceID As String
    Private _Description As String
    Private _RegisterDate As Date
    Private _MessageType As Integer
    Private _Name As String

    Public Sub New(InterfaceID As String, MessageType As Integer, Name As String, Author As String, Description As String)
        _InterfaceID = InterfaceID
        _MessageType = MessageType
        _Author = Author
        _Description = Description
        _Name = Name

    End Sub
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property
    Public Property Author As String
        Get
            Return _Author
        End Get
        Set(value As String)
            _Author = value
        End Set
    End Property


    Public Property InterfaceID As String
        Get
            Return _InterfaceID
        End Get
        Set(value As String)
            _InterfaceID = value
        End Set
    End Property

    Public Property Description As String
        Get
            Return _Description
        End Get
        Set(value As String)
            _Description = value
        End Set
    End Property
    Public Property MessageType As Integer
        Get
            Return _MessageType
        End Get
        Set(value As Integer)
            _MessageType = value
        End Set
    End Property

     
End Class
