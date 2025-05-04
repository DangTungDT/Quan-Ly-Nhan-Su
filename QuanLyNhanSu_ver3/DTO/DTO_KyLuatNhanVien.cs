using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KyLuatNhanVien
    {
        int idKyLuat;
        string idNhanVien;
        DateTime ngayKyLuat;

        public DTO_KyLuatNhanVien(int idKyLuat, string idNhanVien, DateTime ngayKyLuat)
        {
            this.idKyLuat = idKyLuat;
            this.idNhanVien = idNhanVien;
            this.ngayKyLuat = ngayKyLuat;
        }

        public int IdKyLuat { get => idKyLuat; set => idKyLuat = value; }
        public string IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public DateTime NgayKyLuat { get => ngayKyLuat; set => ngayKyLuat = value; }
    }
}
