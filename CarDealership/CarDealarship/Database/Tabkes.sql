USE CarDealarship
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Employees')
	DROP TABLE Employees
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Users')
	DROP TABLE Users
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Sales')
	DROP TABLE Sales
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicles')
	DROP TABLE Vehicles
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Models')
	DROP TABLE Models
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Makes')
	DROP TABLE Makes
GO



IF EXISTS(SELECT * FROM sys.tables WHERE name='Customers')
	DROP TABLE Customers
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='States')
	DROP TABLE States
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='City')
	DROP TABLE CIty
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='Departments')
	DROP TABLE Departments
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
	DROP TABLE Specials
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='ContactUs')
	DROP TABLE ContactUs
GO

CREATE TABLE Users (
	EmployeeId int identity(1,1) not null primary key,
	FirsrName varchar(30),
	LastName  varchar(30),
	Email varchar(30),
	Password varchar(30),
	Role varchar(30)		
)

CREATE TABLE City (
	CityId int identity(1,1) not null primary key,
	CityName nvarchar(max) not null		
)

CREATE TABLE States (
	StateId int identity(1,1) not null primary key,
	StateAbbreviation char(2) not null,
	StateName varchar(max)not null		
)

CREATE TABLE Customers (
	CustomerId int identity(1,1) not null primary key,
	FirsrName varchar(30),
	LastName  varchar(30),
	Email varchar(30),
	Street1 nvarchar(max),
	Street2 nvarchar(max),
	ZipCode int not null,
	Cityid Int not null foreign key references City(CityId),
	StateId int not null foreign key references States(StateId)

	)

CREATE TABLE Departments (
	DepartmentId int identity(1,1) not null primary key,
	DepartmentName nvarchar(max),		
)




CREATE TABLE Employees (
	EmployeeId int identity(1,1) not null primary key,
	FirstName varchar(30) not null,
	LastName varchar(30) not null,
	Email varchar(30) not null,		
	DepartmentId int foreign key references Departments(DepartmentId)	
)


CREATE TABLE Makes (
	MakesId int identity(1,1) not null primary key,
	MakeName nvarchar(128) not null	
)

CREATE TABLE Models (
	ModelId int identity(1,1) not null primary key,
	ModelType nvarchar(128) not null,
	MakesId int not null foreign key references Makes(MakesId)	
)



CREATE TABLE Specials (
	SpecialId int identity(1,1) not null primary key,
	Title nvarchar(128) not null,
	Message nvarchar(max)
)

CREATE TABLE Vehicles (
	VehicleId int identity(1,1) not null primary key,
	MakesId int not null foreign key references Makes(MakesId),
	ModelId int not null foreign key references Models(ModelId),
	Interior varchar(30) not null,
	VehicleType varchar(30) not null,
	Year int not null,
	Color nvarchar(30),
	Mileage decimal not null,
	VinNumber nvarchar(max) not null,
	ImageFileName varchar(50),
	MSRP money null,
	Price Money not null,
	Transmission nvarchar(30) not null,
	IsFeatured bit not null,
	IsNew bit not null	
)

CREATE TABLE Sales (
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId) NOT NULL,
	UserId nvarchar(128) FOREIGN KEY REFERENCES [AspNetUsers](Id)  not null,
	VehicleId INT FOREIGN KEY REFERENCES Vehicles(VehicleId) NOT NULL,
	[Date] DateTime2 NOT NULL,
	PurchasePrice MONEY NOT NULL
	
)













