using ManageRoles.Algorithm;
using ManageRoles.Filters;
using ManageRoles.Repository;
using ManageRoles.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageRoles.Controllers
{
    [AuthorizeSuperAdminandAdmin]
    public class ProductController : Controller
    {
        private readonly ILoaiTaiKhoan _loaiTaiKhoanService;
        private readonly ITaiKhoan _taiKhoanService;
        private readonly ISanPham _sanPhamService;
        private readonly INhaSanXuat _nhaSXService;
        private readonly IDanhMuc _danhMucService;

        public ProductController(ILoaiTaiKhoan loaiTaiKhoanService, ITaiKhoan taiKhoanService,
            ISanPham sanPhamService, INhaSanXuat nhaSXService, IDanhMuc danhMucService)
        {
            _loaiTaiKhoanService = loaiTaiKhoanService;
            _taiKhoanService = taiKhoanService;
            _sanPhamService = sanPhamService;
            _nhaSXService = nhaSXService;
            _danhMucService = danhMucService;
        }
        public ActionResult Index()
        {
            ViewBag.Data = _sanPhamService.GetAll().Where(x => x.Actived);
            ViewBag.Avatar = GetAnh();
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
            ViewBag.NhaSX = _nhaSXService.GetAll();
            ViewBag.DanhMuc = _danhMucService.GetAll();
            ViewBag.Avatar = GetAnh();

            var model = _sanPhamService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPhamModel model, HttpPostedFileBase file)
        {
            ViewBag.NhaSX = _nhaSXService.GetAll();
            ViewBag.DanhMuc = _danhMucService.GetAll();
            var id = 0;
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/images/index/content"), _FileName);
                        file.SaveAs(_path);
                        model.AnhDaiDien = file.FileName;
                    }
                }

                var sp = _sanPhamService.GetById(model.Id);

                model.NgayNhap = sp.NgayNhap;
                model.Actived = sp.Actived;
                model.DanhMuc = _danhMucService.GetById(model.IdDanhMuc) == null ? "" : _danhMucService.GetById(model.IdDanhMuc).Ten;
                var idSP = _sanPhamService.Update(model.Id, model);
                id = idSP;

                TempData["Message"] = "Đã sửa thành công !";
                return RedirectToAction("Edit", idSP);
            }
            catch (DbEntityValidationException dbEx)
            {
                TempData["Message"] = "Sửa lỗi !";
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(msg, dbEx);
            }

            return RedirectToAction("Edit", id);
        }

        public ActionResult Create()
        {
            ViewBag.NhaSX = _nhaSXService.GetAll();
            ViewBag.DanhMuc = _danhMucService.GetAll();
            ViewBag.Avatar = GetAnh();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPhamModel model, HttpPostedFileBase file)
        {
            try
            {
                ViewBag.NhaSX = _nhaSXService.GetAll();
                ViewBag.DanhMuc = _danhMucService.GetAll();

                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/images/index/content"), _FileName);
                        file.SaveAs(_path);
                        model.AnhDaiDien = file.FileName;
                    }
                }

                model.Actived = true;
                model.NgayNhap = DateTime.Now;
                model.DanhMuc = _danhMucService.GetById(model.IdDanhMuc) == null ? "" : _danhMucService.GetById(model.IdDanhMuc).Ten;

                _sanPhamService.Add(model);
                TempData["Message"] = "Đã tạo thành công !";
                return View();
            }
            catch
            {
                TempData["Message"] = "Tạo lỗi";
                return View();
            }
        }

        public ActionResult Remove(int id)
        {
            try
            {
                var model = _sanPhamService.GetById(id);

                model.Actived = false;
                var idSP = _sanPhamService.Update(id, model);
                id = idSP;

                TempData["Message"] = "Xóa thành công !";
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException dbEx)
            {
                TempData["Message"] = "Sửa lỗi !";
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(msg, dbEx);
            }

            return RedirectToAction("Index");
        }
        public ActionResult ShowMenus()
        {
            try
            {
                return PartialView("ShowMenu");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}