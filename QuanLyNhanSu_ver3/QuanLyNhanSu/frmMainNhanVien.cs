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
    public partial class frmMainNhanVien : Form
    {

        //Biến toàn cục
        string IDNhanVien;

        public frmMainNhanVien(string id)
        {
            InitializeComponent();
            IDNhanVien = id;
        }
        public frmMainNhanVien()
        {
            InitializeComponent();
        }

        private void frmMainNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
