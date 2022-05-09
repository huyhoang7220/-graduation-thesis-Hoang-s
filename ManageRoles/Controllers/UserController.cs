using ManageRoles.Algorithm;
using ManageRoles.Filters;
using ManageRoles.Models;
using ManageRoles.Repository;
using ManageRoles.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageRoles.Controllers
{
    [AuthorizeSuperAdminandAdmin]
    public class UserController : Controller
    {
        private readonly ILoaiTaiKhoan _loaiTaiKhoanService;
        private readonly ITaiKhoan _taiKhoanService;

        public UserController(ILoaiTaiKhoan loaiTaiKhoanService, ITaiKhoan taiKhoanService)
        {
            _loaiTaiKhoanService = loaiTaiKhoanService;
            _taiKhoanService = taiKhoanService;
        }
        public ActionResult Index()
        {
            var lists = _taiKhoanService.GetAll();

            ViewBag.Avatar = GetAnh();
            ViewBag.Data = lists;
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
            var model = _taiKhoanService.GetById(id);
            ViewBag.Avatar = GetAnh();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TaiKhoanModel model, HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/images/index/content"), _FileName);
                        file.SaveAs(_path);
                        model.Anh = file.FileName;
                    }
                }

                var taiKhoan = _taiKhoanService.GetById(model.Id);
                model.IdLoaiTK = taiKhoan.IdLoaiTK;
                model.MatKhau = taiKhoan.MatKhau;

                var id_ = _taiKhoanService.Update(model.Id, model);
                return RedirectToAction("Edit", id_);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            ViewBag.Avatar = GetAnh();
            ViewBag.LoaiTK = _loaiTaiKhoanService.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaiKhoanModel model, HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/images/index/content"), _FileName);
                        file.SaveAs(_path);
                        model.Anh = file.FileName;
                    }
                }

                ViewBag.LoaiTK = _loaiTaiKhoanService.GetAll();
                if (_taiKhoanService.CheckEmailExists(model.Email))
                {
                    TempData["Message"] = "Email đã tồn tại";
                    return View();
                }

                AesAlgorithm aesAlgorithm = new AesAlgorithm();

                model.MatKhau = aesAlgorithm.EncryptString(model.MatKhau);
                var id_ = _taiKhoanService.Add(model);

                TempData["Message"] = "Tạo thành công!";
                return View();
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Tạo không thành công, "+ ex.ToString();
                return View();
            }
        }

        public ActionResult Remove(int id)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    var model = db.TaiKhoanService.Find(id);
                    if (model != null)
                    {
                        db.TaiKhoanService.Remove(model);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index", "User");
            }
            catch (Exception ex)
            {
                return View();
            }
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