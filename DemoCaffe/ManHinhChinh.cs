﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCaffe
{
	public partial class ManHinhChinh : Form
	{
		public ManHinhChinh()
		{
			InitializeComponent();
		}

		private void btnThemMatHang_Click(object sender, EventArgs e)
		{
			ThemMatHang themMatHang = new ThemMatHang();			
			themMatHang.ShowDialog();
		}

		private void btnTimKiemMatHang_Click(object sender, EventArgs e)
		{
			TimKiemMatHang timKiemMatHang = new TimKiemMatHang();
			timKiemMatHang.ShowDialog();
		}

		private void btnThemHoaDonXuat_Click(object sender, EventArgs e)
		{
			ThemHoaDonBanHang themHoaDonBanHang = new ThemHoaDonBanHang();
			themHoaDonBanHang.ShowDialog();
		}

		private void btnThongKe_Click(object sender, EventArgs e)
		{
			ThongKeChungTheoMatHang thongKeChungTheoMatHang = new ThongKeChungTheoMatHang();
			thongKeChungTheoMatHang.ShowDialog();
		}		
	}
}
