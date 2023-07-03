using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class ThemLop : Form
    {
        private int currentYear = 0;
        private string tenLop = "";
        public ThemLop()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void ThemLop_Load(object sender, EventArgs e)
        {
            quanLyQuyen();
        }

        public void quanLyQuyen()
        {
            if (QuanLyTaiKhoan.Quyen == 3)
            {
                btnThemLop.Enabled = false;
                btnSuaLop.Enabled = false;
            }
            else
            {
                btnThemLop.Enabled = true;
                btnSuaLop.Enabled = true;
            }
        }

        public void HienThiBang()
        {
            NewFolder1.MainFunction.OpenConnection();
            DataTable tb = new DataTable();
            String query = "SELECT l.MaLop, h.TenHeDaoTao, FORMAT(l.NgayBatDau, 'dd/MM/yyyy') AS [NgayBD], FORMAT(l.NgayKetThuc, 'dd/MM/yyyy') AS [NgayKT], " +
                            "CASE l.TrangThaiLop WHEN 1 THEN N'Chưa kết thúc' ELSE N'Đã kết thúc' END AS TrangThaiLop " +
                            "FROM  Lop l JOIN HeDaoTao h ON l.MaHeDaoTao = h.MaHeDaoTao;";
            String queryArena = "SELECT l.MaLop, h.TenHeDaoTao, FORMAT(l.NgayBatDau, 'dd/MM/yyyy') AS [NgayBD], FORMAT(l.NgayKetThuc, 'dd/MM/yyyy') AS [NgayKT], " +
                                "CASE l.TrangThaiLop WHEN 1 THEN N'Chưa kết thúc' ELSE N'Đã kết thúc' END AS TrangThaiLop " +
                                "FROM  Lop l JOIN HeDaoTao h ON l.MaHeDaoTao = h.MaHeDaoTao WHERE h.TenHeDaoTao='Arena';";
            String queryAptech = "SELECT l.MaLop, h.TenHeDaoTao, FORMAT(l.NgayBatDau, 'dd/MM/yyyy') AS [NgayBD], FORMAT(l.NgayKetThuc, 'dd/MM/yyyy') AS [NgayKT], " +
                                "CASE l.TrangThaiLop WHEN 1 THEN N'Chưa kết thúc' ELSE N'Đã kết thúc' END AS TrangThaiLop " +
                                "FROM  Lop l JOIN HeDaoTao h ON l.MaHeDaoTao = h.MaHeDaoTao WHERE h.TenHeDaoTao='Aptech';";
            SqlCommand command;
            switch (fcbHeDaoTao.SelectedItem)
            {
                case "Arena":
                    command = new SqlCommand(queryArena, NewFolder1.MainFunction.getCnn());
                    break;
                case "Aptech":
                    command = new SqlCommand(queryAptech, NewFolder1.MainFunction.getCnn());
                    break;
                default:
                    command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
                    break;
            }
            SqlDataReader reader = command.ExecuteReader();
            tb.Load(reader);
            guna2DataGridView1.DataSource = tb;
            guna2DataGridView1.Visible = true;

            int rowCount = guna2DataGridView1.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                guna2DataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
            guna2DataGridView1.Columns[1].HeaderText = "MÃ LỚP";
            guna2DataGridView1.Columns[2].HeaderText = "TÊN HỆ ĐÀO TẠO";
            guna2DataGridView1.Columns[3].HeaderText = "NGÀY BẮT ĐẦU";
            guna2DataGridView1.Columns[4].HeaderText = "NGÀY KẾT THÚC";
            guna2DataGridView1.Columns[5].HeaderText = "TRẠNG THÁI LỚP";
            reader.Close();
            NewFolder1.MainFunction.CloseConnection();
            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void fcbHeDaoTao_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiBang();
        }

        public void AddClass()
        {
            string nam = ngayBatDau.Value.ToString("yy");
            string hdt="";
            switch (cbHeDaoTao.SelectedItem)
            {
                case "Arena":
                    hdt = "Y0G";
                    break;
                case "Aptech":
                    hdt = "96G";
                    break;
            }
            NewFolder1.MainFunction.OpenConnection();
            string query = "SELECT RIGHT(MAX(MaLop), 2) AS MaxIDClass FROM Lop WHERE MaLop LIKE 'CP"+nam+hdt+"%';";
            SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            SqlDataReader reader = command.ExecuteReader();
            string id = "";
            if (reader.Read())
            {
                if (reader.IsDBNull(0))
                {
                    id = "CP"+nam+hdt+"01";
                }
                else
                {
                    id = "CP"+nam+hdt+(int.Parse(reader.GetString(0))+1).ToString("D2");
                }
            }
            AddClassInSQL(id, hdt);
            NewFolder1.MainFunction.CloseConnection();
        }
        public void AddClassInSQL(string id, string hdt)
        {
            NewFolder1.MainFunction.OpenConnection();
            string query = "INSERT INTO Lop VALUES(@id, @ngaybatdau, @ngayketthuc, @mahedaotao, 1)";
            SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@ngaybatdau", ngayBatDau.Value.Date.ToString("MM/dd/yyyy"));
            command.Parameters.AddWithValue("@ngayketthuc", ngayKetThuc.Value.Date.ToString("MM/dd/yyyy"));
            command.Parameters.AddWithValue("@mahedaotao", hdt);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                DialogResult re = MessageBox.Show("Thêm Lớp Thành Công!",
                                                    "Thêm Lớp");
                cbHeDaoTao.Text = "-Hệ Đào Tạo-";
                ngayBatDau.Value = DateTime.Today;
                ngayKetThuc.Value = DateTime.Today;
            }
            NewFolder1.MainFunction.CloseConnection();
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbHeDaoTao.SelectedItem?.ToString()))
            {
                MessageBox.Show("Mời Nhập Đủ Thông Tin!",
                                  "Thông Báo");
                
            }
            else if(ngayBatDau.Value == ngayKetThuc.Value)
            {
                MessageBox.Show("Ngày Nhập Học phải khác Ngày Kết Thúc!",
                                  "Thông Báo");
            }
            else
            {
                AddClass();
                if (cbHeDaoTao.SelectedItem == fcbHeDaoTao.SelectedItem || fcbHeDaoTao.SelectedItem?.ToString() == "Tất Cả Lớp")
                {
                    HienThiBang();
                }
            }
        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không được sửa hệ đào tạo");
        }
        public void layThongTinLop(DataGridViewRow lop)
        {
            ngayBatDau.ValueChanged -= ngayBatDau_ValueChanged;
            txtTenLop.Text = lop.Cells[1].Value.ToString().Trim();
            tenLop = txtTenLop.Text;
            cbHeDaoTao.SelectedItem = lop.Cells[2].Value.ToString().Trim();
            ngayBatDau.Value = DateTime.ParseExact(lop.Cells[3].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            currentYear = int.Parse(lop.Cells[3].Value.ToString().Substring(6, 4));
            ngayKetThuc.Value = DateTime.ParseExact(lop.Cells[4].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            cbHeDaoTao.Click += comboBox1_Click;
            ngayBatDau.ValueChanged += ngayBatDau_ValueChanged;
        }

        private void cbHeDaoTao_TextChanged(object sender, EventArgs e)
        {
            cbHeDaoTao.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void fcbHeDaoTao_TextChanged(object sender, EventArgs e)
        {
            fcbHeDaoTao.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbHeDaoTao.SelectedItem?.ToString()))
            {
                NewFolder1.MainFunction.OpenConnection();
                string query = "UPDATE Lop SET MaLop=@malopmoi, NgayBatDau=@ngaybatdau, NgayKetThuc=@ngayketthuc WHERE MaLop=@malop";
                SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
                command.Parameters.AddWithValue("@ngaybatdau", ngayBatDau.Value.Date.ToString("MM/dd/yyyy"));
                command.Parameters.AddWithValue("@ngayketthuc", ngayKetThuc.Value.Date.ToString("MM/dd/yyyy"));
                command.Parameters.AddWithValue("@malopmoi", txtTenLop.Text);
                command.Parameters.AddWithValue("@malop", tenLop);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        DialogResult re = MessageBox.Show("Cập Nhật Lớp Thành Công!",
                                                            "Cập Nhật Lớp");
                    }
                    NewFolder1.MainFunction.CloseConnection();
                    HienThiBang();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Tên lớp đã tồn tại", "Thông báo sửa lớp");
                }
            }
            else
            {
                MessageBox.Show("Mời Nhập Đủ Thông Tin!",
                                      "Thông Báo");
            }
        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow lop = guna2DataGridView1.SelectedRows[0];
                layThongTinLop(lop);
            }
        }

        private void ngayBatDau_ValueChanged(object sender, EventArgs e)
        {
            if (currentYear != ngayBatDau.Value.Year)
            {
                Console.WriteLine("ngayBatDau.Value: " + ngayBatDau.Value.Year);
                Console.WriteLine("currenYear: " + currentYear);
                MessageBox.Show("Không được thay đổi năm nhập học");
                ngayBatDau.Value = new DateTime(currentYear, ngayBatDau.Value.Month, ngayBatDau.Value.Day);
            }
        }

        public void XuatTrangThaiExcel(DataTable[] danhSachDataTable, string lop)
        {
            try
            {
                // Tạo một ứng dụng Excel mới
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;

                // Tạo một workbook và worksheet mới
                Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add();
                Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;
                
                worksheet.Cells[1, 1] = lop;
                worksheet.Cells[1, 1].Font.Bold = true;
                worksheet.Cells[1, 1].Font.Color = ColorTranslator.ToOle(Color.Red);
                string[] trangThai;
                if (lop=="TẤT CẢ")
                {
                    trangThai = new string[] { "BÌNH THƯỜNG", "VẮNG NHIỀU", "NGUY CƠ", "NGHĨ HỌC","CHƯA TỐT NGHIỆP", "ĐÃ TỐT NGHIỆP"};
                }
                else
                {
                    trangThai = new string[] { "BÌNH THƯỜNG", "VẮNG NHIỀU", "NGUY CƠ", "NGHĨ HỌC", "ĐÃ TỐT NGHIỆP" };
                }
                int trangThaiIndex = 0;
                int rowIndex = 2;

                //Tải dữ liệu
                foreach (DataTable table in danhSachDataTable)
                {
                    //BẢNG TB1
                    worksheet.Cells[rowIndex, 1] = "TRẠNG THÁI "+trangThai[trangThaiIndex] +": ";
                    worksheet.Cells[rowIndex, 2] = table.Rows.Count + " sinh viên";
                    worksheet.Rows[rowIndex].Font.Bold = true;
                    worksheet.Rows[rowIndex].Font.Color = ColorTranslator.ToOle(Color.Blue);
                    rowIndex++;

                    //Nhập Tiêu Đề Cột
                    worksheet.Cells[rowIndex, 1] = "MSSV";
                    worksheet.Cells[rowIndex, 2] = "ID SINH VIÊN";
                    worksheet.Cells[rowIndex, 3] = "HỌ TÊN";
                    worksheet.Cells[rowIndex, 4] = "NGÀY SINH";
                    worksheet.Cells[rowIndex, 5] = "GIỚI TÍNH";
                    worksheet.Cells[rowIndex, 6] = "SĐT";
                    worksheet.Cells[rowIndex, 7] = "PHỤ HUYNH";
                    worksheet.Cells[rowIndex, 8] = "SĐT PHỤ HUYNH";
                    worksheet.Cells[rowIndex, 9] = "ĐỊA CHỈ";
                    worksheet.Cells[rowIndex, 10] = "EMAIL";
                    worksheet.Rows[rowIndex].Font.Bold = true;
                    worksheet.Rows[rowIndex].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    rowIndex++;

                    //Nhập dữ liệu bảng
                    foreach (DataRow row in table.Rows)
                    {
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            if(i==5 || i == 7)
                            {
                                worksheet.Cells[rowIndex, i + 1] = "'"+row[i].ToString();
                            }
                            else
                            {
                                worksheet.Cells[rowIndex, i + 1] = row[i].ToString();
                            }
                        }
                        worksheet.Rows[rowIndex].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        rowIndex++;

                    }
                    trangThaiIndex++;
                }

                // Tự động điều chỉnh độ rộng cột để hiển thị tốt hơn
                worksheet.Columns.AutoFit();

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

        public void layThongKeTTTheoLop(string lop)
        {
            Console.WriteLine(lop);
            NewFolder1.MainFunction.OpenConnection();

            //trạng thái bình thường
            DataTable tb = new DataTable();
            string query;
            SqlCommand command;
            if (lop =="TẤT CẢ")
            {
                query = "SELECT sv.MSSV, sv.IDSinhVien, sv.HoTen, FORMAT(sv.NgaySinh, 'dd/MM/yyyy') AS [NgaySinh], " +
                "sv.GioiTinh, sv.SDT, sv.PhuHuynh, sv.SDT_PH, sv.DiaChi, sv.Email FROM SinhVien sv " +
                "JOIN LOP l ON l.MaLop = sv.MaLop WHERE sv.MaTrangThai=1 AND l.TrangThaiLop=1";
                command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            }
            else
            {
                query = "SELECT sv.MSSV, sv.IDSinhVien, sv.HoTen, FORMAT(sv.NgaySinh, 'dd/MM/yyyy') AS [NgaySinh], " +
                "sv.GioiTinh, sv.SDT, sv.PhuHuynh, sv.SDT_PH, sv.DiaChi, sv.Email FROM SinhVien sv " +
                "JOIN LOP l ON l.MaLop = sv.MaLop WHERE l.MaLop = @malop AND sv.MaTrangThai=1";
                command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
                command.Parameters.AddWithValue("@malop", lop);
            }

            SqlDataReader reader = command.ExecuteReader();
            tb.Load(reader);
            reader.Close();

            //trạng thái vắng nhiều
            DataTable tb2 = new DataTable();
            string query2;
            SqlCommand command2;
            if (lop == "TẤT CẢ")
            {
                query2 = "SELECT sv.MSSV, sv.IDSinhVien, sv.HoTen, FORMAT(sv.NgaySinh, 'dd/MM/yyyy') AS [NgaySinh], " +
                "sv.GioiTinh, sv.SDT, sv.PhuHuynh, sv.SDT_PH, sv.DiaChi, sv.Email FROM SinhVien sv " +
                "JOIN LOP l ON l.MaLop = sv.MaLop WHERE sv.MaTrangThai=2 AND l.TrangThaiLop=1";
                command2 = new SqlCommand(query2, NewFolder1.MainFunction.getCnn());
            }
            else
            {
                query2 = "SELECT sv.MSSV, sv.IDSinhVien, sv.HoTen, FORMAT(sv.NgaySinh, 'dd/MM/yyyy') AS [NgaySinh], " +
                "sv.GioiTinh, sv.SDT, sv.PhuHuynh, sv.SDT_PH, sv.DiaChi, sv.Email FROM SinhVien sv " +
                "JOIN LOP l ON l.MaLop = sv.MaLop WHERE l.MaLop = @malop2 AND sv.MaTrangThai=2";
                command2 = new SqlCommand(query2, NewFolder1.MainFunction.getCnn());
                command2.Parameters.AddWithValue("@malop2", lop);
            }
            SqlDataReader reader2 = command2.ExecuteReader();
            tb2.Load(reader2);
            reader2.Close();

            //trạng thái nguy cơ
            DataTable tb3 = new DataTable();
            string query3;
            SqlCommand command3;
            if (lop == "TẤT CẢ")
            {
                query3 = "SELECT sv.MSSV, sv.IDSinhVien, sv.HoTen, FORMAT(sv.NgaySinh, 'dd/MM/yyyy') AS [NgaySinh], " +
                "sv.GioiTinh, sv.SDT, sv.PhuHuynh, sv.SDT_PH, sv.DiaChi, sv.Email FROM SinhVien sv " +
                "JOIN LOP l ON l.MaLop = sv.MaLop WHERE sv.MaTrangThai=3 AND l.TrangThaiLop=1";
                command3 = new SqlCommand(query3, NewFolder1.MainFunction.getCnn());
            }
            else
            {
                query3 = "SELECT sv.MSSV, sv.IDSinhVien, sv.HoTen, FORMAT(sv.NgaySinh, 'dd/MM/yyyy') AS [NgaySinh], " +
                "sv.GioiTinh, sv.SDT, sv.PhuHuynh, sv.SDT_PH, sv.DiaChi, sv.Email FROM SinhVien sv " +
                "JOIN LOP l ON l.MaLop = sv.MaLop WHERE l.MaLop = @malop3 AND sv.MaTrangThai=3";
                command3 = new SqlCommand(query3, NewFolder1.MainFunction.getCnn());
                command3.Parameters.AddWithValue("@malop3", lop);
            }
            SqlDataReader reader3 = command3.ExecuteReader();
            tb3.Load(reader3);
            reader3.Close();

            //trạng thái nghĩ học
            DataTable tb4 = new DataTable();
            string query4;
            SqlCommand command4;
            if (lop == "TẤT CẢ")
            {
                query4 = "SELECT sv.MSSV, sv.IDSinhVien, sv.HoTen, FORMAT(sv.NgaySinh, 'dd/MM/yyyy') AS [NgaySinh], " +
                "sv.GioiTinh, sv.SDT, sv.PhuHuynh, sv.SDT_PH, sv.DiaChi, sv.Email FROM SinhVien sv " +
                "JOIN LOP l ON l.MaLop = sv.MaLop WHERE sv.MaTrangThai=4 AND l.TrangThaiLop=1";
                command4 = new SqlCommand(query4, NewFolder1.MainFunction.getCnn());
            }
            else
            {
                query4 = "SELECT sv.MSSV, sv.IDSinhVien, sv.HoTen, FORMAT(sv.NgaySinh, 'dd/MM/yyyy') AS [NgaySinh], " +
                "sv.GioiTinh, sv.SDT, sv.PhuHuynh, sv.SDT_PH, sv.DiaChi, sv.Email FROM SinhVien sv " +
                "JOIN LOP l ON l.MaLop = sv.MaLop WHERE l.MaLop = @malop4 AND sv.MaTrangThai=4";
                command4 = new SqlCommand(query4, NewFolder1.MainFunction.getCnn());
                command4.Parameters.AddWithValue("@malop4", lop);
            }
            SqlDataReader reader4 = command4.ExecuteReader();
            tb4.Load(reader4);
            reader4.Close();

            //trạng thái chưa tốt nghiệp
            DataTable tb6 = new DataTable();
            if (lop == "TẤT CẢ")
            {
                string query6;
                SqlCommand command6;
                query6 = "SELECT sv.MSSV, sv.IDSinhVien, sv.HoTen, FORMAT(sv.NgaySinh, 'dd/MM/yyyy') AS [NgaySinh], " +
                "sv.GioiTinh, sv.SDT, sv.PhuHuynh, sv.SDT_PH, sv.DiaChi, sv.Email FROM SinhVien sv " +
                "JOIN LOP l ON l.MaLop = sv.MaLop WHERE sv.MaTrangThai!=0 AND l.TrangThaiLop=2";
                command6 = new SqlCommand(query6, NewFolder1.MainFunction.getCnn());
                SqlDataReader reader6 = command6.ExecuteReader();
                tb6.Load(reader6);
                reader6.Close();
            }
           

            //trạng thái đã tốt nghiệp
            DataTable tb5 = new DataTable();
            string query5;
            SqlCommand command5;
            if (lop == "TẤT CẢ")
            {
                query5 = "SELECT sv.MSSV, sv.IDSinhVien, sv.HoTen, FORMAT(sv.NgaySinh, 'dd/MM/yyyy') AS [NgaySinh], " +
                "sv.GioiTinh, sv.SDT, sv.PhuHuynh, sv.SDT_PH, sv.DiaChi, sv.Email FROM SinhVien sv " +
                "JOIN LOP l ON l.MaLop = sv.MaLop WHERE sv.MaTrangThai=0";
                command5 = new SqlCommand(query5, NewFolder1.MainFunction.getCnn());
            }
            else
            {
                query5 = "SELECT sv.MSSV, sv.IDSinhVien, sv.HoTen, FORMAT(sv.NgaySinh, 'dd/MM/yyyy') AS [NgaySinh], " +
                "sv.GioiTinh, sv.SDT, sv.PhuHuynh, sv.SDT_PH, sv.DiaChi, sv.Email FROM SinhVien sv " +
                "JOIN LOP l ON l.MaLop = sv.MaLop WHERE l.MaLop = @malop5 AND sv.MaTrangThai=0";
                command5 = new SqlCommand(query5, NewFolder1.MainFunction.getCnn());
                command5.Parameters.AddWithValue("@malop5", lop);
            }
            SqlDataReader reader5 = command5.ExecuteReader();
            tb5.Load(reader5);
            reader5.Close();

            //Truyền dữ liệu vào để xuất ra
            DataTable[] danhSachDataTable;
            if (lop=="TẤT CẢ")
            {
                danhSachDataTable = new DataTable[] { tb, tb2, tb3, tb4, tb6, tb5 };
            }
            else
            {
                danhSachDataTable = new DataTable[] { tb, tb2, tb3, tb4, tb5 };
            }

            XuatTrangThaiExcel(danhSachDataTable, lop);


            NewFolder1.MainFunction.CloseConnection();
        }

        private void btnXuatTrangThaiLop_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow lop = guna2DataGridView1.SelectedRows[0];
                layThongKeTTTheoLop(lop.Cells[1].Value.ToString());
            }
            else
            {
                MessageBox.Show("Mời nhập lớp cần xuất trạng thái");
            }
        }

        private void txtTenLop_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int maxLength = 9; // Độ dài tối đa của văn bản trong TextBox
            int allowedLength = 2; // Số ký tự cuối cùng được phép chỉnh sửa
            int lockedLength = 7; // Số ký tự đầu bị khóa


            // Kiểm tra nếu độ dài văn bản hiện tại vượt quá độ dài tối đa
            if (textBox.Text.Length >= maxLength)
            {
                // Kiểm tra nếu không phải phím Delete hoặc Backspace được nhấn
                if (e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back)
                {
                    // Hủy bỏ sự kiện KeyPress
                    e.Handled = true;
                }
            }
            else if (textBox.SelectionStart <= lockedLength)
            {
                // Hủy bỏ sự kiện KeyPress
                if (e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
                {
                    // Hủy bỏ sự kiện KeyPress
                    e.Handled = true;
                }
            }

            // Kiểm tra nếu chỉnh sửa các ký tự cuối cùng
            else if (textBox.SelectionStart >= textBox.Text.Length - allowedLength)
            {
                // Tiếp tục cho phép chỉnh sửa
                e.Handled = false;
            }
            // Ngăn chặn chỉnh sửa các ký tự khác
            else
            {
                // Hủy bỏ sự kiện KeyPress
                e.Handled = true;
            }
        }

        public void ResetDuLieu()
        {
            cbHeDaoTao.Click -= comboBox1_Click;
            ngayBatDau.ValueChanged -= ngayBatDau_ValueChanged;
            txtTenLop.Text = "";
            cbHeDaoTao.SelectedIndex = 0;
            ngayBatDau.Value = DateTime.Today;
            ngayKetThuc.Value = DateTime.Today;
        }

        private void vbXoaDuLieu_Click(object sender, EventArgs e)
        {
            ResetDuLieu();
        }
    }
}
