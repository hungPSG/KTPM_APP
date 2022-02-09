using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTPM_APP
{
    public partial class PhongBanNV : Form
    {
        PhongBanBLL bllPB;
        public PhongBanNV(string MaNhanVien)
        {
            InitializeComponent();
            LabelMaNhanVien.Text = MaNhanVien;
            bllPB = new PhongBanBLL();
        }
        public void ShowAllPhongBan()
        {
            DataTable dt2 = bllPB.GetAllPhongBan();
            dtgvPhongBan.DataSource = dt2;
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

        private void PhongBanNV_Load(object sender, EventArgs e)
        {
            ShowAllPhongBan();
        }

        private void dtgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {

                txtMaPhong.Text = dtgvPhongBan.Rows[index].Cells["MaPhong"].Value.ToString();
                txtTenPhong.Text = dtgvPhongBan.Rows[index].Cells["TenPhong"].Value.ToString();
                txtEmail.Text = dtgvPhongBan.Rows[index].Cells["Email"].Value.ToString();
                txtSDT.Text = dtgvPhongBan.Rows[index].Cells["SDT"].Value.ToString();
                txtSoNhanVien.Text = dtgvPhongBan.Rows[index].Cells["SoNhanVien"].Value.ToString();
                txtTrangThai.Text = dtgvPhongBan.Rows[index].Cells["TrangThai"].Value.ToString();
                txtSoF0.Text = bllPB.SoF0(txtMaPhong.Text);
                txtSoF1.Text = bllPB.SoF1(txtMaPhong.Text);
            }
        }
    }
}
