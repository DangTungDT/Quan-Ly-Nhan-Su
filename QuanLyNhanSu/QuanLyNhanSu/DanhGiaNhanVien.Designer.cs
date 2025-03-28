namespace QuanLyNhanSu
{
    partial class DanhGiaNhanVien
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbDiemSo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNhanVien = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbNguoiDanhGia = new System.Windows.Forms.ComboBox();
            this.dtGridMainDG = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.rtNhanXet = new System.Windows.Forms.RichTextBox();
            this.dtNgayTao = new System.Windows.Forms.DateTimePicker();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridMainDG)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(54, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Điểm số:";
            // 
            // cbDiemSo
            // 
            this.cbDiemSo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbDiemSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiemSo.FormattingEnabled = true;
            this.cbDiemSo.Location = new System.Drawing.Point(112, 71);
            this.cbDiemSo.Name = "cbDiemSo";
            this.cbDiemSo.Size = new System.Drawing.Size(159, 21);
            this.cbDiemSo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(54, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày tạo:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(300, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID Nhân viên:";
            // 
            // cbNhanVien
            // 
            this.cbNhanVien.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNhanVien.FormattingEnabled = true;
            this.cbNhanVien.Location = new System.Drawing.Point(390, 70);
            this.cbNhanVien.Name = "cbNhanVien";
            this.cbNhanVien.Size = new System.Drawing.Size(159, 21);
            this.cbNhanVien.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(299, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Người đánh giá: ";
            // 
            // cbNguoiDanhGia
            // 
            this.cbNguoiDanhGia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbNguoiDanhGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNguoiDanhGia.FormattingEnabled = true;
            this.cbNguoiDanhGia.Location = new System.Drawing.Point(390, 110);
            this.cbNguoiDanhGia.Name = "cbNguoiDanhGia";
            this.cbNguoiDanhGia.Size = new System.Drawing.Size(159, 21);
            this.cbNguoiDanhGia.TabIndex = 2;
            // 
            // dtGridMainDG
            // 
            this.dtGridMainDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridMainDG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtGridMainDG.Location = new System.Drawing.Point(10, 252);
            this.dtGridMainDG.Name = "dtGridMainDG";
            this.dtGridMainDG.Size = new System.Drawing.Size(728, 150);
            this.dtGridMainDG.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(54, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nhận xét:";
            // 
            // rtNhanXet
            // 
            this.rtNhanXet.Location = new System.Drawing.Point(112, 154);
            this.rtNhanXet.Name = "rtNhanXet";
            this.rtNhanXet.Size = new System.Drawing.Size(437, 83);
            this.rtNhanXet.TabIndex = 4;
            this.rtNhanXet.Text = "";
            // 
            // dtNgayTao
            // 
            this.dtNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayTao.Location = new System.Drawing.Point(112, 113);
            this.dtNgayTao.Name = "dtNgayTao";
            this.dtNgayTao.Size = new System.Drawing.Size(159, 20);
            this.dtNgayTao.TabIndex = 5;
            this.dtNgayTao.Value = new System.DateTime(2025, 3, 27, 11, 26, 42, 0);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(592, 198);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(112, 39);
            this.btnThoat.TabIndex = 23;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(592, 110);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(112, 39);
            this.btnSua.TabIndex = 24;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(592, 154);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(112, 39);
            this.btnXoa.TabIndex = 25;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(592, 64);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(112, 39);
            this.btnThem.TabIndex = 26;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 39);
            this.panel1.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(728, 39);
            this.label10.TabIndex = 15;
            this.label10.Text = "ĐÁNH GIÁ NHÂN VIÊN";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DanhGiaNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dtNgayTao);
            this.Controls.Add(this.rtNhanXet);
            this.Controls.Add(this.dtGridMainDG);
            this.Controls.Add(this.cbNguoiDanhGia);
            this.Controls.Add(this.cbNhanVien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbDiemSo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DanhGiaNhanVien";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DanhGiaNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridMainDG)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDiemSo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNhanVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbNguoiDanhGia;
        private System.Windows.Forms.DataGridView dtGridMainDG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtNhanXet;
        private System.Windows.Forms.DateTimePicker dtNgayTao;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
    }
}

