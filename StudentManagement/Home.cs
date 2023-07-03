using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using System.Globalization;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace StudentManagement
{
    public partial class Home : Form
    {
        private string maLop;
        public string sinhVienCanTim;
        public Home()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                cbClass.Items.Clear();
                cbClass.Items.AddRange(NewFolder1.MainFunction.AddDataComboboxClass("cbClassThem"));
                cbHDT.Items.Clear();
                cbHDT.Items.AddRange(layMaDaoTao());
                label11.Text = QuanLyTaiKhoan.LoggedInUsername;
                quanLyQuyen();
        }

        public void quanLyQuyen()
        {
            if (QuanLyTaiKhoan.Quyen==3)
            {
                vbThem.Enabled = false;
                vbSua.Enabled = false;
                vbSuaSV.Enabled = false;
                vbNghiHoc.Enabled = false;
            }
            else
            {
                vbThem.Enabled = true;
                vbSua.Enabled = true;
                vbSuaSV.Enabled = true;
                vbNghiHoc.Enabled = true;
            }
        }

        private void fcbClassList_TextChanged(object sender, EventArgs e)
        {
            fcbClassList.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cbClass_TextChanged(object sender, EventArgs e)
        {
            cbClass.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        
        public void getStudentByClass() //Chọn lớp
        {
            maLop = fcbClassList.SelectedItem.ToString();
            NewFolder1.MainFunction.OpenConnection();
            string query = "SELECT TrangThaiLop FROM Lop WHERE MaLop=@malop;";
            SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            command.Parameters.AddWithValue("@malop", maLop);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetInt32(0)==2)
                {
                    btnXetTN.Visible = true;
                    vbButton2.Visible = false;
                    vbThem.Enabled = false;
                }
                else
                {
                    btnXetTN.Visible = false;
                    vbButton2.Visible = true;
                    vbThem.Enabled = true;
                }
            }
            reader.Close();
            NewFolder1.MainFunction.CloseConnection();
            OpenExcel();
        }

        private void cbClass_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cbClass.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void fcbClassList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            fcbClassList.DropDownStyle = ComboBoxStyle.DropDownList;
            getStudentByClass();
        }

        public void ImportExcel(String excelFilePath)
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"]; // Chọn sheet thích hợp

                int rowCount = worksheet.Dimension.Rows;

                NewFolder1.MainFunction.OpenConnection();
                String maHeDaoTao = worksheet.Cells[1, 3].Text.Substring(4, 3);
                maLop = worksheet.Cells[1, 3].Value.ToString();
                SqlCommand command = new SqlCommand("INSERT INTO Lop VALUES (@value1, @value2, @value3, @value4, @value5)", NewFolder1.MainFunction.getCnn());
                command.Parameters.AddWithValue("@value1", maLop);
                command.Parameters.AddWithValue("@value2", worksheet.Cells[2, 3].Value);
                command.Parameters.AddWithValue("@value3", worksheet.Cells[3, 3].Value);
                command.Parameters.AddWithValue("@value4", maHeDaoTao);
                command.Parameters.AddWithValue("@value5", 1);
                command.ExecuteNonQuery();

                for (int row = 5; row <= rowCount; row++) // Bắt đầu từ dòng thứ 2 để bỏ qua dòng tiêu đề
                {
                    command = new SqlCommand("INSERT INTO SinhVien VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9, @value10, @value11, @value12)", NewFolder1.MainFunction.getCnn());
                    command.Parameters.AddWithValue("@value1", worksheet.Cells[row, 2].Value);
                    command.Parameters.AddWithValue("@value2", worksheet.Cells[row, 3].Value);
                    command.Parameters.AddWithValue("@value3", worksheet.Cells[row, 4].Value);
                    command.Parameters.AddWithValue("@value4", worksheet.Cells[row, 5].Value);
                    command.Parameters.AddWithValue("@value5", worksheet.Cells[row, 6].Value);
                    command.Parameters.AddWithValue("@value6", worksheet.Cells[row, 7].Value);
                    command.Parameters.AddWithValue("@value7", worksheet.Cells[row, 8].Value);
                    command.Parameters.AddWithValue("@value8", worksheet.Cells[row, 9].Value);
                    command.Parameters.AddWithValue("@value9", worksheet.Cells[row, 10].Value);
                    command.Parameters.AddWithValue("@value10", worksheet.Cells[row, 11].Value);
                    command.Parameters.AddWithValue("@value11", maLop);
                    command.Parameters.AddWithValue("@value12", 1); //Mã trạng thái ban đầu là bình thường hết
                    command.ExecuteNonQuery();

                }
                NewFolder1.MainFunction.CloseConnection();
            }
        }
        public void themSV()
        {
            NewFolder1.MainFunction.OpenConnection();
        }

        public void OpenExcel() //Đọc dữ liệu ra DatagridView
        {
            NewFolder1.MainFunction.OpenConnection();
            DataTable tb = new DataTable();
            String query1;
            query1 = "SELECT sv.MSSV, sv.IDSinhVien, sv.HoTen, FORMAT(sv.NgaySinh, 'dd/MM/yyyy') " +
                    "AS [NgaySinh], sv.GioiTinh, sv.SDT, sv.PhuHuynh, sv.SDT_PH, sv.DiaChi, sv.Email, " +
                    "tt.TenTrangThai FROM SinhVien sv JOIN TrangThai tt ON tt.MaTrangThai = sv.MaTrangThai WHERE sv.MaLop=@malop";
           
            SqlCommand command;
            command = new SqlCommand(query1, NewFolder1.MainFunction.getCnn());
            command.Parameters.AddWithValue("@malop", fcbClassList.SelectedItem);
            SqlDataReader reader = command.ExecuteReader();
            tb.Load(reader);
            dataGridView1.DataSource = tb;
            dataGridView1.Visible = true;
            reader.Close();

            int rowCount = dataGridView1.RowCount;
            int colCount = dataGridView1.ColumnCount;
            for (int i = 0; i < rowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i+1;
                if (dataGridView1.Rows[i].Cells[11].Value.ToString().Trim()=="Nghĩ Học")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
                }
            }
            dataGridView1.Columns[2].HeaderText = "ID";
            dataGridView1.Columns[3].HeaderText = "HỌ VÀ TÊN";
            dataGridView1.Columns[4].HeaderText = "NGÀY SINH";
            dataGridView1.Columns[5].HeaderText = "GIỚI TÍNH";
            dataGridView1.Columns[7].HeaderText = "PHỤ HUYNH";
            dataGridView1.Columns[8].HeaderText = "SĐT PHỤ HUYNH";
            dataGridView1.Columns[9].HeaderText = "ĐỊA CHỈ";
            dataGridView1.Columns[11].HeaderText = "TÊN TRẠNG THÁI";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            NewFolder1.MainFunction.CloseConnection();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import Excel";
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ImportExcel(openFileDialog.FileName);
                    MessageBox.Show("Nhập File Thành Công");
                    this.Form1_Load(sender, e);
                    fcbClassList.SelectedItem = maLop;
                    OpenExcel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nhập File Không Thành Công");
                }
            }
        }

        public void AddNewStudent()
        {
            // heDaoTao + nam + số
            string nam = "";
            string mssvMax = "";
            string heDaoTao = "";
            string idSV = "";
            NewFolder1.MainFunction.OpenConnection();

            //lấy năm, hedaotao
            string query1 = "SELECT RIGHT(DATEPART(YEAR, NgayBatDau), 2) AS nam, MaHeDaoTao FROM Lop WHERE MaLop=@malop;";
            SqlCommand command1 = new SqlCommand(query1, NewFolder1.MainFunction.getCnn());
            command1.Parameters.AddWithValue("@malop", cbClass.SelectedItem);
            SqlDataReader reader1 = command1.ExecuteReader();

            if (reader1.Read())
            {
                nam = reader1.GetString(0);
                if (reader1.GetString(1) == "96G")
                {
                    heDaoTao = "A";
                }
                else
                {
                    heDaoTao = "B";
                }
            }
            reader1.Close();

            //lấy 3 số cuối mssv của sinh viên có mssv lớn nhất
            string query2 = "SELECT RIGHT(MAX(MSSV), 3) AS MaxMSSV FROM SinhVien WHERE MSSV LIKE'" + heDaoTao + nam + "%';";
            SqlCommand command2 = new SqlCommand(query2, NewFolder1.MainFunction.getCnn());
            SqlDataReader reader2 = command2.ExecuteReader();

            if (reader2.Read())
            {
                if (reader2.IsDBNull(0))
                {
                    mssvMax = "000";
                }
                else
                {
                    mssvMax = reader2.GetString(0);
                }
            }
            reader2.Close();
            int number = (int.Parse(mssvMax) + 1); //stt của mssv
            string mssvMoi = heDaoTao + nam + number.ToString("D3");

            //lấy 6 số cuối của ID Sinh Viên lớn nhất
            string query3 = "SELECT RIGHT(MAX(IDSinhVien), 6) AS MaxID FROM SinhVien;";
            SqlCommand command3 = new SqlCommand(query3, NewFolder1.MainFunction.getCnn());
            SqlDataReader reader3 = command3.ExecuteReader();

            if (reader3.Read())
            {
                idSV = "Student"+(int.Parse(reader3.GetString(0)) + 1).ToString("D2");
            }
            reader3.Close();
            int Index;
            if (txthoten.Text.Contains(" "))
            {
                Index = txthoten.Text.Trim().LastIndexOf(' ');
            }
            else
            {
                Index = 1;
            }
            string Ten = txthoten.Text.Trim().Substring(Index);
            string normalizedString = Ten.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder(3000);

            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            string result = stringBuilder.ToString().ToLower();
            AddStudentInSQL(idSV, mssvMoi, result);
            NewFolder1.MainFunction.CloseConnection();
        }

        public void AddStudentInSQL(string id, string mssv, string ten)
        {
            NewFolder1.MainFunction.OpenConnection();
            string query = "INSERT INTO SinhVien VALUES(@mssv, @id, @hoten, @ngaysinh, @gioitinh, @sdt, @phuhuynh, @sdtph, @diachi, @email, @malop, 1)";
            SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            command.Parameters.AddWithValue("@mssv", mssv);
            command.Parameters.AddWithValue("@id", id); 
            command.Parameters.AddWithValue("@hoten", txthoten.Text.Trim());
            command.Parameters.AddWithValue("@ngaysinh", datengaysinh.Value.Date.ToString("MM/dd/yyyy"));
            command.Parameters.AddWithValue("@gioitinh", cbgioitinh.SelectedItem);
            command.Parameters.AddWithValue("@sdt", txtsdt.Text);
            command.Parameters.AddWithValue("@phuhuynh", txtphuhuynh.Text);
            command.Parameters.AddWithValue("@sdtph", txtsdtph.Text);
            command.Parameters.AddWithValue("@diachi", txtdiachi.Text);
            command.Parameters.AddWithValue("@email", ten + mssv.ToLower() + "@cusc.ctu.edu.vn");
            command.Parameters.AddWithValue("@malop", cbClass.SelectedItem);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                DialogResult re = MessageBox.Show("Thêm Sinh Viên Thành Công!",
                                                    "Thêm Sinh Viên");
                string lop = cbClass.SelectedItem.ToString();
                resetDuLieu();
                cbClass.SelectedItem = lop;
            }
            NewFolder1.MainFunction.CloseConnection();
        }

        private void vbThem_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txthoten.Text) 
                && !string.IsNullOrWhiteSpace(txtdiachi.Text) 
                && !string.IsNullOrWhiteSpace(txtphuhuynh.Text)
                && !string.IsNullOrWhiteSpace(txtsdt.Text)
                && !string.IsNullOrWhiteSpace(txtsdtph.Text)
                && !string.IsNullOrWhiteSpace(cbClass.SelectedItem?.ToString())
                && !string.IsNullOrWhiteSpace(cbgioitinh.SelectedItem?.ToString()))
            {
                NewFolder1.MainFunction.OpenConnection();
                String query2 = "SELECT * FROM SinhVien WHERE SDT=@sdt AND MaLop=@malop";
                SqlCommand command2 = new SqlCommand(query2, NewFolder1.MainFunction.getCnn());
                command2.Parameters.AddWithValue("@sdt", txtsdt.Text);
                command2.Parameters.AddWithValue("@malop", cbClass.SelectedItem);
                String check = (string)command2.ExecuteScalar();

                if (!string.IsNullOrEmpty(check))
                {
                    MessageBox.Show("Số Điện Thoại Sinh Viên Không Được Trùng", "Thông Báo");
                }
                else
                {
                    AddNewStudent();
                    Console.WriteLine(fcbClassList.SelectedItem?.ToString());
                    Console.WriteLine(cbClass.SelectedItem?.ToString());
                    Console.WriteLine(!string.IsNullOrWhiteSpace(fcbClassList.SelectedItem?.ToString().Trim()) && fcbClassList.SelectedItem?.ToString() == cbClass.SelectedItem?.ToString());

                    if (!string.IsNullOrWhiteSpace(fcbClassList.SelectedItem?.ToString().Trim()) && fcbClassList.SelectedItem?.ToString() == cbClass.SelectedItem?.ToString())
                    {
                        OpenExcel();
                    }
                }
                NewFolder1.MainFunction.CloseConnection();
            }
            else
            {
                MessageBox.Show("Mời Nhập Đủ Thông Tin!",
                                  "Thông Báo");

            }
        }

        private void vbSuaSV_Click(object sender, EventArgs e)
        {
                if (!string.IsNullOrWhiteSpace(txthoten.Text)
                && !string.IsNullOrWhiteSpace(txtdiachi.Text)
                && !string.IsNullOrWhiteSpace(txtphuhuynh.Text)
                && !string.IsNullOrWhiteSpace(txtsdt.Text)
                && !string.IsNullOrWhiteSpace(txtsdtph.Text)
                && !string.IsNullOrWhiteSpace(cbClass.SelectedItem?.ToString())
                && !string.IsNullOrWhiteSpace(cbgioitinh.SelectedItem?.ToString()))
                {
                    NewFolder1.MainFunction.OpenConnection();
                    string query = "UPDATE SinhVien SET HoTen=@hoten, NgaySinh=@ngaysinh, GioiTinh=@gioitinh, SDT=@sdt, PhuHuynh=@phuhuynh, SDT_PH=@sdtph, DiaChi=@diachi, MaLop=@malop WHERE MSSV=@mssv";
                    SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
                    command.Parameters.AddWithValue("@mssv", txtmssv.Text);
                    command.Parameters.AddWithValue("@hoten", txthoten.Text.Trim());
                    command.Parameters.AddWithValue("@ngaysinh", datengaysinh.Value.Date.ToString("MM/dd/yyyy"));
                    command.Parameters.AddWithValue("@gioitinh", cbgioitinh.SelectedItem);
                    command.Parameters.AddWithValue("@sdt", txtsdt.Text);
                    command.Parameters.AddWithValue("@phuhuynh", txtphuhuynh.Text);
                    command.Parameters.AddWithValue("@sdtph", txtsdtph.Text);
                    command.Parameters.AddWithValue("@diachi", txtdiachi.Text);
                    command.Parameters.AddWithValue("@malop", cbClass.SelectedItem);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        DialogResult re = MessageBox.Show("Cập Nhật Sinh Viên Thành Công!",
                                                            "Cập Nhật Sinh Viên");
                        string lop = cbClass.SelectedItem.ToString();
                        resetDuLieu();
                        cbClass.SelectedItem = lop;
                    }
                    NewFolder1.MainFunction.CloseConnection();
                    if (fcbClassList.SelectedItem?.ToString() == null)
                    {
                        timKiemSinhVien(sinhVienCanTim);
                    }
                    else
                    {
                        OpenExcel();
                    }
            }
            else
                {
                    MessageBox.Show("Mời Nhập Đủ Thông Tin!",
                                      "Thông Báo");
                }
        }

        private void picTimKiem_Click(object sender, EventArgs e)
        {
             if (!string.IsNullOrWhiteSpace(txttkmssv.Text))
            {
                sinhVienCanTim = txttkmssv.Text;
                timKiemSinhVien(sinhVienCanTim);
            }
            else
            {
                MessageBox.Show("Mời nhập nội dung tìm kiếm", "Thông báo");
            }
        }

        public void timKiemSinhVien(string TenCanTim)
        {
            NewFolder1.MainFunction.OpenConnection();
            string query = "SELECT sv.MSSV, sv.IDSinhVien, sv.HoTen, FORMAT(sv.NgaySinh, 'dd/MM/yyyy') AS [NgaySinh], sv.GioiTinh, sv.SDT, sv.PhuHuynh, sv.SDT_PH, sv.DiaChi, sv.Email, t3.TenTrangThai, sv.MaLop FROM SinhVien sv JOIN TrangThai t3 ON sv.MaTrangThai=t3.MaTrangThai WHERE sv.MSSV=@mssv;";
            SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            command.Parameters.AddWithValue("@mssv", TenCanTim);
            SqlDataReader reader = command.ExecuteReader();
            DataTable tb = new DataTable();
            if (reader.HasRows)
            {
                tb.Load(reader);
                dataGridView1.DataSource = tb;
                dataGridView1.Visible = true;
                dataGridView1.Rows[0].Cells[0].Value = 1;
                DataGridViewRow sinhvien = dataGridView1.Rows[0];
                dataGridView1.Columns[2].HeaderText = "ID";
                dataGridView1.Columns[3].HeaderText = "HỌ VÀ TÊN";
                dataGridView1.Columns[4].HeaderText = "NGÀY SINH";
                dataGridView1.Columns[5].HeaderText = "GIỚI TÍNH";
                dataGridView1.Columns[7].HeaderText = "PHỤ HUYNH";
                dataGridView1.Columns[8].HeaderText = "SĐT PHỤ HUYNH";
                dataGridView1.Columns[9].HeaderText = "ĐỊA CHỈ";
                dataGridView1.Columns[11].HeaderText = "TÊN TRẠNG THÁI";
                getStudent(sinhvien);
                maLop = dataGridView1.Rows[0].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                layLopTuongDong();
                cbClass.SelectedItem = dataGridView1.Rows[0].Cells[dataGridView1.ColumnCount - 1].Value;
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                NewFolder1.MainFunction.CloseConnection();
            }
            else
            {
                dataGridView1.Visible = false;
                MessageBox.Show("Không Tìm thấy sinh viên", "Thông báo");
            }

            reader.Close();
        }

        public void getStudent(DataGridViewRow sinhvien)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                txthoten.Text = sinhvien.Cells[3].Value.ToString();
                datengaysinh.Value = DateTime.ParseExact(sinhvien.Cells[4].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtmssv.Text = sinhvien.Cells[1].Value.ToString();
                cbgioitinh.SelectedItem = sinhvien.Cells[5].Value.ToString().Trim();
                Console.WriteLine(cbgioitinh.SelectedItem.ToString());
                txtsdt.Text = sinhvien.Cells[6].Value.ToString();
                txtemail.Text = sinhvien.Cells[10].Value.ToString();
                txtphuhuynh.Text = sinhvien.Cells[7].Value.ToString();
                txtsdtph.Text = sinhvien.Cells[8].Value.ToString();
                txtdiachi.Text = sinhvien.Cells[9].Value.ToString();
                layLopTuongDong();
                cbClass.SelectedItem = maLop;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //lay thong tin sinh vien
            DataGridViewRow sinhvien = dataGridView1.SelectedRows[0];
            getStudent(sinhvien);
        }

        public void CapNhatDuLieuTrangThai() //cập nhật datagirdview sau khi điểm danh
        {
            NewFolder1.MainFunction.OpenConnection();
            string query = "SELECT tt.TenTrangThai FROM SinhVien sv JOIN TrangThai tt ON sv.MaTrangThai=tt.MaTrangThai WHERE MaLop = @malop";
            SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            command.Parameters.AddWithValue("@malop", fcbClassList.SelectedItem);
            int i = 0;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows[i].Cells[11].Value = reader.GetString(0);
                i++;
            }
            reader.Close();
            dataGridView1.Refresh();
            NewFolder1.MainFunction.CloseConnection();
        }
        private void Form_FormClose(object sender, FormClosedEventArgs e)
        {
            CapNhatDuLieuTrangThai();
        }

        private void vbButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string idSinhVien = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                DiemDanh diemDanh = new DiemDanh(idSinhVien);
                diemDanh.TopLevel = true;
                //diemDanh.FormClosed += Form_FormClose;
                diemDanh.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mời nhập sinh viên muốn điểm danh");
            }
        }

        private void txttkmssv_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra xem phím nhấn có phải là Enter không
            if (e.KeyCode == Keys.Enter)
            {
                picTimKiem_Click(sender, e);

                // Ngăn chặn xử lý tiếp theo của phím Enter trong TextBox
                e.SuppressKeyPress = true;
            }
        }

        public void ExportExcel(string lop)
        {
            try
            {
                //Tạo excel
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;

                Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add();
                Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;

                //Lấy ngày bắt đầu, ngày kết thúc
                int colCount = dataGridView1.ColumnCount;
                int rowCount = dataGridView1.RowCount;
                NewFolder1.MainFunction.OpenConnection();
                string query = "SELECT MaLop, NgayBatDau, NgayKetThuc From Lop WHERE MaLop = @malop;";
                SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
                command.Parameters.AddWithValue("@malop", lop);
                SqlDataReader reader = command.ExecuteReader();

                //gáng thông tin cho excel
                if (reader.Read())
                {
                    worksheet.Cells[1, 2] = "Mã Lớp";
                    worksheet.Cells[1, 3] = reader.GetString(0);
                    worksheet.Cells[2, 2] = "Ngày Bắt Đầu";
                    worksheet.Cells[2, 3] = reader.GetDateTime(1).ToString("dd/MM/yyyy");
                    worksheet.Cells[3, 2] = "Ngày Kết Thúc";
                    worksheet.Cells[3, 3] = reader.GetDateTime(2).ToString("dd/MM/yyyy");
                }
                reader.Close();
                NewFolder1.MainFunction.CloseConnection();

                //Tiêu đề bảng
                for (int i = 0; i < colCount; i++)
                {
                    worksheet.Cells[4, i + 1] = dataGridView1.Columns[i].HeaderText;
                    worksheet.Rows[4].Font.Bold = true;
                    worksheet.Rows[4].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                }
                //Dữ liệu bảng
                for (int i = 0; i < rowCount - 1; i++) //dong
                {
                    for (int j = 0; j < colCount; j++) //cot
                    {
                        if (j==6 || j==8)
                        {
                            worksheet.Cells[i + 5, j + 1] = "'"+dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            worksheet.Cells[i + 5, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                // Tự động điều chỉnh độ rộng cột để hiển thị tốt hơn
                worksheet.Columns.AutoFit();
                worksheet.UsedRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                worksheet.UsedRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                // Giải phóng đối tượng Excel
                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xuất ra Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        //btnExport
        private void vbButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible)
            {
                ExportExcel(fcbClassList.SelectedItem.ToString().Trim());
            }
            else
            {
                MessageBox.Show("Mời nhập lớp cần xuất");
            }
        }

        public string[] layMaDaoTao()
        {
            NewFolder1.MainFunction.OpenConnection();
            List<string> dataList = new List<string>();
            String query = "SELECT TenHeDaoTao FROM HeDaoTao";
            SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            SqlDataReader reader = command.ExecuteReader();
            dataList.Add("Tất Cả");
            while (reader.Read())
            {
                dataList.Add(reader.GetString(0));
            }
            reader.Close();
            NewFolder1.MainFunction.CloseConnection();
            return dataList.ToArray();
        }

        private void flatCombobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbHDT.DropDownStyle = ComboBoxStyle.DropDownList;
            
            switch (cbHDT.SelectedItem.ToString())
            {
                case "Aptech":
                    fcbClassList.Items.Clear();
                    fcbClassList.Items.AddRange(NewFolder1.MainFunction.AddDataComboboxClass("96G"));
                    break;
                case "Arena":
                    fcbClassList.Items.Clear();
                    fcbClassList.Items.AddRange(NewFolder1.MainFunction.AddDataComboboxClass("Y0G"));
                    break;
                default:
                    fcbClassList.Items.Clear();
                    fcbClassList.Items.AddRange(NewFolder1.MainFunction.AddDataComboboxClass("Tất Cả"));
                    break;
            }

        }

        private void vbSua_Click(object sender, EventArgs e)
        {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    DialogResult result = MessageBox.Show("Bạn Có Muốn Xóa Sinh Viên", "Thông Báo", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string mssv = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        NewFolder1.MainFunction.OpenConnection();
                        string query = "DELETE FROM Vang WHERE IDSinhVien = @id " +
                                        "DELETE FROM SinhVien WHERE IDSinhVien = @id";
                        SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
                        command.Parameters.AddWithValue("@id", dataGridView1.SelectedRows[0].Cells[2].Value);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công sinh viên có MSSV "+mssv);
                        OpenExcel();
                    }
                }
                else
                {
                    MessageBox.Show("Chọn Một Sinh Viên Để Xóa");
                }
        }

        private void XetTotNghiep_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void btnXetTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string maLop = fcbClassList.SelectedItem.ToString();
                XetTotNghiep xetTotNghiep = new XetTotNghiep(maLop);
                xetTotNghiep.TopLevel = true;
                xetTotNghiep.ShowDialog();
                xetTotNghiep.FormClosed += XetTotNghiep_FormClosed;
            }
            else
            {
                MessageBox.Show("Mời nhập sinh viên muốn điểm danh");
            }
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if ( !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' || textBox.Text.Length >= 10 && e.KeyChar != '\b')
            {
                e.Handled = true; // Loại bỏ ký tự không phải số
            }
        }

        private void txtsdt_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Kiểm tra và giới hạn số lượng ký tự
            if (textBox.Text.Length > 10)
            {
                textBox.Text = textBox.Text.Substring(0, 10);
            }
            // Loại bỏ các ký tự không phải số
            string numericText = new string(textBox.Text.Where(char.IsDigit).ToArray());
            textBox.Text = numericText;
        }

        public void layLopTuongDong()
        {
            NewFolder1.MainFunction.OpenConnection();
            //CP2396G%
            string query = "SELECT MaLop FROM Lop WHERE MaLop LIKE @ma";
            SqlCommand command1 = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            command1.Parameters.AddWithValue("@ma", maLop?.Substring(0,7)+"%");
            Console.WriteLine(maLop?.Substring(0, 7) + "%");
            SqlDataReader reader = command1.ExecuteReader();
            cbClass.Items.Clear();
            while (reader.Read())
            {
                cbClass.Items.Add(reader.GetString(0));
            }
            reader.Close();
            NewFolder1.MainFunction.CloseConnection();
        }

        public void resetDuLieu()
        {
            txtmssv.Text = "";
            txtdiachi.Text = "";
            txtemail.Text = "";
            txthoten.Text = "";
            txtphuhuynh.Text = "";
            txtsdt.Text = "";
            txtsdtph.Text = "";
            cbgioitinh.SelectedIndex = 0;
            cbClass.Items.Clear();
            cbClass.Items.AddRange(NewFolder1.MainFunction.AddDataComboboxClass("cbClassThem"));
        }

        private void vbXoaDuLieu_Click(object sender, EventArgs e)
        {
            resetDuLieu();
        }

        private void vbNghiHoc_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string mssv = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có muốn cho sinh viên "+mssv+" nghĩ học", "Thông Báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    NewFolder1.MainFunction.OpenConnection();
                    string query = "UPDATE SinhVien SET MaTrangThai=4 WHERE MSSV=@mssv";
                    SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
                    command.Parameters.AddWithValue("@mssv", mssv);
                    int rowAffect = command.ExecuteNonQuery();
                    if (rowAffect == 1)
                    {
                        MessageBox.Show("Sinh viên "+mssv+ " đã bị thôi học!");
                        OpenExcel();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại ");
                    }

                }
            }
            else
            {
                MessageBox.Show("Chọn Một Sinh Viên Để Xóa");
            }
        }

    }
}
