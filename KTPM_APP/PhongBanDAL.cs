using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPM_APP
{
    class PhongBanDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public PhongBanDAL()
        {
            dc = new DataConnection();
        }
        public DataTable GetAllPhongBan()
        {
            string sql = "select * from tblPhongBan";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        string Temp;
        int Temp1;
        public bool ThemNhanVien(string MaPhong)
        {
            string sql = "select tblPhongBan.SoNhanVien from tblPhongBan where MaPhong=@MaPhong";
            string sql1 = "Update tblPhongBan Set SoNhanVien=@SoNhanVien where MaPhong=@MaPhong";
            SqlConnection con = dc.getConnect();
            try
            {
                con.Open();
                
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
               cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = MaPhong;
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Temp = dr[0].ToString();
               }
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            int tonghientai = Int32.Parse(Temp)+1;
            try
            {
                cmd = new SqlCommand(sql1, con);
                con.Open();
                cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = MaPhong;
                cmd.Parameters.Add("@SoNhanVien", SqlDbType.Int).Value = tonghientai;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool XoaNhanVien(string MaPhong)
        {
            string sql = "select tblPhongBan.SoNhanVien from tblPhongBan where MaPhong=@MaPhong";
            string sql1 = "Update tblPhongBan Set SoNhanVien=@SoNhanVien where MaPhong=@MaPhong";
            SqlConnection con = dc.getConnect();
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = MaPhong;
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Temp = dr[0].ToString();
                }
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            int tonghientai = Int32.Parse(Temp) -1;
            try
            {
                cmd = new SqlCommand(sql1, con);
                con.Open();
                cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = MaPhong;
                cmd.Parameters.Add("@SoNhanVien", SqlDbType.Int).Value = tonghientai;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool SuaPhongBan(string MaPhong, string TenPhong, string TrangThai, string SDT, string Email)
        {

            string sql = "UPDATE tblPhongBan SET TenPhong=@TenPhong, TrangThai=@TrangThai, SDT=@SDT,Email=@Email WHERE MaPhong= @MaPhong";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value =MaPhong;
                cmd.Parameters.Add("@TenPhong", SqlDbType.NVarChar).Value = TenPhong;
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value =TrangThai;
                cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = SDT;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value =Email;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public string SoF0(string MaPhong)
        {
            string sql = @"select count(tblCoVid.MaCoVid) from tblCoVid,tblNhanVien where tblNhanVien.MaPhong=@MaPhong and TblCoVid.TrangThai='F0' and tblNhanVien.MaNhanVien =tblCoVid.MaNhanVien";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = MaPhong;
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Temp = dr[0].ToString();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                return Temp;
            }
            return Temp;
        }
        public string SoF1(string MaPhong)
        {
            string sql = @"select count(tblCoVid.MaCoVid) from tblCoVid,tblNhanVien where tblNhanVien.MaPhong=@MaPhong and TblCoVid.TrangThai='F1' and tblNhanVien.MaNhanVien =tblCoVid.MaNhanVien";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = MaPhong;
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Temp = dr[0].ToString();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                return Temp;
            }
            return Temp;
        }
    }
}