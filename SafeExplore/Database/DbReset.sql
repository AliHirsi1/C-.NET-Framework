IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
   DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	
		
	Delete from Capacities;
	Delete From Cadence;
	Delete from Makes;   
	Delete From Specials;




--declare @aliid nvarchar(128);
--select @aliid = id from AspNetUsers where email = 'ali@guild.com';

--declare @nahid nvarchar(128);
--select @nahid = id from AspNetUsers where email = 'nah@guild.com';


SET IDENTITY_INSERT Cadence ON;

INSERT INTO Cadence (CadenceID, Sequence, Program, Iteration, StartDate, EndDate, Duration, Notes) VALUES
(1, 1,   'pi-100', 'pi100-1', '2018-01-29', '2018-02-09', 10, 'null'),
(2, 2,   'pi-100', 'pi100-2', '2018-02-12', '2018-02-23', 10, 'null'),
(3, 3,   'pi-100', 'pi100-3', '2018-02-26', '2018-03-09', 10, 'null'),
(4, 4,   'pi-100', 'pi100-4', '2018-03-12', '2018-03-23', 10, 'null'),
(5, 5,   'pi-100', 'pi100-5', '2018-03-26', '2018-04-06', 10, 'customer beta'),
(6, 6,   'pi-100', 'pi100-6', '2018-04-09', '2018-04-20', 10, 'end of spring 2018'),
(7, 7,   'pi-200', 'pi200-1', '2018-04-23', '2018-05-04', 10, 'null'),
(8, 8,   'pi-200', 'pi200-2', '2018-05-07', '2018-05-18', 10, 'null'),
(9, 9,   'pi-200', 'pi200-3', '2018-05-21', '2018-06-01', 10, 'null'),
(10, 10, 'pi-200', 'pi200-4', '2018-06-04', '2018-06-15', 10, 'null'),
(11, 11, 'pi-200', 'pi200-5', '2018-06-18', '2018-06-29', 10, 'null'),
(12, 12, 'pi-200', 'pi200-6', '2018-07-02', '2018-07-20', 15, 'Summer demo '),
(13, 13, 'pi-300', 'pi300-1', '2018-07-23', '2018-08-03', 10, 'null'),
(14, 14, 'pi-300', 'pi300-2', '2018-08-06', '2018-08-17', 10, 'null'),
(15, 15, 'pi-300', 'pi300-3', '2018-08-20', '2018-08-31', 10, 'null'),
(16, 16, 'pi-300', 'pi300-4', '2018-09-03', '2018-09-14', 10, 'null'),
(17, 17, 'pi-300', 'pi300-5', '2018-09-17', '2018-09-28', 10, 'null'),
(18, 18, 'pi-300', 'pi300-6', '2018-10-01', '2018-10-19', 15, 'longer stabilization'),
(19, 19, 'pi-400', 'pi400-1', '2018-10-22', '2018-11-02', 10, 'null'),
(20, 20, 'pi-400', 'pi400-2', '2018-11-05', '2018-11-16', 10, 'null'),
(21, 21, 'pi-400', 'pi400-3', '2018-11-19', '2018-11-30', 10, 'null'),
(22, 22, 'pi-400', 'pi400-4', '2018-12-03', '2018-12-14', 10, 'null'),
(23, 23, 'pi-400', 'pi400-5', '2018-12-17', '2018-12-28', 10, 'null'),
(24, 24, 'pi-400', 'pi400-6', '2018-12-31', '2019-01-18', 15, 'Begin Spring 2019');
SET IDENTITY_INSERT Cadence OFF;



