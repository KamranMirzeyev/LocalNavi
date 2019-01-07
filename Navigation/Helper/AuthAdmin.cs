using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Navigation.Helper
{
    public class AuthAdmin:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["admin"]==null)
            {
                filterContext.Result = new RedirectResult("~/Area/Login/index");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}