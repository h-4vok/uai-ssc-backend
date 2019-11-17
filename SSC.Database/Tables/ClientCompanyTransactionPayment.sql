CREATE TABLE ClientCompanyTransactionPayment
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	ClientCreditCardId INT,
	CreditNoteId INT,
	CreditCardNumber NVARCHAR(30),
	CreditCardOwner NVARCHAR(500),
	CreditCardCCV INT,
	CreditCardExpirationDateMMYY NVARCHAR(4),
	ClientTransactionId INT NOT NULL,
	Amount NUMERIC(12, 0),
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (ClientCreditCardId) REFERENCES ClientCompanyCreditCard,
	FOREIGN KEY (ClientTransactionId) REFERENCES ClientCompanyTransaction
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransactionPayment',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransactionPayment',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransactionPayment',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransactionPayment',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransactionPayment',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tarjeta de crédito utilizada en el pago',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransactionPayment',
    @level2type = N'COLUMN',
    @level2name = N'ClientCreditCardId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Transacción relacionada a este pago.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyTransactionPayment',
    @level2type = N'COLUMN',
    @level2name = N'ClientTransactionId'