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
    public partial class PhongBan : Form
    {
        BLLCheckDataPB data = new BLLCheckDataPB();
        public PhongBan()
        {
            InitializeComponent();
        }

        private void PhongBan_Load(object sender, EventArgs e)
        {
            dtGridMainPB.DataSource = data.CheckGetAllPBan();
        }

        private void PhongBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        // Du lieu nhap them phong ban
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (data.CheckEmptyXontrol(this.Controls, errorProvider1))
            {
                try
                {
                    if (data.CheckAddPBan(new DTOPhongBan(txtID.Text, txtTenPB.Text, rtMoTa.Text)))
                    {
                        dtGridMainPB.DataSource = data.CheckGetAllPBan();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm phòng ban: " + ex.Message);
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show("Lỗi: " + ex.InnerException.Message);
                    }
                }
                finally { Empty(); }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (data.CheckEmptyXontrol(this.Controls, errorProvider1))
            {
                try
                {
                    if (data.CheckUpdatePBan(new DTOPhongBan(txtID.Text, txtTenPB.Text, rtMoTa.Text)))
                    {
                        dtGridMainPB.DataSource = data.CheckGetAllPBan();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật phòng ban: " + ex.Message);
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show("Lỗi: " + ex.InnerException.Message);
                    }
                }
                finally { Empty(); }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dữ liệu phòng ban này không ?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (data.CheckDeletePBan(new DTOPhongBan(txtID.Text)))
                    {
                        dtGridMainPB.DataSource = data.CheckGetAllPBan();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa phòng ban: " + ex.Message);
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show("Lỗi: " + ex.InnerException.Message);
                    }
                }
                finally { Empty(); }
            }
        }

        private void dtGridMainPB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e != null && e.RowIndex > -1)
            {
                txtID.Text = dtGridMainPB.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenPB.Text = dtGridMainPB.Rows[e.RowIndex].Cells[1].Value.ToString();
                rtMoTa.Text = dtGridMainPB.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        public void Empty()
        {
            txtID.Clear();
            txtTenPB.Clear();
            rtMoTa.Clear();
        }
    }
}
