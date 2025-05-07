using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTODuAnNhanVien
    {
        private string _idDuAn;
        private string _idNhanVien;
        private string _vaiTroNV;
        private DateTime _ngayThamGia;
        private DateTime _ngayTao;

        public DTODuAnNhanVien() { }

        public DTODuAnNhanVien(string idDuAn, string idNhanVien, string vaiTroNV, DateTime ngayThamGia, DateTime ngayTao)
        {
            _idDuAn = idDuAn;
            _idNhanVien = idNhanVien;
            _vaiTroNV = vaiTroNV;
            _ngayThamGia = ngayThamGia;
            _ngayTao = ngayTao;
        }

        public string IdDuAn { get => _idDuAn; set => _idDuAn = value; }
        public string IdNhanVien { get => _idNhanVien; set => _idNhanVien = value; }
        public string VaiTroNV { get => _vaiTroNV; set => _vaiTroNV = value; }
        public DateTime NgayThamGia { get => _ngayThamGia; set => _ngayThamGia = value; }
        public DateTime NgayTao { get => _ngayTao; set => _ngayTao = value; }
    }
}
