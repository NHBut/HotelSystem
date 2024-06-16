using QuanLyKhachSan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKhachSan.Controllers.Auth
{
    public class RoleAuthorizeAttribute : ActionFilterAttribute
    {
        private readonly int[] allowedRoles;

        public RoleAuthorizeAttribute(params int[] roles)
        {
            this.allowedRoles = roles;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = (User)filterContext.HttpContext.Session["ADMIN"];
            if (user == null)
            {
                filterContext.Result = new RedirectResult("~/PublicAuthentication/Login");
                return;
            }

            if (!allowedRoles.Contains(user.idRole))
            {
                filterContext.Result = new RedirectResult("~/Home/Unauthorized");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}