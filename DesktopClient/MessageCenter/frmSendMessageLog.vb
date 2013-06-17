Public Class frmSendMessageLog
    Public sb As New System.Text.StringBuilder
    Public Sub AddLog(Message As String)
        sb.Append(Message)
        sb.Append(vbCrLf)
        ' txtLog.Text = txtLog.Text & vbCrLf & Message
        txtLog.Text = sb.ToString
        Application.DoEvents()
    End Sub
    Private Sub frmSendMessageLog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
 
    End Sub

    Private Sub txtLog_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLog.TextChanged

    End Sub
End Class