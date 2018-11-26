INSERT INTO Projects VALUES ('Wallace',100,'Its our cool website!', NULL);
INSERT INTO Projects VALUES ('Wand Swatters',0,'Dawson''s arguably horrible game', NULL);
INSERT INTO Projects VALUES ('A Third project',9999,'I cant really describe a project that doesn''t exist', NULL);


INSERT INTO Versions VALUES (0, 0, GETDATE());
INSERT INTO Versions VALUES (0, 1, '20181125');
INSERT INTO Versions VALUES (0, 2, '20181128');
--------------------------------------------------
INSERT INTO Versions VALUES (1, 0, '20181128');
INSERT INTO Versions VALUES (1, 1, '20990417');
--------------------------------------------------
INSERT INTO Versions VALUES (2, 0, GETDATE());


INSERT INTO Specifications VALUES('Database Client', 'Turn the tables in the SQL Database into C# objects', 0);
INSERT INTO Specifications VALUES('Database Interface', 'Bridge the gap between the Database Client and website', 0);
INSERT INTO Specifications VALUES('Good UI', 'Make the website look good', 0);
INSERT INTO Specifications VALUES('MVC Framework', 'Use the MVC Framework to structure the business logic', 0);
------------------------------------------------------------------------------------------------------------------
INSERT INTO Specifications VALUES('Consistent Collision', 'Reduce the frequency of players passing through walls', 1);
INSERT INTO Specifications VALUES('Large selection of weapons', 'Make more cool weapons for the players to use', 1);
INSERT INTO Specifications VALUES('Good UI', 'Make health and stamina bars more intuitive', 1);
--------------------------------------------------------------------------------------------------
INSERT INTO Specifications VALUES('Be a project', 'Its not a project yet. It needs to be.', 2);

INSERT INTO VersionSpecs VALUES(0, 3);

INSERT INTO VersionSpecs VALUES(1, 0);
INSERT INTO VersionSpecs VALUES(1, 3);

INSERT INTO VersionSpecs VALUES(2, 0);
INSERT INTO VersionSpecs VALUES(2, 1);
INSERT INTO VersionSpecs VALUES(2, 2);
INSERT INTO VersionSpecs VALUES(2, 3);
--------------------------------------
INSERT INTO VersionSpecs VALUES(3, 6);

INSERT INTO VersionSpecs VALUES(4, 5);
INSERT INTO VersionSpecs VALUES(4, 6);
--------------------------------------

Insert into Employees values ('Lead Developer',50000,'Dave');
Insert into Employees values ('Head Tester',55000,'Dan');
Insert into Employees values ('Sales Manager',60000,'Derek');
Insert into Employees values ('Code Monkey',35000,'Ken');
Insert into Employees values ('Mascot',44000,'Melon');
Insert into Employees values ('Tester',54700,'Jeremy');
Insert into Employees values ('Code testing man',100000,'Jim');
Insert into Employees values ('Salesperson', 20000,'Ronald');
Insert into Employees values ('Selling Man',12500,'Arnold');
Insert into Employees values ('Sells Persons',33400,'Benold');

Insert into Teams values ('Dev Team','Team that writes code', 0);
Insert into Teams values ('SQA Team','Team that reads code', 1);
Insert into Teams values ('Sales','Team that makes money', 2);

Insert into TeamMembers values (0,0);
Insert into TeamMembers values (1,1);
Insert into TeamMembers values (2,2);

Insert into TeamMembers values (3,0);
Insert into TeamMembers values (4,0);

Insert into TeamMembers values (5,1);
Insert into TeamMembers values (6,1);

Insert into TeamMembers values (7,2);
Insert into TeamMembers values (8,2);
Insert into TeamMembers values (9,2);


delete  from Employees;
delete from TeamMembers;
delete from Teams;
delete from ProjectClients;
delete from Versions;
delete from VersionTeams;
delete from VersionSpecs;
delete from Experience;
delete from Clients;
delete from Projects;
delete from Specifications;

DBCC CHECKIDENT ('Employees', RESEED, -1);
DBCC CHECKIDENT ('Teams', RESEED, -1);
DBCC CHECKIDENT ('Versions', RESEED, -1);
DBCC CHECKIDENT ('Projects', RESEED, -1);
DBCC CHECKIDENT ('Specifications', RESEED, -1);