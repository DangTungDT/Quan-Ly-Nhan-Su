using BLL;
using DTO;
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
    public partial class TaiKhoan: Form
    {
        public TaiKhoan()
        {
            InitializeComponent();
        }
        BLLXemNhanVien nhanVienBLL = new BLLXemNhanVien();
        BLLTaiKhoan bllTaiKhoan = new BLLTaiKhoan();
        DTOTaiKhoan selectedData = new DTOTaiKhoan();
        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            dgvMainTK.DataSource = bllTaiKhoan.getThongTinTaiKhoan();

            cbbIDNVien.DataSource = nhanVienBLL.ThongTinNhanVien();
            cbbIDNVien.DisplayMember = "TenNhanVien";
            cbbIDNVien.ValueMember = "id";
            //dgvMainTK.Columns["NhanVien"].Visible = false;
            LamMoi();
        }

        private void dgvMainTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idong = e.RowIndex;
            if (idong >= 0 && !dgvMainTK.Rows[idong].IsNewRow)
            {
                var taiKhoanId = int.Parse(dgvMainTK.Rows[idong].Cells[0].Value.ToString());
                //cbIDNVien.SelectedValue = dgvMainTK.Rows[idong].Cells[0].Value.ToString();
                cbbIDNVien.SelectedValue = dgvMainTK.Rows[idong].Cells[1].Value.ToString();
                txtTaiKhoan.Text = dgvMainTK.Rows[idong].Cells[3].Value.ToString();
                txtMK.Text = dgvMainTK.Rows[idong].Cells[4].Value.ToString();

                selectedData = new DTOTaiKhoan()
                {
                    ID = taiKhoanId,
                    IDNhanVien = cbbIDNVien.SelectedValue?.ToString(),
                    TaiKhoan = txtTaiKhoan.Text,
                    MatKhau = txtMK.Text,
                };
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTOTaiKhoan dtoTK = new DTOTaiKhoan();
            dtoTK.IDNhanVien = cbbIDNVien.SelectedValue?.ToString();
            dtoTK.TaiKhoan = txtTaiKhoan.Text;
            dtoTK.MatKhau = txtMK.Text;
            int result = bllTaiKhoan.themTaiKhoan(dtoTK);
            switch (result)
            {
                case -1:
                    MessageBox.Show("Không thêm được vui lòng thử lại!");
                    break;
                case 0:
                    MessageBox.Show($"Tài khoản {txtTaiKhoan.Text} đã tồn tại!");
                    break;
                case 1:
                    dgvMainTK.DataSource = bllTaiKhoan.getThongTinTaiKhoan();
                    LamMoi();
                    break;
                default:
                    break;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTOTaiKhoan dtoTK = new DTOTaiKhoan();
            if (selectedData != null && (selectedData.TaiKhoan != txtTaiKhoan.Text))
            {
                MessageBox.Show("Không được thay đổi thông tin Tài khoản");
                return;
            }
            dtoTK.IDNhanVien = cbbIDNVien.SelectedValue?.ToString();
            dtoTK.TaiKhoan = txtTaiKhoan.Text;
            dtoTK.MatKhau = txtMK.Text;
            if (bllTaiKhoan.sua(dtoTK) == true)
            {
                dgvMainTK.DataSource = bllTaiKhoan.getThongTinTaiKhoan();
                LamMoi();
            }
            else
            {
                //hiển thị thông báo khi không sửa được
                MessageBox.Show("Không sửa được vui lòng thử lại!");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                DTOTaiKhoan dtoTK = new DTOTaiKhoan();
                dtoTK.IDNhanVien = cbbIDNVien.SelectedValue?.ToString();

                if (bllTaiKhoan.xoa(dtoTK) == true) //kiểm tra nếu true đã xóa thành công
                {
                    dgvMainTK.DataSource = bllTaiKhoan.getThongTinTaiKhoan();
                }
                else
                {
                    //hiển thị thông báo khi không xóa được
                    MessageBox.Show("Không xóa được vui lòng thử lại!");
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            //chọn yes or no để thoát or không
            DialogResult tl = MessageBox.Show("bạn có chắc muốn thoát không?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes) //khi chọn yes sẽ thoát khỏi chương trình
            {
                this.Hide();
            }
        }

        public void LamMoi()
        {
            cbbIDNVien.Text = "";
            txtTaiKhoan.Text = "";
            txtMK.Text = "";
        }

        private void cbbIDNVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbIDNVien.SelectedValue != null)
            {
                txtTaiKhoan.Text = cbbIDNVien.SelectedValue.ToString();
            }
        }

        private void TaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            //chọn yes or no để thoát or không
            DialogResult r;
            r = MessageBox.Show("Do you want to close?", "Exit",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
