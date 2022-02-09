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
    public partial class PhongBan : Form
    {
        NhanVienBLL bllNV;
        PhongBanBLL bllPB;
        public PhongBan()
        {
            InitializeComponent();
            bllNV = new NhanVienBLL();
            bllPB = new PhongBanBLL();
        }
        public void ShowAllPhongBan()
        {
            DataTable dt2 = bllPB.GetAllPhongBan();
            dtgvPhongBan.DataSource = dt2;
        }

        private void PhongBan_Load(object sender, EventArgs e)
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

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            tblPhongBan pb = new tblPhongBan();
            string MaPhong = txtMaPhong.Text;
            string TenPhong = txtTenPhong.Text;
            string Email = txtEmail.Text;
            string SDT = txtSDT.Text;
            string TrangThai = txtTrangThai.Text;
            if (bllPB.SuaPhongBan(MaPhong, TenPhong, TrangThai, SDT, Email))
            {
                ShowAllPhongBan();
                MessageBox.Show("Cập Nhật Thành Công!");
            }
            else
            {
                MessageBox.Show("Có Lỗi Hệ Thống, Thử Lại Sau!");
            }
        }
    }
}
