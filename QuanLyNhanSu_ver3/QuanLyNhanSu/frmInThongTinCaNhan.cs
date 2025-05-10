using CrystalDecisions.Shared;
using QuanLyNhanSu.report;
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
    public partial class frmInThongTinCaNhan : Form
    {
        //Biến toàn cục
        string IDNhanVien;
        public frmInThongTinCaNhan()
        {
            InitializeComponent();
        }

        public frmInThongTinCaNhan(string id)
        {
            InitializeComponent();
            IDNhanVien = id;
        }

        private void frmInThongTinCaNhan_Load(object sender, EventArgs e)
        {
            
            if(IDNhanVien != string.Empty || IDNhanVien != null)
            {
                MessageBox.Show(IDNhanVien);
                rptThongTinNhanVien rpt = new rptThongTinNhanVien();

                ParameterValues paramValues = new ParameterValues();
                ParameterDiscreteValue paramValue = new ParameterDiscreteValue();
                paramValue.Value = IDNhanVien;
                paramValues.Add(paramValue);

                rpt.DataDefinition.ParameterFields["pIDNhanVien"].ApplyCurrentValues(paramValues);

                CrytalReportViewer.ReportSource = rpt;
                CrytalReportViewer.Refresh();
            }
            else
            {
                MessageBox.Show("ID nhân viên không đúng !", "Thông báo");
            }
        }

        private void rptThongTinNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
