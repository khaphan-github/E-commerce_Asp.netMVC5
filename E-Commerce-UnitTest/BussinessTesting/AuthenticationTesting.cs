using E_Commerce.Controllers;
using E_Commerce_Business_Logic.Logic;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce_UnitTest.BussinessTesting {
    [TestClass]
    public class AuthenticationTesting {

        [TestMethod]
        public void whenUserLoginSuccess_thenMessage() {
            string username = "0329199948";
            string password = "0329199948";

            Login login = new Login();
            Account acc = login.ValidationAccount(username, password);

            Assert.IsNotNull(acc);
        }
    }
}
