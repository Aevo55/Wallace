CREATE TABLE [dbo].[Projects]
(
	[pId] INT NOT NULL PRIMARY KEY,
	[pName] varchar(MAX) NOT NULL,
	[pBudget] INT NOT NULL,
	[pDesc] varchar(MAX) NOT NULL,
	[Manager] INT NULL FOREIGN KEY REFERENCES Employees(eId)
)
