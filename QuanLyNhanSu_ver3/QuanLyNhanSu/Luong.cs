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
    public partial class Luong : Form
    {
        BLL_Luong bllLuong = new BLL_Luong();
        public Luong()
        {
            InitializeComponent();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLuong_Click(object sender, EventArgs e)
        {
            if(dgvLuong.CurrentCell.RowIndex > 0 && dgvLuong.Rows[dgvLuong.CurrentCell.RowIndex].Cells[0].Value != null)
            {
                int dong = dgvLuong.CurrentCell.RowIndex;
                txtIdLuong.Text = dgvLuong.Rows[dong].Cells[0].Value.ToString();
                txtSoLuong.Text = dgvLuong.Rows[dong].Cells[1].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtSoLuong.Text != "")
            {
                DTO_Luong dto = new DTO_Luong(decimal.Parse(txtSoLuong.Text));
                if(bllLuong.AddLuong(dto))
                {
                    MessageBox.Show("Thêm thành công !", "Thông báo");
                    dgvLuong.DataSource = bllLuong.LoadLuong();
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
            if(txtIdLuong.Text != "" && txtIdLuong.Text != "0")
            {
                DialogResult kq = MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    if (bllLuong.DeteleLuong(int.Parse(txtIdLuong.Text)))
                    {
                        MessageBox.Show("Xóa thành công !", "Thông báo");
                        dgvLuong.DataSource = bllLuong.LoadLuong();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại !", "Thông báo");
                    }

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 phần tử !", "Thông báo");
            }
        }

        private void Luong_Load(object sender, EventArgs e)
        {
            dgvLuong.DataSource = bllLuong.LoadLuong();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != ""&& txtIdLuong.Text != "" && txtIdLuong.Text != "0")
            {
                DTO_Luong dto = new DTO_Luong(decimal.Parse(txtSoLuong.Text));
                dto.Id = int.Parse(txtIdLuong.Text);

                if (bllLuong.EditLuong(dto))
                {
                    MessageBox.Show("Sửa thành công !", "Thông báo");
                    dgvLuong.DataSource = bllLuong.LoadLuong();
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

        private void Luong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(txtSoLuong.Text != null && txtSoLuong.Text != string.Empty)
            {
                DialogResult kq = MessageBox.Show("Bạn vẫn còn dữ liệu có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(kq == DialogResult.Yes)
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
    }
}
