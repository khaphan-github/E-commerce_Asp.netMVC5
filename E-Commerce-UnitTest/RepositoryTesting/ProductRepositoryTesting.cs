using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_UnitTest.RepositoryTesting {
    [TestClass]
    public class ProductRepositoryTesting {
        [TestMethod]
        public void whenGetProductStoreInDB_thenShowProductInfor() {
            ProductRepository productRepository = new ProductRepository();
            Product product= productRepository.getProductById(1);
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void whenCreateAddress_thenGetAddressAgain() {
            AccountRepository accountRepository = new AccountRepository();
            AccountConsumer accountConsumer = new AccountConsumer() {

            };
            Address address = new Address() { 
            
                 Street = "HUTECH"
            };

            accountRepository.createAddress(address);
            
        }
    }

}
