namespace QuanLyNhanSu
{
    partial class frmInThongTinCaNhan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CrytalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptThongTinNhanVien1 = new QuanLyNhanSu.report.rptThongTinNhanVien();
            this.SuspendLayout();
            // 
            // CrytalReportViewer
            // 
            this.CrytalReportViewer.ActiveViewIndex = 0;
            this.CrytalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrytalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrytalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrytalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.CrytalReportViewer.Name = "CrytalReportViewer";
            this.CrytalReportViewer.ReportSource = this.rptThongTinNhanVien1;
            this.CrytalReportViewer.Size = new System.Drawing.Size(1217, 515);
            this.CrytalReportViewer.TabIndex = 0;
            this.CrytalReportViewer.Load += new System.EventHandler(this.rptThongTinNhanVien_Load);
            // 
            // frmInThongTinCaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 515);
            this.Controls.Add(this.CrytalReportViewer);
            this.Name = "frmInThongTinCaNhan";
            this.Text = "frmInThongTinCaNhan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInThongTinCaNhan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrytalReportViewer;
        private report.rptThongTinNhanVien rptThongTinNhanVien1;
    }
}