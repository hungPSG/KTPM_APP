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

namespace KTPM_APP
{
    public partial class Salary : Form
    {
        NhanVienBLL bllNV;
        SqlDataAdapter da;
        SqlCommand cmd;
        public Salary(string MaNhanVien)
        {
            InitializeComponent();
            LabelMaNhanVien.Text = MaNhanVien;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            PannelNV xy = new PannelNV(LabelMaNhanVien.Text);
            xy.Show();
        }
        private void GetInformation(string MaNhanVien)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NDNDB0N\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True");
            string sql = "select tblnhanvien.MaNhanVien, tblNhanVien.TenNhanVien, tblNhanVien.ChucVu,tblChamCong.SoNgayLamViec,tblChamCong.HSL,tblChamCong.TienUng,tblChamCong.TienThuong,tblChamCong.Tong, tblChamCong.TrangThai from tblNhanVien, tblChamCong where tblNhanVien.MaNhanVien = tblChamCong.MaNhanVien and tblChamCong.MaNhanVien =@MaNhanVien";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = MaNhanVien;
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtTenNhanVien.Text = dr[1].ToString();
                txtChucVu.Text = dr[2].ToString();
                txtSoNgayLam.Text = dr[3].ToString();
                txtHSL.Text = dr[4].ToString();
                txtTienUng.Text = dr[5].ToString();
                txtTienThuong.Text = dr[6].ToString();
                txtTong.Text = dr[7].ToString();
                txtTrangThai.Text = dr[8].ToString();
            }
            con.Close();
        }

        private void Salary_Load(object sender, EventArgs e)
        {
            GetInformation(LabelMaNhanVien.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Shut Down?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
