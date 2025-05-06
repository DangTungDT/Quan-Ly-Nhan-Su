using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCheckDataDGNV
    {
        public readonly DALConnectDGNV qlns;

        public BLLCheckDataDGNV()
        {
            qlns = new DALConnectDGNV();
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

        public bool CheckScoreDGNV(DTODanhGiaNV nv)
        {
            try
            {
                if (nv.DiemSo < 0 || nv.DiemSo > 10)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra d/s đánh giá nhân viên: " + ex.Message, ex);
            }
        }

        // Kiem tra d/s du lieu danh gia nhan vien
        public List<DTODanhGiaNV> CheckGetAllDGNV()
        {
            var list = qlns.getAllDGNVien().ToList();
            if (list.Any() && list != null)
            {
                try
                {
                    foreach (var item in list)
                    {
                        if (item.DiemSo > -1 || item.DiemSo < 11)
                        {
                            return list;
                        }
                    }
                    throw new Exception("Điểm số không hợp lệ!!!");
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi kiểm tra d/s đánh giá nhân viên: " + ex.Message, ex);
                }
            }
            else
            {
                throw new Exception("Danh sách đánh giá nhân viên rỗng hoặc null");
            }
        }

        // kiem tra du lieu them DGNVien
        public bool CheckAddDGNVien(DTODanhGiaNV np)
        {
            try
            {
                if (CheckGetAllDGNV() != null && np != null && CheckScoreDGNV(np))
                {
                    return qlns.AddDGNVien(np);
                }
                else
                {
                    throw new Exception("Kiểm tra dữ liệu thêm đánh giá nhân viên không hợp lệ !!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm đánh giá nhân viên: " + ex.Message);
            }
        }

        // Kiem tra du lieu cap nhat DGNVien
        public bool CheckUpdateDGNVien(DTODanhGiaNV np)
        {
            try
            {
                var ktra = qlns.getAllDGNVien().FirstOrDefault(p => p.ID == np.ID);
                if (ktra != null && np != null && CheckScoreDGNV(np))
                {
                    return qlns.UpdateDGNVien(np);
                }
                else
                {
                    throw new Exception("Kiểm tra dữ liệu cập nhật đánh giá nhân viên không hợp lệ !!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật đánh giá nhân viên: " + ex.Message);
            }
        }

        // Kiem tra du lieu xoa DGNVien
        public bool CheckDeleteDGNVien(DTODanhGiaNV np)
        {
            try
            {
                if (np.ID > 0)
                {
                    return qlns.DeleteDGNVien(np);
                }
                else
                {
                    throw new Exception("Kiểm tra ID đánh giá nhân viên không hợp lệ !!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa đánh giá nhân viên: " + ex.Message);
            }
        }

        // Kiem tra ten nhan vien duoc convert
        public string CheckConvertNameToINVien(string name)
        {
            if (name == null) return string.Empty;
            else
            {
                if (!qlns.getAllNVien().Any()) return string.Empty;
                else
                {
                    try
                    {
                        return qlns.ConvertNameToIDNVien(name);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi chuyển đổi dữ liệu nhân viên: " + ex.Message, ex);
                    }
                }
            }
        }


    }
}
