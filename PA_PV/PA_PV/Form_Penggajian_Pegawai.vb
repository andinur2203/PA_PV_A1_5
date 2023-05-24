Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Form_Penggajian_Pegawai
    Dim dataTanpaKet As String
    Private Function CekDataKosong()
        If txtKodeGaji.Text = "" Then
            MessageBox.Show("Kode Gaji Wajib Diisi!", "Konfirmasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtKodeGaji.Focus()
        ElseIf cbxNIP.Text = "" Then
            MessageBox.Show("NIP Wajib Diisi!", "Konfirmasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            cbxNIP.Focus()
        ElseIf txtNama.Text = "" Then
            MessageBox.Show("Nama Wajib Diisi!", "Konfirmasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtNama.Focus()
        ElseIf cbxJabatan.Text = "" Then
            MessageBox.Show("Jabatan Wajib Diisi!", "Konfirmasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            cbxJabatan.Focus()
        ElseIf txtGajiPokok.Text = "" Then
            MessageBox.Show("Gaji Pokok Wajib Diisi!", "Konfirmasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtGajiPokok.Focus()
        ElseIf cbxBulan.Text = "" Then
            MessageBox.Show("Bulan Wajib Diisi!", "Konfirmasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            cbxBulan.Focus()
        ElseIf txtHariKerja.Text = "" Then
            MessageBox.Show("Hari Kerja Wajib Diisi!", "Konfirmasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtHadir.Focus()
        ElseIf txtHadir.Text = "" Then
            MessageBox.Show("Hadir Wajib Diisi!", "Konfirmasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtHadir.Focus()
        ElseIf txtSakit.Text = "" Then
            MessageBox.Show("Sakit Wajib Diisi!", "Konfirmasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtSakit.Focus()
        ElseIf txtTanpaKet.Text = "" Then
            MessageBox.Show("TanpaKet Wajib Diisi!", "Konfirmasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtTanpaKet.Focus()
        ElseIf txtIzin.Text = "" Then
            MessageBox.Show("Izin Wajib Diisi!", "Konfirmasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtIzin.Focus()
        ElseIf txtTunjangan.Text = "" Then
            MessageBox.Show("Tunjangan Wajib Diisi!", "Konfirmasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtTunjangan.Focus()
        ElseIf txtGajiBersih.Text = "" Then
            MessageBox.Show("Gaji Bersih Wajib Diisi!", "Konfirmasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtGajiBersih.Focus()
        Else
            Return True
        End If
        Return False
    End Function

    Sub Bersih()
        txtKodeGaji.Text = ""
        cbxNIP.Text = ""
        txtNama.Text = ""
        cbxJabatan.Text = ""
        txtGajiPokok.Text = ""
        cbxBulan.Text = ""
        txtTahun.Text = ""
        txtHariKerja.Text = ""
        txtHadir.Text = ""
        txtSakit.Text = ""
        txtIzin.Text = ""
        txtTanpaKet.Text = ""
        txtTunjangan.Text = ""
        txtGajiBersih.Text = ""

        txtKodeGaji.Focus()
        txtNama.Enabled = False
        txtGajiPokok.Enabled = False
        txtGajiBersih.Enabled = False
        txtHadir.Enabled = False
        txtHariKerja.Enabled = False
        txtTunjangan.Enabled = False
    End Sub

    Sub TampilDaftarGaji()
        DA = New MySqlDataAdapter("Select Kode_Gaji,NIP,Nama_Lengkap,Bulan,Tahun,Gaji_Bersih From tbgajipegawai", CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "Kode_Gaji")
        Daftar_Gaji_Pegawai.dgvDaftarGaji.DataSource = DS.Tables("Kode_Gaji")
        Daftar_Gaji_Pegawai.dgvDaftarGaji.Refresh()
    End Sub

    Sub TampilNIP()
        CMD = New MySqlCommand("SELECT NIP FROM tbdatapegawai", CONN)
        RD = CMD.ExecuteReader
        Do While RD.Read
            cbxNIP.Items.Add(RD.Item(0))
        Loop
        RD.Close()
    End Sub

    Dim Bulan As String() = {"Januari", "Februari", "Maret", "April", "Mei",
                             "Juni", "Juli", "Agustus", "September",
                             "Oktober", "November", "Desember"}

    Dim Jabatan As String() = {"Redaktur", "Wakil Redaksi", "General Manager", "Presenter", "News Reporter"}

    Public Sub Hadir()
        Dim HariKerja, Sakit, Izin, TanpaKet, Hadir As Integer
        HariKerja = Val(txtHariKerja.Text)
        Sakit = Val(txtSakit.Text)
        Izin = Val(txtIzin.Text)
        TanpaKet = Val(txtTanpaKet.Text)

        Hadir = HariKerja - Sakit - Izin - TanpaKet
        txtHadir.Text = Hadir
    End Sub

    Public Sub Jumlah_Sakit()
        Dim TglAwal, TglAkhir As String

        If cbxBulan.SelectedItem = "Januari" Then
            TglAwal = txtTahun.Text + "-01-01"
            TglAkhir = txtTahun.Text + "-01-30"
        ElseIf cbxBulan.SelectedItem = "Februari" Then
            TglAwal = txtTahun.Text + "-02-01"
            TglAkhir = txtTahun.Text + "-02-28"
        ElseIf cbxBulan.SelectedItem = "Maret" Then
            TglAwal = txtTahun.Text + "-03-01"
            TglAkhir = txtTahun.Text + "-03-31"
        ElseIf cbxBulan.SelectedItem = "April" Then
            TglAwal = txtTahun.Text + "-04-01"
            TglAkhir = txtTahun.Text + "-04-30"
        ElseIf cbxBulan.SelectedItem = "Mei" Then
            TglAwal = txtTahun.Text + "-05-01"
            TglAkhir = txtTahun.Text + "-05-31"
        ElseIf cbxBulan.SelectedItem = "Juni" Then
            TglAwal = txtTahun.Text + "-06-01"
            TglAkhir = txtTahun.Text + "-06-30"
        ElseIf cbxBulan.SelectedItem = "Juli" Then
            TglAwal = txtTahun.Text + "-07-01"
            TglAkhir = txtTahun.Text + "-07-31"
        ElseIf cbxBulan.SelectedItem = "Agustus" Then
            TglAwal = txtTahun.Text + "-08-01"
            TglAkhir = txtTahun.Text + "-08-31"
        ElseIf cbxBulan.SelectedItem = "September" Then
            TglAwal = txtTahun.Text + "-09-01"
            TglAkhir = txtTahun.Text + "-09-30"
        ElseIf cbxBulan.SelectedItem = "Oktober" Then
            TglAwal = txtTahun.Text + "-10-01"
            TglAkhir = txtTahun.Text + "-10-31"
        ElseIf cbxBulan.SelectedItem = "November" Then
            TglAwal = txtTahun.Text + "-11-01"
            TglAkhir = txtTahun.Text + "-11-31"
        ElseIf cbxBulan.SelectedItem = "Desember" Then
            TglAwal = txtTahun.Text + "-12-01"
            TglAkhir = txtTahun.Text + "-12-31"
        End If


        RD.Close()
        CMD = New MySqlCommand("SELECT COUNT(Alasan) FROM tbabsensipegawai WHERE Alasan = 'Sakit' AND (Tanggal_Absensi BETWEEN'" & TglAwal & "' AND '" & TglAkhir & "')", CONN)
        RD = CMD.ExecuteReader
        RD.Read()

        'While RD.Read
        '    txtSakit.Text = RD.GetValue(0)
        'End While


        'MsgBox(RD.Item(0))
        If RD.HasRows Then
            txtSakit.Text = RD.Item(0)
        End If

        'If Not RD.HasRows Then
        '    MessageBox.Show("Pegawai dengan Nama " & txtNama.Text & " Belum Melengkapi Data Absensi !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        RD.Close()
    End Sub

    Public Sub Jumlah_Izin()
        Dim TglAwal, TglAkhir As String

        If cbxBulan.SelectedItem = "Januari" Then
            TglAwal = txtTahun.Text + "-01-01"
            TglAkhir = txtTahun.Text + "-01-30"
        ElseIf cbxBulan.SelectedItem = "Februari" Then
            TglAwal = txtTahun.Text + "-02-01"
            TglAkhir = txtTahun.Text + "-02-28"
        ElseIf cbxBulan.SelectedItem = "Maret" Then
            TglAwal = txtTahun.Text + "-03-01"
            TglAkhir = txtTahun.Text + "-03-31"
        ElseIf cbxBulan.SelectedItem = "April" Then
            TglAwal = txtTahun.Text + "-04-01"
            TglAkhir = txtTahun.Text + "-04-30"
        ElseIf cbxBulan.SelectedItem = "Mei" Then
            TglAwal = txtTahun.Text + "-05-01"
            TglAkhir = txtTahun.Text + "-05-31"
        ElseIf cbxBulan.SelectedItem = "Juni" Then
            TglAwal = txtTahun.Text + "-06-01"
            TglAkhir = txtTahun.Text + "-06-30"
        ElseIf cbxBulan.SelectedItem = "Juli" Then
            TglAwal = txtTahun.Text + "-07-01"
            TglAkhir = txtTahun.Text + "-07-31"
        ElseIf cbxBulan.SelectedItem = "Agustus" Then
            TglAwal = txtTahun.Text + "-08-01"
            TglAkhir = txtTahun.Text + "-08-31"
        ElseIf cbxBulan.SelectedItem = "September" Then
            TglAwal = txtTahun.Text + "-09-01"
            TglAkhir = txtTahun.Text + "-09-30"
        ElseIf cbxBulan.SelectedItem = "Oktober" Then
            TglAwal = txtTahun.Text + "-10-01"
            TglAkhir = txtTahun.Text + "-10-31"
        ElseIf cbxBulan.SelectedItem = "November" Then
            TglAwal = txtTahun.Text + "-11-01"
            TglAkhir = txtTahun.Text + "-11-31"
        ElseIf cbxBulan.SelectedItem = "Desember" Then
            TglAwal = txtTahun.Text + "-12-01"
            TglAkhir = txtTahun.Text + "-12-31"
        End If


        RD.Close()
        CMD = New MySqlCommand("SELECT COUNT(Alasan) FROM tbabsensipegawai WHERE Alasan = 'Izin' AND (Tanggal_Absensi BETWEEN'" & TglAwal & "' AND '" & TglAkhir & "')", CONN)
        RD = CMD.ExecuteReader
        RD.Read()

        'While RD.Read
        '    txtSakit.Text = RD.GetValue(0)
        'End While


        'MsgBox(RD.Item(0))
        If RD.HasRows Then
            txtIzin.Text = RD.Item(0)
        End If

        'If Not RD.HasRows Then
        '    MessageBox.Show("Pegawai dengan Nama " & txtNama.Text & " Belum Melengkapi Data Absensi !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        RD.Close()
    End Sub

    Public Sub Jumlah_TanpaKet()
        Dim TglAwal, TglAkhir As String

        If cbxBulan.SelectedItem = "Januari" Then
            TglAwal = txtTahun.Text + "-01-01"
            TglAkhir = txtTahun.Text + "-01-30"
        ElseIf cbxBulan.SelectedItem = "Februari" Then
            TglAwal = txtTahun.Text + "-02-01"
            TglAkhir = txtTahun.Text + "-02-28"
        ElseIf cbxBulan.SelectedItem = "Maret" Then
            TglAwal = txtTahun.Text + "-03-01"
            TglAkhir = txtTahun.Text + "-03-31"
        ElseIf cbxBulan.SelectedItem = "April" Then
            TglAwal = txtTahun.Text + "-04-01"
            TglAkhir = txtTahun.Text + "-04-30"
        ElseIf cbxBulan.SelectedItem = "Mei" Then
            TglAwal = txtTahun.Text + "-05-01"
            TglAkhir = txtTahun.Text + "-05-31"
        ElseIf cbxBulan.SelectedItem = "Juni" Then
            TglAwal = txtTahun.Text + "-06-01"
            TglAkhir = txtTahun.Text + "-06-30"
        ElseIf cbxBulan.SelectedItem = "Juli" Then
            TglAwal = txtTahun.Text + "-07-01"
            TglAkhir = txtTahun.Text + "-07-31"
        ElseIf cbxBulan.SelectedItem = "Agustus" Then
            TglAwal = txtTahun.Text + "-08-01"
            TglAkhir = txtTahun.Text + "-08-31"
        ElseIf cbxBulan.SelectedItem = "September" Then
            TglAwal = txtTahun.Text + "-09-01"
            TglAkhir = txtTahun.Text + "-09-30"
        ElseIf cbxBulan.SelectedItem = "Oktober" Then
            TglAwal = txtTahun.Text + "-10-01"
            TglAkhir = txtTahun.Text + "-10-31"
        ElseIf cbxBulan.SelectedItem = "November" Then
            TglAwal = txtTahun.Text + "-11-01"
            TglAkhir = txtTahun.Text + "-11-31"
        ElseIf cbxBulan.SelectedItem = "Desember" Then
            TglAwal = txtTahun.Text + "-12-01"
            TglAkhir = txtTahun.Text + "-12-31"
        End If


        RD.Close()
        CMD = New MySqlCommand("SELECT COUNT(Alasan) FROM tbabsensipegawai WHERE Alasan = 'Tanpa Keterangan' AND (Tanggal_Absensi BETWEEN'" & TglAwal & "' AND '" & TglAkhir & "')", CONN)
        RD = CMD.ExecuteReader
        RD.Read()

        'While RD.Read
        '    txtSakit.Text = RD.GetValue(0)
        'End While


        'MsgBox(RD.Item(0))
        If RD.HasRows Then
            txtTanpaKet.Text = RD.Item(0)
        End If

        'If Not RD.HasRows Then
        '    MessageBox.Show("Pegawai dengan Nama " & txtNama.Text & " Belum Melengkapi Data Absensi !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        RD.Close()
    End Sub

    Public Sub HtngTunjangan()
        Dim HariKerja, Sakit, Izin, TanpaKet, Tunjangan As Integer
        HariKerja = Val(txtHariKerja.Text) * 50000
        Sakit = Val(txtSakit.Text) * 20000
        Izin = Val(txtIzin.Text) * 5000
        TanpaKet = Val(txtTanpaKet.Text) * 30000

        Tunjangan = Val(HariKerja - Sakit - Izin - TanpaKet)
        txtTunjangan.Text = Tunjangan
    End Sub

    Public Sub HtngGajiBrsh()
        Dim GajiPokok, Tunjangan, GajiBersih As Integer
        GajiPokok = Val(txtGajiPokok.Text)
        Tunjangan = Val(txtTunjangan.Text)

        GajiBersih = Val(GajiPokok + Tunjangan)
        txtGajiBersih.Text = GajiBersih
    End Sub

    Private Sub cbxNIP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNIP.SelectedIndexChanged
        CMD = New MySqlCommand("SELECT * FROM tbdatapegawai WHERE NIP='" & cbxNIP.Text & "'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()

        If RD.HasRows Then
            txtNama.Text = RD.Item(1)
        Else
            MessageBox.Show("Data Diri Pegawai dengan NIP " & cbxNIP.Text & " Belum Ditambahkan, Silahkan Isi Formulir Data Diri Pegawai Terlebih Dahulu !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        RD.Close()
    End Sub

    Private Sub cbxJabatan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxJabatan.SelectedIndexChanged
        If cbxJabatan.SelectedItem = "Redaktur" Then
            txtGajiPokok.Text = 5900000
        ElseIf cbxJabatan.SelectedItem = "Wakil Redaksi" Then
            txtGajiPokok.Text = 5000000
        ElseIf cbxJabatan.SelectedItem = "General Manager" Then
            txtGajiPokok.Text = 6800000
        ElseIf cbxJabatan.SelectedItem = "Presenter" Then
            txtGajiPokok.Text = 4200000
        ElseIf cbxJabatan.SelectedItem = "News Reporter" Then
            txtGajiPokok.Text = 3300000
        End If
        Call HtngTunjangan()
        Call HtngGajiBrsh()
    End Sub

    Private Sub cbxBulan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBulan.SelectedIndexChanged

        If cbxBulan.SelectedItem = "Januari" Then
            txtHariKerja.Text = 31 - 4
        ElseIf cbxBulan.SelectedItem = "Februari" Then
            txtHariKerja.Text = 28 - 4
        ElseIf cbxBulan.SelectedItem = "Maret" Then
            txtHariKerja.Text = 31 - 4
        ElseIf cbxBulan.SelectedItem = "April" Then
            txtHariKerja.Text = 30 - 4
        ElseIf cbxBulan.SelectedItem = "Mei" Then
            txtHariKerja.Text = 31 - 4
        ElseIf cbxBulan.SelectedItem = "Juni" Then
            txtHariKerja.Text = 30 - 4
        ElseIf cbxBulan.SelectedItem = "Juli" Then
            txtHariKerja.Text = 31 - 4
        ElseIf cbxBulan.SelectedItem = "Agustus" Then
            txtHariKerja.Text = 31 - 4
        ElseIf cbxBulan.SelectedItem = "September" Then
            txtHariKerja.Text = 30 - 4
        ElseIf cbxBulan.SelectedItem = "Oktober" Then
            txtHariKerja.Text = 31 - 4
        ElseIf cbxBulan.SelectedItem = "November" Then
            txtHariKerja.Text = 30 - 4
        ElseIf cbxBulan.SelectedItem = "Desember" Then
            txtHariKerja.Text = 31 - 4
        End If
        Call Jumlah_Sakit()
        Call Jumlah_Izin()
        Call Jumlah_TanpaKet()

        Call HtngGajiBrsh()
    End Sub

    Private Sub txtSakit_TextChanged(sender As Object, e As EventArgs) Handles txtSakit.TextChanged
        Call Jumlah_Sakit()
        Call HtngTunjangan()
        Call HtngGajiBrsh()
        Call Hadir()
    End Sub

    Private Sub txtIzin_TextChanged(sender As Object, e As EventArgs) Handles txtIzin.TextChanged
        Call HtngTunjangan()
        Call HtngGajiBrsh()
        Call Hadir()
    End Sub

    Private Sub txtTanpaKet_TextChanged(sender As Object, e As EventArgs) Handles txtTanpaKet.TextChanged
        Call HtngTunjangan()
        Call HtngGajiBrsh()
        Call Hadir()
    End Sub

    Private Sub txtHariKerja_TextChanged(sender As Object, e As EventArgs) Handles txtHariKerja.TextChanged
        Call Hadir()
    End Sub

    Private Sub btnDaftarDataDiri_Click(sender As Object, e As EventArgs) Handles btnDaftarDataDiri.Click
        Daftar_Data_Diri_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnDaftarAbsensi_Click(sender As Object, e As EventArgs) Handles btnDaftarAbsensi.Click
        Daftar_Absensi_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnFormGaji_Click(sender As Object, e As EventArgs) Handles btnFormGaji.Click
        Me.Show()
    End Sub

    Private Sub btnDaftarGaji_Click(sender As Object, e As EventArgs) Handles btnDaftarGaji.Click
        Daftar_Gaji_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        ' UNTUK MENUTUP FORM PENGGAJIAN PEGAWAI DAN KEMBALI KE MENU LOGIN
        Dim Logout As String
        Logout = MessageBox.Show("Yakin Keluar Akun Ini?", "Konfirmasi",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Logout = MsgBoxResult.Yes Then
            Login.Show()
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If CekDataKosong() = True Then
            CMD = New MySqlCommand("Select * From tbgajipegawai where Kode_Gaji='" & txtKodeGaji.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()

            If Not RD.HasRows Then
                RD.Close()
                Dim Simpan As String = "insert into tbgajipegawai(Kode_Gaji, NIP, Nama_Lengkap, Jabatan, Gaji_Pokok, Bulan, Tahun, Hari_Kerja, Sakit, Izin, Tanpa_Ket, Hadir, Tunjangan, Gaji_Bersih) VALUES
                                        ('" & txtKodeGaji.Text & "','" & cbxNIP.Text & "','" & txtNama.Text & "','" & cbxJabatan.Text & "',
                                        '" & txtGajiPokok.Text & "','" & cbxBulan.Text & "',
                                        '" & txtTahun.Text & "',
                                        '" & txtHariKerja.Text & "','" & txtSakit.Text & "',
                                        '" & txtIzin.Text & "','" & txtTanpaKet.Text & "','" & txtHadir.Text & "',
                                        '" & txtTunjangan.Text & "','" & txtGajiBersih.Text & "')"
                CMD = New MySqlCommand(Simpan, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Gaji Pegawai dengan Kode Gaji " & txtKodeGaji.Text & " Berhasil Ditambahkan ! ...", MsgBoxStyle.Information, "INFORMASI")
            Else
                MessageBox.Show("Gaji Pegawai dengan Kode Gaji " & txtKodeGaji.Text & " Sudah Pernah Ditambahkan, Silahkan Isi Form Penggajian Pegawai dengan Kode Gaji yang Berbeda !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                RD.Close()
            End If
            Call TampilDaftarGaji()
            Call Bersih()
            txtKodeGaji.Focus()
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Bersih()
        txtKodeGaji.Focus()
    End Sub

    Private Sub txtKodeGaji_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodeGaji.KeyPress
        If e.KeyChar = Chr(13) Then cbxNIP.Focus()

        'VALIDASI HANYA ANGKA
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            ErrorProvider1.SetError(txtKodeGaji, "Harus Dalam Angka!")
            e.Handled = True
        Else
            e.Handled = False
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub cbxNIP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbxNIP.KeyPress
        If e.KeyChar = Chr(13) Then cbxJabatan.Focus()
    End Sub

    Private Sub cbxJabatan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbxJabatan.KeyPress
        If e.KeyChar = Chr(13) Then cbxBulan.Focus()
    End Sub

    Private Sub cbxBulan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbxBulan.KeyPress
        If e.KeyChar = Chr(13) Then txtTahun.Focus()
    End Sub

    Private Sub txtTahun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTahun.KeyPress
        Call Jumlah_Sakit()
        If e.KeyChar = Chr(13) Then txtSakit.Focus()

        'VALIDASI HANYA ANGKA
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            ErrorProvider1.SetError(txtTahun, "Harus Dalam Angka!")
            e.Handled = True
        Else
            e.Handled = False
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub txtSakit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSakit.KeyPress
        If e.KeyChar = Chr(13) Then txtIzin.Focus()
    End Sub

    Private Sub txtIzin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIzin.KeyPress
        If e.KeyChar = Chr(13) Then txtTanpaKet.Focus()
    End Sub


    Private Sub Form_Penggajian_Pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUsnManager.Text = Login_Manager.txtNIPManager.Text
        ' VALIDASI MAX CHAR
        txtNama.MaxLength = 100
        txtKodeGaji.MaxLength = 9
        txtTahun.MaxLength = 4

        Call Bersih()
        Call koneksi()
        Call TampilDaftarGaji()
        Call TampilNIP()
        txtKodeGaji.Focus()
        cbxJabatan.Items.AddRange(Jabatan)
        cbxBulan.Items.AddRange(Bulan)
    End Sub
End Class