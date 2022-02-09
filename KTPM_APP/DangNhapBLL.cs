using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPM_APP
{
    class DangNhapBLL
    {
        DangNhapDAL dalDN;
        public DangNhapBLL()
        {
            dalDN = new DangNhapDAL();
        }
        public bool KhoiTaoTaiKhoan(tblNhanVien nv)
        {
            return dalDN.KhoiTaoTaiKhoan(nv);
        }
        public bool SuaTaiKhoanDN(tblNhanVien nv)
        {
            return dalDN.SuaTaiKhoanDN(nv);
        }
        public bool XoaTaiKhoan(tblNhanVien nv)
        {
            return dalDN.XoaTaiKhoan(nv);
        }
    }
}
