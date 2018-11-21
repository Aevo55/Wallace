CREATE TABLE [dbo].[VersionSpecs]
(
	[vId] INT NOT NULL FOREIGN KEY REFERENCES Versions(vId),
	[sId] INT NOT NULL FOREIGN KEY REFERENCES Specifications(sId),
	[Done] bit NOT NULL,
	PRIMARY KEY (vId, sId)
)
