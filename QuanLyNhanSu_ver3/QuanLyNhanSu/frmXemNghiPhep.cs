using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class frmXemNghiPhep : Form
    {
        //Global Variable
        string GIDNhanVien;
        BLLCheckDataNP GBLL = new BLLCheckDataNP();
        public frmXemNghiPhep()
        {
            InitializeComponent();
        }

        public frmXemNghiPhep(string id)
        {
            InitializeComponent();
            GIDNhanVien = id;
        }

        private void frmXemNghiPhep_Load(object sender, EventArgs e)
        {
            dgvNghiPhep.DataSource = GBLL.getNghiPhepByID(GIDNhanVien);
                
        }
    }
}
