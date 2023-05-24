Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Daftar_Data_Diri_Pegawai
    Sub AturGrid()
        ' UNTUK MENGATUR NAMA HEADER DAN UKURAN PADA DATAGRIDVIEW
        dgvDaftarPegawai.RowTemplate.Height = 150
        dgvDaftarPegawai.Columns(0).HeaderText = "NIP"
        dgvDaftarPegawai.Columns(0).Width = 100
        dgvDaftarPegawai.Columns(1).HeaderText = "Nama Lengkap"
        dgvDaftarPegawai.Columns(1).Width = 175
        dgvDaftarPegawai.Columns(2).HeaderText = "Jenis Kelamin"
        dgvDaftarPegawai.Columns(2).Width = 100
        dgvDaftarPegawai.Columns(3).HeaderText = "Tanggal Lahir"
        dgvDaftarPegawai.Columns(3).Width = 90
        dgvDaftarPegawai.Columns(4).HeaderText = "Agama"
        dgvDaftarPegawai.Columns(4).Width = 75
        dgvDaftarPegawai.Columns(5).HeaderText = "No. Telpon"
        dgvDaftarPegawai.Columns(5).Width = 120
        dgvDaftarPegawai.Columns(6).HeaderText = "Alamat"
        dgvDaftarPegawai.Columns(6).Width = 160
        dgvDaftarPegawai.Columns(7).HeaderText = "Foto Pegawai"
        dgvDaftarPegawai.Columns(7).Width = 100
        DirectCast(dgvDaftarPegawai.Columns(7), DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Stretch
        dgvDaftarPegawai.Columns("NIP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDaftarPegawai.Columns("Agama").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Sub TampilDaftarPegawai()
        ' UNTUK MENGAMBIL SEMUA DATA YANG ADA PADA DATABASE UNTUK DITAMPILKAN PADA DATAGRIDVIEW
        DA = New MySqlDataAdapter("SELECT * FROM tbdatapegawai", CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "NIP")
        dgvDaftarPegawai.DataSource = DS.Tables("NIP")
        dgvDaftarPegawai.Refresh()
    End Sub

    Private Sub btnDaftarDataDiri_Click(sender As Object, e As EventArgs) Handles btnDaftarDataDiri.Click
        Me.Show()
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
        Daftar_Gaji_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        ' UNTUK MENUTUP DAFTAR DATA DIRI PEGAWAI DAN KEMBALI KE MENU LOGIN
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

    Private Sub Daftar_Data_Diri_Pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUsnManager.Text = Form_Penggajian_Pegawai.lblUsnManager.Text
        Call koneksi()
        Call TampilDaftarPegawai()
        Call AturGrid()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        CMD = New MySqlCommand("SELECT * FROM tbdatapegawai WHERE Nama_Lengkap  like '%" & txtCari.Text & "%'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()

        If RD.HasRows Then
            RD.Close()
            DA = New MySqlDataAdapter("SELECT * FROM tbdatapegawai WHERE Nama_Lengkap  like '%" & txtCari.Text & "%'", CONN)
            DS = New DataSet
            DA.Fill(DS, "Dapat")
            dgvDaftarPegawai.DataSource = DS.Tables("Dapat")
            dgvDaftarPegawai.ReadOnly = True
        Else
            MsgBox("Data Tidak Dapat Ditemukan ! ...", MsgBoxStyle.Information, "INFORMASI")
        End If
        RD.Close()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If MessageBox.Show("Yakin Ingin Menghapus Data : " & dgvDaftarPegawai.Item(1, dgvDaftarPegawai.CurrentRow.Index).Value & " ?", "Konfirmasi",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If dgvDaftarPegawai.CurrentRow.Index <> dgvDaftarPegawai.NewRowIndex Then
                Dim Hapus As String = "DELETE From tbdatapegawai WHERE NIP = '" & dgvDaftarPegawai.Item(0, dgvDaftarPegawai.CurrentRow.Index).Value & "'; DELETE From tbakunpegawai WHERE NIP='" & dgvDaftarPegawai.Item(0, dgvDaftarPegawai.CurrentRow.Index).Value & "'"
                CMD = New MySqlCommand(Hapus, CONN)
                CMD.ExecuteNonQuery()

                dgvDaftarPegawai.Rows.RemoveAt(dgvDaftarPegawai.CurrentRow.Index)
            End If
        End If
        Call TampilDaftarPegawai()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call TampilDaftarPegawai()
    End Sub
End Class