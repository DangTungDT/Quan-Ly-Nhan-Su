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
    public partial class DuAn_NhanVien : Form
    {
        public DuAn_NhanVien()
        {
            InitializeComponent();
        }

        BLLXemNhanVien nhanVienBLL = new BLLXemNhanVien();
        BLLDuAnNhanVien duAn_NhanVienBLL = new BLLDuAnNhanVien();
        BLLDuAn duAnBLL = new BLLDuAn();

        DTODuAnNhanVien selectedData = new DTODuAnNhanVien();
        private void DuAn_NhanVien_Load(object sender, EventArgs e)
        {
            dgvDuAnNV.DataSource = duAn_NhanVienBLL.ThongTinDuAnNV();

            cbDuAn.DataSource = duAnBLL.ThongTinDuAn();
            cbDuAn.DisplayMember = "TenDuAn";
            cbDuAn.ValueMember = "id";

            cbIDNVien.DataSource = nhanVienBLL.ThongTinNhanVien();
            cbIDNVien.DisplayMember = "TenNhanVien";
            cbIDNVien.ValueMember = "id";
            dgvDuAnNV.Columns["NhanVien"].Visible = false;
            dgvDuAnNV.Columns["DuAn"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkCondition() == false) return;
            DTODuAnNhanVien dtoDuAnNV = new DTODuAnNhanVien();
            dtoDuAnNV.IdDuAn = cbDuAn.SelectedValue?.ToString();
            dtoDuAnNV.IdNhanVien = cbIDNVien.SelectedValue?.ToString();
            dtoDuAnNV.VaiTroNV = txtVaiTroNV.Text;
            dtoDuAnNV.NgayThamGia = dtBatDau.Value;
            dtoDuAnNV.NgayTao = dtpNgayTao.Value;

            if (duAn_NhanVienBLL.them(dtoDuAnNV) == true)
            {
                dgvDuAnNV.DataSource = duAn_NhanVienBLL.ThongTinDuAnNV();
                MessageBox.Show("Thêm thành công !" ,"Thông báo");

            }
            else
            {
                //hiển thị thông báo khi không thêm được
                MessageBox.Show("Không thêm được vui lòng thử lại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                DTODuAnNhanVien dtoDuAnNV = new DTODuAnNhanVien();
                dtoDuAnNV.IdDuAn = cbDuAn.SelectedValue?.ToString();
                dtoDuAnNV.IdNhanVien = cbIDNVien.SelectedValue?.ToString();

                if (duAn_NhanVienBLL.xoa(dtoDuAnNV) == true) //kiểm tra nếu true đã xóa thành công
                {
                    dgvDuAnNV.DataSource = duAn_NhanVienBLL.ThongTinDuAnNV(); //load lại dữ liệu để hiện thị
                }
                else
                {
                    //hiển thị thông báo khi không xóa được
                    MessageBox.Show("Không xóa được vui lòng thử lại!");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (checkCondition() == false) return;
            DTODuAnNhanVien dtoDuAnNV = new DTODuAnNhanVien();
            if (selectedData != null && (selectedData.IdNhanVien != cbIDNVien.SelectedValue?.ToString() && selectedData.IdDuAn != cbDuAn.SelectedValue?.ToString()))
            {
                MessageBox.Show("Không được thay đổi thông tin Id Nhân viên và Dự án");
                return;
            }
            dtoDuAnNV.IdDuAn = cbDuAn.SelectedValue?.ToString();
            dtoDuAnNV.IdNhanVien = cbIDNVien.SelectedValue?.ToString();
            dtoDuAnNV.VaiTroNV = txtVaiTroNV.Text;
            dtoDuAnNV.NgayThamGia = dtBatDau.Value;
            dtoDuAnNV.NgayTao = dtpNgayTao.Value;

            if (duAn_NhanVienBLL.sua(dtoDuAnNV) == true)
            {
                dgvDuAnNV.DataSource = duAn_NhanVienBLL.ThongTinDuAnNV();
                LamMoi();
            }
            else
            {
                //hiển thị thông báo khi không sửa được
                MessageBox.Show("Không sửa được vui lòng thử lại!");
            }

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

        private void dgvDuAnNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idong = e.RowIndex;

            if (idong >= 0 && !dgvDuAnNV.Rows[idong].IsNewRow)
            {
                //gan du lieu
                cbIDNVien.SelectedValue = dgvDuAnNV.Rows[idong].Cells[0].Value.ToString();
                cbDuAn.SelectedValue = dgvDuAnNV.Rows[idong].Cells[1].Value.ToString();
                txtVaiTroNV.Text = dgvDuAnNV.Rows[idong].Cells[2].Value.ToString();
                dtBatDau.Text = dgvDuAnNV.Rows[idong].Cells[3].Value.ToString();
                dtpNgayTao.Text = dgvDuAnNV.Rows[idong].Cells[4].Value.ToString();

                selectedData = new DTODuAnNhanVien()
                {
                    IdNhanVien = cbIDNVien.SelectedValue?.ToString(),
                    IdDuAn = cbDuAn.SelectedValue?.ToString(),
                    VaiTroNV = txtVaiTroNV.Text,
                    NgayThamGia = dtBatDau.Value,
                    NgayTao = dtpNgayTao.Value,
                };
            }

        }

        private void LamMoi()
        {
            cbDuAn.Text = "";
            cbIDNVien.Text = "";
            txtVaiTroNV.Text = "";
            dtBatDau.Text = "";
            dtpNgayTao.Text = "";

        }

        private void DuAn_NhanVien_FormClosing(object sender, FormClosingEventArgs e)
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
        private bool checkCondition()
        {
            // Kiểm tra null cho combobox và textbox
            if (cbDuAn.SelectedValue == null || string.IsNullOrWhiteSpace(cbDuAn.Text))
            {
                MessageBox.Show("Vui lòng chọn Dự án!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbIDNVien.SelectedValue == null || string.IsNullOrWhiteSpace(cbIDNVien.Text))
            {
                MessageBox.Show("Vui lòng chọn Nhân viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtVaiTroNV.Text))
            {
                MessageBox.Show("Vui lòng nhập Vai trò nhân viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
