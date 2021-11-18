using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPM_APP
{
    class DangNhapDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public DangNhapDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getAllTaiKhoan()
        {
            // B1: Tạo câu lệnh SQL để lấy toàn bộ tài khoản 
            string sql = "SELECT * FROM tblDangNhap";
            // B2: tạo một kết nối đến SQL  
            SqlConnection con = dc.getConnect();
            // B3: khởi tạo đối tượng của lớp SqlDataAdapter
            da = new SqlDataAdapter(sql, con);
            // B4: mở kết nối
            con.Open();
            //B5: đổ dữ liệu từ SqlDataAdapter vào datatable
            DataTable dt = new DataTable();
            da.Fill(dt);
            // B6: đóng kết nối
            con.Close();
            return dt;
        }

        public bool ThemTaiKhoan(tblDangNhap tk)
        {
            string sql = "INSERT INTO tblDangNhap(TaiKhoan, MatKhau, Quyen) VALUES(@TaiKhoan,@MatKhau,@Quyen)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = tk.TaiKhoan;
                cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = tk.MatKhau;
                cmd.Parameters.Add("@Quyen", SqlDbType.NVarChar).Value = tk.Quyen;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        public bool SuaTaiKhoan(tblDangNhap tk)
        {
            string sql = "UPDATE tblDangNhap SET TaiKhoan = @TaiKhoan, MatKhau= @MatKhau, Quyen= @Quyen WHERE TaiKhoan= @TaiKhoan";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
              //  cmd.Parameters.Add("@Id", SqlDbType.Int).Value = tk.Id;
                cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = tk.TaiKhoan;
                cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = tk.MatKhau;
                cmd.Parameters.Add("@Quyen", SqlDbType.NVarChar).Value = tk.Quyen;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool XoaTaiKhoan(tblDangNhap tk)
        {
            string sql = "DELETE tblDangNhap WHERE TaiKhoan =@TaiKhoan";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = tk.TaiKhoan;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
