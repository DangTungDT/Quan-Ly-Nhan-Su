using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class DALconnectNP
    {
        public readonly PersonnelManagementDataContext ql;

        public DALconnectNP()
        {
            ql = new PersonnelManagementDataContext();
        }

        // Lay d/s cua nghi phep
        public IQueryable<DTONghiPhep> GetAllNPhep()
        {
            return ql.NghiPheps.Select(p => new DTONghiPhep()
            {
                ID = p.id,
                TrangThai = p.TrangThai,
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
                NghiPhep NghiPhep = new NghiPhep();
                if (np.TrangThai == "Đang yêu cầu" || np.TrangThai == null)
                {
                    NghiPhep = new NghiPhep()
                    {
                        idNhanVien = np.NhanVien,
                        LoaiNghiPhep = np.LoaiNghiPhep,
                        LyDoNghi = np.LyDoNghi,
                        NgayBatDau = np.NgayBD,
                        NgayKetThuc = np.NgayKT,
                        TrangThai = "Đang yêu cầu"
                    };
                }
                else
                {
                    NghiPhep = new NghiPhep()
                    {
                        idNhanVien = np.NhanVien,
                        LoaiNghiPhep = np.LoaiNghiPhep,
                        LyDoNghi = np.LyDoNghi,
                        NgayBatDau = np.NgayBD,
                        NgayKetThuc = np.NgayKT,
                        TrangThai = np.TrangThai
                    };
                }


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

                if(NghiPhep != null)
                {
                    NghiPhep.idNhanVien = np.NhanVien;
                    NghiPhep.TrangThai = np.TrangThai;
                    NghiPhep.LoaiNghiPhep = np.LoaiNghiPhep;
                    NghiPhep.LyDoNghi = np.LyDoNghi;
                    NghiPhep.NgayBatDau = np.NgayBD;
                    NghiPhep.NgayKetThuc = np.NgayKT;

                    ql.SubmitChanges();

                    return true;
                }
                else
                {
                    return false;
                }
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

        //Lấy các nghỉ phép theo id người dùng và ở trạng thái yêu cầu (0)
        public IQueryable getAllNghiPhepDangYeuCau(string IDEmployee)
        {
            return ql.NghiPheps.Where(x => x.idNhanVien == IDEmployee && x.TrangThai == "Đang yêu cầu").Select(x => new DTONghiPhep
            {
                ID = x.id,
                NhanVien = x.idNhanVien,
                LoaiNghiPhep = x.LoaiNghiPhep,
                LyDoNghi = x.LyDoNghi,
                NgayBD = x.NgayBatDau,
                NgayKT = x.NgayKetThuc,
                TrangThai = x.TrangThai
            });
        }

        //Lấy nghỉ phép theo phân quyền
        public IQueryable getNghiPhepTheoPhanQuyen(string IDEmployee)
        {
            if(IDEmployee.Substring(0,2) == "TP")
            {
                //Tách chuỗi để lấy mã phòng ban ở giữa ID nhân viên
                string idPhongBan = "PB" +Regex.Match(IDEmployee, @"^TP([A-Z]+)\d+$").Groups[1].Value; //Dùng Regex này để lấy chữ ở giữa TP và số
                

                return from np in ql.NghiPheps
                       from pb in ql.PhongBans
                       from nv in ql.NhanViens
                       where nv.idPhongBan == pb.id && np.idNhanVien == nv.id && pb.id == idPhongBan
                       select new DTONghiPhep
                       {
                           ID = np.id,
                           NhanVien = np.idNhanVien,
                           LoaiNghiPhep = np.LoaiNghiPhep,
                           LyDoNghi = np.LyDoNghi,
                           NgayBD = np.NgayBatDau,
                           NgayKT = np.NgayKetThuc,
                           TrangThai = np.TrangThai
                       };
            }
            else if(IDEmployee.Substring(0, 2) == "GD" || IDEmployee.Substring(0, 3) == "PGD")
            {
                return GetAllNPhep();
            }
            return null;
        }

        //Lấy các nghỉ phép theo id người dùng
        public IQueryable getAllNghiPhepByID(string IDEmployee)
        {
            return ql.NghiPheps.Where(x => x.idNhanVien == IDEmployee).Select(x => new DTONghiPhep
            {
                ID = x.id,
                NhanVien = x.idNhanVien,
                LoaiNghiPhep = x.LoaiNghiPhep,
                LyDoNghi = x.LyDoNghi,
                NgayBD = x.NgayBatDau,
                NgayKT = x.NgayKetThuc,
                TrangThai = x.TrangThai
            });
        }
    }
}
