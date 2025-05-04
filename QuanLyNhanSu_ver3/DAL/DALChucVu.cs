using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALChucVu
    {
        PersonnelManagementDataContext db = new PersonnelManagementDataContext();

        public IQueryable LoadChucVu()
        {
            return from cv in db.ChucVus select cv;
        }

        public bool AddChucVu(DTO_ChucVu dto)
        {
            try
            {
                ChucVu newChucVu = new ChucVu()
                {
                    id = dto.Id,
                    TenChucVu = dto.TenChucVu
                };
                db.ChucVus.InsertOnSubmit(newChucVu);
                db.SubmitChanges();

                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteChucVu(string idChucVuDelete)
        {
            try
            {
                ChucVu ChucVuDelete = (from cv in db.ChucVus where cv.id == idChucVuDelete select cv).FirstOrDefault();
                db.ChucVus.DeleteOnSubmit(ChucVuDelete);
                db.SubmitChanges();

                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool EditChucVu(DTO_ChucVu dto)
        {
            try
            {
                ChucVu chucVu = (from cv in db.ChucVus where cv.id == dto.Id select cv).FirstOrDefault();
                chucVu.TenChucVu = dto.TenChucVu;
                db.SubmitChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
