using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTONghiPhep
    {
        public DTONghiPhep()
        {

        }

        public DTONghiPhep(int id)
        {
            ID = id;
        }

        public DTONghiPhep(string nhanVien, string lyDoNghi, string loaiNghiPhep, DateTime? ngayBD, DateTime? ngayKT)
        {
            NhanVien = nhanVien;
            LyDoNghi = lyDoNghi;
            LoaiNghiPhep = loaiNghiPhep;
            NgayBD = ngayBD;
            NgayKT = ngayKT;
        }

        public DTONghiPhep(int id, string nhanVien, string lyDoNghi, string loaiNghiPhep, DateTime? ngayBD, DateTime? ngayKT)
        {
            ID = id;
            NhanVien = nhanVien;
            LyDoNghi = lyDoNghi;
            LoaiNghiPhep = loaiNghiPhep;
            NgayBD = ngayBD;
            NgayKT = ngayKT;
        }

        public DTONghiPhep(string nhanVien, string lyDoNghi, string loaiNghiPhep, DateTime? ngayBD, DateTime? ngayKT, string trangThai)
        {
            NhanVien = nhanVien;
            LyDoNghi = lyDoNghi;
            LoaiNghiPhep = loaiNghiPhep;
            NgayBD = ngayBD;
            NgayKT = ngayKT;
            TrangThai = trangThai;
        }

        public DTONghiPhep(int id, string nhanVien, string lyDoNghi, string loaiNghiPhep, DateTime? ngayBD, DateTime? ngayKT, string trangThai)
        {
            ID = id;
            NhanVien = nhanVien;
            LyDoNghi = lyDoNghi;
            LoaiNghiPhep = loaiNghiPhep;
            NgayBD = ngayBD;
            NgayKT = ngayKT;
            TrangThai = trangThai;
        }

        public int ID { get; set; }
        public string TrangThai { get; set; }

        public string NhanVien { get; set; }
        public string LyDoNghi { get; set; }
        public string LoaiNghiPhep { get; set; }

        public DateTime? NgayBD { get; set; }
        public DateTime? NgayKT { get; set; }


    }
}
