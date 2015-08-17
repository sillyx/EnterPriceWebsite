create database sniper
go
use sniper
go

--����
create table News
(
	Id char(36) primary key not null,
	Cont text not null,
	CreateTime datetime,
	Title nvarchar(100) not null
)
--����
create table [Service]
(
	Id char(36) primary key not null,
	Cont text not null
)
--�������
create table Solution
(
	Id char(36) primary key not null,
	Cont text not null
)
--��������
create table AboutUs
(
	Id char(36) primary key not null,
	Cont text not null
)
--��Ʒ����
create table Category
(
	Id char(36) primary key not null,
	Name nvarchar(100) not null
)
--��Ʒ
create table Product
(
	Id char(36) primary key not null,
	Name nvarchar(100) not null,
	[Description] nvarchar(1000) not null,
	ImgSrc varchar(200) not null,
	CategoryId char(36) foreign key references Category(Id), 
	CreateTime datetime,
)
--��ƷͼƬ
create table ImageList
(
	Id char(36) primary Key not null,
	ProductId char(36) foreign key references Product(Id),
	ImgSrc varchar(200)
)