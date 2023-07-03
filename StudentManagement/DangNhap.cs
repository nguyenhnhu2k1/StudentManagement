using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StudentManagement.NewFolder1;
namespace StudentManagement
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Boolean loi = false;
            errorProvider1.Clear();
            if (txtUsername.Text == "")
            {
                errorProvider1.SetError(txtUsername, "UserName không được trống");
                loi = true;
            }
            else if (txtMatKhau.Text == "")
            {
                errorProvider1.SetError(txtMatKhau, "Mật khẩu không được trống");
                loi = true;
            }

            if (loi==false)
            {
                string userName = txtUsername.Text;
                string matKhau = txtMatKhau.Text;
                Console.WriteLine(NewFolder1.MainFunction.DangNhap(userName, matKhau));
                if (NewFolder1.MainFunction.DangNhap(userName, matKhau))
                {
                    QuanLyTaiKhoan.IsLoggedIn = true;
                    QuanLyTaiKhoan.LoggedInUsername = userName;
                    frmMenu menu = new frmMenu();
                    menu.Show();
                    this.Hide();
                }
                
            }
            
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtMatKhau.Text = "admin";
            quanLyQuyen();
        }

        public void quanLyQuyen()
        {
            if (QuanLyTaiKhoan.Quyen != 1)
            {
                label1.Visible = false;
            }
            else
            {
                label1.Visible = false;
            }
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
                Application.Exit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn muốn thoát?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (re == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DangKy dangky = new DangKy();
            dangky.Show();
        }
    }
}
