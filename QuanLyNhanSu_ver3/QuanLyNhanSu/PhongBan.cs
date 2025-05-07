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
    public partial class PhongBan: Form
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PhongBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        // Kiem tra du lieu trong trong Form
        public bool CheckEmptyXontrol()
        {
            bool ktra = true;
            errorProvider1.Clear();

            foreach (var item in Controls)
            {
                if (item is TextBox text && string.IsNullOrWhiteSpace(text.Text))
                {
                    errorProvider1.SetError(text, $"Empty {text.Name.Substring(3)} !!!");
                    ktra = false;
                }
            }

            return ktra;
        }

        // Du lieu nhap them phong ban
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckEmptyXontrol())
            {
                try
                {
                    if (data.CheckAddPBan(new DTOPhongBan(txtID.Text, txtTenPB.Text, rtMoTa.Text)))
                    {
                        dtGridMainPB.DataSource = data.CheckGetAllPBan();
                        MessageBox.Show("Thêm dữ liệu thành công !!!");
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

        // Du lieu xoa them phong ban
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dữ liệu phòng ban này không ?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (data.CheckDeletePBan(new DTOPhongBan(txtID.Text)))
                    {
                        dtGridMainPB.DataSource = data.CheckGetAllPBan();
                        MessageBox.Show("Xóa dữ liệu thành công !!!");
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

        // Du lieu cap nhat them phong ban
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckEmptyXontrol())
            {
                try
                {
                    if (data.CheckUpdatePBan(new DTOPhongBan(txtID.Text, txtTenPB.Text, rtMoTa.Text)))
                    {
                        dtGridMainPB.DataSource = data.CheckGetAllPBan();
                        MessageBox.Show("Sửa dữ liệu thành công !!!");
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
    }
}
