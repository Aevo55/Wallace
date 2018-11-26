﻿CREATE TABLE [dbo].[Specifications]
(
	[sId] INT NOT NULL PRIMARY KEY IDENTITY(0,1),
	[sName] VARCHAR(MAX) NOT NULL,
	[sDesc] VARCHAR(MAX) NULL,
	[pId] INT NOT NULL FOREIGN KEY REFERENCES Projects(pId) ON DELETE NO ACTION
)
