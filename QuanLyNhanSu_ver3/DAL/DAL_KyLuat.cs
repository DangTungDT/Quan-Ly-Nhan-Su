using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KyLuat
    {
        PersonnelManagementDataContext db = new PersonnelManagementDataContext();

        public IQueryable LoadKyLuat()
        {
            return from kl in db.KyLuats select kl;
        }

        public bool AddKyLuat(DTO_KyLuat dto)
        {
            try
            {
                KyLuat newKyLuat = new KyLuat()
                {
                    NoiDungKyLuat = dto.NoiDungKyLuat,
                    LyDoKyLuat = dto.LyDoKyLuat
                };
                db.KyLuats.InsertOnSubmit(newKyLuat);
                db.SubmitChanges();

                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool DeleteKyLuat(int idKyLuat)
        {
            try
            {
                KyLuat kyLuatDelete = (from kl in db.KyLuats where kl.id == idKyLuat select kl).FirstOrDefault();
                db.KyLuats.DeleteOnSubmit(kyLuatDelete);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditKyLuat(DTO_KyLuat dto)
        {
            try
            {

                KyLuat kyLuatEdit = (from kl in db.KyLuats where kl.id == dto.Id select kl).FirstOrDefault();
                kyLuatEdit.NoiDungKyLuat = dto.NoiDungKyLuat;
                kyLuatEdit.LyDoKyLuat = dto.LyDoKyLuat;
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
