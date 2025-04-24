using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTODanhGiaNV
    {
        private int id;
        private int diemSo;
        private int idNguoiDanhGia;
        private int idNhanVien;
        private string nhanXet;
        private DateTime ngayTao;


        public int Id { get => id; set => id = value; }
        public int DiemSo
        {
            get => diemSo;
            set
            {
                if (value > -1 && value < 11)
                {
                    diemSo = value;
                }
                else throw new Exception("Loi diem so");
            }
        }
        public int IdNhanVien { get => idNhanVien; }
        public int IdNguoiDanhGia { get => idNguoiDanhGia; }
        public string NhanXet { get => nhanXet; set => nhanXet = value; }
        public DateTime NgayTao { get => ngayTao; set => ngayTao = DateTime.Now;  }
    }
}
