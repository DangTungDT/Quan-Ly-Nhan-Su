using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOChamCongNhanVien
    {
        int id;
        DateTime ngayChamCong;
        string idNhanVien;

        public DTOChamCongNhanVien(DateTime ngayChamCong, string idNhanVien)
        {
            this.NgayChamCong = ngayChamCong;
            this.IdNhanVien = idNhanVien;
        }

        public DateTime NgayChamCong { get => ngayChamCong; set => ngayChamCong = value; }
        public string IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public int Id { get => id; set => id = value; }
    }
}
