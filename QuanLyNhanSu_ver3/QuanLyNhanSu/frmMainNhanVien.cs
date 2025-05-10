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
    public partial class frmMainNhanVien : Form
    {

        //Biến toàn cục
        string IDNhanVien;

        public frmMainNhanVien(string id)
        {
            InitializeComponent();
            IDNhanVien = id;
        }
        public frmMainNhanVien()
        {
            InitializeComponent();
        }

        private void frmMainNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void tsmiChamCong2_Click(object sender, EventArgs e)
        {
            ShowForm(new frmChamCongNhanVien(IDNhanVien));
        }

        private void frmMainNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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

        private void tsmiChamCong_Click(object sender, EventArgs e)
        {
            ShowForm(new frmChamCongNhanVien(IDNhanVien));
        }

        private void tsmiThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inThôngTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void thôngTinNhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowForm(new frmInThongTinCaNhan(IDNhanVien));
        }

        private void ShowForm(Form form)
        {
            foreach (var item in this.MdiChildren)
            {
                item.Close();
            }
            form.MdiParent = this;
            form.Show();
        }

        private void chứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsmiNghiPhep_Click(object sender, EventArgs e)
        {
            ShowForm(new frmXinNghiPhep(IDNhanVien));
        }

        private void xemNghỉPhépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new frmXemNghiPhep(IDNhanVien));
        }
    }
}
