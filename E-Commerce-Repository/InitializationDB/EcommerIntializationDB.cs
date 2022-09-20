using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.InitializationDB
{
    public class EcommerIntializationDB : DbContext
    {
       
        public EcommerIntializationDB() : base("EcommerIntializationDB")
        {
            /*
             var intitializer = new DropCreateDatabaseIfModelChanges<EcommerIntializationDB>();
             Database.SetInitializer(intitializer);
            */
            var initializer = new MigrateDatabaseToLatestVersion<EcommerIntializationDB, Migrations.Configuration>();
                Database.SetInitializer(initializer);
            
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<AccountState> AccountStates { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BankingCard> BankingCards { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<DeliverState> DeliverStates { get; set; }
        public DbSet<Describe> Describes { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Feedback> Feedbacks  { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<ShoppingCard> ShoppingCards { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<Wards> Wards { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            // Describe is a FK of Product
            modelBuilder.Entity<Product>()
                .HasOptional(product => product.Describe)
                .WithRequired(desc => desc.Product);

            // District is a FK of Address
            modelBuilder.Entity<Address>()
                .HasOptional(address => address.District)
                .WithRequired(district => district.Address);

            // Province is a FK of Address
            modelBuilder.Entity<Address>()
                .HasOptional(address => address.Province)
                .WithRequired(province => province.Address);

            // Wards is a FK of Address
            modelBuilder.Entity<Address>()
                .HasOptional(address => address.Wards)
                .WithRequired(wards => wards.Address);

            // ShoppingCard is a FK of AccountConsumer
            modelBuilder.Entity<AccountConsumer>()
              .HasOptional(accountConsumer => accountConsumer.ShoppingCard)
              .WithRequired(shoppingCard => shoppingCard.AccountConsumer);

         
        }
    }

}
