using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALChamCongNhanVien
    {
        //Biến toàn cục
        PersonnelManagementDataContext db = new PersonnelManagementDataContext();

        public IQueryable LoadDanhSachChamCong()
        {
            IQueryable list = db.ChamCongs.Select(x => x);
            return list;
        }

        public DTONhanVienChamCong LoadNhanVienByID(string id)
        {
            return (from nv in db.NhanViens
                    where nv.id == id
                    select new DTONhanVienChamCong
                    {
                        Id = nv.id,
                        TenNhanVien = nv.TenNhanVien
                    }).FirstOrDefault();
        }

        //Hàm add chấm công, return -1 là có lỗi, 1 là đã chấm công từ trước, 0 là chấm công thành công.
        public bool AddChamCong(DTOChamCongNhanVien dto)
        {
            try
            {
                ChamCong newItem = new ChamCong()
                {
                    idNhanVien = dto.IdNhanVien,
                    NgayChamCong = dto.NgayChamCong
                };
                db.ChamCongs.InsertOnSubmit(newItem);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }
        //public int AddChamCong(DTOChamCongNhanVien dto)
        //{
        //    if (dto == null) return -1; //Dữ liệu null, return -1 để nhận biết trường hợp
        //    try
        //    {
        //        if (CheckVauleChamCong(dto.IdNhanVien, dto.NgayChamCong) == true) //Kiểm tra đã chấm công từ trước hay chưa
        //        {
        //            //đã có chấm công vào ngày đó, nên sẽ return 1 để nhận biết trường hợp.
        //            return 1;
        //        }
        //        else
        //        {
        //            ChamCong newItem = new ChamCong()
        //            {
        //                idNhanVien = dto.IdNhanVien,
        //                NgayChamCong = dto.NgayChamCong
        //            };
        //            db.ChamCongs.InsertOnSubmit(newItem);
        //            db.SubmitChanges();

        //            return 0; //Thực hiện thành công, return 0 để nhận biết trường hợp
        //        }
        //    }catch(Exception ex)
        //    {
        //        return -1; //Sảy ra lỗi trong quá trình truy xuất
        //    }
        //}



        public ChamCong LoadChamCongNow(string idNhanVien, DateTime ngayChamCong)
        {
            return db.ChamCongs.Where(x => x.idNhanVien == idNhanVien && x.NgayChamCong == ngayChamCong).FirstOrDefault();
        }
    }
}
