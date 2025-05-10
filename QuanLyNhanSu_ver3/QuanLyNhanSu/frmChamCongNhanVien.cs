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
    public partial class frmChamCongNhanVien : Form
    {
        //Biến toàn cục
        BLLChamCongNhanVien bll = new BLLChamCongNhanVien();
        string idNhanVien;

        public frmChamCongNhanVien()
        {
            InitializeComponent();
        }

        public frmChamCongNhanVien(string id)
        {
            InitializeComponent();
            idNhanVien = id;
        }
        private void frmChamCongNhanVien_Load(object sender, EventArgs e)
        {
            DTONhanVienChamCong nhanVien = bll.LoadNhanVienByID(idNhanVien);
            txtID.Text = nhanVien.Id;
            txtTenNhanVien.Text = nhanVien.TenNhanVien;
            dtpNgayChamCong.Text = DateTime.Now.ToString();

        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            if(!bll.CheckVauleChamCong(txtID.Text, dtpNgayChamCong.Value))
            {
                int ketQua = bll.AddChamCong(new DTOChamCongNhanVien(dtpNgayChamCong.Value, txtID.Text)); 
                switch(ketQua)
                {
                    //Trường hợp bị lỗi truy xuất dữ liệu (DAL)
                    case -2:

                        MessageBox.Show("Lỗi không thể lấy dữ liệu !", "Thông báo");
                        return;
                        
                    //Trường hợp dữ liệu có vấn đề (lỗi)
                    case -1:
                        MessageBox.Show("Lỗi dữ liệu đầu vào !", "Thông báo");
                        return;
                    //Trường hợp thêm thành công
                    case 0:
                        MessageBox.Show("Chấm công thành công !", "Thông báo");
                        return;
                    //Trường hợp đã chấm công từ trước
                    case 1:
                        MessageBox.Show("Bạn đã chấm công ngày hôm nay rồi !", "Thông báo");
                        return;
                }
            }
            else
            {
                MessageBox.Show("Bạn đã chấm công ngày hôm nay rồi !", "Thông báo");
                return;
            }
        }
    }
}
