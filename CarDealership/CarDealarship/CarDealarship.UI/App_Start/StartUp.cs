using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Runtime.Remoting.Contexts;
using Microsoft.AspNet.Identity.Owin;
using CarDealarship.Data;
using CarDealarship.Model.Tables;

namespace CarDealarship.UI.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            //var options = new CookieAuthenticationOptions();
            //options.AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active;
            //options.AuthenticationType = "ApplicationCookie";
            //options.LoginPath = new PathString("/auth/login");

            //app.UseCookieAuthentication(options);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/login"),
            });
            app.CreatePerOwinContext(() => new CarDealarshipEntities());
            app.CreatePerOwinContext<UserManager<Users>>((options, context) => new UserManager<Users>(new UserStore<Users>(context.Get<CarDealarshipEntities>())));
            app.CreatePerOwinContext<RoleManager<IdentityRole>>((options, context) => new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context.Get<CarDealarshipEntities>())));
        }
    }
}