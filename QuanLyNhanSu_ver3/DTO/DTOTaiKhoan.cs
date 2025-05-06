using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOTaiKhoan
    {
        public DTOTaiKhoan()
        {

        }

        public DTOTaiKhoan(int iD, string iDNhanVien, string taiKhoan, string matKhau)
        {
            ID = iD;
            IDNhanVien = iDNhanVien;
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
        }

        public int ID { get; set; }
        public string IDNhanVien { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
    }
}
