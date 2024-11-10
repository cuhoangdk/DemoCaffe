namespace DemoCaffe
{
	partial class ManHinhChinh
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
			this.btnThemMatHang = new System.Windows.Forms.Button();
			this.btnTimKiemMatHang = new System.Windows.Forms.Button();
			this.btnThemHoaDonXuat = new System.Windows.Forms.Button();
			this.btnThongKe = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label1.Location = new System.Drawing.Point(252, 82);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(278, 36);
			this.label1.TabIndex = 0;
			this.label1.Text = "MÀN HÌNH CHÍNH";
			// 
			// btnThemMatHang
			// 
			this.btnThemMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnThemMatHang.Location = new System.Drawing.Point(81, 139);
			this.btnThemMatHang.Name = "btnThemMatHang";
			this.btnThemMatHang.Size = new System.Drawing.Size(230, 105);
			this.btnThemMatHang.TabIndex = 1;
			this.btnThemMatHang.Text = "THÊM MẶT HÀNG";
			this.btnThemMatHang.UseVisualStyleBackColor = true;
			this.btnThemMatHang.Click += new System.EventHandler(this.btnThemMatHang_Click);
			// 
			// btnTimKiemMatHang
			// 
			this.btnTimKiemMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnTimKiemMatHang.Location = new System.Drawing.Point(437, 139);
			this.btnTimKiemMatHang.Name = "btnTimKiemMatHang";
			this.btnTimKiemMatHang.Size = new System.Drawing.Size(230, 105);
			this.btnTimKiemMatHang.TabIndex = 2;
			this.btnTimKiemMatHang.Text = "TÌM KIẾM MẶT HÀNG";
			this.btnTimKiemMatHang.UseVisualStyleBackColor = true;
			this.btnTimKiemMatHang.Click += new System.EventHandler(this.btnTimKiemMatHang_Click);
			// 
			// btnThemHoaDonXuat
			// 
			this.btnThemHoaDonXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnThemHoaDonXuat.Location = new System.Drawing.Point(81, 304);
			this.btnThemHoaDonXuat.Name = "btnThemHoaDonXuat";
			this.btnThemHoaDonXuat.Size = new System.Drawing.Size(230, 105);
			this.btnThemHoaDonXuat.TabIndex = 3;
			this.btnThemHoaDonXuat.Text = "THÊM HOÁ ĐƠN BÁN HÀNG";
			this.btnThemHoaDonXuat.UseVisualStyleBackColor = true;
			this.btnThemHoaDonXuat.Click += new System.EventHandler(this.btnThemHoaDonXuat_Click);
			// 
			// btnThongKe
			// 
			this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnThongKe.Location = new System.Drawing.Point(437, 304);
			this.btnThongKe.Name = "btnThongKe";
			this.btnThongKe.Size = new System.Drawing.Size(230, 105);
			this.btnThongKe.TabIndex = 4;
			this.btnThongKe.Text = "THÔNG KÊ DOANH THU";
			this.btnThongKe.UseVisualStyleBackColor = true;
			this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label2.Location = new System.Drawing.Point(233, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(330, 39);
			this.label2.TabIndex = 5;
			this.label2.Text = "CÀ PHÊ GÓC NHỎ";
			// 
			// ManHinhChinh
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnThongKe);
			this.Controls.Add(this.btnThemHoaDonXuat);
			this.Controls.Add(this.btnTimKiemMatHang);
			this.Controls.Add(this.btnThemMatHang);
			this.Controls.Add(this.label1);
			this.Name = "ManHinhChinh";
			this.Text = "ManHinhChinh";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnThemMatHang;
		private System.Windows.Forms.Button btnTimKiemMatHang;
		private System.Windows.Forms.Button btnThemHoaDonXuat;
		private System.Windows.Forms.Button btnThongKe;
		private System.Windows.Forms.Label label2;
	}
}