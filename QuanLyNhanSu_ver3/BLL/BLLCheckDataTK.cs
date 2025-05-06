using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCheckDataTK
    {
        public readonly DALConnectTK tk;

        public BLLCheckDataTK() => tk = new DALConnectTK();

        // Kiem tra du lieu d/s trong trong tai khoan
        public List<DTOTaiKhoan> CheckGetAllTKhoan()
        {
            var list = tk.getAllTKhoan().ToList();
            try
            {
                if (list.Any() && list != null)
                {
                    return list;
                }

                throw new Exception("Lỗi tài khoản null / không có dữ liệu trong d/s");

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra d/s tài khoản: " + ex.Message, ex);
            }
        }

    }
}
