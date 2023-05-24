Imports MySql.Data.MySqlClient

Public Class Login_Manager
    Private Function CekDataKosong()
        ' UNTUK MENGECEK SEMUA KOMPONEN APABILA TERDAPAT DATA KOSONG MAKA AKAN DIBERIKAN PERINGATAN
        If txtNIPManager.Text = "" Then
            MessageBox.Show("NIP Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNIPManager.Focus()
            txtNIPManager.Enabled = True
        ElseIf txtUsnManager.Text = "" Then
            MessageBox.Show("Username Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsnManager.Focus()
            txtUsnManager.Enabled = True
        ElseIf txtPswManager.Text = "" Then
            MessageBox.Show("Password Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPswManager.Focus()
            txtPswManager.Enabled = True
        Else
            Return True
        End If
        Return False
    End Function

    Sub Bersih()
        ' UNTUK MENGOSONGKAN SEMUA DATA PADA MASING_MASING KOMPONEN
        txtNIPManager.Clear()
        txtUsnManager.Clear()
        txtPswManager.Clear()

        ' UNTUK MEMFOKUSKAN PENGISIAN FORM PADA TEXTBOX ID PEGAWAI
        txtNIPManager.Enabled = True
    End Sub

    Private Sub chbShow_CheckedChanged(sender As Object, e As EventArgs) Handles chbShow.CheckedChanged
        If chbShow.CheckState = CheckState.Checked Then
            chbHide.BringToFront()
            txtPswManager.UseSystemPasswordChar = False
        Else
            chbHide.BringToFront()
            txtPswManager.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub chbHide_CheckedChanged(sender As Object, e As EventArgs) Handles chbHide.CheckedChanged
        If chbHide.CheckState = CheckState.Checked Then
            chbShow.BringToFront()
            txtPswManager.UseSystemPasswordChar = True
        Else
            chbShow.BringToFront()
            txtPswManager.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Login_Pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Bersih()
        txtNIPManager.Focus()
    End Sub

    Private Sub btnLoginManager_Click(sender As Object, e As EventArgs) Handles btnLoginManager.Click
        If CekDataKosong() = True Then
            Call koneksi()
            CMD = New MySqlCommand("SELECT * FROM tbakunmanager WHERE NIP = '" & txtNIPManager.Text & "' AND Username = '" & txtUsnManager.Text & "' AND Password = '" & txtPswManager.Text & "'", CONN)

            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then
                MessageBox.Show("Anda Telah Berhasil Login !", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information)
                RD.Close()
                Form_Penggajian_Pegawai.Show()
                Me.Close()
            ElseIf Not RD.HasRows Then
                RD.Close()
                MessageBox.Show("Periksa Kembali NIP, Username dan Password Anda !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNIPManager.Focus()
                txtNIPManager.Text = ""
                txtUsnManager.Text = ""
                txtPswManager.Text = ""
            End If
        End If
    End Sub

    Private Sub btnBatalLogin_Click(sender As Object, e As EventArgs) Handles btnBatalLogin.Click
        Call Bersih()
        txtNIPManager.Focus()
    End Sub
    Private Sub txtNIPPegawai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIPManager.KeyPress
        If e.KeyChar = Chr(13) Then txtUsnManager.Focus()
    End Sub
    Private Sub txtUsnPegawai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsnManager.KeyPress
        If e.KeyChar = Chr(13) Then txtPswManager.Focus()
    End Sub

    Private Sub txtPswPegawai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPswManager.KeyPress
        If e.KeyChar = Chr(13) Then btnLoginManager.Focus()
    End Sub
End Class