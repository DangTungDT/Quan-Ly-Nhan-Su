using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLChamCongNhanVien
    {
        //Biến toàn cục
        DALChamCongNhanVien dal = new DALChamCongNhanVien();

        public DTONhanVienChamCong LoadNhanVienByID(string id)
        {
            return dal.LoadNhanVienByID(id);
        }

        public int AddChamCong(DTOChamCongNhanVien dto)
        {
            if (dto == null) return -1; //Dữ liệu null, return -1 để nhận biết trường hợp
            if (CheckVauleChamCong(dto.IdNhanVien, dto.NgayChamCong) == true)
            {
                //đã có chấm công vào ngày đó, nên sẽ return 1 để nhận biết trường hợp.
                return 1;
            }
            else
            {
                if(dal.AddChamCong(dto))
                {
                    return 0; //Thực hiện thành công, return 0 để nhận biết trường hợp
                }
                else
                {
                    return -2; //Sảy ra lỗi trong quá trình truy xuất, return -2 để nhận biết trường hợp
                }
            }
        }

        // Hàm kiểm tra dữ liệu đã chấm công từ trước hay chưa
        public bool CheckVauleChamCong(string idNhanVien, DateTime ngayChamCong)
        {
            if (dal.LoadChamCongNow(idNhanVien, ngayChamCong) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
