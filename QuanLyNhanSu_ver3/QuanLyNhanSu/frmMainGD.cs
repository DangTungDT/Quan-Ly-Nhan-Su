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

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChamCongNhanVien f = new frmChamCongNhanVien(IDNhanVien);
            f.MdiParent = this;
            f.Show();
        }

        private void frmMainGD_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult question = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (question == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void khenThưởngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhenThuong_NhanVien f = new frmKhenThuong_NhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void kỷLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKyLuat_NhanVien f = new frmKyLuat_NhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void đánhGiáNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhGiaNhanVien f = new DanhGiaNhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void chứcNăngKhácToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tạosửaDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DuAn f = new DuAn();
            f.MdiParent = this;
            f.Show();
        }

        private void thêmNhânViênVàoDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DuAn_NhanVien f = new DuAn_NhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void tàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TaiKhoan f = new TaiKhoan();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmChiTietLuong f = new frmChiTietLuong();
            f.MdiParent = this;
            f.Show();
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Luong f = new Luong();
            f.MdiParent = this;
            f.Show();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhongBan f = new PhongBan();
            f.MdiParent = this;
            f.Show();
        }

        private void chấmCôngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChamCong f = new ChamCong();
            f.MdiParent = this;
            f.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void brToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xemDanhSachsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhSanhNhanVien f = new XemDanhSanhNhanVien();
            f.MdiParent = this;
            f.Show();
        }
    }
}
