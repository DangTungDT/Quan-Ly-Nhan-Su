using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOChamCong
    {
        public string IdChamCong { get; set; }
        public string IdNhanVien { get; set; }
        public DateTime NgayChamCong { get; set; }
        public TimeSpan GioVao { get; set; }
        public TimeSpan GioRa { get; set; }
        public string TrangThai { get; set; }

        public DTOChamCong() { }

        public DTOChamCong(string idChamCong, string idNhanVien, DateTime ngayChamCong, TimeSpan gioVao, TimeSpan gioRa, string trangThai)
        {
            IdChamCong = idChamCong;
            IdNhanVien = idNhanVien;
            NgayChamCong = ngayChamCong;
            GioVao = gioVao;
            GioRa = gioRa;
            TrangThai = trangThai;
        }
    }
}
