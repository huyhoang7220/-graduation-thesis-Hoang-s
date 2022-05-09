using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ManageRoles.Models;
using ManageRoles.Repository;

namespace ManageRoles.Filters
{
    public class AuthorizeSuperAdminandAdminAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                DatabaseContext context = new DatabaseContext();

                string role = string.Empty;
                HttpCookie reqCookies = HttpContext.Current.Request.Cookies["userInfo"];
                if (reqCookies != null)
                {
                    role = reqCookies["Role"].ToString();
                }

                //var role = Convert.ToString(filterContext.HttpContext.Session["Role"]);

                if (!string.IsNullOrEmpty(role))
                {
                    var roleValue = role;

                    var userDetail = (from u in context.LoaiTaiKhoanService
                                             where u.Ma == roleValue
                                             select u).FirstOrDefault();

                    if (userDetail != null && (userDetail.Ma.ToLower() == "khachhang" || userDetail.Ma.ToLower() == "nguoigiahang"))
                    {
                        //filterContext.HttpContext.Session.Abandon();
                        HttpContext.Current.Request.Cookies.Remove("userInfo");

                        filterContext.Result = new RedirectToRouteResult
                        (
                            new RouteValueDictionary
                                (new
                                { controller = "Error", action = "Error" }
                            ));
                    }
                }
                else
                {
                    //filterContext.HttpContext.Session.Abandon();
                    //HttpContext.Current.Request.Cookies.Remove("userInfo");

                    filterContext.Result = new RedirectToRouteResult
                    (
                        new RouteValueDictionary
                        (new
                        { controller = "Error", action = "Error" }
                        ));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}