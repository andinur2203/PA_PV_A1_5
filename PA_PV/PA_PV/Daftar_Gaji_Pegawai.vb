Imports MySql.Data.MySqlClient

Public Class Daftar_Gaji_Pegawai
    Sub AturGrid()
        ' UNTUK MENGATUR NAMA HEADER DAN UKURAN PADA DATAGRIDVIEW
        dgvDaftarGaji.Columns(0).Width = 160
        dgvDaftarGaji.Columns(1).Width = 170
        dgvDaftarGaji.Columns(2).Width = 200
        dgvDaftarGaji.Columns(3).Width = 120
        dgvDaftarGaji.Columns(4).Width = 100
        dgvDaftarGaji.Columns(5).Width = 175

        dgvDaftarGaji.Columns(0).HeaderText = "Kode Gaji"
        dgvDaftarGaji.Columns(1).HeaderText = "NIP"
        dgvDaftarGaji.Columns(2).HeaderText = "Nama Pegawai"
        dgvDaftarGaji.Columns(3).HeaderText = "Bulan"
        dgvDaftarGaji.Columns(4).HeaderText = "Tahun"
        dgvDaftarGaji.Columns(5).HeaderText = "Gaji Bersih"


        dgvDaftarGaji.Columns("Kode_Gaji").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDaftarGaji.Columns("NIP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDaftarGaji.Columns("Tahun").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDaftarGaji.Columns("Gaji_Bersih").DefaultCellStyle.Format = "Rp#"
    End Sub

    Sub TampilDaftarGaji()
        DA = New MySqlDataAdapter("Select Kode_Gaji,NIP,Nama_Lengkap,Bulan,Tahun,Gaji_Bersih From tbgajipegawai", CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "Kode_Gaji")
        dgvDaftarGaji.DataSource = DS.Tables("Kode_Gaji")
        dgvDaftarGaji.Refresh()
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
        Form_Penggajian_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnDaftarGaji_Click(sender As Object, e As EventArgs) Handles btnDaftarGaji.Click
        Me.Show()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        ' UNTUK MENUTUP DAFTAR GAJI PEGAWAI DAN KEMBALI KE MENU LOGIN
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
        Call TampilDaftarGaji()
        Call AturGrid()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        CMD = New MySqlCommand("SELECT * FROM tbgajipegawai WHERE Nama_Lengkap  like '%" & txtCari.Text & "%'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()

        If RD.HasRows Then
            RD.Close()
            DA = New MySqlDataAdapter("SELECT * FROM tbgajipegawai WHERE Nama_Lengkap  like '%" & txtCari.Text & "%'", CONN)
            DS = New DataSet
            DA.Fill(DS, "Dapat")
            dgvDaftarGaji.DataSource = DS.Tables("Dapat")
            dgvDaftarGaji.ReadOnly = True
        Else
            MsgBox("Data Tidak Dapat Ditemukan ! ...", MsgBoxStyle.Information, "INFORMASI")
        End If
        RD.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call TampilDaftarGaji()
    End Sub
End Class