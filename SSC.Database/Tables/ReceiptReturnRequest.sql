CREATE TABLE [dbo].[ReceiptReturnRequest]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	ReceiptId INT NOT NULL,
	RequestedBy INT NOT NULL,
	Approved BIT NOT NULL DEFAULT(0),
	ApprovedBy INT,
	Rejected BIT NOT NULL DEFAULT(0),
	RejectedBy INT,
	RequestDate SMALLDATETIME DEFAULT(GETDATE()),
	ReviewDate SMALLDATETIME,

	FOREIGN KEY (ReceiptId) REFERENCES Receipt
)
