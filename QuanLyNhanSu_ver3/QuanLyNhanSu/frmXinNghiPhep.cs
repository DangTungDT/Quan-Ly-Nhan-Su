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
    public partial class frmXinNghiPhep : Form
    {
        //Global variable
        string GIDEmployee;
        BLLCheckDataNP GBLL = new BLLCheckDataNP();
        BLLCheckDataNV GBLLNhanVien = new BLLCheckDataNV();
        int GIDNghiPhep;

        public frmXinNghiPhep()
        {
            InitializeComponent();
        }
        public frmXinNghiPhep(string id)
        {
            InitializeComponent();
            GIDEmployee = id;
        }

        private void frmXinNghiPhep_Load(object sender, EventArgs e)
        {
            if (GIDEmployee != null) 
            {
                //Chèn tên nhân viên vào textBox
                txtNameEmployee.Text = GBLLNhanVien.getNameByID(GIDEmployee);

                //Load danh sách NghiPhep đang trong trạng thái "yêu cầu"
                dgvListRequestNghiPhep.DataSource = GBLL.getAllNghiPhepDangYeuCau(GIDEmployee);

                //Nạp dữ liệu cho combobox Loại nghỉ 
                cobType.Items.Add("Nghỉ không lương");
                cobType.Items.Add("Nghỉ có lương");
            }
        }

        private void txtNameEmployee_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (GBLL.CheckAddNghiPhep(new DTONghiPhep(GIDEmployee, txtReason.Text, cobType.Text, dtpDateStart.Value,dtpDateEnd.Value,"Đang yêu cầu")))
                {
                    dgvListRequestNghiPhep.DataSource = GBLL.getAllNghiPhepDangYeuCau(GIDEmployee);
                    MessageBox.Show("Đã gửi yêu cầu thành công !!!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa yêu cầu này ?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (GBLL.CheckDeleteNghiPhep(new DTONghiPhep(GIDNghiPhep)))
                    {
                        dgvListRequestNghiPhep.DataSource = GBLL.getAllNghiPhepDangYeuCau(GIDEmployee);
                        MessageBox.Show("Xóa yếu cầu thành công !!!");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                    return;
                }
            }
        }

        private void dgvListRequestNghiPhep_Click(object sender, EventArgs e)
        {
            if (dgvListRequestNghiPhep.Rows[dgvListRequestNghiPhep.CurrentCell.RowIndex].Cells.Count > 0 &&
                dgvListRequestNghiPhep.Rows[dgvListRequestNghiPhep.CurrentCell.RowIndex].Cells[0].Value != null &&
                dgvListRequestNghiPhep.Rows[dgvListRequestNghiPhep.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                GIDNghiPhep = int.Parse(dgvListRequestNghiPhep.Rows[dgvListRequestNghiPhep.CurrentCell.RowIndex].Cells[0].Value.ToString());
                txtNameEmployee.Text = GBLLNhanVien.getNameByID(dgvListRequestNghiPhep.Rows[dgvListRequestNghiPhep.CurrentCell.RowIndex].Cells[2].Value.ToString());
                txtReason.Text = dgvListRequestNghiPhep.Rows[dgvListRequestNghiPhep.CurrentCell.RowIndex].Cells[3].Value.ToString();
                cobType.SelectedItem = dgvListRequestNghiPhep.Rows[dgvListRequestNghiPhep.CurrentCell.RowIndex].Cells[4].Value.ToString();
                dtpDateStart.Text = dgvListRequestNghiPhep.Rows[dgvListRequestNghiPhep.CurrentCell.RowIndex].Cells[5].Value.ToString();
                dtpDateEnd.Text = dgvListRequestNghiPhep.Rows[dgvListRequestNghiPhep.CurrentCell.RowIndex].Cells[6].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GIDNghiPhep.ToString());
            try
            {

                if (GBLL.CheckUpdateNghiPhep(new DTONghiPhep(GIDNghiPhep, GIDEmployee, txtReason.Text, cobType.Text, dtpDateStart.Value, dtpDateEnd.Value, "Đang yêu cầu")))
                {
                    dgvListRequestNghiPhep.DataSource = GBLL.getAllNghiPhepDangYeuCau(GIDEmployee);
                    MessageBox.Show("Sửa yêu cầu thành công !!!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                return;
            }
        }

        private void frmXinNghiPhep_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
