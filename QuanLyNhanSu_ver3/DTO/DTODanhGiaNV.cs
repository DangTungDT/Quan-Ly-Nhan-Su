using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTODanhGiaNV
    {

        public DTODanhGiaNV()
        {

        }

        public DTODanhGiaNV(int id)
        {
            ID = id;
        }

        public DTODanhGiaNV(int diemSo, string iDNguoiDanhGia, string iDNhanVien, string nhanXet, DateTime ngayTao)
        {

            DiemSo = diemSo;
            IDNguoiDanhGia = iDNguoiDanhGia;
            IDNhanVien = iDNhanVien;
            NhanXet = nhanXet;
            NgayTao = ngayTao;
        }

        public DTODanhGiaNV(int iD, int diemSo, string iDNguoiDanhGia, string iDNhanVien, string nhanXet, DateTime ngayTao)
        {
            ID = iD;
            DiemSo = diemSo;
            IDNguoiDanhGia = iDNguoiDanhGia;
            IDNhanVien = iDNhanVien;
            NhanXet = nhanXet;
            NgayTao = ngayTao;
        }

        public int ID { get; set; }
        public int? DiemSo { get; set; }
        public string IDNguoiDanhGia { get; set; }
        public string IDNhanVien { get; set; }
        public string NhanXet { get; set; }
        public DateTime? NgayTao { get; set; }
    }
}
