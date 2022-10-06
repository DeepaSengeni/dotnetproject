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
    public sealed class CheckLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpContext = new HttpContextWrapper(HttpContext.Current);
            string originalPath = HttpContext.Current.Request.Url.PathAndQuery;
            // string originalPath = HttpContext.Current.Request.Path;


            if (System.Web.HttpContext.Current.Session["UserId"] == null && HttpContext.Current.Request.Cookies["StudentApp"] != null)
            {
                System.Web.HttpContext.Current.Session["Username"] = HttpContext.Current.Request.Cookies["StudentApp"].Values["Username"];
                System.Web.HttpContext.Current.Session["Role"] = HttpContext.Current.Request.Cookies["StudentApp"].Values["Role"];
                System.Web.HttpContext.Current.Session["StudentName"] = HttpContext.Current.Request.Cookies["StudentApp"].Values["StudentName"]; 
                System.Web.HttpContext.Current.Session["ProfileImage"] = HttpContext.Current.Request.Cookies["StudentApp"].Values["ProfileImage"]; 
                System.Web.HttpContext.Current.Session["UserId"] = HttpContext.Current.Request.Cookies["StudentApp"].Values["UserId"];
             
                try
                {
                    STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
                    STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
                    STU.BaseLayer.ActionResult actionResult = new STU.BaseLayer.ActionResult();
                    UserInfoBase.Id = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserId"]);
                    UserInfoBase.IsActive = false;
                    actionResult = UserAction.UsersLoginInfo_Insert_Update(UserInfoBase);
                }
                catch (Exception ex)
                {
                }

            }

            string url = "~/Account/SubmitterRegistration?returnUrl=" + HttpUtility.UrlEncode(originalPath);
            if (System.Web.HttpContext.Current.Session["UserId"] == null)
            {

                filterContext.Result = new RedirectResult(url);
                return;


            }

            


        }

    }


}

