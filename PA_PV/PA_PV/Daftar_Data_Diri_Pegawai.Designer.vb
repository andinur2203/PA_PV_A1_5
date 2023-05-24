<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Daftar_Data_Diri_Pegawai
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Daftar_Data_Diri_Pegawai))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvDaftarPegawai = New System.Windows.Forms.DataGridView()
        Me.txtCari = New System.Windows.Forms.TextBox()
        Me.btnCari = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblJudul = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.btnLogOut = New System.Windows.Forms.Button()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.lblUsnManager = New System.Windows.Forms.Label()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnDaftarGaji = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnFormGaji = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnDaftarAbsensi = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnDaftarDataDiri = New System.Windows.Forms.Button()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvDaftarPegawai, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel4.Controls.Add(Me.btnHapus)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.dgvDaftarPegawai)
        Me.Panel4.Controls.Add(Me.txtCari)
        Me.Panel4.Controls.Add(Me.btnCari)
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Location = New System.Drawing.Point(807, 424)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1982, 1099)
        Me.Panel4.TabIndex = 7
        '
        'btnHapus
        '
        Me.btnHapus.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHapus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHapus.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnHapus.Location = New System.Drawing.Point(1370, 985)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(200, 70)
        Me.btnHapus.TabIndex = 176
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(524, 921)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(523, 32)
        Me.Label7.TabIndex = 175
        Me.Label7.Text = "* Masukkan Nama Pegawai yang Dicari"
        '
        'dgvDaftarPegawai
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDaftarPegawai.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDaftarPegawai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDaftarPegawai.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDaftarPegawai.Location = New System.Drawing.Point(68, 59)
        Me.dgvDaftarPegawai.Name = "dgvDaftarPegawai"
        Me.dgvDaftarPegawai.RowHeadersVisible = False
        Me.dgvDaftarPegawai.RowHeadersWidth = 82
        Me.dgvDaftarPegawai.RowTemplate.Height = 33
        Me.dgvDaftarPegawai.Size = New System.Drawing.Size(1847, 833)
        Me.dgvDaftarPegawai.TabIndex = 82
        '
        'txtCari
        '
        Me.txtCari.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCari.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCari.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCari.Location = New System.Drawing.Point(552, 995)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(497, 43)
        Me.txtCari.TabIndex = 173
        '
        'btnCari
        '
        Me.btnCari.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.btnCari.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCari.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCari.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnCari.Location = New System.Drawing.Point(1143, 984)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(200, 70)
        Me.btnCari.TabIndex = 172
        Me.btnCari.Text = "Cari"
        Me.btnCari.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(530, 974)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(536, 81)
        Me.PictureBox1.TabIndex = 174
        Me.PictureBox1.TabStop = False
        '
        'lblJudul
        '
        Me.lblJudul.AutoSize = True
        Me.lblJudul.BackColor = System.Drawing.Color.Transparent
        Me.lblJudul.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudul.ForeColor = System.Drawing.Color.White
        Me.lblJudul.Location = New System.Drawing.Point(789, 28)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New System.Drawing.Size(542, 50)
        Me.lblJudul.TabIndex = 29
        Me.lblJudul.Text = "Daftar Data Diri Pegawai"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnRefresh)
        Me.Panel3.Controls.Add(Me.lblJudul)
        Me.Panel3.Location = New System.Drawing.Point(807, 314)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1982, 111)
        Me.Panel3.TabIndex = 6
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.btnRefresh.BackgroundImage = CType(resources.GetObject("btnRefresh.BackgroundImage"), System.Drawing.Image)
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Location = New System.Drawing.Point(22, 20)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(77, 76)
        Me.btnRefresh.TabIndex = 31
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PictureBox10)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(699, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(2185, 234)
        Me.Panel2.TabIndex = 15
        '
        'PictureBox10
        '
        Me.PictureBox10.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox10.BackgroundImage = CType(resources.GetObject("PictureBox10.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox10.Location = New System.Drawing.Point(455, 12)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(199, 198)
        Me.PictureBox10.TabIndex = 35
        Me.PictureBox10.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(740, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(860, 50)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Jl. Hamengku Buwono IX Blok A No. 124"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label13.Location = New System.Drawing.Point(816, 51)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(718, 50)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "PT. KOMPAS SEJAHTERA ABADI"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Panel9)
        Me.Panel1.Controls.Add(Me.btnLogOut)
        Me.Panel1.Controls.Add(Me.lblWelcome)
        Me.Panel1.Controls.Add(Me.lblUsnManager)
        Me.Panel1.Controls.Add(Me.lblRole)
        Me.Panel1.Controls.Add(Me.PictureBox9)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.btnDaftarGaji)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.btnFormGaji)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.btnDaftarAbsensi)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.btnDaftarDataDiri)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(699, 1629)
        Me.Panel1.TabIndex = 14
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel9.Location = New System.Drawing.Point(2, 1398)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(40, 150)
        Me.Panel9.TabIndex = 34
        '
        'btnLogOut
        '
        Me.btnLogOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogOut.FlatAppearance.BorderSize = 0
        Me.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogOut.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogOut.Image = CType(resources.GetObject("btnLogOut.Image"), System.Drawing.Image)
        Me.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogOut.Location = New System.Drawing.Point(58, 1398)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(638, 150)
        Me.btnLogOut.TabIndex = 33
        Me.btnLogOut.Text = "Log Out"
        Me.btnLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLogOut.UseVisualStyleBackColor = False
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.BackColor = System.Drawing.Color.Transparent
        Me.lblWelcome.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.ForeColor = System.Drawing.Color.White
        Me.lblWelcome.Location = New System.Drawing.Point(192, 32)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(316, 43)
        Me.lblWelcome.TabIndex = 32
        Me.lblWelcome.Text = "Selamat Datang!"
        '
        'lblUsnManager
        '
        Me.lblUsnManager.AutoSize = True
        Me.lblUsnManager.BackColor = System.Drawing.Color.Transparent
        Me.lblUsnManager.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsnManager.ForeColor = System.Drawing.Color.White
        Me.lblUsnManager.Location = New System.Drawing.Point(302, 423)
        Me.lblUsnManager.Name = "lblUsnManager"
        Me.lblUsnManager.Size = New System.Drawing.Size(85, 43)
        Me.lblUsnManager.TabIndex = 31
        Me.lblUsnManager.Text = "123"
        '
        'lblRole
        '
        Me.lblRole.AutoSize = True
        Me.lblRole.BackColor = System.Drawing.Color.Transparent
        Me.lblRole.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRole.ForeColor = System.Drawing.Color.White
        Me.lblRole.Location = New System.Drawing.Point(256, 490)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(177, 43)
        Me.lblRole.TabIndex = 30
        Me.lblRole.Text = "Manager"
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.PictureBox9.BackgroundImage = CType(resources.GetObject("PictureBox9.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox9.Location = New System.Drawing.Point(180, 101)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(328, 300)
        Me.PictureBox9.TabIndex = 14
        Me.PictureBox9.TabStop = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel8.Location = New System.Drawing.Point(1, 1189)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(40, 150)
        Me.Panel8.TabIndex = 11
        '
        'btnDaftarGaji
        '
        Me.btnDaftarGaji.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDaftarGaji.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDaftarGaji.FlatAppearance.BorderSize = 0
        Me.btnDaftarGaji.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDaftarGaji.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDaftarGaji.Image = CType(resources.GetObject("btnDaftarGaji.Image"), System.Drawing.Image)
        Me.btnDaftarGaji.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDaftarGaji.Location = New System.Drawing.Point(58, 1189)
        Me.btnDaftarGaji.Name = "btnDaftarGaji"
        Me.btnDaftarGaji.Size = New System.Drawing.Size(638, 150)
        Me.btnDaftarGaji.TabIndex = 10
        Me.btnDaftarGaji.Text = "Daftar Gaji Pegawai"
        Me.btnDaftarGaji.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDaftarGaji.UseVisualStyleBackColor = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel7.Location = New System.Drawing.Point(5, 967)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(40, 150)
        Me.Panel7.TabIndex = 9
        '
        'btnFormGaji
        '
        Me.btnFormGaji.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnFormGaji.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFormGaji.FlatAppearance.BorderSize = 0
        Me.btnFormGaji.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFormGaji.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFormGaji.Image = CType(resources.GetObject("btnFormGaji.Image"), System.Drawing.Image)
        Me.btnFormGaji.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFormGaji.Location = New System.Drawing.Point(58, 967)
        Me.btnFormGaji.Name = "btnFormGaji"
        Me.btnFormGaji.Size = New System.Drawing.Size(638, 150)
        Me.btnFormGaji.TabIndex = 8
        Me.btnFormGaji.Text = "Formulir Penggajian Pegawai"
        Me.btnFormGaji.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFormGaji.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel6.Location = New System.Drawing.Point(3, 767)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(40, 150)
        Me.Panel6.TabIndex = 7
        '
        'btnDaftarAbsensi
        '
        Me.btnDaftarAbsensi.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDaftarAbsensi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDaftarAbsensi.FlatAppearance.BorderSize = 0
        Me.btnDaftarAbsensi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDaftarAbsensi.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDaftarAbsensi.Image = CType(resources.GetObject("btnDaftarAbsensi.Image"), System.Drawing.Image)
        Me.btnDaftarAbsensi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDaftarAbsensi.Location = New System.Drawing.Point(58, 767)
        Me.btnDaftarAbsensi.Name = "btnDaftarAbsensi"
        Me.btnDaftarAbsensi.Size = New System.Drawing.Size(638, 150)
        Me.btnDaftarAbsensi.TabIndex = 6
        Me.btnDaftarAbsensi.Text = "Daftar Absensi Pegawai"
        Me.btnDaftarAbsensi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDaftarAbsensi.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel5.Location = New System.Drawing.Point(0, 568)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(40, 150)
        Me.Panel5.TabIndex = 5
        '
        'btnDaftarDataDiri
        '
        Me.btnDaftarDataDiri.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDaftarDataDiri.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDaftarDataDiri.FlatAppearance.BorderSize = 0
        Me.btnDaftarDataDiri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDaftarDataDiri.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDaftarDataDiri.Image = CType(resources.GetObject("btnDaftarDataDiri.Image"), System.Drawing.Image)
        Me.btnDaftarDataDiri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDaftarDataDiri.Location = New System.Drawing.Point(58, 568)
        Me.btnDaftarDataDiri.Name = "btnDaftarDataDiri"
        Me.btnDaftarDataDiri.Size = New System.Drawing.Size(638, 150)
        Me.btnDaftarDataDiri.TabIndex = 0
        Me.btnDaftarDataDiri.Text = "Daftar Data Diri Pegawai"
        Me.btnDaftarDataDiri.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDaftarDataDiri.UseVisualStyleBackColor = False
        '
        'Daftar_Data_Diri_Pegawai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(192.0!, 192.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(2884, 1629)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Daftar_Data_Diri_Pegawai"
        Me.Text = "Daftar Data Diri Pegawai"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dgvDaftarPegawai, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Panel4 As Panel
    Friend WithEvents dgvDaftarPegawai As DataGridView
    Friend WithEvents lblJudul As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents btnLogOut As Button
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblUsnManager As Label
    Friend WithEvents lblRole As Label
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents btnDaftarGaji As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents btnFormGaji As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnDaftarAbsensi As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnDaftarDataDiri As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCari As TextBox
    Friend WithEvents btnCari As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnRefresh As Button
End Class
