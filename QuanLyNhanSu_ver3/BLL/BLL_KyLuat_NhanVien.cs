using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KyLuat_NhanVien
    {
        DAL_KyLuatNhanVien dal = new DAL_KyLuatNhanVien();

        public IQueryable LoadNhanVien()
        {
            return dal.LoadNhanVien();
        }

        public IQueryable LoadKyLuat()
        {
            return dal.LoadKyLuat();
        }

        public IQueryable LoadNhanVienKyLuat(int idKyLuat)
        {
            return dal.LoadNhanVienKyLuat(idKyLuat);
        }

        public bool AddKyLuatNhanVien(DTO_KyLuatNhanVien dto)
        {
            return dal.AddKyLuatNhanVien(dto);
        }

        public bool DeleteKyLuatNhanVien(DTO_KyLuatNhanVien dto)
        {
            return dal.DeleteKyLuatNhanVien(dto);
        }
    }
}
