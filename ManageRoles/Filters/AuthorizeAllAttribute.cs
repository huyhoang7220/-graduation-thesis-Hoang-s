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
    public class AuthorizeAllAttribute : ActionFilterAttribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                DatabaseContext context = new DatabaseContext();

                //var role = Convert.ToString(filterContext.HttpContext.Session["Role"]);

                string role = string.Empty;
                HttpCookie reqCookies = HttpContext.Current.Request.Cookies["userInfo"];
                if (reqCookies != null)
                {
                    role = reqCookies["Role"].ToString();
                }

                role = "1";
                if (!string.IsNullOrEmpty(role))
                {
                    var roleValue = Convert.ToInt32(role);

                    //var roleMasterDetails = (from rolemaster in context.RoleMasters
                    //                         where rolemaster.RoleId == roleValue
                    //                         select rolemaster).FirstOrDefault();

                   
                }
                else
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}