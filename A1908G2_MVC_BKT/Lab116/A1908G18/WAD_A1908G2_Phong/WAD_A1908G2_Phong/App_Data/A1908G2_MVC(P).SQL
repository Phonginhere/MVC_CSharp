﻿USE master
GO

IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'ProductManagement')
 DROP DATABASE ProductManagement
GO

CREATE DATABASE ProductManagement
GO

USE ProductManagement
GO

/* CƠ SỞ DỮ LIỆU CHO ỨNG DỤNG WEB ASP.NET MVC QUẢN LÝ SẢN PHẨM (PRODUCT MANAGEMENT) */

/* bảng LOẠI SẢN PHẨM */
IF OBJECT_ID('dbo.Category', 'U') IS NOT NULL
  DROP TABLE dbo.Category
CREATE TABLE Category
(
	CategoryId INT PRIMARY KEY IDENTITY (1,1),	/* định danh cục bộ */
	CategoryName NVARCHAR(50) NOT NULL	/* Loại Sản Phẩm */
)
ON [PRIMARY]
GO


/* bảng SẢN PHẨM */
IF OBJECT_ID('dbo.Product', 'U') IS NOT NULL
  DROP TABLE dbo.Product
CREATE TABLE Product
(
	ProductId INT PRIMARY KEY IDENTITY (1,1),
	Name NVARCHAR(50), /* Tên Sản Phẩm */
	Price MONEY, /* Đơn Giá sản phẩm (tính theo đô) */
	Quantity INT, /* Số Lượng sản phẩm */
	ReleaseDate datetime, /* Ngày Phát Hành sản phẩm */
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Category(CategoryId) /* khóa ngoại tham chiếu sang bảng loại sản phẩm */
)

INSERT INTO Category(CategoryName) VALUES 
 ('Smartphone'),
 ('Tablet'),
 ('Laptop')
GO

INSERT INTO Product(Name, Price, Quantity, ReleaseDate, CategoryId) VALUES 
 ('iPhone',        399,  3,  '2007-06-29', 1),
 ('Galaxy Note',   355,  3,  '2011-10-14', 1),
 ('xPeria',        319,  3,  '2015-09-01', 1),
 ('iPad',          699,  10, '2010-07-01', 2),
 ('Galaxy Tab',    655,  7,  '2013-07-07', 2),
 ('xPeria Tablet', 619,  3,  '2013-10-03', 2),
 ('iMac',          1099, 3,  '2016-09-10', 3),
 ('ATIV Book',     1055, 5,  '2011-03-04', 3),
 ('Vaio',          1019, 5,  '2002-12-14', 3),
 ('Lumia',         315,  5,  '2012-04-14', 1),
 ('Oppo',          415,  5,  '2015-12-14', 1),
 ('Asus ZendPad',  125,  5,  '2015-12-14', 2),
 ('Dell Vostro',   751,  5,  '2015-12-14', 3),
 ('HP Pavillion',  832,  5,  '2015-12-14', 3),
 ('Surface Pro',  1790,  5,  '2015-12-14', 2)
GO

SELECT * FROM Category
SELECT * FROM Product