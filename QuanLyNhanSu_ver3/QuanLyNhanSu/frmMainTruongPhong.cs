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
    public partial class frmMainTruongPhong : Form
    {

        //Biến toàn cục
        string IDNhanVien;
        public frmMainTruongPhong(string id)
        {
            InitializeComponent();
            IDNhanVien = id;
        }
        public frmMainTruongPhong()
        {
            InitializeComponent();
        }

        private void frmMainTruongPhong_Load(object sender, EventArgs e)
        {

        }
        public void FormChild(Form form)
        {
            foreach (var item in this.MdiChildren)
            {
                item.Close();
            }
            form.MdiParent = this;
            form.Show();
        }

        private void tsmiChamCong_Click(object sender, EventArgs e)
        {
            FormChild(new frmChamCongNhanVien(IDNhanVien));
        }

        private void frmMainTruongPhong_FormClosing(object sender, FormClosingEventArgs e)
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new frmInDanhSachNhanVien());
        }

        private void danhSáchPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new frmInDanhSachPhongBan());
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiChamCongNhanVien_Click(object sender, EventArgs e)
        {
            FormChild(new ChamCong());
        }

        private void tsmiDanhGiaNhanVien_Click(object sender, EventArgs e)
        {
            FormChild(new DanhGiaNhanVien());
        }

        private void tsmiThemNhanVienDuAn_Click(object sender, EventArgs e)
        {
            FormChild(new DuAn_NhanVien());
        }

        private void tsmiKhenThuong_Click(object sender, EventArgs e)
        {
            FormChild(new frmKhenThuong_NhanVien());
        }

        private void tsmiKyLuatNhanVien_Click(object sender, EventArgs e)
        {
            FormChild(new frmKyLuat_NhanVien());
        }

        private void tsmiXemDSNhanVien_Click(object sender, EventArgs e)
        {
            FormChild(new XemDanhSanhNhanVien());
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new frmInThongTinCaNhan(IDNhanVien));
        }

        private void xemThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xinNghỉPhépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new frmXinNghiPhep(IDNhanVien));
        }

        private void duyệtNghỉPhépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new frmDuyetNghiPhep(IDNhanVien));
        }

        private void xemNghỉPhépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new frmXemNghiPhep(IDNhanVien));
        }

        private void xemHợpĐồngLaoĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
