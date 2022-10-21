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
        private readonly string[] allowedRoles;
        public AuthorizationFilter(params string[] allowedRoles) {
            this.allowedRoles = allowedRoles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            // Phân quyền
            bool authorize = false;
            var user = httpContext.Session[SessionConstaint.USERSESION] as Account;

            if (user != null) {
                var userRole = user.AccountRoles;

                int maxLevelRole = userRole.Max(lv => lv.level);

                string roleName = userRole.FirstOrDefault(prop => prop.level == maxLevelRole).Name;

                foreach (var role in allowedRoles) {
                    if (role == roleName) return true;
                }
            }
            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {

            RouteValueDictionary rauteValue = new RouteValueDictionary {
                { "controller", "Login" },
                { "action", "Index" }
            };

            filterContext.Result = new RedirectToRouteResult(rauteValue);
        }
    }
}
