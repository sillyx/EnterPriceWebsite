create database sniper
go
use sniper
go

--新闻
create table News
(
	Id char(36) primary key not null,
	Cont text not null,
	CreateTime datetime,
	Title nvarchar(100) not null
)
--服务
create table [Service]
(
	Id char(36) primary key not null,
	Cont text not null
)
--解决方案
create table Solution
(
	Id char(36) primary key not null,
	Cont text not null
)
--关于我们
create table AboutUs
(
	Id char(36) primary key not null,
	Cont text not null
)
--产品分类
create table Category
(
	Id char(36) primary key not null,
	Name nvarchar(100) not null
)
--产品
create table Product
(
	Id char(36) primary key not null,
	Name nvarchar(100) not null,
	[Description] nvarchar(1000) not null,
	ImgSrc varchar(200) not null,
	CategoryId char(36) foreign key references Category(Id), 
	CreateTime datetime,
)
--产品图片
create table ImageList
(
	Id char(36) primary Key not null,
	ProductId char(36) foreign key references Product(Id),
	ImgSrc varchar(200)
)