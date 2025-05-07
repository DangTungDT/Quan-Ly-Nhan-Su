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
    public partial class XemDanhSanhNhanVien: Form
    {
        public XemDanhSanhNhanVien()
        {
            InitializeComponent();
        }

        BLLXemNhanVien nhanVienBLL = new BLLXemNhanVien();
        private void XemDanhSanhNhanVien_Load(object sender, EventArgs e)
        {
            dgvNVien.DataSource = nhanVienBLL.ThongTinNhanVien();
            dgvNVien.Columns["ChucVu"].Visible = false;
            dgvNVien.Columns["Luong"].Visible = false;
            dgvNVien.Columns["PhongBan"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvNVien.DataSource = nhanVienBLL.timNhanVien(txtTimKiem.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //chọn yes or no để thoát or không
            DialogResult tl = MessageBox.Show("bạn có chắc muốn thoát không?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes) //khi chọn yes sẽ thoát khỏi chương trình
            {
                this.Hide();
            }
        }

        private void XemDanhSanhNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Do you want to close?", "Exit",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
