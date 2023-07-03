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
    public partial class XetTotNghiep : Form
    {
        private string maLop;
        private List<string> DSDuPhong = new List<string> { };
        public XetTotNghiep(string idlop)
        {
            InitializeComponent();
            maLop = idlop;
        }

        private void XetTotNghiep_Load(object sender, EventArgs e)
        {
            capNhatDuLieu();
            quanLyQuyen();
        }

        public void quanLyQuyen()
        {
            if (QuanLyTaiKhoan.Quyen == 3)
            {
                guna2Button1.Enabled = false;
                btnCapNhat.Enabled = false;
            }
            else
            {
                guna2Button1.Enabled = true;
                btnCapNhat.Enabled = true;
            }
        }

        public void capNhatDuLieu()
        {
            lblMaLop.Text = maLop;
            NewFolder1.MainFunction.OpenConnection();
            List<string> svChuaTN = new List<string> {};
            List<string> svDaTN = new List<string> {};
            //query chua tot nghiep
            string query = "SELECT sv.MSSV, sv.HoTen FROM SinhVien sv JOIN Lop l ON l.MaLop = sv.MaLop WHERE l.MaLop=@malop AND sv.MaTrangThai!=0 AND sv.MaTrangThai!=4";
            //query1 da tot nghiep
            string query1 = "SELECT sv.MSSV, sv.HoTen FROM SinhVien sv JOIN Lop l ON l.MaLop = sv.MaLop WHERE l.MaLop=@malop AND sv.MaTrangThai=0;";

            SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            command.Parameters.AddWithValue("@malop", maLop);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                svChuaTN.Add(reader.GetString(0) +" "+ reader.GetString(1));
            }
            reader.Close();

            SqlCommand command1 = new SqlCommand(query1, NewFolder1.MainFunction.getCnn());
            command1.Parameters.AddWithValue("@malop", maLop);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                svDaTN.Add(reader1.GetString(0) + " " + reader1.GetString(1));
            }
            reader1.Close();

            cklSVchuaTN.Items.Clear();
            cklSVDaTN.Items.Clear();
            cklSVchuaTN.Items.AddRange(svChuaTN.ToArray());
            cklSVDaTN.Items.AddRange(svDaTN.ToArray());

            NewFolder1.MainFunction.CloseConnection();
        }

        public void ThemSVTotNghiep(string selectedItem)
        {
            NewFolder1.MainFunction.OpenConnection();
            string query = "UPDATE SinhVien SET MaTrangThai=0 WHERE MSSV=@mssv";
            SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            command.Parameters.AddWithValue("@mssv", selectedItem);
            command.ExecuteNonQuery();
            NewFolder1.MainFunction.CloseConnection();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            lblThongBao.Visible = false;
            if (cklSVchuaTN.CheckedItems.Count > 0)
            {
                List<object> itemsToRemove = new List<object>();
                foreach (var item in cklSVchuaTN.CheckedItems)
                {
                    string selectedItem = item.ToString().Substring(0, 6);
                    cklSVDaTN.Items.Add(item);
                    DSDuPhong.Add(selectedItem);
                    itemsToRemove.Add(item);
                }
                foreach (var itemToRemove in itemsToRemove)
                {
                    cklSVchuaTN.Items.Remove(itemToRemove);
                }
            }
            else
            {
                lblThongBao.Text = "Mời chọn sinh viên cần xét tốt nghiệp";
                lblThongBao.ForeColor = Color.Red;
                lblThongBao.Visible = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            foreach (string item in DSDuPhong)
            {
                ThemSVTotNghiep(item);
            }
            capNhatDuLieu();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Nếu thoát dữ liệu trước đó sẽ không được lưu?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (re == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
