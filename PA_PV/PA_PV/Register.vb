Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Register
    Private Function CekDataKosong()
        ' UNTUK MENGECEK SEMUA KOMPONEN APABILA TERDAPAT DATA KOSONG MAKA AKAN DIBERIKAN PERINGATAN
        If txtNIPPegawai.Text = "" Then
            MessageBox.Show("NIP Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNIPPegawai.Focus()
        ElseIf txtUsnPegawai.Text = "" Then
            MessageBox.Show("Username Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsnPegawai.Focus()
        ElseIf txtEmail.Text = "" Then
            MessageBox.Show("Email Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
        ElseIf txtPswPegawai.Text = "" Then
            MessageBox.Show("Password Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPswPegawai.Focus()
        ElseIf txtKonfirPsw.Text = "" Then
            MessageBox.Show("Konfirmasi Password Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPswPegawai.Focus()
        Else
            Return True
        End If
        Return False
    End Function

    Sub Bersih()
        ' UNTUK MENGOSONGKAN SEMUA DATA PADA MASING_MASING KOMPONEN
        txtNIPPegawai.Clear()
        txtUsnPegawai.Clear()
        txtEmail.Clear()
        txtPswPegawai.Clear()
        txtKonfirPsw.Clear()

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

    Private Sub chbShowKonfir_CheckedChanged(sender As Object, e As EventArgs) Handles chbShowKonfir.CheckedChanged
        If chbShow.CheckState = CheckState.Checked Then
            chbHideKonfir.BringToFront()
            txtKonfirPsw.UseSystemPasswordChar = False
        Else
            chbHideKonfir.BringToFront()
            txtKonfirPsw.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub chbHideKonfir_CheckedChanged(sender As Object, e As EventArgs) Handles chbHideKonfir.CheckedChanged
        If chbHide.CheckState = CheckState.Checked Then
            chbShowKonfir.BringToFront()
            txtKonfirPsw.UseSystemPasswordChar = True
        Else
            chbShowKonfir.BringToFront()
            txtKonfirPsw.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If CekDataKosong() = True Then
            ' UNTUK MENGECEK KONFIRMASI PASSWORD SAMA DENGAN PASSWORD YANG DIISI
            If txtKonfirPsw.Text <> txtPswPegawai.Text Then
                MessageBox.Show("Konfirmasi Password Salah!", "Konfirmasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtKonfirPsw.Focus()
            Else
                CMD = New MySqlCommand("SELECT * FROM tbdatapegawai WHERE NIP = '" & txtNIPPegawai.Text & "'", CONN)
                RD = CMD.ExecuteReader
                RD.Read()

                If Not RD.HasRows Then
                    RD.Close()

                    ' MENGISI KOLOM DATABASE (NIP, Nama_Lengkap, Jenis_Kelamin, Tanggal_Lahir, Agama, No_Telpon, Alamat, Foto_Pegawai) SESUAI DENGAN INPUTAN USER PADA MASING-MASING KOMPONEN
                    Dim inputSTR As String = "INSERT INTO tbakunpegawai VALUES ('" & txtNIPPegawai.Text & "','" & txtEmail.Text & "','" & txtUsnPegawai.Text & "','" & txtPswPegawai.Text & "')"
                    CMD = New MySqlCommand(inputSTR, CONN)
                    CMD.ExecuteNonQuery()

                    ' JIKA DATA BERHASIL DITAMBAHKAN MAKA AKAN MUNCUL PEMBERITAHUAN
                    MsgBox("Registrasi Berhasil!", MsgBoxStyle.Information, "Informasi")
                    Login_Pegawai.Show()
                Else
                    ' JIKA NIP YANG INGIN DITAMBAHKAN SUDAH TERDAPAT PADA TABEL AKUNA PEGAWAI MAKA AKAN MUNCUL PEMBERITAHUAN
                    MessageBox.Show("Akun Pegawai dengan NIP " & txtNIPPegawai.Text & " Sudah Pernah Ditambahkan, Silahkan Beralih ke Menu Login !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    RD.Close()
                End If
                Call Bersih()
            End If
        End If
    End Sub

    Private Sub btnLoginPegawai_Click(sender As Object, e As EventArgs)
        Login_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnBatalLogin_Click(sender As Object, e As EventArgs) Handles btnBatalLogin.Click
        Call Bersih()
        txtNIPPegawai.Focus()
    End Sub

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        txtNIPPegawai.Focus()
    End Sub

    Private Sub txtNIPPegawai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIPPegawai.KeyPress
        If e.KeyChar = Chr(13) Then txtEmail.Focus()
    End Sub

    Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress
        If e.KeyChar = Chr(13) Then txtUsnPegawai.Focus()
    End Sub

    Private Sub txtUsnPegawai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsnPegawai.KeyPress
        If e.KeyChar = Chr(13) Then txtPswPegawai.Focus()
    End Sub

    Private Sub txtPswPegawai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPswPegawai.KeyPress
        If e.KeyChar = Chr(13) Then txtKonfirPsw.Focus()
    End Sub

    Private Sub txtKonfirPsw_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKonfirPsw.KeyPress
        If e.KeyChar = Chr(13) Then btnRegister.Focus()
    End Sub
End Class