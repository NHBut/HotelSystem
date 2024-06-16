using QuanLyKhachSan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKhachSan.Controllers.Auth
{

    public class AdminSessionAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = (User)filterContext.HttpContext.Session["ADMIN"];
            if (user == null)
            {
                filterContext.Result = new RedirectResult("~/PublicAuthentication/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}