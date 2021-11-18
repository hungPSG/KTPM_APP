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
    public partial class MainQL : Form
    {
        public MainQL()
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

        private void changeForm(object formija)                   // hàm chuyển form 
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

        private void button3_Click(object sender, EventArgs e)
        {
            changeForm(new HomeQL());
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

        private void buttonNV_Click(object sender, EventArgs e)
        {
            changeForm(new NhanVienQL());
        }
    }
}
