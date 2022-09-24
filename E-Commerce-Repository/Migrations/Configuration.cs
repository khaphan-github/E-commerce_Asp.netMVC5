namespace E_Commerce_Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.AccountRoles.AddOrUpdate();
            context.AccountStates.AddOrUpdate();
            context.Positions.AddOrUpdate();
            context.Accounts.AddOrUpdate();
            context.ShoppingCards.AddOrUpdate();
            context.BankingCards.AddOrUpdate();
            context.Categorys.AddOrUpdate();
            context.TypeProducts.AddOrUpdate();
            context.Suppliers.AddOrUpdate();
            context.Companys.AddOrUpdate();
            context.Promotions.AddOrUpdate();
            context.Products.AddOrUpdate();
            context.Describes.AddOrUpdate();
            //context.ProductImages.AddOrUpdate();
            context.Feedbacks.AddOrUpdate();
            //context.shoppingCarsProduct.AddOrUpdate();
            //context.Provinces.AddOrUpdate();
            context.District.AddOrUpdate();
            context.Wards.AddOrUpdate();
            context.Addresses.AddOrUpdate();
            //context.AddressAccountConsumer.AddOrUpdate(); /*--bảng này không có chèn mà vẫn có trong diagram!!!--*/
            context.Warehouses.AddOrUpdate();
            //context.WarehousesAddresses.AddOrUpdate();
            //context.WarehouseProduct.AddOrUpdate();
            context.PaymentMethods.AddOrUpdate();
            context.ShippingMethods.AddOrUpdate();
            context.DeliverStates.AddOrUpdate();
            context.Orders.AddOrUpdate();
            //context.OrderDetail.AddOrUpdate();
            base.Seed(context);
        }
    }
}
