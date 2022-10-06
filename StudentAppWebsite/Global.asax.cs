using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StudentAppWebsite
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            //log4net.Config.XmlConfigurator.Configure();
        }
        //protected void Session_Start()
        //{
        //    if (Session["UserId"] != null)
        //    {
        //        STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
        //        STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
        //        STU.BaseLayer.ActionResult ActionResult = new STU.BaseLayer.ActionResult();
        //        UserInfoBase.Id = Convert.ToInt32(Session["UserId"]);
        //        UserInfoBase.IsActive = false;
        //        ActionResult = UserAction.UsersLoginInfo_Insert_Update(UserInfoBase);
        //    }
        //}
    }
}