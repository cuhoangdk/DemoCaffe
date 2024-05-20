using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCaffe
{
    public partial class ThemHoaDonBanHang : Form
    {
        string maHD;
        string thoiGian;
        string maBan;
        string maNV;
        int soLuong;
        int giaCa;
        double tongTien;
        string maMH;
        private System.Windows.Forms.Timer timer;

        public ThemHoaDonBanHang()
        {
            InitializeComponent();
            this.Load += Set_MaHD_Tinme_Load; // Đăng ký sự kiện Load
            dataChiTietHoaDon();
            dataHoaDon();

            // Đăng ký sự kiện SelectedIndexChanged cho các ComboBox
            cbBan.SelectedIndexChanged += cbBan_SelectedIndexChanged;
            cbNhanVien.SelectedIndexChanged += cbNhanVien_SelectedIndexChanged;
        }

        private void Set_MaHD_Tinme_Load(object sender, EventArgs e)
        {
            currentTime();
            LoadBan();
            LoadNhanVien();
        }
        private void cbBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy giá trị của mục được chọn và gán vào biến maBan
            if (cbBan.SelectedItem is Ban selectedBan)
            {
                maBan = selectedBan.MaBan;
            }
        }

        private void cbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy giá trị của mục được chọn và gán vào biến maNV
            if (cbNhanVien.SelectedItem is NhanVien selectedNhanVien)
            {
                maNV = selectedNhanVien.MaNV;
            }
        }
        private void btnThemMH_Click(object sender, EventArgs e)
        {
            ThemChiTietHoaDon chiTietHoaDon = new ThemChiTietHoaDon(this);
            chiTietHoaDon.Show();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy các giá trị cần thiết từ các điều khiển trên form
            maHD = SetNextMaHD();
            thoiGian = txtThoiGian.Text;
            maBan = ((Ban)cbBan.SelectedItem).MaBan;
            maNV = ((NhanVien)cbNhanVien.SelectedItem).MaNV;
            tongTien = double.Parse(txtTongTien.Text);

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                try
                {
                    connection.Open();

                    // Tạo truy vấn SQL để chèn dữ liệu vào bảng HoaDon
                    string queryHD = "INSERT INTO HOADON (MaHD, MaBan, MaNV,ThoiGian) VALUES (@MaHD, @MaBan, @MaNV, @ThoiGian)";

                    // Tạo một đối tượng SqlCommand để thực thi truy vấn
                    using (SqlCommand command = new SqlCommand(queryHD, connection))
                    {
                        DateTime thoiGianDateTime;
                        if (DateTime.TryParseExact(thoiGian, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out thoiGianDateTime))
                        {
                            command.Parameters.AddWithValue("@ThoiGian", thoiGianDateTime);
                        }
                        else
                        {
                            MessageBox.Show("Chuỗi thời gian không hợp lệ.");
                        }
                        // Truyền các giá trị vào các tham số của truy vấn
                        command.Parameters.AddWithValue("@MaHD", maHD);
                        command.Parameters.AddWithValue("@MaBan", maBan);
                        command.Parameters.AddWithValue("@MaNV", maNV);

                        // Thực thi truy vấn
                        int rowsAffected = command.ExecuteNonQuery();

                        // Kiểm tra xem dữ liệu đã được chèn thành công hay không
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm hóa đơn thành công!");
                            // Thực hiện các hành động cần thiết sau khi thêm thành công
                        }
                        else
                        {
                            MessageBox.Show("Thêm hóa đơn không thành công!");
                        }
                    }

                    // Lặp qua các dòng trong DataGridView
                    foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
                    {
                        // Kiểm tra xem dòng hiện tại không phải là dòng mới và có chứa dữ liệu hợp lệ
                        if (!row.IsNewRow && row.Cells["MaMH"].Value != null)
                        {
                            maMH = row.Cells["MaMH"].Value.ToString();
                            // Lấy giá trị của cột MaMH từ dòng hiện tại
                            // Tiếp tục thêm mã mặt hàng vào bảng ChiTietHoaDon

                            // Tạo truy vấn SQL để chèn dữ liệu vào bảng HoaDon
                            string queryCTHD = "INSERT INTO CHITIETHOADON (MaHD, MaMH, SoLuong,GiaCa) VALUES (@MaHD, @MaMH, @SoLuong, @GiaCa)";

                            // Tạo một đối tượng SqlCommand để thực thi truy vấn
                            using (SqlCommand command = new SqlCommand(queryCTHD, connection))
                            {
                                command.Parameters.AddWithValue("@MaHD", maHD);
                                command.Parameters.AddWithValue("@MaMH", maMH);
                                command.Parameters.AddWithValue("@SoLuong", soLuong);
                                command.Parameters.AddWithValue("@GiaCa", giaCa);

                                // Thực thi truy vấn
                                int rowsAffected = command.ExecuteNonQuery();

                                // Kiểm tra xem dữ liệu đã được chèn thành công hay không
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Thêm chi tiết hóa đơn thành công!");
                                    // Thực hiện các hành động cần thiết sau khi thêm thành công
                                }
                                else
                                {
                                    MessageBox.Show("Thêm chi tiết hóa đơn không thành công!");
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            LoadHoaDon();
        }
        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải là hàng dữ liệu hay không
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dgvHoaDon.Rows[e.RowIndex];

                // Lấy giá trị từ các cột của hàng được chọn
                string maHD = selectedRow.Cells["Mã hóa đơn"].Value.ToString();
                string thoiGian = selectedRow.Cells["Thời gian"].Value.ToString();
                string maBan = selectedRow.Cells["Bàn"].Value.ToString();
                string maNV = selectedRow.Cells["Nhân viên"].Value.ToString();

                // Đặt các giá trị vào các điều khiển khác
                txtMaHD.Text = maHD;
                txtThoiGian.Text = thoiGian;
                cbBan.SelectedItem = maBan; // Giả sử bạn đã load dữ liệu vào ComboBox Ban
                cbNhanVien.SelectedItem = maNV; // Giả sử bạn đã load dữ liệu vào ComboBox 
            }
        }
        private void dataChiTietHoaDon()
        {
            dgvChiTietHoaDon.Columns.Add("MaMH", "Mã MH");
            dgvChiTietHoaDon.Columns.Add("TenMH", "Tên MH");
            dgvChiTietHoaDon.Columns.Add("GiaCa", "Giá Cả");
            dgvChiTietHoaDon.Columns.Add("DVT", "ĐVT");
            dgvChiTietHoaDon.Columns.Add("MaLoai", "MaLoai");
            dgvChiTietHoaDon.Columns.Add("SoLuong", "Số Lượng");
        }
        private void dataHoaDon()
        {
            // Tạo một DataTable để chứa dữ liệu từ bảng HoaDon
            DataTable dataTable = new DataTable();

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                try
                {
                    connection.Open();

                    // Truy vấn để lấy dữ liệu từ bảng HoaDon
                    string query = "SELECT * FROM HoaDon";

                    // Tạo một đối tượng SqlCommand để thực thi truy vấn
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Tạo một DataAdapter để lấy dữ liệu từ cơ sở dữ liệu
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        // Đổ dữ liệu từ DataAdapter vào DataTable
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            // Đặt lại tên cho các cột trong DataTable
            dataTable.Columns["MaHD"].ColumnName = "Mã hóa đơn";
            dataTable.Columns["ThoiGian"].ColumnName = "Thời gian";
            dataTable.Columns["MaBan"].ColumnName = "Bàn";
            dataTable.Columns["MaNV"].ColumnName = "Nhân viên";
            dataTable.Columns.Add("Tổng tiền");

            // Thiết lập DataSource của DataGridView là DataTable vừa lấy được
            dgvHoaDon.DataSource = dataTable;

        }
        public void AddChiTietHoaDon(string maMH, string tenMH, string giaCa, string dvt, string maLoai, int soLuong)
        {
            bool isExisting = false;

            // Kiểm tra xem mã hàng đã tồn tại chưa
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.Cells["MaMH"].Value != null && row.Cells["MaMH"].Value.ToString() == maMH)
                {
                    // Nếu tồn tại, cộng dồn số lượng
                    int currentSoLuong = int.Parse(row.Cells["SoLuong"].Value.ToString());
                    row.Cells["SoLuong"].Value = currentSoLuong + soLuong;

                    // Cập nhật tổng tiền
                    double currentGiaCa = double.Parse(row.Cells["GiaCa"].Value.ToString());
                    totalFunds(currentGiaCa * soLuong);

                    isExisting = true;
                    break;
                }
            }

            // Nếu không tồn tại, thêm một dòng mới
            if (!isExisting)
            {
                dgvChiTietHoaDon.Rows.Add(maMH, tenMH, giaCa, dvt, maLoai, soLuong);

                // Parse giaCa và soLuong cho việc tính toán tổng số tiền
                this.giaCa = int.Parse(giaCa);
                totalFunds(this.giaCa * soLuong);
            }
            this.maMH = maMH;
            this.soLuong = soLuong;
        }
        private string SetNextMaHD()
        {
            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                try
                {
                    connection.Open();

                    // Truy vấn để lấy mã hóa đơn lớn nhất
                    string query = "SELECT MAX(MaHD) FROM HoaDon";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            string maxMaHD = result.ToString();
                            string prefix = "HD";
                            int currentNumber = int.Parse(maxMaHD.Substring(prefix.Length));
                            int nextNumber = currentNumber + 1;
                            maHD = prefix + nextNumber.ToString("D4"); // Định dạng số với 4 chữ số (D4)
                            return maHD;
                        }
                        else
                        {
                            // Nếu bảng không có mã hóa đơn nào, khởi tạo mã hóa đơn đầu tiên
                            maHD = "HD0001";
                            return maHD;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            return maHD;
        }

        private void currentTime()
        {
            DateTime currentTime = DateTime.Now;

            // Định dạng thời gian theo ý muốn (ví dụ: "dd/MM/yyyy HH:mm:ss")
            thoiGian = currentTime.ToString("dd/MM/yyyy HH:mm:ss");

            txtThoiGian.Text = thoiGian;
        }
        private void totalFunds(double sum)
        {
            // Lấy giá trị hiện tại của txtTongTien và cộng thêm amount
            tongTien = string.IsNullOrEmpty(txtTongTien.Text) ? 0 : double.Parse(txtTongTien.Text);
            tongTien += sum;
            txtTongTien.Text = tongTien.ToString();
        }
        private void LoadBan()
        {
            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                try
                {
                    connection.Open();

                    // Truy vấn để lấy danh sách các loại mặt hàng
                    string query = "SELECT MaBan, TinhTrang FROM BAN";

                    // Tạo một đối tượng SqlCommand để thực thi truy vấn
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        // Duyệt qua các dòng kết quả và thêm vào ComboBox
                        while (reader.Read())
                        {
                            string maBan = reader["MaBan"].ToString();
                            string tinhTrang = reader["TinhTrang"].ToString();
                            cbBan.Items.Add(new Ban(maBan, tinhTrang));
                            
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
        private void LoadNhanVien()
        {
            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                try
                {
                    connection.Open();

                    // Truy vấn để lấy danh sách các loại mặt hàng
                    string query = "SELECT MaNV, HoNV, TenNV, Email, DiaChi, MatKhau, ChucVu, GioiTinh, SDT, CCCD FROM NHANVIEN";

                    // Tạo một đối tượng SqlCommand để thực thi truy vấn
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        // Duyệt qua các dòng kết quả và thêm vào ComboBox
                        while (reader.Read())
                        {
                            string MaNV = reader["MaNV"].ToString();
                            string HoNV = reader["HoNV"].ToString();
                            string TenNV = reader["TenNV"].ToString();
                            string Email = reader["Email"].ToString();
                            string DiaChi = reader["DiaChi"].ToString();
                            string MatKhau = reader["MatKhau"].ToString();
                            string ChucVu = reader["ChucVu"].ToString();
                            string GioiTinh = reader["GioiTinh"].ToString();
                            string SDT = reader["SDT"].ToString();
                            string CCCD = reader["CCCD"].ToString();
                            cbNhanVien.Items.Add(new NhanVien(MaNV, HoNV, TenNV, Email, DiaChi, MatKhau, ChucVu, GioiTinh, SDT, CCCD));
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
        private void LoadHoaDon()
        {
            // Xây dựng câu truy vấn để lấy dữ liệu từ cơ sở dữ liệu
            string query = "SELECT * FROM HoaDon";

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                try
                {
                    connection.Open();

                    // Tạo một đối tượng SqlCommand để thực thi truy vấn
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Tạo một DataAdapter để lấy dữ liệu từ cơ sở dữ liệu
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();

                        // Đổ dữ liệu vào DataTable
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu trên DataGridView
                        dgvHoaDon.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

		private void btn_LamMoi_Click(object sender, EventArgs e)
		{		
			txtThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
			txtTongTien.Clear();
			cbBan.SelectedIndex = -1; 
            cbNhanVien.SelectedIndex = -1;
		}
	}
}
