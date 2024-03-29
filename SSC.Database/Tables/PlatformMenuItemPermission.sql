﻿CREATE TABLE [dbo].[PlatformMenuItemPermission]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	PlatformMenuItemId INT NOT NULL,
	PermissionId INT NOT NULL,

	CreatedBy INT,
	UpdatedBy INT,
	CreatedDate SMALLDATETIME DEFAULT(GETUTCDATE()),
	UpdatedDate SMALLDATETIME DEFAULT(GETUTCDATE()),

	FOREIGN KEY (PlatformMenuItemId) REFERENCES PlatformMenuItem
)
