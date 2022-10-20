using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce_Business_Logic.Session;
using E_Commerce_Business_Logic.CartHandler;

using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using E_Commerce_Business_Logic.RequestFilter;

namespace E_Commerce.Controllers {

    [AuthenticationFilter]
    public class CardController : Controller {
        // GET: Card
        private ProductRepository productRepository = new ProductRepository();
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
        public string addProductToCard(int productId) {
            return CartHandlders.addProductToCart(productId);
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public string removeProductFromCard(int productId) {
            return CartHandlders.RemoveProductFromCart(productId);
        }
    }
}