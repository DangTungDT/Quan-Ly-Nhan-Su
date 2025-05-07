using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTODuAn
    {
        private string _idDuAn;
        private string _tenDuAn;
        private string _moTa;
        private DateTime _ngayBD;
        private DateTime _ngayKT;
        private string _trangThai;
        private DateTime _ngayTao;

        public DTODuAn() { }

        public DTODuAn(string idDuAn, string tenDuAn, string moTa, DateTime ngayBD, DateTime ngayKT, string trangThai, DateTime ngayTao)
        {
            _idDuAn = idDuAn;
            _tenDuAn = tenDuAn;
            _moTa = moTa;
            _ngayBD = ngayBD;
            _ngayKT = ngayKT;
            _trangThai = trangThai;
            _ngayTao = ngayTao;
        }

        public string IdDuAn { get => _idDuAn; set => _idDuAn = value; }
        public string TenDuAn { get => _tenDuAn; set => _tenDuAn = value; }
        public string MoTa { get => _moTa; set => _moTa = value; }
        public DateTime NgayBD { get => _ngayBD; set => _ngayBD = value; }
        public DateTime NgayKT { get => _ngayKT; set => _ngayKT = value; }
        public string TrangThai { get => _trangThai; set => _trangThai = value; }
        public DateTime NgayTao { get => _ngayTao; set => _ngayTao = value; }
    }
}
