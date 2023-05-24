Imports MySql.Data.MySqlClient

Public Class Daftar_Absensi_Pegawai
    Sub AturGrid()
        ' UNTUK MENGATUR NAMA HEADER DAN UKURAN PADA DATAGRIDVIEW
        dgvDaftarAbsensi.Columns(0).HeaderText = "NIP"
        dgvDaftarAbsensi.Columns(0).Width = 175
        dgvDaftarAbsensi.Columns(1).HeaderText = "Nama Lengkap"
        dgvDaftarAbsensi.Columns(1).Width = 250
        dgvDaftarAbsensi.Columns(2).HeaderText = "Tanggal Absensi"
        dgvDaftarAbsensi.Columns(2).Width = 150
        dgvDaftarAbsensi.Columns(3).HeaderText = "Keterangan"
        dgvDaftarAbsensi.Columns(3).Width = 150
        dgvDaftarAbsensi.Columns(4).HeaderText = "Alasan Ketidak Hadiran"
        dgvDaftarAbsensi.Columns(4).Width = 200
        dgvDaftarAbsensi.Columns("NIP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDaftarAbsensi.Columns("Tanggal_Absensi").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Sub TampilDaftarAbsensi()
        ' UNTUK MENGAMBIL SEMUA DATA YANG ADA PADA DATABASE UNTUK DITAMPILKAN PADA DATAGRIDVIEW
        DA = New MySqlDataAdapter("SELECT * FROM tbabsensipegawai", CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "NIP")
        dgvDaftarAbsensi.DataSource = DS.Tables("NIP")
        dgvDaftarAbsensi.Refresh()
    End Sub
    Private Sub btnDaftarDataDiri_Click(sender As Object, e As EventArgs) Handles btnDaftarDataDiri.Click
        Daftar_Data_Diri_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnDaftarAbsensi_Click(sender As Object, e As EventArgs) Handles btnDaftarAbsensi.Click
        Me.Show()
    End Sub

    Private Sub btnFormGaji_Click(sender As Object, e As EventArgs) Handles btnFormGaji.Click
        Form_Penggajian_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnDaftarGaji_Click(sender As Object, e As EventArgs) Handles btnDaftarGaji.Click
        Daftar_Gaji_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        ' UNTUK MENUTUP DAFTAR ABSENSI PEGAWAI DAN KEMBALI KE MENU LOGIN
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

    Private Sub Daftar_Absensi_Pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUsnManager.Text = Form_Penggajian_Pegawai.lblUsnManager.Text
        Call koneksi()
        Call TampilDaftarAbsensi()
        Call AturGrid()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        CMD = New MySqlCommand("SELECT * FROM tbabsensipegawai WHERE Nama_Lengkap  like '%" & txtCari.Text & "%'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()

        If RD.HasRows Then
            RD.Close()
            DA = New MySqlDataAdapter("SELECT * FROM tbabsensipegawai WHERE Nama_Lengkap  like '%" & txtCari.Text & "%'", CONN)
            DS = New DataSet
            DA.Fill(DS, "Dapat")
            dgvDaftarAbsensi.DataSource = DS.Tables("Dapat")
            dgvDaftarAbsensi.ReadOnly = True
        Else
            MsgBox("Data Tidak Dapat Ditemukan ! ...", MsgBoxStyle.Information, "INFORMASI")
        End If
        RD.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call TampilDaftarAbsensi()
    End Sub
End Class