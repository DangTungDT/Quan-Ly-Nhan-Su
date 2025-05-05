using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        // Kiem tra du lieu trong trong Form
        public bool CheckEmptyControl(Control.ControlCollection controls, ErrorProvider error)
        {
            bool ktra = true;
            error.Clear();

            foreach (var item in controls)
            {
                if (item is TextBox text && string.IsNullOrWhiteSpace(text.Text))
                {

                    error.SetError(text, $"Empty {text.Name.Substring(3)} !!!");
                    ktra = false;
                }
            }

            return ktra;
        }

    }
}
