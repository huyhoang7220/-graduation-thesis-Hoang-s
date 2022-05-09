using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageRoles.ViewModels
{
    [Table("ChiTietDonHang")]
    public class ChiTietDonHangModel
    {
        [Key]
        public int Id { get; set; }
        public double GiaBan { get; set; }
        public double SoLuong { get; set; }
        public int IdDonHang { get; set; }
        public int IdSanPham { get; set; }
    }
}
