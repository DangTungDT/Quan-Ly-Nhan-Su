using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALConnectPB
    {
        public readonly QLNSDataContext qlns;

        public DALConnectPB()
        {
            qlns = new QLNSDataContext();
        }

        // Lay du lieu tu phong ban
        public IQueryable<DTOPhongBan> GetAllPBan() =>
            qlns.PhongBans.Select(p => new DTOPhongBan
            {
                ID = p.id,
                TenPhongBan = p.TenPhongBan,
                MoTa = p.Mota
            });

        // Xy li them phong ban
        public bool AddPBan(DTOPhongBan pb)
        {
            try
            {
                PhongBan PhongBan = new PhongBan()
                {
                    id = pb.ID,
                    TenPhongBan = pb.TenPhongBan,
                    Mota = pb.MoTa
                };

                qlns.PhongBans.InsertOnSubmit(PhongBan);
                qlns.SubmitChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        // Xy li cap nhat phong ban
        public bool UpdatePBan(DTOPhongBan pb)
        {
            try
            {
                var PhongBan = qlns.PhongBans.FirstOrDefault(p => p.id == pb.ID);
                PhongBan.id = pb.ID;
                PhongBan.TenPhongBan = pb.TenPhongBan;
                PhongBan.Mota = pb.MoTa;

                qlns.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Xy li xoa phong ban
        public bool DeletePBan(DTOPhongBan pb)
        {
            try
            {
                var PhongBan = qlns.PhongBans.FirstOrDefault(p => p.id == pb.ID);

                qlns.PhongBans.DeleteOnSubmit(PhongBan);
                qlns.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
