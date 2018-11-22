﻿CREATE TABLE [dbo].[VersionTeams]
(
	[tId] INT NOT NULL FOREIGN KEY REFERENCES Employees(eId),
	[vId] INT NOT NULL FOREIGN KEY REFERENCES Versions(vId),
	PRIMARY KEY (tId, vId)
)
