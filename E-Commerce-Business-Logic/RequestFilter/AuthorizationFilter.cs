using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using E_Commerce_Business_Logic.Session;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;

namespace E_Commerce_Business_Logic.RequestFilter {
    public class AuthorizationFilter : AuthorizeAttribute {
        private readonly string[] allowedroles;
        public AuthorizationFilter(params string[] roles) {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            // Phân quyền
            bool authorize = false;
            var user = httpContext.Session[SessionConstaint.USERSESION] as AccountConsumer;

            if (user != null) {
                var userRole = user.AccountRoles;
                int maxLevelRole = userRole.Max(lv => lv.level);
                string roleName = userRole.FirstOrDefault(prop => prop.level == maxLevelRole).Name;
                System.Diagnostics.Debug.WriteLine(roleName);
                foreach (var role in allowedroles) {
                    if (role == roleName) return true;
                }
            }
            return authorize;
        }

    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
        filterContext.Result = new RedirectToRouteResult(
           new RouteValueDictionary
           {
                    { "controller", "Home" },
                    { "action", "UnAuthorized" }
           });
    }
}
}
