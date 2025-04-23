using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhenThuong
    {
        int id;
        DateTime ngayKhenThuong;
        int soTienThuong;
        string lyDo;

        public DTO_KhenThuong(DateTime ngayKhenThuong, int soTienThuong, string lyDo)
        {
            this.NgayKhenThuong = ngayKhenThuong;
            this.SoTienThuong = soTienThuong;
            this.LyDo = lyDo;
        }

        public int Id { get => id; set => id = value; }
        public DateTime NgayKhenThuong { get => ngayKhenThuong; set => ngayKhenThuong = value; }
        public int SoTienThuong { get => soTienThuong; set => soTienThuong = value; }
        public string LyDo { get => lyDo; set => lyDo = value; }
    }
}
