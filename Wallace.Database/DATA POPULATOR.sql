INSERT INTO Projects VALUES (0,'Wallace',100,'Its our cool website!');
INSERT INTO Projects VALUES (1,'Wand Swatters',0,'Dawson''s arguably horrible game');
INSERT INTO Projects VALUES (2,'A Third project',9999,'I cant really describe a project that doesn''t exist');


INSERT INTO Versions VALUES (0, 0, 0, GETDATE());
INSERT INTO Versions VALUES (1, 0, 1, 25-11-2018);
INSERT INTO Versions VALUES (2, 0, 2, 28-11-2018);

INSERT INTO Versions VALUES (3, 1, 0, 28-11-2018);
INSERT INTO Versions VALUES (4, 1, 1, 17-04-2099);

INSERT INTO Versions VALUES (5, 2, 0, GETDATE());



INSERT INTO Specifications VALUES(0, 'Database Client', 'Turn the tables in the SQL Database into C# objects', 0);
INSERT INTO Specifications VALUES(1, 'Database Interface', 'Bridge the gap between the Database Client and website', 0);
INSERT INTO Specifications VALUES(2, 'Good UI', 'Make the website look good', 0);
INSERT INTO Specifications VALUES(3, 'MVC Framework', 'Use the MVC Framework to structure the business logic', 0);

INSERT INTO Specifications VALUES(4, 'Consistent Collision', 'Reduce the frequency of players passing through walls', 1);
INSERT INTO Specifications VALUES(5, 'Large selection of weapons', 'Make more cool weapons for the players to use', 1);
INSERT INTO Specifications VALUES(6, 'Good UI', 'Make health and stamina bars more intuitive', 1);

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