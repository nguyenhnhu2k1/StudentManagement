using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManagement.NewFolder1
{
    class MainFunction
    {
        private static string connectionString;
        private static SqlConnection cnn;

        public static SqlConnection getCnn()
        {
            return cnn;
        }
        public static void OpenConnection()
        {
            connectionString = @"Data Source=DESKTOP-ALSELER\SQLEXPRESS;Initial Catalog=QL_SinhVien;Integrated Security=True";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
        }

        public static void CloseConnection()
        {
                cnn.Close();
        }

        public static void DangKy(string userName, string matKhau, string HoTen)
        {
            string query = "INSERT INTO Account(UserName, Pass, FullName) VALUES (@username, @pass, @fullname)";
            SqlCommand command = new SqlCommand(query, cnn);
            command.Parameters.AddWithValue("@username", userName);
            command.Parameters.AddWithValue("@pass", matKhau);
            command.Parameters.AddWithValue("@fullname", HoTen);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                DialogResult re = MessageBox.Show("Đăng Ký Tài Khoản Thành Công! Bạn có muốn đăng nhập",
                                                    "Đăng Ký",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Information);
            }
        }
        public static Boolean DangNhap(string userName, string matKhau)
        {
            OpenConnection();
            string query = "SELECT UserName, Pass FROM Account WHERE UserName=@username AND Pass=@pass";
            SqlCommand command = new SqlCommand(query, cnn);
            command.Parameters.AddWithValue("@username", userName);
            command.Parameters.AddWithValue("@pass", matKhau);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                CloseConnection();
                return true;
            }
            else
            {
                MessageBox.Show("Bạn nhập sai tài khoản hoặc mật khẩu!");
                reader.Close();
                CloseConnection();
                return false;
            }
        }
        public static string[] AddDataComboboxClass(string MaHeDaoTao)
        {
            OpenConnection();
            List<string> dataList = new List<string>();
            String query;
            if (MaHeDaoTao == "Y0G")
            {
                query = "SELECT MaLop FROM Lop WHERE MaHeDaoTao='Y0G'";
            }
            else if (MaHeDaoTao == "96G")
            {
                query = "SELECT MaLop FROM Lop WHERE MaHeDaoTao='96G'";
            }
            else if (MaHeDaoTao == "cbClassThem")
            {
                query = "SELECT MaLop FROM Lop WHERE TrangThaiLop!=2";
            }
            else
            {
                query = "SELECT MaLop FROM Lop";
            }
            SqlCommand command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataList.Add(reader.GetString(0));
            }
            reader.Close();
            CloseConnection();
            return dataList.ToArray();
        }
    }
    

}