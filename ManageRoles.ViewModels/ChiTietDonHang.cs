using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageRoles.ViewModels
{
    public class ChiTietDonHang
    {
        public int Id { get; set; }
        public double GiaBan { get; set; }
        public double SoLuong { get; set; }
        public int IdDonHang { get; set; }
        public int IdSanPham { get; set; }
    }
}
