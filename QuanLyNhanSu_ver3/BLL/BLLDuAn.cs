using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLDuAn
    {
        DALDuAn duAnDAL = new DALDuAn();
        public IQueryable ThongTinDuAn()
        {
            return duAnDAL.getThongTinDuAn();
        }

        public IQueryable timDuAn(DTODuAn duAn)
        {
            return duAnDAL.timDuAnTheoID(duAn);
        }

        public bool them(DTODuAn duAn)
        {
            return duAnDAL.themDuAn(duAn);
        }

        public bool xoa(DTODuAn duAn)
        {
            return duAnDAL.xoaDuAn(duAn);
        }

        public bool sua(DTODuAn duAn)
        {
            return duAnDAL.suaDuAn(duAn);
        }
    }
}
