using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StudentManagement
{
    public partial class ThongKe : Form
    {
        //Lớp đang học => Trạng Thái lớp ==1
        //Lớp kết thuc => Trạng Thái lớp !=1
        private int tongSVDangHoc = 0; //tong sv trong lop dang hoc
        private int trangThai01 = 0;
        private int trangThai02 = 0;
        private int trangThai03 = 0;
        private int trangThai04 = 0;

        private int tongSVDaKetThuc= 0; //tong sv trong lop da ket thuc
        private int tongSVDaTotNghiep= 0; 
        private int tongSVChuaTotNghiep= 0; 
        public ThongKe()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            layDuLieu();
            CapNhatuLieu();
        }

        public void layDuLieu() //lay du lieu thong ke
        {
            NewFolder1.MainFunction.OpenConnection();
            String query1 = "SELECT " +
                "(SELECT COUNT(sv.IDSinhVien) FROM SinhVien sv JOIN Lop l ON l.MaLop = sv.MaLop WHERE l.TrangThaiLop = 1) AS SoSVDangHoc," +
                "(SELECT COUNT(sv.IDSinhVien) FROM SinhVien sv JOIN Lop l ON l.MaLop = sv.MaLop WHERE l.TrangThaiLop = 1 AND sv.MaTrangThai = 1) AS TrangThai01," +
                "(SELECT COUNT(sv.IDSinhVien) FROM SinhVien sv JOIN Lop l ON l.MaLop = sv.MaLop WHERE l.TrangThaiLop = 1 AND sv.MaTrangThai = 2) AS TrangThai02," +
                "(SELECT COUNT(sv.IDSinhVien) FROM SinhVien sv JOIN Lop l ON l.MaLop = sv.MaLop WHERE l.TrangThaiLop = 1 AND sv.MaTrangThai = 3) AS TrangThai03," +
                "(SELECT COUNT(sv.IDSinhVien) FROM SinhVien sv JOIN Lop l ON l.MaLop = sv.MaLop WHERE l.TrangThaiLop = 1 AND sv.MaTrangThai = 4) AS TrangThai04," +
                "(SELECT COUNT(sv.IDSinhVien) FROM SinhVien sv JOIN Lop l ON l.MaLop = sv.MaLop WHERE l.TrangThaiLop != 1) AS tongSVDaKetThuc," +
                "(SELECT COUNT(sv.IDSinhVien) FROM SinhVien sv JOIN Lop l ON l.MaLop = sv.MaLop WHERE l.TrangThaiLop != 1 AND sv.MaTrangThai = 0) AS tongSVDaTotNghiep," +
                "(SELECT COUNT(sv.IDSinhVien) FROM SinhVien sv JOIN Lop l ON l.MaLop = sv.MaLop WHERE l.TrangThaiLop != 1 AND sv.MaTrangThai != 0) AS tongSVChuaTotNghiep; ";
            SqlCommand command = new SqlCommand(query1, NewFolder1.MainFunction.getCnn());
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                tongSVDangHoc = reader.GetInt32(0);
                trangThai01 = reader.GetInt32(1);
                trangThai02 = reader.GetInt32(2);
                trangThai03 = reader.GetInt32(3);
                trangThai04 = reader.GetInt32(4);

                tongSVDaKetThuc = reader.GetInt32(5);
                tongSVDaTotNghiep = reader.GetInt32(6);
                tongSVChuaTotNghiep = reader.GetInt32(7);
            }

            reader.Close();
            NewFolder1.MainFunction.CloseConnection();
        }

        public void CapNhatuLieu()
        {
            DataGridViewTextBoxColumn newColumn1 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn newColumn2 = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(newColumn1);
            dataGridView1.Columns.Add(newColumn2);

            dataGridView1.Rows.Add("Tổng số lượng sinh viên đang học", tongSVDangHoc);
            dataGridView1.Rows.Add("Trạng thái 1", trangThai01);
            dataGridView1.Rows.Add("Trạng thái 2", trangThai02);
            dataGridView1.Rows.Add("Trạng thái 3", trangThai03);
            dataGridView1.Rows.Add("Trạng thái 4", trangThai04);

            dataGridView1.Rows.Add("");
            dataGridView1.Rows.Add("Tổng số lượng sinh viên đã kết thúc", tongSVDaKetThuc);
            dataGridView1.Rows.Add("Đã tốt nghiệp", tongSVDaTotNghiep);
            dataGridView1.Rows.Add("Chưa tốt nghiệp", tongSVChuaTotNghiep);
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void ExportExcel(string excelPath)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Application.Workbooks.Add(Type.Missing);
            int rowCount = dataGridView1.RowCount;
            NewFolder1.MainFunction.OpenConnection();

            for (int i = 0; i < rowCount - 1; i++) //dong
            {
                for (int j = 0; j < 2; j++) //cot
                {
                    app.Cells[i + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            app.Columns.AutoFit();
            app.ActiveWorkbook.SaveCopyAs(excelPath);
            app.ActiveWorkbook.Saved = true;
            app.Workbooks.Close();
            app.Quit();
            Marshal.ReleaseComObject(app);
            NewFolder1.MainFunction.CloseConnection();
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            ThemLop themLop = new ThemLop();
            themLop.layThongKeTTTheoLop("TẤT CẢ");
        }
    }
}
