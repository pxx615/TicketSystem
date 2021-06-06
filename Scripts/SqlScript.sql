--Author: Patrick Kan

--Create database needed for the ticket system.
CREATE DATABASE TicketSystemDB;

USE [TicketSystemDB]
GO

--Create 'Department' table
CREATE TABLE Department (
    DepartmentId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    DepartmentName varchar(100) NOT NULL
); 

--Create 'Employee' table
CREATE TABLE Employee (
    EmployeeId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    EmployeeName varchar(100) NOT NULL,
	DepartmentId int FOREIGN KEY REFERENCES Department(DepartmentId) NOT NULL
); 

--Create 'Ticket' table
CREATE TABLE Ticket (
    TicketId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ProjectName varchar(100) NOT NULL,
	DepartmentId int FOREIGN KEY REFERENCES Department(DepartmentId) NOT NULL,
	EmployeeId int FOREIGN KEY REFERENCES Employee(EmployeeId) NOT NULL,
	[Description] varchar(200) NOT NULL,
	[DateTime] datetime NOT NULL
); 

--Populate data
INSERT INTO [dbo].[Department]
           ([DepartmentName])
     VALUES
			('Branch of Extranet Implementation'),
			('Branch of Intranet Computer Maintenance and E-Commerce PC Programming'),
			('Bureau of Business-Oriented PC Backup and Wireless Telecommunications Control'),
			('Database Programming Branch'),
			('Division of Application Security'),
			('Division of Telecommunications Extranet Development'),
			('Extranet Multimedia Connectivity and Security Division'),
			('Hardware Backup Department'),
			('Mainframe PC Development and Practical Source Code Acquisition Team'),
			('Multimedia Troubleshooting and Maintenance Team'),
			('Network Maintenance and Multimedia Implementation Committee'),
			('Office of Statistical Data Connectivity'),
			('PC Maintenance Department'),
			('Software Technology and Networking Department'),
			('Wireless Extranet Backup Team')
GO

--Populate data
INSERT INTO [dbo].[Employee]
           ([EmployeeName]
           ,[DepartmentId])
     VALUES
			('Roma Marcell',6),
			('Hugo Wess',7),
			('Kelvin Lahr',1),
			('Janelle Newberg',6),
			('Mellie Lombard',2),
			('Reita Abshire',15),
			('Dalila Vickrey',4),
			('Idella Dallman',1),
			('Farah Eldridge',8),
			('Lana Montes',8),
			('Leola Thornburg',7),
			('Marcelo Paris',4),
			('Ione Tomlin',10),
			('Hilario Masterson',10),
			('Janice Skipper',15),
			('Keren Gillespi',12),
			('Linh Leitzel',6),
			('Rosalia Ayoub',5),
			('Shawna Hood',2),
			('Wilfredo Stumpf',11),
			('Alexandra Brendle',12),
			('Luciano Riddell',9),
			('Boyce Perales',11),
			('Alissa Perlman',6),
			('Latoyia Kremer',11),
			('Tawna Blackmore',15),
			('Claudine Valderrama',8),
			('Katheryn Lepak',11),
			('Sage Bow',10),
			('Altha Rudisill',8),
			('Olympia Vien',5),
			('Olene Pyron',13),
			('Delorse Searle',7),
			('Greta Quigg',3),
			('Kenneth Bowie',2),
			('Colton Kranz',8),
			('Kasie Barclay',10),
			('Thresa Levins',7),
			('Diego Hasbrouck',14),
			('Tomoko Gale',4)
GO

--Populate data
INSERT INTO [dbo].[Ticket]
           ([ProjectName]
           ,[DepartmentId]
           ,[EmployeeId]
           ,[Description]
           ,[DateTime])
     VALUES
			('15 Five',4,7,'15 laptops went missing','2021-06-05 00:14:36.937'),
			('Associations Now',1,3,'Printer not working.','2021-06-05 00:15:27.700'),
			('Hex Clan',4,12,'Update employees information','2021-06-05 00:16:26.890'),
			('Box of Crayons',10,13,'broken keyboards','2021-06-05 00:17:31.610'),
			('Next Gala',10,14,'Broken mice','2021-06-05 00:18:41.123'),
			('Annual Award Show',6,1,'Mice went missing','2021-06-05 00:19:27.687'),
			('A Triumph of Softwares',1,3,'We need extra equipment','2021-06-05 00:20:11.993'),
			('Social Geek Made',7,33,'Test ticket. Please ignore.','2021-06-05 00:23:19.557'),
			('Coding Region',2,35,'Everything went wrong','2021-06-05 00:29:52.913'),
			('Fast Ball',4,12,'Extra equipment needed for new coops','2021-06-05 00:31:41.440'),
			('The Social Experiment',5,31,'Need USB cables.','2021-06-05 00:32:05.830'),
			('Project Explained',1,3,'Internet is not working on my computer.','2021-06-05 00:33:33.153'),
			('Ceremony Worthy of time',10,29,'some problem occured','2021-06-05 00:35:44.973'),
			('15 Five',2,19,'Missing keyboards.','2021-06-05 13:04:14.847'),
			('15 Five',10,14,'Missing mice.','2021-06-05 13:04:23.983'),
			('15 Five',14,39,'Computer wont turn on. Help.','2021-06-05 13:04:47.880'),
			('Box of Crayons',11,25,'Need more crayons, from IT support.','2021-06-05 13:05:29.493'),
			('Box of Crayons',12,16,'Crayons are stuck in the router.','2021-06-05 13:05:47.200'),
			('Coding Region',3,34,'My code is not working. Maybe its the internet? Please help.','2021-06-05 13:06:14.080'),
			('Fast Ball',2,35,'My internet is too fast.','2021-06-05 13:06:29.420'),
			('Annual Award Show',4,12,'need more laptops.','2021-06-05 13:06:51.637'),
			('Project Explained',3,34,'We need a projector.','2021-06-05 13:07:08.623'),
			('Project Explained',5,18,'my internet is slow.','2021-06-05 15:47:29.683'),
			('15 Five',7,2,'Something happened.','2021-06-05 18:06:54.410'),
			('15 Five',5,18,'This is just a test.','2021-06-05 21:38:02.183'),
			('project 1',4,40,'something something','2021-06-05 21:53:47.430')
GO