namespace E_Commerce_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitWareHouseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        level = c.Int(nullable: false),
                        Descibe = c.String(maxLength: 50),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 130),
                        DisplayName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Phone = c.String(),
                        DateOfBirth = c.DateTime(precision: 7, storeType: "datetime2"),
                        Sex = c.String(),
                        Avatar = c.String(),
                        AccountStateId = c.Int(nullable: false),
                        Salary = c.Single(),
                        PositionId = c.Int(),
                        BankingCardsId = c.Int(),
                        ShoppingCardsId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountStates", t => t.AccountStateId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .Index(t => t.Username, unique: true)
                .Index(t => t.AccountStateId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.AccountStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
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
                "dbo.Promotions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                        PercentPromotion = c.Single(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AccountAdminID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountAdminID)
                .Index(t => t.AccountAdminID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TypeProductID = c.Int(),
                        SupplierID = c.Int(),
                        CompanyID = c.Int(),
                        DescribeID = c.Int(),
                        PromotionID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .ForeignKey("dbo.Promotions", t => t.PromotionID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID)
                .ForeignKey("dbo.TypeProducts", t => t.TypeProductID)
                .Index(t => t.TypeProductID)
                .Index(t => t.SupplierID)
                .Index(t => t.CompanyID)
                .Index(t => t.PromotionID);
            
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
                "dbo.Describes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(),
                        Pin = c.Int(nullable: false),
                        ProductID = c.Int(),
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
                        AccountConsumerID = c.Int(),
                        ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountConsumerID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.AccountConsumerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        ProvinceID = c.Int(),
                        DistrictID = c.Int(),
                        WardsID = c.Int(),
                        Warehouses_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Warehouses", t => t.Warehouses_Id)
                .Index(t => t.Warehouses_Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TotalPrice = c.Single(nullable: false),
                        ShippingMethodID = c.Int(),
                        PaymentMethodId = c.Int(),
                        AddressID = c.Int(),
                        DeliverStateID = c.Int(),
                        AccountConsumerID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountConsumerID)
                .ForeignKey("dbo.Addresses", t => t.AddressID)
                .ForeignKey("dbo.DeliverStates", t => t.DeliverStateID)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId)
                .ForeignKey("dbo.ShippingMethods", t => t.ShippingMethodID)
                .Index(t => t.ShippingMethodID)
                .Index(t => t.PaymentMethodId)
                .Index(t => t.AddressID)
                .Index(t => t.DeliverStateID)
                .Index(t => t.AccountConsumerID);
            
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
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberofItems = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
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
                "dbo.ShippingMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Domain = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WarehouseProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        numerItems = c.Int(nullable: false),
                        status = c.String(),
                        productId = c.Int(),
                        WarehousesID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.productId)
                .ForeignKey("dbo.Warehouses", t => t.WarehousesID)
                .Index(t => t.productId)
                .Index(t => t.WarehousesID);
            
            CreateTable(
                "dbo.BankingCards",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        BankingCardName = c.String(),
                        AccountName = c.String(),
                        AccountNumber = c.String(),
                        AccountConsumerID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingCards",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        isEmpty = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        totalPrice = c.Single(nullable: false),
                        AccountConsumerID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingCardDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        price = c.Single(nullable: false),
                        ShoppingCardID = c.Int(),
                        ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.ShoppingCards", t => t.ShoppingCardID)
                .Index(t => t.ShoppingCardID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        thumbImage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "TypeProductID", "dbo.TypeProducts");
            DropForeignKey("dbo.TypeProducts", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "PromotionID", "dbo.Promotions");
            DropForeignKey("dbo.ProductImages", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Feedbacks", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ShoppingCardDetails", "ShoppingCardID", "dbo.ShoppingCards");
            DropForeignKey("dbo.ShoppingCardDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ShoppingCards", "Id", "dbo.Accounts");
            DropForeignKey("dbo.Feedbacks", "AccountConsumerID", "dbo.Accounts");
            DropForeignKey("dbo.BankingCards", "Id", "dbo.Accounts");
            DropForeignKey("dbo.Addresses", "Warehouses_Id", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseProducts", "WarehousesID", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseProducts", "productId", "dbo.Products");
            DropForeignKey("dbo.Wards", "Id", "dbo.Addresses");
            DropForeignKey("dbo.Provinces", "Id", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "ShippingMethodID", "dbo.ShippingMethods");
            DropForeignKey("dbo.Orders", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "DeliverStateID", "dbo.DeliverStates");
            DropForeignKey("dbo.Orders", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "AccountConsumerID", "dbo.Accounts");
            DropForeignKey("dbo.Districts", "Id", "dbo.Addresses");
            DropForeignKey("dbo.AddressAccountConsumers", "AccountConsumer_Id", "dbo.Accounts");
            DropForeignKey("dbo.AddressAccountConsumers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Describes", "Id", "dbo.Products");
            DropForeignKey("dbo.Products", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Promotions", "AccountAdminID", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Accounts", "AccountStateId", "dbo.AccountStates");
            DropForeignKey("dbo.AccountAccountRoles", "AccountRole_Id", "dbo.AccountRoles");
            DropForeignKey("dbo.AccountAccountRoles", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.AddressAccountConsumers", new[] { "AccountConsumer_Id" });
            DropIndex("dbo.AddressAccountConsumers", new[] { "Address_Id" });
            DropIndex("dbo.AccountAccountRoles", new[] { "AccountRole_Id" });
            DropIndex("dbo.AccountAccountRoles", new[] { "Account_Id" });
            DropIndex("dbo.TypeProducts", new[] { "CategoryID" });
            DropIndex("dbo.ProductImages", new[] { "ProductID" });
            DropIndex("dbo.ShoppingCardDetails", new[] { "ProductID" });
            DropIndex("dbo.ShoppingCardDetails", new[] { "ShoppingCardID" });
            DropIndex("dbo.ShoppingCards", new[] { "Id" });
            DropIndex("dbo.BankingCards", new[] { "Id" });
            DropIndex("dbo.WarehouseProducts", new[] { "WarehousesID" });
            DropIndex("dbo.WarehouseProducts", new[] { "productId" });
            DropIndex("dbo.Wards", new[] { "Id" });
            DropIndex("dbo.Provinces", new[] { "Id" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "AccountConsumerID" });
            DropIndex("dbo.Orders", new[] { "DeliverStateID" });
            DropIndex("dbo.Orders", new[] { "AddressID" });
            DropIndex("dbo.Orders", new[] { "PaymentMethodId" });
            DropIndex("dbo.Orders", new[] { "ShippingMethodID" });
            DropIndex("dbo.Districts", new[] { "Id" });
            DropIndex("dbo.Addresses", new[] { "Warehouses_Id" });
            DropIndex("dbo.Feedbacks", new[] { "ProductID" });
            DropIndex("dbo.Feedbacks", new[] { "AccountConsumerID" });
            DropIndex("dbo.Describes", new[] { "Id" });
            DropIndex("dbo.Products", new[] { "PromotionID" });
            DropIndex("dbo.Products", new[] { "CompanyID" });
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropIndex("dbo.Products", new[] { "TypeProductID" });
            DropIndex("dbo.Promotions", new[] { "AccountAdminID" });
            DropIndex("dbo.AccountStates", new[] { "Name" });
            DropIndex("dbo.Accounts", new[] { "PositionId" });
            DropIndex("dbo.Accounts", new[] { "AccountStateId" });
            DropIndex("dbo.Accounts", new[] { "Username" });
            DropIndex("dbo.AccountRoles", new[] { "Name" });
            DropTable("dbo.AddressAccountConsumers");
            DropTable("dbo.AccountAccountRoles");
            DropTable("dbo.Categories");
            DropTable("dbo.TypeProducts");
            DropTable("dbo.Suppliers");
            DropTable("dbo.ProductImages");
            DropTable("dbo.ShoppingCardDetails");
            DropTable("dbo.ShoppingCards");
            DropTable("dbo.BankingCards");
            DropTable("dbo.WarehouseProducts");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Wards");
            DropTable("dbo.Provinces");
            DropTable("dbo.ShippingMethods");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.DeliverStates");
            DropTable("dbo.Orders");
            DropTable("dbo.Districts");
            DropTable("dbo.Addresses");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Describes");
            DropTable("dbo.Companies");
            DropTable("dbo.Products");
            DropTable("dbo.Promotions");
            DropTable("dbo.Positions");
            DropTable("dbo.AccountStates");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountRoles");
        }
    }
}
