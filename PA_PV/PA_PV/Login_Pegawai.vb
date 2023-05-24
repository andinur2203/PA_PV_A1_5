Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports MySql.Data.MySqlClient

Public Class Login_Pegawai
    Private Function CekDataKosong()
        ' UNTUK MENGECEK SEMUA KOMPONEN APABILA TERDAPAT DATA KOSONG MAKA AKAN DIBERIKAN PERINGATAN
        If txtNIPPegawai.Text = "" Then
            MessageBox.Show("NIP Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNIPPegawai.Focus()
            txtNIPPegawai.Enabled = True
        ElseIf txtUsnPegawai.Text = "" Then
            MessageBox.Show("Username Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsnPegawai.Focus()
            txtUsnPegawai.Enabled = True
        ElseIf txtPswPegawai.Text = "" Then
            MessageBox.Show("Password Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPswPegawai.Focus()
            txtPswPegawai.Enabled = True
        Else
            Return True
        End If
        Return False
    End Function

    Sub Bersih()
        ' UNTUK MENGOSONGKAN SEMUA DATA PADA MASING_MASING KOMPONEN
        txtNIPPegawai.Clear()
        txtUsnPegawai.Clear()
        txtPswPegawai.Clear()

        ' UNTUK MEMFOKUSKAN PENGISIAN FORM PADA TEXTBOX ID PEGAWAI
        txtNIPPegawai.Enabled = True
    End Sub

    Private Sub chbShow_CheckedChanged(sender As Object, e As EventArgs) Handles chbShow.CheckedChanged
        If chbShow.CheckState = CheckState.Checked Then
            chbHide.BringToFront()
            txtPswPegawai.UseSystemPasswordChar = False
        Else
            chbHide.BringToFront()
            txtPswPegawai.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub chbHide_CheckedChanged(sender As Object, e As EventArgs) Handles chbHide.CheckedChanged
        If chbHide.CheckState = CheckState.Checked Then
            chbShow.BringToFront()
            txtPswPegawai.UseSystemPasswordChar = True
        Else
            chbShow.BringToFront()
            txtPswPegawai.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Login_Pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Bersih()
        txtNIPPegawai.Focus()
    End Sub

    Private Sub btnLoginPegawai_Click(sender As Object, e As EventArgs) Handles btnLoginPegawai.Click
        If CekDataKosong() = True Then
            Call koneksi()
            CMD = New MySqlCommand("SELECT * FROM tbakunpegawai WHERE NIP = '" & txtNIPPegawai.Text & "' AND Username = '" & txtUsnPegawai.Text & "' AND Password = '" & txtPswPegawai.Text & "'", CONN)

            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then
                MessageBox.Show("Anda Telah Berhasil Login !", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information)
                RD.Close()
                Form_Data_Diri_Pegawai.Show()
                Me.Close()
            ElseIf Not RD.HasRows Then
                RD.Close()
                MessageBox.Show("Periksa Kembali NIP, Username dan Password Anda !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNIPPegawai.Focus()
                txtNIPPegawai.Text = ""
                txtUsnPegawai.Text = ""
                txtPswPegawai.Text = ""
            End If
        End If
    End Sub

    Private Sub btnBatalLogin_Click(sender As Object, e As EventArgs) Handles btnBatalLogin.Click
        Call Bersih()
        txtNIPPegawai.Focus()
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Register.Show()
        Me.Hide()
    End Sub

    Private Sub txtNIPPegawai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIPPegawai.KeyPress
        If e.KeyChar = Chr(13) Then txtUsnPegawai.Focus()
    End Sub
    Private Sub txtUsnPegawai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsnPegawai.KeyPress
        If e.KeyChar = Chr(13) Then txtPswPegawai.Focus()
    End Sub

    Private Sub txtPswPegawai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPswPegawai.KeyPress
        If e.KeyChar = Chr(13) Then btnLoginPegawai.Focus()
    End Sub
End Class