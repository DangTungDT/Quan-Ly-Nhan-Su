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
    public partial class frmMainTruongPhong : Form
    {

        //Biến toàn cục
        string IDNhanVien;
        public frmMainTruongPhong(string id)
        {
            InitializeComponent();
            IDNhanVien = id;
        }
        public frmMainTruongPhong()
        {
            InitializeComponent();
        }

        private void frmMainTruongPhong_Load(object sender, EventArgs e)
        {

        }
        public void FormChild(Form form)
        {
            foreach (var item in this.MdiChildren)
            {
                item.Hide();
            }
            form.MdiParent = this;
            form.Show();
        }

    }
}
