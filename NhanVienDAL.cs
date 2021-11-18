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
            // B1: Tạo câu lệnh SQL để lấy toàn bộ tài khoản 
            string sql = "SELECT * FROM tblNhanVien";
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

        public bool ThemNhanVien(tblNhanVien NV)
        {
            string sql = "INSERT INTO tblNhanVien(MaNhanVien, TenNhanVien, NamSinh, QueQuan, CCCD, DienThoai, HocVan, ChucVu, HinhThuc) VALUES(@MaNhanVien,@TenNhanVien,@NamSinh,@QueQuan,@CCCD,@DienThoai,@HocVan,@ChucVu,@HinhThuc)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = NV.MaNhanVien;
                cmd.Parameters.Add("@TenNhanVien", SqlDbType.NVarChar).Value = NV.TenNhanVien;
                cmd.Parameters.Add("@NamSinh", SqlDbType.Int).Value = NV.NamSinh;
                cmd.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = NV.QueQuan;
                cmd.Parameters.Add("@CCCD", SqlDbType.NVarChar).Value = NV.CCCD;
                cmd.Parameters.Add("@DienThoai", SqlDbType.NVarChar).Value = NV.DienThoai;
                cmd.Parameters.Add("@HocVan", SqlDbType.NVarChar).Value = NV.HocVan;
                cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = NV.ChucVu;
                cmd.Parameters.Add("@HinhThuc", SqlDbType.NVarChar).Value = NV.HinhThuc;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool SuaNhanVien(tblNhanVien NV)
        {
            string sql = "UPDATE tblNhanVien SET MaNhanVien = @MaNhanVien, TenNhanVien= @TenNhanVien, NamSinh= @NamSinh, QueQuan = @QueQuan, CCCD = @CCCD, DienThoai = @DienThoai , HocVan=@HocVan,ChucVu=@ChucVu,HinhThuc=@HinhThuc WHERE Id= @Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = NV.Id;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = NV.MaNhanVien;
                cmd.Parameters.Add("@TenNhanVien", SqlDbType.NVarChar).Value = NV.TenNhanVien;
                cmd.Parameters.Add("@NamSinh", SqlDbType.Int).Value = NV.NamSinh;
                cmd.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = NV.QueQuan;
                cmd.Parameters.Add("@CCCD", SqlDbType.NVarChar).Value = NV.CCCD;
                cmd.Parameters.Add("@DienThoai", SqlDbType.NVarChar).Value = NV.DienThoai;
                cmd.Parameters.Add("@HocVan", SqlDbType.NVarChar).Value = NV.HocVan;
                cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = NV.ChucVu;
                cmd.Parameters.Add("@HinhThuc", SqlDbType.NVarChar).Value = NV.HinhThuc;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool XoaNhanVien(tblNhanVien NV)
        {
            string sql = "DELETE tblNhanVien WHERE Id =@Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = NV.Id;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable TimkiemNhanVien (string NV)
        {
            string sql = "SELECT * FROM tblNhanVien Where TenNhanVien like N'%" + NV + "%'";
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

    }
}
