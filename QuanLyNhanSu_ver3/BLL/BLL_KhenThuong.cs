using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KhenThuong
    {
        DAL_KhenThuong dal = new DAL_KhenThuong();

        //Method
        public IQueryable LoadKhenThuong()
        {
            return dal.LoadKhenThuong();
        }

        public bool XoaKhenThuong(DTO_KhenThuong dto)
        {
            return dal.XoaKhenThuong(dto);
        }
        public bool ThemKhenThuong(DTO_KhenThuong dto)
        {
            return dal.ThemKhenThuong(dto);
        }
    }
}
