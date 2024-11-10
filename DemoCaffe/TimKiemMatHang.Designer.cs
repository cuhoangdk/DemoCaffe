namespace DemoCaffe
{
    partial class TimKiemMatHang
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
			this.label2 = new System.Windows.Forms.Label();
			this.dgvMatHang = new System.Windows.Forms.DataGridView();
			this.cbLoaiMH = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTenMH = new System.Windows.Forms.TextBox();
			this.btnQuayLai = new System.Windows.Forms.Button();
			this.btnLamMoi = new System.Windows.Forms.Button();
			this.btnTimKiem = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtGiaMin = new System.Windows.Forms.TextBox();
			this.txtGiaMax = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvMatHang)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(500, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(363, 38);
			this.label2.TabIndex = 4;
			this.label2.Text = "TRA CỨU MẶT HÀNG";
			// 
			// dgvMatHang
			// 
			this.dgvMatHang.AllowUserToAddRows = false;
			this.dgvMatHang.AllowUserToDeleteRows = false;
			this.dgvMatHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMatHang.Location = new System.Drawing.Point(417, 80);
			this.dgvMatHang.Name = "dgvMatHang";
			this.dgvMatHang.ReadOnly = true;
			this.dgvMatHang.RowHeadersWidth = 51;
			this.dgvMatHang.RowTemplate.Height = 24;
			this.dgvMatHang.Size = new System.Drawing.Size(1009, 461);
			this.dgvMatHang.TabIndex = 13;
			// 
			// cbLoaiMH
			// 
			this.cbLoaiMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbLoaiMH.FormattingEnabled = true;
			this.cbLoaiMH.Location = new System.Drawing.Point(186, 142);
			this.cbLoaiMH.Name = "cbLoaiMH";
			this.cbLoaiMH.Size = new System.Drawing.Size(215, 33);
			this.cbLoaiMH.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(26, 145);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(141, 25);
			this.label4.TabIndex = 16;
			this.label4.Text = "Loại mặt hàng:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(26, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(139, 25);
			this.label3.TabIndex = 15;
			this.label3.Text = "Tên mặt hàng:";
			// 
			// txtTenMH
			// 
			this.txtTenMH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTenMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTenMH.Location = new System.Drawing.Point(186, 80);
			this.txtTenMH.Name = "txtTenMH";
			this.txtTenMH.Size = new System.Drawing.Size(215, 30);
			this.txtTenMH.TabIndex = 14;
			// 
			// btnQuayLai
			// 
			this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnQuayLai.Location = new System.Drawing.Point(31, 497);
			this.btnQuayLai.Name = "btnQuayLai";
			this.btnQuayLai.Size = new System.Drawing.Size(113, 44);
			this.btnQuayLai.TabIndex = 19;
			this.btnQuayLai.Text = "Quay lại";
			this.btnQuayLai.UseVisualStyleBackColor = true;
			this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
			// 
			// btnLamMoi
			// 
			this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLamMoi.Location = new System.Drawing.Point(217, 361);
			this.btnLamMoi.Name = "btnLamMoi";
			this.btnLamMoi.Size = new System.Drawing.Size(184, 49);
			this.btnLamMoi.TabIndex = 21;
			this.btnLamMoi.Text = "Làm mới";
			this.btnLamMoi.UseVisualStyleBackColor = true;
			this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
			// 
			// btnTimKiem
			// 
			this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTimKiem.Location = new System.Drawing.Point(31, 361);
			this.btnTimKiem.Name = "btnTimKiem";
			this.btnTimKiem.Size = new System.Drawing.Size(180, 49);
			this.btnTimKiem.TabIndex = 20;
			this.btnTimKiem.Text = "Tìm kiếm";
			this.btnTimKiem.UseVisualStyleBackColor = true;
			this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(26, 202);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 25);
			this.label1.TabIndex = 22;
			this.label1.Text = "Đơn giá:";
			// 
			// txtGiaMin
			// 
			this.txtGiaMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGiaMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtGiaMin.Location = new System.Drawing.Point(31, 252);
			this.txtGiaMin.Name = "txtGiaMin";
			this.txtGiaMin.Size = new System.Drawing.Size(166, 30);
			this.txtGiaMin.TabIndex = 23;
			// 
			// txtGiaMax
			// 
			this.txtGiaMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGiaMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtGiaMax.Location = new System.Drawing.Point(228, 252);
			this.txtGiaMax.Name = "txtGiaMax";
			this.txtGiaMax.Size = new System.Drawing.Size(173, 30);
			this.txtGiaMax.TabIndex = 24;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(203, 254);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(19, 25);
			this.label5.TabIndex = 25;
			this.label5.Text = "-";
			// 
			// TimKiemMatHang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1462, 553);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtGiaMax);
			this.Controls.Add(this.txtGiaMin);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnLamMoi);
			this.Controls.Add(this.btnTimKiem);
			this.Controls.Add(this.btnQuayLai);
			this.Controls.Add(this.cbLoaiMH);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtTenMH);
			this.Controls.Add(this.dgvMatHang);
			this.Controls.Add(this.label2);
			this.Name = "TimKiemMatHang";
			this.Text = "Tra cứu mặt hàng";
			this.Load += new System.EventHandler(this.TimKiemMatHang_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvMatHang)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvMatHang;
        private System.Windows.Forms.ComboBox cbLoaiMH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenMH;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGiaMin;
        private System.Windows.Forms.TextBox txtGiaMax;
        private System.Windows.Forms.Label label5;
    }
}