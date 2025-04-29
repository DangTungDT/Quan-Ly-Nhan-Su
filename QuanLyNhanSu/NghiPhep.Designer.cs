namespace QuanLyNhanSu
{
    partial class NghiPhep
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.rtLyDo = new System.Windows.Forms.RichTextBox();
            this.dtGridMainNP = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLoaiNghi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDNV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridMainNP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 39);
            this.panel1.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(780, 39);
            this.label10.TabIndex = 15;
            this.label10.Text = "NGHỈ PHÉP";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(633, 206);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(112, 39);
            this.btnThoat.TabIndex = 39;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(633, 118);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(112, 39);
            this.btnSua.TabIndex = 40;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(633, 162);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(112, 39);
            this.btnXoa.TabIndex = 41;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(633, 72);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(112, 39);
            this.btnThem.TabIndex = 42;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // rtLyDo
            // 
            this.rtLyDo.Location = new System.Drawing.Point(134, 178);
            this.rtLyDo.Name = "rtLyDo";
            this.rtLyDo.Size = new System.Drawing.Size(437, 83);
            this.rtLyDo.TabIndex = 37;
            this.rtLyDo.Text = "";
            // 
            // dtGridMainNP
            // 
            this.dtGridMainNP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridMainNP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtGridMainNP.Location = new System.Drawing.Point(10, 276);
            this.dtGridMainNP.Name = "dtGridMainNP";
            this.dtGridMainNP.RowHeadersWidth = 51;
            this.dtGridMainNP.Size = new System.Drawing.Size(780, 150);
            this.dtGridMainNP.TabIndex = 36;
            this.dtGridMainNP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridMainNP_CellContentClick);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(321, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 28;
            this.label4.Text = "Ngày kết thúc:";
            // 
            // cbLoaiNghi
            // 
            this.cbLoaiNghi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbLoaiNghi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiNghi.FormattingEnabled = true;
            this.cbLoaiNghi.Location = new System.Drawing.Point(134, 141);
            this.cbLoaiNghi.Name = "cbLoaiNghi";
            this.cbLoaiNghi.Size = new System.Drawing.Size(159, 21);
            this.cbLoaiNghi.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(322, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 29;
            this.label3.Text = "Ngày bắt đầu:";
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(51, 178);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(85, 19);
            this.label.TabIndex = 30;
            this.label.Text = "Lý do:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 31;
            this.label2.Text = "Loại nghỉ:";
            // 
            // dtBatDau
            // 
            this.dtBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBatDau.Location = new System.Drawing.Point(412, 102);
            this.dtBatDau.Name = "dtBatDau";
            this.dtBatDau.Size = new System.Drawing.Size(159, 20);
            this.dtBatDau.TabIndex = 38;
            this.dtBatDau.Value = new System.DateTime(2025, 3, 27, 11, 26, 42, 0);
            // 
            // dtKetThuc
            // 
            this.dtKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtKetThuc.Location = new System.Drawing.Point(412, 143);
            this.dtKetThuc.Name = "dtKetThuc";
            this.dtKetThuc.Size = new System.Drawing.Size(159, 20);
            this.dtKetThuc.TabIndex = 38;
            this.dtKetThuc.Value = new System.DateTime(2025, 3, 27, 11, 26, 42, 0);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "ID nhân viên:";
            // 
            // txtIDNV
            // 
            this.txtIDNV.Location = new System.Drawing.Point(134, 101);
            this.txtIDNV.Multiline = true;
            this.txtIDNV.Name = "txtIDNV";
            this.txtIDNV.Size = new System.Drawing.Size(159, 21);
            this.txtIDNV.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 19);
            this.label5.TabIndex = 31;
            this.label5.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(134, 62);
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(159, 21);
            this.txtID.TabIndex = 18;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // NghiPhep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 436);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtIDNV);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dtKetThuc);
            this.Controls.Add(this.dtBatDau);
            this.Controls.Add(this.rtLyDo);
            this.Controls.Add(this.dtGridMainNP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbLoaiNghi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label2);
            this.Name = "NghiPhep";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "NghiPhep";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NghiPhep_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NghiPhep_FormClosed);
            this.Load += new System.EventHandler(this.NghiPhep_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridMainNP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.RichTextBox rtLyDo;
        private System.Windows.Forms.DataGridView dtGridMainNP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLoaiNghi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtBatDau;
        private System.Windows.Forms.DateTimePicker dtKetThuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}