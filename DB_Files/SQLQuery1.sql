--CREATE DATABASE InventoryManagementSystem
USE InventoryManagementSystem

CREATE TABLE UserLogin(
Id INT IDENTITY(1,1) PRIMARY KEY,
UserId VARCHAR(15) NOT NULL,
UserPassword VARCHAR(15) NOT NULL,
UserName VARCHAR(50) NOT NULL,
Active VARCHAR(1) DEFAULT 'Y'
)

--INSERT INTO UserLogin (UserId,UserPassword,UserName) VALUES ('John@gmail.com','John@123','John Doe'),
--('Abhay@gmail.com','Abhay@123','Abhay Mati')
SELECT * FROM UserLogin

CREATE TABLE ItemMaster(
Id INT IDENTITY(1,1) PRIMARY KEY,
ItemCode VARCHAR(10) UNIQUE NOT NULL,
ItemName VARCHAR(30) NOT NULL,
UoM VARCHAR(8) NOT NULL,  --Unit of Measurement
Active VARCHAR(1) DEFAULT 'Y',
UserCode INT,
[DATE] DATETIME,
CONSTRAINT Fk_Item_User FOREIGN KEY (UserCode) REFERENCES UserLogin(Id)
)

CREATE TABLE SupplierMaster(
Id INT IDENTITY(1,1) PRIMARY KEY,
SupplierCode VARCHAR(10) UNIQUE NOT NULL,
SupplierName VARCHAR(30) NOT NULL,
Address VARCHAR(150) NOT NULL,
Phone VARCHAR(15) NOT NULL,
Active VARCHAR(1) DEFAULT 'Y',
UserCode INT,
[DATE] DATETIME ,
CONSTRAINT Fk_Supplier_User FOREIGN KEY (UserCode) REFERENCES UserLogin(Id)
) 

CREATE TABLE GoodsReceiptNote(
Id INT IDENTITY(1,1) PRIMARY KEY,
GRNDate DATETIME,
SupplierCode VARCHAR(10),
ItemCode VARCHAR(10),
ItemQuantity DECIMAL(7,2),
UserCode INT,
[DATE] DATETIME ,
CONSTRAINT Fk_Goods_Supplier FOREIGN KEY(SupplierCode) REFERENCES SupplierMaster(SupplierCode),
CONSTRAINT Fk_Goods_Item FOREIGN KEY(ItemCode) REFERENCES ItemMaster(ItemCode),
CONSTRAINT Fk_GoodsReceipt_User FOREIGN KEY (UserCode) REFERENCES UserLogin(Id)
)

CREATE TABLE StockOut(
Id INT IDENTITY(1,1) PRIMARY KEY,
ItemCode VARCHAR(10),
Quantity DECIMAL(7,2),
UserCode INT,
[DATE] DATETIME,
CONSTRAINT Fk_Stock_Item FOREIGN KEY(ItemCode) REFERENCES ItemMaster(ItemCode)
)