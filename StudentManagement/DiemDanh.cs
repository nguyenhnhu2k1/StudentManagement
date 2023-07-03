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

namespace StudentManagement
{
    public partial class DiemDanh : Form
    {
        private string id;
        private string malop;
        private DateTime ngayBatDau;
        public DiemDanh(string idSinhVien)
        {
            InitializeComponent();
            id = idSinhVien;
        }

        private void DiemDanh_Load(object sender, EventArgs e)
        {
            datengaynghi.Value = DateTime.Today;
            txtLyDo.Text = "";
            capNhatDuLieu();
            HienThiChiTietVang();
            DanhSachSinhVien();
            quanLyQuyen();
        }

        public void quanLyQuyen()
        {
            if (QuanLyTaiKhoan.Quyen == 3)
            {
                btnCapNhat.Enabled = false;
            }
            else
            {
                btnCapNhat.Enabled = true;
            }
        }

        public void capNhatDuLieu()
        {
            NewFolder1.MainFunction.OpenConnection();
            string query = "SELECT sv.MSSV, sv.MaLop, tt.TenTrangThai, a.tong_vang, sv.HoTen, l.NgayBatDau FROM SinhVien sv JOIN(SELECT s.IDSinhVien, COUNT(v.IDSinhVien) AS tong_vang FROM SinhVien s LEFT JOIN Vang v ON s.IDSinhVien = v.IDSinhVien GROUP BY s.IDSinhVien) a ON a.IDSinhVien=sv.IDSinhVien JOIN TrangThai tt ON tt.MaTrangThai=sv.MaTrangThai JOIN Lop l ON l.MaLop = sv.MaLop WHERE sv.IDSinhVien=@idsinhvien;";
            SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            command.Parameters.AddWithValue("@idsinhvien", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                lblMSSV.Text = reader.GetString(0);
                lblMaLop.Text = reader.GetString(1);
                malop = lblMaLop.Text;
                lblTrangThaiSV.Text = reader.GetString(2);
                lblSoLuotVang.Text = reader.GetInt32(3) + "";
                lblHoTen.Text = reader.GetString(4);
                ngayBatDau = reader.GetDateTime(5).Date;
            }
            reader.Close();
            NewFolder1.MainFunction.CloseConnection();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            NewFolder1.MainFunction.OpenConnection();
            String query2 = "SELECT IDSinhVien, NgayVang FROM Vang WHERE IDSinhVien=@Value1 AND NgayVang=@Value2;";
            SqlCommand command2 = new SqlCommand(query2, NewFolder1.MainFunction.getCnn());
            command2.Parameters.AddWithValue("@Value1", id);
            command2.Parameters.AddWithValue("@Value2", datengaynghi.Value.Date.ToString("MM/dd/yyyy"));
            String check = (string)command2.ExecuteScalar();

            if (!string.IsNullOrEmpty(check))
            {
                MessageBox.Show("Sinh viên đã được điểm danh vắng vào ngày " + datengaynghi.Value.Date.ToString("dd/MM/yyyy"), "Thông Báo");
            }
            else if (datengaynghi.Value < ngayBatDau)
            {
                MessageBox.Show("Không được quá ngày nhập học!");
            }
            else if (datengaynghi.Value > DateTime.Today)
            {
                MessageBox.Show("Không được quá ngày hiện tại!");
            }
            else
            {
                string query = "INSERT INTO Vang (IDSinhVien, NgayVang, LyDo) VALUES (@Value1, @Value2, @Value3)";
                SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
                command.Parameters.AddWithValue("@Value1", id);
                command.Parameters.AddWithValue("@Value2", datengaynghi.Value.Date.ToString("MM/dd/yyyy"));
                command.Parameters.AddWithValue("@Value3", txtLyDo.Text);
                command.ExecuteNonQuery();

                String query1 = "UPDATE SinhVien SET MaTrangThai = t3.MaTrangThai FROM SinhVien t1 JOIN(SELECT s.IDSinhVien, COUNT(v.IDSinhVien) AS tong_vang FROM SinhVien s LEFT JOIN Vang v ON s.IDSinhVien = v.IDSinhVien GROUP BY s.IDSinhVien) a ON t1.IDSinhVien = a.IDSinhVien JOIN TrangThai t3 ON a.tong_vang BETWEEN t3.LuotVangMin AND t3.LuotVangMax JOIN Lop l ON l.MaLop=t1.MaLop  WHERE l.TrangThaiLop!=2 AND t1.MaTrangThai!=4";
                SqlCommand command1 = new SqlCommand(query1, NewFolder1.MainFunction.getCnn());
                command1.ExecuteNonQuery();
                datengaynghi.Value = DateTime.Today;
                txtLyDo.Text = "";
                capNhatDuLieu();
                HienThiChiTietVang();
            }
            NewFolder1.MainFunction.CloseConnection();
        }

        public void HienThiChiTietVang()
        {
            NewFolder1.MainFunction.OpenConnection();
            String query2 = "SELECT FORMAT(NgayVang, 'dd/MM/yyyy') AS [NgayVang], LyDo FROM Vang WHERE IDSinhVien=@id";
            SqlCommand command2 = new SqlCommand(query2, NewFolder1.MainFunction.getCnn());
            command2.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command2.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(reader);
            dataGridView1.DataSource = tb;
            dataGridView1.Visible = true;
            int rowCount = dataGridView1.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
            dataGridView1.Columns[1].HeaderText = "Ngày Vắng";
            dataGridView1.Columns[2].HeaderText = "Lý Do";
            reader.Close();
            NewFolder1.MainFunction.CloseConnection();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void DanhSachSinhVien()
        {
            NewFolder1.MainFunction.OpenConnection();
            String query2 = "SELECT MSSV, HoTen, SDT, Email, PhuHuynh, SDT_PH, IDSinhVien FROM SinhVien WHERE MaLop=@malop AND MaTrangThai != 4";
            SqlCommand command2 = new SqlCommand(query2, NewFolder1.MainFunction.getCnn());
            command2.Parameters.AddWithValue("@malop", malop);
            SqlDataReader reader = command2.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(reader);
            dataGridView2.DataSource = tb;
            int rowCount = dataGridView2.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = i + 1;
            }
            dataGridView2.Columns[2].HeaderText = "Họ Tên";
            dataGridView2.Columns[5].HeaderText = "Phụ Huynh";
            dataGridView2.Columns[6].HeaderText = "SĐT Phụ Huynh";
            reader.Close();
            NewFolder1.MainFunction.CloseConnection();
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView2.SelectedRows.Count == 1)
            {
                DataGridViewRow sinhvien = dataGridView2.SelectedRows[0];
                id = sinhvien.Cells[dataGridView2.ColumnCount - 1].Value.ToString();
                capNhatDuLieu();
                HienThiChiTietVang();
            }
        }

    }
}
