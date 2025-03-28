using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NghiPhep
    {
        public int id, idNhanVien;
        public string lyDoNghi, loaiNghi;
        public DateTime ngayBD, ngayKT;


        public int Id { get => id; set => id = value; }
        public int IdNhanVien { get => idNhanVien; }
        public string LyDoNghi { get => lyDoNghi; set => lyDoNghi = value; }
        public string LoaiNghi { get => loaiNghi; set => loaiNghi = value; }
        public DateTime NgayBD { get => ngayBD; set => ngayBD = DateTime.Now; } 
        public DateTime NgayKT { get => ngayKT; set => ngayKT = value; }
    }
}
