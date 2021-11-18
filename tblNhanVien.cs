using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPM_APP
{
    class tblNhanVien
    {
        public  int Id { set; get; }

        public string MaNhanVien { set; get; }

        public string TenNhanVien { set; get; }

        public int NamSinh { set; get; }

        public string QueQuan { set; get; }

        public string CCCD { set; get; }

        public string DienThoai { set; get; }

        public string HocVan { set; get; }

        public string ChucVu { set; get; }
        public string HinhThuc
        {
            set;get;
        }
    }
}
