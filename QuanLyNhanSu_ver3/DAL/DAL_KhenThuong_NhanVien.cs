using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhenThuong_NhanVien
    {
        PersonnelManagementDataContext db = new PersonnelManagementDataContext();

        public IQueryable LoadKhenThuong()
        {
            return from kt in db.KhenThuongs select new
            {
                kt.id,
                kt.LyDo
            };
        }
        public IQueryable LoadNhanVien()
        {
            return from nv in db.NhanViens
                   select new
                   {
                       nv.id,
                       nv.TenNhanVien,
                       nv.idChucVu,
                       nv.idLuong,
                       nv.idPhongBan
                   };
        }

        public IQueryable LoadNhanVienKhenThuong(int idKhenThuong)
        {
            IQueryable dsNhanVien = from nv in db.NhanViens
                                    from pb in db.PhongBans where pb.id == nv.idPhongBan
                                    from nvKhenThuong in db.KhenThuong_NhanViens
                                    where nvKhenThuong.idKhenThuong == idKhenThuong && nv.id == nvKhenThuong.idNhanVien
                                    select new
                                    {
                                        nv.id,
                                        nv.TenNhanVien,
                                        pb.TenPhongBan,
                                    };

            return dsNhanVien;

        }

        public bool AddKhenThuongNhanVien(string idNV, int idKT)
        {
            try
            {
                KhenThuong_NhanVien valueNew = new KhenThuong_NhanVien()
                {
                    idKhenThuong = idKT,
                    idNhanVien = idNV
                };
                db.KhenThuong_NhanViens.InsertOnSubmit(valueNew);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool DeleteNhanVienNhanKhenThuong(string idNV, int idKT)
        {
            try
            {
                KhenThuong_NhanVien valueDelete = (from item in db.KhenThuong_NhanViens
                                                  where item.idNhanVien == idNV && item.idKhenThuong == idKT
                                                  select item).FirstOrDefault();
                db.KhenThuong_NhanViens.DeleteOnSubmit(valueDelete);
                db.SubmitChanges(); return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
