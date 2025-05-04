using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Luong
    {
        PersonnelManagementDataContext db = new PersonnelManagementDataContext();

        public IQueryable LoadLuong()
        {
            return db.Luongs.Select(x => x);
        }

        public bool AddLuong(DTO_Luong dto)
        {
            try
            {
                Luong newLuong = new Luong()
                {
                    SoTienLuong = dto.SoTienLuong
                };
                db.Luongs.InsertOnSubmit(newLuong);
                db.SubmitChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeteleLuong(int id)
        {
            try
            {
                Luong luong = db.Luongs.Where(x => x.id == id).FirstOrDefault();
                db.Luongs.DeleteOnSubmit(luong);
                db.SubmitChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditLuong(DTO_Luong dto)
        {
            try
            {
                Luong newLuong = db.Luongs.Where(x=> x.id == dto.Id).FirstOrDefault();
                newLuong.SoTienLuong = dto.SoTienLuong;
                db.SubmitChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
