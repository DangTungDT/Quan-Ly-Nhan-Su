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
    public partial class frmMainGD : Form
    {
        //Biến toàn cục
        string IDNhanVien;

        public frmMainGD(string id)
        {
            InitializeComponent();
            IDNhanVien = id;
        }
        public frmMainGD()
        {
            InitializeComponent();
        }

       
        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInDanhSachNhanVien f = new frmInDanhSachNhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void danhSáchPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInDanhSachPhongBan f = new frmInDanhSachPhongBan();
            f.MdiParent = this;
            f.Show();
        }

        private void frmMainGD_Load(object sender, EventArgs e)
        {

        }
    }
}
