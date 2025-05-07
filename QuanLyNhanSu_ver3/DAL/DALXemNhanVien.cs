using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALXemNhanVien
    {
        //Kết Nối Với DaTa = DataLinQ
        PersonnelManagementDataContext db = new PersonnelManagementDataContext();

        //Tìm Tai khoản
        public IQueryable timNhanVien(string strSearch)
        {
            // Tìm Dự án cần tìm theo id
            IQueryable tim = from i in db.NhanViens
                             where i.id.Contains(strSearch) || i.TenNhanVien.Contains(strSearch)
                             || i.DiaChi.Contains(strSearch) || i.Que.Contains(strSearch) || i.Email.Contains(strSearch)
                             select i;
            return tim;
        }
        //Lấy thông tin nhân viên
        public IQueryable getThongTinNhanVien()
        {
            IQueryable TTNV = from nv in db.NhanViens
                              select nv;
            return TTNV;
        }
    }
}
