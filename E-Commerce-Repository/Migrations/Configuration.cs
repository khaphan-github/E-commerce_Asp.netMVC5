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

<<<<<<< Updated upstream
        protected override void Seed(E_Commerce_Repository.InitializationDB.EcommerIntializationDB context) {
            try {
                // INIT ROLE TO DB [ACCOUNTROLE]
                context.AccountRoles.AddOrUpdate(
                    prop => prop.Id,
                    new AccountRole {Id = 1, Name = "User", Descibe = "", isActive = true },
                    new AccountRole {Id = 2, Name = "Admin", Descibe = "", isActive = true },
                    new AccountRole {Id = 3, Name = "SystemAdmin", Descibe = "Tài khoản quản trị hệ thống", isActive = true }
                );

                /* ---------------------------------------------------------------------------------------------------------------*/
                /* [ACCOUNTSTATE] */
                context.AccountStates.AddOrUpdate(
                    prop => prop.Id,
                    new AccountState {Id = 1, Name = "Hoạt động" },
                    new AccountState {Id = 2, Name = "Mới" },
                    new AccountState {Id = 3, Name = "Tạm khóa" }
                );

                /* ---------------------------------------------------------------------------------------------------------------*/
                /* POSITION ACCOUNT ADMIN */
                context.Positions.AddOrUpdate(
                    prop => prop.Id, 
                    new Position {Id = 1, Name = "Content", BaseSalary = 4500000 },
                    new Position {Id = 2, Name = "Manager", BaseSalary = 6500000 },
                    new Position {Id = 3, Name = "Designer", BaseSalary = 3500000 }
                );

                /* ---------------------------------------------------------------------------------------------------------------*/
                /* ACCOUNT */

                context.Accounts.AddOrUpdate(prop => prop.Id, 
                    new AccountConsumer {Id = 1, Username = "khaphan",Avata = "https://s120.avatar.talk.zdn.vn/5/f/e/e/12/120/903f984bfa9e8d5d3ce38605a6c722f9.jpg", DisplayName = "Kha Phan", CreatedDate = DateTime.Now, Email = "phanhoangkha01@gmail.com", Password = MD5Hash.Hash.Content("123") },
                    new AccountConsumer {Id = 2, Username = "quangvi", DisplayName = "Quang Vỉ", CreatedDate = DateTime.Now, Password = MD5Hash.Hash.Content("123") },
                    new AccountConsumer {Id = 3, Username = "yenquynh", DisplayName = "Yến Quỳnh", CreatedDate = DateTime.Now, Email = "yenquynh@gmail.com", Password = MD5Hash.Hash.Content("123") },
                    new AccountConsumer {Id = 4 ,Username = "yennhi", DisplayName = "Yến Nhi", CreatedDate = DateTime.Now, Email = "yennhi@gmail.com", Password = MD5Hash.Hash.Content("123") },

                    new AccountAdmin { Id = 11, Username = "admin", DisplayName = "Administration", CreatedDate = DateTime.Now, Password = MD5Hash.Hash.Content("123") },
                    new AccountAdmin { Id = 12, Username = "system", DisplayName = "SystemAaministration", CreatedDate = DateTime.Now, Password = MD5Hash.Hash.Content("123") }
                   
                 );

                /* ---------------------------------------------------------------------------------------------------------------*/
                // ADD ROLE TO ACCOUNT
                context.AccountRoles.Find(1).Account.Add(context.Accounts.Find(1));
                context.AccountRoles.Find(1).Account.Add(context.Accounts.Find(2));
                context.AccountRoles.Find(1).Account.Add(context.Accounts.Find(3));
                context.AccountRoles.Find(1).Account.Add(context.Accounts.Find(4));
                context.AccountRoles.Find(1).Account.Add(context.Accounts.Find(11));
                context.AccountRoles.Find(1).Account.Add(context.Accounts.Find(12));

                context.AccountRoles.Find(2).Account.Add(context.Accounts.Find(11));
                context.AccountRoles.Find(2).Account.Add(context.Accounts.Find(12));

                context.AccountRoles.Find(3).Account.Add(context.Accounts.Find(12));

                // ADD STATE TO ACCOUNT
                context.AccountStates.Find(1).Accounts.Add(context.Accounts.Find(1));
                context.AccountStates.Find(1).Accounts.Add(context.Accounts.Find(2));
                context.AccountStates.Find(1).Accounts.Add(context.Accounts.Find(3));
                context.AccountStates.Find(1).Accounts.Add(context.Accounts.Find(4));
                context.AccountStates.Find(1).Accounts.Add(context.Accounts.Find(11));
                context.AccountStates.Find(1).Accounts.Add(context.Accounts.Find(12));



               
                // ADD SHOPPING CARD TO ACCOUNT
                
                // context.BankingCards.AddOrUpdate();

                context.Categorys.AddOrUpdate(prop => prop.Id, 
                    new Category {Id = 1, Name = "Thiết bị di động" },
                    new Category {Id = 2, Name = "Máy tính" });

                context.TypeProducts.AddOrUpdate(prop => prop.Id,
                    new TypeProduct {Id = 1, Name = "Smart Phone" },
                    new TypeProduct {Id = 2, Name = "Basic Phone" },
                    new TypeProduct {Id = 3, Name = "PC" },
                    new TypeProduct {Id = 4, Name = "Laptop" }
               );

                
                // SUPPLIER
                context.Suppliers.AddOrUpdate(prop => prop.Id,
                    new Supplier {Id = 1, Name = "Thế giới di động" }
                 );
                // COMPANY
                context.Companys.AddOrUpdate(
                     prop => prop.Id,
                     new Company {Id = 1, Name = "APPLE" },
                     new Company {Id = 2, Name = "NOKIA" },
                     new Company {Id = 3, Name = "SAMSUNG" }
                );
               
                context.Promotions.AddOrUpdate(prop => prop.Id);

                // PRODUCT
                context.Products.AddOrUpdate(prop => prop.Id,
                     new Product {Id = 1, Name =  "Apple IPhone 13 Pro", Price = 23990000 },
                     new Product {Id = 2, Name = "Apple IPhone 14 Pro", Price = 23990000 },
                     new Product {Id = 3, Name = "Apple IPhone 15 Pro", Price = 23990000 }
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
                    new ProductImage {Id = 1, URL = "/Resources/ProductImage/iphone14_promax.jpg" },
                    new ProductImage {Id = 2, URL = "/Resources/ProductImage/iphone14_promaxblack.png" },
                    new ProductImage { Id = 3, URL = "/Resources/ProductImage/iphone14_promax.jpg" },
                    new ProductImage { Id = 4, URL = "/Resources/ProductImage/iphone14_promaxblack.png" },
                    new ProductImage { Id = 5, URL = "/Resources/ProductImage/iphone14_promax.jpg" },
                    new ProductImage { Id = 6, URL = "/Resources/ProductImage/iphone14_promaxblack.png" }
                );

                var image1 = context.ProductImages.Find(1);
                var image2 = context.ProductImages.Find(2);
                var image3 = context.ProductImages.Find(3);
                var image4 = context.ProductImages.Find(4); 
                var image5 = context.ProductImages.Find(5);
                var image6 = context.ProductImages.Find(6);

                product1.ProductImages.Add(image1);
                product1.ProductImages.Add(image2);
                product2.ProductImages.Add(image3);
                product2.ProductImages.Add(image4);
                product3.ProductImages.Add(image5);
                product3.ProductImages.Add(image6);


                // FEEDBACK
                context.Feedbacks.AddOrUpdate(prop => prop.Id,
                    new Feedback {
                        Id = 1,
                        Comment = "Shop giao hàng nhanh, đónh gói cẩn thận không bị móp méo. Điện thoại xài bao mượt, màu rất đẹp, " +
                        "kiểu dáng hiện đại, mua giá chênh lệch gần 1 triệu với giá thành ở ngoài quá ngon. Do bữa khui hàng mình " +
                        "k chụp hình lại nên để hình này tạm. Cảm ơn shop nhìu nh",
                        CreadtedDate = DateTime.Now,
                        Ranking = 5,
                    },
                    new Feedback {
                        Id = 2,
                        Comment = "Sản phẩm được đóng gói cẩn thận. Giao hàng đúng ngày hẹn. Giá sản phẩm hợp lí. " +
                        "Chưa dùng nên chưa nhận định được trải nghiệm sản phẩm.",
                        CreadtedDate = DateTime.Now,
                        Ranking = 5,
                    }
                );
                // ADD FEEDBACK TO PRODUCT;
                product1.Feedbacks.Add(context.Feedbacks.Find(1));
                product1.Feedbacks.Add(context.Feedbacks.Find(2));

                // ADDPRODUCT TO SHOPPING CARD
                context.ShoppingCards.Find(1).Products.Add(product1);
                context.ShoppingCards.Find(1).Products.Add(product2);

                // context.Provinces.AddOrUpdate();
                // context.District.AddOrUpdate();
                // context.Wards.AddOrUpdate();
                // context.Addresses.AddOrUpdate();
                //context.AddressAccountConsumer.AddOrUpdate(); /*--bảng này không có chèn mà vẫn có trong diagram!!!--*/
                // context.Warehouses.AddOrUpdate();
                //context.WarehousesAddresses.AddOrUpdate();
                //context.WarehouseProduct.AddOrUpdate();
                // context.PaymentMethods.AddOrUpdate();
                //context.ShippingMethods.AddOrUpdate();
                // context.DeliverStates.AddOrUpdate();
                // context.Orders.AddOrUpdate();
                //context.OrderDetail.AddOrUpdate();

                context.SaveChanges();
            } catch (Exception e) {
                
            }
          
=======
        protected override void Seed(E_Commerce_Repository.InitializationDB.EcommerIntializationDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            IList<AccountRole> roleList = new List<AccountRole>();
            roleList.Add(new AccountRole { Name = "User", Descibe = "Tài khoản khách hàng", isActive = true});
            roleList.Add(new AccountRole { Name = "Admin", Descibe = "Tài khoản quản trị trang web", isActive = true });
            roleList.Add(new AccountRole { Name = "SystemAdmin", Descibe = "Tài khoản quản trị hệ thống", isActive = true });
            context.AccountRoles.AddRange(roleList);

            IList<AccountState> accountStates = new List<AccountState>();
            accountStates.Add(new AccountState { Name = "Đang hoạt động" });
            accountStates.Add(new AccountState { Name = "Tạm khóa" });
            accountStates.Add(new AccountState { Name = "Mới" });
            context.AccountStates.AddRange(accountStates);

            IList<Position> positions = new List<Position>();
            positions.Add(new Position { Name = "Content", BaseSalary = 3400000 });
            positions.Add(new Position { Name = "Management", BaseSalary = 5400000 });
            positions.Add(new Position { Name = "Design", BaseSalary = 2400000 });
            context.Positions.AddRange(positions);

            IList<Account> accounts = new List<Account>();
            accounts.Add(new AccountConsumer {
                Username = "khaphan",
                Password = "123",
                Email = "phanhoangkha01@gmail.com",
                Phone = "0329199948",
                AccountRoles = new AccountRole { Name = "User", Descibe = "Tài khoản khách hàng", isActive = true },
                AccountState = new AccountState { Name = "Mới" },
                ShoppingCard = new ShoppingCard { }
            });
            accounts.Add(new AccountAdmin{ 
                Username = "yennhi",
                Password = "123", 
                Email = "phanhoangkha01@gmail.com",
                Phone = "0329199948", 
                AccountRoles = new AccountRole { Name = "User", Descibe = "Tài khoản khách hàng", isActive = true }, 
                AccountState = new AccountState { Name = "Mới" },
                Position = new Position { Name = "Management", BaseSalary = 5400000 },
            });
            context.Accounts.AddRange(accounts);
            
            IList<ShoppingCard> shoppingCards = new List<ShoppingCard>();
            context.ShoppingCards.AddRange(shoppingCards);

            IList<BankingCard> bankingCards = new List<BankingCard>();
            context.BankingCards.AddRange(bankingCards);

            IList<Category> categorys = new List<Category>();
            categorys.Add(new Category { Name = "Thiết bị di động"});
            categorys.Add(new Category { Name = "Máy tính" });
            context.Categorys.AddRange(categorys);

            IList<TypeProduct> typeProducts = new List<TypeProduct>();
            typeProducts.Add(new TypeProduct { Name = "Điện thoại"});
            typeProducts.Add(new TypeProduct { Name = "Máy tính bảng" });
            typeProducts.Add(new TypeProduct { Name = "Laptop" });
            typeProducts.Add(new TypeProduct { Name = "PC" });
            context.TypeProducts.AddRange(typeProducts);

            IList<Supplier> suppliers = new List<Supplier>();
            suppliers.Add(new Supplier { Name = "Phong Vũ", Email = "phongvu@gmail.com"});
            suppliers.Add(new Supplier { Name = "Thế giới di động", Email = "tgdd@gmail.com" });
            suppliers.Add(new Supplier { Name = "CellphoneS", Email = "CellphoneS@gmail.com" });
            context.Suppliers.AddRange(suppliers);

            IList<Company> companys = new List<Company>();
            companys.Add(new Company { Name = "APPLE"});
            companys.Add(new Company { Name = "SAMSUNG" });
            companys.Add(new Company { Name = "HUAWEI" });
            companys.Add(new Company { Name = "LENOVO" });
            companys.Add(new Company { Name = "MACBOOK" });
            context.Companys.AddRange(companys);

            IList<Promotion> promotions = new List<Promotion>();
            promotions.Add(new Promotion { Name = "Khuyến mãi 12/12", PercentPromotion = 0.3F, });
            context.Promotions.AddRange(promotions);


            IList<ProductImage> productImages = new List<ProductImage>();
            context.ProductImages.AddRange(productImages);
           

            IList<Product> products = new List<Product>();
            products.Add(new Product {
                Id = 9199,
                Name = "Apple iPhone 13 Pro Max",
                Company = new Company { Name = "APPLE" },
                Price = 26490000,
                Quantity = 931,
                TypeProduct = new TypeProduct { Name = "Điện thoại" },
                Supplier = new Supplier { Name = "CellphoneS", Email = "CellphoneS@gmail.com" },  

            }); 
            context.Products.AddRange(products);

            IList<Describe> describes = new List<Describe>();
            context.Describes.AddRange(describes);

        
            
            IList<Feedback> feedbacks = new List<Feedback>();
            context.Feedbacks.AddRange(feedbacks);

            //context.shoppingCarsProduct.AddRange();

            IList<Province> provinces = new List<Province>();
            context.Provinces.AddRange(provinces);

            IList<District> district = new List<District>();
            context.District.AddRange(district);

            IList<Wards> wards = new List<Wards>();
            context.Wards.AddRange(wards);

            IList<Address> addresses = new List<Address>();
            context.Addresses.AddRange(addresses);

            //context.AddressAccountConsumer.AddRange(); /*--bảng này không có chèn mà vẫn có trong diagram!!!--*/

            IList<Warehouse> warehouses = new List<Warehouse>();
            context.Warehouses.AddRange(warehouses);

            //context.WarehousesAddresses.AddRange();
            //context.WarehouseProduct.AddRange();

            IList<PaymentMethod> paymentMethods = new List<PaymentMethod>();
            context.PaymentMethods.AddRange(paymentMethods);

            IList<ShippingMethod> shippingMethods = new List<ShippingMethod>();
            context.ShippingMethods.AddRange(shippingMethods);

            IList<DeliverState> deliverStates = new List<DeliverState>();
            context.DeliverStates.AddRange(deliverStates);

            IList<Order> orders = new List<Order>();
            context.Orders.AddRange(orders);

            //context.OrderDetail.AddRange();
>>>>>>> Stashed changes
            base.Seed(context);
        }
    }
}
