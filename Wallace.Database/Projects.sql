CREATE TABLE [dbo].[Projects]
(
	[pId] INT NOT NULL PRIMARY KEY IDENTITY(0,1),
	[pName] varchar(MAX) NOT NULL,
	[pBudget] INT NOT NULL,
	[pDesc] varchar(MAX) NOT NULL,
	[Manager] INT NULL FOREIGN KEY REFERENCES Employees(eId) ON DELETE SET NULL
)
