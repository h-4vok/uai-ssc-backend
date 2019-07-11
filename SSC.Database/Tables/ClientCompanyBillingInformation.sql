CREATE TABLE ClientCompanyBillingInformation
(
	[Id] INT NOT NULL PRIMARY KEY,
	LegalName NVARCHAR(500) NOT NULL,
	TaxCode NVARCHAR(16) NOT NULL,
	StreetName NVARCHAR(200) NOT NULL,
	StreetNumber NVARCHAR(200) NOT NULL,
	City NVARCHAR(200) NOT NULL,
	PostalCode NVARCHAR(70) NOT NULL,
	Department NVARCHAR(200) NULL,
	ProvinceId INT NOT NULL,
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (Id) REFERENCES ClientCompany,
	FOREIGN KEY (ProvinceId) REFERENCES Province
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyBillingInformation',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyBillingInformation',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyBillingInformation',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyBillingInformation',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyBillingInformation',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Razón Social a utilizar en las facturas',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyBillingInformation',
    @level2type = N'COLUMN',
    @level2name = N'LegalName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'CUIT/CUIL del cliente.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyBillingInformation',
    @level2type = N'COLUMN',
    @level2name = N'TaxCode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Calle del domicilio de facturación.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyBillingInformation',
    @level2type = N'COLUMN',
    @level2name = N'StreetName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Número de calle del domicilio de facturación.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyBillingInformation',
    @level2type = N'COLUMN',
    @level2name = N'StreetNumber'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Ciudad del domicilio de facturación.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyBillingInformation',
    @level2type = N'COLUMN',
    @level2name = N'City'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Código postal del domicilio de facturación.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyBillingInformation',
    @level2type = N'COLUMN',
    @level2name = N'PostalCode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Departamento o localidad del domicilio de facturación.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyBillingInformation',
    @level2type = N'COLUMN',
    @level2name = N'Department'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Provincia del domicilio de facturación.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompanyBillingInformation',
    @level2type = N'COLUMN',
    @level2name = N'ProvinceId'