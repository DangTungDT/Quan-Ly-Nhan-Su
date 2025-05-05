using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class DangNhap : Form
    {
        public BLLCheckDataTK tk = new BLLCheckDataTK();

        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
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

        // Dang nhap lay gia tri id cua nhan vien (chuc vu duoc hien thi sau ky hieu " _ " chi la dau hieu cho biet vi tri cua nhan vien la gi)
        // Viec xoa di id Chuc vu ko anh huong den kiem tra so sanh du lieu cua ma nhan vien
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (tk.CheckEmptyControl(this.Controls, errorProvider1))
                {
                    var IDNhanVien = !string.IsNullOrWhiteSpace(txtTK.Text) ? txtTK.Text.ToUpper().Trim() : string.Empty;
                    var account = tk.CheckGetAllTKhoan().Where(p => p.IDNhanVien == IDNhanVien).FirstOrDefault();
                    var taiKhoan = account.IDNhanVien;
                    var matKhau = account.MatKhau;

                    if (ckXacThuc.Checked)
                    {
                        if (taiKhoan.Equals(txtTK.Text.Trim().ToUpper()) && matKhau.Equals(txtMK.Text.Trim()))
                        {
                            MessageBox.Show("Đăng nhập thành công");
                            new frmMain().Show();
                            this.Hide();
                        }
                        else MessageBox.Show("Đăng nhập thất bại");
                    }
                    else MessageBox.Show("Bạn chưa xác thực tài khoản");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
                if (ex.InnerException != null)
                {
                    MessageBox.Show("Lỗi chi tiết: " + ex.InnerException.Message);
                }
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        // Gan gia tri nhanh khi truy van ra duoc id nhan vien va gan chuc vu vao txtTK
        private void txtTK_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var IDNhanVien = !string.IsNullOrWhiteSpace(txtTK.Text) ? txtTK.Text.ToUpper().Trim() : string.Empty;
                var Account = tk.CheckGetAllTKhoan().Where(p => p.IDNhanVien == IDNhanVien).Select(p => p.IDNhanVien).FirstOrDefault();

                if (Account != null)
                {
                    txtTK.Text = Account.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Gan mat khau nhanh cho txtMK cua txtTK


        private void rdXacThuc_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ckXacThuc_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
