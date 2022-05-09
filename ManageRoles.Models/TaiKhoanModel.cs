using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageRoles.ViewModels
{
    [Table("TaiKhoan")]
    public class TaiKhoanModel
    {
        [Key]
        public int Id { get; set; }
        public string TenDangNhap { get; set; }
        public string Ten { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public int IdLoaiTK { get; set; }
        public string Anh { get; set; }

    }
}
