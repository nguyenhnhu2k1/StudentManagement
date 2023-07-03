using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public static class QuanLyTaiKhoan
    {
        public static bool IsLoggedIn
        {
            get; set;
        }
        public static string LoggedInUsername
        {
            get; set;
        }
        public static int Quyen
        {
            get; set;
        }
        public static string LoaiTaiKhoan(int loaiTK)
        {
            switch (loaiTK)
            {
                case 1:
                    return "Admin";
                case 2:
                    return "Giáo Viên";
                default:
                    return "Nhân Viên";

            }
        }

        //lấy quyền dựa vào tên username
        public static void layQuyen()
        {
            Console.WriteLine("Tên: " + LoggedInUsername);
            NewFolder1.MainFunction.OpenConnection();
            string query = "SELECT UserAuthorization FROM Account WHERE UserName=@ten";
            SqlCommand command = new SqlCommand(query, NewFolder1.MainFunction.getCnn());
            command.Parameters.AddWithValue("@ten", LoggedInUsername);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Quyen = reader.GetInt32(0);
            }
            reader.Close();
            NewFolder1.MainFunction.CloseConnection();
        }

    }
}
