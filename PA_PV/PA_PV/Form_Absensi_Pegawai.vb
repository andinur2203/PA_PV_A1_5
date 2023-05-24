
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Form_Absensi_Pegawai
    Private Function CekDataKosong()
        ' UNTUK MENGECEK SEMUA KOMPONEN APABILA TERDAPAT DATA KOSONG MAKA AKAN DIBERIKAN PERINGATAN
        If cbxNIP.Text = "" Then
            MessageBox.Show("NIP Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbxNIP.Focus()
            cbxNIP.Enabled = True
        ElseIf txtNama.Text = "" Then
            MessageBox.Show("Nama Lengkap Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            txtNama.Enabled = True
        ElseIf cbxKeterangan.Text = "" Then
            MessageBox.Show("Keterangan Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbxKeterangan.Focus()
            cbxKeterangan.Enabled = True
        Else
            Return True
        End If
        Return False
    End Function

    Sub Bersih()
        ' UNTUK MENGOSONGKAN SEMUA DATA PADA MASING_MASING KOMPONEN
        rdbSakit.Checked = False
        rdbIzin.Checked = False
        rdbTanpaKet.Checked = False
        cbxKeterangan.Text = ""

        ' UNTUK MEMFOKUSKAN PENGISIAN FORM PADA TEXTBOX ID PEGAWAI
        cbxNIP.Enabled = True
    End Sub

    Sub Keterangan()
        ' UNTUK MENAMBAHKAN ITEM PADA KOMPONEN COMBOBOX
        With cbxKeterangan
            .Items.Add("Hadir")
            .Items.Add("Tidak Hadir")
        End With
    End Sub

    Sub TampilNIP()
        CMD = New MySqlCommand("SELECT NIP FROM tbdatapegawai WHERE NIP = '" & Form_Data_Diri_Pegawai.txtNIP.Text & "'", CONN)
        RD = CMD.ExecuteReader
        Do While RD.Read
            cbxNIP.Items.Add(RD.Item(0))
        Loop
        RD.Close()
    End Sub

    Sub AturGrid()
        ' UNTUK MENGATUR NAMA HEADER DAN UKURAN PADA DATAGRIDVIEW
        dgvDataAbsensi.Columns(0).HeaderText = "Tanggal Absensi"
        dgvDataAbsensi.Columns(0).Width = 100
        dgvDataAbsensi.Columns(1).HeaderText = "Keterangan"
        dgvDataAbsensi.Columns(1).Width = 100
        dgvDataAbsensi.Columns(2).HeaderText = "Alasan Ketidak Hadiran"
        dgvDataAbsensi.Columns(2).Width = 100
        dgvDataAbsensi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Sub TampilDataAbsensi()
        ' UNTUK MENGAMBIL SEMUA DATA YANG ADA PADA DATABASE UNTUK DITAMPILKAN PADA DATAGRIDVIEW
        DA = New MySqlDataAdapter("SELECT Tanggal_Absensi, Keterangan, Alasan FROM tbabsensipegawai WHERE NIP = '" & Form_Data_Diri_Pegawai.txtNIP.Text & "'", CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "Tanggal_Absensi")
        dgvDataAbsensi.DataSource = DS.Tables("Tanggal_Absensi")
        dgvDataAbsensi.Refresh()
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
        Me.Show()
    End Sub

    Private Sub btnInfoGaji_Click(sender As Object, e As EventArgs) Handles btnInfoGaji.Click
        ' UNTUK MENAMPILKAN GAJI PEGAWAI
        Informasi_Gaji_Pegawai.Show()
        Me.Hide()
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
            Informasi_Gaji_Pegawai.Close()
            Login.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub cbxNIP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNIP.SelectedIndexChanged
        CMD = New MySqlCommand("SELECT * FROM tbdatapegawai WHERE NIP = '" & cbxNIP.Text & "'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()

        If RD.HasRows = True Then
            txtNama.Text = RD.Item(1)
            RD.Close()
        Else
            MessageBox.Show("Data Diri Pegawai dengan NIP " & cbxNIP.Text & " Belum Ditambahkan, Silahkan Isi Formulir Data Diri Pegawai Terlebih Dahulu !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Call Bersih()
        End If
        RD.Close()
    End Sub

    Private Sub cbxKeterangan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxKeterangan.SelectedIndexChanged
        If cbxKeterangan.Text = "Hadir" Then
            rdbIzin.Enabled = False
            rdbSakit.Enabled = False
            rdbTanpaKet.Enabled = False
        ElseIf cbxKeterangan.Text = "Tidak Hadir" Then
            rdbIzin.Enabled = True
            rdbSakit.Enabled = True
            rdbTanpaKet.Enabled = True
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If CekDataKosong() = True Then
            CMD = New MySqlCommand("SELECT * FROM tbabsensipegawai WHERE Tanggal_Absensi = '" & Format(DTPTglAbsen.Value, "dd-MM-yyyy") & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()

            If Not RD.HasRows Then
                ' UNTUK MENGAMBIL VALUE DARI RADIO BUTTON ALASAN KETIDAK HADIRAN
                Dim Alasan As String
                If rdbSakit.Checked = True Then
                    Alasan = rdbSakit.Text
                ElseIf rdbSakit.Checked = True Then
                    Alasan = rdbSakit.Text
                ElseIf rdbTanpaKet.Checked = True Then
                    Alasan = rdbTanpaKet.Text
                End If

                RD.Close()

                Dim inputSTR As String = "INSERT INTO tbabsensipegawai VALUES ('" & cbxNIP.Text & "','" & txtNama.Text & "','" & Format(DTPTglAbsen.Value, "yyyy-MM-dd") & "','" & cbxKeterangan.Text & "','" & Alasan & "')"
                CMD = New MySqlCommand(inputSTR, CONN)
                CMD.ExecuteNonQuery()

                ' JIKA DATA BERHASIL DITAMBAHKAN MAKA AKAN MUNCUL PEMBERITAHUAN
                MsgBox("Absensi pada Tanggal " & Format(DTPTglAbsen.Value, "yyyy-MM-dd") & " Berhasil Ditambahkan ! ...", MsgBoxStyle.Information, "INFORMASI")
            Else
                ' JIKA TANGGAL ABSENSI YANG INGIN DITAMBAHKAN SUDAH TERDAPAT PADA TABEL DATA PEGAWAI MAKA AKAN MUNCUL PEMBERITAHUAN
                MessageBox.Show("Absensi pada Tanggal " & Format(DTPTglAbsen.Value, "yyyy-MM-dd") & "Sudah Pernah Ditambahkan, Silahkan Isi Absensi dengan Tanggal yang Berbeda !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            RD.Close()
            Call TampilNIP()
            Call TampilDataAbsensi()
            txtNama.Focus()
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Bersih()
    End Sub

    Private Sub cbxNIP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbxNIP.KeyPress
        If e.KeyChar = Chr(13) Then DTPTglAbsen.Focus()
    End Sub

    Private Sub DTPTglAbsen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTglAbsen.KeyPress
        If e.KeyChar = Chr(13) Then cbxKeterangan.Focus()
    End Sub

    Private Sub cbxKeterangan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbxKeterangan.KeyPress
        If e.KeyChar = Chr(13) Then rdbSakit.Focus()
    End Sub

    Private Sub rdbSakit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rdbSakit.KeyPress
        If e.KeyChar = Chr(13) Then rdbIzin.Focus()
    End Sub
    Private Sub rdbIzin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rdbIzin.KeyPress
        If e.KeyChar = Chr(13) Then rdbTanpaKet.Focus()
    End Sub

    Private Sub Form_Absensi_Pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' VALIDASI MAX CHAR
        txtNama.MaxLength = 100

        lblUsnPegawai.Text = Form_Data_Diri_Pegawai.lblUsnPegawai.Text
        cbxNIP.Focus()
        cbxNIP.Enabled = True
        txtNama.Enabled = False

        Call koneksi()
        Call Bersih()
        Call Keterangan()
        Call TampilNIP()
        Call TampilDataAbsensi()
        Call AturGrid()
    End Sub
End Class