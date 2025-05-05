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
        public BLLCheckDataNV nv = new BLLCheckDataNV();

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
                errorProvider1.Clear();

                if (txtTK.Text == string.Empty)
                {
                    errorProvider1.SetError(txtTK, "Tài khoản của bạn đang trống");
                }
                else if (txtMK.Text == string.Empty)
                {
                    errorProvider1.SetError(txtMK, "Mật khẩu của bạn đang trống");
                }
                else
                {
                    var taiKhoan = !string.IsNullOrWhiteSpace(txtTK.Text) ? txtTK.Text.ToUpper().Trim() : string.Empty;
                    var position = nv.CheckListNVien().Where(p => taiKhoan.Contains(p.ID)).Select(p => p.ID).FirstOrDefault();

                    if (position == txtMK.Text.Split('_')[0])
                    {
                        if (rdXacThuc.Checked)
                        {
                            MessageBox.Show("Đăng nhập thành công");
                            new frmMain().Show();
                            this.Hide();
                        }
                        else MessageBox.Show("Bạn chưa xác thực tài khoản");
                    }
                    else MessageBox.Show("Đăng nhập thất bại");
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

            //new frmMain().Show();
            //this.Hide();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        // Gan gia tri nhanh khi truy van ra duoc id nhan vien va gan chuc vu vao txtTK
        private void txtTK_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var taiKhoan = !string.IsNullOrWhiteSpace(txtTK.Text) ? txtTK.Text.ToUpper().Trim() : string.Empty;
                var position = nv.CheckListNVien().Where(p => p.ID == taiKhoan).Select(p => p.IDChucVu).FirstOrDefault();

                if (position != null)
                {
                    txtTK.Text = taiKhoan + "_" + position;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Gan mat khau nhanh cho txtMK cua txtTK
        private void ckMK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckMK.Checked)
            {
                txtMK.Text = txtTK.Text;
            }
            else txtMK.Text = string.Empty;
        }

        private void rdXacThuc_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
