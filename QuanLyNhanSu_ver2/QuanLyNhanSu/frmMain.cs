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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void nhânViênChấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChamCongNhanVien f = new frmChamCongNhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void chấmCôngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChamCong f = new ChamCong();
            f.MdiParent = this;
            f.Show();
        }

        private void đánhGiáNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DanhGiaNhanVien f = new DanhGiaNhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void dựÁnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DuAn f = new DuAn();
            f.MdiParent = this;
            f.Show();
        }

        private void dựÁnToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DuAn_NhanVien f = new DuAn_NhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void hợpĐồngLaoĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HopDongLaoDong f = new HopDongLaoDong();
            f.MdiParent = this;
            f.Show();
        }

        private void khenThưởngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            KhenThuong f = new KhenThuong();
            f.MdiParent = this;
            f.Show();
        }

        private void kỷLuậtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            KyLuat f = new KyLuat();
            f.MdiParent = this;
            f.Show();
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Luong f = new Luong();
            f.MdiParent = this;
            f.Show();
        }

        private void nghĩPhépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NghiPhep f = new NghiPhep();
            f.MdiParent = this;
            f.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien f = new NhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhongBan f = new PhongBan();
            f.MdiParent = this;
            f.Show();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaiKhoan f = new TaiKhoan();
            f.MdiParent = this;
            f.Show();
        }

        private void inDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhSanhNhanVien f = new XemDanhSanhNhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult question = MessageBox.Show("Bạn có muốn thoát ?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(question == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
