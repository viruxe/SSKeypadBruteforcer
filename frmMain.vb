Imports System.Runtime.InteropServices
Imports System.Net
Imports System.IO
Imports SSKeypadBruteforcer.CodesHandler

Public Class frmMain
    Const MOD_ALT As Integer = &H1 'Alt key
    Const VK_SNAPSHOT As Integer = &H2C 'PrintScreen key
    Const WM_HOTKEY As Integer = &H312

    'P/Invoke API
    Declare Function RegisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    Declare Function UnregisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer) As Integer

    Const gCurVersion As String = "1.2.0-alpha"
    Const gCheckForUpdates As Boolean = True
    Const gCheckDelayAmount As Integer = 2000
    Const gCodeListLimit As Integer = 29

    Const PROC_START_TEXT = "> Process started"
    Const PROC_STOP_TEXT = "> Process stopped"
    Const PROC_STOP_ONERROR_TEXT = "> An error ocurred, process stopped."
    Const APP_VERSION_TEXT = "> Version: " & gCurVersion

    Private gDoKeystrokes As Boolean = True 'Send keys or not (debug purposes)

    Private gCurCodeListPath As String 'Store the file path
    Private gBruteforceStartDate As Date
    Private gCodeList As CodeList
    Private gCurCodePage As Integer = 1
    Private gTotalCodePages As Integer
    Private gCodeListSaved As Boolean

    Private Sub StartBruteforce()
        If txtInterval.Text <> String.Empty Then
            If Val(txtInterval.Text) > 10 Then
                'Ask the user if he wants to start over or not
                If Not chkBruteforceWithUsedCodes.Checked And chkAskStartOver.Checked And gCodeList.Count > 0 Then
                    If MessageBox.Show("Do you want to start over?", "Start over?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then RestartBruteforce()
                End If

                My.Computer.Audio.Play("c:\Windows\Media\Speech On.wav")
                'Increase value if you have a slow computer or you will miss some codes
                '(Generally if you start seeing numbers in the dialog then your computer is slow and you should raise this value)
                If txtInterval.Text <> My.Settings.interval Then My.Settings.interval = txtInterval.Text

                'Start the bruteforce timer
                tmrBruteforce.Interval = Val(txtInterval.Text)
                tmrBruteforce.Start()

                tmrDurationUpdater.Start()

                'Update duration label
                gBruteforceStartDate = DateTime.Now
                lblTime.Text = GetBruteDuration()

                'Disable stuff so the user doesn't screw something up
                txtInterval.Enabled = False
                txtCodeListFile.Enabled = False
                btnLoad.Enabled = False
                chkBruteforceWithUsedCodes.Enabled = False
                chkReverseBruteforce.Enabled = False
                btnConfig.Enabled = False
                btnUp.Enabled = False
                btnDown.Enabled = False

                If btnRestart.Enabled = True Then btnRestart.Enabled = False

                If gCodeListSaved Then gCodeListSaved = False

                'Print debug info
                If lstCodes.Items.Count = 0 And chkBruteforceWithUsedCodes.Checked = True Then Log("> No codes to bruteforce you noob") Else Log(PROC_START_TEXT)
            End If
        End If
    End Sub

    Private Sub StopBruteforce()
        My.Computer.Audio.Play("c:\Windows\Media\Speech Off.wav")
        tmrBruteforce.Stop()
        tmrDurationUpdater.Stop()

        'Re-enable controls
        txtInterval.Enabled = True
        txtCodeListFile.Enabled = True
        btnLoad.Enabled = True
        chkBruteforceWithUsedCodes.Enabled = True
        btnConfig.Enabled = True
        If gCurCodePage > 1 Then btnDown.Enabled = True

        If btnRestart.Enabled = False Then btnRestart.Enabled = True

        'Reverse bruteforce
        If chkBruteforceWithUsedCodes.Checked Then chkReverseBruteforce.Enabled = True

        Log(PROC_STOP_TEXT & " (Time taken: " & lblTime.Text & ")")
        If Not chkBruteforceWithUsedCodes.Checked And gCodeList.Count > 0 And gCodeList.DuplicatesCount > 0 Then Log("> With " & gCodeList.DuplicatesCount & " Duplicates found.")
    End Sub

    Enum PageSwitch
        PAGE_DOWN
        PAGE_UP
    End Enum

    ''' <summary>
    ''' Switch between code pages in lstCodes
    ''' </summary>
    ''' <param name="action"></param>
    ''' <remarks></remarks>
    Private Sub SwitchPage(ByVal action As PageSwitch)
        lstCodes.Items.Clear()

        For index = gCurCodePage * gCodeListLimit To (gCurCodePage * gCodeListLimit) + gCodeListLimit
            If index = gCodeList.Count Then Exit For
            lstCodes.Items.Add(gCodeList.Item(index))
        Next
    End Sub

    ''' <summary>
    ''' Get the duration of the current bruteforce process
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetBruteDuration() As String
        Dim duration As TimeSpan = Date.Now - gBruteforceStartDate

        Return String.Format("{0:00}:{1:00}:{2:00}", _
        CInt(duration.TotalHours), _
        CInt(duration.TotalMinutes) Mod 60, _
        CInt(duration.TotalSeconds) Mod 60)
    End Function

    ''' <summary>
    ''' Gets the version value from version.check on github for the Update Checker
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function GetVersionStringFromWeb() As String
        Dim version As String = String.Empty

        Try
            Dim fileRequest As HttpWebRequest = HttpWebRequest.Create("https://raw.github.com/viruxe/SSKeypadBruteforcer/master/version.check")
            Dim fileResponse As HttpWebResponse = fileRequest.GetResponse()
            Using sr As StreamReader = New StreamReader(fileResponse.GetResponseStream())
                version = sr.ReadToEnd
                sr.Close()
            End Using
            fileResponse.Close()
        Catch ex As WebException
            Debug.WriteLine("FAIL: " + ex.Message)
            Return String.Empty
        End Try

        Return version
    End Function

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_HOTKEY Then
            If Not tmrBruteforce.Enabled Then StartBruteforce() Else StopBruteforce()
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.formlocation.IsEmpty Then
            Me.StartPosition = FormStartPosition.CenterScreen
        Else
            Me.Location = My.Settings.formlocation
        End If
        Log(APP_VERSION_TEXT)

        Call RegisterHotKey(Me.Handle, 9, MOD_ALT, Keys.PrintScreen)

        If gCheckForUpdates Then
            tmrDelayTimer.Interval = gCheckDelayAmount 'Set the amount of time to wait for the update check to start
            tmrDelayTimer.Start()
        End If

        lblTime.Text = String.Empty 'Reset so the user doesn't see the default text

        gCodeList = New CodeList 'Instantiate the codelist
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Call UnregisterHotKey(Me.Handle, 9)
        If chkBruteforceWithUsedCodes.Checked Then chkBruteforceWithUsedCodes.Checked = False

        My.Settings.formlocation = Me.Location
        My.Settings.Save()
    End Sub

    Private Sub BRUTE_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBruteforce.Tick
        'Brute process handling
        If chkBruteforceWithUsedCodes.Checked Then
            'Loop through listbox
            If lstCodes.Items.Count > 0 Then
                Static curIndex As Integer

                Try
                    'Select the items
                    If curIndex = 0 Then
                        curIndex = lstCodes.Items.Count - 1 'Reset counter
                    ElseIf chkReverseBruteforce.Checked And curIndex = lstCodes.Items.Count - 1 Then
                        curIndex = 0
                    End If

                    'Send keystrokes
                    If gDoKeystrokes Then SendKeys.Send(lstCodes.Items.Item(curIndex) & "~")
                    lstCodes.SelectedIndex = curIndex
                Catch ex As Exception
                    StopBruteforce()
                    Log(PROC_STOP_ONERROR_TEXT)
                    ShowError(ex.Message)
                End Try

                If chkReverseBruteforce.Checked Then curIndex += 1 Else curIndex -= 1
            End If
        Else
            'Just add new codes to the list
            Try
                Dim newCode As New Code(gCodeList)

                If newCode.Value <> String.Empty Then 'Insurance
                    If newCode.Value <> -1 Then
                        gCodeList.Add(newCode.Value)

                        lblCodeCount.Text = gCodeList.Count & " (" & gCodeList.DuplicatesCount & ")" 'Update code count

                        'Update listbox
                        If lstCodes.Items.Count = gCodeListLimit Then lstCodes.Items.RemoveAt(0)
                        lstCodes.Items.Add(newCode.Value)
                        lstCodes.SelectedIndex = lstCodes.Items.Count - 1

                        'Update page label
                        UpdatePageLabel()

                        'Send keys
                        If gDoKeystrokes Then
                            SendKeys.Send(newCode.Value & "~")
                        Else
                            'Log(newCode.Value, debugLog:=True)
                        End If
                    Else
                        StopBruteforce()
                        MessageBox.Show( _
                            "No moar codes for you buddy!" & vbNewLine & vbNewLine & _
                            "With 4 digit pincodes we can only have 10000 combinations and you've just reached your 10000th code!" & vbNewLine & _
                            "This unfortunately means something went wrong with this bruteforcing process. Have some possible reasons:" & vbNewLine & _
                            "- You have a slow computer and as a consequence some codes might not have been tried." & vbNewLine & _
                            "- The gamemode might have been patched in some sort of way that makes this program just go on with the process without knowing anything." & vbNewLine & _
                            "- Or I just messed up somewhere in the code. :D" & vbNewLine & vbNewLine & _
                            "Just try again and hope for the best.", "WHOA!?!?!?!?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    Log("> Couldn't generate a code! WTF!")
                    StopBruteforce()
                End If
            Catch ex As Exception
                StopBruteforce()
                Log(PROC_STOP_ONERROR_TEXT)
                ShowError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub UpdatePageLabel()
        If gCodeList.Count > gCodeListLimit Then
            gTotalCodePages = gCodeList.Count \ gCodeListLimit
            gCurCodePage = gTotalCodePages + 1
            lblPage.Text = "Page: " & gCurCodePage
        End If
    End Sub

    Private Sub ShowError(ByVal message As String)
        MessageBox.Show("Error: " & vbNewLine & vbNewLine & message, "Error Message:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Debug.Print("[ERROR] " & message)
    End Sub

    ''' <summary>
    ''' Log something important to the debug listbox
    ''' </summary>
    ''' <param name="message">Log message - duh</param>
    ''' <param name="debugLog">Whether or not to show the message if Debug Mode is activated</param>
    ''' <remarks></remarks>
    Private Sub Log(ByVal message As String, Optional ByVal debugLog As Boolean = False)
        If debugLog = True And Not frmConfig.chkDebugActive.Checked Then Exit Sub

        lstDebug.Items.Add(message)
        lstDebug.SelectedIndex = lstDebug.Items.Count - 1
    End Sub

    Private Sub RestartBruteforce() Handles btnRestart.Click
        lstCodes.Items.Clear()
        gCodeList = New CodeList

        gCurCodePage = 1
        lblPage.Text = "Page: 1"
        lblCodeCount.Text = "0 Codes"
        lblTime.Text = "00:00:00"
    End Sub

    Private Sub btnClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLog.Click
        lstDebug.Items.Clear()
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim msgResult As MsgBoxResult 'Store the user's answer if there is any

        If Not gCodeListSaved And lstCodes.Items.Count > 0 Then
            msgResult = MessageBox.Show("There are codes to be saved. Do you want to save them?", "Unsaved codes", MessageBoxButtons.YesNoCancel)
            If msgResult = Windows.Forms.DialogResult.Yes Then btnSave_Click(sender, e)
        End If

        If Not msgResult = MsgBoxResult.Yes And Not msgResult = MsgBoxResult.Cancel Then
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                gCurCodeListPath = OpenFileDialog1.FileName

                txtCodeListFile.Text = OpenFileDialog1.SafeFileName
                txtCodeListFile.SelectionStart = txtCodeListFile.Text.Length

                Try
                    'Read from selected file
                    Dim sr As New StreamReader(OpenFileDialog1.FileName)

                    While Not sr.EndOfStream
                        gCodeList.Add(sr.ReadLine())
                    End While
                    sr.Close()

                    'Add the last 29 (or wtv limit atm) to the listbox
                    lstCodes.Items.Clear()
                    For index = gCodeList.Count - gCodeListLimit To gCodeList.Count - 1
                        lstCodes.Items.Add(gCodeList.Item(index))
                    Next

                    If gCodeList.Count > gCodeListLimit Then btnDown.Enabled = True

                    UpdatePageLabel()
                    lblCodeCount.Text = gCodeList.Count
                    lstCodes.SelectedIndex = lstCodes.Items.Count - 1
                    gCodeListSaved = True
                    Log("> Codes Loaded: " & Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName) & " (" & gCodeList.Count & " codes)")
                    txtCodeListFile_TextChanged(sender, e)

                    If MessageBox.Show("Do you want to bruteforce using these codes?", "Bruteforce using these codes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then chkBruteforceWithUsedCodes.Checked = True
                Catch ex As Exception
                    Log("> An error ocurred while trying to load the file.")
                    ShowError(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If gCurCodeListPath <> String.Empty Then SaveFileDialog1.FileName = gCurCodeListPath Else SaveFileDialog1.FileName = txtCodeListFile.Text

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Dim sw As New StreamWriter(SaveFileDialog1.FileName)

                For Each code As String In gCodeList.Codes
                    sw.WriteLine(code.ToString)
                Next
                sw.Close()

                Log("> Codes Saved: " & Path.GetFileNameWithoutExtension(SaveFileDialog1.FileName) & " (" & gCodeList.Count & " codes)")
                gCodeListSaved = True
                btnSave.Enabled = False

                If MessageBox.Show("Do you want to restart?", "Restart?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then RestartBruteforce()
            Catch ex As Exception
                Log("> An error ocurred while saving the file.")
                ShowError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub chkBruteforceWithUsedCodes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBruteforceWithUsedCodes.CheckedChanged
        Static oldInterval As Integer

        If chkBruteforceWithUsedCodes.Checked Then
            oldInterval = txtInterval.Text
            txtInterval.Text = 1000
            chkReverseBruteforce.Enabled = True
        Else
            chkReverseBruteforce.Enabled = False
            txtInterval.Text = oldInterval
        End If
    End Sub

    Private Sub txtCodeListFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodeListFile.TextChanged
        If txtCodeListFile.Text.Length > 0 And lstCodes.Items.Count > 0 And Not gCodeListSaved Then btnSave.Enabled = True Else btnSave.Enabled = False
    End Sub

    Private Sub frmMain_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDoubleClick
        MsgBox("viruxe.the.pwner@gmail.com")

        If gDoKeystrokes = True Then gDoKeystrokes = False Else gDoKeystrokes = True
    End Sub

    ''' <summary>
    ''' Delays the update checker so the program can load faster on startup
    ''' </summary>
    Private Sub tmrDelayTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDelayTimer.Tick
        tmrDelayTimer.Stop()
        'Check for a new version of the program through GitHub
        Log("> Checking for updates...")
        Dim newVersion As String = GetVersionStringFromWeb()
        If Not newVersion = String.Empty Then 'Only do something if newVersion is not empty
            If newVersion <> gCurVersion Then
                If MessageBox.Show("There is a new version! Would you like to download it?" & vbNewLine & "Version: " & newVersion, "New version", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    Process.Start("https://github.com/viruxe/SSKeypadBruteforcer/releases/")
                End If
            Else : Log("> Program is up to date. Brute at will.")
            End If
        Else : Log("> Update check unavailable")
        End If

        If My.Settings.reminder = True Then
            If MessageBox.Show(System.Text.RegularExpressions.Regex.Unescape("Always remember:\n\nIf you have a slow computer or your connection between the server is a bit laggy\nor even if the server somehow responds slowly, you should increase the bruteforce interval so you don't miss any codes.\n\nWould you like to be reminded again about this?"), "Reminder :)", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                My.Settings.reminder = False
            End If
        End If
    End Sub

    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.Click
        frmConfig.ShowDialog()
    End Sub

    Private Sub txtInterval_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInterval.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Try
            If gCurCodePage < gTotalCodePages + 1 Then
                gCurCodePage += 1
                lblPage.Text = "Page: " & gCurCodePage
                If gCurCodePage > 1 Then btnDown.Enabled = True
                If gCurCodePage = gTotalCodePages + 1 Then btnUp.Enabled = False
                SwitchPage(PageSwitch.PAGE_UP)
            End If
        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Try
            If gCurCodePage > 1 Then
                gCurCodePage -= 1
                lblPage.Text = "Page: " & gCurCodePage
                If btnUp.Enabled = False Then btnUp.Enabled = True
                If gCurCodePage = 1 Then btnDown.Enabled = False
                SwitchPage(PageSwitch.PAGE_DOWN)
            End If
        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub

    Private Sub tmrUpdateDuration_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDurationUpdater.Tick
        lblTime.Text = GetBruteDuration()
    End Sub
End Class
