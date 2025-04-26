using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class NghiPhep : Form
    {
        public BLLCheckDataNP np = new BLLCheckDataNP();
        public NghiPhep()
        {
            InitializeComponent();
        }

        private void NghiPhep_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void NghiPhep_Load(object sender, EventArgs e)
        {
            dtGridMainNP.DataSource = np.CheckGetAllNphep();

            cbLoaiNghi.DataSource = np.CheckGetAllNphep();
            cbLoaiNghi.DisplayMember = "LoaiNghiPhep";
            cbLoaiNghi.ValueMember = "id";
        }

        // Thoat bang nghi phep
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        // Nhap du lieu them nghi phep nhan vien
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (np.CheckEmptyXontrol(this.Controls, errorProvider1))
            {
                try
                {
                    if (np.CheckAddNghiPhep(new DTONghiPhep(txtIDNV.Text, rtLyDo.Text, cbLoaiNghi.Text, dtBatDau.Value, dtKetThuc.Value)))
                    {
                        dtGridMainNP.DataSource = np.CheckGetAllNphep();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                    return;
                }
                finally { Empty(); }
                MessageBox.Show("Thêm dữ liệu thành công !!!");
            }
        }

        // Nhap du lieu cap nhat nghi phep nhan vien
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (np.CheckEmptyXontrol(this.Controls, errorProvider1))
            {
                try
                {
                    if (np.CheckUpdateNghiPhep(new DTONghiPhep(int.Parse(txtID.Text), txtIDNV.Text, rtLyDo.Text, cbLoaiNghi.Text, dtBatDau.Value, dtKetThuc.Value)))
                    {
                        dtGridMainNP.DataSource = np.CheckGetAllNphep();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                    return;
                }
                finally { Empty(); }
                MessageBox.Show("Sửa dữ liệu thành công !!!");
            }
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
                        dtGridMainNP.DataSource = np.CheckGetAllNphep();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                    return;
                }

                MessageBox.Show("Xóa dữ liệu thành công !!!");
            }
        }

        private void dtGridMainNP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e != null && e.RowIndex > -1)
            {
                txtID.Text = dtGridMainNP.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtIDNV.Text = dtGridMainNP.Rows[e.RowIndex].Cells[1].Value.ToString();
                rtLyDo.Text = dtGridMainNP.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbLoaiNghi.Text = dtGridMainNP.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtBatDau.Value = DateTime.Parse(dtGridMainNP.Rows[e.RowIndex].Cells[4].Value.ToString());
                dtKetThuc.Value = DateTime.Parse(dtGridMainNP.Rows[e.RowIndex].Cells[5].Value.ToString());
            }
        }

        private void Empty()
        {
            txtID.Clear();
            txtIDNV.Clear();
            rtLyDo.Clear();
            cbLoaiNghi.SelectedIndex = -1;
        }
    }
}
