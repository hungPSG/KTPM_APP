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
    public partial class Profile : Form
    {
        NhanVienBLL nvBLL;
        SqlDataAdapter da;
        SqlCommand cmd;
        public Profile(string MaNhanVien)
        {
            InitializeComponent();
            LabelMaNhanVien.Text = MaNhanVien;
            nvBLL = new NhanVienBLL();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            PannelNV xy = new PannelNV(LabelMaNhanVien.Text);
            xy.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Shut Down?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void GetInformation(string MaNhanVien)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NDNDB0N\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True");
            string sql = @"select * from tblNhanVien where MaNhanVien=@MaNhanVien";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = MaNhanVien;
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtTenNhanVien.Text = dr[2].ToString();
                txtQueQuan.Text= dr[3].ToString();
                txtNamSinh.Text = dr[4].ToString();
                txtChucVu.Text = dr[5].ToString();
                txtSDT.Text = dr[6].ToString();
                txtCCCD.Text = dr[7].ToString();
                txtTrinhDo.Text = dr[8].ToString();
                txtMaPhong.Text = dr[9].ToString();
            }
            con.Close();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            GetInformation(LabelMaNhanVien.Text);
        }

        int CheckSua()
        {
            if (txtCCCD.Text == "" || txtChucVu.Text == "" || txtNamSinh.Text == "" || txtMaPhong.Text == "" || txtQueQuan.Text == "" || txtSDT.Text == "" || txtTenNhanVien.Text == "" || txtTrinhDo.Text == "")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckSua() == 0)
            {
                tblNhanVien nv = new tblNhanVien();
                
                nv.MaNhanVien = LabelMaNhanVien.Text;
                nv.TenNhanVien = txtTenNhanVien.Text;
                nv.NamSinh = txtNamSinh.Text;
                nv.QueQuan = txtQueQuan.Text;
                nv.ChucVu = txtChucVu.Text;
                nv.SDT = txtSDT.Text;
                nv.CCCD = txtCCCD.Text;
                nv.TrinhDo = txtTrinhDo.Text;
                nv.MaPhong = txtMaPhong.Text;
                if (nvBLL.SuaNhanVien(nv))
                {
                    GetInformation(LabelMaNhanVien.Text);
                    MessageBox.Show("Sửa Thành Công!");
                }
                else
                {
                    MessageBox.Show("Có Lỗi Hệ Thống, Thử Lại Sau!");
                }
            }
            if (CheckSua() == 1)
            {
                MessageBox.Show("Thiếu Thông Tin");
            }
        }
    }
}
