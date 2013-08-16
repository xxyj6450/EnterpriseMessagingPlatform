<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendMessage
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSendMessage))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.nudNumberCount = New System.Windows.Forms.NumericUpDown()
        Me.txtMessage = New System.Windows.Forms.RichTextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tscb_MessageType = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.gridLog = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.rbInput = New System.Windows.Forms.RadioButton()
        Me.rbImport = New System.Windows.Forms.RadioButton()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtRecipients = New System.Windows.Forms.RichTextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssl_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_发送进度 = New System.Windows.Forms.ToolStripProgressBar()
        Me.tss_timer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_字数 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_短信条数 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.nudNumberCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.nudNumberCount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMessage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gridLog)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(930, 491)
        Me.SplitContainer1.SplitterDistance = 189
        Me.SplitContainer1.TabIndex = 0
        '
        'nudNumberCount
        '
        Me.nudNumberCount.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nudNumberCount.Location = New System.Drawing.Point(391, 4)
        Me.nudNumberCount.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.nudNumberCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNumberCount.Name = "nudNumberCount"
        Me.nudNumberCount.Size = New System.Drawing.Size(56, 21)
        Me.nudNumberCount.TabIndex = 5
        Me.nudNumberCount.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'txtMessage
        '
        Me.txtMessage.AutoWordSelection = True
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMessage.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtMessage.Location = New System.Drawing.Point(0, 31)
        Me.txtMessage.MaxLength = 300
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(930, 158)
        Me.txtMessage.TabIndex = 1
        Me.txtMessage.Text = ""
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.tscb_MessageType, Me.ToolStripLabel2, Me.ToolStripComboBox1, Me.ToolStripSeparator2, Me.ToolStripLabel3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(930, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 28)
        Me.ToolStripButton1.Text = "发送"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(58, 28)
        Me.ToolStripLabel1.Text = "消息类型:"
        '
        'tscb_MessageType
        '
        Me.tscb_MessageType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tscb_MessageType.Items.AddRange(New Object() {"短信", "邮件", "微信"})
        Me.tscb_MessageType.Name = "tscb_MessageType"
        Me.tscb_MessageType.Size = New System.Drawing.Size(75, 31)
        Me.tscb_MessageType.Text = "短信"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(34, 28)
        Me.ToolStripLabel2.Text = "接口:"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"自动", "联通SP短信", "恒讯短信"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(80, 31)
        Me.ToolStripComboBox1.Text = "自动"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(55, 28)
        Me.ToolStripLabel3.Text = "每批发送"
        '
        'gridLog
        '
        Me.gridLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader2, Me.ColumnHeader4})
        Me.gridLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridLog.FullRowSelect = True
        Me.gridLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.gridLog.Location = New System.Drawing.Point(0, 116)
        Me.gridLog.Name = "gridLog"
        Me.gridLog.Size = New System.Drawing.Size(930, 182)
        Me.gridLog.SmallImageList = Me.ImageList1
        Me.gridLog.StateImageList = Me.ImageList1
        Me.gridLog.TabIndex = 8
        Me.gridLog.UseCompatibleStateImageBehavior = False
        Me.gridLog.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "发送状态"
        Me.ColumnHeader1.Width = 90
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "发送时间"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "收件人"
        Me.ColumnHeader2.Width = 400
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "说明"
        Me.ColumnHeader4.Width = 200
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ok.ico")
        Me.ImageList1.Images.SetKeyName(1, "error.ico")
        Me.ImageList1.Images.SetKeyName(2, "right.ico")
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.rbInput, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbImport, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRecipients, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(930, 116)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'rbInput
        '
        Me.rbInput.Checked = True
        Me.rbInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbInput.Location = New System.Drawing.Point(4, 4)
        Me.rbInput.Name = "rbInput"
        Me.rbInput.Size = New System.Drawing.Size(114, 74)
        Me.rbInput.TabIndex = 2
        Me.rbInput.TabStop = True
        Me.rbInput.Text = "输入联系人(0人)"
        Me.rbInput.UseVisualStyleBackColor = True
        '
        'rbImport
        '
        Me.rbImport.Dock = System.Windows.Forms.DockStyle.Top
        Me.rbImport.Location = New System.Drawing.Point(4, 85)
        Me.rbImport.Name = "rbImport"
        Me.rbImport.Size = New System.Drawing.Size(114, 26)
        Me.rbImport.TabIndex = 4
        Me.rbImport.Text = "导入联系人"
        Me.rbImport.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.txtFileName)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(125, 85)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(801, 29)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'txtFileName
        '
        Me.txtFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileName.BackColor = System.Drawing.SystemColors.Window
        Me.txtFileName.Location = New System.Drawing.Point(3, 3)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(714, 21)
        Me.txtFileName.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(723, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "浏览文件.."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtRecipients
        '
        Me.txtRecipients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRecipients.Location = New System.Drawing.Point(125, 4)
        Me.txtRecipients.Name = "txtRecipients"
        Me.txtRecipients.Size = New System.Drawing.Size(801, 74)
        Me.txtRecipients.TabIndex = 5
        Me.txtRecipients.Text = ""
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssl_Status, Me.tssl_发送进度, Me.tss_timer, Me.tssl_字数, Me.tssl_短信条数})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 491)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(930, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssl_Status
        '
        Me.tssl_Status.Name = "tssl_Status"
        Me.tssl_Status.Size = New System.Drawing.Size(82, 17)
        Me.tssl_Status.Text = "状态:编辑短信"
        '
        'tssl_发送进度
        '
        Me.tssl_发送进度.Name = "tssl_发送进度"
        Me.tssl_发送进度.Size = New System.Drawing.Size(100, 16)
        Me.tssl_发送进度.Step = 1
        Me.tssl_发送进度.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tssl_发送进度.Visible = False
        '
        'tss_timer
        '
        Me.tss_timer.Name = "tss_timer"
        Me.tss_timer.Size = New System.Drawing.Size(26, 17)
        Me.tss_timer.Text = "0秒"
        Me.tss_timer.Visible = False
        '
        'tssl_字数
        '
        Me.tssl_字数.Name = "tssl_字数"
        Me.tssl_字数.Size = New System.Drawing.Size(752, 17)
        Me.tssl_字数.Spring = True
        Me.tssl_字数.Text = "已录入:00字"
        Me.tssl_字数.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tssl_短信条数
        '
        Me.tssl_短信条数.Name = "tssl_短信条数"
        Me.tssl_短信条数.Size = New System.Drawing.Size(81, 17)
        Me.tssl_短信条数.Text = "共计00条短信"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmSendMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 513)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSendMessage"
        Me.Text = "发送消息"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.nudNumberCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbInput As System.Windows.Forms.RadioButton
    Friend WithEvents rbImport As System.Windows.Forms.RadioButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tssl_Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssl_字数 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssl_短信条数 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssl_发送进度 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tss_timer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents tscb_MessageType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents gridLog As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents nudNumberCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtRecipients As System.Windows.Forms.RichTextBox
End Class
