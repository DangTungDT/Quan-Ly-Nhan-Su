using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ChucVu
    {
        DALChucVu dal = new DALChucVu();

        public IQueryable LoadChucVu()
        {
           return dal.LoadChucVu();
        }

        public bool AddChucVu(DTO_ChucVu dto)
        {
            return dal.AddChucVu(dto);
        }

        public bool DeleteChucVu(string idChucVuDelete)
        {
            return dal.DeleteChucVu(idChucVuDelete);
        }

        public bool EditChucVu(DTO_ChucVu dto)
        {
            return dal.EditChucVu(dto);
        }
    }
}
