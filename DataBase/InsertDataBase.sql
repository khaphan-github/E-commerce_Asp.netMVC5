﻿insert into Account(username,password,email,phone,address,dateOfBirth,sex,avatar,Discriminator)
values('acc','28c8edde3d61a0411511d3b1866f0636','a@gmail.com','0123456789','tphcm','1/1/1999','Nam','https://kenh14cdn.com/2017/screen-shot-2017-10-14-at-41652-pm-1507972625700.png', 
'NULL');/*thiếu ngày tạo tài khoản*/  /* pass: 1 */
insert into Account(username,password,email,phone,address,dateOfBirth,sex,avatar,Discriminator)
values('admin','665f644e43731ff9db3d341da5c827e1','b@gmail.com','0987654321','Ha Noi','1/1/2000','Nu','https://nhakhoagiadinh.com.vn/hinh-anh-nguoi-cute/imager_6_77285_700.jpg', 
'NULL');  /* pass: 2 */
update Account
set salary=5000
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

insert into ShoppingCards(ShoppingId,NumberOfItems,IsEmpty,CreatedDate)/*0 rỗng 1 ngược lại*/
values(3,4,1,'1/1/2021');/* ShoppingId phải trùng với id của Account mới nhập được!!! */

insert into WareHouses(WareHouseName,Status)
values('Nha Kho smartphone','1 nam');/* Status này là hợp tác với nhà kho được 1 năm :) */

insert into Suppliers(SupplierName,Phone,Email)
values('Apple','0147258369',31);/* Ủa ủa mail là kiểu INT hả??? */

insert into Companies(CompanyName,Phone,Email,ActiveType)
values('ABC','19001080','ABC@gmail.com','2 nam');/* ActiviType??? */

insert into Promotions(name,desc,percentPromotion,AdminAccountId,accountAdmin_id)
values('Khuyen mai 1','',10,1,1);/* AdminAccountId với accountAdmin_id khác gì nhau??? */ /* Chưa nhập vào vì 2 cái kia */
/* desc là gì??? */

insert into Products(name,price,quantity,TypeproductId,SupplierID,CompanyID,promotionid)
values('',0,0,1,1,1,0);/* Chưa có promotionid nên chưa nhập */

insert into Describes(DescribeId,Description,CPU,Ram,HardDisk,GraphicsCard,Pin,ModelName,Pin1,CellularTechnolory,MemoryStorageCapcity,Color,ScreenSize,Discriminator)
values(1,'','',0,'','',0,'',0,'','','','','');

insert into ProductImages(URL,productId)
values('',0);/* Chưa có productId nên chưa nhập */

insert into WareHouseProducts(WareHouse_WareHouseId,Product_id)
values(1,0);/* Chưa có productId nên chưa nhập */

insert into ShoppingCardProducts(ShoppingCard_ShoppingId,Product_id)
values(3,0);/* Chưa có productId nên chưa nhập */

insert into Positions(id,name,baseSalary)
values(0,'',0);/* Chịu!!! Vị trí gì??? */

insert into Feedbacks(comment,ranking,AccountConsumerId,productId)
values('Chat luong ok nha<3',5,3,0);/* Chưa có productId nên chưa nhập */  /* ranking là 5 sao! */

insert into PaymentMethods(PaymentName,Desc)
values('','');/* Desc là gì??? */

insert into DeliverStates(DeliverName,OrderNumber)
values('',0);/* Không biết nhập kiểu gì :) */

insert into ShippingMethods(ShippingMethodName,Desc)
values('Giao nhanh','');/* Desc là gì??? */

insert into Orders(orderedDate,totalPrice,shippingMethodId,PaymentMethodID,AddressID,DeliverStateID,AccountConsumer_id,DeliverState_DeliverId,PaymentMethod_PaymentId)
values('16-9-2022',0,0,0,1,0,3,0,0);/* Chưa có tổng giá *//* Chưa có shippingMethodId,PaymentMethodID,DeliverStateID nên chưa nhập */
/* DeliverState_DeliverId,PaymentMethod_PaymentId với DeliverStateID,PaymentMethodID khác gì nhau??? */

insert into OrderProducts(Order_orderId,Product_id)
values(0,0);/* Chưa có Order_orderId,Product_id nên chưa nhập */

insert into Categories(CategoryName)
values('');/* Không biết điền!!! */

insert into TypeProducts(typeName,CategogyId,category_CategoryId)
values('',0,0);/* CategogyId,category_CategoryId khác gì nhau??? */