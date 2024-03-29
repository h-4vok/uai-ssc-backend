﻿CREATE TABLE [dbo].[SupportTicketConversation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	SupportTicketId INT NOT NULL,
	AuthorId INT NOT NULL,
	Content NVARCHAR(MAX) NOT NULL,
	CreatedDate SMALLDATETIME NOT NULL DEFAULT(GETDATE()),

	FOREIGN KEY (SupportTicketId) REFERENCES SupportTicket,
	FOREIGN KEY (AuthorId) REFERENCES PlatformUser
)
