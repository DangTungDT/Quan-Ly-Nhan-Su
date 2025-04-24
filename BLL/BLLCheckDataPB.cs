using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BLLCheckDataPB
    {
        public readonly DALConnectPB qlns;
        public BLLCheckDataPB() => qlns = new DALConnectPB();

        public List<DTOPhongBan> CheckGetAllPBan()
        {
            var list = qlns.GetAllPBan().ToList();
            try
            {
                if (list.Any() && list != null)
                {
                    return list;
                }

                throw new Exception("Lỗi phòng ban null / không có dữ liệu trong d/s");

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra d/s phòng ban: " + ex.Message, ex);
            }
        }

        // Kiem tra du lieu them phong ban
        public bool CheckAddPBan(DTOPhongBan pb)
        {
            try
            {
                if (qlns.GetAllPBan().Any() && pb != null)
                {
                    return qlns.AddPBan(pb);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm phòng ban: " + ex.Message, ex);
            }
        }

        // Kiem tra du lieu cap nhat phong ban
        public bool CheckUpdatePBan(DTOPhongBan pb)
        {
            try
            {
                if (qlns.GetAllPBan().Any() && pb != null)
                {
                    return qlns.UpdatePBan(pb);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật phòng ban: " + ex.Message, ex);
            }
        }

        // Kiem tra du lieu xoa phong ban
        public bool CheckDeletePBan(DTOPhongBan pb)
        {
            try
            {
                if (qlns.GetAllPBan().Any() && pb != null)
                {
                    return qlns.DeletePBan(pb);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa phòng ban: " + ex.Message, ex);
            }
        }
    }
}
