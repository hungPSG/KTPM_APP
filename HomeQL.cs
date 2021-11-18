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
    public partial class HomeQL : Form
    {
        public HomeQL()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e) // hàm hiện ngày giờ
        {
            gio.Text = DateTime.Now.ToLongTimeString();
            ngaythang.Text = DateTime.Now.ToString("dddd MMMM yyy");
        }


    }
}
