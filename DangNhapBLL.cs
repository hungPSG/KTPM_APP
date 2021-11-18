using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPM_APP
{
    class DangNhapBLL
    {
        DangNhapDAL dalTK;
        public DangNhapBLL()
        {
            dalTK = new DangNhapDAL();
        }

        public DataTable getAllTaiKhoan()
        {
            return dalTK.getAllTaiKhoan();
        }

        public bool ThemTaiKhoan(tblDangNhap tk)
        {
            return dalTK.ThemTaiKhoan(tk);
        }

        public bool SuaTaiKhoan(tblDangNhap tk)
        {
            return dalTK.SuaTaiKhoan(tk);
        }
        public bool XoaTaiKhoan(tblDangNhap tk)
        {
            return dalTK.XoaTaiKhoan(tk);
        }
    }
}
