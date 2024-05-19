using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCaffe
{
    internal class ChiTietHoaDon
    {
        public string MaHD {  get; set; }
        public string MaMH { get; set; }
        public string SoLuong { get; set; }
        public int GiaCa { get; set; }
        public ChiTietHoaDon(string maHD, string maMH, string soLuong, int giaCa)
        {
            MaHD = maHD;
            MaMH = maMH;
            SoLuong = soLuong;
            GiaCa = giaCa;
        }
    }
}
