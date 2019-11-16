CREATE TABLE [dbo].[ClientCompany]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name NVARCHAR(200) NOT NULL,
	CurrentPricingPlanId INT NOT NULL,
	IsEnabled BIT NOT NULL DEFAULT(1),
	ApiToken NVARCHAR(500) NOT NULL,
	ServicePlanExpirationDate SMALLDATETIME DEFAULT(GETDATE()),
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (CurrentPricingPlanId) REFERENCES PricingPlan
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompany',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompany',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id de usuario que creó el registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompany',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompany',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id de usuario que realizó la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompany',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Nombre de la compañía cliente.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompany',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'El plan contratado actual por el cliente',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompany',
    @level2type = N'COLUMN',
    @level2name = N'CurrentPricingPlanId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Si el cliente está habilitado en la plataforma o no.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompany',
    @level2type = N'COLUMN',
    @level2name = N'IsEnabled'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Token de seguridad que se utiliza como salt para encriptar datos sensibles del cliente.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClientCompany',
    @level2type = N'COLUMN',
    @level2name = N'ApiToken'