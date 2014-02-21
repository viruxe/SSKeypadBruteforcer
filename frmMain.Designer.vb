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
        Me.lstCodes = New System.Windows.Forms.ListBox()
        Me.txtInterval = New System.Windows.Forms.TextBox()
        Me.tmrScanner = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCodeCount = New System.Windows.Forms.Label()
        Me.lstDebug = New System.Windows.Forms.ListBox()
        Me.chkDebugSound = New System.Windows.Forms.CheckBox()
        Me.chkScanWithUsedCodes = New System.Windows.Forms.CheckBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnClearLog = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkReverseScan = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkDebugActive = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodeList = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.tmrDelayTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
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
        'txtInterval
        '
        Me.txtInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInterval.Location = New System.Drawing.Point(79, 22)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(44, 20)
        Me.txtInterval.TabIndex = 2
        Me.txtInterval.Text = "100"
        Me.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtInterval, "Interval in miliseconds to generate and send a new code." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Insert a bigger value i" & _
                "f you have a slow computer/low fps.")
        '
        'tmrScanner
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Interval (ms):"
        '
        'lblCodeCount
        '
        Me.lblCodeCount.AutoSize = True
        Me.lblCodeCount.Location = New System.Drawing.Point(12, 497)
        Me.lblCodeCount.Name = "lblCodeCount"
        Me.lblCodeCount.Size = New System.Drawing.Size(46, 13)
        Me.lblCodeCount.TabIndex = 4
        Me.lblCodeCount.Text = "0 Codes"
        '
        'lstDebug
        '
        Me.lstDebug.FormattingEnabled = True
        Me.lstDebug.Location = New System.Drawing.Point(99, 113)
        Me.lstDebug.Name = "lstDebug"
        Me.lstDebug.Size = New System.Drawing.Size(224, 381)
        Me.lstDebug.TabIndex = 5
        '
        'chkDebugSound
        '
        Me.chkDebugSound.AutoSize = True
        Me.chkDebugSound.Location = New System.Drawing.Point(68, 14)
        Me.chkDebugSound.Name = "chkDebugSound"
        Me.chkDebugSound.Size = New System.Drawing.Size(57, 17)
        Me.chkDebugSound.TabIndex = 6
        Me.chkDebugSound.Text = "Sound"
        Me.chkDebugSound.UseVisualStyleBackColor = True
        '
        'chkScanWithUsedCodes
        '
        Me.chkScanWithUsedCodes.AutoSize = True
        Me.chkScanWithUsedCodes.Location = New System.Drawing.Point(185, 12)
        Me.chkScanWithUsedCodes.Name = "chkScanWithUsedCodes"
        Me.chkScanWithUsedCodes.Size = New System.Drawing.Size(120, 17)
        Me.chkScanWithUsedCodes.TabIndex = 7
        Me.chkScanWithUsedCodes.Text = "Scan with Code List"
        Me.ToolTip1.SetToolTip(Me.chkScanWithUsedCodes, "Start cracking with the already used codes list in backwards.")
        Me.chkScanWithUsedCodes.UseVisualStyleBackColor = True
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
        Me.btnClearLog.Location = New System.Drawing.Point(236, 500)
        Me.btnClearLog.Name = "btnClearLog"
        Me.btnClearLog.Size = New System.Drawing.Size(87, 30)
        Me.btnClearLog.TabIndex = 11
        Me.btnClearLog.Text = "Clear Log"
        Me.btnClearLog.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(232, 4)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 23)
        Me.btnLoad.TabIndex = 21
        Me.btnLoad.Text = "Load"
        Me.ToolTip1.SetToolTip(Me.btnLoad, "Load or Save a code list file")
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Codes Tried:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(96, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Debug Window:"
        '
        'chkReverseScan
        '
        Me.chkReverseScan.AutoSize = True
        Me.chkReverseScan.Enabled = False
        Me.chkReverseScan.Location = New System.Drawing.Point(185, 35)
        Me.chkReverseScan.Name = "chkReverseScan"
        Me.chkReverseScan.Size = New System.Drawing.Size(94, 17)
        Me.chkReverseScan.TabIndex = 17
        Me.chkReverseScan.Text = "Reverse Scan"
        Me.chkReverseScan.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDebugActive)
        Me.GroupBox1.Controls.Add(Me.chkDebugSound)
        Me.GroupBox1.Location = New System.Drawing.Point(99, 497)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(131, 37)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Debug:"
        '
        'chkDebugActive
        '
        Me.chkDebugActive.AutoSize = True
        Me.chkDebugActive.Location = New System.Drawing.Point(6, 14)
        Me.chkDebugActive.Name = "chkDebugActive"
        Me.chkDebugActive.Size = New System.Drawing.Size(56, 17)
        Me.chkDebugActive.TabIndex = 7
        Me.chkDebugActive.Text = "Active"
        Me.chkDebugActive.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(278, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(45, 23)
        Me.btnSave.TabIndex = 22
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Code List Filename:"
        '
        'txtCodeList
        '
        Me.txtCodeList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodeList.Location = New System.Drawing.Point(114, 7)
        Me.txtCodeList.Name = "txtCodeList"
        Me.txtCodeList.Size = New System.Drawing.Size(112, 20)
        Me.txtCodeList.TabIndex = 19
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkScanWithUsedCodes)
        Me.GroupBox2.Controls.Add(Me.chkReverseScan)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtInterval)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(314, 55)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Scan Options:"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(9, 517)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(30, 13)
        Me.lblTime.TabIndex = 24
        Me.lblTime.Text = "Time"
        '
        'tmrDelayTimer
        '
        Me.tmrDelayTimer.Enabled = True
        Me.tmrDelayTimer.Interval = 1
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 539)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCodeList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnClearLog)
        Me.Controls.Add(Me.lstDebug)
        Me.Controls.Add(Me.lblCodeCount)
        Me.Controls.Add(Me.lstCodes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SS Keypad Cracker"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstCodes As System.Windows.Forms.ListBox
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Public WithEvents tmrScanner As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCodeCount As System.Windows.Forms.Label
    Friend WithEvents lstDebug As System.Windows.Forms.ListBox
    Friend WithEvents chkDebugSound As System.Windows.Forms.CheckBox
    Friend WithEvents chkScanWithUsedCodes As System.Windows.Forms.CheckBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnClearLog As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkReverseScan As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDebugActive As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodeList As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents tmrDelayTimer As System.Windows.Forms.Timer

End Class
