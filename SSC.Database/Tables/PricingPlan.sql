CREATE TABLE PricingPlan
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Code NVARCHAR(70) NOT NULL,
	Name NVARCHAR(500) NOT NULL,
	UserLimit INT NULL,
	ClinicRehearsalLimit INT NULL,
	PatientSampleLimit INT NULL,
	ControlSampleLimit INT NULL,
	AnualDiscountPercentage INT NULL,
	Price NUMERIC(12,2) NOT NULL,
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PricingPlan',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PricingPlan',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PricingPlan',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PricingPlan',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PricingPlan',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Código inmutable del plan de precios',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PricingPlan',
    @level2type = N'COLUMN',
    @level2name = N'Code'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Nombre amigable del plan de precios',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PricingPlan',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Límite de usuarios del plan',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PricingPlan',
    @level2type = N'COLUMN',
    @level2name = N'UserLimit'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Límite de ensayos clínicos mensuales del plan',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PricingPlan',
    @level2type = N'COLUMN',
    @level2name = N'ClinicRehearsalLimit'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Límite de muestras de pacientes del plan',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PricingPlan',
    @level2type = N'COLUMN',
    @level2name = N'PatientSampleLimit'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Límite de muestras de control del plan',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PricingPlan',
    @level2type = N'COLUMN',
    @level2name = N'ControlSampleLimit'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Descuento por suscripción anual',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PricingPlan',
    @level2type = N'COLUMN',
    @level2name = N'AnualDiscountPercentage'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Precio mensual del plan',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PricingPlan',
    @level2type = N'COLUMN',
    @level2name = N'Price'