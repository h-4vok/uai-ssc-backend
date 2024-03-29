﻿CREATE TABLE ClientCompanyTransaction
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	TransactionTypeId INT NOT NULL,
	TransactionDate SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	Total NUMERIC(10, 2) NOT NULL,
	ClientId INT NOT NULL,
	ReceiptId INT,
	RelatedReceiptId INT,
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (TransactionTypeId) REFERENCES TransactionType,
	FOREIGN KEY (ClientId) REFERENCES ClientCompany,
	FOREIGN KEY (ReceiptId) REFERENCES Receipt,
	FOREIGN KEY (RelatedReceiptId) REFERENCES Receipt
	
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransaction',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N's',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransaction',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransaction',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransaction',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransaction',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tipo de transacción',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransaction',
    @level2type = N'COLUMN',
    @level2name = N'TransactionTypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de la transacción',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransaction',
    @level2type = N'COLUMN',
    @level2name = N'TransactionDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Total de la transacción',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransaction',
    @level2type = N'COLUMN',
    @level2name = N'Total'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Cliente al que le pertenece esta transacción.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransaction',
    @level2type = N'COLUMN',
    @level2name = N'ClientId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Comprobante de la transacción',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransaction',
    @level2type = N'COLUMN',
    @level2name = N'ReceiptId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Comprobante relacionado a la transacción.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransaction',
    @level2type = N'COLUMN',
    @level2name = N'RelatedReceiptId'