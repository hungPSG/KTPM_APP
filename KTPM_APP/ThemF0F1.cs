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
    public partial class ThemF0F1 : Form
    {
        NhanVienBLL bllNV;
        CoVidBLL bllCV;
        PhongBanBLL bllPB;
        public ThemF0F1()
        {
            InitializeComponent();
            bllNV = new NhanVienBLL();
            bllCV = new CoVidBLL();
            bllPB = new PhongBanBLL();
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MaNhanVien=txtMaNhanVien.Text;
            string TrangThai=txtTrangThai.Text;
            string NguonLay=txtNguonLay.Text;
            string Ngay=txtNgayPhatHien.Text;
            string HinhThuc=txtHinhThuc.Text;
            if (TrangThai == "F0")
            {
                if (bllCV.ThemF0F1(MaNhanVien, TrangThai, NguonLay, Ngay, HinhThuc))
                {
                    MessageBox.Show("Thêm Thành Công");
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
                }
                else
                {
                    MessageBox.Show("Lỗi Hệ Thống");
                }
            }
            else
            {
                MessageBox.Show("Trạng Thái Không Hợp Lệ");

            }
        }
    }
}
