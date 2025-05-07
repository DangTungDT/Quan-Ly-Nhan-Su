using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALHopDongLaoDong
    {
        //Kết Nối Với DaTa = DataLinQ
        PersonnelManagementDataContext db = new PersonnelManagementDataContext();

        //Lấy Toàn Bộ Thông Tin Bảng HopDongLaoDong
        public IQueryable getThongTinHopDong()
        {
            IQueryable hopDongLD = from hd in db.HopDongLaoDongs
                                   join nv in db.NhanViens on hd.idNhanVien equals nv.id
                                   select new
                                   {
                                       ID = hd.id,
                                       TenNhanVien = nv.TenNhanVien,
                                       NgayKy = hd.NgayKy,
                                       NgayBatDau = hd.NgayBatDau,
                                       NgayKetThuc = hd.NgayKetThuc,
                                       MoTa = hd.MoTa
                                       // Thêm các cột khác của bảng HopDongLaoDongs nếu cần
                                   };
            return hopDongLD;
        }

        //public IQueryable getThongTinHopDong()
        //{
        //    IQueryable hopDongLD = from hopDong in db.HopDongLaoDongs
        //                           select hopDong;
        //    return hopDongLD;
        //}
        //Thêm dự án Mới vào bảng
        public int themHopDong(DTOHopDongLaoDong objHD)
        {
            try
            {
                // Kiểm tra xem hợp đồng có tồn tại chưa
                if (db.HopDongLaoDongs.Any(h => h.idNhanVien == objHD.IdNhanVien))
                {
                    return 0;
                }
                HopDongLaoDong insertNew = new HopDongLaoDong()
                {
                    idNhanVien = objHD.IdNhanVien,
                    NgayBatDau = objHD.NgayBatDau,
                    NgayKetThuc = objHD.NgayKetThuc,
                    NgayKy = objHD.NgayKy,
                    MoTa = objHD.MoTa,
                };
                db.HopDongLaoDongs.InsertOnSubmit(insertNew);
                db.SubmitChanges(); // Chỉ gọi SubmitChanges() khi chắc chắn thêm thành công
                return 1;
            }
            catch (Exception)
            {
                return -1; // Nếu có lỗi xảy ra, trả về false
            }
        }
        //Xóa
        public bool xoaHopDong(DTOHopDongLaoDong objHD)
        {
            try
            {
                var xoa = from i in db.HopDongLaoDongs
                          where i.idNhanVien == objHD.IdNhanVien
                          select i;
                if (!xoa.Any()) // Kiểm tra có dữ liệu để xóa không
                {
                    return false; // Không có bản ghi nào phù hợp => trả về false
                }

                foreach (var i in xoa)
                {
                    db.HopDongLaoDongs.DeleteOnSubmit(i);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Sửa
        public bool suaHopDong(DTOHopDongLaoDong objHD)
        {
            try
            {
                var dataUpdate = db.HopDongLaoDongs.FirstOrDefault(h => h.idNhanVien == objHD.IdNhanVien);
                if (dataUpdate == null) return false;
                dataUpdate.NgayKy = objHD.NgayKy;
                dataUpdate.NgayBatDau = objHD.NgayBatDau;
                dataUpdate.NgayKetThuc = objHD.NgayKetThuc;
                dataUpdate.MoTa = objHD.MoTa;
                // Lưu thay đổi
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IQueryable timHopDong(DTOHopDongLaoDong objHD)
        {
            // Tìm Dự án_Nhan viên cần tìm theo idNhân viên và id Dự án
            IQueryable dataFind = from i in db.HopDongLaoDongs
                                  where i.idNhanVien == objHD.IdNhanVien
                                  select i;

            return dataFind;

        }
    }
}
