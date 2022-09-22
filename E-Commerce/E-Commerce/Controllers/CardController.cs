using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class CardController : Controller
    {
        // GET: Card hhhh
        public ActionResult Index()
        {
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