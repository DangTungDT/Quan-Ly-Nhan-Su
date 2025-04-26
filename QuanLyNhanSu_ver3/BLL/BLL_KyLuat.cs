using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KyLuat
    {
        DAL_KyLuat dal = new DAL_KyLuat();

        public IQueryable LoadKyLuat()
        {
            return dal.LoadKyLuat();
        }

        public bool AddKyLuat(DTO_KyLuat dto)
        {
            return dal.AddKyLuat(dto);
        }

        public bool DeleteKyLuat(int idKyLuat)
        {
            return dal.DeleteKyLuat(idKyLuat);
        }

        public bool EditKyLuat(DTO_KyLuat dto)
        {
            return dal.EditKyLuat(dto);
        }
    }
}
