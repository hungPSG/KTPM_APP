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

        public bool KhoiTaoTaiKhoan(tblNhanVien nv)
        {
            string sql = "INSERT INTO tblDangNhap(TaiKhoan, MatKhau,Quyen,MaNhanVien) VALUES(@TaiKhoan,@MatKhau,@Quyen,@MaNhanVien)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = nv.MaNhanVien;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = nv.MaNhanVien;
                cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = nv.CCCD;
                cmd.Parameters.Add("@Quyen", SqlDbType.Int).Value = 0;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool SuaTaiKhoanDN(tblNhanVien nv)
        {
            string sql = "UPDATE tblDangNhap SET MatKhau=@MatKhau WHERE MaNhanVien=@MaNhanVien";

            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = nv.MaNhanVien;
                cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = nv.CCCD;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool XoaTaiKhoan(tblNhanVien nv)
        {
            string sql = "DELETE tblDangNhap WHERE MaNhanVien=@MaNhanVien";

            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = nv.MaNhanVien;
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
