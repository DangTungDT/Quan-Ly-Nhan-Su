using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KyLuatNhanVien
    {
        PersonnelManagementDataContext db = new PersonnelManagementDataContext();

        public IQueryable LoadNhanVien()
        {
            return from nv in db.NhanViens
                   from pb in db.PhongBans
                   from cv in db.ChucVus
                   where nv.idChucVu == cv.id && nv.idPhongBan == pb.id
                   select new
                   {
                       nv.id,
                       nv.TenNhanVien,
                       cv.TenChucVu,
                       pb.TenPhongBan

                   };
        }

        public IQueryable LoadKyLuat()
        {
            return from kl in db.KyLuats select kl;
        }

        public IQueryable LoadNhanVienKyLuat(int idKyLuat)
        {
            return from nvkl in db.KyLuat_NhanViens
                   from nv in db.NhanViens
                   from kl in db.KyLuats
                   where nvkl.idNhanVien == nv.id && nvkl.idKyLuat == kl.id && nvkl.idKyLuat == idKyLuat && kl.id == idKyLuat
                   select new
                   {
                       nvkl.idNhanVien,
                       nv.TenNhanVien,
                       kl.NoiDungKyLuat,
                       nvkl.NgayKyLuat
                   };
        }

        public bool AddKyLuatNhanVien(DTO_KyLuatNhanVien dto) 
        {
            try
            {
                KyLuat_NhanVien newItem = new KyLuat_NhanVien()
                {
                    idKyLuat = dto.IdKyLuat,
                    idNhanVien = dto.IdNhanVien,
                    NgayKyLuat = dto.NgayKyLuat
                };
                db.KyLuat_NhanViens.InsertOnSubmit(newItem);
                db.SubmitChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteKyLuatNhanVien(DTO_KyLuatNhanVien dto)
        {
            try
            {
                KyLuat_NhanVien itemDelete = (from nv in db.KyLuat_NhanViens 
                                              where nv.idNhanVien == dto.IdNhanVien 
                                                    && nv.idKyLuat == dto.IdKyLuat 
                                                    && nv.NgayKyLuat == dto.NgayKyLuat
                                              select nv).FirstOrDefault();
                db.KyLuat_NhanViens.DeleteOnSubmit(itemDelete);
                db.SubmitChanges();

                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

    }
}
