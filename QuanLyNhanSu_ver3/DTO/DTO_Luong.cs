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
        float soTienLuong;

        public DTO_Luong(int id, float soTienLuong)
        {
            this.Id = id;
            this.SoTienLuong = soTienLuong;
        }

        public int Id { get => id; set => id = value; }
        public float SoTienLuong { get => soTienLuong; set => soTienLuong = value; }
    }
}
