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
    public partial class ThemChiTietHoaDon : Form
    {
        private ThemHoaDonBanHang parentForm;
        private string selectedMaMH;
        private string selectedTenMH;
        private string selectedGiaCa;
        private string selectedDVT;
        private string selectedMaLoai;
        public ThemChiTietHoaDon(ThemHoaDonBanHang parentForm)
        {
            InitializeComponent();
            this.Load += ThemChiTietHoaDon_Load; // Đăng ký sự kiện Load
            dgvMatHang.CellContentClick += DgvMatHang_CellContentClick;
            txtSoLuong.KeyPress += txtSoLuong_TextChanged;

            this.parentForm = parentForm;
        }

        private void DgvMatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ThemChiTietHoaDon_Load(object sender, EventArgs e)
        {
            // Gọi phương thức để tải dữ liệu và hiển thị trên DataGridView
            LoadDataToDataGridView();
        }
        private void LoadDataToDataGridView()
        {
            // Xây dựng câu truy vấn dựa trên điều kiện tìm kiếm
            string query = "SELECT * FROM MENU WHERE 1=1";

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

                        // Kiểm tra nếu DataTable có dữ liệu
                        if (dataTable.Rows.Count > 0)
                        {
                            // Hiển thị dữ liệu trên DataGridView
                            dgvMatHang.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu để hiển thị.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void dgvMatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào hàng (chứ không phải tiêu đề cột)
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dgvMatHang.Rows[e.RowIndex];

                selectedMaMH = selectedRow.Cells["MaMH"].Value.ToString();
                selectedTenMH = selectedRow.Cells["TenMH"].Value.ToString();
                selectedGiaCa = selectedRow.Cells["GiaCa"].Value.ToString();
                selectedDVT = selectedRow.Cells["DVT"].Value.ToString();
                selectedMaLoai = selectedRow.Cells["MaLoai"].Value.ToString();

                // Hiển thị thông tin hoặc thực hiện các xử lý cần thiết
                selectedItem.Text = $"Chọn {selectedTenMH}";
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            // Lấy văn bản hiện tại từ TextBox
            string currentText = txtSoLuong.Text;

            // Sử dụng StringBuilder để xây dựng chuỗi mới chỉ chứa các ký tự số
            StringBuilder sb = new StringBuilder();

            foreach (char c in currentText)
            {
                if (char.IsDigit(c))
                {
                    sb.Append(c);
                }
            }

            // Cập nhật lại TextBox với chuỗi mới chỉ chứa các ký tự số
            if (sb.ToString() != currentText)
            {
                int selectionStart = txtSoLuong.SelectionStart - 1;
                txtSoLuong.Text = sb.ToString();
                txtSoLuong.SelectionStart = Math.Max(0, selectionStart);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedTenMH) || string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng và nhập số lượng.");
                return;
            }

            int soLuong = int.Parse(txtSoLuong.Text);

            parentForm.AddChiTietHoaDon(selectedMaMH, selectedTenMH, selectedGiaCa, selectedDVT,selectedMaLoai, soLuong);

            // Đóng form hiện tại
            this.Close();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
