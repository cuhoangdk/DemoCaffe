using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCaffe
{
	internal class LoaiMatHangItem
	{
		public string MaLoai { get; set; }
		public string TenLoai { get; set; }

		public LoaiMatHangItem(string maLoai, string tenLoai)
		{
			MaLoai = maLoai;
			TenLoai = tenLoai;
		}

		public override string ToString()
		{
			return TenLoai; // Hiển thị tên loại mặt hàng trong ComboBox
		}
	}
}
