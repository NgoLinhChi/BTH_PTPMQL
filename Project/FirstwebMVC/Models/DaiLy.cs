using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstwebMVC.Models
{
    public class DaiLy 
    {
        public string MaDaiLy { get; set; }
        public string TenDaiLy { get; set; }
        public string Diachi { get; set; }
        public string NguoiDaiDien { get; set; }
        public string DienThoai { get; set; }
        public string MaHTTP { get; set; }
        public HeThongPhanPhoi? HeThongPhanPhoi { get; set; }
    }
}