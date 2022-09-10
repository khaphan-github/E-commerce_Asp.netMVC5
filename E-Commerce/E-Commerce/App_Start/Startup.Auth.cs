using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Google;

[assembly: OwinStartup(typeof(E_Commerce.App_Start.Startup))]

namespace E_Commerce.App_Start
{
    public partial class Startup
    {
        const string GoogleClientID = "995664507246-p0s07gg73hlviop06cpkjvigc06fkjhq.apps.googleusercontent.com";
        const string GoogleClientSecret = "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";

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            }) ;


            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = GoogleClientID,
                ClientSecret = GoogleClientSecret
            });
        }
    }
}
