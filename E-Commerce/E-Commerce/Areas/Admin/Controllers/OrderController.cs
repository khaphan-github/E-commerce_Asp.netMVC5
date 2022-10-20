using E_Commerce_Repository.InitializationDB;
using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
/*using PagedList;
using PagedList.Mcv;*/

namespace E_Commerce.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private EcommerIntializationDB db = new EcommerIntializationDB();
        // GET: Admin/Order
        public ActionResult Index(int? page)
        {
            /*var items = db.Orders.OrderByDescending(x => x.Date).ToList();
            if(page == null)
            {
                page = 1;
            }
            var pageSize = 15;
            return View();//View(items.ToPagedList(page,pageSize));
            int pageNumber = (page ?? 1);
            int pagesize = 7;
            return View(db.Orders.ToList().OrderBy(x => x.Id).ToPagedList(pageNumber, pagesize));*/
            return View(db.Orders.ToList());
        }
        public ActionResult Details(int? id)
        {
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

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Order order = db.Orders.Find(id);
            ViewBag.OrderID = order.Id;
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // Tìm đơn hàng trong db
                Order order = db.Orders.Find(id);
                ViewBag.OrderID = order.Id;

                // Xóa order
                db.Orders.Remove(order);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }

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