using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChucVu
    {
        string id, tenChucVu;

        public DTO_ChucVu(string id, string tenChucVu)
        {
            this.id = id;
            this.tenChucVu = tenChucVu;
        }

        public string Id { get => id; set => id = value; }
        public string TenChucVu { get => tenChucVu; set => tenChucVu = value; }
    }
}
