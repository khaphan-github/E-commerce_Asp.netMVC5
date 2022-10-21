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

            string getCurrentSession = Convert.ToString(filterContext.HttpContext.Session[SessionConstaint.USERSESION]);

            bool isNoAuthenticated = string.IsNullOrEmpty(getCurrentSession);

            if (isNoAuthenticated) {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext) {
            RouteValueDictionary routerValue = new RouteValueDictionary { 
                    { "controller", "Home" },
                    { "action", "Index" }
            };
            bool isUnauth = filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult;

            if (isUnauth) {

                filterContext.Result = new RedirectToRouteResult(routerValue);
            }
        }
    }
}
