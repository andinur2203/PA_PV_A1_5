Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Informasi_Data_Diri_Pegawai
    Sub Bersih()
        cbxNIP.Text = ""
        txtNamaPegawai.Clear()
        txtJK.Clear()
        txtTglLahir.Clear()
        txtAgama.Clear()
        txtNoTelp.Clear()
        txtAlamat.Clear()
    End Sub

    Sub TampilNIP()
        CMD = New MySqlCommand("SELECT NIP FROM tbdatapegawai WHERE NIP = '" & Form_Data_Diri_Pegawai.txtNIP.Text & "'", CONN)
        RD = CMD.ExecuteReader
        Do While RD.Read
            cbxNIP.Items.Add(RD.Item(0))
        Loop
        RD.Close()
    End Sub

    Private Sub btnFormDataDiri_Click_1(sender As Object, e As EventArgs) Handles btnFormDataDiri.Click
        ' UNTUK MENAMPILKAN FORM DATA DIRI PEGAWAI DENGAN MEMANGGIL DIRI SENDIRI
        Form_Data_Diri_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnInfoDataDiri_Click(sender As Object, e As EventArgs) Handles btnInfoDataDiri.Click
        ' UNTUK MENAMPILKAN DATA DIRI PEGAWAI
        Me.Show()
    End Sub

    Private Sub btnFormAbsen_Click(sender As Object, e As EventArgs) Handles btnFormAbsen.Click
        ' UNTUK MENAMPILKAN FORM ABSENSI PEGAWAI
        Form_Absensi_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub btnInfoGaji_Click_1(sender As Object, e As EventArgs) Handles btnInfoGaji.Click
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
            Form_Absensi_Pegawai.Close()
            Informasi_Gaji_Pegawai.Close()

            Login.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Informasi_Data_Diri_Pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUsnPegawai.Text = Form_Data_Diri_Pegawai.lblUsnPegawai.Text
        cbxNIP.Focus()
        cbxNIP.Enabled = True
        Call koneksi()
        Call TampilNIP()
    End Sub

    Private Sub cbxNIP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNIP.SelectedIndexChanged
        CMD = New MySqlCommand("SELECT * FROM tbdatapegawai WHERE NIP = '" & cbxNIP.Text & "'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()

        If RD.HasRows = True Then
            txtNamaPegawai.Text = RD.Item(1)
            txtJK.Text = RD.Item(2)
            txtTglLahir.Text = RD.Item(3)
            txtAgama.Text = RD.Item(4)
            txtNoTelp.Text = RD.Item(5)
            txtAlamat.Text = RD.Item(6)
            Dim img As Byte()
            img = RD.Item(7)
            Dim ms As New MemoryStream(img)
            ptbFoto.Image = Image.FromStream(ms)
            RD.Close()
        Else
            MessageBox.Show("Data Diri Pegawai dengan NIP " & cbxNIP.Text & " Belum Ditambahkan, Silahkan Isi Formulir Data Diri Pegawai Terlebih Dahulu !", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Call Bersih()
        End If
        RD.Close()
    End Sub
End Class