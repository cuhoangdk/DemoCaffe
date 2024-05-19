using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCaffe
{
    internal class Ban
    {
        public string MaBan {  get; set; }
        public string TinhTrang { get; set; }
        public Ban(string maBan, string tinhTrang)
        {
            MaBan = maBan;
            TinhTrang = tinhTrang;
        }
        public override string ToString()
        {
            return MaBan; // Hiển thị tên bàn trong ComboBox
        }
        
    }
}
