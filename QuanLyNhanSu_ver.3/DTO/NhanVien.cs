using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DTO
{
    public class NhanVien
    {
        public int iD, iDChucVu, iDLuong, iDPhongBan;
        public string tenNhanVien, diaChi, que, gioiTinh, email;
        public DateTime ngaySinh;

        public int ID { get => iD; set => iD = value; }
        public int IDChucVu { get => iDChucVu; }
        public int IDLuong { get => iDLuong; }
        public int IDPhongBan { get => iDPhongBan; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Que { get => que; set => que = value; }
        public string GioiTinh
        {
            get => gioiTinh; 
            set
            {
                if (string.IsNullOrEmpty(value) && (value == "Nam" || value == "Nữ")) 
                {
                    gioiTinh = value;
                }
                else throw new Exception("Loi gioi tinh");
            }
        }
        
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string Email
        {
            get => email; 
            set
            {
                if (value.Contains("@gmail.com"))
                {
                    email = value;
                }
                else throw new Exception("Loi Email");
            }
        }
    }
}
