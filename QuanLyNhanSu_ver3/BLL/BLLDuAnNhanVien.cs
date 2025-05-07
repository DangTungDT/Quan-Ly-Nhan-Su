using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLDuAnNhanVien
    {
        DALDuAnNhanVien duAnNVDAL = new DALDuAnNhanVien();
        public IQueryable ThongTinDuAnNV()
        {
            return duAnNVDAL.getThongTinDuAn_NhanVien();
        }

        public IQueryable timDuAnNV(DTODuAnNhanVien duAnNV)
        {
            return duAnNVDAL.timDuAn_NVTheoID(duAnNV);
        }

        public bool them(DTODuAnNhanVien duAnNV)
        {
            return duAnNVDAL.themDuAn_NV(duAnNV);
        }

        public bool xoa(DTODuAnNhanVien duAnNV)
        {
            return duAnNVDAL.xoaDuAn_NV(duAnNV);
        }

        public bool sua(DTODuAnNhanVien duAnNV)
        {
            return duAnNVDAL.suaDuAn_NV(duAnNV);
        }
    }
}