Set Identity_Insert Capacities On;
Insert into Capacities(CapacityID,TeamID, TeamName, ProgramIncrement, Iteration1, Iteration2, Iteration3,Iteration4, Iteration5, Iteration6, Total, CadenceID_CadenceID)
(1, 'AT-710', 'Agile Team 710', 'pi-100', 60, 65, 65, 50, 61, 63, 364,1),
(2, 'AT-710', 'Agile Team 710', 'pi-200', 61, 72, 73, 69, 71, 72, 418, 2),
(3, 'AT-710', 'Agile Team 710', 'pi-300', 66, 56, 61, 70, 66, 53, 372, 3),
(4, 'AT-710', 'Agile Team 710', 'pi-400', 75, 67, 57, 59, 0, 89, 347, 4),
(5, 'AT-800', '800 Agile Team', 'pi-100', 53, 73, 53, 0, 53, 84, 316, 5),
(6, 'AT-800', '800 Agile Team', 'pi-200', 43, 62, 64, 61, 61, 67, 358, 6),
(7, 'AT-800', '800 Agile Team', 'pi-300', 75, 70, 0, 53, 53, 52, 303, 7),
(8, 'AT-800', '800 Agile Team', 'pi-400', 51, 69, 73, 63, 69, 75, 400, 8),
(9, 'AT-abc1', 'Agile Team 1000 1', 'pi-100', 55, 0, 51, 62, 69, 71, 308, 9),
(10, 'AT-abc1', 'Agile Team 1000 1', 'pi-200', 62, 0, 68, 59, 0, 0, 189, 10),
(11, 'AT-abc1', 'Agile Team 1000 1', 'pi-300', 51, 64, 56, 51, 0, 0, 222, 11),
(12, 'AT-abc1', 'Agile Team 1000 1', 'pi-400', 51, 62, 75, 54, 0, 0, 242, 12);

Set Identity_insert Capacities Off;

Set Identity_insert Employee on;
INSERT INTO Employee (EmployeeID, EmployeeNumber, FirstName, LastName, City, Country, ManagerID, Email, CostCenter, Status, PrimaryTeam) VALUES
(1, 788621, 'Palmer', 'Tandy', 'CityB', 'IT', 702035, 'pt@gmail', 4, 'Employee', 'Team E'),
(2, 788919, 'Daryl', 'Detamore', 'CityC', 'TR', 813207, 'dd@gmail', 5, 'Employee', 'Team I'),
(3, 789261, 'Bonny', 'Dolphin', 'City X', 'SK', 702035, 'bd@gmail', 9, 'Employee', 'Team G'),
(4, 789338, 'Mauricio', 'Janke', 'City X', 'CH', 556715, 'mj@gmail', 9, 'Contractor', 'Team C'),
(5, 789765, 'Daina', 'Heise', 'City X', 'TL', 702035, 'dh@gmail', 9, 'Employee', 'Team J'),
(6, 790797, 'Pedro', 'Flore', 'Minneapolis', 'MO', 702035, 'pf@gmail', 1, 'Consultant', 'Team C'),
(7, 791274, 'Lorean', 'Izzo', 'City D', 'KM', 913218, 'li@gmail', 5, 'Consultant', 'Team B'),
(8, 791786, 'Darell', 'Macedo', 'CityA', 'PW', 913218, 'dm@gmail', 2, 'Employee', 'Team G'),
(9, 791996, 'Terrence', 'Morton', 'City D', 'TG', 364332, 'tm@gmail', 6, 'Contractor', 'Team F'),
(10, 792829, 'Sergio', 'Watson', 'CityA', 'MA', 702035, 'sw@gmail', 3, 'Employee', 'Team A'),
(11, 792884, 'Jamie', 'Buchanan', 'CityB', 'HN', 702035, 'jb@gmail', 9, 'Contractor', 'Team D'),
(12, 794388, 'Pamela', 'Maldonado', 'CityB', 'IQ', 300991, 'pm@gmail', 2, 'Employee', 'Team A'),
(13, 794428, 'Monica', 'Scott', 'CityC', 'SJ', 419665, 'ms@gmail', 7, 'Contractor', 'Team I'),
(14, 794909, 'Vanessa', 'Davis', 'CityC', 'DE', 364332, 'vdgmail', 6, 'Employee', 'Team D'),
(15, 795058, 'Sadie', 'Floyd', 'City D', 'YE', 300991, 'sf@gmail', 4, 'Part Time', 'Team B'),
(16, 795586, 'Olga', 'Ramos', 'CityC', 'GI', 748855, 'or@gmail', 3, 'Consultant', 'Team B'),
(17, 796469, 'Gene', 'Gregory', 'CityC', 'TT', 300991, 'gg@gmail', 8, 'Contractor', 'Team F'),
(18, 797134, 'Sonya', 'Walters', 'CityC', 'SR', 913218, 'sw@gmail', 3, 'Consultant', 'Team E')

Set Identity_insert Employee Off;

Insert Into E(Title, Message)
Values('College Graduate Program', 'Through This Car Dealarship we recognize the hardwork of recent gratuates and the need of car to get to work'),
       ('Firt Time Car Buyer','Are you ready to purchase your first vehicle and travel throughout world'),
	   ('Sign Up for Email Offers','Be the first to know about our sales special offers by signing up to receive email notifications')

END





exec DbReset



