CREATE TABLE [dbo].[SupportTicket]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	UserId INT NOT NULL,
	Subject NVARCHAR(200) NOT NULL,
	SupportTicketStatusId INT NOT NULL,
	CreatedDate SMALLDATETIME NOT NULL,

	FOREIGN KEY (UserId) REFERENCES PlatformUser,
	FOREIGN KEY (SupportTicketStatusId) REFERENCES SupportTicketStatus
)
