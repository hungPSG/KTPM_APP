using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPM_APP
{
    class NhanVienBLL
    {
        NhanVienDAL dalNV;
        public NhanVienBLL()
        {
            dalNV = new NhanVienDAL();
        }

        public DataTable getAllNhanVien()
        {
            return dalNV.getAllNhanVien();
        }

        public bool ThemNhanVien(tblNhanVien NV)
        {
            return dalNV.ThemNhanVien(NV);
        }

        public bool SuaNhanVien(tblNhanVien NV)
        {
            return dalNV.SuaNhanVien(NV);
        }
        public bool XoaNhanVien(tblNhanVien NV)
        {
            return dalNV.XoaNhanVien(NV);
        }

        public DataTable TimKiemNhanVien(string NV) {
            return dalNV.TimkiemNhanVien(NV);
        }

    }
}
