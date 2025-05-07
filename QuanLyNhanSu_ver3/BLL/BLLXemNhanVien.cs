using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLXemNhanVien
    {
        DALXemNhanVien nhanVienDAL = new DALXemNhanVien();
        public IQueryable timNhanVien(string strSearch)
        {
            return nhanVienDAL.timNhanVien(strSearch);
        }
        public IQueryable ThongTinNhanVien()
        {
            return nhanVienDAL.getThongTinNhanVien();
        }
    }
}
