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
    public partial class frmKyLuat : Form
    {
        BLL_KyLuat bll = new BLL_KyLuat();
        public frmKyLuat()
        {
            InitializeComponent();
        }

        private void KyLuat_Load(object sender, EventArgs e)
        {
            dgvKyLuat.DataSource = bll.LoadKyLuat();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if( txtLyDoKyLuat.Text != "" && txtNoiDungKyLuat.Text != "")
            {
                DTO_KyLuat dto = new DTO_KyLuat(txtNoiDungKyLuat.Text, txtLyDoKyLuat.Text);
                if (bll.AddKyLuat(dto))
                {
                    MessageBox.Show("Thêm thành công !", "Thông báo");
                    dgvKyLuat.DataSource = bll.LoadKyLuat();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtLyDoKyLuat.Text != "" && txtNoiDungKyLuat.Text != "")
            {
                DTO_KyLuat dto = new DTO_KyLuat(int.Parse(txtId.Text),txtNoiDungKyLuat.Text, txtLyDoKyLuat.Text);
                if (bll.EditKyLuat(dto))
                {
                    MessageBox.Show("Sửa thành công !", "Thông báo");
                    dgvKyLuat.DataSource = bll.LoadKyLuat();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtLyDoKyLuat.Text != "" && txtNoiDungKyLuat.Text != "")
            {
                if(MessageBox.Show("Bạn có muốn xóa ?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (bll.DeleteKyLuat(int.Parse(txtId.Text)))
                    {
                        MessageBox.Show("Xóa thành công !", "Thông báo");
                        dgvKyLuat.DataSource = bll.LoadKyLuat();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại !", "Thông báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo");
            }
        }

        private void KyLuat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtId.Text != "" || txtLyDoKyLuat.Text != "" || txtNoiDungKyLuat.Text != "")
            {
                if (MessageBox.Show("Vẫn còn dữ liệu bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvKyLuat_Click(object sender, EventArgs e)
        {
            if (dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells.Count > 0 &&
                dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[0].Value != null &&
                dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                txtId.Text = dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[0].Value.ToString();
                txtNoiDungKyLuat.Text = dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[1].Value.ToString();
                txtLyDoKyLuat.Text = dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[2].Value.ToString();
            }
        }
    }
}
