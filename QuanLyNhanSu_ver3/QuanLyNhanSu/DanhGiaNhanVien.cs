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
    public partial class DanhGiaNhanVien: Form
    {
        public BLLCheckDataDGNV dg = new BLLCheckDataDGNV();
        public DanhGiaNhanVien()
        {
            InitializeComponent();
        }

        private void DanhGiaNhanVien_Load(object sender, EventArgs e)
        {
            dtGridMainDG.DataSource = dg.CheckGetAllDGNV();

            cbNguoiDanhGia.DataSource = dg.CheckListNVien().Where(p => p.ID.Contains("TP")).ToList();
            cbNguoiDanhGia.DisplayMember = "TenNhanVien";
            cbNguoiDanhGia.ValueMember = "id";
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        // Kiem tra du lieu trong trong Form
        public bool CheckEmptyXontrol()
        {
            bool ktra = true;
            errorProvider1.Clear();

            foreach (var item in Controls)
            {
                if (item is TextBox text && string.IsNullOrWhiteSpace(text.Text))
                {
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

        // Nhap du lieu them danh gia nhan vien
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckEmptyXontrol())
            {
                try
                {
                    if (dg.CheckAddDGNVien(new DTODanhGiaNV(int.Parse(txtDiemSo.Text), dg.CheckConvertNameToINVien(cbNguoiDanhGia.Text), dg.CheckConvertNameToINVien(cbNhanVien.Text), rtNhanXet.Text, dtNgayTao.Value)))
                    {
                        dtGridMainDG.DataSource = dg.CheckGetAllDGNV();
                        MessageBox.Show("Thêm dữ liệu thành công !!!");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                    return;
                }
                finally { Empty(); }
            }
        }

        // Nhap du lieu cap nhat nghi phep nhan vien
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng nhập id đánh giá để sửa thông tin !!!");
                return;
            }
            if (CheckEmptyXontrol())
            {
                try
                {
                    if (dg.CheckUpdateDGNVien(new DTODanhGiaNV(int.Parse(txtID.Text), int.Parse(txtDiemSo.Text), dg.CheckConvertNameToINVien(cbNguoiDanhGia.Text), dg.CheckConvertNameToINVien(cbNhanVien.Text), rtNhanXet.Text, dtNgayTao.Value)))
                    {
                        dtGridMainDG.DataSource = dg.CheckGetAllDGNV();
                        MessageBox.Show("Cập nhật dữ liệu thành công !!!");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                    return;
                }
                finally { Empty(); }
            }
        }

        // Nhap du lieu xoa nghi phep nhan vien
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muôn xóa dữ liệu đánh giá này không ??", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtID.Text))
                    {
                        MessageBox.Show("Vui lòng nhập id đánh giá để xóa thông tin !!!");
                        return;
                    }

                    if (dg.CheckDeleteDGNVien(new DTODanhGiaNV(int.Parse(txtID.Text))))
                    {
                        dtGridMainDG.DataSource = dg.CheckGetAllDGNV();
                        MessageBox.Show("Xóa dữ liệu thành công !!!");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                    return;
                }
                finally { Empty(); }
            }
        }

        private void dtGridMainDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e != null)
            {
                txtID.Text = dtGridMainDG.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDiemSo.Text = dtGridMainDG.Rows[e.RowIndex].Cells[1].Value.ToString();
                rtNhanXet.Text = dtGridMainDG.Rows[e.RowIndex].Cells[4].Value.ToString();
                dtNgayTao.Value = DateTime.Parse(dtGridMainDG.Rows[e.RowIndex].Cells[5].Value.ToString());

                var idDanhGia = dtGridMainDG.Rows[e.RowIndex].Cells[2].Value.ToString();
                //MessageBox.Show(idDanhGia);

                cbNguoiDanhGia.DataSource = dg.CheckListNVien().Where(p => p.ID.Contains("TP")).ToList();
                cbNguoiDanhGia.DisplayMember = "TenNhanVien";
                cbNguoiDanhGia.ValueMember = "id";

                if (!string.IsNullOrEmpty(idDanhGia))
                {
                    cbNguoiDanhGia.SelectedValue = idDanhGia;
                }
                else cbNguoiDanhGia.SelectedIndex = -1;

                if (cbNguoiDanhGia.SelectedValue != null)
                {
                    var major = cbNguoiDanhGia.SelectedValue.ToString().Substring(2, 4);
                    cbNhanVien.DataSource = dg.CheckListNVien().Where(p => p.ID.Contains(major)).ToList();

                    cbNhanVien.DisplayMember = "TenNhanVien";
                    cbNhanVien.ValueMember = "id";

                    var idNhanVien = dtGridMainDG.Rows[e.RowIndex].Cells[3].Value.ToString();
                    //MessageBox.Show(idNhanVien);
                    if (!string.IsNullOrEmpty(idNhanVien))
                    {
                        cbNhanVien.SelectedValue = idNhanVien;
                    }
                    else cbNhanVien.SelectedIndex = -1;
                }
                else
                {
                    cbNhanVien.DataSource = null;
                    cbNhanVien.SelectedIndex = -1;
                }


            }
        }

        // Khi chon truong phong de danh gia se hien thi danh sach nhan vien duoc quan li boi truong phong
        private void cbNguoiDanhGia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbNguoiDanhGia.SelectedValue != null)
            {
                var major = cbNguoiDanhGia.SelectedValue.ToString().Substring(2, 4);
                cbNhanVien.DataSource = dg.CheckListNVien().Where(p => p.ID.Contains(major)).ToList();

                cbNhanVien.DisplayMember = "TenNhanVien";
                cbNhanVien.ValueMember = "id";
            }
        }

        private void Empty()
        {
            txtID.Clear();
            txtDiemSo.Clear();
            rtNhanXet.Clear();
            cbNhanVien.SelectedIndex = -1;
            cbNguoiDanhGia.SelectedIndex = -1;
        }


    }
}
