using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Luong
    {
        DAL_Luong DAL_Luong = new DAL_Luong();

        public IQueryable LoadLuong()
        {
            return DAL_Luong.LoadLuong(); 
        }

        public bool AddLuong(DTO_Luong dto)
        {
            return DAL_Luong.AddLuong(dto);
        }

        public bool DeteleLuong(int id)
        {
            return DAL_Luong.DeteleLuong(id);
        }

        public bool EditLuong(DTO_Luong dto)
        {
            return DAL_Luong.EditLuong(dto);
        }
    }
}
