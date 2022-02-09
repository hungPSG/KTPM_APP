using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace KTPM_APP
{
    public partial class PanelQL : Form
    {
        public PanelQL()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pictureSize_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 250) {
                panelMenu.Width = 70   ;    
            }
            else
            {
                panelMenu.Width = 250;
            }
        }
        public void changeForm(object formija)                   // hàm chuyển form 
        {
            if (this.panelConten.Controls.Count > 0)
                this.panelConten.Controls.RemoveAt(0);
            Form fh = formija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelConten.Controls.Add(fh);
            this.panelConten.Tag = fh;
            fh.Show();
        }

      
        private void panelConten_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

       // hết phần thiết kế



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đăng suất và trở về đăng nhập?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                DangNhap dn = new DangNhap();
                dn.Show();
            }
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Shut Down?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        Color nen = Color.FromArgb(0, 115, 230);
        private void buttonNV_Click(object sender, EventArgs e)
        {
            //changeForm(new NhanVienQL());
            changeForm(new NhanVien_QL());
            buttonNV.BackColor = Color.White;
            btTiemChung.BackColor = Color.FromArgb(0, 115, 230);
            buttonLuong.BackColor = Color.FromArgb(0, 115, 230);
            buttonCorona.BackColor= Color.FromArgb(0, 115, 230);
            buttonHome.BackColor= Color.FromArgb(0, 115, 230);
            btPhongBan.BackColor= Color.FromArgb(0, 115, 230);
            buttonTaiChinh.BackColor= Color.FromArgb(0, 115, 230);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // changeForm(new HomeQL());
        }

        private void buttonLuong_Click(object sender, EventArgs e)
        {
            changeForm(new TienLuong_QL_());
            buttonLuong.BackColor = Color.White;
            btTiemChung.BackColor = Color.FromArgb(0, 115, 230);
            buttonNV.BackColor=Color.FromArgb(0, 115, 230);
            buttonCorona.BackColor = Color.FromArgb(0, 115, 230);
            buttonHome.BackColor = Color.FromArgb(0, 115, 230);
            btPhongBan.BackColor = Color.FromArgb(0, 115, 230);
            buttonTaiChinh.BackColor = Color.FromArgb(0, 115, 230);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
            changeForm(new Slogan());
            btTiemChung.BackColor = Color.FromArgb(0, 115, 230);
            buttonLuong.BackColor = Color.FromArgb(0, 115, 230);
            buttonNV.BackColor = Color.FromArgb(0, 115, 230);
            buttonCorona.BackColor = Color.FromArgb(0, 115, 230);
            buttonHome.BackColor = Color.FromArgb(0, 115, 230);
            btPhongBan.BackColor = Color.FromArgb(0, 115, 230);
            buttonTaiChinh.BackColor = Color.FromArgb(0, 115, 230);
        }

        private void PanelQL_Load(object sender, EventArgs e)
        {
            pictureBox3_Click(null, e);
        }

        private void buttonTaiChinh_Click(object sender, EventArgs e)
        {
            changeForm(new TaiChinh());
            btTiemChung.BackColor = Color.FromArgb(0, 115, 230);
            buttonLuong.BackColor = Color.FromArgb(0, 115, 230);
            buttonNV.BackColor = Color.FromArgb(0, 115, 230);
            buttonCorona.BackColor = Color.FromArgb(0, 115, 230);
            buttonHome.BackColor = Color.FromArgb(0, 115, 230);
            btPhongBan.BackColor = Color.FromArgb(0, 115, 230);
            buttonTaiChinh.BackColor = Color.White;
        }

        private void buttonCorona_Click(object sender, EventArgs e)
        {
            changeForm(new QuanLyF0());
            btTiemChung.BackColor = Color.FromArgb(0, 115, 230);
            buttonLuong.BackColor = Color.FromArgb(0, 115, 230);
            buttonNV.BackColor = Color.FromArgb(0, 115, 230);
            buttonCorona.BackColor = Color.White;
            buttonHome.BackColor = Color.FromArgb(0, 115, 230);
            btPhongBan.BackColor = Color.FromArgb(0, 115, 230);
            buttonTaiChinh.BackColor = Color.FromArgb(0, 115, 230);
        }

        private void btPhongBan_Click(object sender, EventArgs e)
        {
            changeForm(new PhongBan());
            buttonLuong.BackColor = Color.FromArgb(0, 115, 230);
            buttonNV.BackColor = Color.FromArgb(0, 115, 230);
            buttonCorona.BackColor = Color.FromArgb(0, 115, 230);
            buttonHome.BackColor = Color.FromArgb(0, 115, 230);
            btPhongBan.BackColor = Color.White;
            buttonTaiChinh.BackColor = Color.FromArgb(0, 115, 230);
            btTiemChung.BackColor = Color.FromArgb(0, 115, 230);
        }

        public void changeFormThemFoF1()
        {
            changeForm(new ThemF0F1());
        }

        private void btTiemChung_Click(object sender, EventArgs e)
        {
            changeForm(new TiemChung());
            buttonLuong.BackColor = Color.FromArgb(0, 115, 230);
            buttonNV.BackColor = Color.FromArgb(0, 115, 230);
            buttonCorona.BackColor = Color.FromArgb(0, 115, 230);
            buttonHome.BackColor = Color.FromArgb(0, 115, 230);
            btPhongBan.BackColor = Color.FromArgb(0, 115, 230);
            buttonTaiChinh.BackColor = Color.FromArgb(0, 115, 230);
            btTiemChung.BackColor = Color.White;
        }
    }
}
