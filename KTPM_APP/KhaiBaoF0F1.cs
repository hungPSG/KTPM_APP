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
    public partial class KhaiBaoF0F1 : Form
    {
        CoVidBLL bllCV;
        public KhaiBaoF0F1(string MaNhanVien)
        {
            InitializeComponent();
            txtMaNhanVien.Text = MaNhanVien;
            bllCV = new CoVidBLL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TraCuuF0 xy = new TraCuuF0(txtMaNhanVien.Text);
            xy.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MaNhanVien = txtMaNhanVien.Text;
            string TrangThai = txtTrangThai.Text;
            string NguonLay = txtNguonLay.Text;
            string Ngay = txtNgayPhatHien.Text;
            string HinhThuc = txtHinhThuc.Text;
            if (TrangThai == "F0")
            {
                if (bllCV.ThemF0F1(MaNhanVien, TrangThai, NguonLay, Ngay, HinhThuc))
                {
                    MessageBox.Show("Thêm Thành Công");
                    this.Hide();
                    TraCuuF0 xy = new TraCuuF0(txtMaNhanVien.Text);
                    xy.Show();
                }
                else
                {
                    MessageBox.Show("Lỗi Hệ Thống");
                }
            }
            if (TrangThai == "F1")
            {
                if (bllCV.ThemF0F1(MaNhanVien, TrangThai, NguonLay, Ngay, HinhThuc))
                {
                    MessageBox.Show("Thêm Thành Công");
                    this.Hide();
                    TraCuuF0 xy = new TraCuuF0(txtMaNhanVien.Text);
                    xy.Show();
                }
                else
                {
                    MessageBox.Show("Lỗi Hệ Thống");
                }
            }
        }
    }
}
