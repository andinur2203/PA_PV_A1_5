Public Class Login
    Private Sub btnManager_Click(sender As Object, e As EventArgs) Handles btnManager.Click
        Login_Manager.Show()
        Me.Hide()
    End Sub

    Private Sub btnPegawai_Click(sender As Object, e As EventArgs) Handles btnPegawai.Click
        Login_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dim keluar As String
        keluar = MessageBox.Show("Apakah anda yakin ingin keluar dari sistem?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If keluar = MsgBoxResult.Yes Then
            End
        Else
            Exit Sub
        End If
    End Sub
End Class