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
    public partial class frmMenu : Form
    {
        private Boolean sidebarexpand = true;
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            capNhatTrạngThaiLop();
            QuanLyTaiKhoan.layQuyen();
            quanLyQuyen();
        }

        public void quanLyQuyen()
        {
            if (QuanLyTaiKhoan.Quyen != 1)
            {
                btnQLTK.Visible = false;
            }
            else
            {
                btnQLTK.Visible = true;
            }
        }

        public void capNhatTrạngThaiLop()
        {
            NewFolder1.MainFunction.OpenConnection();
            string query = "UPDATE Lop SET TrangThaiLop=2 WHERE NgayKetThuc<GETDATE() AND TrangThaiLop!=2";
            SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            command.ExecuteNonQuery();
            NewFolder1.MainFunction.CloseConnection();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarexpand)
            {
                sidebar.Width -= 10;
                if(sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarexpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarexpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void picMenu_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void buttonClick(object sender)
        {
            Button ClickedButton = (Button)sender;
            foreach (Control btn in sidebar.Controls)
            {
                if (btn.GetType() == typeof(Panel))
                {
                    btn.Controls[0].BackColor = sidebar.BackColor;
                }
            }
            ClickedButton.BackColor = ColorTranslator.FromHtml("#e0ffff");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonClick(sender);
            panel4.Controls.Clear();
            var homeForm = new Home();
            homeForm.TopLevel = false;
            panel4.Controls.Add(homeForm);
            homeForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonClick(sender);
            panel4.Controls.Clear();
            var themLop = new ThemLop();
            themLop.TopLevel = false;
            panel4.Controls.Add(themLop);
            themLop.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            buttonClick(sender);
            panel4.Controls.Clear();
            var thongKe = new ThongKe();
            thongKe.TopLevel = false;
            panel4.Controls.Add(thongKe);
            thongKe.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan.IsLoggedIn = false;
            QuanLyTaiKhoan.LoggedInUsername = "";
            frmDangNhap dangnhap = new frmDangNhap();
            dangnhap.Show();
            this.Close();
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            buttonClick(sender);
            panel4.Controls.Clear();
            var taiKhoan = new TaiKhoan();
            taiKhoan.TopLevel = false;
            panel4.Controls.Add(taiKhoan);
            taiKhoan.Show();
        }
    }
}
