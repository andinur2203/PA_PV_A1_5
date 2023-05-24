Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class Form_Data_Diri_Pegawai
    Private Function CekDataKosong()
        ' UNTUK MENGECEK SEMUA KOMPONEN APABILA TERDAPAT DATA KOSONG MAKA AKAN DIBERIKAN PERINGATAN
        If txtNIP.Text = "" Then
            MessageBox.Show("NIP Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNIP.Focus()
            txtNIP.Enabled = False
        ElseIf txtNama.Text = "" Then
            MessageBox.Show("Nama Lengkap Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            txtNama.Enabled = True
        ElseIf rdbLaki.Checked = False And rdbPerempuan.Checked = False Then
            MessageBox.Show("Jenis Kelamin Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf cbxAgama.Text = "" Then
            MessageBox.Show("Agama Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbxAgama.Focus()
            cbxAgama.Enabled = True
        ElseIf txtNoTelp.Text = "" Then
            MessageBox.Show("No. Telpon Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNoTelp.Focus()
            txtNoTelp.Enabled = True
        ElseIf txtAlamat.Text = "" Then
            MessageBox.Show("Alamat Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAlamat.Focus()
            txtAlamat.Enabled = True
        ElseIf ptbFoto.Image Is Nothing Then
            MessageBox.Show("Foto Pegawai Wajib Diisi!", "Konfirmasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btnUpload.Focus()
            ptbFoto.Enabled = True
        Else
            Return True
        End If
        Return False
    End Function

    Sub Bersih()
        ' UNTUK MENGOSONGKAN SEMUA DATA PADA MASING_MASING KOMPONEN
        txtNama.Clear()
        rdbLaki.Checked = False
        rdbPerempuan.Checked = False
        cbxAgama.Text = ""
        txtNoTelp.Clear()
        txtAlamat.Clear()
        ptbFoto.Image = Nothing


        ' UNTUK MEMFOKUSKAN PENGISIAN FORM PADA TEXTBOX ID PEGAWAI
        txtNIP.Enabled = False
    End Sub

    Sub Agama()
        ' UNTUK MENAMBAHKAN ITEM PADA KOMPONEN COMBOBOX
        With cbxAgama
            .Items.Add("Islam")
            .Items.Add("Kristen")
            .Items.Add("Katolik")
            .Items.Add("Hindu")
            .Items.Add("Buddha")
            .Items.Add("Konghucu")
        End With
    End Sub

    Sub TampilNIP()
        CMD = New MySqlCommand("SELECT NIP FROM tbakunpegawai WHERE NIP = '" & Login_Pegawai.txtNIPPegawai.Text & "'", CONN)
        RD = CMD.ExecuteReader
        While RD.Read
            txtNIP.Text = RD.GetValue(0)
        End While
        RD.Close()
    End Sub

    Sub TampilDataPegawai()
        ' UNTUK MENGAMBIL SEMUA DATA YANG ADA PADA DATABASE UNTUK DITAMPILKAN PADA DATAGRIDVIEW
        DA = New MySqlDataAdapter("SELECT * FROM tbdatapegawai", CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "NIP")
        Daftar_Data_Diri_Pegawai.dgvDaftarPegawai.DataSource = DS.Tables("NIP")
        Daftar_Data_Diri_Pegawai.Refresh()
    End Sub

    Private Sub btnFormDataDiri_Click(sender As Object, e As EventArgs) Handles btnFormDataDiri.Click
        ' UNTUK MENAMPILKAN FORM DATA DIRI PEGAWAI DENGAN MEMANGGIL DIRI SENDIRI
        Me.Show()
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
        Informasi_Gaji_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        ' UNTUK MENUTUP FORM DATA DIRI PEGAWAI DAN KEMBALI KE MENU LOGIN
        Dim Logout As String
        Logout = MessageBox.Show("Yakin Keluar Akun Ini?", "Konfirmasi",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Logout = MsgBoxResult.Yes Then
            Me.Close()
            Form_Absensi_Pegawai.Close()
            Informasi_Data_Diri_Pegawai.Close()
            Informasi_Gaji_Pegawai.Close()
            Login.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        ' UNTUK MEMFILTER FORMAT GAMBAR YANG AKAN DIPILIH
        Dim BukaFile As New OpenFileDialog
        BukaFile.Filter = "Pilih Foto(*.jpg; *.png)|*.jpg; *.png"
        If BukaFile.ShowDialog = DialogResult.OK Then
            ptbFoto.Image = Image.FromFile(BukaFile.FileName)
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        ' UNTUK MENGOSONGKAN SEMUA DATA YANG ADA PADA MASING-MASING KOMPONEN
        Call Bersih()
        txtNama.Focus()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If CekDataKosong() = True Then
            CMD = New MySqlCommand("SELECT * FROM tbdatapegawai WHERE NIP = '" & txtNIP.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()

            If Not RD.HasRows Then
                ' UNTUK MENGAMBIL VALUE DARI RADIO BUTTON JENIS KELAMIN
                Dim Jenis_Kelamin As String
                If rdbLaki.Checked = True Then
                    Jenis_Kelamin = rdbLaki.Text
                ElseIf rdbPerempuan.Checked = True Then
                    Jenis_Kelamin = rdbPerempuan.Text
                End If

                ' UNTUK MENAMPUNG FOTO PEGAWAI DAN MENGONVERSINYA MENJADI ARRAY BYTE
                Dim ms As New MemoryStream
                ptbFoto.Image.Save(ms, ptbFoto.Image.RawFormat)
                Dim img() As Byte
                img = ms.ToArray()

                RD.Close()

                ' QUERY UNTUK MENAMBAHKAN ISI DATABASE
                Dim command_add As New MySqlCommand("INSERT INTO tbdatapegawai (NIP, Nama_Lengkap, Jenis_Kelamin, Tanggal_Lahir, Agama, No_Telpon, Alamat, Foto_Pegawai) VALUES (@NIP, @Nama_Lengkap, @Jenis_Kelamin, @Tanggal_Lahir, @Agama, @No_Telpon, @Alamat, @Foto_Pegawai)", CONN)
                ' MENGISI KOLOM DATABASE (NIP, Nama_Lengkap, Jenis_Kelamin, Tanggal_Lahir, Agama, No_Telpon, Alamat, Foto_Pegawai) SESUAI DENGAN INPUTAN USER PADA MASING-MASING KOMPONEN
                command_add.Parameters.Add("@NIP", MySqlDbType.VarChar).Value = txtNIP.Text
                command_add.Parameters.Add("@Nama_Lengkap", MySqlDbType.VarChar).Value = txtNama.Text
                command_add.Parameters.Add("@Jenis_Kelamin", MySqlDbType.VarChar).Value = Jenis_Kelamin
                command_add.Parameters.Add("@Tanggal_Lahir", MySqlDbType.Date).Value = Format(DTPTglLahir.Value, "yyyy-MM-dd")
                command_add.Parameters.Add("@Agama", MySqlDbType.VarChar).Value = cbxAgama.Text
                command_add.Parameters.Add("@No_Telpon", MySqlDbType.VarChar).Value = txtNoTelp.Text
                command_add.Parameters.Add("@Alamat", MySqlDbType.VarChar).Value = txtAlamat.Text
                command_add.Parameters.Add("@Foto_Pegawai", MySqlDbType.Blob).Value = img
                command_add.ExecuteNonQuery()
                ' JIKA DATA BERHASIL DITAMBAHKAN MAKA AKAN MUNCUL PEMBERITAHUAN
                MsgBox("Data Telah Berhasil Ditambahkan !", MsgBoxStyle.Information, "INFORMASI")
            Else
                ' JIKA NIP YANG INGIN DITAMBAHKAN SUDAH TERDAPAT PADA TABEL DATA PEGAWAI MAKA AKAN MUNCUL PEMBERITAHUAN
                MessageBox.Show("Data Diri Pegawai dengan NIP " & txtNIP.Text & " Sudah Pernah Ditambahkan, Silahkan Simpan Perubahan Jika Terjadi Kesalahan !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            RD.Close()
            Call TampilNIP()
            Call TampilDataPegawai()
            txtNama.Focus()
        End If
    End Sub

    Private Sub btnSimpanEdit_Click(sender As Object, e As EventArgs) Handles btnSimpanEdit.Click
        If CekDataKosong() = True Then
            CMD = New MySqlCommand("SELECT * FROM tbdatapegawai WHERE NIP = '" & txtNIP.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()

            If RD.HasRows = True Then
                ' UNTUK MENGAMBIL VALUE DARI RADIO BUTTON JENIS KELAMIN
                Dim Jenis_Kelamin As String
                If rdbLaki.Checked = True Then
                    Jenis_Kelamin = rdbLaki.Text
                ElseIf rdbPerempuan.Checked = True Then
                    Jenis_Kelamin = rdbPerempuan.Text
                End If

                ' UNTUK MENAMPUNG FOTO PEGAWAI DAN MENGONVERSINYA MENJADI ARRAY BYTE
                Dim ms As New MemoryStream
                ptbFoto.Image.Save(ms, ptbFoto.Image.RawFormat)
                Dim img() As Byte
                img = ms.ToArray()

                RD.Close()

                ' QUERY UNTUK MENGUBAH ISI DATABASE
                Dim command_edit As New MySqlCommand("UPDATE tbdatapegawai SET NIP = @NIP, Nama_Lengkap = @Nama_Lengkap, Jenis_Kelamin = @Jenis_Kelamin, Tanggal_Lahir = @Tanggal_Lahir, Agama = @Agama, No_Telpon = @No_Telpon, Alamat = @Alamat, Foto_Pegawai = @Foto_Pegawai WHERE NIP = @NIP", CONN)
                ' MENGISI KOLOM DATABASE (NIP, Nama_Lengkap, Jenis_Kelamin, Tanggal_Lahir, Agama, No_Telpon, Alamat, Foto_Pegawai) SESUAI DENGAN INPUTAN USER PADA MASING-MASING KOMPONEN
                command_edit.Parameters.Add("@NIP", MySqlDbType.VarChar).Value = txtNIP.Text
                command_edit.Parameters.Add("@Nama_Lengkap", MySqlDbType.VarChar).Value = txtNama.Text
                command_edit.Parameters.Add("@Jenis_Kelamin", MySqlDbType.VarChar).Value = Jenis_Kelamin
                command_edit.Parameters.Add("@Tanggal_Lahir", MySqlDbType.Date).Value = Format(DTPTglLahir.Value, "yyyy-MM-dd")
                command_edit.Parameters.Add("@Agama", MySqlDbType.VarChar).Value = cbxAgama.Text
                command_edit.Parameters.Add("@No_Telpon", MySqlDbType.VarChar).Value = txtNoTelp.Text
                command_edit.Parameters.Add("@Alamat", MySqlDbType.VarChar).Value = txtAlamat.Text
                command_edit.Parameters.Add("@Foto_Pegawai", MySqlDbType.Blob).Value = img
                command_edit.ExecuteNonQuery()
                ' JIKA Data BERHASIL DITAMBAHKAN MAKA AKAN MUNCUL PEMBERITAHUAN
                MsgBox("Data Telah Berhasil Diedit !", MsgBoxStyle.Information, "Perhatian")
            Else
                ' JIKA NIP YANG INGIN DITAMBAHKAN SUDAH TERDAPAT PADA TABEL DATA PEGAWAI MAKA AKAN MUNCUL PEMBERITAHUAN
                MessageBox.Show("Data Diri Pegawai dengan NIP " & txtNIP.Text & " Belum Pernah Ditambahkan, Silahkan Simpan Data Baru Terlebih Dahulu !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                RD.Close()
            End If
        End If
        RD.Close()
        Call TampilNIP()
        Call TampilDataPegawai()
        txtNama.Focus()
    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        If e.KeyChar = Chr(13) Then DTPTglLahir.Focus()

        'VALIDASI HURUF
        Dim keyascii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Z,a-z]" _
                OrElse keyascii = Keys.Back _
                OrElse keyascii = Keys.Space _
                OrElse keyascii = Keys.Return _
                OrElse keyascii = Keys.Delete) Then
            keyascii = 0
        Else
            e.Handled = CBool(keyascii)
        End If
    End Sub

    Private Sub DTPTglLahir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTglLahir.KeyPress
        If e.KeyChar = Chr(13) Then rdbLaki.Focus()
    End Sub

    Private Sub rdbLaki_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rdbLaki.KeyPress
        If e.KeyChar = Chr(13) Then rdbPerempuan.Focus()
    End Sub

    Private Sub rdbPerempuan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rdbPerempuan.KeyPress
        If e.KeyChar = Chr(13) Then cbxAgama.Focus()
    End Sub
    Private Sub cbxAgama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbxAgama.KeyPress
        If e.KeyChar = Chr(13) Then txtNoTelp.Focus()
    End Sub
    Private Sub txtNoTelp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoTelp.KeyPress
        If e.KeyChar = Chr(13) Then txtAlamat.Focus()

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            ErrorProvider1.SetError(txtNoTelp, "Harus Dalam Angka!")
            e.Handled = True
        Else
            e.Handled = False
            ErrorProvider1.Clear()
        End If
    End Sub
    Private Sub txtAlamat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAlamat.KeyPress
        If e.KeyChar = Chr(13) Then btnUpload.Focus()
    End Sub

    Private Sub Form_Data_Diri_Pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' VALIDASI MAX 
        txtNIP.MaxLength = 18
        txtNama.MaxLength = 100
        txtNoTelp.MaxLength = 15
        txtAlamat.MaxLength = 100
        ' UNTUK MENGISI LABEL USERNAME PEGAWAI SESUAI DENGAN INPUTAN KOMPONEN TEXTBOX USERNAME PEGAWAI SAAT LOGIN PEGAWAI
        lblUsnPegawai.Text = Login_Pegawai.txtNIPPegawai.Text
        txtNama.Focus()
        txtNIP.Enabled = False
        Call koneksi()
        Call Agama()
        Call Bersih()
        Call TampilNIP()
    End Sub
End Class
