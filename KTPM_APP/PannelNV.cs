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
    public partial class PannelNV : Form
    {
        public PannelNV(string MaNhanVien)
        {
            InitializeComponent();
            labelMaNhanVien.Text = MaNhanVien;
            //Gán dữ liệu nhận được vào Label để thể hiện
        }

        private void btDangSuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đăng suất và trở về đăng nhập?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                DangNhap dn = new DangNhap();
                dn.Show();
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Shut Down?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile pf = new Profile(labelMaNhanVien.Text);
            pf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Salary pf = new Salary(labelMaNhanVien.Text);
            pf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PhongBanNV ada = new PhongBanNV(labelMaNhanVien.Text);
            ada.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TraCuuF0 ada = new TraCuuF0(labelMaNhanVien.Text);
            ada.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
