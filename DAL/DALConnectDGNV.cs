using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALConnectDGNV
    {
        public readonly QLNSDataContext qlns;

        public DALConnectDGNV()
        {
            qlns = new QLNSDataContext();
        }

        // Lay d/s nhan vien
        public IQueryable<DTONhanVien> getAllNVien() => qlns.NhanViens.Select(nv => new DTONhanVien
        {
            ID = nv.id,
            IDChucVu = nv.idChucVu,
            IDLuong = nv.idLuong,
            IDPhongBan = nv.idPhongBan,
            TenNhanVien = nv.TenNhanVien,
            DiaChi = nv.DiaChi,
            Que = nv.Que,
            GioiTinh = nv.GioiTinh,
            NgaySinh = nv.NgaySinh,
            Email = nv.Email
        });

        // Lay d/s danh gia nhan vien
        public IQueryable<DTODanhGiaNV> getAllDGNVien() => qlns.DanhGiaNhanViens.Select(p => new DTODanhGiaNV
        {
            ID = p.id,
            DiemSo = p.DiemSo,
            IDNguoiDanhGia = p.idNguoiDanhGia,
            IDNhanVien = p.idNhanVien,
            NhanXet = p.NhanXet,
            NgayTao = p.ngayTao
        });

        // Xy li them danh gia nhan vien
        public bool AddDGNVien(DTODanhGiaNV nv)
        {
            try
            {
                DanhGiaNhanVien DanhGia = new DanhGiaNhanVien()
                {
                    id = nv.ID,
                    DiemSo = nv.DiemSo,
                    idNguoiDanhGia = nv.IDNguoiDanhGia,
                    idNhanVien = nv.IDNhanVien,
                    NhanXet = nv.NhanXet,
                    ngayTao = nv.NgayTao
                };

                qlns.DanhGiaNhanViens.InsertOnSubmit(DanhGia);
                qlns.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        // Xy li cap nhat danh gia nhan vien
        public bool UpdateDGNVien(DTODanhGiaNV nv)
        {
            try
            {
                var DanhGia = qlns.DanhGiaNhanViens.FirstOrDefault(p => p.id == nv.ID);
                DanhGia.id = nv.ID;
                DanhGia.DiemSo = nv.DiemSo;
                DanhGia.idNguoiDanhGia = nv.IDNguoiDanhGia;
                DanhGia.idNhanVien = nv.IDNhanVien;
                DanhGia.NhanXet = nv.NhanXet;
                DanhGia.ngayTao = nv.NgayTao;


                qlns.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        // Xy li xoa danh gia nhan vien
        public bool DeleteDGNVien(DTODanhGiaNV nv)
        {
            try
            {
                var DanhGia = qlns.DanhGiaNhanViens.FirstOrDefault(p => p.id == nv.ID);

                if (DanhGia != null)
                {
                    qlns.DanhGiaNhanViens.DeleteOnSubmit(DanhGia);
                    qlns.SubmitChanges();

                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
