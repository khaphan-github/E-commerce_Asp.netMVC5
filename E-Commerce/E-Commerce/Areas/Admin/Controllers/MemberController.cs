using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Areas.Admin.Controllers
{
    public class MemberController : BaseController {
        // GET: Admin/Member/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}