using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KyLuat
    {
        int id;
        string noiDungKyLuat, lyDoKyLuat;

        public DTO_KyLuat(int id, string noiDungKyLuat, string lyDoKyLuat)
        {
            this.id = id;
            this.noiDungKyLuat = noiDungKyLuat;
            this.lyDoKyLuat = lyDoKyLuat;
        }

        public DTO_KyLuat(string noiDungKyLuat, string lyDoKyLuat)
        {
            this.noiDungKyLuat = noiDungKyLuat;
            this.lyDoKyLuat = lyDoKyLuat;
        }

        public int Id { get => id; set => id = value; }
        public string NoiDungKyLuat { get => noiDungKyLuat; set => noiDungKyLuat = value; }
        public string LyDoKyLuat { get => lyDoKyLuat; set => lyDoKyLuat = value; }
    }
}
