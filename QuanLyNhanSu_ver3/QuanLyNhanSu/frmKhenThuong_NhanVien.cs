using BLL;
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
    public partial class frmKhenThuong_NhanVien : Form
    {
        BLL_KhenThuong_NhanVien bll = new BLL_KhenThuong_NhanVien();
        public frmKhenThuong_NhanVien()
        {
            InitializeComponent();
        }

        private void frmKhenThuong_NhanVien_Load(object sender, EventArgs e)
        {
            //Load danh sách khen thưởng ra combobox
            cobKhenThuong.DataSource = bll.LoadKhenThuong();
            cobKhenThuong.DisplayMember = "LyDo";
            cobKhenThuong.ValueMember = "id";

            //Load danh sách nhân viên
            dgvNhanVien.DataSource = bll.LoadNhanVien();

            //Load danh sách nhân viên nhân khen thưởng
            dgvNhanVienKhenThuong.DataSource = bll.LoadNhanVienKhenThuong(int.Parse(cobKhenThuong.SelectedValue.ToString()));
        }

        private void cobKhenThuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Load danh sách nhân viên nhân khen thưởng
            //dgvNhanVienKhenThuong.DataSource = bll.LoadNhanVienKhenThuong(int.Parse(cobKhenThuong.SelectedValue.ToString()));
        }

        private void cobKhenThuong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Load danh sách nhân viên nhân khen thưởng
            dgvNhanVienKhenThuong.DataSource = bll.LoadNhanVienKhenThuong(int.Parse(cobKhenThuong.SelectedValue.ToString()));
        }

        private void dgvNhanVienKhenThuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(dgvNhanVien.SelectedRows.Count > 0)
            {
                bool flag = true;
                foreach(DataGridViewRow row in  dgvNhanVien.SelectedRows)
                {
                    if (!bll.AddKhenThuongNhanVien(row.Cells["id"].Value.ToString(), int.Parse(cobKhenThuong.SelectedValue.ToString())))
                    {
                        flag = false; break;
                    }
                }
                if(flag)
                {
                    MessageBox.Show("Thêm thành công !", "Thông báo");

                    //Load lại danh sách nhân viên được nhận thưởng
                    dgvNhanVienKhenThuong.DataSource = bll.LoadNhanVienKhenThuong(int.Parse(cobKhenThuong.SelectedValue.ToString()));
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !", "Thông báo");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNhanVienKhenThuong.SelectedRows.Count > 0)
            {
                bool flag = true;
                foreach (DataGridViewRow row in dgvNhanVienKhenThuong.SelectedRows)
                {
                    if (!bll.DeleteNhanVienNhanKhenThuong(row.Cells["id"].Value.ToString(), int.Parse(cobKhenThuong.SelectedValue.ToString())))
                    {
                        flag = false; break;
                    }
                }
                if (flag)
                {
                    MessageBox.Show("Xóa thành công !", "Thông báo");

                    //Load lại danh sách nhân viên được nhận thưởng
                    dgvNhanVienKhenThuong.DataSource = bll.LoadNhanVienKhenThuong(int.Parse(cobKhenThuong.SelectedValue.ToString()));
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !", "Thông báo");
                }
            }
        }
    }
}
