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
    public class SlideController : Controller
    {
        private readonly ILoaiTaiKhoan _loaiTaiKhoanService;
        private readonly ITaiKhoan _taiKhoanService;
        private readonly ISanPham _sanPhamService;
        private readonly INhaSanXuat _nhaSXService;
        private readonly ISlide _slideService;

        public SlideController(ILoaiTaiKhoan loaiTaiKhoanService, ITaiKhoan taiKhoanService,
            ISanPham sanPhamService, INhaSanXuat nhaSXService, ISlide slideService)
        {
            _loaiTaiKhoanService = loaiTaiKhoanService;
            _taiKhoanService = taiKhoanService;
            _sanPhamService = sanPhamService;
            _nhaSXService = nhaSXService;
            _slideService = slideService;
        }
        public ActionResult Index()
        {
            ViewBag.Data = _slideService.GetAll();
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
            ViewBag.SP = _sanPhamService.GetAll();
            ViewBag.Avatar = GetAnh();

            var model = _slideService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SlideModel model, HttpPostedFileBase[] files)
        {
            var id = 0;
            try
            {
                ViewBag.SP = _sanPhamService.GetAll();

                foreach (HttpPostedFileBase file in files)
                {
                    if (files != null)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/images/product_detail/content"), _FileName);
                        file.SaveAs(_path);
                        model.Anh = file.FileName;
                    }
                    var idSP = _slideService.Update(model.Id, model);
                    id = idSP;
                }
               

                TempData["Message"] = "Đã sửa thành công !";
                return RedirectToAction("Edit", id);
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
            ViewBag.SP = _sanPhamService.GetAll();
            ViewBag.Avatar = GetAnh();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SlideModel model, HttpPostedFileBase[] files)
        {
            try
            {
                ViewBag.SP = _sanPhamService.GetAll();

                foreach (HttpPostedFileBase file in files)
                {
                    if (files != null)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/images/product_detail/content"), _FileName);
                        file.SaveAs(_path);
                        model.Anh = file.FileName;
                    }
                    _slideService.Add(model);
                }

               
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
                //var model = _danhMucService.GetById(id);
                _slideService.Delete(id);

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