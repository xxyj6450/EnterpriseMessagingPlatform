Imports System.Threading
Imports System.Runtime.Remoting.Messaging
Public Class frmSendMessage
    Private _time As Long
    Private _progress As Long
    Private _ThreadCount As Integer
    Private _ThreadCount_Fact As Integer
    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ToolStripLabel1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim FileName As String
        Me.rbInput.Checked = False
        Me.rbImport.Checked = True
        With Me.OpenFileDialog1

            .Filter = "文本文件|*.txt"
            .AddExtension = True
            .SupportMultiDottedExtensions = True
            .Title = "导入收件人"
            .Multiselect = False
            .FileName = "*.txt"
            .ShowDialog()
            FileName = .FileName
            If FileName <> "" And Me.OpenFileDialog1.CheckFileExists() Then txtFileName.Text = FileName
        End With

    End Sub

    Private Sub txtMessage_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMessage.TextChanged
        Me.tssl_字数.Text = "已输入" & txtMessage.TextLength & "字"
        Me.tssl_短信条数.Text = "共计" & txtMessage.TextLength \ 70 + 1 & "条短信"
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dim Recipients() As String, Start As Integer, Recipient As String, i As Long
        Dim SendSMS As SendMessage_Delegate
        Dim MessageInfo As MessageInfo
        If txtMessage.Text = "" Then MsgBox("请先输入消息内容后再发送.", vbInformation, "发送消息") : txtMessage.Focus() : Return
        If txtRecipients.Text = "" And rbInput.Checked Then MsgBox("请先输入收件人(每行一个)后再发送.", vbInformation, "发送消息") : txtRecipients.Focus() : Return
        If txtFileName.Text = "" And rbImport.Checked Then MsgBox("请先指定收件人文件后再发送.", vbInformation, "发送消息") : Return
        If MsgBox("执行发送消息可能产生费用,您确认要继续操作吗?", vbQuestion + vbYesNo, "确认发送") = vbNo Then Return
        'frmSendMessageLog.Show()
        'frmSendMessageLog.txtLog.Text = ""
        'frmSendMessageLog.sb.Remove(0, frmSendMessageLog.sb.Length)
        Me.tssl_Status.Text = "正在发送消息..."
        gridLog.Items.Clear()
        _ThreadCount = 0
        _ThreadCount_Fact = 0
        _time = 0
        _progress = 0
        Me.tssl_发送进度.Visible = True
        Me.tss_timer.Visible = True
        Me.Timer1.Enabled = True
        Me.ToolStripButton1.Enabled = False
        If Me.rbImport.Checked = True Then
            Using fs As New System.IO.StreamReader(txtFileName.Text)
                Do While fs.EndOfStream = False

                    Recipient = getNumbers(fs, nudNumberCount.Value, 0)

                    If Recipient <> "" Then
                        i = i + 1
                        SendSMS = New SendMessage_Delegate(AddressOf SendMessage)
                        MessageInfo = New MessageInfo(Recipient, "等待发送", "", Now)
                        AddListView(MessageInfo)
                        SendSMS.BeginInvoke(Recipient, txtMessage.Text, New AsyncCallback(AddressOf SendMessage_Compeleted), MessageInfo)
                    End If
                Loop


            End Using
        Else
            Recipients = System.Text.RegularExpressions.Regex.Split(txtRecipients.Text, "\s+|,", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Multiline Or System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace) 'txtRecipients.Text.Split(New Char() {Chr(10), Chr(13)}, StringSplitOptions.RemoveEmptyEntries)
            Start = 0
            Do Until 0

                Recipient = getNumbers(Recipients, nudNumberCount.Value, Start)
                Start = Start + nudNumberCount.Value

                If Recipient <> "" Then
                    i = i + 1
                    SendSMS = New SendMessage_Delegate(AddressOf SendMessage)
                    MessageInfo = New MessageInfo(Recipient, "等待发送", "", Now)
                    AddListView(MessageInfo)
                    SendSMS.BeginInvoke(Recipient, txtMessage.Text, New AsyncCallback(AddressOf SendMessage_Compeleted), MessageInfo)
                End If
                If Recipient = "" Then Exit Do
            Loop

        End If
        _ThreadCount_Fact = i
    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub rbInput_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbInput.CheckedChanged
        If rbInput.Checked = True Then rbImport.Checked = False
    End Sub

    Private Sub txtFileName_GotFocus(sender As Object, e As System.EventArgs) Handles txtFileName.GotFocus
        Me.rbInput.Checked = False
        Me.rbImport.Checked = True
    End Sub

    Private Sub txtFileName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFileName.TextChanged

    End Sub

    Private Sub rbImport_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbImport.CheckedChanged
        If rbImport.Checked = True Then rbInput.Checked = False
    End Sub

    Private Sub frmSendMessage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        txtMessage.Focus()
    End Sub
    Public Delegate Function SendMessage_Delegate(Recipients As String, Message As String) As Integer
    Public Function SendMessage(Recipients As String, Message As String) As Integer
        Dim ws As New MessageGateway.MessageGatewayService
        Dim ret As Integer
        ret = ws.SendMessage("admin", "lkmojupdfe", Recipients, 1, "", Message, 0, True, 1)
        'Thread.Sleep(1000)
        Return 0
    End Function
    Private Function SendMessage_Compeleted(itfAR As IAsyncResult) As Integer
        Dim ar As AsyncResult = CType(itfAR, AsyncResult)
        Dim SendSMS As SendMessage_Delegate = ar.AsyncDelegate, ret As Integer
        Dim Message As String, i As Integer
        Dim rwLock As New System.Threading.ReaderWriterLock
        Dim msgInfo As MessageInfo
        msgInfo = CType(ar.AsyncState, MessageInfo)
        Try
            ret = SendSMS.EndInvoke(ar)
            If ret = 0 Then
                msgInfo.Status = "发送成功"
            Else
                msgInfo.Status = "发送失败"
                msgInfo.ErrorText = ret
            End If
        Catch ex As Exception
            msgInfo.Status = "发送失败"
            msgInfo.ErrorText = ex.Message
        Finally
            rwLock.AcquireReaderLock(100)
            _ThreadCount = _ThreadCount + 1
            rwLock.ReleaseReaderLock()
            Me.Invoke(New Report_Delegate(AddressOf Report), msgInfo)
            If _ThreadCount >= _ThreadCount_Fact And _ThreadCount_Fact <> 0 Then

                Me.BeginInvoke(New Report_Delegate(AddressOf Callback_Compelted), MessageInfo.SharedObject)
            End If

        End Try
        Return 0
    End Function
    Private Delegate Function Report_Delegate(Message As MessageInfo) As Integer
    Private Function Callback_Compelted(Message As MessageInfo) As Integer
        Me.Timer1.Enabled = False
        Me.tssl_发送进度.Visible = False
        Me.tss_timer.Visible = False
        Me.ToolStripButton1.Enabled = True
        Me.tssl_Status.Text = "发送完毕."
        'MsgBox("发送完毕")
    End Function
    Private Function Report(Message As MessageInfo) As Integer
        For Each Item As Windows.Forms.ListViewItem In gridLog.Items
            If Item.Tag = Message.MessageID Then
                Item.StateImageIndex = IIf(Message.Status = "发送成功", 0, 1)
                Item.Text = Message.Status
                Item.SubItems(1).Text = Now
                Item.SubItems(3).Text = Message.ErrorText

            End If
        Next
    End Function
    '从文件中读取号码
    Public Function getNumbers(fs As System.IO.StreamReader, Count As Integer, Optional Start As Integer = 0) As String
        Dim i As Long = 1, s As New System.Text.StringBuilder
        If fs.EndOfStream = True Then Return ""
        While fs.EndOfStream = False And i <= Count
            s.Append(Trim(fs.ReadLine))
            s.Append(";")
            i = i + 1
        End While
        Return s.ToString
    End Function
    '从收件人中读号码
    Public Function getNumbers(Recipients() As String, Count As Integer, Optional Start As Integer = 0) As String
        If Start >= Recipients.Length Then Return ""
        If Start + Count > Recipients.Length Then Count = Recipients.Length - Start
        Return String.Join(";", Recipients, Start, Count)

    End Function
 
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        _time = _time + 1
        _progress = (_progress + 1) Mod 100
        Me.tssl_发送进度.Value = _progress
        Me.tss_timer.Text = _time & "秒"
    End Sub

    Private Sub AddListView(_MessageInfo As MessageInfo)
        Dim item As Windows.Forms.ListViewItem
        With Me.gridLog

            item = .Items.Add(_MessageInfo.Status)
            item.StateImageIndex = 2
            item.Tag = _MessageInfo.MessageID
            item.SubItems.Add(Now)
            item.SubItems.Add(_MessageInfo.Recipients)
            item.SubItems.Add("")

        End With
    End Sub

    Private Sub txtRecipients_GotFocus(sender As Object, e As System.EventArgs) Handles txtRecipients.GotFocus
        Me.rbInput.Checked = True
        Me.rbImport.Checked = False
    End Sub

    Private Sub txtRecipients_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRecipients.TextChanged
        rbInput.Text = "输入联系人(已输入" & System.Text.RegularExpressions.Regex.Split(txtRecipients.Text, "\s+|,", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Multiline Or System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace).Length & "人)"
    End Sub
End Class