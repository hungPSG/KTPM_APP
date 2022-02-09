using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPM_APP
{
    class ChamCongBLL
    {
        ChamCongDAL dalCC;
        public ChamCongBLL()
        {
            dalCC = new ChamCongDAL();
        }

        public DataTable GetAllChamCong()
        {
            return dalCC.GetAllChamCong();
        }
        public bool KhoiTaoChamCong(tblNhanVien nv)
        {
            return dalCC.KhoiTaoChamCong(nv);
        }
        public bool SuaChamCong(string MaNhanVien,int SoNgayLamViec, float HSL, float TienUng, float TienThuong,string TrangThai)
        {
            return dalCC.SuaChamCong(MaNhanVien, SoNgayLamViec,  HSL,  TienUng,  TienThuong,TrangThai);
        }
        public bool XoaChamCong(tblNhanVien cc)
        {
            return dalCC.XoaChamCong(cc);
        }
        public DataTable TimKiemNhanVien(string nv)
        {
            return dalCC.TimKiemNhanVien(nv);
        }
        public bool TinhTongLuong(string MaNhanVien,int SoNgayLamViec, float HSL, float TienThuong, float TienUng)
        {
            return dalCC.TinhTongLuong(MaNhanVien,SoNgayLamViec, HSL,  TienThuong,  TienUng);
        }
        public bool ThanhToanLuong(string MaNhanVien, string DaThanhToan)
        {
            return dalCC.ThanhToanLuong( MaNhanVien, DaThanhToan);
        }
        public DataTable BoLoc(string loc)
        {
            return dalCC.BoLoc(loc);
        }
        public bool LamMoiChamCong(int SoNgayLamViec, float TienUng, float TienThuong, float Tong, string TrangThai)
        {
            return dalCC.LamMoiChamCong( SoNgayLamViec, TienUng, TienThuong,Tong, TrangThai);
        }
    }
}
