namespace E_Commerce_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IngonreChange : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Addresses", "Warehouses_Id", "dbo.Warehouses");
            //DropForeignKey("dbo.Districts", "Id", "dbo.Addresses");
            //DropForeignKey("dbo.Provinces", "Id", "dbo.Addresses");
            //DropForeignKey("dbo.Wards", "Id", "dbo.Addresses");
            //DropIndex("dbo.Addresses", new[] { "Warehouses_Id" });
            //DropIndex("dbo.Districts", new[] { "Id" });
            //DropIndex("dbo.Provinces", new[] { "Id" });
            //DropIndex("dbo.Wards", new[] { "Id" });
            //DropPrimaryKey("dbo.Districts");
            //DropPrimaryKey("dbo.Provinces");
            //DropPrimaryKey("dbo.Wards");
            //AddColumn("dbo.Districts", "Address_Id", c => c.Int());
            //AddColumn("dbo.ShippingMethods", "Price", c => c.Int(nullable: false));
            //AddColumn("dbo.Provinces", "Addresss_Id", c => c.Int());
            //AddColumn("dbo.Wards", "Address_Id", c => c.Int());
            //AlterColumn("dbo.Districts", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.Provinces", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.Wards", "Id", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.Districts", "Id");
            //AddPrimaryKey("dbo.Provinces", "Id");
            //AddPrimaryKey("dbo.Wards", "Id");
            //CreateIndex("dbo.Districts", "Address_Id");
            //CreateIndex("dbo.Provinces", "Addresss_Id");
            //CreateIndex("dbo.Wards", "Address_Id");
            //AddForeignKey("dbo.Districts", "Address_Id", "dbo.Addresses", "Id");
            //AddForeignKey("dbo.Provinces", "Addresss_Id", "dbo.Addresses", "Id");
            //AddForeignKey("dbo.Wards", "Address_Id", "dbo.Addresses", "Id");
            //DropColumn("dbo.Addresses", "ProvinceID");
            //DropColumn("dbo.Addresses", "DistrictID");
            //DropColumn("dbo.Addresses", "WardsID");
            //DropColumn("dbo.Addresses", "Warehouses_Id");
        }
        
        public override void Down() { 
        //{
        //    AddColumn("dbo.Addresses", "Warehouses_Id", c => c.Int());
        //    AddColumn("dbo.Addresses", "WardsID", c => c.Int());
        //    AddColumn("dbo.Addresses", "DistrictID", c => c.Int());
        //    AddColumn("dbo.Addresses", "ProvinceID", c => c.Int());
        //    DropForeignKey("dbo.Wards", "Address_Id", "dbo.Addresses");
        //    DropForeignKey("dbo.Provinces", "Addresss_Id", "dbo.Addresses");
        //    DropForeignKey("dbo.Districts", "Address_Id", "dbo.Addresses");
        //    DropIndex("dbo.Wards", new[] { "Address_Id" });
        //    DropIndex("dbo.Provinces", new[] { "Addresss_Id" });
        //    DropIndex("dbo.Districts", new[] { "Address_Id" });
        //    DropPrimaryKey("dbo.Wards");
        //    DropPrimaryKey("dbo.Provinces");
        //    DropPrimaryKey("dbo.Districts");
        //    AlterColumn("dbo.Wards", "Id", c => c.Int(nullable: false));
        //    AlterColumn("dbo.Provinces", "Id", c => c.Int(nullable: false));
        //    AlterColumn("dbo.Districts", "Id", c => c.Int(nullable: false));
        //    DropColumn("dbo.Wards", "Address_Id");
        //    DropColumn("dbo.Provinces", "Addresss_Id");
        //    DropColumn("dbo.ShippingMethods", "Price");
        //    DropColumn("dbo.Districts", "Address_Id");
        //    AddPrimaryKey("dbo.Wards", "Id");
        //    AddPrimaryKey("dbo.Provinces", "Id");
        //    AddPrimaryKey("dbo.Districts", "Id");
        //    CreateIndex("dbo.Wards", "Id");
        //    CreateIndex("dbo.Provinces", "Id");
        //    CreateIndex("dbo.Districts", "Id");
        //    CreateIndex("dbo.Addresses", "Warehouses_Id");
        //    AddForeignKey("dbo.Wards", "Id", "dbo.Addresses", "Id");
        //    AddForeignKey("dbo.Provinces", "Id", "dbo.Addresses", "Id");
        //    AddForeignKey("dbo.Districts", "Id", "dbo.Addresses", "Id");
        //    AddForeignKey("dbo.Addresses", "Warehouses_Id", "dbo.Warehouses", "Id");
        }
    }
}
