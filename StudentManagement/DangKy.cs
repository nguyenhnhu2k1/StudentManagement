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
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            Boolean loi = false;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                errorProvider1.SetError(txtHoTen, "Họ Tên không được trống");
                loi = true;
            }
            else if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "UserName không được trống");
                loi = true;
            }
            else if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                errorProvider1.SetError(txtMatKhau, "Mật khẩu không được trống");
                loi = true;
            }
            else if (string.IsNullOrWhiteSpace(txtNLMK.Text))
            {
                errorProvider1.SetError(txtNLMK, "Nhập lại mật khẩu");
                loi = true;
            }
            else if (txtMatKhau.Text != txtNLMK.Text)
            {
                errorProvider1.SetError(txtNLMK, "Mật khẩu không trùng nhau");
                loi = true;
            }
            else if (string.IsNullOrEmpty(cbLoaiTK.SelectedItem?.ToString()))
            {
                errorProvider1.SetError(cbLoaiTK, "Chọn loại tài khoản");
                loi = true;
            }
            if (loi == false)
            {
                int auth;
                if (cbLoaiTK.SelectedItem.ToString() == "Giáo Viên")
                {
                    auth = 2;
                }
                else
                {
                    auth = 3;
                }
                NewFolder1.MainFunction.OpenConnection();
                string query = "INSERT INTO Account(FullName, UserName, Pass, UserAuthorization) " +
                                "VALUES (@fullname, @user, @pass, @auth);";
                SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
                command.Parameters.AddWithValue("@fullname", txtHoTen.Text);
                command.Parameters.AddWithValue("@user", txtUsername.Text);
                command.Parameters.AddWithValue("@pass", txtMatKhau.Text);
                Console.WriteLine(auth);
                command.Parameters.AddWithValue("@auth", auth);
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đăng ký tài khoản thành công!", "Đăng Ký");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại");
                }
                
            NewFolder1.MainFunction.CloseConnection();
        }
        }

        private void cbLoaiTK_TextChanged(object sender, EventArgs e)
        {
            cbLoaiTK.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn muốn thoát?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (re == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
