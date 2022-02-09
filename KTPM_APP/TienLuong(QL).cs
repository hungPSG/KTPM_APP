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
    public partial class TienLuong_QL_ : Form
    {
        NhanVienBLL bllNV;
        ChamCongBLL bllCC;
        public TienLuong_QL_()
        {
            InitializeComponent();
            bllNV = new NhanVienBLL();
            bllCC = new ChamCongBLL();
        }
        public void ShowAllChamCong()
        {
            DataTable dt2 = bllCC.GetAllChamCong();
            dtgvChamCong.DataSource = dt2;
        }

        private void TienLuong_QL__Load(object sender, EventArgs e)
        {
            ShowAllChamCong();
        }

        private void dtgvChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            
            else
            {
                DataGridViewRow row = dtgvChamCong.Rows[e.RowIndex];
                txtMaNhanVien.Text = row.Cells[0].Value.ToString();
                txtTenNhanVien.Text = row.Cells[1].Value.ToString();
                txtChucVu.Text = row.Cells[2].Value.ToString();
                txtSoNgayLamViec.Text = row.Cells[3].Value.ToString();
                txtHSL.Text = row.Cells[4].Value.ToString();
                txtTienUng.Text = row.Cells[5].Value.ToString();
                txtTienThuong.Text = row.Cells[6].Value.ToString();
                txtTong.Text = row.Cells[7].Value.ToString();
                txtTrangThai.Text = row.Cells[8].Value.ToString();
            }
        }
        //Tìm Kiếm
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string value = txtTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllCC.TimKiemNhanVien(value);
                dtgvChamCong.DataSource = dt;
            }
            else
            {
                ShowAllChamCong();
            }
        }

        // Cập Nhật
        string Ma;
        string TT = "Đã Cập Nhật";
        int CheckData()
        {
            if (txtMaNhanVien.Text == "")
            {
                return 1;
            }
            if (txtSoNgayLamViec.Text=="0" || txtHSL.Text == "0")
            {
                return 2;
            }
            if(txtTrangThai.Text=="Đã Thanh Toán")
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
        private void btCapNhat_Click(object sender, EventArgs e)
        {
            Ma = txtMaNhanVien.Text;
            if (CheckData()==0)
            {
                int SoNgayLamViec = int.Parse(txtSoNgayLamViec.Text);
                float HSL = float.Parse(txtHSL.Text);
                float TienThuong = float.Parse(txtTienThuong.Text);
                float TienUng = float.Parse(txtTienUng.Text);
                float Tong = SoNgayLamViec * HSL + TienThuong - TienUng;
                if (bllCC.SuaChamCong(Ma,SoNgayLamViec, HSL, TienUng, TienThuong,TT)&&bllCC.TinhTongLuong(Ma, SoNgayLamViec, HSL, TienThuong, TienUng))
                {
                    ShowAllChamCong();
                    txtTong.Text = Tong.ToString();
                    txtTrangThai.Text = TT;
                    MessageBox.Show("Cập Nhật Thành Công");
                }
                else
                {
                    MessageBox.Show("Lỗi Hệ Thống");
                }
            }
            if (CheckData() == 1)
            {
                MessageBox.Show("Chưa Chọn Đối Tượng.");
            }
            if (CheckData() == 2)
            {
                MessageBox.Show("Thiếu Thông Tin.");
            }
            if (CheckData() == 3)
            {
                MessageBox.Show("Đã Thanh Toán.");
            }

        }

        // Thanh Toán
        int CheckThanhToan()
        {
            if (txtMaNhanVien.Text == "")
            {
                return 1;
            }
            if (txtTrangThai.Text=="Đã Thanh Toán")
            {
                return 2;
            }
            if (txtTrangThai.Text=="Chưa Cập Nhật")
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }
        string DaThanhToan = "Đã Thanh Toán";
        private void btThanhToan_Click(object sender, EventArgs e)
        {
           
            if (CheckThanhToan() == 1)
            {
                MessageBox.Show("Chưa Chọn Đối Tượng Thanh Toán");
            }
            if (CheckThanhToan() == 2)
            {
                MessageBox.Show("Đã Thanh Toán");
            }
            if (CheckThanhToan() == 3)
            {
                MessageBox.Show("Cập Nhật Thông Tin Trước Khi Thanh Toán");
            }
            if(CheckThanhToan()==4)
            {
                Ma = txtMaNhanVien.Text;
                if (bllCC.ThanhToanLuong(Ma, DaThanhToan))
                {
                    ShowAllChamCong();
                    txtTrangThai.Text = DaThanhToan;
                    MessageBox.Show("Thanh Toán Thành Công");
                }
                else
                {
                    MessageBox.Show("Lỗi Hệ Thống, Thử Lại Sau!");
                }
            }
        }

        // Bộ Lọc
        string BoLoc;
        private void cbbLoc_SelectedValueChanged(object sender, EventArgs e)
        {
            BoLoc = cbbLoc.Text;
            if (!string.IsNullOrEmpty(BoLoc))
            {
                DataTable dt = bllCC.BoLoc(BoLoc);
                dtgvChamCong.DataSource = dt;
            }
            
            else
            {
                ShowAllChamCong();
            }
        }

        //refresh
        private void btRefresh_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = "";
            txtChucVu.Text = "";
            txtHSL.Text = "";
            txtSoNgayLamViec.Text = "";
            txtTenNhanVien.Text = "";
            txtTienThuong.Text = "";
            txtTienUng.Text = "";
            txtTrangThai.Text = "";
            txtTong.Text = "";
            txtTimKiem.Text = "";
            cbbLoc.Text = "Không";
            ShowAllChamCong();
        }


        private void btLamMoi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tạo Mới Dữ Liệu Lương,Có Thể Còn Những Khoản Chưa Thanh Toán?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int SoNgayLamViec = 0;
                float TienUng = 0;
                float TienThuong = 0;
                float Tong = 0;
                string TrangThai = "Chưa Cập Nhật";
                if (bllCC.LamMoiChamCong(SoNgayLamViec, TienUng, TienThuong, Tong, TrangThai))
                {
                    ShowAllChamCong();
                    MessageBox.Show("Đã Tạo Mới");
                }
                else
                {
                    MessageBox.Show("Lỗi Hệ Thống, Thử Lại Sau");
                }
            }
        }
    }

    }
