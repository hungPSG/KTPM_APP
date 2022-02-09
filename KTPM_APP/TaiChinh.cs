using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;

namespace KTPM_APP
{
    public partial class TaiChinh : Form
    {
        DataConnection dc;

        public TaiChinh()
        {
            InitializeComponent();
        }

        private void TaiChinh_Load(object sender, EventArgs e)
        {
            TongNhanVien();
            string a=   NhanVienDaThanhToan();
            string f = TongNhanVien();
            string d = NhanVienChuaCapNhat();
            string b= TongTienDaThanhToan();
            
            string c= TongTienDuKienThanhToan();
            float ffloat = float.Parse(f);
            float afloat = float.Parse(a);
            float dfloat = float.Parse(d);
          //  float bfloat = float.Parse(b);
            float cfloat = float.Parse(c);
            float gfloat = ffloat - dfloat - afloat;
            if (afloat == 0)
            {
                b = "0";
            }
            float bfloat = float.Parse(b);
            if (afloat == 0 && ffloat == 0 && dfloat == 0)
            {
                chartSoLuong.Series["Số Lượng"].Points.AddXY("Chưa Cập Nhật",1);

                chartTienLuong.Series["Đã Thanh Toán"].Points.AddXY("Đã Thanh Toán", 1);
                chartTienLuong.Series["Dự Kiến"].Points.AddXY("Dự Kiến", 1);
            }
           
            
            else
            {
                chartSoLuong.Series["Số Lượng"].Points.AddXY("Đã Thanh Toán", afloat);
                chartSoLuong.Series["Số Lượng"].Points.AddXY("Đã Cập Nhật", gfloat);
                chartSoLuong.Series["Số Lượng"].Points.AddXY("Chưa Cập Nhật", dfloat);

                chartTienLuong.Series["Đã Thanh Toán"].Points.AddXY("Đã Thanh Toán", bfloat);
                chartTienLuong.Series["Dự Kiến"].Points.AddXY("Dự Kiến", cfloat);
            }
        }

        string Tong;
        string sonhanviendathanhtoan;
        private string TongNhanVien()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NDNDB0N\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True");
            string sql = "select count(MaNhanVien) from tblNhanVien";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow  dr in dt.Rows)
            {
                Tong = dr[0].ToString();
            }
            con.Close();
            return Tong;
        }
        private string NhanVienDaThanhToan()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NDNDB0N\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True");
            string sql = "select count (MaNhanVien) from tblChamCong where TrangThai like N'Đã Thanh Toán'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                sonhanviendathanhtoan = dr[0].ToString();
            }
            con.Close();
            return sonhanviendathanhtoan;
        }
        string NhanVienChuaCapNhat1;
        private string NhanVienChuaCapNhat()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NDNDB0N\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True");
            string sql = "select count (MaNhanVien) from tblChamCong where TrangThai like N'Chưa Cập Nhật'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                NhanVienChuaCapNhat1 = dr[0].ToString();
            }
            con.Close();
            return NhanVienChuaCapNhat1;
        }

        string TienDaThanhToan;
        private string TongTienDaThanhToan()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NDNDB0N\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True");
            string sql = "select Sum (Tong) from tblChamCong Where TrangThai like N'Đã Thanh Toán'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                TienDaThanhToan = dr[0].ToString();
            }
            con.Close();
            return TienDaThanhToan;
        }

        string TienDuKien;
        private string TongTienDuKienThanhToan()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NDNDB0N\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True");
            string sql = "select Sum (Tong) from tblChamCong";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                TienDuKien = dr[0].ToString();
            }
            con.Close();
            return TienDuKien;
        }

        
    }
}
