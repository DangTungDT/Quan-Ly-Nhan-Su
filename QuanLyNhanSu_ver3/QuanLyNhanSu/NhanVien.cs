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
    public partial class NhanVien: Form
    {
        //Biến toàn cục
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
                cbChucVu.DisplayMember = "TenChucVu";
                cbChucVu.ValueMember = "id";

                cbPhongBan.DataSource = data.CheckListPBan();
                cbPhongBan.DisplayMember = "TenPhongBan";
                cbPhongBan.ValueMember = "id";

                cbLuong.DataSource = data.CheckListLuong();
                cbLuong.DisplayMember = "SoTienLuong";
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

        // Kiem tra du lieu trong trong Form
        public bool CheckEmptyControl()
        {
            bool ktra = true;
            errorProvider1.Clear();

            foreach (var item in Controls)
            {
                if (item is TextBox text && string.IsNullOrWhiteSpace(text.Text))
                {
                    if (text.Name == "txtTim")
                    {
                        continue;
                    }

                    errorProvider1.SetError(text, $"Empty {text.Name.Substring(3)} !!!");
                    ktra = false;
                }

                if (item is ComboBox combo && string.IsNullOrWhiteSpace(combo.Text))
                {
                    errorProvider1.SetError(combo, $"Empty {combo.Name.Substring(2)} !!!");
                    ktra = false;
                }
            }

            return ktra;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckEmptyControl())
            {
                try
                {
                    var chucVu = cbChucVu.SelectedValue?.ToString();
                    int.TryParse(cbLuong.SelectedValue?.ToString(), out int luong);
                    var phongBan = cbPhongBan.SelectedValue?.ToString();

                    if (chucVu != null && luong != 0 && phongBan != null)
                    {
                        if (data.CheckAddNVien(new DTONhanVien(txtID?.Text, chucVu, luong, phongBan, txtTenNV.Text, txtDiaChi.Text, txtQue.Text, cbGioiTinh?.Text, dtNgayTao.Value, txtEmail.Text)))
                        {
                            dtGridMainNV.DataSource = data.CheckListNVien();
                            MessageBox.Show("Thêm nhân viên thành công");
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
            if (CheckEmptyControl())
            {
                try
                {
                    var chucVu = cbChucVu.SelectedValue?.ToString();
                    int.TryParse(cbLuong.SelectedValue?.ToString(), out int luong);
                    var phongBan = cbPhongBan.SelectedValue?.ToString();
                    if (chucVu != null && luong != 0 && phongBan != null)
                    {
                        if (data.CheckAddNVien(new DTONhanVien(txtID?.Text, chucVu, luong, phongBan, txtTenNV.Text, txtDiaChi.Text, txtQue.Text, cbGioiTinh?.Text, dtNgayTao.Value, txtEmail.Text)))
                        {
                            dtGridMainNV.DataSource = data.CheckListNVien();
                            MessageBox.Show("Cập nhật nhân viên thành công");
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

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            FindFGeneral();
        }

        public void FindFGeneral()
        {
            try
            {
                var listNV = data.CheckListNVien().Where(p => p.ID.Contains(txtTim.Text.ToUpper())).ToList();

                if (listNV != null && listNV.Count > 0)
                {
                    dtGridMainNV.DataSource = listNV;
                }
                else
                {
                    dtGridMainNV.DataSource = data.CheckListNVien();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi tìm nhân viên: " + ex.Message);
                if (ex.InnerException != null)
                {
                    MessageBox.Show("Lỗi: " + ex.InnerException.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhân viên này không ?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (data.CheckDeleteNVien(new DTONhanVien(txtID?.Text)))
                    {
                        dtGridMainNV.DataSource = data.CheckListNVien();
                        MessageBox.Show("Xóa dữ liệu nhân viên thành công");
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
                cbChucVu.SelectedValue = dtGridMainNV.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbLuong.SelectedValue = int.Parse(dtGridMainNV.Rows[e.RowIndex].Cells[2].Value.ToString());
                cbPhongBan.SelectedValue = dtGridMainNV.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTenNV.Text = dtGridMainNV.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDiaChi.Text = dtGridMainNV.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtQue.Text = dtGridMainNV.Rows[e.RowIndex].Cells[6].Value.ToString();
                cbGioiTinh.Text = dtGridMainNV.Rows[e.RowIndex].Cells[7].Value.ToString();
                dtNgayTao.Value = DateTime.Parse(dtGridMainNV.Rows[e.RowIndex].Cells[8].Value.ToString());
                txtEmail.Text = dtGridMainNV.Rows[e.RowIndex].Cells[9].Value.ToString();

            }
        }
    }
}
