using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPM_APP
{
    class CoVidBLL
    {
        CoVidDAL dalCV;

        public CoVidBLL()
        {
            dalCV = new CoVidDAL();
        }

        public bool KhoiTaoCoVid(tblNhanVien nv)
        {
            return dalCV.KhoiTaoCoVid(nv);
        }

        public bool SuaCoVid(string MaNhanVien, int SoMuiTiem, string TrangThai, string HinhThuc)
        {
            return dalCV.SuaCoVid(MaNhanVien,SoMuiTiem,TrangThai,HinhThuc);
        }
        public bool XoaCoVid(tblNhanVien nv)
        {
            return dalCV.XoaCoVid(nv);
        }
        public DataTable GetAllCoVid()
        {
            return dalCV.GetAllCoVid();
        }
        public bool ThemF0F1(string MaNhanVien, string TrangThai, string NguonLay, string Ngay, string HinhThuc)
        {
            return dalCV.ThemF0F1(MaNhanVien, TrangThai, NguonLay, Ngay, HinhThuc);
        }
        public DataTable GetAllF0()
        {
            return dalCV.GetAllF0();
        }
        public DataTable GetAllF1()
        {
            return dalCV.GetAllF1();
        }
        public DataTable LocF1(string NguonLay)
        {
            return dalCV.LocF1(NguonLay);
        }
        public bool XoaF1(string MaNhanVien)
        {
            return dalCV.XoaF1(MaNhanVien);
        }
        public bool XoaF0(string MaNhanVien)
        {
            return dalCV.XoaF0(MaNhanVien);
        }
        public DataTable TimKiemTiemChung(string nv)
        {
            return dalCV.TimKiemTiemChung(nv);
        }
        public DataTable BoLocMuiTiem(string somui)
        {
            return dalCV.BoLocMuiTiem(somui);
        }
    }
}
