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

        private void FormChild(Form form)
        {
            foreach (var item in this.MdiChildren)
            {
                item.Close();
            }
            form.MdiParent = this;
            form.Show();
        }

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
            FormChild(new frmInDanhSachNhanVien());
        }

        private void danhSáchPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new frmInDanhSachPhongBan());
        }

        private void frmMainGD_Load(object sender, EventArgs e)
        {

        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new frmChamCongNhanVien(IDNhanVien));
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
            FormChild(new frmKhenThuong_NhanVien());
        }

        private void kỷLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new frmKyLuat_NhanVien());
        }

        private void đánhGiáNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new DanhGiaNhanVien());
        }

        private void chứcNăngKhácToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tạosửaDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new DuAn());
        }

        private void thêmNhânViênVàoDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new DuAn_NhanVien());
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void tàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormChild(new TaiKhoan());
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormChild(new frmChiTietLuong());
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new Luong());
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new PhongBan());
        }

        private void chấmCôngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormChild(new ChamCong());
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
            FormChild(new XemDanhSanhNhanVien());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormChild(new frmXinNghiPhep(IDNhanVien));
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new frmInThongTinCaNhan(IDNhanVien));
        }

        private void duyệtNghỉPhépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new frmDuyetNghiPhep(IDNhanVien));
        }

        private void xemNghỉPhépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new frmXemNghiPhep(IDNhanVien));
        }
    }
}
