using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using StudentAppWebsite.Models;
using System.Web;

namespace StudentAppWebsite.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class CheckRoleAttribute : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (System.Web.HttpContext.Current.Session["UserId"] != null && Convert.ToInt32(System.Web.HttpContext.Current.Session["Role"]) !=1)
            {

                string url = "~/Home/Home";
                filterContext.Result = new RedirectResult(url);
                return;
            }
        }


    }
}
