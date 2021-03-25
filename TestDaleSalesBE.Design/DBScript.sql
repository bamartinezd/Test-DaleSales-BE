/*

	drop database Test_Dale_Sales

	Database definition
*/

create database Test_Dale_Sales
go

use Test_Dale_Sales
go

if OBJECT_ID('Product') IS NOT NULL
drop table Product
create table Product(
	ID int identity primary key,
	ProductName varchar(30),
	UnitValue money
)
go

if OBJECT_ID('Client') IS NOT NULL
drop table Client
create table Client(
	ID bigint primary key,
	FirstName varchar(30),
	LastName varchar(30),
	Phone bigint,
	Email varchar(30)
)
go

if OBJECT_ID('Sale') IS NOT NULL
drop table Sale
create table Sale(
	ID int identity primary key,
	ClientID bigint foreign key references Client(ID),
	TotalValue money,
	SaleDate datetime
)
go

if OBJECT_ID('SaleDetail') IS NOT NULL
drop table SaleDetail
create table SaleDetail(
	ID int identity primary key,
	SaleID int foreign key references Sale(ID),
	ProductID int foreign key references Product(ID),
	Quantity int
)
go

/*
	test data inserts
*/

insert into Product(ProductName,UnitValue)values
('Escoba', 4500),
('Trapero', 5000)

insert into Client (ID,FirstName,LastName,Phone,Email)values
(1023931285, 'Brayan', 'Martinez Delgado', 3204796677, 'alejandromardelg@gmail.com'),
(1023930293, 'Alejandro', 'Martinez Delgado', 3204790011, 'alejasssssssselg@gmail.com'),
(2594931285, 'Andres', 'Collazos Certuche', 3204799283, 'mardelg@gmail.com'),
(1234531285, 'Cesar', 'Sierra', 3204567877, 'delg@gmail.com')


insert into Sale(ClientID,TotalValue,SaleDate)values
(1234531285,15000,GETDATE()),
(2594931285,15000,GETDATE())

insert into SaleDetail(SaleID,ProductID,Quantity)values
(1,2,3),(2,2,3)

select * from Product
select * from Client
select * from Sale
select * from SaleDetail
