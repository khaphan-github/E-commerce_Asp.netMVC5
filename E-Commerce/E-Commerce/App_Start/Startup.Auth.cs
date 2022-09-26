using Microsoft.Owin;
using Owin;
using System;
using E_Commerce_Repository.InitializationDB;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace E_Commerce.App_Start {
    public partial class Startup {
        public void ConfigureAuth(IAppBuilder app) {
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Consumer/Login/"),
                Provider = new CookieAuthenticationProvider {
                    OnApplyRedirect = context => {
                        context.Response.Redirect(context.RedirectUri);
                    }
                }
            });
            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie); 
        }
    }
}