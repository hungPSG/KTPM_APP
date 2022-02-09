using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPM_APP
{
    class NhanVienDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public NhanVienDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getAllNhanVien()
        {
            string sql = "SELECT* FROM tblNhanVien";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public bool ThemNhanVien(tblNhanVien nv)
        {
            string sql = "INSERT INTO tblNhanVien(MaNhanVien, TenNhanVien, NamSinh, QueQuan, ChucVu, SDT, CCCD, TrinhDo, MaPhong) VALUES(@MaNhanVien, @TenNhanVien, @NamSinh, @QueQuan, @ChucVu, @SDT, @CCCD, @TrinhDo, @MaPhong)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = nv.MaNhanVien;
                cmd.Parameters.Add("@TenNhanVien", SqlDbType.NVarChar).Value = nv.TenNhanVien;
               // cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = nv.GioiTinh;
                cmd.Parameters.Add("@NamSinh", SqlDbType.NVarChar).Value = nv.NamSinh;
                cmd.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = nv.QueQuan;
                cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = nv.ChucVu;
                cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = nv.SDT;
                cmd.Parameters.Add("@CCCD", SqlDbType.NVarChar).Value = nv.CCCD;
                cmd.Parameters.Add("@TrinhDo", SqlDbType.NVarChar).Value = nv.TrinhDo;
                cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = nv.MaPhong;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool SuaNhanVien (tblNhanVien nv)
        {
            string sql = "UPDATE tblNhanVien SET TenNhanVien= @TenNhanVien, NamSinh=@NamSinh, QueQuan=@QueQuan, ChucVu=@ChucVu, SDT=@SDT, CCCD= @CCCD, TrinhDo=@TrinhDo, MaPhong= @MaPhong WHERE MaNhanVien=@MaNhanVien";

            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
               // cmd.Parameters.Add("@Id", SqlDbType.Int).Value = nv.Id;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = nv.MaNhanVien;
                cmd.Parameters.Add("@TenNhanVien", SqlDbType.NVarChar).Value = nv.TenNhanVien;
               // cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = nv.GioiTinh;
                cmd.Parameters.Add("@NamSinh", SqlDbType.NVarChar).Value = nv.NamSinh;
                cmd.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = nv.QueQuan;
                cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = nv.ChucVu;
                cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = nv.SDT;
                cmd.Parameters.Add("@CCCD", SqlDbType.NVarChar).Value = nv.CCCD;
                cmd.Parameters.Add("@TrinhDo", SqlDbType.NVarChar).Value = nv.TrinhDo;
                cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = nv.MaPhong;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool XoaNhanVien (tblNhanVien nv)
        {
            string sql = "DELETE tblNhanVien WHERE Id=@Id";

            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = nv.Id;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

       

        public DataTable TimKiemNhanVien(string nv)
        {
            string sql = "SELECT * FROM tblNhanVien WHERE TenNhanVien like N'%" + nv + "%' ";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        string temp;
        public bool TrungMaNhanVien(string MaNhanVien)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NDNDB0N\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True");
            string sql = "select count(Id) from tblNhanVien where MaNhanVien like N'%" + MaNhanVien + "%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                temp = dr[0].ToString();
            }
            con.Close();
            int temp1 = int.Parse(temp);
            if (temp1 == 0)
            {
                return false;
            }
            else{
                return true;
            }
        }
    }

}
