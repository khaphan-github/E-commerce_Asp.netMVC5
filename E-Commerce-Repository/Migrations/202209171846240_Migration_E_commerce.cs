namespace E_Commerce_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_E_commerce : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Descibe = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Sex = c.String(),
                        Salary = c.Single(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        AccountState_Id = c.Int(),
                        Position_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountStates", t => t.AccountState_Id)
                .ForeignKey("dbo.Positions", t => t.Position_Id)
                .Index(t => t.AccountState_Id)
                .Index(t => t.Position_Id);
            
            CreateTable(
                "dbo.AccountStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BaseSalary = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        WardID = c.Int(nullable: false),
                        Wards_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wards", t => t.Wards_Id)
                .ForeignKey("dbo.Addresses", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Wards_Id);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        District_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.District_Id)
                .ForeignKey("dbo.Addresses", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.District_Id);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        WardName = c.String(),
                        Domain = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                        AccountConsumer_Id = c.Int(),
                        Address_Id = c.Int(),
                        DeliverState_Id = c.Int(),
                        PaymentMethod_Id = c.Int(),
                        ShippingMethod_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountConsumer_Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.DeliverStates", t => t.DeliverState_Id)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethod_Id)
                .ForeignKey("dbo.ShippingMethods", t => t.ShippingMethod_Id)
                .Index(t => t.AccountConsumer_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.DeliverState_Id)
                .Index(t => t.PaymentMethod_Id)
                .Index(t => t.ShippingMethod_Id);
            
            CreateTable(
                "dbo.DeliverStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OrderNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Pompany_Id = c.Int(),
                        Promotion_Id = c.Int(),
                        Supplier_Id = c.Int(),
                        TypeProduct_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Pompany_Id)
                .ForeignKey("dbo.Promotions", t => t.Promotion_Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id)
                .ForeignKey("dbo.TypeProducts", t => t.TypeProduct_Id)
                .Index(t => t.Pompany_Id)
                .Index(t => t.Promotion_Id)
                .Index(t => t.Supplier_Id)
                .Index(t => t.TypeProduct_Id);
            
            CreateTable(
                "dbo.Describes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(),
                        CPU = c.String(),
                        Ram = c.Int(),
                        HardDisk = c.String(),
                        GraphicsCard = c.String(),
                        ModelName = c.String(),
                        CellularTechnolory = c.String(),
                        MemoryStorageCapcity = c.String(),
                        Color = c.String(),
                        ScreenSize = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Ranking = c.Int(nullable: false),
                        AccountConsumer_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountConsumer_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.AccountConsumer_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        ActiveType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                        PercentPromotion = c.Single(nullable: false),
                        AccountAdmin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountAdmin_Id)
                .Index(t => t.AccountAdmin_Id);
            
            CreateTable(
                "dbo.ShoppingCards",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        isEmpty = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WareHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShippingMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BankingCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankingCardName = c.String(),
                        AccountName = c.String(),
                        AccountNumber = c.String(),
                        AccountConsumer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountConsumer_Id)
                .Index(t => t.AccountConsumer_Id);
            
            CreateTable(
                "dbo.AccountAccountRoles",
                c => new
                    {
                        Account_Id = c.Int(nullable: false),
                        AccountRole_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Account_Id, t.AccountRole_Id })
                .ForeignKey("dbo.Accounts", t => t.Account_Id, cascadeDelete: true)
                .ForeignKey("dbo.AccountRoles", t => t.AccountRole_Id, cascadeDelete: true)
                .Index(t => t.Account_Id)
                .Index(t => t.AccountRole_Id);
            
            CreateTable(
                "dbo.AddressAccountConsumers",
                c => new
                    {
                        Address_Id = c.Int(nullable: false),
                        AccountConsumer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Address_Id, t.AccountConsumer_Id })
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.AccountConsumer_Id, cascadeDelete: true)
                .Index(t => t.Address_Id)
                .Index(t => t.AccountConsumer_Id);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Order_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.ShoppingCardProducts",
                c => new
                    {
                        ShoppingCard_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShoppingCard_Id, t.Product_Id })
                .ForeignKey("dbo.ShoppingCards", t => t.ShoppingCard_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.ShoppingCard_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.WareHouseProducts",
                c => new
                    {
                        WareHouse_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WareHouse_Id, t.Product_Id })
                .ForeignKey("dbo.WareHouses", t => t.WareHouse_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.WareHouse_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCards", "Id", "dbo.Accounts");
            DropForeignKey("dbo.BankingCards", "AccountConsumer_Id", "dbo.Accounts");
            DropForeignKey("dbo.Wards", "Id", "dbo.Addresses");
            DropForeignKey("dbo.Provinces", "Id", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "ShippingMethod_Id", "dbo.ShippingMethods");
            DropForeignKey("dbo.WareHouseProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.WareHouseProducts", "WareHouse_Id", "dbo.WareHouses");
            DropForeignKey("dbo.Products", "TypeProduct_Id", "dbo.TypeProducts");
            DropForeignKey("dbo.TypeProducts", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Products", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.ShoppingCardProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ShoppingCardProducts", "ShoppingCard_Id", "dbo.ShoppingCards");
            DropForeignKey("dbo.Products", "Promotion_Id", "dbo.Promotions");
            DropForeignKey("dbo.Promotions", "AccountAdmin_Id", "dbo.Accounts");
            DropForeignKey("dbo.ProductImages", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Pompany_Id", "dbo.Companies");
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductOrders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Feedbacks", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Feedbacks", "AccountConsumer_Id", "dbo.Accounts");
            DropForeignKey("dbo.Describes", "Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "PaymentMethod_Id", "dbo.PaymentMethods");
            DropForeignKey("dbo.Orders", "DeliverState_Id", "dbo.DeliverStates");
            DropForeignKey("dbo.Orders", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "AccountConsumer_Id", "dbo.Accounts");
            DropForeignKey("dbo.Districts", "Id", "dbo.Addresses");
            DropForeignKey("dbo.Districts", "Wards_Id", "dbo.Wards");
            DropForeignKey("dbo.Provinces", "District_Id", "dbo.Districts");
            DropForeignKey("dbo.AddressAccountConsumers", "AccountConsumer_Id", "dbo.Accounts");
            DropForeignKey("dbo.AddressAccountConsumers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Accounts", "Position_Id", "dbo.Positions");
            DropForeignKey("dbo.Accounts", "AccountState_Id", "dbo.AccountStates");
            DropForeignKey("dbo.AccountAccountRoles", "AccountRole_Id", "dbo.AccountRoles");
            DropForeignKey("dbo.AccountAccountRoles", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.WareHouseProducts", new[] { "Product_Id" });
            DropIndex("dbo.WareHouseProducts", new[] { "WareHouse_Id" });
            DropIndex("dbo.ShoppingCardProducts", new[] { "Product_Id" });
            DropIndex("dbo.ShoppingCardProducts", new[] { "ShoppingCard_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Product_Id" });
            DropIndex("dbo.AddressAccountConsumers", new[] { "AccountConsumer_Id" });
            DropIndex("dbo.AddressAccountConsumers", new[] { "Address_Id" });
            DropIndex("dbo.AccountAccountRoles", new[] { "AccountRole_Id" });
            DropIndex("dbo.AccountAccountRoles", new[] { "Account_Id" });
            DropIndex("dbo.BankingCards", new[] { "AccountConsumer_Id" });
            DropIndex("dbo.TypeProducts", new[] { "Category_Id" });
            DropIndex("dbo.ShoppingCards", new[] { "Id" });
            DropIndex("dbo.Promotions", new[] { "AccountAdmin_Id" });
            DropIndex("dbo.ProductImages", new[] { "Product_Id" });
            DropIndex("dbo.Feedbacks", new[] { "Product_Id" });
            DropIndex("dbo.Feedbacks", new[] { "AccountConsumer_Id" });
            DropIndex("dbo.Describes", new[] { "Id" });
            DropIndex("dbo.Products", new[] { "TypeProduct_Id" });
            DropIndex("dbo.Products", new[] { "Supplier_Id" });
            DropIndex("dbo.Products", new[] { "Promotion_Id" });
            DropIndex("dbo.Products", new[] { "Pompany_Id" });
            DropIndex("dbo.Orders", new[] { "ShippingMethod_Id" });
            DropIndex("dbo.Orders", new[] { "PaymentMethod_Id" });
            DropIndex("dbo.Orders", new[] { "DeliverState_Id" });
            DropIndex("dbo.Orders", new[] { "Address_Id" });
            DropIndex("dbo.Orders", new[] { "AccountConsumer_Id" });
            DropIndex("dbo.Wards", new[] { "Id" });
            DropIndex("dbo.Provinces", new[] { "District_Id" });
            DropIndex("dbo.Provinces", new[] { "Id" });
            DropIndex("dbo.Districts", new[] { "Wards_Id" });
            DropIndex("dbo.Districts", new[] { "Id" });
            DropIndex("dbo.Accounts", new[] { "Position_Id" });
            DropIndex("dbo.Accounts", new[] { "AccountState_Id" });
            DropTable("dbo.WareHouseProducts");
            DropTable("dbo.ShoppingCardProducts");
            DropTable("dbo.ProductOrders");
            DropTable("dbo.AddressAccountConsumers");
            DropTable("dbo.AccountAccountRoles");
            DropTable("dbo.BankingCards");
            DropTable("dbo.ShippingMethods");
            DropTable("dbo.WareHouses");
            DropTable("dbo.Categories");
            DropTable("dbo.TypeProducts");
            DropTable("dbo.Suppliers");
            DropTable("dbo.ShoppingCards");
            DropTable("dbo.Promotions");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Companies");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Describes");
            DropTable("dbo.Products");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.DeliverStates");
            DropTable("dbo.Orders");
            DropTable("dbo.Wards");
            DropTable("dbo.Provinces");
            DropTable("dbo.Districts");
            DropTable("dbo.Addresses");
            DropTable("dbo.Positions");
            DropTable("dbo.AccountStates");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountRoles");
        }
    }
}
