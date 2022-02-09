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
    public partial class QuanLyF0 : Form
    {
        NhanVienBLL bllNV;
        CoVidBLL bllCV;
        PhongBanBLL bllPb;
        public QuanLyF0()
        {
            InitializeComponent();
            bllNV = new NhanVienBLL();
            bllCV = new CoVidBLL();
            bllPb = new PhongBanBLL();
        }

        private void btThemF0_Click(object sender, EventArgs e)
        {
            
            ThemF0F1 tem = new ThemF0F1();
            tem.Show();
        }

        public void ShowAllF0()
        {
            DataTable dt2 = bllCV.GetAllF0();
            dtgvF0.DataSource = dt2;
        }
        public void ShowAllF1()
        {
            DataTable dt2 = bllCV.GetAllF1();
            dtgvF1.DataSource = dt2;
        }
        public void LocF1(string NguonLay)
        {
            DataTable dt2 = bllCV.LocF1(NguonLay);
            dtgvF1.DataSource = dt2;
        }
        private void QuanLyF0_Load(object sender, EventArgs e)
        {
            ShowAllF0();
            ShowAllF1();
        }

        private void btThemF1_Click(object sender, EventArgs e)
        {
            
            ThemF0F1 tem = new ThemF0F1();
            tem.Show();
            
        }

        string MaNhanVienF1;
        private void dtgvF1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1) return;
            else
            {
                DataGridViewRow row = dtgvF1.Rows[e.RowIndex];
                MaNhanVienF1 = row.Cells[0].Value.ToString();
            }
        }

        string MaNhanVienF0;
        private void dtgvF0_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            else
            {
                    DataGridViewRow row = dtgvF0.Rows[e.RowIndex];
                    MaNhanVienF0 = row.Cells[0].Value.ToString();
                LocF1(MaNhanVienF0);
            }
            if (cbbLocF1.Text == "Lọc Theo F0")
            {
                LocF1(MaNhanVienF0);
            }
            else
            {
                ShowAllF1();
            }
            if (cbbLocF1.Text =="Cộng Đồng")
            {
                cbbLocF1.Text = "Không";
                ShowAllF1();
            }
        }

        private void btXoaF0_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Xóa Không?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bllCV.XoaF0(MaNhanVienF0))
                {
                    MessageBox.Show("Đã Xóa");
                    ShowAllF0();
                    ShowAllF1();
                }
                else
                {
                    MessageBox.Show("Có Lỗi, Kiểm Tra Lại Thao Tác");
                }
            }
        }

        private void btXoaF1_Click(object sender, EventArgs e)
        {
            if (bllCV.XoaF1(MaNhanVienF1))
            {
                MessageBox.Show("Đã Xóa");
                ShowAllF1();
            }
            else
            {
                MessageBox.Show("Có Lỗi, Kiểm Tra Lại Thao Tác");
            }
        }

        private void cbbLocF1_TextChanged(object sender, EventArgs e)
        {
            if (cbbLocF1.Text == "Không")
            {
                ShowAllF1();
            }
            if (cbbLocF1.Text=="Cộng Đồng")
            {
                MaNhanVienF0 = "Cộng Đồng";
                LocF1(MaNhanVienF0);
            }
        }
    }
}
