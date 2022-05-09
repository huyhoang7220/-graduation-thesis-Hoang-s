using ManageRoles.Algorithm;
using ManageRoles.Filters;
using ManageRoles.Repository;
using ManageRoles.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageRoles.Controllers
{
    [AuthorizeSuperAdminandAdmin]
    public class HomeAdminController : Controller
    {
        private readonly ILoaiTaiKhoan _loaiTaiKhoanService;
        private readonly ITaiKhoan _taiKhoanService;

        public HomeAdminController(ILoaiTaiKhoan loaiTaiKhoanService, ITaiKhoan taiKhoanService)
        {
            _loaiTaiKhoanService = loaiTaiKhoanService;
            _taiKhoanService = taiKhoanService;
        }
        public ActionResult Index()
        {
            string UserId = string.Empty;
            HttpCookie reqCookies = Request.Cookies["userInfo"];

            if (Request.Cookies["listCart"] != null && reqCookies != null)
            {
                UserId = reqCookies["UserID"].ToString();
                int UserCurentId = Convert.ToInt32(UserId);
                ViewBag.Avatar = _taiKhoanService.GetById(UserCurentId).Anh;

            }
            return View();
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