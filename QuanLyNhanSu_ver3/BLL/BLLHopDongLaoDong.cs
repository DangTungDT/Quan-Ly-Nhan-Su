using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLHopDongLaoDong
    {
        DALHopDongLaoDong hopDongDLL = new DALHopDongLaoDong();
        public IQueryable thongTinHopDong()
        {
            return hopDongDLL.getThongTinHopDong();
        }
        public IQueryable timHopDong(DTOHopDongLaoDong objHD)
        {
            return hopDongDLL.timHopDong(objHD);
        }
        public int themHopDong(DTOHopDongLaoDong objHD)
        {
            return hopDongDLL.themHopDong(objHD);
        }
        public bool suaHopDong(DTOHopDongLaoDong objHD)
        {
            return hopDongDLL.suaHopDong(objHD);
        }
        public bool xoaHopDong(DTOHopDongLaoDong objHD)
        {
            return hopDongDLL.xoaHopDong(objHD);
        }
    }
}
