﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCaffe
{
    public partial class TimKiemMatHang : Form
    {
        public TimKiemMatHang()
        {
            InitializeComponent();            
        }

        private void TimKiemMatHang_Load(object sender, EventArgs e)
		{
			LoadLoaiMatHang();			
		}

		private void LoadLoaiMatHang()
		{
			// Mở kết nối đến cơ sở dữ liệu
			using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
			{
				try
				{
					connection.Open();

					// Truy vấn để lấy danh sách các loại mặt hàng
					string query = "SELECT MaLoai, TenLoai FROM LOAIMATHANG";

					// Tạo một đối tượng SqlCommand để thực thi truy vấn
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						SqlDataReader reader = command.ExecuteReader();

						// Duyệt qua các dòng kết quả và thêm vào ComboBox
						while (reader.Read())
						{
							string maLoai = reader["MaLoai"].ToString();
							string tenLoai = reader["TenLoai"].ToString();
							cbLoaiMH.Items.Add(new LoaiMatHangItem(maLoai, tenLoai));
						}

						// Đóng DataReader sau khi sử dụng
						reader.Close();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi: " + ex.Message);
				}
			}
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			// Xây dựng câu truy vấn dựa trên điều kiện tìm kiếm
			string query = "SELECT MENU.MaMH, MENU.TenMH, MENU.GiaCa, MENU.DVT, LOAIMATHANG.TenLoai " +
						   "FROM MENU " +
						   "INNER JOIN LOAIMATHANG ON MENU.MaLoai = LOAIMATHANG.MaLoai " +
						   "WHERE 1=1";

			if (!string.IsNullOrWhiteSpace(txtTenMH.Text))
			{
				query += " AND TenMH LIKE @TenMH";
			}

			if (cbLoaiMH.SelectedItem != null)
			{
				string maLoai = ((LoaiMatHangItem)cbLoaiMH.SelectedItem).MaLoai;
				query += " AND MENU.MaLoai = @MaLoai";
			}

			if (!string.IsNullOrWhiteSpace(txtGiaMin.Text) && !string.IsNullOrWhiteSpace(txtGiaMax.Text))
			{
				query += " AND GiaCa BETWEEN @GiaTu AND @GiaDen";
			}

			// Mở kết nối đến cơ sở dữ liệu
			using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
			{
				try
				{
					connection.Open();

					// Tạo một đối tượng SqlCommand để thực thi truy vấn
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						// Truyền các tham số tìm kiếm vào truy vấn
						command.Parameters.AddWithValue("@TenMH", "%" + txtTenMH.Text + "%");

						if (cbLoaiMH.SelectedItem != null)
						{
							string maLoai = ((LoaiMatHangItem)cbLoaiMH.SelectedItem).MaLoai;
							command.Parameters.AddWithValue("@MaLoai", maLoai);
						}

						if (!string.IsNullOrWhiteSpace(txtGiaMin.Text) && !string.IsNullOrWhiteSpace(txtGiaMax.Text))
						{
							command.Parameters.AddWithValue("@GiaTu", Convert.ToDecimal(txtGiaMin.Text));
							command.Parameters.AddWithValue("@GiaDen", Convert.ToDecimal(txtGiaMax.Text));
						}

						// Tạo một DataAdapter để lấy dữ liệu từ cơ sở dữ liệu
						SqlDataAdapter adapter = new SqlDataAdapter(command);
						DataTable dataTable = new DataTable();

						// Đổ dữ liệu vào DataTable
						adapter.Fill(dataTable);
						// Thêm cột STT vào DataTable và đánh số thứ tự
						dataTable.Columns.Add("STT", typeof(int));
						for (int i = 0; i < dataTable.Rows.Count; i++)
						{
							dataTable.Rows[i]["STT"] = i + 1;
						}

						// Thiết lập lại tên cột
						dataTable.Columns["STT"].SetOrdinal(0);
						dataTable.Columns["TenLoai"].ColumnName = "Tên loại";
						dataTable.Columns["MaMH"].ColumnName = "Mã mặt hàng";
						dataTable.Columns["TenMH"].ColumnName = "Tên mặt hàng";
						dataTable.Columns["GiaCa"].ColumnName = "Giá cả";
						dataTable.Columns["DVT"].ColumnName = "Đơn vị tính";

						// Đổi vị trí cột "Tên loại" và "Giá cả"
						int tenMatHangIndex = dataTable.Columns.IndexOf("Tên mặt hàng");
						int tenLoaiIndex = dataTable.Columns.IndexOf("Tên loại");
						if (tenMatHangIndex < tenLoaiIndex)
						{
							dataTable.Columns["Tên loại"].SetOrdinal(tenMatHangIndex + 1);
						}
						dataTable.Columns["Giá cả"].SetOrdinal(dataTable.Columns.Count - 1); // Đặt "Giá cả" vào cuối cùng

						// Đặt lại nguồn dữ liệu cho DataGridView
						dgvMatHang.DataSource = dataTable;

					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi: " + ex.Message);
				}
			}
		}


		private void btnLamMoi_Click(object sender, EventArgs e)
		{
			// Gọi lại phương thức LoadLoaiMatHang để làm mới ComboBox Loại mặt hàng
			LoadLoaiMatHang();

			// Xóa nội dung các điều khiển tìm kiếm
			txtTenMH.Clear();
			txtGiaMin.Clear();
			txtGiaMax.Clear();
			cbLoaiMH.SelectedIndex = -1; // Bỏ chọn mục được chọn trong ComboBox Loại mặt hàng

			// Xóa dữ liệu trên DataGridView
			dgvMatHang.DataSource = null;
		}
		private void btnQuayLai_Click(object sender, EventArgs e)
		{
			this.Close();			
		}		
	}
}
