using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTONhanVienChamCong
    {
        string id;
        string tenNhanVien;

        public DTONhanVienChamCong(string id, string tenNhanVien)
        {
            this.Id = id;
            this.TenNhanVien = tenNhanVien;
        }

        public DTONhanVienChamCong()
        {
        }

        public string Id { get => id; set => id = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
    }
}
