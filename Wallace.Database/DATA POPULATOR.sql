INSERT INTO Projects VALUES (0,'Wallace',100,'Its our cool website!', NULL);
INSERT INTO Projects VALUES (1,'Wand Swatters',0,'Dawson''s arguably horrible game', NULL);
INSERT INTO Projects VALUES (2,'A Third project',9999,'I cant really describe a project that doesn''t exist', NULL);


INSERT INTO Versions VALUES (0, 0, 0, GETDATE());
INSERT INTO Versions VALUES (1, 0, 1, '20181125');
INSERT INTO Versions VALUES (2, 0, 2, '20181128');
--------------------------------------------------
INSERT INTO Versions VALUES (3, 1, 0, '20181128');
INSERT INTO Versions VALUES (4, 1, 1, '20990417');
--------------------------------------------------
INSERT INTO Versions VALUES (5, 2, 0, GETDATE());


INSERT INTO Specifications VALUES(0, 'Database Client', 'Turn the tables in the SQL Database into C# objects', 0);
INSERT INTO Specifications VALUES(1, 'Database Interface', 'Bridge the gap between the Database Client and website', 0);
INSERT INTO Specifications VALUES(2, 'Good UI', 'Make the website look good', 0);
INSERT INTO Specifications VALUES(3, 'MVC Framework', 'Use the MVC Framework to structure the business logic', 0);
------------------------------------------------------------------------------------------------------------------
INSERT INTO Specifications VALUES(4, 'Consistent Collision', 'Reduce the frequency of players passing through walls', 1);
INSERT INTO Specifications VALUES(5, 'Large selection of weapons', 'Make more cool weapons for the players to use', 1);
INSERT INTO Specifications VALUES(6, 'Good UI', 'Make health and stamina bars more intuitive', 1);
--------------------------------------------------------------------------------------------------
INSERT INTO Specifications VALUES(7, 'Be a project', 'Its not a project yet. It needs to be.', 2);


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

Insert into Employees values (0, 50000,'Dave');
Insert into Employees values (1, 55000,'Dan');
Insert into Employees values (2, 60000,'Derek');
Insert into Employees values (3, 35000,'Ken');
Insert into Employees values (4, 44000,'Melon');
Insert into Employees values (5, 54700,'Jeremy');
Insert into Employees values (6, 100000,'Jim');
Insert into Employees values (7, 20000,'Ronald');
Insert into Employees values (8, 12500,'Arnold');
Insert into Employees values (9, 33400,'Benold');

Insert into Teams values (0,'Dev Team','Team that writes code', 0);
Insert into Teams values (1,'SQA Team','Team that reads code', 1);
Insert into Teams values (2,'Sales','Team that makes money', 2);

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