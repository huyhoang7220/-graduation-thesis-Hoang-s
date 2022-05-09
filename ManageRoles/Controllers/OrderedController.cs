using ManageRoles.Algorithm;
using ManageRoles.Filters;
using ManageRoles.Models;
using ManageRoles.Repository;
using ManageRoles.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageRoles.Controllers
{
    [AuthorizeSuperAdminandAdmin]
    public class OrderedController : Controller
    {
        private readonly ILoaiTaiKhoan _loaiTaiKhoanService;
        private readonly ITaiKhoan _taiKhoanService;
        private readonly IDonHang _donHangService;
        private readonly ITinhTrangDonHang _tinhTrangDHService;
        private readonly IChiTietDonHang _chiTietDHService;
        private readonly ISanPham _sanphamService;

        public OrderedController(ILoaiTaiKhoan loaiTaiKhoanService, ITaiKhoan taiKhoanService,
            IDonHang donHangService, ITinhTrangDonHang tinhTrangDHService, IChiTietDonHang chiTietDHService,
            ISanPham sanphamService)
        {
            _loaiTaiKhoanService = loaiTaiKhoanService;
            _taiKhoanService = taiKhoanService;
            _donHangService = donHangService;
            _tinhTrangDHService = tinhTrangDHService;
            _chiTietDHService = chiTietDHService;
            _sanphamService = sanphamService;
        }
        public ActionResult Index()
        {
            var result = new List<DonHang>();
            var lists = _donHangService.GetAll().Where(x => x.IdTinhTrangDonHang != 5);
            if(lists.Count() > 0)
            {
                result.AddRange(lists.Select(d => new DonHang()
                {
                    Id = d.Id,
                    TenSanPham = GetSanPham(d.IdSanPham).Ten,
                    NguoiDat = GetTaiKhoan(d.IdTaiKhoan).HoTen + GetTaiKhoan(d.IdTaiKhoan).Ten,
                    GiaBan = GetChiTietDH(d.Id).GiaBan.ToString(),
                    SoLuong = GetChiTietDH(d.Id).SoLuong.ToString(),
                    ThanhTien = d.ThanhTien,
                    NgayTao = d.NgayTao.ToString("dd/mm/yyyy"),
                    TinhTrangDonHang = GetTinhTrang(d.IdTinhTrangDonHang),
                    IdTinhTrangDonHang = d.IdTinhTrangDonHang,
                    DiaChiGiao = d.DiaChiGiao
                }));
            }

            ViewBag.Avatar = GetAnh();

            ViewBag.Data = result;
            return View();
        }

        private string GetAnh()
        {
            string UserId = string.Empty;
            HttpCookie reqCookies = Request.Cookies["userInfo"];

            if (Request.Cookies["listCart"] != null && reqCookies != null)
            {
                UserId = reqCookies["UserID"].ToString();
                int UserCurentId = Convert.ToInt32(UserId);
                return _taiKhoanService.GetById(UserCurentId).Anh;

            }
            return "";
        }
        public ActionResult Edit(int id)
        {
            var model = _donHangService.GetById(id);

            var model_ = AutoMapper.Mapper.Map<DonHang>(model);
            model_.TenSanPham = GetSanPham(model.IdSanPham).Ten;

            ViewBag.ListTinhTrang = _tinhTrangDHService.GetAll();
            ViewBag.Avatar = GetAnh();
            return View(model_);
        }

        [HttpPost]
        public JsonResult Edit(int status, int id)
        {
            try
            {
                var model = _donHangService.GetById(id);
                model.IdTinhTrangDonHang = status;

                var id_ = _donHangService.Update(model);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Remove(int id)
        {
            try
            {
                ViewBag.Avatar = GetAnh();
                using (var db = new DatabaseContext())
                {
                    var model = db.DonHangService.Find(id);
                    if (model != null)
                    {
                        db.DonHangService.Remove(model);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index", "Ordered");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        private string GetTinhTrang(int id)
        {
            var tinhTrang = _tinhTrangDHService.GetById(id);

            if(tinhTrang != null)
            {
                return tinhTrang.TenTinhTrang;
            }
            return "";
        }

        private SanPhamModel GetSanPham(int id)
        {
            var sanPham = new SanPhamModel()
            {
                Ten = "",
            };

            sanPham = _sanphamService.GetById(id);

            if (sanPham != null)
            {
                return sanPham;
            }
            return sanPham;
        }

        private ChiTietDonHangModel GetChiTietDH(int id)
        {
            var chitiet = new ChiTietDonHangModel()
            {
                GiaBan = -1,
                SoLuong = -1,
            };

            chitiet = _chiTietDHService.GetByIdDH(id);

            if (chitiet != null)
            {
                return chitiet;
            }
            return chitiet;
        }

        private TaiKhoanModel GetTaiKhoan(int id)
        {
            var taiKhoan = _taiKhoanService.GetById(id);
            return taiKhoan;
        }

    }
}