using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManageRoles.Models;
using ManageRoles.ViewModels;

namespace ManageRoles.MapperConfig
{
    public class AutoMapperConfiguration
    {
        public static void Config()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<LuuTruView, LuuTruMaster>();
                cfg.CreateMap<ChiTietDonHang, ChiTietDonHangModel>();
                cfg.CreateMap<DonHang, DonHangModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.DiaChiGiao, opt => opt.MapFrom(src => src.DiaChiGiao))
                    .ForMember(dest => dest.NgayTao, opt => opt.Ignore())
                    .ForMember(dest => dest.ThanhTien, opt => opt.Ignore())
                    .ForMember(dest => dest.IdTaiKhoan, opt => opt.Ignore())
                    .ForMember(dest => dest.IdTinhTrangDonHang, opt => opt.Ignore())
                    .ForMember(dest => dest.IdTinhTrangDonHang, opt => opt.Ignore())
                    .ForMember(dest => dest.IdSanPham, opt => opt.Ignore());

                cfg.CreateMap<DonHangModel, DonHang>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.NgayTao, opt => opt.Ignore())
                   .ForMember(dest => dest.ThanhTien, opt => opt.Ignore())
                   .ForMember(dest => dest.NguoiDat, opt => opt.Ignore())
                   .ForMember(dest => dest.TenSanPham, opt => opt.Ignore())
                   .ForMember(dest => dest.ThanhTien, opt => opt.Ignore())
                   .ForMember(dest => dest.GiaBan, opt => opt.Ignore())
                   .ForMember(dest => dest.AnhDaiDien, opt => opt.Ignore())
                   .ForMember(dest => dest.TinhTrangDonHang, opt => opt.Ignore())
                   .ForMember(dest => dest.IdSP, opt => opt.Ignore())
                   .ForMember(dest => dest.DiaChiGiao, opt => opt.MapFrom(src => src.DiaChiGiao))
                   .ForMember(dest => dest.IdTinhTrangDonHang, opt => opt.MapFrom(src => src.IdTinhTrangDonHang));

                cfg.CreateMap<LoaiTaiKhoan, LoaiTaiKhoanModel>();
                cfg.CreateMap<NhaSanXuat, NhaSanXuatModel>();
                cfg.CreateMap<SanPham, SanPhamModel>();
                cfg.CreateMap<TaiKhoan, TaiKhoanModel>();
                cfg.CreateMap<TinhTrangDonHang, TinhTrangDonHangModel>();
                cfg.CreateMap<DanhMuc, DanhMucModel>();
                cfg.CreateMap<Slide, SlideModel>();
            });
        }
    }
}