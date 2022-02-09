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
    public partial class TiemChung : Form
    {
        NhanVienBLL bllNV;
        CoVidBLL bllCV;
        public TiemChung()
        {
            InitializeComponent();
            bllNV = new NhanVienBLL();
            bllCV = new CoVidBLL();
        }
        public void ShowAllCoVid()
        {
            DataTable dt2 = bllCV.GetAllCoVid();
            dtgvCoVid.DataSource = dt2;
        }


        private void Covid_Load(object sender, EventArgs e)
        {
            ShowAllCoVid();
        }



        private void dtgvCoVid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            else
            {
                DataGridViewRow row = dtgvCoVid.Rows[e.RowIndex];
                txtMaNhanVien.Text = row.Cells[0].Value.ToString();
                txtTenNhanVien.Text = row.Cells[1].Value.ToString();
                txtMaPhong.Text = row.Cells[2].Value.ToString();
                txtSoMuiTiem.Text = row.Cells[3].Value.ToString();
                txtTrangThai.Text = row.Cells[4].Value.ToString();
                txtHinhThuc.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            string MaNhanVien = txtMaNhanVien.Text;
            int SoMuiTiem = int.Parse(txtSoMuiTiem.Text);
            string TrangThai = txtTrangThai.Text;
            string HinhThuc = txtHinhThuc.Text;
           if(bllCV.SuaCoVid(MaNhanVien, SoMuiTiem, TrangThai, HinhThuc)) {
                MessageBox.Show("Cập Nhật Thành Công");
                ShowAllCoVid();
            }
            else
            {
                MessageBox.Show("Lỗi Hệ Thống");
            }
        }

        private void txtTimKiemF0_TextChanged(object sender, EventArgs e)
        {
            string value = txtTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllNV.TimKiemNhanVien(value);
                dtgvCoVid.DataSource = dt;
            }
            else
            {
                ShowAllCoVid();
            }
        }
        string BoLoc;
        private void cbbLocF1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbLoc.Text == "Không")
            {
                ShowAllCoVid();
            }
            else
            {
                BoLoc = cbbLoc.Text;
                if (!string.IsNullOrEmpty(BoLoc))
                {
                    DataTable dt = bllCV.BoLocMuiTiem(BoLoc);
                    dtgvCoVid.DataSource = dt;
                }

                else
                {
                    ShowAllCoVid();
                }
            }
        }
    }
}
