using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPM_APP
{
    class CoVidDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

       public CoVidDAL()
        {
            dc = new DataConnection();
        }

        string temp = "CV";
        public bool KhoiTaoCoVid(tblNhanVien nv)
        {
            string sql = "INSERT INTO tblCoVid(MaCoVid, MaNhanVien,SoMuiTiem,TrangThai,HinhThuc) VALUES(@MaCoVid,@MaNhanVien,@SoMuiTiem,@TrangThai,@HinhThuc)";
            SqlConnection con = dc.getConnect();
            temp = temp + nv.MaNhanVien;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaCoVid", SqlDbType.NVarChar).Value = temp;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = nv.MaNhanVien;
                cmd.Parameters.Add("@SoMuiTiem", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = "";
                cmd.Parameters.Add("@HinhThuc", SqlDbType.NVarChar).Value = "";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool SuaCoVid(string MaNhanVien, int SoMuiTiem, string TrangThai, string HinhThuc)
        {
            string sql = "UPDATE tblCoVid SET SoMuiTiem=@SoMuiTiem, TrangThai=@TrangThai , HinhThuc=@HinhThuc WHERE MaNhanVien= @MaNhanVien";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = MaNhanVien;
                cmd.Parameters.Add("@SoMuiTiem", SqlDbType.Int).Value =SoMuiTiem;
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = TrangThai;
                cmd.Parameters.Add("@HinhThuc", SqlDbType.NVarChar).Value = HinhThuc;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool XoaCoVid(tblNhanVien nv)
        {

            string sql = "DELETE tblCoVid WHERE MaNhanVien=@MaNhanVien";

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
        public DataTable GetAllCoVid()
        {
            string sql = "select tblNhanVien.MaNhanVien, tblNhanVien.TenNhanVien, tblNhanVien.MaPhong, tblCoVid.SoMuiTiem, tblCoVid.TrangThai, tblCoVid.HinhThuc from tblNhanVien, tblCoVid where  tblNhanVien.MaNhanVien = tblCoVid.MaNhanVien";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool ThemF0F1(string MaNhanVien, string TrangThai, string NguonLay, string Ngay,string HinhThuc)
        {
            string sql = "UPDATE tblCoVid SET TrangThai=@TrangThai, NguonLay=@NguonLay , Ngay=@Ngay, HinhThuc=@HinhThuc WHERE MaNhanVien= @MaNhanVien";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = MaNhanVien;
                cmd.Parameters.Add("@NguonLay", SqlDbType.NVarChar).Value = NguonLay;
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = TrangThai;
                cmd.Parameters.Add("@HinhThuc", SqlDbType.NVarChar).Value = HinhThuc;
                cmd.Parameters.Add("@Ngay", SqlDbType.NVarChar).Value = Ngay;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable GetAllF0()
        {
            string sql = @"select tblCoVid.MaNhanVien, tblNhanVien.TenNhanVien,tblNhanVien.MaPhong, tblCoVid.NguonLay, tblCoVid.Ngay from tblCoVid,tblNhanVien where tblCoVid.MaNhanVien = tblNhanVien.MaNhanVien and tblCoVid.TrangThai ='F0'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetAllF1()
        {
            string sql = @"select tblCoVid.MaNhanVien, tblNhanVien.TenNhanVien,tblNhanVien.MaPhong, tblCoVid.NguonLay, tblCoVid.Ngay from tblCoVid,tblNhanVien where tblCoVid.MaNhanVien = tblNhanVien.MaNhanVien and tblCoVid.TrangThai ='F1'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LocF1(string NguonLay)
        {
            string sql = @"select tblCoVid.MaNhanVien, tblNhanVien.TenNhanVien,tblNhanVien.MaPhong,tblCoVid.NguonLay,tblCoVid.Ngay from tblCoVid,tblNhanVien where tblCoVid.MaNhanVien = tblNhanVien.MaNhanVien and tblCoVid.TrangThai ='F1' and tblCoVid.NguonLay like N'%" + NguonLay + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public bool XoaF1(string MaNhanVien)
        {
            string sql = "UPDATE tblCoVid SET TrangThai=@TrangThai, NguonLay=@NguonLay , Ngay=@Ngay, HinhThuc=@HinhThuc WHERE MaNhanVien= @MaNhanVien";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = MaNhanVien;
                cmd.Parameters.Add("@NguonLay", SqlDbType.NVarChar).Value = "";
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = "Bình Thường";
                cmd.Parameters.Add("@HinhThuc", SqlDbType.NVarChar).Value = "Bình Thường";
                cmd.Parameters.Add("@Ngay", SqlDbType.NVarChar).Value = "";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool XoaF0(string MaNhanVien)
        {

            string sql = "UPDATE tblCoVid SET TrangThai=@TrangThai, NguonLay=@NguonLay , Ngay=@Ngay, HinhThuc=@HinhThuc WHERE MaNhanVien= @MaNhanVien";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = MaNhanVien;
                cmd.Parameters.Add("@NguonLay", SqlDbType.NVarChar).Value = "";
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = "Bình Thường";
                cmd.Parameters.Add("@HinhThuc", SqlDbType.NVarChar).Value = "Bình Thường";
                cmd.Parameters.Add("@Ngay", SqlDbType.NVarChar).Value = "";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            
            string sql1 = @"update tblCoVid Set  Ngay=N'', HinhThuc=N'Bình Thường', TrangThai=N'Bình Thường',NguonLay=N'' where NguonLay=@NguonLay and TrangThai=N'F1'";
            try
            {
                cmd = new SqlCommand(sql1, con);
                con.Open();
                cmd.Parameters.Add("@NguonLay", SqlDbType.NVarChar).Value = MaNhanVien;     
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable TimKiemTiemChung(string nv)
        {
            string sql = "select tblNhanVien.MaNhanVien, tblNhanVien.TenNhanVien, tblNhanVien.MaPhong, tblCoVid.SoMuiTiem, tblCoVid.TrangThai, tblCoVid.HinhThuc from tblNhanVien, tblCoVid where  tblNhanVien.MaNhanVien = tblCoVid.MaNhanVien and tblNhanVien.TenNhanVien like N'%" + nv + "%' ";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable BoLocMuiTiem(string somui)
        {
            string sql = "select tblNhanVien.MaNhanVien, tblNhanVien.TenNhanVien, tblNhanVien.MaPhong, tblCoVid.SoMuiTiem, tblCoVid.TrangThai, tblCoVid.HinhThuc from tblNhanVien, tblCoVid where  tblNhanVien.MaNhanVien = tblCoVid.MaNhanVien and tblCoVid.SoMuiTiem like N'%" + somui + "%' ";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
