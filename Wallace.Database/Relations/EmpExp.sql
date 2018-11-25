﻿CREATE TABLE [dbo].[EmpExp]
(
	[eId] INT NOT NULL FOREIGN KEY REFERENCES Employees(eId) ON DELETE CASCADE,
	[xId] INT NOT NULL FOREIGN KEY REFERENCES Experience(xId) ON DELETE CASCADE,
	PRIMARY KEY (eId, xId)
)
