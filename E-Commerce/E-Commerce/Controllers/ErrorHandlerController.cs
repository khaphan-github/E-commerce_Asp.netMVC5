using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class ErrorHandlerController : Controller
    {
        // GET: ErrorHandler
        public ActionResult Index()
        {
            return View();
        }
        [HandleError]
        public ActionResult NotFound() {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View();
        }
    }
}