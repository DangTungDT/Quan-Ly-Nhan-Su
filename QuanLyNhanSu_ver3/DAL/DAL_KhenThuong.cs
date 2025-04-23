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
            IQueryable listKT = from kt in db.KhenThuongs select kt;
            return listKT;
        }

        public bool XoaKhenThuong(DTO_KhenThuong dto)
        {
            try
            {
                KhenThuong khenThuongBiXoa = db.KhenThuongs.Where(x => x.id == dto.Id).Select(x => x).FirstOrDefault();
                db.KhenThuongs.DeleteOnSubmit(khenThuongBiXoa);

                return true;
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
    }
}
