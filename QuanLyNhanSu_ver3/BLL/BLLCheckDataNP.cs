using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCheckDataNP
    {
        public readonly DALconnectNP qlns;

        public BLLCheckDataNP()
        {
            qlns = new DALconnectNP();
        }

        //public async Task<List<DTONghiPhep>> NghiList() => await qlns.GetAllNPhep().ToListAsync();

        // Kiem tra du lieu tu d/s NghiPhep
        public List<DTONghiPhep> CheckGetAllNPhep()
        {
            try
            {
                if (qlns.GetAllNPhep().Any())
                {
                    return qlns.GetAllNPhep().ToList();
                }
                else
                {
                    throw new Exception("Không có dữ liệu nào trong d/s nghỉ phép !!!");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi lấy d/s nghỉ phép: " + ex.Message);
            }

        }

        // kiem tra du lieu them nghi phep
        public bool CheckAddNghiPhep(DTONghiPhep np)
        {
            try
            {
                var ktra = qlns.GetAllNV().FirstOrDefault(p => p.id == np.NhanVien);
                if (ktra != null && np != null)
                {
                    return qlns.AddNghiPhep(np);
                }
                else
                {
                    throw new Exception("Kiểm tra dữ liệu thêm nghỉ phép không hợp lệ !!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm nghỉ phép: " + ex.Message);
            }
        }

        // Kiem tra du lieu cap nhat nghi phep
        public bool CheckUpdateNghiPhep(DTONghiPhep np)
        {
            try
            {
                var ktra = qlns.GetAllNV().FirstOrDefault(p => p.id == np.NhanVien);
                if (ktra != null && np != null)
                {
                    return qlns.UpdateNghiPhep(np);
                }
                else
                {
                    throw new Exception("Kiểm tra dữ liệu cập nhật nghỉ phép không hợp lệ !!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật nghỉ phép: " + ex.Message);
            }
        }

        // Kiem tra du lieu xoa nghi phep
        public bool CheckDeleteNghiPhep(DTONghiPhep np)
        {
            try
            {
                if (np.ID > 0)
                {
                    return qlns.DeleteNghiPhep(np);
                }
                else
                {
                    throw new Exception("Kiểm tra ID nghỉ phép không hợp lệ !!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa nghỉ phép: " + ex.Message);
            }
        }
    }
}
