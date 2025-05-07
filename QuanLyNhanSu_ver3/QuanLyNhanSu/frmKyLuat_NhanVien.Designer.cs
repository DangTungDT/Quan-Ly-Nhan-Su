namespace QuanLyNhanSu
{
    partial class frmKyLuat_NhanVien
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.dgvNhanVienNhanKyLuat = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgvKyLuat = new System.Windows.Forms.DataGridView();
            this.dtpNgayKyLuat = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.AddNhanVienKyLuat = new System.Windows.Forms.Button();
            this.btnXoaNhanVienKyLuat = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVienNhanKyLuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyLuat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1801, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kỷ luật nhân viên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại kỷ luật";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(475, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ngày kỷ luật :";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNhanVien.Location = new System.Drawing.Point(0, 441);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.RowTemplate.Height = 24;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(1801, 250);
            this.dgvNhanVien.TabIndex = 2;
            // 
            // dgvNhanVienNhanKyLuat
            // 
            this.dgvNhanVienNhanKyLuat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVienNhanKyLuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVienNhanKyLuat.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvNhanVienNhanKyLuat.Location = new System.Drawing.Point(1227, 50);
            this.dgvNhanVienNhanKyLuat.Name = "dgvNhanVienNhanKyLuat";
            this.dgvNhanVienNhanKyLuat.RowHeadersWidth = 51;
            this.dgvNhanVienNhanKyLuat.RowTemplate.Height = 24;
            this.dgvNhanVienNhanKyLuat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVienNhanKyLuat.Size = new System.Drawing.Size(574, 391);
            this.dgvNhanVienNhanKyLuat.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1223, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Danh sách nhân viên bị kỷ luật :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // dgvKyLuat
            // 
            this.dgvKyLuat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKyLuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKyLuat.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvKyLuat.Location = new System.Drawing.Point(0, 50);
            this.dgvKyLuat.MultiSelect = false;
            this.dgvKyLuat.Name = "dgvKyLuat";
            this.dgvKyLuat.RowHeadersWidth = 51;
            this.dgvKyLuat.RowTemplate.Height = 24;
            this.dgvKyLuat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKyLuat.Size = new System.Drawing.Size(408, 391);
            this.dgvKyLuat.TabIndex = 5;
            this.dgvKyLuat.Click += new System.EventHandler(this.dgvKyLuat_Click);
            // 
            // dtpNgayKyLuat
            // 
            this.dtpNgayKyLuat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKyLuat.Location = new System.Drawing.Point(596, 125);
            this.dtpNgayKyLuat.Name = "dtpNgayKyLuat";
            this.dtpNgayKyLuat.Size = new System.Drawing.Size(255, 22);
            this.dtpNgayKyLuat.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(559, 419);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Danh sách nhân viên";
            this.label5.Click += new System.EventHandler(this.label2_Click);
            // 
            // AddNhanVienKyLuat
            // 
            this.AddNhanVienKyLuat.Location = new System.Drawing.Point(479, 167);
            this.AddNhanVienKyLuat.Name = "AddNhanVienKyLuat";
            this.AddNhanVienKyLuat.Size = new System.Drawing.Size(274, 42);
            this.AddNhanVienKyLuat.TabIndex = 7;
            this.AddNhanVienKyLuat.Text = "Thêm nhân viên kỷ luật";
            this.AddNhanVienKyLuat.UseVisualStyleBackColor = true;
            this.AddNhanVienKyLuat.Click += new System.EventHandler(this.AddNhanVienKyLuat_Click);
            // 
            // btnXoaNhanVienKyLuat
            // 
            this.btnXoaNhanVienKyLuat.Location = new System.Drawing.Point(479, 239);
            this.btnXoaNhanVienKyLuat.Name = "btnXoaNhanVienKyLuat";
            this.btnXoaNhanVienKyLuat.Size = new System.Drawing.Size(274, 42);
            this.btnXoaNhanVienKyLuat.TabIndex = 7;
            this.btnXoaNhanVienKyLuat.Text = "Xóa nhân viên kỷ luật";
            this.btnXoaNhanVienKyLuat.UseVisualStyleBackColor = true;
            this.btnXoaNhanVienKyLuat.Click += new System.EventHandler(this.btnXoaNhanVienKyLuat_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(479, 302);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(274, 42);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmKyLuat_NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1801, 691);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnXoaNhanVienKyLuat);
            this.Controls.Add(this.AddNhanVienKyLuat);
            this.Controls.Add(this.dtpNgayKyLuat);
            this.Controls.Add(this.dgvKyLuat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvNhanVienNhanKyLuat);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmKyLuat_NhanVien";
            this.Text = "frmKyLuat_NhanVien";
            this.Load += new System.EventHandler(this.frmKyLuat_NhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVienNhanKyLuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyLuat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.DataGridView dgvNhanVienNhanKyLuat;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgvKyLuat;
        private System.Windows.Forms.DateTimePicker dtpNgayKyLuat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddNhanVienKyLuat;
        private System.Windows.Forms.Button btnXoaNhanVienKyLuat;
        private System.Windows.Forms.Button btnClose;
    }
}