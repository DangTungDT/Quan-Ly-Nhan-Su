using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLChamCong
    {
        DALChamCong chamCongDAL = new DALChamCong();
        public IQueryable thongTinChamCong()
        {
            return chamCongDAL.getThongTinChamCong();
        }
        public IQueryable timChamCong(DTOChamCong dtoData)
        {
            return chamCongDAL.timChamCong(dtoData);
        }
        public bool themChamCong(DTOChamCong dtoData)
        {
            return chamCongDAL.themChamCong(dtoData);
        }
        public bool xoaChamCong(DTOChamCong dtoData)
        {
            return chamCongDAL.xoaChamCong(dtoData);
        }
        public bool xoaAllChamCong(DTOChamCong dtoData)
        {
            return chamCongDAL.xoaAllChamCong(dtoData);
        }
        public bool suaChamCong(DTOChamCong dtoData)
        {
            return chamCongDAL.suaChamCong(dtoData);
        }
    }
}
