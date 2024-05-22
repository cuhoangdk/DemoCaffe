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
    public partial class ThongKeChungTheoMatHang : Form
    {
        public ThongKeChungTheoMatHang()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime tuNgay;
            DateTime denNgay;

            // Validate the dates
            if (!DateTime.TryParse(txtTuNgay.Text, out tuNgay) || !DateTime.TryParse(txtDenNgay.Text, out denNgay))
            {
                MessageBox.Show("Ngày không hợp lệ. Vui lòng nhập lại ngày hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tuNgay > denNgay)
            {
                MessageBox.Show("'Từ ngày' phải nhỏ hơn hoặc bằng 'Đến ngày'.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xây dựng câu truy vấn cơ bản
            string query = "SELECT " +
                           "m.MaMH AS 'Mã mặt hàng', " +
                           "m.TenMH AS 'Tên mặt hàng', " +
                           "SUM(cthd.SoLuong) AS 'Số lượng bán được', " +
                           "SUM(cthd.SoLuong * cthd.GiaCa) AS 'Doanh thu bán' " +
                           "FROM HOADON hd " +
                           "JOIN CHITIETHOADON cthd ON hd.MAHD = cthd.MAHD " +
                           "JOIN Menu m ON cthd.MaMH = m.MaMH " +
                           "WHERE 1=1";

            // Thêm điều kiện thời gian nếu có
            if (!string.IsNullOrWhiteSpace(txtTuNgay.Text) && !string.IsNullOrWhiteSpace(txtDenNgay.Text))
            {
                query += " AND hd.ThoiGian BETWEEN @TuNgay AND @DenNgay";
            }

            // Kết thúc câu truy vấn
            query += " GROUP BY m.MaMH, m.TenMH ORDER BY 'Doanh thu bán' DESC";

            string doanhThuQuery = "SELECT SUM(cthd.SoLuong * cthd.GiaCa) AS TongDoanhThu " +
                           "FROM HOADON hd " +
                           "JOIN CHITIETHOADON cthd ON hd.MaHD = cthd.MaHD " +
                           "WHERE hd.ThoiGian BETWEEN @TuNgay AND @DenNgay";

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
                        if (!string.IsNullOrWhiteSpace(txtTuNgay.Text) && !string.IsNullOrWhiteSpace(txtDenNgay.Text))
                        {
                            command.Parameters.AddWithValue("@TuNgay", tuNgay);
                            command.Parameters.AddWithValue("@DenNgay", denNgay);
                        }

                        // Tạo một DataAdapter để lấy dữ liệu từ cơ sở dữ liệu
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        // Tạo một DataGridViewCellStyle mới
                        DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();

                        // Thiết lập font cho cellStyle
                        cellStyle.Font = new Font("Arial", 12); // Thay đổi kích thước font ở đây

                        // Áp dụng cellStyle cho cột trong DataGridView
                        dgvMatHang.DefaultCellStyle = cellStyle;
                        dgvMatHang.ColumnHeadersDefaultCellStyle = cellStyle;
                        // Đổ dữ liệu vào DataTable
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu trên DataGridView
                        dgvMatHang.DataSource = dataTable;
                    }
                    // Thực thi truy vấn tính tổng doanh thu
                    using (SqlCommand doanhThuCommand = new SqlCommand(doanhThuQuery, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(txtTuNgay.Text) && !string.IsNullOrWhiteSpace(txtDenNgay.Text))
                        {
                            doanhThuCommand.Parameters.AddWithValue("@TuNgay", tuNgay);
                            doanhThuCommand.Parameters.AddWithValue("@DenNgay", denNgay);
                        }

                        // Thực thi truy vấn và lấy kết quả
                        object result = doanhThuCommand.ExecuteScalar();
                        if (result != null)
                        {
                            txtTongDoanhThu.Text = result.ToString() + " VNĐ";
                        }
                        else
                        {
                            txtTongDoanhThu.Text = "0 VNĐ";
                        }
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
            dgvMatHang.DataSource = null;
            txtDenNgay.Clear();
            txtTuNgay.Clear();
        }
		private void btnQuayLai_Click(object sender, EventArgs e)
		{
            this.Close();
		}
	}
}
