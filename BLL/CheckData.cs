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
using System.Xml;


namespace BLL
{
    public class CheckData
    {
        public readonly ConnectQLNS qlns;

        public CheckData()
        {
            qlns = new ConnectQLNS();
        }

        // Kiem tra du lieu tu d/s NV
        public List<FieldNhanVien> CheckListNVien()
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
        public bool CheckAddNVien(FieldNhanVien nv)
        {
            if (nv == null) return false;
            else
            {
                if (!qlns.getAllNVien().Any()) return false;
                else
                {
                    try
                    {
                        qlns.AddNVien(nv);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi thêm nhân viên: " + ex.Message, ex);
                    }
                }
            }
        }

        // Kiem tra du lieu cap nhat NV
        public bool CheckUpdateNVien(FieldNhanVien nv)
        {
            if (nv == null) return false;
            else
            {
                if (!qlns.getAllNVien().Any()) return false;
                else
                {
                    try
                    {
                        qlns.UpdateNVien(nv);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi cập nhật nhân viên: " + ex.Message, ex);
                    }
                }
            }
        }

        // Kiem tra du lieu xoa NV
        public bool CheckDeleteNVien(FieldNhanVien nv)
        {
            if (nv == null) return false;
            else
            {
                if (!qlns.getAllNVien().Any()) return false;
                else
                {
                    try
                    {
                        qlns.DeleteNVien(nv);
                        return true;
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
