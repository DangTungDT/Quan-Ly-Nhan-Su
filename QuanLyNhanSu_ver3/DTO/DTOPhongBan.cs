using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOPhongBan
    {

        public string ID { get; set; }
        public string TenPhongBan { get; set; }
        public string MoTa { get; set; }

        public DTOPhongBan()
        {

        }

        public DTOPhongBan(string id)
        {
            ID = id;
        }

        public DTOPhongBan(string iD, string tenPhongBan, string moTa)
        {
            ID = iD;
            TenPhongBan = tenPhongBan;
            MoTa = moTa;
        }


    }
}
