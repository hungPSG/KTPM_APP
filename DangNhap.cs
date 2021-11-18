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
using System.Data.SqlClient;
namespace KTPM_APP
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if ( textBoxTK.Text == " Tài Khoản")
            {
                textBoxTK.Text = "";
                textBoxTK.ForeColor = Color.LightGray;
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBoxTK.Text == "")
            {
                textBoxTK.Text = " Tài Khoản";
                textBoxTK.ForeColor = Color.DimGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBoxMK.Text == " Mật Khẩu")
            {
                textBoxMK.Text = "";
                textBoxMK.ForeColor = Color.LightGray;
                textBoxMK.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBoxMK.Text == "")
            {
                textBoxMK.Text = " Mật Khẩu";
                textBoxMK.ForeColor = Color.DimGray;
                textBoxMK.UseSystemPasswordChar = false;
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        // hết phần giao diện


        // tạo kết nối 
        DataConnection abc= new DataConnection(); // khởi tạo giá trị của lớp DataConnection 
        
     
        private void button1_Click(object sender, EventArgs e)
        { 
            SqlConnection Conec = abc.getConnect(); // lấy kết nối
            try
            {
                Conec.Open();
                string tk = textBoxTK.Text;
                string mk = textBoxMK.Text;
               
                if (checkBoxQL.Checked)
                {
                        
                    int Quyen = 1;
                    string sql1 = "select *FROM tblDangNhap  WHERE TaiKhoan ='" + tk + "' and MatKhau ='" + mk + "' and Quyen ='" + Quyen + "'";
                    SqlCommand cmd = new SqlCommand(sql1, Conec);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        this.Hide();
                        MainQL xyz = new MainQL();
                        xyz.Show();
                    }
                    else
                    {
                        MessageBox.Show("thông tin không chính xác");
                    }
                }
                if (checkBoxNV.Checked)
                {
                    int Quyen1 = 0;
                    string sql1 = "select *FROM tblDangNhap  WHERE TaiKhoan ='" + tk + "' and MatKhau ='" + mk + "' and Quyen ='" + Quyen1 + "'";
                    SqlCommand cmd = new SqlCommand(sql1, Conec);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        this.Hide();
                        MainNV xy = new MainNV();
                        xy.Show();
                    }
                    else
                    {
                        MessageBox.Show("thông tin không chính xác");
                    }

                }
                Conec.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("có lỗi hệ thống");
            }
            if (textBoxTK.Text == " Tài Khoản" || textBoxMK.Text == " Mật Khẩu")
            {
                MessageBox.Show("vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                if (!checkBoxNV.Checked && !checkBoxQL.Checked)
                {
                    MessageBox.Show("bạn chưa chọn quyền truy cập");
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
