using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageRoles.ViewModels
{
    [Table("DonHang")]
    public class DonHangModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime NgayTao { get; set; }
        public double ThanhTien { get; set; }
        public int IdTaiKhoan { get; set; }
        public int IdTinhTrangDonHang { get; set; }
        public int IdSanPham { get; set; }
        public string DiaChiGiao { get; set; }
    }
}
