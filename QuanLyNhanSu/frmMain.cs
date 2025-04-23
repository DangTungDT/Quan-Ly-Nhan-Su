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

        public void FormChild(Form form)
        {
            foreach (var item in this.MdiChildren)
            {
                item.Hide();
            }
            form.MdiParent = this;
            form.Show();
        }

        private void nhânViênChấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new frmChamCongNhanVien());

        }

        private void chấmCôngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormChild(new ChamCong());
        }

        private void đánhGiáNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormChild(new DanhGiaNhanVien());
        }

        private void dựÁnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormChild(new DuAn());
        }

        private void dựÁnToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormChild(new DuAn_NhanVien());
        }

        private void hợpĐồngLaoĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new HopDongLaoDong());
        }

        private void khenThưởngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormChild(new KhenThuong());
        }

        private void kỷLuậtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormChild(new KyLuat());
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new Luong());
        }

        private void nghĩPhépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new NghiPhep());
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new NhanVien());
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new PhongBan());
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new TaiKhoan());
        }

        private void inDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild(new XemDanhSanhNhanVien());
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
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

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
