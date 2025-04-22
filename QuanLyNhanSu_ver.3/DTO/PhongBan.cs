using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongBan
    {
        private int id;
        private string tenPhongBan;
        private string moTa;

        public int Id { get => id; set => id = value; }
        public string TenPhongBan { get => tenPhongBan; set => tenPhongBan = value; }
        public string MoTa { get => moTa; set => moTa = value; }
    }
}
