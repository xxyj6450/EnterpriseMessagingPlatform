Imports System.Reflection
Imports System.Threading
Imports log4net
Public Class MessagerFactory
    Private Shared log As log4net.ILog = log4net.LogManager.GetLogger("SendProgress")
    'Interfaces存储了
    Public Shared Interfaces As New System.Collections.Generic.Dictionary(Of String, EMP.MessagerInfo)
    '根据接口ID创建消息发送对象
    Public Shared Function CreateMessager(InterfaceID As String) As EMP.MessagerInterfaces.IMessager

        If Interfaces.Count = 0 Then
            RefreshInterface()
        End If
        If Interfaces.ContainsKey(InterfaceID.ToUpper) Then
            Return Interfaces(InterfaceID.ToUpper).getInstance()
        Else
            Throw New Exception("指定的接口不存在，无法创建消息对象")
        End If

    End Function
    Public Shared Function CreateMessagerByName(InterfaceName As String) As EMP.MessagerInterfaces.IMessager
        Return New Object
    End Function
    Public Shared Sub RefreshInterface()

        Dim path As String
        SyncLock Interfaces
            Interfaces.Clear()
            '搜索工作目录
            Try
                SearchPath(System.IO.Directory.GetCurrentDirectory)
            Catch ex As Exception

            End Try
            Try
                '搜索Lib目录,如果存在的话
                SearchPath("\")
            Catch ex As Exception

            End Try
            Try
                '搜索bin目录,如果存在的话
                SearchPath(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString())
            Catch ex As Exception
                
            End Try

        End SyncLock
    End Sub
    Private Shared Sub SearchPath(Path As String)
        Dim asm As Assembly
        For Each file As String In My.Computer.FileSystem.GetFiles(Path, FileIO.SearchOption.SearchAllSubDirectories)
            log.Info("扫描文件" & file)
            If file Like "*\EMP.Messager.*.dll" Then
                Try
                    asm = System.Reflection.Assembly.LoadFrom(file)
                    For Each type As System.Type In asm.GetTypes
                        If (type.GetInterface("EMP.MessagerInterfaces.IMessager") IsNot Nothing) And type.IsClass Then
                            'Dim InterfaceID = 'type.InvokeMember("InterfaceID", BindingFlags.IgnoreCase Or BindingFlags.GetProperty, Nothing, Nothing, Nothing)
                            Dim atts() As EMP.MessagerAttribute = type.GetCustomAttributes(GetType(EMP.MessagerAttribute), False)
                            If atts IsNot Nothing AndAlso atts.Length > 0 Then
                                Dim InterfaceID As String = atts(0).InterfaceID.ToUpper
                                If Interfaces.ContainsKey(InterfaceID) = False Then Interfaces.Add(InterfaceID, New EMP.MessagerInfo(InterfaceID, type, atts(0), Path))
                            End If

                            'Dim att As EMP.MessagerAttribute = CType(Attribute.GetCustomAttribute(asm, GetType(EMP.MessagerAttribute)), EMP.MessagerAttribute)

                        End If
                    Next
                Catch ex As Exception
                    My.Application.Log.WriteException(New Exception("加载程序集" & file & "失败" & vbCrLf & ex.Message))
                    Continue For
                End Try
            End If
        Next
    End Sub
End Class
