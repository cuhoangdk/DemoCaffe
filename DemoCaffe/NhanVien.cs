using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCaffe
{
    internal class NhanVien
    {
        public string MaNV {  get; set; }
        string HoNV { get; set; }
        public string TenNV { get; set; }
        string Email { get; set; }
        string DiaChi { get; set; }
        string MatKhau { get; set; }
        string ChucVu { get; set; }
        string GioiTinh { get; set; }
        string SDT {  get; set; }
        string CCCD { get; set; }
        public NhanVien(string maNV, string hoNV, string tenNV, string email, string diaChi, string matKhau, string chucVu, string gioiTinh, string sDT, string cCCD)
        {
            MaNV = maNV;
            HoNV = hoNV;
            TenNV = tenNV;
            Email = email;
            DiaChi = diaChi;
            MatKhau = matKhau;
            ChucVu = chucVu;
            GioiTinh = gioiTinh;
            SDT = sDT;
            CCCD = cCCD;
        }
        public override string ToString()
        {
            return MaNV +": "+ TenNV; // Hiển thị mã NV và tên NV trong ComboBox
        }
    }
}
