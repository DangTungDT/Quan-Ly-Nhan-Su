using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOHopDongLaoDong
    {
        public int Id { get; set; }
        public System.Nullable<System.DateTime> NgayKy { get; set; }
        public System.Nullable<System.DateTime> NgayBatDau { get; set; }
        public System.Nullable<System.DateTime> NgayKetThuc { get; set; }
        public string IdNhanVien { get; set; }
        public string MoTa { get; set; }

        public DTOHopDongLaoDong() { }

        public DTOHopDongLaoDong(DateTime ngayKy, DateTime ngayBatDau, DateTime ngayKetThuc, string idNhanVien, string moTa)
        {
            IdNhanVien = idNhanVien;
            NgayKy = ngayKy;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            MoTa = moTa;
        }
    }
}
