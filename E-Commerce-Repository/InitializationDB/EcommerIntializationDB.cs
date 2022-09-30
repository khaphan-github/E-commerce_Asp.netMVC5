using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            /* CHUYỂN THÀNH FALSE ĐỂ KHÔNG UDATE DỬ LIỆU TRONG SEED
                 1. PULL CODE VỀ XONG XÓA DB TRÊN MÁY
                 2. isUpdateDB = false;
                 3. Run project (Nó sẽ bị lổi) -> tắt project
                 4. Mở PACKAGE MANAGER CONSOLE > gõ "Update-Database -Verbose"
                 5. Run;
            */
            bool isUpdateDB = false;
            if (isUpdateDB) {
                var initializer = new MigrateDatabaseToLatestVersion<EcommerIntializationDB, Migrations.Configuration>();
                Database.SetInitializer(initializer);
            }
            else {
                var intitializer = new CreateDatabaseIfNotExists<EcommerIntializationDB>();
                Database.SetInitializer(intitializer);
            }
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<AccountState> AccountStates { get; set; }
        public DbSet<BankingCard> BankingCards { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<DeliverState> DeliverStates { get; set; }
        public DbSet<Describe> Describes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Feedback> Feedbacks  { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<ShoppingCard> ShoppingCards { get; set; }
        public DbSet<ShoppingCardDetail> ShoppingCardDetails { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<Wards> Wards { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Province> Provinces { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
           
            modelBuilder.Entity<Product>().HasOptional(product => product.Describe).WithRequired(desc => desc.Product);
           
            modelBuilder.Entity<Address>().HasOptional(address => address.Province).WithRequired(province => province.Addresss);
            
            modelBuilder.Entity<Address>().HasOptional(address => address.Wards).WithRequired(ward => ward.Address);
            
            modelBuilder.Entity<Address>().HasOptional(address => address.District).WithRequired(dis => dis.Address);
           
            modelBuilder.Entity<Warehouse>().HasOptional(wh => wh.Addresses).WithRequired(add => add.Warehouses);
            
            modelBuilder.Entity<AccountConsumer>().HasOptional(ac => ac.BankingCards).WithRequired(bk => bk.AccountConsumer);
        }
    }  
}
