namespace E_Commerce_Repository.Migrations
{
    using E_Commerce_Repository.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<E_Commerce_Repository.InitializationDB.EcommerIntializationDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(E_Commerce_Repository.InitializationDB.EcommerIntializationDB context)
        {
            try
            {
                // INIT ROLE TO DB [ACCOUNTROLE]
                context.AccountRoles.AddOrUpdate(
                    prop => prop.Id,
                    new AccountRole { Id = 1, Name = "User", Descibe = "", isActive = true },
                    new AccountRole { Id = 2, Name = "Admin", Descibe = "", isActive = true },
                    new AccountRole { Id = 3, Name = "SystemAdmin", Descibe = "Tài khoản quản trị hệ thống", isActive = true }
                );
                context.SaveChanges();

                /* ---------------------------------------------------------------------------------------------------------------*/
                /* [ACCOUNTSTATE] */
                context.AccountStates.AddOrUpdate(
                    prop => prop.Id,
                    new AccountState { Id = 1, Name = "Hoạt động" },
                    new AccountState { Id = 2, Name = "Mới" },
                    new AccountState { Id = 3, Name = "Tạm khóa" }
                );
                context.SaveChanges();
                /* ---------------------------------------------------------------------------------------------------------------*/
                /* POSITION ACCOUNT ADMIN */
                context.Positions.AddOrUpdate(
                    prop => prop.Id,
                    new Position { Id = 1, Name = "Content", BaseSalary = 4500000 },
                    new Position { Id = 2, Name = "Manager", BaseSalary = 6500000 },
                    new Position { Id = 3, Name = "Designer", BaseSalary = 3500000 }
                );
                context.SaveChanges();
                /* ---------------------------------------------------------------------------------------------------------------*/
                /* ACCOUNT */

                context.Accounts.AddOrUpdate(prop => prop.Id,
                    new AccountConsumer { Id = 1, Username = "khaphan", Avatar = "https://s120.avatar.talk.zdn.vn/5/f/e/e/12/120/903f984bfa9e8d5d3ce38605a6c722f9.jpg", DisplayName = "Kha Phan", CreatedDate = DateTime.Now, Email = "phanhoangkha01@gmail.com", Password = MD5Hash.Hash.Content("123") },
new AccountConsumer { Id = 2, Username = "quangvi", DisplayName = "Quang Vỉ", CreatedDate = DateTime.Now, Password = MD5Hash.Hash.Content("123") },
                    new AccountConsumer { Id = 3, Username = "yenquynh", DisplayName = "Yến Quỳnh", CreatedDate = DateTime.Now, Email = "yenquynh@gmail.com", Password = MD5Hash.Hash.Content("123") },
                    new AccountConsumer { Id = 4, Username = "yennhi", DisplayName = "Yến Nhi", CreatedDate = DateTime.Now, Email = "yennhi@gmail.com", Password = MD5Hash.Hash.Content("123") },

                    new AccountAdmin { Id = 5, Username = "admin", DisplayName = "Administration", CreatedDate = DateTime.Now, Password = MD5Hash.Hash.Content("123") },
                    new AccountAdmin { Id = 6, Username = "system", DisplayName = "SystemAaministration", CreatedDate = DateTime.Now, Password = MD5Hash.Hash.Content("123") }
                 );
                context.SaveChanges();
                /* ---------------------------------------------------------------------------------------------------------------*/
                // ADD ROLE TO ACCOUNT
                context.AccountRoles.Find(1).Account.Add(context.Accounts.Find(1));
                context.AccountRoles.Find(1).Account.Add(context.Accounts.Find(2));
                context.AccountRoles.Find(1).Account.Add(context.Accounts.Find(3));
                context.AccountRoles.Find(1).Account.Add(context.Accounts.Find(4));
                context.AccountRoles.Find(1).Account.Add(context.Accounts.Find(5));
                context.AccountRoles.Find(1).Account.Add(context.Accounts.Find(6));

                context.AccountRoles.Find(2).Account.Add(context.Accounts.Find(5));
                context.AccountRoles.Find(2).Account.Add(context.Accounts.Find(6));

                context.AccountRoles.Find(3).Account.Add(context.Accounts.Find(6));

                // ADD STATE TO ACCOUNT
                context.AccountStates.Find(1).Accounts.Add(context.Accounts.Find(1));
                context.AccountStates.Find(1).Accounts.Add(context.Accounts.Find(2));
                context.AccountStates.Find(1).Accounts.Add(context.Accounts.Find(3));
                context.AccountStates.Find(1).Accounts.Add(context.Accounts.Find(4));
                context.AccountStates.Find(1).Accounts.Add(context.Accounts.Find(5));
                context.AccountStates.Find(1).Accounts.Add(context.Accounts.Find(6));






                context.Categorys.AddOrUpdate(prop => prop.Id,
                    new Category { Id = 1, Name = "Thiết bị di động" },
                    new Category { Id = 2, Name = "Máy tính" }
                    ); context.SaveChanges();

                context.TypeProducts.AddOrUpdate(prop => prop.Id,
                    new TypeProduct { Id = 1, Name = "Smart Phone" },
                    new TypeProduct { Id = 2, Name = "Basic Phone" },
                    new TypeProduct { Id = 3, Name = "PC" },
                    new TypeProduct { Id = 4, Name = "Laptop" }
               ); context.SaveChanges();

                var typeProduct1 = context.TypeProducts.Find(1);
                var typeProduct2 = context.TypeProducts.Find(2);
                var typeProduct3 = context.TypeProducts.Find(3);
                var typeProduct4 = context.TypeProducts.Find(4);

                var category1 = context.Categorys.Find(1);
                category1.TypeProducts.Add(typeProduct1);
                category1.TypeProducts.Add(typeProduct2);

                var category2 = context.Categorys.Find(2);
                category2.TypeProducts.Add(typeProduct3);
                category2.TypeProducts.Add(typeProduct4);


                // SUPPLIER
                context.Suppliers.AddOrUpdate(prop => prop.Id,
                    new Supplier { Id = 1, Name = "Thế giới di động" }
                 ); context.SaveChanges();

                // COMPANY
                context.Companys.AddOrUpdate(
                     prop => prop.Id,
                     new Company { Id = 1, Name = "APPLE" },
                     new Company { Id = 2, Name = "NOKIA" },
                     new Company { Id = 3, Name = "SAMSUNG" }
                );


                context.Promotions.AddOrUpdate(prop => prop.Id);

                // PRODUCT
                context.Products.AddOrUpdate(prop => prop.Id,
                     new Product { Id = 1, Name = "Apple IPhone 13 Pro", Price = 23990000 },
                     new Product { Id = 2, Name = "Apple IPhone 14 Pro", Price = 23990000 },
                     new Product { Id = 3, Name = "Apple IPhone 15 Pro", Price = 43990000 }
                );


                // ADD COMPANY FOR PRODUCT
                var product1 = context.Products.Find(1);
                var product2 = context.Products.Find(2);
                var product3 = context.Products.Find(3);

                var company1 = context.Companys.Find(1);

                company1.Products.Add(product1);
                company1.Products.Add(product2);
                company1.Products.Add(product3);

                // ADD SUPPLIER FOR PRODUCT
                var supplier1 = context.Suppliers.Find(1);
                supplier1.Products.Add(product1);
                supplier1.Products.Add(product2);
                supplier1.Products.Add(product3);

                // ADD TYPE PRODUCT FOR PRODUCT
                var typeProduct = context.TypeProducts.Find(1);
                typeProduct.Products.Add(product1);
                typeProduct.Products.Add(product2);
                typeProduct.Products.Add(product3);

                // ADD IMAGE TO PRODUCT

                // context.Describes.AddOrUpdate();
                context.ProductImages.AddOrUpdate(prop => prop.Id,
                    new ProductImage { Id = 1, URL = "/Resources/ProductImage/iphone14_promax.jpg" },
                    new ProductImage { Id = 2, URL = "/Resources/ProductImage/iphone14_promaxblack.png" },
                    new ProductImage { Id = 3, URL = "/Resources/ProductImage/iphone14_promax.jpg" },
                    new ProductImage { Id = 4, URL = "/Resources/ProductImage/iphone14_promaxblack.png" },
                    new ProductImage { Id = 5, URL = "/Resources/ProductImage/iphone14_promax.jpg" },
                    new ProductImage { Id = 6, URL = "/Resources/ProductImage/iphone14_promaxblack.png" }
                );

                context.SaveChanges();
                var image1 = context.ProductImages.Find(1);
                var image2 = context.ProductImages.Find(2);
                var image3 = context.ProductImages.Find(3);
                var image4 = context.ProductImages.Find(4);
                var image5 = context.ProductImages.Find(5);
                var image6 = context.ProductImages.Find(6);
                context.SaveChanges();
                product1.ProductImages.Add(image1);
                product1.ProductImages.Add(image2);
                product2.ProductImages.Add(image3);
                product2.ProductImages.Add(image4);
                product3.ProductImages.Add(image5);
                product3.ProductImages.Add(image6);

                context.SaveChanges();
                // ADD SHOPPING CARD TO ACCOUNT

                // context.ShoppingCards.Add(new ShoppingCard { Id = context.Accounts.Find(4).Id });

                var account = context.Accounts.Find(1) as AccountConsumer;


                context.ShoppingCardDetails.Add(new ShoppingCardDetail { ShoppingCard = account.ShoppingCards, Product = product1 });
                // context.BankingCards.AddOrUpdate();
                // FEEDBACK
                context.Feedbacks.AddOrUpdate(prop => prop.Id,
                    new Feedback
                    {
                        Id = 1,
                        Comment = "Shop giao hàng nhanh, đónh gói cẩn thận không bị móp méo. Điện thoại xài bao mượt, màu rất đẹp, " +
                        "kiểu dáng hiện đại, mua giá chênh lệch gần 1 triệu với giá thành ở ngoài quá ngon. Do bữa khui hàng mình " +
                        "k chụp hình lại nên để hình này tạm. Cảm ơn shop nhìu nh",
                        CreadtedDate = DateTime.Now,
                        Ranking = 5,
                    },
                    new Feedback
                    {
                        Id = 2,
                        Comment = "Sản phẩm được đóng gói cẩn thận. Giao hàng đúng ngày hẹn. Giá sản phẩm hợp lí. " +
                        "Chưa dùng nên chưa nhận định được trải nghiệm sản phẩm.",
                        CreadtedDate = DateTime.Now,
                        Ranking = 5,
                    }
                );
                context.SaveChanges();
                // ADD FEEDBACK TO PRODUCT;
                product1.Feedbacks.Add(context.Feedbacks.Find(1));
                product1.Feedbacks.Add(context.Feedbacks.Find(2));

                // ADDPRODUCT TO SHOPPING CARD


                // context.Provinces.AddOrUpdate();
                // context.District.AddOrUpdate();
                // context.Wards.AddOrUpdate();
                //context.AddressAccountConsumer.AddOrUpdate(); /*--bảng này không có chèn mà vẫn có trong diagram!!!--*/
                // Add Warehouses
                context.Warehouses.AddOrUpdate(
                    wh=>wh.Id,
                    new Warehouse { Id = 1, Name = "Nhà kho khu AB", Status = "Đang hoạt động" },
                    new Warehouse { Id = 2, Name = "Nhà kho khu R", Status = "Đang hoạt động" },
                    new Warehouse { Id = 3, Name = "Nhà kho khu E", Status = "Đang hoạt động" },
                    new Warehouse { Id = 4, Name = "Nhà kho khu U", Status = "Đang hoạt động" }
                    );
                // Add Addresses
                context.Addresses.AddOrUpdate(
                    ad => ad.Id,
                    new Address { Id = 1, Street = "Lê Văn Việt" },
                    new Address { Id = 2, Street = "Đỗ Xuân Hợp" },
                    new Address { Id = 3, Street = "Quang Trung" },
                    new Address { Id = 4, Street = "Đinh Củng Viên" }
                    );
                //context.Warehouses.Find(1).Addresses.Add(context.Addresses.Find(1));
                context.SaveChanges();
                //context.WarehousesAddresses.AddOrUpdate();
                //context.WarehouseProduct.AddOrUpdate();
                // Add PaymentMethods
                context.PaymentMethods.AddOrUpdate(
                    pay=>pay.Id,
                    new PaymentMethod { Id = 1, Name = "Tiền mặt", Desc = "" },
                    new PaymentMethod { Id = 1, Name = "Thẻ ngân hàng", Desc = "" }
                    );
                // Add ShippingMethods
                context.ShippingMethods.AddOrUpdate(
                    shi=>shi.Id,
                    new ShippingMethod() { Id = 1, Name = "Giao hàng tiết kiệm", Desc = "" },
                    new ShippingMethod() { Id = 2, Name = "Giao hàng nhanh", Desc = "" },
                    new ShippingMethod() { Id = 3, Name = "Giao hỏa tốc", Desc = "" }
                    );
                // Add DeliverStates
                context.DeliverStates.AddOrUpdate(
                    del=>del.Id,
                    new DeliverState { Id = 1, Name = "Chờ xác nhận", OrderNumber = 2 },
                    new DeliverState { Id = 2, Name = "Chờ lấy hàng", OrderNumber = 3 },
                    new DeliverState { Id = 3, Name = "Đang giao", OrderNumber = 3 },
                    new DeliverState { Id = 4, Name = "Đã giao", OrderNumber = 2 }
                    );
                // Add Orders
                context.Orders.AddOrUpdate(o=>o.Id,
                    new Order() { Id = 1, Date = DateTime.Now, TotalPrice = 23990000 },
                    new Order() { Id = 2, Date = DateTime.Now, TotalPrice = 23990000 },
                    new Order() { Id = 3, Date = DateTime.Now, TotalPrice = 23990000 },
                    new Order() { Id = 4, Date = DateTime.Now, TotalPrice = 23990000 }
                );
                // Add ShippingMethod to Order
                context.ShippingMethods.Find(1).Orders.Add(context.Orders.Find(1));
                context.ShippingMethods.Find(2).Orders.Add(context.Orders.Find(2));
                context.ShippingMethods.Find(3).Orders.Add(context.Orders.Find(3));
                context.ShippingMethods.Find(1).Orders.Add(context.Orders.Find(4));
                // Add PaymentMethod to Order
                context.PaymentMethods.Find(1).Orders.Add(context.Orders.Find(1));
                context.PaymentMethods.Find(2).Orders.Add(context.Orders.Find(2));
                context.PaymentMethods.Find(2).Orders.Add(context.Orders.Find(3));
                context.PaymentMethods.Find(1).Orders.Add(context.Orders.Find(4));
                // Add Address to Order
                context.Addresses.Find(4).Orders.Add(context.Orders.Find(1));
                context.Addresses.Find(1).Orders.Add(context.Orders.Find(2));
                context.Addresses.Find(3).Orders.Add(context.Orders.Find(3));
                context.Addresses.Find(1).Orders.Add(context.Orders.Find(4));
                // Add DeliverState to Order
                context.DeliverStates.Find(1).Orders.Add(context.Orders.Find(1));
                context.DeliverStates.Find(2).Orders.Add(context.Orders.Find(2));
                context.DeliverStates.Find(1).Orders.Add(context.Orders.Find(3));
                context.DeliverStates.Find(4).Orders.Add(context.Orders.Find(4));
                // Add AccountConsumer to Order
                //context.Accounts.Find(1).or

                context.SaveChanges();
                /*var product1 = context.Products.Find(1);
                var supplier1 = context.Suppliers.Find(1);
                supplier1.Products.Add(product1);
                supplier1.Products.Add(product2);
                supplier1.Products.Add(product3);*/

                //context.OrderDetail.AddOrUpdate();

                context.SaveChanges();
            }
            catch (Exception e)
            {

            }

            base.Seed(context);
        }
    }
}
