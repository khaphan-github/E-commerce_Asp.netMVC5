use EcommerIntializationDB

insert into Categories (Name)
values (N'Thiết Bị Điện Tử'), 
		(N'Điện Thoại & Phụ Kiện'),
		(N'Máy Tính & Laptop');

insert into TypeProducts(Name, Category_Id)
values(N'Điện Thoại',5),(N'Laptop', 6), (N'Tai Nghe',5);

insert into WareHouses(Name,Status)
values(N'Nhà Kho Khu AB',N'Đang Hoạt Động'),
		(N'Nhà Kho Khu R',N'Đang Hoạt Động'),
		(N'Nhà Kho Khu E',N'Đang Hoạt Động');


insert into Suppliers(Name,Phone,Email)
values('Apple','0147258369','apple@gmail.com'),
		('SamSung','0147258369','samsung@gmail.com');

insert into Companies(Name,Phone,Email,ActiveType)
values('ViTranSoftware','0355034864','vitrtan.0905202@gmail.com','');

insert into Describes(Description, ModelName, CPU, Ram, HardDisk, GraphicsCard, Pin)
values('', 'ASUS TUF F15','','','', '', ''  );
insert into Describes(Description, ModelName, CellularTechnolory, MemoryStorageCapcity, Color, ScreenSize, Discriminator, Pin)
values('', 'Iphone 14', '', '', '' ,'','',''  );

insert into PaymentMethods(Name)
values (N'Khi nhận hàng' );

insert into ShoppingCards(Number,IsEmpty,CreatedDate)
values('','Empty', 9/19/2022);

insert into DeliverStates(Name,OrderNumber)
values(N'Chờ',2);


insert into Promotions(name,percentPromotion,AdminAccountId,accountAdmin_id)
values('Khuyen mai 1',10,4,4);/* AdminAccountId với accountAdmin_id khác gì nhau??? */
/* desc lỗi */ /* Nhập được mà chưa có desc */


insert into Accounts(username,password,email,phone,address,dateOfBirth,sex,avatar,Discriminator)
values('acc','28c8edde3d61a0411511d3b1866f0636','a@gmail.com','0123456789','tphcm','1/1/1999','Nam','https://kenh14cdn.com/2017/screen-shot-2017-10-14-at-41652-pm-1507972625700.png', 
'NULL');/*thiếu ngày tạo tài khoản*/  /* pass: 1 */
insert into Account(username,password,email,phone,address,dateOfBirth,sex,avatar,Discriminator)
values('admin','665f644e43731ff9db3d341da5c827e1','b@gmail.com','0987654321','Ha Noi','1/1/2000','Nu','https://nhakhoagiadinh.com.vn/hinh-anh-nguoi-cute/imager_6_77285_700.jpg', 
'NULL');  /* pass: 2 */
update Account
set salary=5000000
where id=4;

insert into Role(name,descibe)
values('Tim kiem san pham','Nhap ten san pham can tim');

insert into BankingCards(bankingCardName,accountName,accountNumber,AccountConsumerID)
values('Vietinbank','acc','0123456789',3);

insert into AccountAccountRoles(Account_id,AccountRole_id)
values(3,1);

insert into AccountStates(id,name)
values(3,'Hoat dong 1 nam');

insert into Addresses(Street,AccountConsumer_id)
values('Le Van Viet',3);

insert into Wards(WardsId,WardName,Domain)
values(1,'phuong Hiep Phu','Nam');

insert into Districts(DistrictId,DistrictName,WardID,wards_WardsId)
values(1,'Tp Thu Duc',1,1)/*chú thích: WardID là sửa tên là tỉnh thành*/

insert into Provinces(ProvinceId,ProvinceName,DistrictID)
values(1,'TpHCM',1);





insert into Products(name,price,quantity,TypeproductId,SupplierID,CompanyID,promotionid)
values('iPhone 14 Pro',30990000,100,1,1,1,1);
update Products
set name='iPhone 12 Pro Max', price=25590000
where id=1

insert into Describes(DescribeId,CPU,Ram,HardDisk,GraphicsCard,Pin,MemoryStorageCapcity,Color,ScreenSize,Discriminator)
values(1,'Hexa-core',6,'128 GB','1284 x 2778 pixels',3046,'128 GB','Màu Trắng','6.7 inches','');
/* Cái DescribeId phải đổi tên thành DescribeId_productId mới đúng :) *//* Đã nhập */
update Describes
set Color='Mau Trang'
where DescribeId=1

insert into ProductImages(URL,productId)
values('https://cdn.hoanghamobile.com/i/preview/Uploads/2020/11/06/iphone-12-pro-max-3.png',1);

insert into WareHouseProducts(WareHouse_WareHouseId,Product_id)
values(1,1);

insert into ShoppingCardProducts(ShoppingCard_ShoppingId,Product_id)
values(3,1);

insert into Positions(id,name,baseSalary)
values(0,'',0);/* Chịu!!! Vị trí gì??? Không biết nhập */

insert into Feedbacks(comment,ranking,AccountConsumerId,productId)
values('Chat luong ok nha<3',5,3,1);/* ranking là 5 sao! *//* Đã nhập */

insert into PaymentMethods(PaymentName)
values('Thanh toan bang tien mat');/* Desc lỗi!!! Đã nhập trừ desc */



insert into ShippingMethods(ShippingMethodName)
values('Giao nhanh');/* Desc lỗi!!! Đã nhập trừ desc */

insert into Orders(orderedDate,totalPrice,shippingMethodId,PaymentMethodID,AddressID,DeliverStateID,AccountConsumer_id,DeliverState_DeliverId,PaymentMethod_PaymentId)
values('16-9-2022',25590000,1,1,1,0,3,0,0);
/* Chưa có DeliverStateID nên chưa nhập */
/* DeliverState_DeliverId,PaymentMethod_PaymentId với DeliverStateID,PaymentMethodID khác gì nhau??? */

insert into OrderProducts(Order_orderId,Product_id)
values(0,1);/* Chưa có Order_orderId nên chưa nhập */


