﻿CREATE TABLE [dbo].[EmpExp]
(
	[eId] INT NOT NULL FOREIGN KEY REFERENCES Employees(eId) ON DELETE NO ACTION,
	[xId] INT NOT NULL FOREIGN KEY REFERENCES Experience(xId) ON DELETE NO ACTION,
	PRIMARY KEY (eId, xId)
)
