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

    Const gCurVersion As String = "1.1-alpha"
    Const gCheckForUpdates As Boolean = True
    Const gCheckDelayAmount As Integer = 2000
    Const gCodeListLimit As Integer = 29

    Private gCurCodeListPath As String 'Store the file path
    Private gDoKeystrokes As Boolean = True 'Send keys or not (debug purposes)
    Private gBruteforceStart As Date
    Private gCodeList As New CodeList
    Private gCurCodePage As Integer = 1
    Private gTotalCodePages As Integer

    Private Sub StartBruteforce()
        If txtInterval.Text <> String.Empty Then
            If Val(txtInterval.Text) > 10 Then
                'Ask the user if he wants to start over or not
                If Not chkBruteforceWithUsedCodes.Checked And chkAskStartOver.Checked And gCodeList.Count > 0 Then
                    If MessageBox.Show("Do you want to start over?", "Start over?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then lstCodes.Items.Clear()
                End If

                My.Computer.Audio.Play("c:\Windows\Media\Speech On.wav")
                'Increase value if you have a slow computer or you will miss some codes
                If txtInterval.Text <> My.Settings.interval Then My.Settings.interval = txtInterval.Text

                'Start the bruteforce timer
                tmrBruteforce.Interval = Val(txtInterval.Text)
                tmrBruteforce.Start()

                'Update duration label
                gBruteforceStart = DateTime.Now
                lblTime.Text = GetBruteDuration()

                'Disable stuff so the user doesn't screw something up
                txtInterval.Enabled = False
                txtCodeList.Enabled = False
                btnLoad.Enabled = False
                chkBruteforceWithUsedCodes.Enabled = False
                chkReverseBruteforce.Enabled = False
                btnConfig.Enabled = False
                btnUp.Enabled = False
                btnDown.Enabled = False

                If btnRestart.Enabled = True Then btnRestart.Enabled = False

                'Print debug info
                If lstCodes.Items.Count = 0 And chkBruteforceWithUsedCodes.Checked = True Then
                    Log("> No codes to bruteforce you noob")
                Else : Log("> Process started")
                End If
            End If
        End If
    End Sub

    Private Sub StopBruteforce()
        My.Computer.Audio.Play("c:\Windows\Media\Speech Off.wav")
        tmrBruteforce.Stop()

        'Re-enable controls
        txtInterval.Enabled = True
        txtCodeList.Enabled = True
        btnLoad.Enabled = True
        chkBruteforceWithUsedCodes.Enabled = True
        btnConfig.Enabled = True
        If gCurCodePage > 1 Then btnDown.Enabled = True

        If btnRestart.Enabled = False Then btnRestart.Enabled = True

        'Reverse bruteforce
        If chkBruteforceWithUsedCodes.Checked Then chkReverseBruteforce.Enabled = True

        Log("> Process ended (Time taken: " & lblTime.Text & ")")
        If Not chkBruteforceWithUsedCodes.Checked And gCodeList.Count > 0 And gCodeList.DuplicatesCount > 0 Then Log("> With " & gCodeList.DuplicatesCount & " Duplicates found.")
    End Sub

    Private Sub SwitchPage()
        lstCodes.Items.Clear()

        For index = gCurCodePage * gCodeListLimit To (gCurCodePage * gCodeListLimit) + gCodeListLimit
            If index = gCodeList.Count Then Exit For
            lstCodes.Items.Add(gCodeList.Item(index))
        Next
    End Sub

    Private Function GetBruteDuration() As String
        Dim duration As TimeSpan = Date.Now - gBruteforceStart

        Return String.Format("{0:00}:{1:00}:{2:00}", _
        CInt(duration.TotalHours), _
        CInt(duration.TotalMinutes) Mod 60, _
        CInt(duration.TotalSeconds) Mod 60)
    End Function

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
        Log("> Version: " & gCurVersion)
        Call RegisterHotKey(Me.Handle, 9, MOD_ALT, Keys.PrintScreen)

        If gCheckForUpdates Then tmrDelayTimer.Start()
        tmrDelayTimer.Interval = gCheckDelayAmount 'Set the amount of time to wait for the update check to start

        lblTime.Text = String.Empty 'Reset so the user doesn't see the default text
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Call UnregisterHotKey(Me.Handle, 9)
        If chkBruteforceWithUsedCodes.Checked Then chkBruteforceWithUsedCodes.Checked = False
        My.Settings.Save()
    End Sub

    Private Sub BRUTE_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBruteforce.Tick
        Static tickCount As Integer 'Count 1 second

        'Update brute duration label after 1 second has passed
        If tickCount < 10 Then
            tickCount += 1
        Else
            tickCount = 1
            lblTime.Text = GetBruteDuration()
        End If

        'Loop through listbox
        If chkBruteforceWithUsedCodes.Checked Then
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
                    Log("ERROR: " & ex.Message)
                    StopBruteforce()
                End Try

                If chkReverseBruteforce.Checked Then curIndex += 1 Else curIndex -= 1
            End If
        Else
            'Just add codes to the list
            Try
                Dim newCode As New Code(gCodeList)

                If newCode.Value <> String.Empty Then 'Insurance
                    gCodeList.Add(newCode.Value)

                    lblCodeCount.Text = gCodeList.Count & " Codes" 'Update code count

                    'Update listbox
                    If lstCodes.Items.Count = gCodeListLimit Then lstCodes.Items.RemoveAt(0)
                    lstCodes.Items.Add(newCode.Value)
                    lstCodes.SelectedIndex = lstCodes.Items.Count - 1

                    'Update page label
                    If gCodeList.Count > gCodeListLimit Then
                        gTotalCodePages = gCodeList.Count \ gCodeListLimit
                        gCurCodePage = gTotalCodePages + 1
                        lblPage.Text = "Page: " & gCurCodePage
                    End If

                    'Send keys
                    If gDoKeystrokes Then
                        SendKeys.Send(newCode.Value & "~")
                    Else
                        'Log(newCode.Value, debugLog:=True)
                    End If
                Else
                    Log("> Couldn't generate a code! WTF!")
                    StopBruteforce()
                End If
            Catch ex As Exception
                Log("> An error ocurred, process stopped.")
                StopBruteforce()

                MessageBox.Show("Error: " & ex.Message, "Error Message:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
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

    Private Sub btnClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLog.Click
        lstDebug.Items.Clear()
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            gCurCodeListPath = OpenFileDialog1.FileName

            txtCodeList.Text = OpenFileDialog1.SafeFileName
            txtCodeList.SelectionStart = txtCodeList.Text.Length

            Try
                Dim sr As New StreamReader(OpenFileDialog1.FileName)

                lstCodes.Items.Clear()
                While Not sr.EndOfStream
                    lstCodes.Items.Add(sr.ReadLine())
                End While
                sr.Close()

                lblCodeCount.Text = lstCodes.Items.Count & " Codes"
                lstCodes.SelectedIndex = lstCodes.Items.Count - 1
                Log("Codes Loaded: " & Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName) & " (" & lstCodes.Items.Count & " codes)")
                txtCodeList_TextChanged(sender, e)

                If MessageBox.Show("Do you want to bruteforce using these codes?", "Bruteforce using these codes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then chkBruteforceWithUsedCodes.Checked = True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Loading File")
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If gCurCodeListPath <> String.Empty Then SaveFileDialog1.FileName = gCurCodeListPath Else SaveFileDialog1.FileName = txtCodeList.Text

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Dim sw As New StreamWriter(SaveFileDialog1.FileName)

                For Each code As String In lstCodes.Items
                    sw.WriteLine(code.ToString)
                Next
                sw.Close()

                Log("Codes Saved: " & Path.GetFileNameWithoutExtension(SaveFileDialog1.FileName) & " (" & lstCodes.Items.Count & " codes)")
                txtCodeList.Text = String.Empty
                lstCodes.Items.Clear()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Saving File")
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

    Private Sub txtCodeList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodeList.TextChanged
        If txtCodeList.Text.Length > 0 And lstCodes.Items.Count > 0 Then btnSave.Enabled = True Else btnSave.Enabled = False
    End Sub

    Private Sub frmMain_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDoubleClick
        MsgBox("viruxe.the.pwner@gmail.com")

        If gDoKeystrokes = True Then gDoKeystrokes = False Else gDoKeystrokes = True
    End Sub

    ''' <summary>
    ''' Delays the update checker so the program can load fast on startup
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

    Private Sub RestartBruteforce() Handles btnRestart.Click
        lstCodes.Items.Clear()
        gCodeList.Clear()
        gCurCodePage = 1
        lblPage.Text = "Page: 1"
        lblCodeCount.Text = "0 Codes"
        lblTime.Text = "00:00:00"
    End Sub

    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.Click
        frmConfig.ShowDialog()
    End Sub

    Private Sub txtInterval_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInterval.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        If gCurCodePage < gTotalCodePages + 1 Then
            gCurCodePage += 1
            lblPage.Text = "Page: " & gCurCodePage
            If gCurCodePage > 1 Then btnDown.Enabled = True
            If gCurCodePage = gTotalCodePages + 1 Then btnUp.Enabled = False
            SwitchPage()
        End If
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        If gCurCodePage > 1 Then
            gCurCodePage -= 1
            lblPage.Text = "Page: " & gCurCodePage
            If btnUp.Enabled = False Then btnUp.Enabled = True
            If gCurCodePage = 1 Then btnDown.Enabled = False
            SwitchPage()
        End If
    End Sub
End Class
