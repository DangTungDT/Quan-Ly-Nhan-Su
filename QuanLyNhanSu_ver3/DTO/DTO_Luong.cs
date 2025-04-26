using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class DTO_Luong
    {
        int id;
        decimal soTienLuong;

        public DTO_Luong(decimal soTienLuong)
        {
            this.SoTienLuong = soTienLuong;
        }

        public int Id { get => id; set => id = value; }
        public decimal SoTienLuong { get => soTienLuong; set => soTienLuong = value; }
    }
}
