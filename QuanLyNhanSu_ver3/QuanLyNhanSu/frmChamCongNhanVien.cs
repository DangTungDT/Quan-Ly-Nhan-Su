using BLL;
using DTO;
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
    public partial class frmChamCongNhanVien : Form
    {
        //Biến toàn cục
        BLLChamCongNhanVien bll = new BLLChamCongNhanVien();
        string idNhanVien;

        public frmChamCongNhanVien()
        {
            InitializeComponent();
        }

        public frmChamCongNhanVien(string id)
        {
            InitializeComponent();
            idNhanVien = id;
        }
        private void frmChamCongNhanVien_Load(object sender, EventArgs e)
        {
            DTONhanVienChamCong nhanVien = bll.LoadNhanVienByID(idNhanVien);
            txtID.Text = nhanVien.Id;
            txtTenNhanVien.Text = nhanVien.TenNhanVien;
            dtpNgayChamCong.Text = DateTime.Now.ToString();

        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {

        }
    }
}
