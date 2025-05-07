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
    public partial class DuAn: Form
    {
        //Biến toàn cục
        BLLDuAn duAnBLL = new BLLDuAn();
        public DuAn()
        {
            InitializeComponent();
        }

        private void dtpNgayTao_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DuAn_Load(object sender, EventArgs e)
        {
            dgvDuAn.DataSource = duAnBLL.ThongTinDuAn();
        }

        private void dgvDuAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idong = e.RowIndex;

            if (idong >= 0 && !dgvDuAn.Rows[idong].IsNewRow)
            {
                //gan du lieu
                txtIdDuAn.Text = dgvDuAn.Rows[idong].Cells[0].Value.ToString();
                txtTenDuAn.Text = dgvDuAn.Rows[idong].Cells[1].Value.ToString();
                rtLMoTa.Text = dgvDuAn.Rows[idong].Cells[2].Value.ToString();
                dtBatDau.Text = dgvDuAn.Rows[idong].Cells[3].Value.ToString();
                dtKetThuc.Text = dgvDuAn.Rows[idong].Cells[4].Value.ToString();
                cbbTrangThai.SelectedItem = dgvDuAn.Rows[idong].Cells[5].Value.ToString();
                dtpNgayTao.Text = dgvDuAn.Rows[idong].Cells[6].Value.ToString();

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường dữ liệu không được để trống
            if (string.IsNullOrWhiteSpace(txtIdDuAn.Text) ||
                string.IsNullOrWhiteSpace(txtTenDuAn.Text) ||
                string.IsNullOrWhiteSpace(rtLMoTa.Text) ||
                cbbTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin dự án!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DTODuAn dtoDuAn = new DTODuAn();
            dtoDuAn.IdDuAn = txtIdDuAn.Text;
            dtoDuAn.TenDuAn = txtTenDuAn.Text;
            dtoDuAn.MoTa = rtLMoTa.Text;
            dtoDuAn.NgayBD = dtBatDau.Value;
            dtoDuAn.NgayKT = dtKetThuc.Value;
            dtoDuAn.TrangThai = cbbTrangThai.SelectedItem?.ToString() ?? "";
            dtoDuAn.NgayTao = dtpNgayTao.Value;

            if (duAnBLL.them(dtoDuAn) == true)
            {
                dgvDuAn.DataSource = duAnBLL.ThongTinDuAn();

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
                DTODuAn dtoDuAn = new DTODuAn();
                dtoDuAn.IdDuAn = txtIdDuAn.Text;

                if (duAnBLL.xoa(dtoDuAn) == true) //kiểm tra nếu true đã xóa thành công
                {
                    dgvDuAn.DataSource = duAnBLL.ThongTinDuAn(); //load lại dữ liệu để hiện thị
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
            // Kiểm tra các trường dữ liệu không được để trống
            if (string.IsNullOrWhiteSpace(txtIdDuAn.Text) ||
                string.IsNullOrWhiteSpace(txtTenDuAn.Text) ||
                string.IsNullOrWhiteSpace(rtLMoTa.Text) ||
                cbbTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin dự án!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DTODuAn dtoDuAn = new DTODuAn();
            dtoDuAn.IdDuAn = txtIdDuAn.Text;
            dtoDuAn.TenDuAn = txtTenDuAn.Text;
            dtoDuAn.MoTa = rtLMoTa.Text;
            dtoDuAn.NgayBD = dtBatDau.Value;
            dtoDuAn.NgayKT = dtKetThuc.Value;
            dtoDuAn.TrangThai = cbbTrangThai.SelectedItem?.ToString() ?? "";
            dtoDuAn.NgayTao = dtpNgayTao.Value;

            if (duAnBLL.sua(dtoDuAn) == true)
            {
                dgvDuAn.DataSource = duAnBLL.ThongTinDuAn();
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

        private void LamMoi()
        {
            txtIdDuAn.Text = "";
            txtTenDuAn.Text = "";
            rtLMoTa.Text = "";
            dtBatDau.Text = "";
            dtKetThuc.Text = "";
            cbbTrangThai.SelectedItem = "Chưa thực hiện";
            dtpNgayTao.Text = "";
        }

        private void DuAn_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
