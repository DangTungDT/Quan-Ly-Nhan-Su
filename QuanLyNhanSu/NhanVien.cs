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
    public partial class NhanVien : Form
    {
        public BLLCheckDataNV data = new BLLCheckDataNV();

        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                dtGridMainNV.DataSource = data.CheckListNVien();

                cbChucVu.DataSource = data.CheckListCVu();
                cbChucVu.DisplayMember = "id";
                cbChucVu.ValueMember = "id";

                cbPhongBan.DataSource = data.CheckListPBan();
                cbPhongBan.DisplayMember = "id";
                cbPhongBan.ValueMember = "id";

                cbLuong.DataSource = data.CheckListLuong();
                cbLuong.DisplayMember = "id";
                cbLuong.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
                if (ex.InnerException != null)
                {
                    MessageBox.Show("Lỗi: " + ex.InnerException.Message);
                }
            }

        }

        private void NhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void dtGridMainNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e != null)
            {
                txtID.Text = dtGridMainNV.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbChucVu.Text = dtGridMainNV.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbLuong.Text = dtGridMainNV.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbPhongBan.Text = dtGridMainNV.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTenNV.Text = dtGridMainNV.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDiaChi.Text = dtGridMainNV.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtQue.Text = dtGridMainNV.Rows[e.RowIndex].Cells[6].Value.ToString();
                cbGioiTinh.Text = dtGridMainNV.Rows[e.RowIndex].Cells[7].Value.ToString();
                dtNgayTao.Value = DateTime.Parse(dtGridMainNV.Rows[e.RowIndex].Cells[8].Value.ToString());
                txtEmail.Text = dtGridMainNV.Rows[e.RowIndex].Cells[9].Value.ToString();

            }
        }

        // Du lieu nhap them nhan vien
        private void btnThem_Click(object sender, EventArgs e)
        {

            if (data.CheckEmptyXontrol(this.Controls, errorProvider1))
            {
                try
                {
                    DTONhanVien nv = new DTONhanVien(txtID?.Text, cbChucVu?.Text, int.Parse(cbLuong?.Text), cbPhongBan?.Text, txtTenNV.Text, txtDiaChi.Text, txtQue.Text, cbGioiTinh?.Text, dtNgayTao.Value, txtEmail.Text);
                    if (nv != null)
                    {
                        if (data.CheckAddNVien(nv))
                        {
                            MessageBox.Show("Thêm nhân viên thành công");
                            dtGridMainNV.DataSource = data.CheckListNVien();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message);
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show("Lỗi: " + ex.InnerException.Message);
                    }
                }
                finally { Empty(); }
            }
        }


        // Du lieu cap nhat nhan vien
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (data.CheckEmptyXontrol(this.Controls, errorProvider1))
            {
                try
                {
                    DTONhanVien nv = new DTONhanVien(txtID?.Text, cbChucVu?.Text, int.Parse(cbLuong?.Text), cbPhongBan?.Text, txtTenNV.Text, txtDiaChi.Text, txtQue.Text, cbGioiTinh?.Text, dtNgayTao.Value, txtEmail.Text);
                    if (nv != null)
                    {
                        if (data.CheckUpdateNVien(nv))
                        {
                            MessageBox.Show("Cập nhật nhân viên thành công");
                            dtGridMainNV.DataSource = data.CheckListNVien();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật nhân viên: " + ex.Message);
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show("Lỗi: " + ex.InnerException.Message);
                    }
                }
                finally { Empty(); }
            }
        }

        // Xoa nhan vien bang id
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhân viên này không ??", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (data.CheckDeleteNVien(new DTONhanVien(txtID?.Text)))
                    {
                        dtGridMainNV.DataSource = data.CheckListNVien();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Xoá nhân viên: " + ex.Message);
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show("Lỗi: " + ex.InnerException.Message);
                    }
                }
                finally { Empty(); }
            }
        }

        // Lam trong du lieu
        public void Empty()
        {
            txtID.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtQue.Clear();
            txtEmail.Clear();
            cbChucVu.SelectedIndex = -1;
            cbLuong.SelectedIndex = -1;
            cbPhongBan.SelectedIndex = -1;
            cbGioiTinh.SelectedIndex = -1;
        }
    }
}
