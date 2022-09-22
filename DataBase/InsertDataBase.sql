use EcommerIntializationDB

--------------------------------------------------------------------------------------------------------
select * from AccountRoles
select * from AccountStates
select * from Positions
select * from BankingCards
select * from Accounts --con

insert into AccountRoles([Name],descibe, isActive)
	values(N'Người dùng',N'Đây là khách hàng', 1);
insert into AccountStates([name])
	values(N'Đang hoạt động');
insert into Positions([name],baseSalary)
	values(N'Trùm cuối',99999);
insert into BankingCards(bankingCardName,accountName,accountNumber,AccountConsumer_Id)
	values('Vietinbank','Tran Van Acc1','0123456789',3);
insert into Accounts(username,[password],email,phone,dateOfBirth,sex,Discriminator, AccountState_Id, AccountRoles_Id, Position_Id, accounts.CreatedDate)
	values('acc1','acc123','a@gmail.com','0123456789','1/1/1999','Nam', '',1,1,1 , '2008-11-11 13:23:44'),
		('admin','admin123','b@gmail.com','0987654321','1/1/2000','Nu','',1,1,1, '2008-11-11 13:23:44');  

---------------------------------------------------------------------------------------------------
select * from ShoppingCards
select * from ShoppingCardProducts

insert into ShoppingCards(Number, isEmpty, CreatedDate)
values(1,0,'2/1/2011');
insert into ShoppingCardProducts(ShoppingCard_Id, Product_Id)
values(1,1);
-------------------------------------------------------------------------------------------

select * from DeliverStates
select * from PaymentMethods
select * from ShippingMethods
select * from Orders
select * from OrderDetails

insert into PaymentMethods(Name)
	values (N'Thẻ ngân hàng' ),
		('Thanh toan bang tien mat');
insert into ShippingMethods(Name, [Desc])
	values('Giao nhanh', '');
insert into DeliverStates(Name,OrderNumber)
	values(N'Chờ',2);

insert into Orders(Date,totalPrice,AccountConsumer_Id,Address_ID,DeliverState_ID,PaymentMethod_ID,ShippingMethod_Id)
values('16-9-2022',25590000,3,1,1,1,3);

insert into OrderDetails(NumberofItems, Price, Order_Id, Product_Id)
values(2, 20000, 1, 1)
----------------------------------------------------------------------------------------

select * from Categories
select * from TypeProducts --con

insert into Categories (Name)
values (N'Thiết Bị Điện Tử'), 
		(N'Điện Thoại & Phụ Kiện'),
		(N'Máy Tính & Laptop');
insert into TypeProducts(Name, Category_Id)
values(N'Điện Thoại',5),(N'Laptop', 6), (N'Tai Nghe',5);
---------------------------------------------------------------------------------

select * from Provinces --1
select * from Districts   --2
select * from Wards  --3
select * from Addresses  -- con

insert into Provinces(Name, Domain)
values('TpHCM',1);
insert into Districts(Name,Province_Id)
values('Tp Thu Duc',1)
insert into Wards(Name)
values('phuong Hiep Phu','Nam');
insert into Addresses(Street)
values('Le Van Viet');

---------------------------------------------------------------------------------------

select * from WarehouseAddresses
select * from WarehouseProducts
select * from Warehouses

insert into WarehouseProducts(Number, Product_Id, Warehouse_Id)
values(5, 1,1)
insert into WarehouseAddresses(Warehouse_Id, Address_Id)
values(1,1)
insert into WareHouses(Name,Status)
values(N'Nhà Kho Khu AB',N'Đang Hoạt Động'),
		(N'Nhà Kho Khu R',N'Đang Hoạt Động'),
		(N'Nhà Kho Khu E',N'Đang Hoạt Động');


---------------------------------------------------------------------------------------

select * from Promotions
select * from Companies
select * from Suppliers
select * from ProductImages
select * from Describes
select * from Products--con
select * from Feedbacks

insert into ProductImages(URL,Product_Id)
values('hinhnaokhongbiet.png',1);
insert into Suppliers(Name,Phone,Email)
values('Apple','0147258369','apple@gmail.com'),
		('SamSung','0147258369','samsung@gmail.com');
insert into Companies(Name,Phone,Email,ActiveType)
values('ViTranSoftware','0355034864','vitrtan.0905202@gmail.com','');
insert into Describes(Description, ModelName, CPU, Ram, HardDisk, GraphicsCard, Pin)
values('', 'ASUS TUF F15','','','', '', ''  );
insert into Describes(Description, ModelName, CellularTechnolory, MemoryStorageCapcity, Color, ScreenSize, Discriminator, Pin)
values('', 'Iphone 14', '', '', '' ,'','',''  );
insert into Promotions([name], [Desc],percentPromotion, accountAdmin_id)
values('Khuyen mai 1',N'giảm giá',4,2);
insert into Products(name,price,quantity,TypeProduct_Id,Supplier_Id,Company_Id,Promotion_Id)
values('iPhone 14 Pro',30990000,100,1,1,1,1);
insert into Feedbacks(comment,ranking,AccountConsumer_Id,Product_Id)
values('Chat luong ok nha<3',5,3,1);