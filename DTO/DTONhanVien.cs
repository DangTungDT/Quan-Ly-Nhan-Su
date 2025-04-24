using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTONhanVien
    {
        public string ID { get; set; }
        public string IDChucVu { get; set; }
        public int? IDLuong { get; set; }
        public string IDPhongBan { get; set; }
        public string TenNhanVien { get; set; }
        public string DiaChi { get; set; }
        public string Que { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Email { get; set; }

        public DTONhanVien()
        {

        }
        public DTONhanVien(string id)
        {
            ID = id;
        }
        public DTONhanVien(string id, string iDChucVu, int? iDLuong, string iDPhongBan, string tenNhanVien, string diaChi, string que, string gioiTinh, DateTime? ngaySinh, string email)
        {
            ID = id;
            IDChucVu = iDChucVu;
            IDLuong = iDLuong;
            IDPhongBan = iDPhongBan;
            TenNhanVien = tenNhanVien;
            DiaChi = diaChi;
            Que = que;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            Email = email;
        }
    }
}
