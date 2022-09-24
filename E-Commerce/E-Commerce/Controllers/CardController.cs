using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce_Business_Logic.Session;

namespace E_Commerce.Controllers {
       public class CardController : Controller
    {
        // GET: Card
       
        public ActionResult Index() {
            // Nếu chư login thì không cho vào trang card
            bool NoUserSession = Session[SessionConstaint.USERSESION].Equals("");
            if (NoUserSession) {
                ViewBag.dataToggle = "modal";
                ViewBag.hreLink = "#signin-modal";
                Response.Redirect("/Home/Index/", false);
            }
            return View();
        }

        //  Thêm sản phẩm vào giỏ hàng @Url.Action("addProductToCard", "Card", new {productId = , cardId =})
        public string addProductToCard(int productId, int cardId) {
            // Use sesion
            return "1";
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public string removeProductFromCard(int productId, int cardId) {
            return "1";
        }

    }
}