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
    public partial class TaiKhoan : Form
    {
        private string TenNguoiDung = "";
        public TaiKhoan()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            layTaiKhoan();
        }

        //lấy tất cả tài khoản vào datagirdview
        public void layTaiKhoan()
        {

            //lấy dữ liệu từ csdl
            NewFolder1.MainFunction.OpenConnection();
            String query = "SELECT Pass AS 'STT', UserName, Pass AS N'Mật khẩu', FullName AS N'Họ Tên', CASE WHEN UserAuthorization=2 THEN N'Giáo viên' WHEN UserAuthorization=3 THEN N'Nhân viên'END AS N'Loại Tài Khoản' FROM Account WHERE UserAuthorization!=1";
            SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            SqlDataReader reader = command.ExecuteReader();
            //thêm dữ liệu vào bảng
            DataTable tb = new DataTable();
            tb.Load(reader);

            //Tạo cột stt cho bảng
            guna2DataGridView1.DataSource = tb;
            guna2DataGridView1.Visible = true;
            for (int i = 0; i < guna2DataGridView1.RowCount; i++)
            {
                guna2DataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
            reader.Close();
            NewFolder1.MainFunction.CloseConnection();

            //ngăn chặn sắp xếp trong bảng
            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void cbQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cbQuyen_TextChanged(object sender, EventArgs e)
        {
            cbQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void layThongTinTaiKhoan(DataGridViewRow lop)
        {
            txtUsername.Text = lop.Cells[1].Value.ToString().Trim();
            TenNguoiDung = txtUsername.Text;
            txtHoTen.Text = lop.Cells[3].Value.ToString().Trim();
            txtMatKhau.Text = lop.Cells[2].Value.ToString().Trim();
            cbQuyen.SelectedItem = lop.Cells[4].Value.ToString().Trim();
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow lop = guna2DataGridView1.SelectedRows[0];
                layThongTinTaiKhoan(lop);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtHoTen.Text)
                && !string.IsNullOrWhiteSpace(txtMatKhau.Text)
                && !string.IsNullOrWhiteSpace(txtUsername.Text)
                && !string.IsNullOrWhiteSpace(cbQuyen.SelectedItem?.ToString()))
            {
                NewFolder1.MainFunction.OpenConnection();
                string query = "INSERT INTO Account(FullName, UserName, Pass, UserAuthorization) " +
                                "VALUES (@fullname, @user, @pass, @auth);";
                SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
                command.Parameters.AddWithValue("@fullname", txtHoTen.Text);
                command.Parameters.AddWithValue("@user", txtUsername.Text);
                command.Parameters.AddWithValue("@pass", txtMatKhau.Text);
                int auth;
                if (cbQuyen.SelectedItem.ToString() == "Giáo viên")
                {
                    auth = 2;
                }
                else
                {
                    auth = 3;
                }
                Console.WriteLine(auth);
                command.Parameters.AddWithValue("@auth", auth);
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đăng ký tài khoản thành công!", "Đăng Ký");
                    }
                    txtHoTen.Text = "";
                    txtUsername.Text = "";
                    txtMatKhau.Text = "";
                    layTaiKhoan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại");
                }

                NewFolder1.MainFunction.CloseConnection();
            }
            else
            {
                MessageBox.Show("Mời Nhập Đủ Thông Tin!",
                                  "Thông Báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtHoTen.Text)
                && !string.IsNullOrWhiteSpace(txtMatKhau.Text)
                && !string.IsNullOrWhiteSpace(txtUsername.Text)
                && !string.IsNullOrWhiteSpace(cbQuyen.SelectedItem?.ToString()))
            {
                NewFolder1.MainFunction.OpenConnection();
                string query = "UPDATE Account SET UserName=@user, Pass=@pass, FullName=@fullname, UserAuthorization=@auth WHERE UserName = @tennguoidung";
                SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
                command.Parameters.AddWithValue("@fullname", txtHoTen.Text);
                command.Parameters.AddWithValue("@user", txtUsername.Text);
                command.Parameters.AddWithValue("@pass", txtMatKhau.Text);
                command.Parameters.AddWithValue("@tennguoidung", TenNguoiDung);
                int auth;
                if (cbQuyen.SelectedItem.ToString() == "Giáo viên")
                {
                    auth = 2;
                }
                else
                {
                    auth = 3;
                }
                command.Parameters.AddWithValue("@auth", auth);
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Đăng Ký");
                    }
                    txtHoTen.Text = "";
                    txtUsername.Text = "";
                    txtMatKhau.Text = "";
                    layTaiKhoan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại");
                }

                NewFolder1.MainFunction.CloseConnection();
            }
            else
            {
                MessageBox.Show("Mời Nhập Đủ Thông Tin!",
                                  "Thông Báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Bạn Có Muốn Xóa Tài Khoản", "Thông Báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    NewFolder1.MainFunction.OpenConnection();
                    string query = "DELETE FROM Account WHERE UserName = @tennguoidung";
                    SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
                    command.Parameters.AddWithValue("@tennguoidung", TenNguoiDung);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công tài khoản " + TenNguoiDung);
                    layTaiKhoan();
                }
            }
            else
            {
                MessageBox.Show("Chọn Một Tài Khoản Để Xóa");
            }
        }
    }
}
