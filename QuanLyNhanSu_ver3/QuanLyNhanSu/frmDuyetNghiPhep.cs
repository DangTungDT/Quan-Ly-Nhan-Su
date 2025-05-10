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
    public partial class frmDuyetNghiPhep : Form
    {
        //Global Variable 
        string GIDEmployee;
        BLLCheckDataNP GBLL = new BLLCheckDataNP();
        public frmDuyetNghiPhep()
        {
            InitializeComponent();
        }

        public frmDuyetNghiPhep(string id)
        {
            InitializeComponent();
            GIDEmployee = id;
        }
        private void frmDuyetNghiPhep_Load(object sender, EventArgs e)
        {
            dgvNghiPhep.DataSource = GBLL.getNghiPhepTheoPhanQuyen(GIDEmployee);
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            Update("Duyệt");
        }

        private void dgvNghiPhep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            Update("Bị từ chối");
        }

        private void Update(string update)
        {
            if (dgvNghiPhep.SelectedRows.Count > 0)
            {
                bool flag = true;
                foreach (DataGridViewRow row in dgvNghiPhep.SelectedRows)
                {
                    if (!GBLL.CheckUpdateNghiPhep(new DTONghiPhep(int.Parse(row.Cells[0].Value.ToString()), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), DateTime.Parse(row.Cells[5].Value.ToString()), DateTime.Parse(row.Cells[6].Value.ToString()), update)))
                    {
                        flag = false; break;
                    }
                }
                if (flag)
                {
                    if(update == "Bị từ chối")
                    {
                        MessageBox.Show("Từ chối thành công !", "Thông báo");

                    }
                    else
                    {
                        MessageBox.Show("Duyệt thành công !", "Thông báo");
                    }

                    //Load lại danh sách nhân viên được nhận thưởng
                    dgvNghiPhep.DataSource = GBLL.getNghiPhepTheoPhanQuyen(GIDEmployee);
                }
                else
                {
                    if (update == "Bị từ chối")
                    {
                        MessageBox.Show("Từ chối thất bại !", "Thông báo");

                    }
                    else
                    {
                        MessageBox.Show("Duyệt thất bại !", "Thông báo");
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
