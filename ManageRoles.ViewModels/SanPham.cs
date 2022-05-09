using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageRoles.ViewModels
{
    public class SanPham
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string AnhDaiDien { get; set; }
        public double Gia { get; set; }
        public DateTime NgayNhap { get; set; }
        public int IdNhaSanXuat { get; set; }
        public int IdDanhMuc { get; set; }
        public string DanhMuc { get; set; }
    }
}
