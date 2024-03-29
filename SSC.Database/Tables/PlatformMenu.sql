﻿CREATE TABLE [dbo].[PlatformMenu]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Code NVARCHAR(100) NOT NULL,
	TranslationKey NVARCHAR(500) NOT NULL,
	MenuOrder INT NOT NULL,

	CreatedBy INT,
	UpdatedBy INT,
	CreatedDate SMALLDATETIME DEFAULT(GETUTCDATE()),
	UpdatedDate SMALLDATETIME DEFAULT(GETUTCDATE())
)
