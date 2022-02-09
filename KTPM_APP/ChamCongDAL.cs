using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPM_APP
{
    class ChamCongDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public ChamCongDAL()
        {
            dc = new DataConnection();
        }
        public DataTable GetAllChamCong()
        {
            string sql = "select tblnhanvien.MaNhanVien, tblNhanVien.TenNhanVien, tblNhanVien.ChucVu,tblChamCong.SoNgayLamViec,tblChamCong.HSL,tblChamCong.TienUng,tblChamCong.TienThuong,tblChamCong.Tong, tblChamCong.TrangThai from tblNhanVien, tblChamCong where tblNhanVien.MaNhanVien = tblChamCong.MaNhanVien";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        string temp = "ML";
        public bool KhoiTaoChamCong(tblNhanVien nv)
        {
            string sql = "INSERT INTO tblChamCong(MaLuong, MaNhanVien, Thang, SoNgayLamViec, HSL,TrangThai,TienUng,TienThuong,Tong) VALUES(@MaLuong, @MaNhanVien, @Thang, @SoNgayLamViec, @HSL,@TrangThai,@TienUng,@TienThuong,@Tong)";
            SqlConnection con = dc.getConnect();
            temp = temp + nv.MaNhanVien;
            try
            {

                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaLuong", SqlDbType.NVarChar).Value = temp;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = nv.MaNhanVien;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@SoNgayLamViec", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@HSL", SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = "Chưa Cập Nhật";
                cmd.Parameters.Add("@TienUng", SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("@TienThuong", SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("@Tong", SqlDbType.Float).Value = 0;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool SuaChamCong(string MaNhanVien, int SoNgayLamViec, float HSL, float TienUng, float TienThuong, string TrangThai)
        {
            string sql = "UPDATE tblChamCong SET SoNgayLamViec=@SoNgayLamViec, HSL=@HSL, TienUng=@TienUng,TienThuong=@TienThuong,TrangThai=@TrangThai WHERE MaNhanVien= @MaNhanVien";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = MaNhanVien;
                cmd.Parameters.Add("@SoNgayLamViec", SqlDbType.Int).Value = SoNgayLamViec;
                cmd.Parameters.Add("@HSL", SqlDbType.Float).Value = HSL;
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = TrangThai;
                cmd.Parameters.Add("@TienUng", SqlDbType.Int).Value = TienUng;
                cmd.Parameters.Add("@TienThuong", SqlDbType.Int).Value = TienThuong;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool XoaChamCong(tblNhanVien cc)
        {
            string sql = "DELETE tblChamCong WHERE MaNhanVien=@MaNhanVien";

            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = cc.MaNhanVien;
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
            string sql = "select DISTINCT tblNhanVien.MaNhanVien, tblNhanVien.TenNhanVien, tblNhanVien.ChucVu,tblChamCong.SoNgayLamViec,tblChamCong.HSL,tblChamCong.TienUng,tblChamCong.TienThuong,tblChamCong.Tong, tblChamCong.TrangThai from tblNhanVien, tblChamCong  WHERE tblNhanVien.TenNhanVien like N'%" + nv + "%' AND tblChamCong.MaNhanVien =tblNhanVien.MaNhanVien ";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool TinhTongLuong(string MaNhanVien, int SoNgayLamViec, float HSL, float TienThuong, float TienUng)
        {
            string sql = "Update tblChamCong Set Tong=@Tong where MaNhanVien=@MaNhanVien";
            SqlConnection con = dc.getConnect();
            float Tong = SoNgayLamViec * HSL + TienThuong - TienUng;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = MaNhanVien;
                cmd.Parameters.Add("@Tong", SqlDbType.Float).Value = Tong;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool ThanhToanLuong(string MaNhanVien, string DaThanhToan)
        {
            string sql = "Update tblChamCong Set TrangThai=@TrangThai where MaNhanVien=@MaNhanVien";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = MaNhanVien;
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = DaThanhToan;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable BoLoc(string loc)
        {
            string sql = "select DISTINCT tblNhanVien.MaNhanVien, tblNhanVien.TenNhanVien, tblNhanVien.ChucVu,tblChamCong.SoNgayLamViec,tblChamCong.HSL,tblChamCong.TienUng,tblChamCong.TienThuong,tblChamCong.Tong, tblChamCong.TrangThai from tblNhanVien, tblChamCong  WHERE tblChamCong.TrangThai like N'%" + loc + "%' AND tblChamCong.MaNhanVien =tblNhanVien.MaNhanVien ";
            // string sql1 = "select DISTINCT tblNhanVien.MaNhanVien, tblNhanVien.TenNhanVien, tblNhanVien.ChucVu,tblChamCong.SoNgayLamViec,tblChamCong.HSL,tblChamCong.TienUng,tblChamCong.TienThuong,tblChamCong.Tong, tblChamCong.TrangThai from tblNhanVien, tblChamCong  WHERE tblChamCong.HSL =0 AND tblChamCong.MaNhanVien =tblNhanVien.MaNhanVien ";
            string sql2 = "select DISTINCT tblNhanVien.MaNhanVien, tblNhanVien.TenNhanVien, tblNhanVien.ChucVu,tblChamCong.SoNgayLamViec,tblChamCong.HSL,tblChamCong.TienUng,tblChamCong.TienThuong,tblChamCong.Tong, tblChamCong.TrangThai from tblNhanVien, tblChamCong  where tblChamCong.MaNhanVien =tblNhanVien.MaNhanVien ";
            if (loc == "Không")
            {
                SqlConnection con = dc.getConnect();
                da = new SqlDataAdapter(sql2, con);
                con.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }

            else
            {
                SqlConnection con = dc.getConnect();
                da = new SqlDataAdapter(sql, con);
                con.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }

        }
        public bool LamMoiChamCong( int SoNgayLamViec, float TienUng, float TienThuong, float Tong, string TrangThai)
        {
            string sql = "UPDATE tblChamCong SET SoNgayLamViec=@SoNgayLamViec, TienUng=@TienUng,TienThuong=@TienThuong,Tong=@Tong,TrangThai=@TrangThai";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                //cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = MaNhanVien;
                // cmd.Parameters.Add("@MaLuong", SqlDbType.NVarChar).Value = cc.MaLuong;
                //  cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = cc.Thang;
                cmd.Parameters.Add("@SoNgayLamViec", SqlDbType.Int).Value = SoNgayLamViec;
                //cmd.Parameters.Add("@HSL", SqlDbType.Float).Value = HSL;
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = TrangThai;
                cmd.Parameters.Add("@TienUng", SqlDbType.Float).Value = TienUng;
                cmd.Parameters.Add("@TienThuong", SqlDbType.Float).Value = TienThuong;
                 cmd.Parameters.Add("@Tong", SqlDbType.Float).Value = Tong;
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
