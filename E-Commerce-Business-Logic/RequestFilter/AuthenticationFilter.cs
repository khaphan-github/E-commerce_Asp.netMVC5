using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using E_Commerce_Business_Logic.Session;

namespace E_Commerce_Business_Logic.RequestFilter {
    public class AuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter {
        public void OnAuthentication(AuthenticationContext filterContext) {

            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session[SessionConstaint.USERSESION]))) {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext) {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult) {
                //Redirecting the user to the Login View of Account Controller  
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                     { "controller", "Home" },
                     { "action", "NoAuthLogin" }
                });
            }
        }
    }
}
