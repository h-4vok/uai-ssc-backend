CREATE TABLE SampleTransaction
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	SampleId INT NOT NULL,
	TransactionDate SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	SampleTransactionOriginId INT NOT NULL,
	OriginDescriptor NVARCHAR(500) NULL,
	SampleTransactionConceptId INT NOT NULL,
	Value NUMERIC(10, 2),
	BalanceAtTransactionTime NUMERIC(10, 2),
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (SampleId) REFERENCES Sample,
	FOREIGN KEY (SampleTransactionOriginId) REFERENCES SampleTransactionOrigin,
	FOREIGN KEY (SampleTransactionConceptId) REFERENCES SampleTransactionConcept
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTransaction',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTransaction',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTransaction',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTransaction',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTransaction',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Referencia a la muestra a la que le corresponde esta transacción',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTransaction',
    @level2type = N'COLUMN',
    @level2name = N'SampleId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de la transacción',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTransaction',
    @level2type = N'COLUMN',
    @level2name = N'TransactionDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Origen de la transacción',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTransaction',
    @level2type = N'COLUMN',
    @level2name = N'SampleTransactionOriginId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Descriptor adicional del origen de la transacción',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTransaction',
    @level2type = N'COLUMN',
    @level2name = N'OriginDescriptor'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tipo de concepto de la transacción',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTransaction',
    @level2type = N'COLUMN',
    @level2name = N'SampleTransactionConceptId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Valor de la transacción. Volumen afectado.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTransaction',
    @level2type = N'COLUMN',
    @level2name = N'Value'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Saldo de volumen de la muestra al momento de efectuarse la transacción',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTransaction',
    @level2type = N'COLUMN',
    @level2name = N'BalanceAtTransactionTime'