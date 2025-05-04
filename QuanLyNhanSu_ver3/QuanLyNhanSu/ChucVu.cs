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
    public partial class ChucVu : Form
    {
        BLL_ChucVu bll = new BLL_ChucVu();
        public ChucVu()
        {
            InitializeComponent();
        }

        private void ChucVu_Load(object sender, EventArgs e)
        {
            dgvChucVu.DataSource = bll.LoadChucVu();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtId.Text != null || txtId.Text != string.Empty || txtTenChucVu.Text != null || txtTenChucVu.Text != string.Empty)
            {
                DTO_ChucVu dto = new DTO_ChucVu(txtId.Text, txtTenChucVu.Text);
                if(bll.AddChucVu(dto))
                {
                    MessageBox.Show("Thêm thành công !", "Thông báo");
                    dgvChucVu.DataSource = bll.LoadChucVu();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != null || txtId.Text != string.Empty )
            {
                if (bll.DeleteChucVu(txtId.Text))
                {
                    MessageBox.Show("Xóa thành công !", "Thông báo");
                    dgvChucVu.DataSource = bll.LoadChucVu();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtId.Text != null || txtId.Text != string.Empty || txtTenChucVu.Text != null || txtTenChucVu.Text != string.Empty)
            {
                DTO_ChucVu dto = new DTO_ChucVu(txtId.Text, txtTenChucVu.Text);
                if (bll.EditChucVu(dto))
                {
                    MessageBox.Show("Sửa thành công !", "Thông báo");
                    dgvChucVu.DataSource = bll.LoadChucVu();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại !", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo");
            }
        }

        private void ChucVu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(txtId.Text != null || txtId.Text != string.Empty || txtTenChucVu.Text != null || txtTenChucVu.Text != string.Empty)
            {
                DialogResult kq = MessageBox.Show("Vẫn còn dữ liệu bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChucVu_Click(object sender, EventArgs e)
        {
            if (dgvChucVu.Rows[dgvChucVu.CurrentCell.RowIndex].Cells.Count > 0 &&
                dgvChucVu.Rows[dgvChucVu.CurrentCell.RowIndex].Cells[0].Value != null && dgvChucVu.Rows[dgvChucVu.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                txtId.Text = dgvChucVu.Rows[dgvChucVu.CurrentCell.RowIndex].Cells[0].Value.ToString();
                txtTenChucVu.Text = dgvChucVu.Rows[dgvChucVu.CurrentCell.RowIndex].Cells[1].Value.ToString();
            }
        }
    }
}
