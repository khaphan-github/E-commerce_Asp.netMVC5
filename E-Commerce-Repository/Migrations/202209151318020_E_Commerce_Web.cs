namespace E_Commerce_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class E_Commerce_Web : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30),
                        descibe = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 256),
                        password = c.String(nullable: false, maxLength: 256),
                        email = c.String(maxLength: 256),
                        phone = c.String(maxLength: 10),
                        address = c.String(),
                        dateOfBirth = c.DateTime(nullable: false),
                        sex = c.String(),
                        avatar = c.String(),
                        salary = c.Single(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AccountStates",
                c => new
                    {
                        id = c.Int(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Account", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        id = c.Int(nullable: false),
                        name = c.String(nullable: false, maxLength: 50),
                        baseSalary = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Account", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        desc = c.String(),
                        percentPromotion = c.Single(nullable: false),
                        AdminAccountId = c.Int(nullable: false),
                        accountAdmin_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.accountAdmin_id)
                .Index(t => t.accountAdmin_id);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(),
                    price = c.Int(nullable: false),
                    quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TypeproductId = c.Int(nullable: false),
                    SupplierID = c.Int(nullable: false),
                    CompanyID = c.Int(nullable: false),
                    promotionid = c.Int(nullable: false),

                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .ForeignKey("dbo.Promotions", t => t.promotionid, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID)
                .Index(t => t.CompanyID)
                .Index(t => t.promotionid);
   
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        ActiveType = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Describes",
                c => new
                    {
                        DescribeId = c.Int(nullable: false),
                        Description = c.String(),
                        CPU = c.String(),
                        Ram = c.Int(),
                        HardDisk = c.String(),
                        GraphicsCard = c.String(),
                        Pin = c.Int(),
                        ModelName = c.String(),
                        Pin1 = c.Int(),
                        CellularTechnolory = c.String(),
                        MemoryStorageCapcity = c.String(),
                        Color = c.String(),
                        ScreenSize = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DescribeId)
                .ForeignKey("dbo.Products", t => t.DescribeId)
                .Index(t => t.DescribeId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        comment = c.String(),
                        ranking = c.Int(nullable: false),
                        AccountConsumerId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountConsumerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.AccountConsumerId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        AccountConsumer_id = c.Int(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Account", t => t.AccountConsumer_id)
                .Index(t => t.AccountConsumer_id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false),
                        DistrictName = c.String(),
                        WardID = c.Int(nullable: false),
                        wards_WardsId = c.Int(),
                    })
                .PrimaryKey(t => t.DistrictId)
                .ForeignKey("dbo.Wards", t => t.wards_WardsId)
                .ForeignKey("dbo.Addresses", t => t.DistrictId)
                .Index(t => t.DistrictId)
                .Index(t => t.wards_WardsId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceId = c.Int(nullable: false),
                        ProvinceName = c.String(),
                        DistrictID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinceId)
                .ForeignKey("dbo.Districts", t => t.DistrictID, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.ProvinceId)
                .Index(t => t.ProvinceId)
                .Index(t => t.DistrictID);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        WardsId = c.Int(nullable: false),
                        WardName = c.String(),
                        Domain = c.String(),
                    })
                .PrimaryKey(t => t.WardsId)
                .ForeignKey("dbo.Addresses", t => t.WardsId)
                .Index(t => t.WardsId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        orderedDate = c.DateTime(nullable: false),
                        totalPrice = c.Single(nullable: false),
                        shippingMethodId = c.Int(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                        DeliverStateID = c.Int(nullable: false),
                        AccountConsumer_id = c.Int(),
                        DeliverState_DeliverId = c.Int(),
                        PaymentMethod_PaymentId = c.Int(),
                    })
                .PrimaryKey(t => t.orderId)
                .ForeignKey("dbo.Account", t => t.AccountConsumer_id)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .ForeignKey("dbo.DeliverStates", t => t.DeliverState_DeliverId)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethod_PaymentId)
                .ForeignKey("dbo.ShippingMethods", t => t.shippingMethodId, cascadeDelete: true)
                .Index(t => t.shippingMethodId)
                .Index(t => t.AddressID)
                .Index(t => t.AccountConsumer_id)
                .Index(t => t.DeliverState_DeliverId)
                .Index(t => t.PaymentMethod_PaymentId);
            
            CreateTable(
                "dbo.DeliverStates",
                c => new
                    {
                        DeliverId = c.Int(nullable: false, identity: true),
                        DeliverName = c.String(),
                        OrderNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeliverId);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        PaymentName = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.ShippingMethods",
                c => new
                    {
                        ShippingMethodId = c.Int(nullable: false, identity: true),
                        ShippingMethodName = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.ShippingMethodId);
            
            CreateTable(
                "dbo.BankingCards",
                c => new
                    {
                        bankingCardId = c.Int(nullable: false, identity: true),
                        bankingCardName = c.String(),
                        accountName = c.String(),
                        accountNumber = c.String(),
                        AccountConsumerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.bankingCardId)
                .ForeignKey("dbo.Account", t => t.AccountConsumerID, cascadeDelete: true)
                .Index(t => t.AccountConsumerID);
            
            CreateTable(
                "dbo.ShoppingCards",
                c => new
                    {
                        ShoppingId = c.Int(nullable: false),
                        NumberOfItems = c.Int(nullable: false),
                        IsEmpty = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingId)
                .ForeignKey("dbo.Account", t => t.ShoppingId)
                .Index(t => t.ShoppingId);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.TypeProducts",
                c => new
                    {
                        typeID = c.Int(nullable: false, identity: true),
                        typeName = c.String(),
                        CategogyId = c.Int(nullable: false),
                        category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.typeID)
                .ForeignKey("dbo.Categories", t => t.category_CategoryId)
                .Index(t => t.category_CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        Phone = c.String(),
                        Email = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.WareHouses",
                c => new
                    {
                        WareHouseId = c.Int(nullable: false, identity: true),
                        WareHouseName = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.WareHouseId);
            
            CreateTable(
                "dbo.AccountAccountRoles",
                c => new
                    {
                        Account_id = c.Int(nullable: false),
                        AccountRole_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Account_id, t.AccountRole_id })
                .ForeignKey("dbo.Account", t => t.Account_id, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.AccountRole_id, cascadeDelete: true)
                .Index(t => t.Account_id)
                .Index(t => t.AccountRole_id);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Order_orderId = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_orderId, t.Product_id })
                .ForeignKey("dbo.Orders", t => t.Order_orderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.Order_orderId)
                .Index(t => t.Product_id);
            
            CreateTable(
                "dbo.ShoppingCardProducts",
                c => new
                    {
                        ShoppingCard_ShoppingId = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShoppingCard_ShoppingId, t.Product_id })
                .ForeignKey("dbo.ShoppingCards", t => t.ShoppingCard_ShoppingId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.ShoppingCard_ShoppingId)
                .Index(t => t.Product_id);
            
            CreateTable(
                "dbo.WareHouseProducts",
                c => new
                    {
                        WareHouse_WareHouseId = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WareHouse_WareHouseId, t.Product_id })
                .ForeignKey("dbo.WareHouses", t => t.WareHouse_WareHouseId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.WareHouse_WareHouseId)
                .Index(t => t.Product_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WareHouseProducts", "Product_id", "dbo.Products");
            DropForeignKey("dbo.WareHouseProducts", "WareHouse_WareHouseId", "dbo.WareHouses");
            DropForeignKey("dbo.Products", "TypeProduct_typeID1", "dbo.TypeProducts");
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "promotionid", "dbo.Promotions");
            DropForeignKey("dbo.Products", "productType_typeID", "dbo.TypeProducts");
            DropForeignKey("dbo.Products", "TypeProduct_typeID", "dbo.TypeProducts");
            DropForeignKey("dbo.TypeProducts", "category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductImages", "productId", "dbo.Products");
            DropForeignKey("dbo.Feedbacks", "productId", "dbo.Products");
            DropForeignKey("dbo.ShoppingCards", "ShoppingId", "dbo.Account");
            DropForeignKey("dbo.ShoppingCardProducts", "Product_id", "dbo.Products");
            DropForeignKey("dbo.ShoppingCardProducts", "ShoppingCard_ShoppingId", "dbo.ShoppingCards");
            DropForeignKey("dbo.Feedbacks", "AccountConsumerId", "dbo.Account");
            DropForeignKey("dbo.BankingCards", "AccountConsumerID", "dbo.Account");
            DropForeignKey("dbo.Addresses", "AccountConsumer_id", "dbo.Account");
            DropForeignKey("dbo.Wards", "WardsId", "dbo.Addresses");
            DropForeignKey("dbo.Provinces", "ProvinceId", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "shippingMethodId", "dbo.ShippingMethods");
            DropForeignKey("dbo.OrderProducts", "Product_id", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "Order_orderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "PaymentMethod_PaymentId", "dbo.PaymentMethods");
            DropForeignKey("dbo.Orders", "DeliverState_DeliverId", "dbo.DeliverStates");
            DropForeignKey("dbo.Orders", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "AccountConsumer_id", "dbo.Account");
            DropForeignKey("dbo.Districts", "DistrictId", "dbo.Addresses");
            DropForeignKey("dbo.Districts", "wards_WardsId", "dbo.Wards");
            DropForeignKey("dbo.Provinces", "DistrictID", "dbo.Districts");
            DropForeignKey("dbo.Describes", "DescribeId", "dbo.Products");
            DropForeignKey("dbo.Products", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Promotions", "accountAdmin_id", "dbo.Account");
            DropForeignKey("dbo.Positions", "id", "dbo.Account");
            DropForeignKey("dbo.AccountStates", "id", "dbo.Account");
            DropForeignKey("dbo.AccountAccountRoles", "AccountRole_id", "dbo.Role");
            DropForeignKey("dbo.AccountAccountRoles", "Account_id", "dbo.Account");
            DropIndex("dbo.WareHouseProducts", new[] { "Product_id" });
            DropIndex("dbo.WareHouseProducts", new[] { "WareHouse_WareHouseId" });
            DropIndex("dbo.ShoppingCardProducts", new[] { "Product_id" });
            DropIndex("dbo.ShoppingCardProducts", new[] { "ShoppingCard_ShoppingId" });
            DropIndex("dbo.OrderProducts", new[] { "Product_id" });
            DropIndex("dbo.OrderProducts", new[] { "Order_orderId" });
            DropIndex("dbo.AccountAccountRoles", new[] { "AccountRole_id" });
            DropIndex("dbo.AccountAccountRoles", new[] { "Account_id" });
            DropIndex("dbo.TypeProducts", new[] { "category_CategoryId" });
            DropIndex("dbo.ProductImages", new[] { "productId" });
            DropIndex("dbo.ShoppingCards", new[] { "ShoppingId" });
            DropIndex("dbo.BankingCards", new[] { "AccountConsumerID" });
            DropIndex("dbo.Orders", new[] { "PaymentMethod_PaymentId" });
            DropIndex("dbo.Orders", new[] { "DeliverState_DeliverId" });
            DropIndex("dbo.Orders", new[] { "AccountConsumer_id" });
            DropIndex("dbo.Orders", new[] { "AddressID" });
            DropIndex("dbo.Orders", new[] { "shippingMethodId" });
            DropIndex("dbo.Wards", new[] { "WardsId" });
            DropIndex("dbo.Provinces", new[] { "DistrictID" });
            DropIndex("dbo.Provinces", new[] { "ProvinceId" });
            DropIndex("dbo.Districts", new[] { "wards_WardsId" });
            DropIndex("dbo.Districts", new[] { "DistrictId" });
            DropIndex("dbo.Addresses", new[] { "AccountConsumer_id" });
            DropIndex("dbo.Feedbacks", new[] { "productId" });
            DropIndex("dbo.Feedbacks", new[] { "AccountConsumerId" });
            DropIndex("dbo.Describes", new[] { "DescribeId" });
            DropIndex("dbo.Products", new[] { "TypeProduct_typeID1" });
            DropIndex("dbo.Products", new[] { "productType_typeID" });
            DropIndex("dbo.Products", new[] { "TypeProduct_typeID" });
            DropIndex("dbo.Products", new[] { "promotionid" });
            DropIndex("dbo.Products", new[] { "CompanyID" });
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropIndex("dbo.Promotions", new[] { "accountAdmin_id" });
            DropIndex("dbo.Positions", new[] { "id" });
            DropIndex("dbo.AccountStates", new[] { "id" });
            DropTable("dbo.WareHouseProducts");
            DropTable("dbo.ShoppingCardProducts");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.AccountAccountRoles");
            DropTable("dbo.WareHouses");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Categories");
            DropTable("dbo.TypeProducts");
            DropTable("dbo.ProductImages");
            DropTable("dbo.ShoppingCards");
            DropTable("dbo.BankingCards");
            DropTable("dbo.ShippingMethods");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.DeliverStates");
            DropTable("dbo.Orders");
            DropTable("dbo.Wards");
            DropTable("dbo.Provinces");
            DropTable("dbo.Districts");
            DropTable("dbo.Addresses");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Describes");
            DropTable("dbo.Companies");
            DropTable("dbo.Products");
            DropTable("dbo.Promotions");
            DropTable("dbo.Positions");
            DropTable("dbo.AccountStates");
            DropTable("dbo.Account");
            DropTable("dbo.Role");
        }
    }
}
