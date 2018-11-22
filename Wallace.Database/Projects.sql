CREATE TABLE [dbo].[Projects]
(
	[pId] INT NOT NULL PRIMARY KEY,
	[pName] varchar(50) NOT NULL,
	[pBudget] INT NOT NULL,
	[pDesc] varchar(200) NOT NULL,
	[Manager] INT NULL FOREIGN KEY REFERENCES Employees(eId)
)
