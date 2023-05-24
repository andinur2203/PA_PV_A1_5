Imports MySql.Data.MySqlClient

Public Class Informasi_Gaji_Pegawai
    Sub Bersih()
        txtKodeGaji.Text = ""
        txtNIP.Text = ""
        txtNama.Text = ""
        txtJabatan.Text = ""
        txtGajiPokok.Text = ""
        txtBulan.Text = ""
        txtTahun.Text = ""
        txtHariKerja.Text = ""
        txtSakit.Text = ""
        txtIzin.Text = ""
        txtTanpaKet.Text = ""
        txtTunjangan.Text = ""
        txtGajiBersih.Text = ""

        txtKodeGaji.Focus()
        txtNIP.Enabled = False
        txtNama.Enabled = False
        txtJabatan.Enabled = False
        txtGajiPokok.Enabled = False
        txtIzin.Enabled = False
        txtSakit.Enabled = False
        txtTanpaKet.Enabled = False
        txtTahun.Enabled = False
        txtBulan.Enabled = False
        txtGajiBersih.Enabled = False
        txtHariKerja.Enabled = False
        txtHadir.Enabled = False
        txtTunjangan.Enabled = False
    End Sub

    Sub TampilDataGaji()
        CMD = New MySqlCommand("SELECT * FROM tbgajipegawai WHERE Kode_Gaji = '" & txtKodeGaji.Text & "'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()

        If RD.HasRows = True Then
            txtNIP.Text = RD.Item(1)
            txtNama.Text = RD.Item(2)
            txtJabatan.Text = RD.Item(3)
            txtGajiPokok.Text = RD.Item(4)
            txtBulan.Text = RD.Item(5)
            txtTahun.Text = RD.Item(6)
            txtHariKerja.Text = RD.Item(7)
            txtSakit.Text = RD.Item(8)
            txtIzin.Text = RD.Item(9)
            txtTanpaKet.Text = RD.Item(10)
            txtHadir.Text = RD.Item(11)
            txtTunjangan.Text = RD.Item(12)
            txtGajiBersih.Text = RD.Item(13)

        Else
            MessageBox.Show("Kode Gaji " & txtKodeGaji.Text & " Belum Ditambahkan, Silahkan Konfirmasi kepada Manager !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RD.Close()
            Call Bersih()
        End If
        RD.Close()
    End Sub

    Private Sub btnFormDataDiri_Click(sender As Object, e As EventArgs) Handles btnFormDataDiri.Click
        ' UNTUK MENAMPILKAN FORM DATA DIRI PEGAWAI DENGAN MEMANGGIL DIRI SENDIRI
        Form_Data_Diri_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnInfoDataDiri_Click(sender As Object, e As EventArgs) Handles btnInfoDataDiri.Click
        ' UNTUK MENAMPILKAN DATA DIRI PEGAWAI
        Informasi_Data_Diri_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnFormAbsen_Click(sender As Object, e As EventArgs) Handles btnFormAbsen.Click
        ' UNTUK MENAMPILKAN FORM ABSENSI PEGAWAI
        Form_Absensi_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnInfoGaji_Click(sender As Object, e As EventArgs) Handles btnInfoGaji.Click
        ' UNTUK MENAMPILKAN GAJI PEGAWAI
        Me.Show()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        ' UNTUK MENUTUP FORM ABSENSI PEGAWAI DAN KEMBALI KE MENU LOGIN
        Dim Logout As String
        Logout = MessageBox.Show("Yakin Keluar Akun Ini?", "Konfirmasi",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Logout = MsgBoxResult.Yes Then
            Me.Close()
            Form_Data_Diri_Pegawai.Close()
            Informasi_Data_Diri_Pegawai.Close()
            Form_Absensi_Pegawai.Close()
            Login.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Call TampilDataGaji()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Bersih()
        txtKodeGaji.Focus()
        txtKodeGaji.Enabled = True
    End Sub

    Private Sub txtKodeGaji_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodeGaji.KeyPress
        If e.KeyChar = Chr(13) Then btnCari.Focus()

        'VALIDASI HANYA ANGKA
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            ErrorProvider1.SetError(txtKodeGaji, "Harus Dalam Angka!")
            e.Handled = True
        Else
            e.Handled = False
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub Informasi_Gaji_Pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUsnPegawai.Text = Form_Data_Diri_Pegawai.lblUsnPegawai.Text
        txtKodeGaji.Focus()
        txtKodeGaji.Enabled = True
        Call Bersih()
        Call koneksi()
    End Sub

End Class