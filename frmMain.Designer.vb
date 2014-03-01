<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lstCodes = New System.Windows.Forms.ListBox()
        Me.tmrBruteforce = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCodeCount = New System.Windows.Forms.Label()
        Me.lstDebug = New System.Windows.Forms.ListBox()
        Me.chkBruteforceWithUsedCodes = New System.Windows.Forms.CheckBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnClearLog = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.ContextMenuStripLoad = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnSave = New System.Windows.Forms.Button()
        Me.chkAskStartOver = New System.Windows.Forms.CheckBox()
        Me.txtInterval = New System.Windows.Forms.TextBox()
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkReverseBruteforce = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodeListFile = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.tmrDelayTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblPage = New System.Windows.Forms.Label()
        Me.btnConfig = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.tmrDurationUpdater = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstCodes
        '
        Me.lstCodes.FormattingEnabled = True
        Me.lstCodes.Location = New System.Drawing.Point(12, 113)
        Me.lstCodes.Name = "lstCodes"
        Me.lstCodes.Size = New System.Drawing.Size(81, 381)
        Me.lstCodes.TabIndex = 1
        '
        'tmrBruteforce
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Interval (ms):"
        '
        'lblCodeCount
        '
        Me.lblCodeCount.AutoSize = True
        Me.lblCodeCount.Location = New System.Drawing.Point(9, 497)
        Me.lblCodeCount.Name = "lblCodeCount"
        Me.lblCodeCount.Size = New System.Drawing.Size(13, 13)
        Me.lblCodeCount.TabIndex = 4
        Me.lblCodeCount.Text = "0"
        '
        'lstDebug
        '
        Me.lstDebug.FormattingEnabled = True
        Me.lstDebug.Location = New System.Drawing.Point(99, 113)
        Me.lstDebug.Name = "lstDebug"
        Me.lstDebug.Size = New System.Drawing.Size(224, 381)
        Me.lstDebug.TabIndex = 5
        '
        'chkBruteforceWithUsedCodes
        '
        Me.chkBruteforceWithUsedCodes.AutoSize = True
        Me.chkBruteforceWithUsedCodes.Location = New System.Drawing.Point(165, 12)
        Me.chkBruteforceWithUsedCodes.Name = "chkBruteforceWithUsedCodes"
        Me.chkBruteforceWithUsedCodes.Size = New System.Drawing.Size(144, 17)
        Me.chkBruteforceWithUsedCodes.TabIndex = 7
        Me.chkBruteforceWithUsedCodes.Text = "Bruteforce with Code List"
        Me.ToolTip1.SetToolTip(Me.chkBruteforceWithUsedCodes, "Start bruteforcing with the already used codes list in backwards.")
        Me.chkBruteforceWithUsedCodes.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "codes"
        Me.OpenFileDialog1.Filter = "Code files|*.codes|All files|*.*"
        Me.OpenFileDialog1.Title = "Select a code list to open!"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "codes"
        Me.SaveFileDialog1.Filter = "Code files|*.codes|All files|*.*"
        '
        'btnClearLog
        '
        Me.btnClearLog.Image = CType(resources.GetObject("btnClearLog.Image"), System.Drawing.Image)
        Me.btnClearLog.Location = New System.Drawing.Point(233, 500)
        Me.btnClearLog.Name = "btnClearLog"
        Me.btnClearLog.Size = New System.Drawing.Size(90, 30)
        Me.btnClearLog.TabIndex = 11
        Me.btnClearLog.Text = "Clear Debug"
        Me.btnClearLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClearLog.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.ContextMenuStrip = Me.ContextMenuStripLoad
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.Location = New System.Drawing.Point(212, 7)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(37, 26)
        Me.btnLoad.TabIndex = 21
        Me.ToolTip1.SetToolTip(Me.btnLoad, "Load Codes")
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'ContextMenuStripLoad
        '
        Me.ContextMenuStripLoad.Name = "ContextMenuStripLoad"
        Me.ContextMenuStripLoad.Size = New System.Drawing.Size(61, 4)
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(249, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(37, 26)
        Me.btnSave.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.btnSave, "Save Codes")
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'chkAskStartOver
        '
        Me.chkAskStartOver.AutoSize = True
        Me.chkAskStartOver.Checked = Global.SSKeypadBruteforcer.My.MySettings.Default.askstartover
        Me.chkAskStartOver.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.SSKeypadBruteforcer.My.MySettings.Default, "askstartover", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkAskStartOver.Location = New System.Drawing.Point(9, 35)
        Me.chkAskStartOver.Name = "chkAskStartOver"
        Me.chkAskStartOver.Size = New System.Drawing.Size(107, 17)
        Me.chkAskStartOver.TabIndex = 18
        Me.chkAskStartOver.Text = "Ask to Start Over"
        Me.ToolTip1.SetToolTip(Me.chkAskStartOver, "Whether to display a prompt asking to Start Over or not. Check by default.")
        Me.chkAskStartOver.UseVisualStyleBackColor = True
        '
        'txtInterval
        '
        Me.txtInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInterval.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.SSKeypadBruteforcer.My.MySettings.Default, "interval", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtInterval.Location = New System.Drawing.Point(79, 13)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(44, 21)
        Me.txtInterval.TabIndex = 2
        Me.txtInterval.Text = Global.SSKeypadBruteforcer.My.MySettings.Default.interval
        Me.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtInterval, "Interval in miliseconds to generate and send a new code." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Insert a bigger value i" & _
                "f you have a slow computer/low fps.")
        '
        'btnRestart
        '
        Me.btnRestart.BackColor = System.Drawing.SystemColors.Control
        Me.btnRestart.Enabled = False
        Me.btnRestart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestart.Image = CType(resources.GetObject("btnRestart.Image"), System.Drawing.Image)
        Me.btnRestart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRestart.Location = New System.Drawing.Point(142, 500)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(90, 30)
        Me.btnRestart.TabIndex = 19
        Me.btnRestart.Text = "Restart"
        Me.btnRestart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRestart.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Code list:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(96, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Debug Window:"
        '
        'chkReverseBruteforce
        '
        Me.chkReverseBruteforce.AutoSize = True
        Me.chkReverseBruteforce.Enabled = False
        Me.chkReverseBruteforce.Location = New System.Drawing.Point(165, 32)
        Me.chkReverseBruteforce.Name = "chkReverseBruteforce"
        Me.chkReverseBruteforce.Size = New System.Drawing.Size(129, 17)
        Me.chkReverseBruteforce.TabIndex = 17
        Me.chkReverseBruteforce.Text = "Bruteforce in Reverse"
        Me.chkReverseBruteforce.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Code List:"
        '
        'txtCodeListFile
        '
        Me.txtCodeListFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodeListFile.Location = New System.Drawing.Point(64, 9)
        Me.txtCodeListFile.Name = "txtCodeListFile"
        Me.txtCodeListFile.Size = New System.Drawing.Size(142, 21)
        Me.txtCodeListFile.TabIndex = 19
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkAskStartOver)
        Me.GroupBox2.Controls.Add(Me.chkBruteforceWithUsedCodes)
        Me.GroupBox2.Controls.Add(Me.chkReverseBruteforce)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtInterval)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(314, 55)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Bruteforce Options:"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(276, 97)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(29, 13)
        Me.lblTime.TabIndex = 24
        Me.lblTime.Text = "Time"
        '
        'tmrDelayTimer
        '
        Me.tmrDelayTimer.Interval = 1
        '
        'lblPage
        '
        Me.lblPage.AutoSize = True
        Me.lblPage.Location = New System.Drawing.Point(9, 514)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(44, 13)
        Me.lblPage.TabIndex = 25
        Me.lblPage.Text = "Page: 1"
        '
        'btnConfig
        '
        Me.btnConfig.Image = CType(resources.GetObject("btnConfig.Image"), System.Drawing.Image)
        Me.btnConfig.Location = New System.Drawing.Point(286, 7)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(37, 26)
        Me.btnConfig.TabIndex = 20
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Enabled = False
        Me.btnUp.Image = CType(resources.GetObject("btnUp.Image"), System.Drawing.Image)
        Me.btnUp.Location = New System.Drawing.Point(94, 500)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(24, 30)
        Me.btnUp.TabIndex = 26
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Enabled = False
        Me.btnDown.Image = CType(resources.GetObject("btnDown.Image"), System.Drawing.Image)
        Me.btnDown.Location = New System.Drawing.Point(117, 500)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(24, 30)
        Me.btnDown.TabIndex = 27
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'tmrDurationUpdater
        '
        Me.tmrDurationUpdater.Interval = 1000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 536)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.btnRestart)
        Me.Controls.Add(Me.btnConfig)
        Me.Controls.Add(Me.lblPage)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCodeListFile)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnClearLog)
        Me.Controls.Add(Me.lstDebug)
        Me.Controls.Add(Me.lblCodeCount)
        Me.Controls.Add(Me.lstCodes)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SS Keypad Bruteforcer"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstCodes As System.Windows.Forms.ListBox
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Public WithEvents tmrBruteforce As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCodeCount As System.Windows.Forms.Label
    Friend WithEvents lstDebug As System.Windows.Forms.ListBox
    Friend WithEvents chkBruteforceWithUsedCodes As System.Windows.Forms.CheckBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnClearLog As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkReverseBruteforce As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodeListFile As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents tmrDelayTimer As System.Windows.Forms.Timer
    Friend WithEvents chkAskStartOver As System.Windows.Forms.CheckBox
    Friend WithEvents btnRestart As System.Windows.Forms.Button
    Friend WithEvents lblPage As System.Windows.Forms.Label
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStripLoad As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tmrDurationUpdater As System.Windows.Forms.Timer

End Class
