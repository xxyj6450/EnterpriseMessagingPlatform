Public Class MessagerFactory
    'Interfaces存储了
    Private Interfaces As System.Collections.Generic.Dictionary(Of String, String)
    '根据接口ID创建消息发送对象
    Public Shared Function CreateMessager(InterfaceID As String) As IMessage.IMessager
        Select Case InterfaceID
            Case "B9644867-678E-46F6-984C-4BE5E50FEDF7"
                Return New Object
            Case "68A36DF0-0C4A-407E-98E1-33C0D0077804"
                Return New Object
            Case Else
                Throw New Exception("接口不存在,无法发送消息")
                Return Nothing
        End Select

    End Function
    Public Shared Function CreateMessagerByName(InterfaceName As String) As IMessage.IMessager
        Return New Object
    End Function
End Class
