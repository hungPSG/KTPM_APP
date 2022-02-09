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
    public partial class NhanVien_QL : Form
    {
        NhanVienBLL bllNV;
        ChamCongBLL bllCC;
        CoVidBLL bllCV;
        DangNhapBLL bllDN;
        PhongBanBLL bllPB;

        public NhanVien_QL()
        {
            InitializeComponent();
            bllNV = new NhanVienBLL();
            bllCC = new ChamCongBLL();
            bllCV = new CoVidBLL();
            bllDN = new DangNhapBLL();
            bllPB = new PhongBanBLL();
        }
        public void ShowAllNhanVien()
        {
            DataTable dt1 = bllNV.getAllNhanVien();
            dtgvNhanVien.DataSource = dt1;
        }

        private void NhanVien_QL_Load(object sender, EventArgs e)
        {
            ShowAllNhanVien();
        }

        int ID;
        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index >= 0)
            {
                ID = Int32.Parse(dtgvNhanVien.Rows[index].Cells["Id"].Value.ToString());
                txtMaNhanVien.Text = dtgvNhanVien.Rows[index].Cells["MaNhanVien"].Value.ToString();
                txtTenNhanVien.Text = dtgvNhanVien.Rows[index].Cells["TenNhanVien"].Value.ToString();
                txtSDT.Text = dtgvNhanVien.Rows[index].Cells["SDT"].Value.ToString();
                txtNamSinh.Text = dtgvNhanVien.Rows[index].Cells["NamSinh"].Value.ToString();
                txtQueQuan.Text = dtgvNhanVien.Rows[index].Cells["QueQuan"].Value.ToString();
                txtCCCD.Text = dtgvNhanVien.Rows[index].Cells["CCCD"].Value.ToString();
                txtTrinhDo.Text = dtgvNhanVien.Rows[index].Cells["TrinhDo"].Value.ToString();
                txtChucVu.Text = dtgvNhanVien.Rows[index].Cells["ChucVu"].Value.ToString();
                txtPhong.Text = dtgvNhanVien.Rows[index].Cells["MaPhong"].Value.ToString();
            }
        }
        // Tìm Kiếm
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllNV.TimKiemNhanVien(value);
                dtgvNhanVien.DataSource = dt;
            }
            else
            {
                ShowAllNhanVien();
            }
        }
        // Thêm Nhân Viên
        int CheckThem()
        {
            if (txtCCCD.Text == "" || txtChucVu.Text == "" || txtMaNhanVien.Text == "" || txtNamSinh.Text == "" || txtPhong.Text == "" || txtQueQuan.Text == "" || txtSDT.Text == "" || txtTenNhanVien.Text == "" || txtTrinhDo.Text == "")
            {
                return 1; // Thông tin bị thiếu 
            }
            else
            {
                return 0; // thông tin đủ
            }
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            if (CheckThem() == 0)
            {
                tblNhanVien nv = new tblNhanVien();
                nv.MaNhanVien = txtMaNhanVien.Text;
                nv.TenNhanVien = txtTenNhanVien.Text;
                nv.NamSinh = txtNamSinh.Text;
                nv.QueQuan = txtQueQuan.Text;
                nv.ChucVu = txtChucVu.Text;
                nv.SDT = txtSDT.Text;
                nv.CCCD = txtCCCD.Text;
                nv.TrinhDo = txtTrinhDo.Text;
                nv.MaPhong = txtPhong.Text;
                if (!bllNV.TrungMaNhanVien(nv.MaNhanVien))
                {
                    if (bllNV.ThemNhanVien(nv) && bllCV.KhoiTaoCoVid(nv) && bllDN.KhoiTaoTaiKhoan(nv) && bllCC.KhoiTaoChamCong(nv)&&bllPB.ThemNhanVien(nv.MaPhong))
                    {

                        ShowAllNhanVien();
                        MessageBox.Show("Thêm Thành Công!");
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi hệ thống, thử lại sau!");
                    }
                }
                else
                {
                    MessageBox.Show("Mã Nhân Viên Đã Tồn Tại");
                }
            }
            if (CheckThem() == 1)
            {
                    MessageBox.Show("Thiếu Thông Tin");
            } 
        }
        // Sửa Nhân Viên
        int CheckSua()
        {
            if (txtCCCD.Text == "" || txtChucVu.Text == "" || txtMaNhanVien.Text == "" || txtNamSinh.Text == "" || txtPhong.Text == "" || txtQueQuan.Text == "" || txtSDT.Text == "" || txtTenNhanVien.Text == "" || txtTrinhDo.Text == "")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private void btSua_Click(object sender, EventArgs e)
        {
            if (CheckSua() == 0)
            {
                tblNhanVien nv = new tblNhanVien();
                nv.Id = ID;
                nv.MaNhanVien = txtMaNhanVien.Text;
                nv.TenNhanVien = txtTenNhanVien.Text;
                nv.NamSinh = txtNamSinh.Text;
                nv.QueQuan = txtQueQuan.Text;
                nv.ChucVu = txtChucVu.Text;
                nv.SDT = txtSDT.Text;
                nv.CCCD = txtCCCD.Text;
                nv.TrinhDo = txtTrinhDo.Text;
                nv.MaPhong = txtPhong.Text;
                if (bllNV.SuaNhanVien(nv) && bllDN.SuaTaiKhoanDN(nv))
                {
                    ShowAllNhanVien();
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
        // Xóa Nhân Viên

        int CheckXoa()
        {
            if (txtCCCD.Text == "" || txtChucVu.Text == "" || txtMaNhanVien.Text == "" || txtNamSinh.Text == "" || txtPhong.Text == "" || txtQueQuan.Text == "" || txtSDT.Text == "" || txtTenNhanVien.Text == "" || txtTrinhDo.Text == "")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
                if (CheckXoa() == 0)  {
                if (MessageBox.Show("Bạn Có Muốn Xóa Không?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)  {
                    tblNhanVien nv = new tblNhanVien();
                    nv.Id = ID;
                    nv.MaNhanVien = txtMaNhanVien.Text;
                    nv.TenNhanVien = txtTenNhanVien.Text;
                    nv.NamSinh = txtNamSinh.Text;
                    nv.QueQuan = txtQueQuan.Text;
                    nv.ChucVu = txtChucVu.Text;
                    nv.SDT = txtSDT.Text;
                    nv.CCCD = txtCCCD.Text;
                    nv.TrinhDo = txtTrinhDo.Text;
                    nv.MaPhong = txtPhong.Text;
                    if (bllCC.XoaChamCong(nv) && bllCV.XoaCoVid(nv) && bllDN.XoaTaiKhoan(nv) && bllNV.XoaNhanVien(nv)&&bllPB.XoaNhanVien(nv.MaPhong))
                    {
                        ShowAllNhanVien();
                        MessageBox.Show("Đã Xóa!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi Hệ Thống, Thử lại sau!");
                    }
                  }
                }
            
            if (CheckXoa() == 1)
            {
                MessageBox.Show("Đối Tượng Không Tồn Tại");
            }
        }

        private void btRefesh_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtCCCD.Text = "";
            txtChucVu.Text = "";
            txtNamSinh.Text = "";
            txtPhong.Text = "";
            txtQueQuan.Text = "";
            txtSDT.Text = "";
            txtTrinhDo.Text = "";
        }

    }
}
