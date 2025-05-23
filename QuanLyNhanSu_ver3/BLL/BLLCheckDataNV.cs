﻿using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCheckDataNV
    {
        public readonly DALConnectNV qlns;

        public BLLCheckDataNV()
        {
            qlns = new DALConnectNV();
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

        public IQueryable CheckListCVu() => qlns.getAllCVu();
        public IQueryable CheckListPBan() => qlns.getAllPBan();
        public IQueryable CheckListLuong() => qlns.getAllLuong();

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


        // Kiem tra chuc vu nhan vien duoc convert
        public string CheckConvertNameToIDChucVu(string name)
        {
            if (name == null) return string.Empty;
            else
            {
                if (!qlns.getAllNVien().Any()) return string.Empty;
                else
                {
                    try
                    {
                        return qlns.ConvertNameToIDChucVu(name);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi chuyển đổi dữ liệu chức vụ nhân viên: " + ex.Message, ex);
                    }
                }
            }
        }

        // Kiem tra luong nhan vien duoc convert
        public int CheckConvertNameToIDLuong(int luong)
        {
            if (luong < 0) return 0;
            else
            {
                if (!qlns.getAllNVien().Any()) return 0;
                else
                {
                    try
                    {
                        return qlns.ConvertNameToIDLuong(luong);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi chuyển đổi dữ liệu lương nhân viên: " + ex.Message, ex);
                    }
                }
            }
        }

        // Kiem tra phong ban nhan vien duoc convert
        public string CheckConvertNameToIDPhongBan(string name)
        {
            if (name == null) return string.Empty;
            else
            {
                if (!qlns.getAllNVien().Any()) return string.Empty;
                else
                {
                    try
                    {
                        return qlns.ConvertNameToIDPhongBan(name);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi chuyển đổi dữ liệu phòng ban nhân viên: " + ex.Message, ex);
                    }
                }
            }
        }

        public string getNameByID(string id)
        {
            return qlns.getNameByID(id);
        }


    }
}
