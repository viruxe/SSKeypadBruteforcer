Imports System.Runtime.InteropServices

Public Class frmMain

    'Private Declare Function GetAsyncKeyState Lib "User32" (ByVal vKey As Integer) As Short

    'Function GetKey(ByVal Key As Integer) As Boolean
    '    If GetAsyncKeyState(Key) = -32767 Then
    '        Return True
    '    End If
    '    Return False
    'End Function

    Public Const MOD_ALT As Integer = &H1 'Alt key
    Public Const VK_SNAPSHOT As Integer = &H2C 'PrintScreen key
    Public Const WM_HOTKEY As Integer = &H312

    'P/Invoke API
    Public Declare Function RegisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    Public Declare Function UnregisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer) As Integer

    Private curCodeListPath As String 'Store the file path
    Private doKeys As Boolean = True 'Send keys or not (debug purposes)
    Private startDate As Date

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_HOTKEY Then

            'Start
            My.Computer.Audio.Play("c:\Windows\Media\Speech On.wav")
            If Not tmrScanner.Enabled Then
                If Not chkScanWithUsedCodes.Checked And lstCodes.Items.Count > 0 Then
                    If MessageBox.Show("Do you want to clear the codes?", "Clear Codes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then lstCodes.Items.Clear()
                End If

                tmrScanner.Interval = Val(txtInterval.Text)
                tmrScanner.Start()
                startDate = DateTime.Now
                lblTime.Text = GetTimeDuration()
                tmrTimePassed.Start()
                txtInterval.Enabled = False
                txtCodeList.Enabled = False
                btnLoad.Enabled = False
                chkScanWithUsedCodes.Enabled = False
                chkReverseScan.Enabled = False
                Log("> Process started")
                If lstCodes.Items.Count = 0 And chkScanWithUsedCodes.Checked = True Then Log("> No codes to scan you noob")

            Else 'Stop
                My.Computer.Audio.Play("c:\Windows\Media\Speech Off.wav")
                tmrScanner.Stop()
                txtInterval.Enabled = True
                txtCodeList.Enabled = True
                btnLoad.Enabled = True
                chkScanWithUsedCodes.Enabled = True
                chkReverseScan.Enabled = True

                tmrTimePassed.Stop()
                Log("> Process ended (Time taken: " & lblTime.Text & ")")
            End If
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call RegisterHotKey(Me.Handle, 9, MOD_ALT, VK_SNAPSHOT)
        lblTime.Text = String.Empty
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Call UnregisterHotKey(Me.Handle, 9)  'Remember to unregister the hotkey
    End Sub

    Private Function GenerateNewCode() As String
        Dim rand As New Random
        Dim code As String
        Dim tries As Integer

        Do
            code = rand.Next(0, 9999)

            If code < 10 Then
                Log("Found a code under 10! (" & code & ")", debugLog:=True)
                code = code.Insert(0, "0")
                If chkDebugSound.Checked Then My.Computer.Audio.Play("c:\Windows\Media\recycle.wav")
            End If

            If code < 100 Then
                Log("Found a code under 100! (" & code & ")", debugLog:=True)
                code = code.Insert(0, "0")
                If chkDebugSound.Checked Then My.Computer.Audio.Play("c:\Windows\Media\recycle.wav")
            End If

            If code < 1000 Then
                Log("Found a code under 1000! (" & code & ")", debugLog:=True)
                code = code.Insert(0, "0")
                If chkDebugSound.Checked Then My.Computer.Audio.Play("c:\Windows\Media\chimes.wav")
            End If

            tries = +1
            If tries > 1 Then Log(code)
        Loop While IsCodeDuplicated(code) = True

        Return code
    End Function

    ''' <summary>
    ''' Check if the provided code is listed on the codelist
    ''' </summary>
    ''' <param name="code"></param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Private Function IsCodeDuplicated(ByVal code)
        For Each usedCode As String In lstCodes.Items
            If usedCode = code Then
                Log("Duplicated code! (" & code & ")", True)
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub tmrScanner_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrScanner.Tick
        If chkScanWithUsedCodes.Checked Then 'Loop trough listbox
            If lstCodes.Items.Count > 0 Then
                Static curIndex As Integer

                If curIndex = 0 Then
                    curIndex = lstCodes.Items.Count - 1 'Reset counter
                ElseIf chkReverseScan.Checked And curIndex = lstCodes.Items.Count - 1 Then
                    curIndex = 0
                End If

                Try
                    If doKeys Then SendKeys.Send(lstCodes.Items.Item(curIndex) & "~")
                    lstCodes.SelectedIndex = curIndex
                Catch ex As Exception
                    Log("ERROR: " & ex.Message)
                End Try

                If chkReverseScan.Checked Then curIndex += 1 Else curIndex -= 1

                lblCodeCount.Text = lstCodes.Items.Count & " Codes"
            End If
        Else
            Dim code As String = GenerateNewCode()

            'Add to list
            lstCodes.Items.Add(code)
            lstCodes.SelectedIndex = lstCodes.Items.Count - 1
            lblCodeCount.Text = lstCodes.Items.Count & " Codes"

            'Send keys
            If doKeys Then
                SendKeys.Send(code & "~")
            Else
                Log(code & "~", debugLog:=True)
            End If

        End If
    End Sub

    Private Sub Log(ByVal message As String, Optional ByVal debugLog As Boolean = False)
        If debugLog = True And Not chkDebugActive.Checked Then Exit Sub

        lstDebug.Items.Add(message)
        lstDebug.SelectedIndex = lstDebug.Items.Count - 1
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lstCodes.Items.Clear()
    End Sub

    Private Sub btnClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLog.Click
        lstDebug.Items.Clear()
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            curCodeListPath = OpenFileDialog1.FileName

            txtCodeList.Text = OpenFileDialog1.SafeFileName
            txtCodeList.SelectionStart = txtCodeList.Text.Length

            Try
                Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)

                lstCodes.Items.Clear()
                While Not sr.EndOfStream
                    lstCodes.Items.Add(sr.ReadLine())
                End While
                sr.Close()

                lblCodeCount.Text = lstCodes.Items.Count & " Codes"
                lstCodes.SelectedIndex = lstCodes.Items.Count - 1
                Log("Codes Loaded: " & System.IO.Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName) & " (" & lstCodes.Items.Count & " codes)")
                txtCodeList_TextChanged(sender, e)

                If MessageBox.Show("Do you want to scan using these codes?", "Scan using these codes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then chkScanWithUsedCodes.Checked = True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Loading File")
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveFileDialog1.FileName = curCodeListPath

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Dim sw As New System.IO.StreamWriter(SaveFileDialog1.FileName)

                For Each code As String In lstCodes.Items
                    sw.WriteLine(code.ToString)
                Next
                sw.Close()

                Log("Codes Saved: " & System.IO.Path.GetFileNameWithoutExtension(SaveFileDialog1.FileName) & " (" & lstCodes.Items.Count & " codes)")
                txtCodeList.Text = String.Empty
                lstCodes.Items.Clear()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Saving File")
            End Try
        End If
    End Sub

    Private Sub chkScanWithUsedCodes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScanWithUsedCodes.CheckedChanged
        If chkScanWithUsedCodes.Checked = True Then
            txtInterval.Text = 1000
            chkReverseScan.Enabled = True
        Else
            chkReverseScan.Enabled = False
            txtInterval.Text = 100
        End If
    End Sub

    Private Sub txtCodeList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodeList.TextChanged
        If txtCodeList.Text.Length > 0 And lstCodes.Items.Count > 0 Then btnSave.Enabled = True Else btnSave.Enabled = False
    End Sub

    Private Sub frmMain_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDoubleClick
        MsgBox("viruxe.the.pwner@gmail.com")

        If doKeys = True Then doKeys = False Else doKeys = True
    End Sub

    Private Sub TIME(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimePassed.Tick
        lblTime.Text = GetTimeDuration()
    End Sub

    Private Function GetTimeDuration() As String
        Dim duration As TimeSpan = Date.Now - startDate

        Return String.Format("{0:00}:{1:00}:{2:00}", _
        CInt(duration.TotalHours), _
        CInt(duration.TotalMinutes) Mod 60, _
        CInt(duration.TotalSeconds) Mod 60)
    End Function
End Class
