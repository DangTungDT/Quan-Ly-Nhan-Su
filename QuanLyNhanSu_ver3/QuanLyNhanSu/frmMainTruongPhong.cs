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
                item.Hide();
            }
            form.MdiParent = this;
            form.Show();
        }

        private void tsmiChamCong_Click(object sender, EventArgs e)
        {
            frmChamCongNhanVien f = new frmChamCongNhanVien(IDNhanVien);
            f.MdiParent = this;
            f.Show();
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

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiChamCongNhanVien_Click(object sender, EventArgs e)
        {
            ChamCong f = new ChamCong();
            f.MdiParent = this;
            f.Show();
        }

        private void tsmiDanhGiaNhanVien_Click(object sender, EventArgs e)
        {
            DanhGiaNhanVien f = new DanhGiaNhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void tsmiThemNhanVienDuAn_Click(object sender, EventArgs e)
        {
            DuAn_NhanVien f = new DuAn_NhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void tsmiKhenThuong_Click(object sender, EventArgs e)
        {
            frmKhenThuong_NhanVien f = new frmKhenThuong_NhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void tsmiKyLuatNhanVien_Click(object sender, EventArgs e)
        {
            frmKyLuat_NhanVien f = new frmKyLuat_NhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void tsmiXemDSNhanVien_Click(object sender, EventArgs e)
        {
            XemDanhSanhNhanVien f = new XemDanhSanhNhanVien();
            f.MdiParent = this;
            f.Show();
        }
    }
}
