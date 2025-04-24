using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DAL
{
    public class DALConnectNV
    {
        public readonly QLNSDataContext qlns;

        public DALConnectNV()
        {
            qlns = new QLNSDataContext();
        }

        public IEnumerable<ChucVu> getAllCVu() => qlns.ChucVus.ToList();

        public IEnumerable<PhongBan> getAllPBan() => qlns.PhongBans.ToList();

        public IEnumerable<Luong> getAllLuong() => qlns.Luongs.ToList();

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

        // Xy li them nhan vien
        public bool AddNVien(DTONhanVien nv)
        {
            try
            {
                NhanVien addNV = new NhanVien()
                {
                    id = nv.ID,
                    idChucVu = nv.IDChucVu,
                    idLuong = nv.IDLuong,
                    idPhongBan = nv.IDPhongBan,
                    NgaySinh = nv.NgaySinh,
                    TenNhanVien = nv.TenNhanVien,
                    DiaChi = nv.DiaChi,
                    Que = nv.Que,
                    GioiTinh = nv.GioiTinh,
                    Email = nv.Email
                };

                qlns.NhanViens.InsertOnSubmit(addNV);
                qlns.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        // Xy li cap nhat nhan vien
        public bool UpdateNVien(DTONhanVien nv)
        {
            try
            {
                var NhanVien = qlns.NhanViens.FirstOrDefault(p => p.id == nv.ID);
                NhanVien.id = nv.ID;
                NhanVien.idChucVu = nv.IDChucVu;
                NhanVien.idLuong = nv.IDLuong;
                NhanVien.idPhongBan = nv.IDPhongBan;
                NhanVien.NgaySinh = nv.NgaySinh;
                NhanVien.TenNhanVien = nv.TenNhanVien;
                NhanVien.DiaChi = nv.DiaChi;
                NhanVien.Que = nv.Que;
                NhanVien.GioiTinh = nv.GioiTinh;
                NhanVien.Email = nv.Email;

                qlns.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        // Xy li xoa nhan vien
        public bool DeleteNVien(DTONhanVien nv)
        {
            try
            {
                var Nhanvien = qlns.NhanViens.FirstOrDefault(p => p.id == nv.ID);
                var TaiKhoanNV = qlns.TaiKhoans.FirstOrDefault(p => p.idNhanVien == nv.ID);

                if (Nhanvien != null)
                {
                    qlns.NhanViens.DeleteOnSubmit(Nhanvien);

                    if (TaiKhoanNV != null)
                    {
                        qlns.TaiKhoans.DeleteOnSubmit(TaiKhoanNV);
                    }

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
