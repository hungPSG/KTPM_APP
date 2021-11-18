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
    public partial class NhanVienQL : Form
    {

        NhanVienBLL bllNV;
        DangNhapBLL bllTK;
        public NhanVienQL()
        {
            InitializeComponent();
            bllNV = new NhanVienBLL();
            bllTK = new DangNhapBLL();
        }


        public void ShowAllNhanVien()
        {
            DataTable dt = bllNV.getAllNhanVien();
            dgvNhanVien.DataSource = dt;
        }

        private void NhanVienQL_Load(object sender, EventArgs e)
        {
            ShowAllNhanVien();
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMaNhanVien.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Mã Nhân Viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenNhanVien.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Tên Nhân Viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhanVien.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNamSinh.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Năm Sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNamSinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtQueQuan.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Quê Quán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQueQuan.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCCCD.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập CCCD.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCCD.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Số Điện Thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaNhanVien.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Mã Nhân Viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbbHocVan.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Học Vấn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbHocVan.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtChucVu.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Chức Vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChucVu.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbbHinhThuc.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Hình Thức.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbHinhThuc.Focus();
                return false;
            }
            return true;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                tblNhanVien nv = new tblNhanVien();                       
                nv.MaNhanVien = txtMaNhanVien.Text;
                nv.TenNhanVien = txtTenNhanVien.Text;
                nv.NamSinh = int.Parse(txtNamSinh.Text);
                nv.QueQuan = txtQueQuan.Text;
                nv.CCCD = txtCCCD.Text;
                nv.DienThoai = txtDienThoai.Text;
                nv.HinhThuc = cbbHinhThuc.Text;
                nv.HocVan = cbbHocVan.Text;
                nv.ChucVu = txtChucVu.Text;

              /*  if (bllNV.ThemNhanVien(nv))
                {
                    ShowAllNhanVien();
                    MessageBox.Show("Thêm Thành Công.");
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }*/

                tblDangNhap tk = new tblDangNhap(); // tao tai khoan moi
                tk.TaiKhoan = txtMaNhanVien.Text;
                tk.MatKhau = txtCCCD.Text;
                tk.Quyen = "0";
                if (bllTK.ThemTaiKhoan(tk) && bllNV.ThemNhanVien(nv)) {
                    ShowAllNhanVien();
                    MessageBox.Show("Thêm Thành Công.");
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        int ID;
      
        private void btLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtNamSinh.Text = "";
            txtQueQuan.Text = "";
            txtCCCD.Text = "";
            txtDienThoai.Text = "";
            cbbHinhThuc.Text = "";
            txtChucVu.Text = "";
            cbbHocVan.Text = "";
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                tblNhanVien nv = new tblNhanVien();
                nv.Id = ID;
                nv.MaNhanVien = txtMaNhanVien.Text;
                nv.TenNhanVien = txtTenNhanVien.Text;
                nv.NamSinh = int.Parse(txtNamSinh.Text);
                nv.QueQuan = txtQueQuan.Text;
                nv.CCCD = txtCCCD.Text;
                nv.DienThoai = txtDienThoai.Text;
                nv.HinhThuc = cbbHinhThuc.Text;
                nv.HocVan = cbbHocVan.Text;
                nv.ChucVu = txtChucVu.Text;

                tblDangNhap tk = new tblDangNhap();
                tk.TaiKhoan = txtMaNhanVien.Text;
                tk.MatKhau = txtCCCD.Text;
                tk.Quyen = "0";
                if (bllTK.SuaTaiKhoan(tk) && bllNV.SuaNhanVien(nv))
                {
                    ShowAllNhanVien();
                    MessageBox.Show("Sửa Thành Công.");
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
       
        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Xóa Không?","Cảnh Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                tblNhanVien nv = new tblNhanVien();
                nv.Id = ID;
                tblDangNhap tk = new tblDangNhap();
                tk.TaiKhoan = txtMaNhanVien.Text;
                if (bllNV.XoaNhanVien(nv) && bllTK.XoaTaiKhoan(tk))
                {
                    ShowAllNhanVien();
                    MessageBox.Show("Xóa Thành Công.");
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                ID = Int32.Parse(dgvNhanVien.Rows[index].Cells["Id"].Value.ToString());
                txtMaNhanVien.Text = dgvNhanVien.Rows[index].Cells["dataGridViewTextBoxColumn20"].Value.ToString();
                txtTenNhanVien.Text = dgvNhanVien.Rows[index].Cells["dataGridViewTextBoxColumn21"].Value.ToString();
                txtNamSinh.Text = dgvNhanVien.Rows[index].Cells["dataGridViewTextBoxColumn22"].Value.ToString();
                txtQueQuan.Text = dgvNhanVien.Rows[index].Cells["dataGridViewTextBoxColumn23"].Value.ToString();
                txtCCCD.Text = dgvNhanVien.Rows[index].Cells["dataGridViewTextBoxColumn24"].Value.ToString();
                txtDienThoai.Text = dgvNhanVien.Rows[index].Cells["dataGridViewTextBoxColumn25"].Value.ToString();
                cbbHinhThuc.Text = dgvNhanVien.Rows[index].Cells["dataGridViewTextBoxColumn28"].Value.ToString();
                txtChucVu.Text = dgvNhanVien.Rows[index].Cells["dataGridViewTextBoxColumn27"].Value.ToString();
                cbbHocVan.Text = dgvNhanVien.Rows[index].Cells["dataGridViewTextBoxColumn26"].Value.ToString();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string value = txtTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllNV.TimKiemNhanVien(value);
                dgvNhanVien.DataSource = dt;
            }
            else
            {
                ShowAllNhanVien();
            }
        }
    }
}
