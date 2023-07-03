
namespace StudentManagement
{
    partial class ThemLop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.ngayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.ngayBatDau = new System.Windows.Forms.DateTimePicker();
            this.cbHeDaoTao = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fcbHeDaoTao = new StudentManagement.NewFolder1.FlatCombobox();
            this.btnXuatTrangThaiLop = new Guna.UI2.WinForms.Guna2Button();
            this.btnSuaLop = new Guna.UI2.WinForms.Guna2Button();
            this.btnThemLop = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vbXoaDuLieu = new StudentManagement.NewFolder1.VBButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtTenLop);
            this.groupBox1.Controls.Add(this.ngayKetThuc);
            this.groupBox1.Controls.Add(this.ngayBatDau);
            this.groupBox1.Controls.Add(this.cbHeDaoTao);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(55, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(693, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Lớp Học";
            // 
            // txtTenLop
            // 
            this.txtTenLop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTenLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenLop.Location = new System.Drawing.Point(149, 52);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(163, 24);
            this.txtTenLop.TabIndex = 4;
            this.txtTenLop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenLop_KeyPress);
            // 
            // ngayKetThuc
            // 
            this.ngayKetThuc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ngayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.ngayKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ngayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayKetThuc.Location = new System.Drawing.Point(468, 93);
            this.ngayKetThuc.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.ngayKetThuc.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.ngayKetThuc.Name = "ngayKetThuc";
            this.ngayKetThuc.Size = new System.Drawing.Size(200, 24);
            this.ngayKetThuc.TabIndex = 3;
            this.ngayKetThuc.Value = new System.DateTime(2023, 6, 12, 0, 0, 0, 0);
            // 
            // ngayBatDau
            // 
            this.ngayBatDau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ngayBatDau.CustomFormat = "dd/MM/yyyy";
            this.ngayBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ngayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayBatDau.Location = new System.Drawing.Point(468, 48);
            this.ngayBatDau.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.ngayBatDau.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.ngayBatDau.Name = "ngayBatDau";
            this.ngayBatDau.Size = new System.Drawing.Size(200, 24);
            this.ngayBatDau.TabIndex = 3;
            this.ngayBatDau.Value = new System.DateTime(2023, 6, 12, 0, 0, 0, 0);
            // 
            // cbHeDaoTao
            // 
            this.cbHeDaoTao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbHeDaoTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbHeDaoTao.FormattingEnabled = true;
            this.cbHeDaoTao.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbHeDaoTao.Items.AddRange(new object[] {
            "Arena",
            "Aptech"});
            this.cbHeDaoTao.Location = new System.Drawing.Point(149, 93);
            this.cbHeDaoTao.Name = "cbHeDaoTao";
            this.cbHeDaoTao.Size = new System.Drawing.Size(163, 26);
            this.cbHeDaoTao.TabIndex = 2;
            this.cbHeDaoTao.Text = "-Hệ Đào Tạo-";
            this.cbHeDaoTao.TextChanged += new System.EventHandler(this.cbHeDaoTao_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(337, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ngày Kết Thúc";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(337, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày Nhập Học";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(18, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hệ Đào Tạo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(18, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Lớp";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.vbXoaDuLieu);
            this.panel1.Controls.Add(this.fcbHeDaoTao);
            this.panel1.Controls.Add(this.btnXuatTrangThaiLop);
            this.panel1.Controls.Add(this.btnSuaLop);
            this.panel1.Controls.Add(this.btnThemLop);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 279);
            this.panel1.TabIndex = 1;
            // 
            // fcbHeDaoTao
            // 
            this.fcbHeDaoTao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fcbHeDaoTao.BackColor = System.Drawing.Color.Azure;
            this.fcbHeDaoTao.BorderColor = System.Drawing.Color.Teal;
            this.fcbHeDaoTao.ButtonColor = System.Drawing.Color.LightSteelBlue;
            this.fcbHeDaoTao.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.fcbHeDaoTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.fcbHeDaoTao.FormattingEnabled = true;
            this.fcbHeDaoTao.Items.AddRange(new object[] {
            "Tất Cả Lớp",
            "Arena",
            "Aptech"});
            this.fcbHeDaoTao.Location = new System.Drawing.Point(583, 18);
            this.fcbHeDaoTao.Name = "fcbHeDaoTao";
            this.fcbHeDaoTao.Size = new System.Drawing.Size(165, 26);
            this.fcbHeDaoTao.TabIndex = 8;
            this.fcbHeDaoTao.Text = "-Hệ Đào Tạo-";
            this.fcbHeDaoTao.SelectedIndexChanged += new System.EventHandler(this.fcbHeDaoTao_SelectedIndexChanged);
            this.fcbHeDaoTao.TextChanged += new System.EventHandler(this.fcbHeDaoTao_TextChanged);
            // 
            // btnXuatTrangThaiLop
            // 
            this.btnXuatTrangThaiLop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXuatTrangThaiLop.BackColor = System.Drawing.Color.Honeydew;
            this.btnXuatTrangThaiLop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnXuatTrangThaiLop.BorderColor = System.Drawing.Color.Green;
            this.btnXuatTrangThaiLop.BorderRadius = 10;
            this.btnXuatTrangThaiLop.BorderThickness = 2;
            this.btnXuatTrangThaiLop.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXuatTrangThaiLop.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXuatTrangThaiLop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXuatTrangThaiLop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXuatTrangThaiLop.FillColor = System.Drawing.Color.PaleGreen;
            this.btnXuatTrangThaiLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXuatTrangThaiLop.ForeColor = System.Drawing.Color.Green;
            this.btnXuatTrangThaiLop.Location = new System.Drawing.Point(366, 204);
            this.btnXuatTrangThaiLop.Name = "btnXuatTrangThaiLop";
            this.btnXuatTrangThaiLop.Size = new System.Drawing.Size(161, 42);
            this.btnXuatTrangThaiLop.TabIndex = 1;
            this.btnXuatTrangThaiLop.Text = "Xuất Trạng Thái";
            this.btnXuatTrangThaiLop.Click += new System.EventHandler(this.btnXuatTrangThaiLop_Click);
            // 
            // btnSuaLop
            // 
            this.btnSuaLop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSuaLop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSuaLop.BorderColor = System.Drawing.Color.Teal;
            this.btnSuaLop.BorderRadius = 10;
            this.btnSuaLop.BorderThickness = 2;
            this.btnSuaLop.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSuaLop.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSuaLop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSuaLop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSuaLop.FillColor = System.Drawing.Color.PaleTurquoise;
            this.btnSuaLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSuaLop.ForeColor = System.Drawing.Color.Teal;
            this.btnSuaLop.Location = new System.Drawing.Point(246, 204);
            this.btnSuaLop.Name = "btnSuaLop";
            this.btnSuaLop.Size = new System.Drawing.Size(114, 42);
            this.btnSuaLop.TabIndex = 1;
            this.btnSuaLop.Text = "Sửa Lớp";
            this.btnSuaLop.Click += new System.EventHandler(this.btnSuaLop_Click);
            // 
            // btnThemLop
            // 
            this.btnThemLop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThemLop.BorderRadius = 10;
            this.btnThemLop.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemLop.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemLop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemLop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemLop.FillColor = System.Drawing.Color.Teal;
            this.btnThemLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThemLop.ForeColor = System.Drawing.Color.White;
            this.btnThemLop.Location = new System.Drawing.Point(126, 204);
            this.btnThemLop.Name = "btnThemLop";
            this.btnThemLop.Size = new System.Drawing.Size(114, 42);
            this.btnThemLop.TabIndex = 1;
            this.btnThemLop.Text = "Thêm Lớp";
            this.btnThemLop.Click += new System.EventHandler(this.btnThemLop_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.guna2DataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 279);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(807, 209);
            this.panel2.TabIndex = 2;
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
            this.guna2DataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.guna2DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(0, 2, 0, 4);
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.guna2DataGridView1.ColumnHeadersHeight = 26;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.Padding = new System.Windows.Forms.Padding(0, 2, 0, 3);
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle15;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(29, 6);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.Size = new System.Drawing.Size(755, 200);
            this.guna2DataGridView1.TabIndex = 0;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 26;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 22;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.Visible = false;
            this.guna2DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellContentClick_1);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // vbXoaDuLieu
            // 
            this.vbXoaDuLieu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.vbXoaDuLieu.BackColor = System.Drawing.Color.Silver;
            this.vbXoaDuLieu.BackgroundColor = System.Drawing.Color.Silver;
            this.vbXoaDuLieu.BorderColor = System.Drawing.Color.DimGray;
            this.vbXoaDuLieu.BorderRadius = 20;
            this.vbXoaDuLieu.BorderSize = 2;
            this.vbXoaDuLieu.FlatAppearance.BorderSize = 0;
            this.vbXoaDuLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbXoaDuLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.vbXoaDuLieu.ForeColor = System.Drawing.Color.DimGray;
            this.vbXoaDuLieu.Location = new System.Drawing.Point(543, 204);
            this.vbXoaDuLieu.Name = "vbXoaDuLieu";
            this.vbXoaDuLieu.Size = new System.Drawing.Size(132, 40);
            this.vbXoaDuLieu.TabIndex = 9;
            this.vbXoaDuLieu.Text = "Xóa Dữ Liệu";
            this.vbXoaDuLieu.TextColor = System.Drawing.Color.DimGray;
            this.vbXoaDuLieu.UseVisualStyleBackColor = false;
            this.vbXoaDuLieu.Click += new System.EventHandler(this.vbXoaDuLieu_Click);
            // 
            // ThemLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 488);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ThemLop";
            this.Text = "Quản Lý Lớp";
            this.Load += new System.EventHandler(this.ThemLop_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker ngayBatDau;
        private System.Windows.Forms.ComboBox cbHeDaoTao;
        private System.Windows.Forms.DateTimePicker ngayKetThuc;
        private Guna.UI2.WinForms.Guna2Button btnThemLop;
        private Guna.UI2.WinForms.Guna2Button btnSuaLop;
        private NewFolder1.FlatCombobox fcbHeDaoTao;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.TextBox txtTenLop;
        private Guna.UI2.WinForms.Guna2Button btnXuatTrangThaiLop;
        private NewFolder1.VBButton vbXoaDuLieu;
    }
}