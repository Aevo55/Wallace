CREATE TABLE [dbo].[VersionSpecs]
(
	[vId] INT NOT NULL FOREIGN KEY REFERENCES Versions(vId),
	[sId] INT NOT NULL FOREIGN KEY REFERENCES Specifications(sId),
	PRIMARY KEY (vId, sId)
)
