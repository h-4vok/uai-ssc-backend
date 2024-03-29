﻿CREATE TABLE ClientCompanyCreditCard
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	ClientId INT NOT NULL,
	Number NVARCHAR(30) NOT NULL,
	Owner NVARCHAR(500) NOT NULL,
	CCV INT NOT NULL,
	ExpirationDateMMYY NVARCHAR(4) NOT NULL,
	IsDefault BIT NOT NULL DEFAULT(1),
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (ClientId) REFERENCES ClientCompany
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyCreditCard',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyCreditCard',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyCreditCard',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyCreditCard',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyCreditCard',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Cliente al que le pertenece esta tarjeta de crédito',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyCreditCard',
    @level2type = N'COLUMN',
    @level2name = N'ClientId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Número de tarjeta de crédito',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyCreditCard',
    @level2type = N'COLUMN',
    @level2name = N'Number'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Titular de la tarjeta de crédito',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyCreditCard',
    @level2type = N'COLUMN',
    @level2name = N'Owner'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Código de seguridad de la tarjeta de crédito',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyCreditCard',
    @level2type = N'COLUMN',
    @level2name = N'CCV'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de expiración de la tarjeta de crédito en formato MMYY',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyCreditCard',
    @level2type = N'COLUMN',
    @level2name = N'ExpirationDateMMYY'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Indica si esta tarjeta es la predeterminada.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyCreditCard',
    @level2type = N'COLUMN',
    @level2name = N'IsDefault'