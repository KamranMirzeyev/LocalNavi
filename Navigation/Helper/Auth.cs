using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Navigation.Helper
{
    public class Auth:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Login"] == null)
            {
                HttpContext.Current.Session["Error"] = "Login olmamisiniz!";
                filterContext.Result = new RedirectResult("~/home/index");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}