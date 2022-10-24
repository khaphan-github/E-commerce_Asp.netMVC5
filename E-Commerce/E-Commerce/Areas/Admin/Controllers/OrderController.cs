using E_Commerce_Business_Logic.RequestFilter;
using E_Commerce_Repository.InitializationDB;
using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace E_Commerce.Areas.Admin.Controllers
{
    [AuthorizationFilter(allowedRoles: new string[2] { Role.SystemAdmin, Role.Admin })]
    public class OrderController : Controller
    {
        private EcommerIntializationDB db = new EcommerIntializationDB();
        // GET: Admin/Order
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int maxPage = db.Orders.Count() / pageSize;
            if (page == null || page <= 0 || page > maxPage)
            {
                page = 1;
            }
           
            int pageNumber = (page ?? 1);
            ViewBag.MaxPage = maxPage;
            ViewBag.CurrentPage = page;
            return View(db.Orders.ToList().OrderByDescending(prop => prop.Date).ToPagedList(pageNumber, pageSize));

        }
        public ActionResult Details(int? id)
        {
            ViewBag.DeliverStateID = new SelectList(db.DeliverStates.ToList().OrderBy(x => x.Name), "Id", "Name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Danhsachsp = db.OrderDetails.Where(prop => prop.OrderID == id).ToList();
            return View(order);
        }

        public ActionResult Update(Order order)
        {
            ViewBag.DeliverStateID = new SelectList(db.DeliverStates.ToList().OrderBy(x => x.Name), "Id", "Name");
            var ord = db.Orders.FirstOrDefault(x => x.Id == order.Id);
            ord.DeliverStateID = order.DeliverStateID;
            db.SaveChanges();
            return RedirectToAction("Index", "Order", new { id = order.Id });
        }

 

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}