Public Class frmConfig

    Private Sub frmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtHotkeySecundary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHotkeySecundary.KeyDown
        txtHotkeySecundary.Text = e.KeyCode
        e.SuppressKeyPress = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        My.Settings.Save()
        Me.Close()
    End Sub
End Class