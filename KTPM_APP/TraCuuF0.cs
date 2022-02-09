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
    public partial class TraCuuF0 : Form
    {
        CoVidBLL bllCV;
        public TraCuuF0(string MaNhanVien)
        {
            InitializeComponent();
             LabelMaNhanVien.Text = MaNhanVien;
            bllCV = new CoVidBLL();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            PannelNV xy = new PannelNV(LabelMaNhanVien.Text);
            xy.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Shut Down?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void ShowAllF0()
        {
            DataTable dt2 = bllCV.GetAllF0();
            dtgvF0.DataSource = dt2;
        }
        public void ShowAllF1()
        {
            DataTable dt2 = bllCV.GetAllF1();
            dtgvF1.DataSource = dt2;
        }
        public void LocF1(string NguonLay)
        {
            DataTable dt2 = bllCV.LocF1(NguonLay);
            dtgvF1.DataSource = dt2;
        }

        private void TraCuuF0_Load(object sender, EventArgs e)
        {

            ShowAllF0();
            ShowAllF1();
        }
        string MaNhanVienF0;
        private void dtgvF0_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            else
            {
                DataGridViewRow row = dtgvF0.Rows[e.RowIndex];
                MaNhanVienF0 = row.Cells[0].Value.ToString();
                LocF1(MaNhanVienF0);
            }
            if (cbbLocF1.Text == "Lọc Theo F0")
            {
                LocF1(MaNhanVienF0);
            }
            else
            {
                ShowAllF1();
            }
            if (cbbLocF1.Text == "Cộng Đồng")
            {
                cbbLocF1.Text = "Không";
                ShowAllF1();
            }
        }

        private void cbbLocF1_TextChanged(object sender, EventArgs e)
        {
            if (cbbLocF1.Text == "Không")
            {
                ShowAllF1();
            }
            if (cbbLocF1.Text == "Cộng Đồng")
            {
                MaNhanVienF0 = "Cộng Đồng";
                LocF1(MaNhanVienF0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhaiBaoF0F1 xy = new KhaiBaoF0F1(LabelMaNhanVien.Text);
            xy.Show();
        }
    }
}
