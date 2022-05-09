using ManageRoles.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageRoles.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseConnection")
        {
        }
        public DbSet<LuuTruMaster> LuuTruMaster { get; set; }
        public DbSet<ChiTietDonHangModel> ChiTietDonHangService { get; set; }
        public DbSet<DonHangModel> DonHangService { get; set; }
        public DbSet<LoaiTaiKhoanModel> LoaiTaiKhoanService { get; set; }
        public DbSet<NhaSanXuatModel> NhaSanXuatService { get; set; }
        public DbSet<SanPhamModel> SanPhamService { get; set; }
        public DbSet<TaiKhoanModel> TaiKhoanService { get; set; }
        public DbSet<TinhTrangDonHangModel> TinhTrangDonHangService { get; set; }
        public DbSet<DanhMucModel> DanhMucService { get; set; }
        public DbSet<SlideModel> SlideService { get; set; }
    }
}
