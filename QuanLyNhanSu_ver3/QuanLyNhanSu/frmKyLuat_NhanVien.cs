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
    public partial class frmKyLuat_NhanVien : Form
    {
        BLL_KyLuat_NhanVien bll = new BLL_KyLuat_NhanVien();
        public frmKyLuat_NhanVien()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmKyLuat_NhanVien_Load(object sender, EventArgs e)
        {
            //Load danh sách Kỷ luật
            dgvKyLuat.DataSource = bll.LoadKyLuat();

            //Load danh sách nhân viên
            dgvNhanVien.DataSource = bll.LoadNhanVien();

            //Load danh sách nhân viên bị kỷ luật
            if(dgvKyLuat.CurrentCell.RowIndex > -1 && dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[0].Value != null && dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                dgvNhanVienNhanKyLuat.DataSource = bll.LoadNhanVienKyLuat(int.Parse(dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[0].Value.ToString()));

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void dgvKyLuat_Click(object sender, EventArgs e)
        {
            if (dgvKyLuat.CurrentCell.RowIndex > -1 && dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[0].Value != null && dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                dgvNhanVienNhanKyLuat.DataSource = bll.LoadNhanVienKyLuat(int.Parse(dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[0].Value.ToString()));

            }
        }

        private void AddNhanVienKyLuat_Click(object sender, EventArgs e)
        {
            if (dgvKyLuat.CurrentCell.RowIndex > -1 && dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[0].Value != null 
                && dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[1].Value != null
                && dgvNhanVien.SelectedRows.Count > 0)
            {
                bool flag = true;
                foreach(DataGridViewRow row in dgvNhanVien.SelectedRows)
                {
                    DTO_KyLuatNhanVien dto = new DTO_KyLuatNhanVien(int.Parse(dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[0].Value.ToString()), row.Cells["id"].Value.ToString(), dtpNgayKyLuat.Value);
                    if(!bll.AddKyLuatNhanVien(dto))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    MessageBox.Show("Thêm thành công !", "Thông báo");
                    //Load lại danh sách nhân viên bị kỷ luật
                    dgvNhanVienNhanKyLuat.DataSource = bll.LoadNhanVienKyLuat(int.Parse(dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[0].Value.ToString()));
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !", "Thông báo");
                }
                



            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại kỷ luật !", "thông báo");
            }
        }

        private void btnXoaNhanVienKyLuat_Click(object sender, EventArgs e)
        {
            if(dgvNhanVienNhanKyLuat.SelectedRows.Count > 0 && dgvKyLuat.CurrentCell.RowIndex > -1 && dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[0].Value != null && dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                bool flag = true;
                foreach(DataGridViewRow row in dgvNhanVienNhanKyLuat.SelectedRows)
                {
                    MessageBox.Show(dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    MessageBox.Show(row.Cells[0].Value.ToString());
                    MessageBox.Show(dtpNgayKyLuat.Value.ToString());
                    DTO_KyLuatNhanVien dto = new DTO_KyLuatNhanVien(int.Parse(dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[0].Value.ToString()), row.Cells[0].Value.ToString(), dtpNgayKyLuat.Value);
                    if(!bll.DeleteKyLuatNhanVien(dto))
                    {
                        flag = false;
                        break;
                    }
                }
                if(flag)
                {
                    MessageBox.Show("Xóa thành công !", "Thông báo");
                    dgvNhanVienNhanKyLuat.DataSource = bll.LoadNhanVienKyLuat(int.Parse(dgvKyLuat.Rows[dgvKyLuat.CurrentCell.RowIndex].Cells[0].Value.ToString()));
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !", "Thông báo");
                }
            }
        }
    }
}
