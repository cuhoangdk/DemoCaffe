using System;
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
    public partial class ThemMatHang : Form
    {		
        public ThemMatHang()
        {
            InitializeComponent();
        }


		private void btnThem_Click(object sender, EventArgs e)
		{
			// Kiểm tra xem đã chọn một loại mặt hàng từ ComboBox chưa
			if (cbLoaiMH.SelectedItem == null)
			{
				MessageBox.Show("Vui lòng chọn một loại mặt hàng.");
				return;
			}

			// Lấy mã loại mặt hàng từ đối tượng được chọn
			string maLoai = ((LoaiMatHangItem)cbLoaiMH.SelectedItem).MaLoai;
			string tenMH = txtTenMH.Text;

			// Mở kết nối đến cơ sở dữ liệu
			using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
			{
				try
				{
					connection.Open();

					// Kiểm tra sự tồn tại của sản phẩm với tên cụ thể
					string queryCheckExist = "SELECT COUNT(*) FROM MENU WHERE TenMH = @TenMH";
					using (SqlCommand checkExistCommand = new SqlCommand(queryCheckExist, connection))
					{
						checkExistCommand.Parameters.AddWithValue("@TenMH", tenMH);
						int count = (int)checkExistCommand.ExecuteScalar();

						if (count > 0)
						{
							MessageBox.Show("Sản phẩm với tên này đã tồn tại. Vui lòng chọn tên khác.");
							return;
						}
					}

					// Tạo mã mặt hàng tự động bằng cách ghép mã loại với số thứ tự
					string queryGetMaxMaMH = "SELECT MAX(MaMH) FROM MENU WHERE MaMH LIKE @MaLoaiPrefix";
					using (SqlCommand getMaxMaMHCommand = new SqlCommand(queryGetMaxMaMH, connection))
					{
						// Xác định số thứ tự tiếp theo cho mặt hàng trong loại đó
						getMaxMaMHCommand.Parameters.AddWithValue("@MaLoaiPrefix", maLoai + "%");
						object maxMaMHObject = getMaxMaMHCommand.ExecuteScalar();
						int nextNumber = 1;

						if (maxMaMHObject != null && maxMaMHObject != DBNull.Value)
						{
							string maxMaMH = maxMaMHObject.ToString();
							string numberPart = maxMaMH.Substring(maLoai.Length); // Lấy phần số thứ tự từ mã mặt hàng
							int.TryParse(numberPart, out int currentNumber);
							nextNumber = currentNumber + 1;
						}

						string newMaMH = maLoai + nextNumber.ToString().PadLeft(3, '0'); // Ghép mã loại với số thứ tự

						// Tạo truy vấn SQL để thêm mặt hàng mới
						string query = "INSERT INTO MENU (MaMH, TenMH, GiaCa, DVT, MaLoai) VALUES (@MaMH, @TenMH, @GiaCa, @DVT, @MaLoai)";

						// Tạo một đối tượng SqlCommand để thực thi truy vấn
						using (SqlCommand command = new SqlCommand(query, connection))
						{
							// Truyền các giá trị từ các điều khiển trên giao diện người dùng vào truy vấn
							command.Parameters.AddWithValue("@MaMH", newMaMH);
							command.Parameters.AddWithValue("@TenMH", tenMH);
							command.Parameters.AddWithValue("@GiaCa", Convert.ToDecimal(txtDonGia.Text));
							command.Parameters.AddWithValue("@DVT", txtDVT.Text);
							command.Parameters.AddWithValue("@MaLoai", maLoai);

							// Thực thi truy vấn
							int rowsAffected = command.ExecuteNonQuery();

							if (rowsAffected > 0)
							{
								MessageBox.Show("Thêm mặt hàng thành công!");

								// Hiển thị lại danh sách mặt hàng trên DataGridView
								LoadMatHang();

								// Sau khi thêm thành công, bạn có thể làm mới giao diện người dùng hoặc thực hiện các hành động khác cần thiết.
							}
							else
							{
								MessageBox.Show("Thêm mặt hàng không thành công!");
							}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi: " + ex.Message);
				}
			}
		}
		private void LoadMatHang()
		{
			// Mở kết nối đến cơ sở dữ liệu
			using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
			{
				try
				{
					connection.Open();

					// Truy vấn để lấy danh sách các mặt hàng kèm theo tên loại mặt hàng
					string query = "SELECT MENU.*, LOAIMATHANG.TenLoai " +
								   "FROM MENU " +
								   "INNER JOIN LOAIMATHANG ON MENU.MaLoai = LOAIMATHANG.MaLoai";

					// Tạo một đối tượng SqlCommand để thực thi truy vấn
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						SqlDataAdapter adapter = new SqlDataAdapter(command);
						DataTable dataTable = new DataTable();
						adapter.Fill(dataTable);

						// Thêm cột số thứ tự vào DataTable
						dataTable.Columns.Add("STT", typeof(int));
						int i = 1;
						foreach (DataRow row in dataTable.Rows)
						{
							row["STT"] = i++;
						}

						// Xóa cột "MaLoai" từ DataTable
						dataTable.Columns.Remove("MaLoai");

						// Đặt lại tên cột số thứ tự và đặt lại thứ tự cột
						dataTable.Columns["STT"].SetOrdinal(0);
						dataTable.Columns["STT"].Caption = "Số thứ tự";

						// Đặt tên cho các cột
						dataTable.Columns["TenLoai"].ColumnName = "Tên loại";
						dataTable.Columns["TenMH"].ColumnName = "Tên mặt hàng";
						dataTable.Columns["GiaCa"].ColumnName = "Giá cả";
						dataTable.Columns["DVT"].ColumnName = "Đơn vị tính";
						// Di chuyển cột "Tên loại" để nằm bên phải cột "Tên mặt hàng"
						int tenMatHangIndex = dataTable.Columns.IndexOf("Tên mặt hàng");
						int tenLoaiIndex = dataTable.Columns.IndexOf("Tên loại");
						if (tenMatHangIndex < tenLoaiIndex)
						{
							dataTable.Columns["Tên loại"].SetOrdinal(tenMatHangIndex + 1);
						}
						dataTable.Columns["Giá cả"].SetOrdinal(dataTable.Columns.Count - 1);
						// Thiết lập lại thứ tự của các cột
						dgvMatHang.DataSource = dataTable;
						dgvMatHang.ReadOnly = true;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi: " + ex.Message);
				}
			}
		}
		private void ThemMatHang_Load(object sender, EventArgs e)
		{
			LoadLoaiMatHang();
			LoadMatHang();
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
		private void btnQuayLai_Click(object sender, EventArgs e)
		{
			this.Close();
		}
    }
}
