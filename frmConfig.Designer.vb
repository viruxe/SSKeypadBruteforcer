<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkDebugActive = New System.Windows.Forms.CheckBox()
        Me.chkDebugSound = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtHotkeySecundary = New System.Windows.Forms.TextBox()
        Me.txtHotkeyPrimary = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkReminder = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(35, 156)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(116, 156)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDebugActive)
        Me.GroupBox1.Controls.Add(Me.chkDebugSound)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(131, 37)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Debug Mode:"
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
        'chkDebugSound
        '
        Me.chkDebugSound.AutoSize = True
        Me.chkDebugSound.Location = New System.Drawing.Point(68, 14)
        Me.chkDebugSound.Name = "chkDebugSound"
        Me.chkDebugSound.Size = New System.Drawing.Size(56, 17)
        Me.chkDebugSound.TabIndex = 6
        Me.chkDebugSound.Text = "Sound"
        Me.chkDebugSound.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtHotkeySecundary)
        Me.GroupBox2.Controls.Add(Me.txtHotkeyPrimary)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.chkReminder)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 55)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(178, 90)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "General:"
        '
        'txtHotkeySecundary
        '
        Me.txtHotkeySecundary.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.SSKeypadBruteforcer.My.MySettings.Default, "hotkeySecundary", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtHotkeySecundary.Location = New System.Drawing.Point(114, 14)
        Me.txtHotkeySecundary.Name = "txtHotkeySecundary"
        Me.txtHotkeySecundary.Size = New System.Drawing.Size(53, 21)
        Me.txtHotkeySecundary.TabIndex = 3
        Me.txtHotkeySecundary.Text = Global.SSKeypadBruteforcer.My.MySettings.Default.hotkeySecundary
        '
        'txtHotkeyPrimary
        '
        Me.txtHotkeyPrimary.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.SSKeypadBruteforcer.My.MySettings.Default, "hotkeyPrimary", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtHotkeyPrimary.Location = New System.Drawing.Point(57, 14)
        Me.txtHotkeyPrimary.Name = "txtHotkeyPrimary"
        Me.txtHotkeyPrimary.Size = New System.Drawing.Size(51, 21)
        Me.txtHotkeyPrimary.TabIndex = 2
        Me.txtHotkeyPrimary.Text = Global.SSKeypadBruteforcer.My.MySettings.Default.hotkeyPrimary
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Hotkeys:"
        '
        'chkReminder
        '
        Me.chkReminder.AutoSize = True
        Me.chkReminder.Checked = Global.SSKeypadBruteforcer.My.MySettings.Default.reminder
        Me.chkReminder.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReminder.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.SSKeypadBruteforcer.My.MySettings.Default, "reminder", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkReminder.Location = New System.Drawing.Point(6, 67)
        Me.chkReminder.Name = "chkReminder"
        Me.chkReminder.Size = New System.Drawing.Size(148, 17)
        Me.chkReminder.TabIndex = 0
        Me.chkReminder.Text = "Show reminder at startup"
        Me.chkReminder.UseVisualStyleBackColor = True
        '
        'frmConfig
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(203, 191)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuration"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkReminder As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDebugActive As System.Windows.Forms.CheckBox
    Friend WithEvents chkDebugSound As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHotkeySecundary As System.Windows.Forms.TextBox
    Friend WithEvents txtHotkeyPrimary As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
