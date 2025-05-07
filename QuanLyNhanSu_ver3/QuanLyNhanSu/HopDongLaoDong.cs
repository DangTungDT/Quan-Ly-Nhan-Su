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
    public partial class HopDongLaoDong: Form
    {
        public HopDongLaoDong()
        {
            InitializeComponent();
        }
        BLLXemNhanVien nhanVienBLL = new BLLXemNhanVien();
        BLLHopDongLaoDong bllHopDong = new BLLHopDongLaoDong();
        DTOHopDongLaoDong selectedData = new DTOHopDongLaoDong();
        private void HopDongLaoDong_Load(object sender, EventArgs e)
        {
            dgvHopDong.DataSource = bllHopDong.thongTinHopDong();
            cbbIDNVien.DataSource = nhanVienBLL.ThongTinNhanVien();
            cbbIDNVien.DisplayMember = "TenNhanVien";
            cbbIDNVien.ValueMember = "id";
            //dgvHopDong.Columns["NhanVien"].Visible = false;
            LamMoi();
        }
        public void LamMoi()
        {
            cbbIDNVien.Text = "";
            dtNgayKy.Text = "";
            dtBatDau.Text = "";
            dtKetThuc.Text = "";
            rtLMoTa.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbIDNVien.SelectedValue == null || string.IsNullOrWhiteSpace(cbbIDNVien.Text))
            {
                MessageBox.Show("Vui lòng chọn Nhân viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DTOHopDongLaoDong dtoHDLD = setData();
            var result = bllHopDong.themHopDong(dtoHDLD);
            switch (result)
            {
                case -1:
                    MessageBox.Show("Không thêm được vui lòng thử lại!");
                    break;
                case 0:
                    MessageBox.Show($"Hợp đồng của nhân viên {cbbIDNVien.SelectedText} đã tồn tại!");
                    break;
                case 1:
                    dgvHopDong.DataSource = bllHopDong.thongTinHopDong();
                    LamMoi();
                    break;
                default:
                    break;
            }
        }
        private DTOHopDongLaoDong setData()
        {
            DTOHopDongLaoDong dtoHDLD = new DTOHopDongLaoDong();
            dtoHDLD.IdNhanVien = cbbIDNVien.SelectedValue?.ToString();
            dtoHDLD.NgayKy = dtNgayKy.Value;
            dtoHDLD.NgayBatDau = dtBatDau.Value;
            dtoHDLD.NgayKetThuc = dtKetThuc.Value;
            dtoHDLD.MoTa = rtLMoTa.Text;
            return dtoHDLD;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cbbIDNVien.SelectedValue == null || string.IsNullOrWhiteSpace(cbbIDNVien.Text))
            {
                MessageBox.Show("Vui lòng chọn Nhân viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DTOHopDongLaoDong dtoHDLD = setData();

            if (bllHopDong.suaHopDong(dtoHDLD) == true)
            {
                dgvHopDong.DataSource = bllHopDong.thongTinHopDong();
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
                DTOHopDongLaoDong dtoHDLD = setData();

                if (bllHopDong.xoaHopDong(dtoHDLD) == true) //kiểm tra nếu true đã xóa thành công
                {
                    dgvHopDong.DataSource = bllHopDong.thongTinHopDong();
                    LamMoi();
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

        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idong = e.RowIndex;
            if (idong >= 0 && !dgvHopDong.Rows[idong].IsNewRow)
            {
                var hopDongId = int.Parse(dgvHopDong.Rows[idong].Cells[0].Value.ToString());
                cbbIDNVien.Text = dgvHopDong.Rows[idong].Cells[1].Value.ToString();
                dtNgayKy.Text = dgvHopDong.Rows[idong].Cells[2].Value.ToString();
                dtBatDau.Text = dgvHopDong.Rows[idong].Cells[3].Value.ToString();
                dtKetThuc.Text = dgvHopDong.Rows[idong].Cells[4].Value.ToString();
                //cbbIDNVien.SelectedValue = dgvHopDong.Rows[idong].Cells[5].Value.ToString();
                rtLMoTa.Text = dgvHopDong.Rows[idong].Cells[5].Value.ToString();

                selectedData = new DTOHopDongLaoDong()
                {
                    Id = hopDongId,
                    IdNhanVien = cbbIDNVien.SelectedValue?.ToString(),
                    NgayKy = dtNgayKy.Value,
                    NgayBatDau = dtBatDau.Value,
                    NgayKetThuc = dtKetThuc.Value,
                    MoTa = rtLMoTa.Text,
                };
            }
        }

        private void HopDongLaoDong_FormClosing(object sender, FormClosingEventArgs e)
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
