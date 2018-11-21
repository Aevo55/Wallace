﻿CREATE TABLE [dbo].[Versions]
(
	[vId] INT NOT NULL PRIMARY KEY,
	[pId] INT NOT NULL FOREIGN KEY REFERENCES Projects(pId),
	[vNum] INT NOT NULL,
	[ReleaseDate] DATE NOT NULL DEFAULT(GETDATE()),
	UNIQUE (pId, vNum)
)
