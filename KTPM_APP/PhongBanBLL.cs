
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPM_APP
{
    class PhongBanBLL
    {
        PhongBanDAL dalPB;

        public PhongBanBLL()
        {
            dalPB = new PhongBanDAL();
        }
        public DataTable GetAllPhongBan()
        {
            return dalPB.GetAllPhongBan();
        }
        public bool ThemNhanVien(string MaPhong)
        {
            return dalPB.ThemNhanVien(MaPhong);
        }
        public bool XoaNhanVien(string MaPhong)
        {
            return dalPB.XoaNhanVien(MaPhong);
        }
        public bool SuaPhongBan(string MaPhong, string TenPhong, string TrangThai, string SDT, string Email)
        {
            return dalPB.SuaPhongBan(MaPhong, TenPhong, TrangThai, SDT,Email);
        }
        public string SoF0(string MaPhong)
        {
            return dalPB.SoF0(MaPhong);
        }
        public string SoF1(string MaPhong)
        {
            return dalPB.SoF1(MaPhong);
        }
    }
}
