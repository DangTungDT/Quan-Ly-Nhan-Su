using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALDuAnNhanVien
    {
        //Kết Nối Với DaTa = DataLinQ
        PersonnelManagementDataContext db = new PersonnelManagementDataContext();


        //Lấy Toàn Bộ Thông Tin Bảng Dự ÁN_Nhân viên
        public IQueryable getThongTinDuAn_NhanVien()
        {
            IQueryable duAn_NV = from du_an_NV in db.DuAn_NhanViens
                                 select du_an_NV;
            return duAn_NV;

        }

        //Thêm dự án Mới vào bảng
        public bool themDuAn_NV(DTODuAnNhanVien objDANV)
        {
            try
            {
                // Kiểm tra xem Dự Án_Nhân viên có tồn tại chưa
                var check = db.DuAn_NhanViens.FirstOrDefault(s => s.idDuAn == objDANV.IdDuAn && s.idNhanVien == objDANV.IdNhanVien);
                if (check != null) return false; // Nếu đã tồn tại, trả về false

                DuAn_NhanVien spnew = new DuAn_NhanVien
                {
                    idNhanVien = objDANV.IdNhanVien,
                    idDuAn = objDANV.IdDuAn,
                    VaiTroNhanVien = objDANV.VaiTroNV,
                    NgayThamGia = objDANV.NgayThamGia,
                    NgayTao = objDANV.NgayTao,

                };
                db.DuAn_NhanViens.InsertOnSubmit(spnew);
                db.SubmitChanges(); // Chỉ gọi SubmitChanges() khi chắc chắn thêm thành công
                return true;
            }
            catch (Exception)
            {
                return false; // Nếu có lỗi xảy ra, trả về false
            }
        }

        //Xóa dự án
        public bool xoaDuAn_NV(DTODuAnNhanVien objDANV)
        {
            var xoa = from i in db.DuAn_NhanViens
                      where i.idDuAn == objDANV.IdDuAn && i.idNhanVien == objDANV.IdNhanVien
                      select i;
            if (!xoa.Any()) // Kiểm tra có dữ liệu để xóa không
            {
                return false; // Không có bản ghi nào phù hợp => trả về false
            }

            foreach (var i in xoa)
            {
                db.DuAn_NhanViens.DeleteOnSubmit(i);
                db.SubmitChanges();
            }
            return true;

        }

        public bool suaDuAn_NV(DTODuAnNhanVien objDANV)
        {
            try
            {
                // Tìm Dự Án_NV cần sửa theo id Nhan Vien
                var phanCongDuAnUpdate = db.DuAn_NhanViens.FirstOrDefault(s => s.idDuAn == objDANV.IdDuAn && s.idNhanVien == objDANV.IdNhanVien);

                // Nếu không tìm thấy Dự Án, trả về false
                if (phanCongDuAnUpdate == null)
                    return false;

                // Cập nhật thông tin mới
                phanCongDuAnUpdate.idNhanVien = objDANV.IdNhanVien;
                phanCongDuAnUpdate.idDuAn = objDANV.IdDuAn;
                phanCongDuAnUpdate.VaiTroNhanVien = objDANV.VaiTroNV;
                phanCongDuAnUpdate.NgayThamGia = objDANV.NgayThamGia;
                phanCongDuAnUpdate.NgayTao = objDANV.NgayTao;

                // Lưu thay đổi vào DB
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false; // Nếu có lỗi, trả về false
            }
        }

        public IQueryable timDuAn_NVTheoID(DTODuAnNhanVien objDANV)
        {
            // Tìm Dự án_Nhan viên cần tìm theo idNhân viên và id Dự án
            IQueryable tim = from i in db.DuAn_NhanViens
                             where i.idDuAn == objDANV.IdDuAn && i.idNhanVien == objDANV.IdNhanVien
                             select i;

            return tim;

        }
    }
}
