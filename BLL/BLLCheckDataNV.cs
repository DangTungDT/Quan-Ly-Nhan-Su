using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace BLL
{
    public class BLLCheckDataNV
    {
        public readonly DALConnectNV qlns;

        public BLLCheckDataNV()
        {
            qlns = new DALConnectNV();
        }

        // Kiem tra du lieu trong trong Form
        public bool CheckEmptyXontrol(Control.ControlCollection controls, ErrorProvider error)
        {
            bool ktra = true;
            error.Clear();

            foreach (var item in controls)
            {
                if (item is TextBox text && string.IsNullOrWhiteSpace(text.Text))
                {
                    if (text.Name == "txtTim")
                    {
                        continue;
                    }

                    error.SetError(text, $"Empty {text.Name.Substring(3)} !!!");
                    ktra = false;
                }

                if (item is ComboBox combo && string.IsNullOrWhiteSpace(combo.Text))
                {
                    error.SetError(combo, $"Empty {combo.Name.Substring(2)} !!!");
                    ktra = false;
                }
            }

            return ktra;
        }

        // Kiem tra du lieu tu d/s NV
        public List<DTONhanVien> CheckListNVien()
        {
            var list = qlns.getAllNVien().ToList();
            if (list.Any() && list != null)
            {
                try
                {
                    foreach (var item in list)
                    {
                        if (string.IsNullOrEmpty(item.GioiTinh) || item.GioiTinh != "Nam" && item.GioiTinh != "Nu")
                        {
                            item.GioiTinh = "Cần thêm giới tính";
                        }

                        if (string.IsNullOrEmpty(item.Email) || !item.Email.Contains("@gmail.com"))
                        {
                            item.Email = "cần thêm gmail";
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi kiểm tra d/s nhân viên: " + ex.Message, ex);
                }
            }
            else
            {
                throw new Exception("Danh sách nhân viên rỗng hoặc null");
            }

            return list;
        }

        public IEnumerable<ChucVu> CheckListCVu() => qlns.getAllCVu();
        public IEnumerable<PhongBan> CheckListPBan() => qlns.getAllPBan();
        public IEnumerable<Luong> CheckListLuong() => qlns.getAllLuong();

        // Kiem tra du lieu them NV
        public bool CheckAddNVien(DTONhanVien nv)
        {
            if (nv == null) return false;
            else
            {
                if (!qlns.getAllNVien().Any()) return false;
                else
                {
                    try
                    {
                        return qlns.AddNVien(nv);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi thêm nhân viên: " + ex.Message, ex);
                    }
                }
            }
        }

        // Kiem tra du lieu cap nhat NV
        public bool CheckUpdateNVien(DTONhanVien nv)
        {
            if (nv == null) return false;
            else
            {
                if (!qlns.getAllNVien().Any()) return false;
                else
                {
                    try
                    {
                        return qlns.UpdateNVien(nv);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi cập nhật nhân viên: " + ex.Message, ex);
                    }
                }
            }
        }

        // Kiem tra du lieu xoa NV
        public bool CheckDeleteNVien(DTONhanVien nv)
        {
            if (nv == null) return false;
            else
            {
                if (!qlns.getAllNVien().Any()) return false;
                else
                {
                    try
                    {
                        return qlns.DeleteNVien(nv);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi xóa nhân viên: " + ex.Message, ex);
                    }
                }
            }
        }

    }
}
