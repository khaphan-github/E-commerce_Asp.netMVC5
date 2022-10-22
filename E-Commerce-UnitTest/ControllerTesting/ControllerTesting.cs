using E_Commerce.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace E_Commerce_UnitTest.ControllerTesting {
    [TestClass]
    public class ControllerTesting {
        [TestMethod]
        public void whenGetCartControler_thenShowCart() {
            // Arrange
            CardController controller = new CardController();
            // Act
            ActionResult index = controller.Index("");
            // Assert
            Assert.IsNotNull(index);
           
        }


        [TestMethod]
        public void whenGetHomeControler_thenShowHome() {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ActionResult index = controller.Index("");
            ActionResult about = controller.About();
            ActionResult contact = controller.Contact();
            ActionResult unAuth = controller.NoAuthLogin();
            // Assert
            Assert.IsNotNull(index);
            Assert.IsNotNull(about);
            Assert.IsNotNull(contact);
            Assert.IsNotNull(unAuth);
        }

        [TestMethod]
        public void whenGetShopControler_thenShowShop() {
            // Arrange
            ShopController controller = new ShopController();
            // Act
        }

    }
}
