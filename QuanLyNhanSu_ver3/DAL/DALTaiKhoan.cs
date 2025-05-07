using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALTaiKhoan
    {
        //Kết Nối Với DaTa = DataLinQ
        PersonnelManagementDataContext db = new PersonnelManagementDataContext();

        //Lấy Tàn Bộ Thông Tin Bảng TaiKhoan
        public IQueryable getThongTinTaiKhoan()
        {
            IQueryable taiKhoan = from tk in db.TaiKhoans
                                  join nv in db.NhanViens on tk.idNhanVien equals nv.id
                                  select new
                                  {
                                      ID = tk.id,
                                      IDNhanVien = tk.idNhanVien,
                                      TenNhanVien = nv.TenNhanVien,
                                      TenDangNhap = tk.taiKhoan1,
                                      MatKhau = tk.matKhau
                                  };
            return taiKhoan;

        }

        //Thêm TaiKhoan Mới vào bảng
        public int themTaiKhoan(DTOTaiKhoan objTK)
        {
            try
            {
                // Kiểm tra xem TaiKhoan có tồn tại chưa
                var check = db.TaiKhoans.FirstOrDefault(s => s.idNhanVien == objTK.IDNhanVien);
                if (check != null) return -1; // Nếu đã tồn tại, trả về false
                if (db.TaiKhoans.Any(t => t.taiKhoan1 == objTK.TaiKhoan))
                {
                    return 0;
                }

                TaiKhoan tknew = new TaiKhoan
                {
                    idNhanVien = objTK.IDNhanVien,
                    taiKhoan1 = objTK.TaiKhoan,
                    matKhau = objTK.MatKhau,
                };
                db.TaiKhoans.InsertOnSubmit(tknew);
                db.SubmitChanges(); // Chỉ gọi SubmitChanges() khi chắc chắn thêm thành công
                return 1;
            }
            catch (Exception)
            {
                return -1; // Nếu có lỗi xảy ra, trả về false
            }
        }

        //Xóa TaiKhoan
        public bool xoaTaiKhoan(DTOTaiKhoan objTK)
        {
            var xoa = from i in db.TaiKhoans
                      where i.idNhanVien == objTK.IDNhanVien
                      select i;
            if (!xoa.Any()) // Kiểm tra có dữ liệu để xóa không
            {
                return false; // Không có bản ghi nào phù hợp => trả về false
            }

            foreach (var i in xoa)
            {
                db.TaiKhoans.DeleteOnSubmit(i);
                db.SubmitChanges();
            }
            return true;

        }

        //Sửa tài khoản
        public bool suaTaiKhoan(DTOTaiKhoan objTK)
        {
            try
            {
                // Tìm TaiKhoan cần sửa theo id
                var taiKhoanUpdate = db.TaiKhoans.FirstOrDefault(s => s.idNhanVien == objTK.IDNhanVien);

                // Nếu không tìm thấy Dự Án, trả về false
                if (taiKhoanUpdate == null)
                    return false;

                // Cập nhật thông tin mới
                taiKhoanUpdate.taiKhoan1 = objTK.TaiKhoan;
                taiKhoanUpdate.matKhau = objTK.MatKhau;

                // Lưu thay đổi vào DB
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false; // Nếu có lỗi, trả về false
            }
        }

        //Tìm Tai khoản
        public IQueryable timTaiKhoanTheoID(DTOTaiKhoan objTK)
        {
            // Tìm Dự án cần tìm theo id
            IQueryable tim = from i in db.TaiKhoans
                             where i.idNhanVien == objTK.IDNhanVien
                             select i;

            return tim;

        }

        
    }
}
