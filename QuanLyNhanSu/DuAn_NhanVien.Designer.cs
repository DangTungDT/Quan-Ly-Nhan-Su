namespace QuanLyNhanSu
{
    partial class DuAn_NhanVien
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVaiTroNV = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtBatDau = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIDNVien = new System.Windows.Forms.TextBox();
            this.cbDuAn = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(711, 252);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 62);
            this.btnClose.TabIndex = 86;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(546, 252);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 62);
            this.btnEdit.TabIndex = 85;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(711, 138);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 62);
            this.btnDelete.TabIndex = 84;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(546, 138);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 62);
            this.btnAdd.TabIndex = 83;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 342);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 27);
            this.label3.TabIndex = 80;
            this.label3.Text = "Ngày tạo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 19);
            this.label6.TabIndex = 79;
            this.label6.Text = "Vai trò nhân viên :";
            // 
            // txtVaiTroNV
            // 
            this.txtVaiTroNV.Location = new System.Drawing.Point(237, 217);
            this.txtVaiTroNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVaiTroNV.Name = "txtVaiTroNV";
            this.txtVaiTroNV.Size = new System.Drawing.Size(259, 27);
            this.txtVaiTroNV.TabIndex = 78;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 394);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(865, 264);
            this.dataGridView1.TabIndex = 77;
            // 
            // dtBatDau
            // 
            this.dtBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBatDau.Location = new System.Drawing.Point(237, 274);
            this.dtBatDau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtBatDau.Name = "dtBatDau";
            this.dtBatDau.Size = new System.Drawing.Size(259, 27);
            this.dtBatDau.TabIndex = 76;
            this.dtBatDau.Value = new System.DateTime(2025, 3, 27, 11, 26, 42, 0);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 277);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 27);
            this.label5.TabIndex = 74;
            this.label5.Text = "Ngày bắt đầu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 72;
            this.label2.Text = "Tên dự án :";
            // 
            // dtpNgayTao
            // 
            this.dtpNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTao.Location = new System.Drawing.Point(237, 334);
            this.dtpNgayTao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(259, 27);
            this.dtpNgayTao.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(865, 59);
            this.label1.TabIndex = 70;
            this.label1.Text = "DỰ ÁN_NHÂN VIÊN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(51, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 19);
            this.label7.TabIndex = 88;
            this.label7.Text = "ID nhân viên :";
            // 
            // txtIDNVien
            // 
            this.txtIDNVien.Location = new System.Drawing.Point(237, 158);
            this.txtIDNVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDNVien.Name = "txtIDNVien";
            this.txtIDNVien.Size = new System.Drawing.Size(259, 27);
            this.txtIDNVien.TabIndex = 87;
            // 
            // cbDuAn
            // 
            this.cbDuAn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbDuAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDuAn.FormattingEnabled = true;
            this.cbDuAn.Location = new System.Drawing.Point(237, 100);
            this.cbDuAn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDuAn.Name = "cbDuAn";
            this.cbDuAn.Size = new System.Drawing.Size(259, 27);
            this.cbDuAn.TabIndex = 89;
            // 
            // DuAn_NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 658);
            this.Controls.Add(this.cbDuAn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIDNVien);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtVaiTroNV);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dtBatDau);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpNgayTao);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DuAn_NhanVien";
            this.Text = "DuAn_NhanVien";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DuAn_NhanVien_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVaiTroNV;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtBatDau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIDNVien;
        private System.Windows.Forms.ComboBox cbDuAn;
    }
}