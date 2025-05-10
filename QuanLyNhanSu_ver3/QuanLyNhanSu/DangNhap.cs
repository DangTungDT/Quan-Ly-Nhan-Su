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
    public partial class DangNhap: Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        //Biến toàn cục
        public BLLCheckDataTK tk = new BLLCheckDataTK();

        // Kiem tra du lieu trong trong Form
        public bool CheckEmptyControl()
        {
            bool ktra = true;
            errorProvider1.Clear();

            foreach (var item in this.Controls)
            {
                if (item is TextBox text && string.IsNullOrWhiteSpace(text.Text))
                {
                    errorProvider1.SetError(text, $"Empty {text.Name.Substring(3)} !!!");
                    ktra = false;
                }
            }

            return ktra;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckEmptyControl())
                {
                    var IDNhanVien = !string.IsNullOrWhiteSpace(txtTK.Text) ? txtTK.Text.ToUpper().Trim() : string.Empty;
                    if(tk.CheckGetAllTKhoan().Where(p => p.IDNhanVien == IDNhanVien).FirstOrDefault() == null) 
                    { 
                       MessageBox.Show("Đăng nhập thất bại");
                        return;
                    }
                    var account = tk.CheckGetAllTKhoan().Where(p => p.IDNhanVien == IDNhanVien).FirstOrDefault();
                    var taiKhoan = account.IDNhanVien;
                    var matKhau = account.MatKhau;

                    if (ckXacThuc.Checked)
                    {
                        if (taiKhoan.Equals(txtTK.Text.Trim().ToUpper()) && matKhau.Equals(txtMK.Text.Trim()))
                        {
                            MessageBox.Show("Đăng nhập thành công");
                            
                            //Phân biệt loại nhân viên để mở đúng form
                            if(IDNhanVien.Substring(0,2).ToUpper() == "TP") 
                            {
                                //Xuất form của trưởng phòng
                                new frmMainTruongPhong(IDNhanVien).Show();
                            }else if(IDNhanVien.Substring(0,2).ToUpper() == "NV")
                            {
                                //Xuất form của nhân viên
                                new frmMainNhanVien(IDNhanVien).Show();
                            }
                            else 
                            {
                                //Xuất form của giám đốc
                                new frmMainGD(IDNhanVien).Show();
                            }
                            //Ẩn form hiện tại để chỉ xuất hiện form main
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

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
