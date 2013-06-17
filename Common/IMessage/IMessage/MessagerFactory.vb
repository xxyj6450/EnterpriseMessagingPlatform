Public Class MessagerFactory
    '根据接口ID创建消息发送对象
    Public Shared Function CreateMessager(InterfaceID As String) As IMessager
        Select Case InterfaceID
            Case "B9644867-678E-46F6-984C-4BE5E50FEDF7"
                Return New SP_Message
            Case "68A36DF0-0C4A-407E-98E1-33C0D0077804"
                Return New HX_Message
            Case Else
                Throw New Exception("接口不存在,无法发送消息")
                Return Nothing
        End Select

    End Function
End Class
