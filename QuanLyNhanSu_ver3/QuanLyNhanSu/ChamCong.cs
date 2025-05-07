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
    public partial class ChamCong: Form
    {
        public ChamCong()
        {
            InitializeComponent();
        }
        BLLXemNhanVien nhanVienBLL = new BLLXemNhanVien();
        BLLChamCong chamCongBLL = new BLLChamCong();
        DTOChamCong selectedValue = new DTOChamCong();
        private void ChamCong_Load(object sender, EventArgs e)
        {
            dgvChamCong.DataSource = chamCongBLL.thongTinChamCong();

            cbbNVien.DataSource = nhanVienBLL.ThongTinNhanVien();
            cbbNVien.DisplayMember = "TenNhanVien";
            cbbNVien.ValueMember = "id";
            //dgvChamCong.Columns["NhanVien"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DTOChamCong dtoData = setChamCong();
            if (chamCongBLL.themChamCong(dtoData))
            {
                dgvChamCong.DataSource = chamCongBLL.thongTinChamCong();
            }
            else
            {
                MessageBox.Show("Không thêm được vui lòng thử lại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có chắc muốn xóa không?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                DTOChamCong dtoData = setChamCong();
                if (chamCongBLL.xoaChamCong(dtoData) == true) //kiểm tra nếu true đã xóa thành công
                {
                    dgvChamCong.DataSource = chamCongBLL.thongTinChamCong();
                }
                else
                {
                    //hiển thị thông báo khi không xóa được
                    MessageBox.Show("Không xóa được vui lòng thử lại!");
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có chắc muốn xóa tất cả không?", "Xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                DTOChamCong dtoData = setChamCong();
                if (chamCongBLL.xoaAllChamCong(dtoData) == true) //kiểm tra nếu true đã xóa thành công
                {
                    dgvChamCong.DataSource = chamCongBLL.thongTinChamCong();
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
            DTOChamCong dtoData = setChamCong();

            if (chamCongBLL.suaChamCong(dtoData) == true)
            {
                dgvChamCong.DataSource = chamCongBLL.thongTinChamCong();
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
        private DTOChamCong setChamCong()
        {
            DTOChamCong dtoChamCong = new DTOChamCong();
            dtoChamCong.IdChamCong = selectedValue.IdChamCong;
            dtoChamCong.IdNhanVien = cbbNVien.SelectedValue?.ToString();
            dtoChamCong.NgayChamCong = dtpNgayChamCong.Value;
            return dtoChamCong;
        }

        private void dgvChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idong = e.RowIndex;
            if (idong >= 0 && !dgvChamCong.Rows[idong].IsNewRow)
            {
                selectedValue.IdChamCong = dgvChamCong.Rows[idong].Cells[0].Value.ToString();
                dtpNgayChamCong.Text = dgvChamCong.Rows[idong].Cells[1].Value.ToString();
                cbbNVien.SelectedValue = dgvChamCong.Rows[idong].Cells[2].Value.ToString();
            }
        }

        private void ChamCong_FormClosing(object sender, FormClosingEventArgs e)
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
