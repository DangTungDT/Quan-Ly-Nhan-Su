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
    public partial class NghiPhep: Form
    {
        //Biến toàn cục
        public BLLCheckDataNP np = new BLLCheckDataNP();
        public NghiPhep()
        {
            InitializeComponent();
        }



        private void NghiPhep_Load(object sender, EventArgs e)
        {
            dtGridMainNP.DataSource = np.CheckGetAllNPhep();

            cbLoaiNghi.DataSource = np.CheckGetAllNPhep();
            cbLoaiNghi.DisplayMember = "LoaiNghiPhep";
            cbLoaiNghi.ValueMember = "id";
        }

        // Nhap du lieu them nghi phep nhan vien
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckEmptyXontrol())
            {
                try
                {
                    if (np.CheckAddNghiPhep(new DTONghiPhep(txtIDNV.Text, rtLyDo.Text, cbLoaiNghi.Text, dtBatDau.Value, dtKetThuc.Value)))
                    {
                        dtGridMainNP.DataSource = np.CheckGetAllNPhep();
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
            if (CheckEmptyXontrol())
            {
                try
                {
                    if (np.CheckUpdateNghiPhep(new DTONghiPhep(int.Parse(txtID.Text), txtIDNV.Text, rtLyDo.Text, cbLoaiNghi.Text, dtBatDau.Value, dtKetThuc.Value)))
                    {
                        dtGridMainNP.DataSource = np.CheckGetAllNPhep();
                        MessageBox.Show("Sửa dữ liệu thành công !!!");
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

        // Lam trong truong du lieu sau khi CRUD xong
        private void Empty()
        {
            txtID.Clear();
            txtIDNV.Clear();
            rtLyDo.Clear();
            cbLoaiNghi.SelectedIndex = -1;
        }

        // Kiem tra du lieu trong trong Form
        public bool CheckEmptyXontrol()
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

                if (item is ComboBox combo && string.IsNullOrWhiteSpace(combo.Text))
                {
                    errorProvider1.SetError(combo, $"Empty {combo.Name.Substring(2)} !!!");
                    ktra = false;
                }
            }

            return ktra;
        }



        // Xoa du lieu nghi phep nhan vien
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nghỉ phép này không ??", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (np.CheckDeleteNghiPhep(new DTONghiPhep(int.Parse(txtID.Text))))
                    {
                        dtGridMainNP.DataSource = np.CheckGetAllNPhep();
                        MessageBox.Show("Xóa dữ liệu thành công !!!");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                    return;
                }
            }
        }

        // Thoat bang nghi phep
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }
        private void NghiPhep_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void NghiPhep_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }
    }
}
