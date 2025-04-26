using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALconnectNP
    {
        public readonly QLNSDataContext ql;

        public DALconnectNP()
        {
            ql = new QLNSDataContext();
        }

        // Lay d/s cua nghi phep
        public IQueryable<DTONghiPhep> GetAllNPhep()
        {
            return ql.NghiPheps.Select(p => new DTONghiPhep()
            {
                ID = p.id,
                NhanVien = p.idNhanVien,
                LyDoNghi = p.LyDoNghi,
                LoaiNghiPhep = p.LoaiNghiPhep,
                NgayBD = p.NgayBatDau,
                NgayKT = p.NgayKetThuc
            });
        }

        public IQueryable<NhanVien> GetAllNV()
        {
            return ql.NhanViens;
        }

        // Them du lieu cho nghi phep
        public bool AddNghiPhep(DTONghiPhep np)
        {
            try
            {
                NghiPhep NghiPhep = new NghiPhep()
                {
                    idNhanVien = np.NhanVien,
                    LoaiNghiPhep = np.LoaiNghiPhep,
                    LyDoNghi = np.LyDoNghi,
                    NgayBatDau = np.NgayBD,
                    NgayKetThuc = np.NgayKT
                };

                ql.NghiPheps.InsertOnSubmit(NghiPhep);
                ql.SubmitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Cap nhat du lieu cho nghi phep
        public bool UpdateNghiPhep(DTONghiPhep np)
        {
            try
            {
                var NghiPhep = ql.NghiPheps.FirstOrDefault(p => p.id == np.ID);

                NghiPhep.idNhanVien = np.NhanVien;
                NghiPhep.LoaiNghiPhep = np.LoaiNghiPhep;
                NghiPhep.LyDoNghi = np.LyDoNghi;
                NghiPhep.NgayBatDau = np.NgayBD;
                NghiPhep.NgayKetThuc = np.NgayKT;

                ql.SubmitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Xoa du lieu cho nghi phep
        public bool DeleteNghiPhep(DTONghiPhep np)
        {
            try
            {
                var NghiPhep = ql.NghiPheps.FirstOrDefault(p => p.id == np.ID);
                ql.NghiPheps.DeleteOnSubmit(NghiPhep);
                ql.SubmitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
