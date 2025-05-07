using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLTaiKhoan
    {
        DALTaiKhoan taiKhoanDAL = new DALTaiKhoan();
        public IQueryable ThongTinTaiKhoan()
        {
            return taiKhoanDAL.getThongTinTaiKhoan();
        }

        public IQueryable getThongTinTaiKhoan()
        {
            return taiKhoanDAL.getThongTinTaiKhoan();
        }
        public IQueryable timTaiKhoan(DTOTaiKhoan taiKhoan)
        {
            return taiKhoanDAL.timTaiKhoanTheoID(taiKhoan);
        }

        public int them(DTOTaiKhoan taiKhoan)
        {
            return taiKhoanDAL.themTaiKhoan(taiKhoan);
        }

        public bool xoa(DTOTaiKhoan taiKhoan)
        {
            return taiKhoanDAL.xoaTaiKhoan(taiKhoan);
        }

        public bool sua(DTOTaiKhoan taiKhoan)
        {
            return taiKhoanDAL.suaTaiKhoan(taiKhoan);
        }

        public int themTaiKhoan(DTOTaiKhoan objTK)
        {
            return taiKhoanDAL.themTaiKhoan(objTK);
        }
    }
}
