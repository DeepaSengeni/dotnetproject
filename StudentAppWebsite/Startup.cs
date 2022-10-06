using Hangfire;
using Hangfire.Dashboard;
using Hangfire.MemoryStorage;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentAppWebsite
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        private readonly string[] _roles;

        public HangfireAuthorizationFilter(params string[] roles)
        {
            _roles = roles;
        }

        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //providing database name to save jobs etc
            Hangfire.GlobalConfiguration.Configuration
                .UseMemoryStorage();

            //basic process to check
            Hangfire.BackgroundJob.Enqueue(() => Console.WriteLine("Getting Started with HangFire!"));

            //will create hangfire dashboard
            // app.UseHangfireDashboard();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions{
                DashboardTitle = "Sample Jobs",
                Authorization = new[]
                {
                    new  HangfireAuthorizationFilter("admin")
                }
            });
            app.UseHangfireServer();

        }
    }
}