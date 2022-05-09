using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageRoles.ViewModels
{
    public class DonHang
    { 
        public int Id { get; set; }
        public string TenSanPham { get; set; }
        public string NguoiDat { get; set; }
        public string GiaBan { get; set; }
        public string AnhDaiDien { get; set; }
        public string SoLuong { get; set; }
        public string NgayTao { get; set; }
        public double ThanhTien { get; set; }
        public string TinhTrangDonHang { get; set; }
        public int IdSP { get; set; }
        public int IdTinhTrangDonHang { get; set; }
        public string DiaChiGiao { get; set; }
    }
}
