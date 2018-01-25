IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
   DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	
	Delete From Vehicles;	
	Delete from Models;
	Delete from Makes;   
	Delete From Specials;


SET IDENTITY_INSERT Makes ON;

declare @aliid nvarchar(128);
select @aliid = id from AspNetUsers where email = 'ali@guild.com';

declare @nahid nvarchar(128);
select @nahid = id from AspNetUsers where email = 'nah@guild.com';




Insert Into Makes(MakeId, MakeName, userId, Date)
values(1,'Chevy', @aliid, 12/4/2017),

      (2, 'BMW', @aliid, 12/4/2017),
	  (3, 'Toyota', @aliid, 12/4/2017),
	  (4, 'Nissan', @nahid, 12/4/2017),
	  (5, 'Chevy' , @aliid, 12/4/2017),
	  (6, 'Tesla' , @nahid , 12/4/2017),
	  (7, 'Audi' , @aliid , 12/4/2017),
	  (8, 'Jeep' , @nahid , 12/4/2017),
	  (9, 'Ford' , @aliid , 12/4/2017)

SET IDENTITY_INSERT Makes OFF;



Set Identity_Insert Models On;
Insert into Models(ModelId,ModelName, MakeId, Date, UserId)
Values(1, 'Camero', 1 , 12/4/2017,  @nahid),
      (2, 'i8',2 , 12/4/2017, @aliid),
	  (3, 'Rav4',3 , 12/4/2017,  @nahid),
	  (4, 'Altima',4 , 12/4/2017, @nahid),
	  (5, 'SS454',5 , 12/4/2017, @nahid),
	  (6, '3',6,  12/4/2017, @aliid),
	  (7, 'F103',7 , 12/4/2017, @aliid),
	  (8, 'Cherokee',8 , 12/4/2017, @aliid),	  
	  (9, 'Escape', 9 , 12/4/2017, @aliid)

Set Identity_insert Models Off;

Set Identity_insert Vehicles on;
Insert Into Vehicles(vehicleId, MakeId_MakeId, ModelId_ModelId, Interior, VehicleType, Year, Color, Mileage, VinNumber, ImageFileName, MSRP, SalesPrice, Transmission, IsFeatured, IsNew)
Values(1, 1, 1, 'White', 'Convertible', 2012, 'Silver', 10020, '1XP7DU9X48D704313', 'Images/camero.jpg', 5000, 3000, 'Manual', 0, 0),
      (2, 2, 2, 'Black', 'Convertible', 2018, 'White', 10, '1XP7DU9X48D705213', 'Images/i8.jpg', 55000, 52000, 'Automatic', 1, 1),
	  (3, 3, 3, 'Fabric', 'SUV',2017, 'Red', 250, '1XP7DU9X48D705213', 'Images/Rav4.jpg', 22000, 19000, 'Automatic', 1, 1),
	  (4, 4, 4, 'Nylon', 'SUV', 2016, 'Red', 5600, '1XP7DU9X48X895213', 'Images/nissan.jpg', 15000, 12000, 'Automatic', 1, 1),
	  (5, 5, 5, 'Black', 'Coupe', 2015, 'Red', 66000, '1XP7DU9X32X895213', 'Images/SS454.JPG', 17000, 16500, 'Automatic' , 1, 1),
	  (6, 6, 6, 'Black', 'Sedan', 2014, 'Red', 45000, '1XP7DU9X14Y895213', 'Images/telsa3.jpg', 9000, 6500,'Automatic', 1, 1),
	  (7, 7, 7, 'Black', 'Coupe', 2012, 'Silver', 55000, '1XP7DU9X14Y895213', 'Images/f103.jpg', 17000, 16560, 'Automatic', 1, 1),
	  (8, 8, 8, 'Black', 'SUV', 2018, 'Black', 10, '1XP7DU9X14Y895213', 'Images/cherokee.jpg', 39000, 37250, 'Automatic', 1, 1),
	  (9, 9, 9, 'Black', 'SUV', 2018, 'White', 10, '1XP7CG9X14Y895213', 'Images/ford.jpg', 33000, 31000, 'Automatic', 1, 1)
Set Identity_insert Vehicles off;


Insert Into Specials(Title, Message)
Values('College Graduate Program', 'Through This Car Dealarship we recognize the hardwork of recent gratuates and the need of car to get to work'),
       ('Firt Time Car Buyer','Are you ready to purchase your first vehicle and travel throughout world'),
	   ('Sign Up for Email Offers','Be the first to know about our sales special offers by signing up to receive email notifications')

END





exec DbReset



