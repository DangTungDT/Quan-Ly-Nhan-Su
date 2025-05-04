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
    public partial class KhenThuong : Form
    {
        BLL_KhenThuong bll = new BLL_KhenThuong();
        public KhenThuong()
        {
            InitializeComponent();
        }

        private void frmKhenThuong_Load(object sender, EventArgs e)
        {
            //Load danh sách khen thưởng
            dgvKhenThuong.DataSource = bll.LoadKhenThuong();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DTO_KhenThuong dto = new DTO_KhenThuong(dtpNgayKhenThuong.Value, int.Parse(txtSoTien.Text), txtLyDo.Text);
            if (bll.ThemKhenThuong(dto))
            {
                MessageBox.Show("Thêm thành công !", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm thất bại !", "Thông báo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(kq == DialogResult.Yes)
            {
                DTO_KhenThuong dto = new DTO_KhenThuong(dtpNgayKhenThuong.Value, int.Parse(txtSoTien.Text), txtLyDo.Text);
                if (bll.XoaKhenThuong(dto))
                {
                    MessageBox.Show("Xóa thành công !", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !", "Thông báo");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DTO_KhenThuong dto = new DTO_KhenThuong(dtpNgayKhenThuong.Value, int.Parse(txtSoTien.Text), txtLyDo.Text);
            dto.Id = int.Parse(txtIdKhenThuong.Text);
            if (bll.EditKhenThuong(dto))
            {
                MessageBox.Show("Sửa thành công !", "Thông báo");
            }
            else
            {
                MessageBox.Show("Sửa thất bại !", "Thông báo");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void KhenThuong_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult question = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (question == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgvKhenThuong_Click(object sender, EventArgs e)
        {
            if (dgvKhenThuong.Rows[dgvKhenThuong.CurrentCell.RowIndex].Cells[1].Value != null && dgvKhenThuong.CurrentCell != null && dgvKhenThuong.CurrentCell.RowIndex >= 0 && dgvKhenThuong.Rows[dgvKhenThuong.CurrentCell.RowIndex].Cells[0] != null)
            {
                int dong = dgvKhenThuong.CurrentCell.RowIndex;
                txtIdKhenThuong.Text = dgvKhenThuong.Rows[dong].Cells[0].Value.ToString();
                dtpNgayKhenThuong.Text = dgvKhenThuong.Rows[dong].Cells[1].Value.ToString();
                txtSoTien.Text = dgvKhenThuong.Rows[dong].Cells[2].Value.ToString();
                txtLyDo.Text = dgvKhenThuong.Rows[dong].Cells[3].Value.ToString();
            }
        }

    }
}
