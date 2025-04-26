using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KhenThuong_NhanVien
    {
        DAL_KhenThuong_NhanVien dal = new DAL_KhenThuong_NhanVien();

        public IQueryable LoadKhenThuong()
        {
            return dal.LoadKhenThuong();
        }
        public IQueryable LoadNhanVien()
        {
            return dal.LoadNhanVien();
        }
        public IQueryable LoadNhanVienKhenThuong(int idKhenThuong)
        {
            return dal.LoadNhanVienKhenThuong(idKhenThuong);
        }

        public bool AddKhenThuongNhanVien(string idNV, int idKT)
        {
            return dal.AddKhenThuongNhanVien(idNV, idKT);
        }

        public bool DeleteNhanVienNhanKhenThuong(string idNV, int idKT)
        {
            return dal.DeleteNhanVienNhanKhenThuong(idNV, idKT);
        }
    }
}
