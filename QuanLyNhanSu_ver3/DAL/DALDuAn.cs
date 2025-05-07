using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALDuAn
    {
        //Kết Nối Với DaTa = DataLinQ
        PersonnelManagementDataContext db = new PersonnelManagementDataContext();

        //Lấy Tàn Bộ Thông Tin Bảng Dự ÁN
        public IQueryable getThongTinDuAn()
        {
            IQueryable duAn = from du_an in db.DuAns
                              select du_an;
            return duAn;

        }

        //Thêm dự án Mới vào bảng
        public bool themDuAn(DTODuAn objDA)
        {
            try
            {
                // Kiểm tra xem Dự Án có tồn tại chưa
                var check = db.DuAns.FirstOrDefault(s => s.id == objDA.IdDuAn);
                if (check != null) return false; // Nếu đã tồn tại, trả về false

                DuAn spnew = new DuAn
                {
                    id = objDA.IdDuAn,
                    TenDuAn = objDA.TenDuAn,
                    MoTa = objDA.MoTa,
                    NgayBatDau = objDA.NgayBD,
                    NgayKetThuc = objDA.NgayKT,
                    TrangThai = objDA.TrangThai,
                    NgayTao = objDA.NgayTao,

                };
                db.DuAns.InsertOnSubmit(spnew);
                db.SubmitChanges(); // Chỉ gọi SubmitChanges() khi chắc chắn thêm thành công
                return true;
            }
            catch (Exception ex)
            {
                return false; // Nếu có lỗi xảy ra, trả về false
            }
        }

        //Xóa dự án
        public bool xoaDuAn(DTODuAn objDA)
        {
            if (db.DuAn_NhanViens.Any(dn => dn.idDuAn == objDA.IdDuAn))
            {
                return false;
            }
            var xoa = from i in db.DuAns
                      where i.id == objDA.IdDuAn
                      select i;
            if (!xoa.Any()) // Kiểm tra có dữ liệu để xóa không
            {
                return false; // Không có bản ghi nào phù hợp => trả về false
            }

            foreach (var i in xoa)
            {
                db.DuAns.DeleteOnSubmit(i);
                db.SubmitChanges();
            }
            return true;

        }

        public bool suaDuAn(DTODuAn objDA)
        {
            try
            {
                // Tìm Dự Án cần sửa theo id
                var duAnUpdate = db.DuAns.FirstOrDefault(s => s.id == objDA.IdDuAn);

                // Nếu không tìm thấy Dự Án, trả về false
                if (duAnUpdate == null)
                    return false;
                // Cập nhật thông tin mới
                duAnUpdate.TenDuAn = objDA.TenDuAn;
                duAnUpdate.MoTa = objDA.MoTa;
                duAnUpdate.NgayBatDau = objDA.NgayBD;
                duAnUpdate.NgayKetThuc = objDA.NgayKT;
                duAnUpdate.TrangThai = objDA.TrangThai;
                duAnUpdate.NgayTao = objDA.NgayTao;

                // Lưu thay đổi vào DB
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false; // Nếu có lỗi, trả về false

            }
        }

        public IQueryable timDuAnTheoID(DTODuAn duAn)
        {
            // Tìm Dự án cần tìm theo id
            IQueryable tim = from i in db.DuAns
                             where i.id == duAn.IdDuAn
                             select i;

            return tim;

        }
    }
}
