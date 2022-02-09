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

        public bool ThemNhanVien(tblNhanVien nv)
        {
            return dalNV.ThemNhanVien(nv);
        }

        public bool SuaNhanVien(tblNhanVien nv)
        {
            return dalNV.SuaNhanVien(nv);
        }

        public bool XoaNhanVien(tblNhanVien nv)
        {
            return dalNV.XoaNhanVien(nv);
        }

        public DataTable TimKiemNhanVien(string nv)
        {
            return dalNV.TimKiemNhanVien(nv);
        }
        public bool TrungMaNhanVien(string MaNhanVien)
        {
            return dalNV.TrungMaNhanVien(MaNhanVien);
        }
    }
}
