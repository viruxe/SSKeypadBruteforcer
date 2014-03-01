Public Class CodesHandler

    Public Class Code
        Public Property Value As String

        Sub New(ByRef codeList As CodeList)
            If codeList.Count = 9999 Then
                '4 digit pin codes can only have a maximum of 10000 combinations (from 0 to 9 = 10 numbers - so - 10^4 digits = 10000)
                ' NO MOAAAAR CODES!
                Value = -1
            Else
                Dim rand As New Random
                Dim code As String

                Do
                    code = rand.Next(0, 10000)

                    If code < 10 Then
                        'Log("Found a code under 10! (" & code & ")", debugLog:=True)
                        code = code.Insert(0, "0")
                        If frmConfig.chkDebugSound.Checked Then My.Computer.Audio.Play("c:\Windows\Media\recycle.wav")
                    End If

                    If code < 100 Then
                        'Log("Found a code under 100! (" & code & ")", debugLog:=True)
                        code = code.Insert(0, "0")
                        If frmConfig.chkDebugSound.Checked Then My.Computer.Audio.Play("c:\Windows\Media\recycle.wav")
                    End If

                    If code < 1000 Then
                        'Log("Found a code under 1000! (" & code & ")", debugLog:=True)
                        code = code.Insert(0, "0")
                        If frmConfig.chkDebugSound.Checked Then My.Computer.Audio.Play("c:\Windows\Media\chimes.wav")
                    End If

                Loop While codeList.IsCodeDuplicated(code)
                Value = code
            End If
        End Sub
    End Class

    ''' <summary>
    ''' This class handles the storage of the codes
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CodeList
        Private cCodes As List(Of String)
        Private cDuplicates As Integer

        ''' <summary>
        ''' Provide outside access to the codes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Codes() As List(Of String)
            Get
                Return cCodes
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of duplicates found in the current CodeList while trying to populate it
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DuplicatesCount() As Integer
            Get
                Return cDuplicates
            End Get
        End Property

        Sub New()
            cCodes = New List(Of String)
        End Sub

        Public Sub Clear()
            Codes.Clear()
            cDuplicates = 0
        End Sub

        Public Sub Add(ByVal code As String)
            Codes.Add(code)
        End Sub

        Public ReadOnly Property Count() As Integer
            Get
                Return Codes.Count
            End Get
        End Property

        Public ReadOnly Property Item(ByVal index As Integer) As String
            Get
                Return Codes.Item(index)
            End Get
        End Property

        ''' <summary>
        ''' Check if the provided code is listed on the codelist
        ''' </summary>
        ''' <param name="code"></param>
        ''' <returns>Boolean</returns>
        ''' <remarks></remarks>
        Public Function IsCodeDuplicated(ByVal code As String) As Boolean
            If Codes.Contains(code) Then
                'Debug.Print("Duplicated code! (" & code & ")", True)
                cDuplicates += 1
                Return (True)
            End If

            Return False
        End Function
    End Class
End Class
