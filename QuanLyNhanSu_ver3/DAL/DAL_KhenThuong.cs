using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhenThuong
    {
        //Connection
        PersonnelManagementDataContext db = new PersonnelManagementDataContext();
        //Method
        public IQueryable LoadKhenThuong()
        {
            return from kt in db.KhenThuongs select kt;
        }

        public IQueryable LoadNhanVien(string idPhongBan)
        {
            return from nhanVien in db.NhanViens where nhanVien.idPhongBan == idPhongBan select nhanVien;
        }

        public IQueryable LoadPhongBan()
        {
            return from phongBan in db.PhongBans select phongBan;
        }


        public bool XoaKhenThuong(DTO_KhenThuong dto)
        {
            try
            {
                //Kiểm tra trường hợp id không tồn tài
                if(db.KhenThuongs.Where(x=> x.id == dto.Id).FirstOrDefault() != null)
                {
                    KhenThuong khenThuongBiXoa = db.KhenThuongs.Where(x => x.id == dto.Id).Select(x => x).FirstOrDefault();
                    db.KhenThuongs.DeleteOnSubmit(khenThuongBiXoa);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                db.SubmitChanges();
            }
        }
        public bool ThemKhenThuong(DTO_KhenThuong dto)
        {
            try
            {
                KhenThuong newKT = new KhenThuong()
                {
                    ngayKhenThuong = dto.NgayKhenThuong,
                    LyDo = dto.LyDo,
                    SoTienThuong = dto.SoTienThuong
                };
                db.KhenThuongs.InsertOnSubmit(newKT);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                db.SubmitChanges();
                LoadKhenThuong();
            }
        }

        public bool EditKhenThuong(DTO_KhenThuong dto)
        {
            try
            {
                //Kiểm tra trường hợp không tìm thấy id
                if(db.KhenThuongs.Where(x=> x.id == dto.Id).First() != null)
                {
                    KhenThuong oldKhenThuong = db.KhenThuongs.Single(x => x.id == dto.Id);
                    oldKhenThuong.ngayKhenThuong = dto.NgayKhenThuong;
                    oldKhenThuong.SoTienThuong = dto.SoTienThuong;
                    oldKhenThuong.LyDo = dto.LyDo;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
    }
}
