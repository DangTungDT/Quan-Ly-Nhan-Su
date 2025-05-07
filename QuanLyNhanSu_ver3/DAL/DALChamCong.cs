using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALChamCong
    {
        //Kết Nối Với DaTa = DataLinQ
        PersonnelManagementDataContext db = new PersonnelManagementDataContext();
        //Lấy thông tin
        public IQueryable getThongTinChamCong()
        {
            IQueryable chamCong = from dt in db.ChamCongs
                                  join nv in db.NhanViens on dt.idNhanVien equals nv.id
                                  select new
                                  {
                                      ID = dt.id,
                                      NgayChamCong = dt.NgayChamCong,
                                      IDNhanVien = dt.idNhanVien,
                                      TenNhanVien = nv.TenNhanVien
                                      // Thêm các cột khác của bảng HopDongLaoDongs nếu cần
                                  };
            return chamCong;
        }
        //Thêm
        public bool themChamCong(DTOChamCong dtoData)
        {
            try
            {
                ChamCong insertData = new ChamCong
                {
                    idNhanVien = dtoData.IdNhanVien,
                    NgayChamCong = dtoData.NgayChamCong,
                };

                db.ChamCongs.InsertOnSubmit(insertData);
                db.SubmitChanges(); // Chỉ gọi SubmitChanges() khi chắc chắn thêm thành công
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Xóa
        public bool xoaChamCong(DTOChamCong dtoData)
        {
            try
            {
                var xoa = from i in db.ChamCongs
                          where i.idNhanVien == dtoData.IdNhanVien && i.NgayChamCong == dtoData.NgayChamCong
                          select i;
                if (!xoa.Any()) // Kiểm tra có dữ liệu để xóa không
                {
                    return false; // Không có bản ghi nào phù hợp => trả về false
                }

                foreach (var i in xoa)
                {
                    db.ChamCongs.DeleteOnSubmit(i);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Xóa tất cả
        public bool xoaAllChamCong(DTOChamCong dtoData)
        {
            try
            {
                var deleteData = from i in db.ChamCongs
                                 where i.idNhanVien == dtoData.IdNhanVien
                                 select i;
                if (deleteData == null)
                {
                    return false;
                }
                foreach (var i in deleteData)
                {
                    db.ChamCongs.DeleteOnSubmit(i);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Sửa
        public bool suaChamCong(DTOChamCong dtoData)
        {
            try
            {
                var updateData = db.ChamCongs.FirstOrDefault(c => c.id == int.Parse(dtoData.IdChamCong));
                // Nếu không tìm thấy, trả về false
                if (updateData == null) return false;

                updateData.NgayChamCong = dtoData.NgayChamCong;

                // Lưu thay đổi vào DB
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IQueryable timChamCong(DTOChamCong dtoData)
        {
            IQueryable tim = from i in db.ChamCongs
                             where i.idNhanVien == dtoData.IdNhanVien && i.NgayChamCong == dtoData.NgayChamCong
                             select i;
            return tim;

        }
    }
}
