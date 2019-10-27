CREATE TABLE SampleTypeParameter
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	SampleTypeId INT NOT NULL,
	Code NVARCHAR(500) NOT NULL,
	DefaultDescription NVARCHAR(500) NOT NULL,
	ParameterDataTypeId INT NOT NULL,
	DecimalDigits INT NULL,
	MinimumRange NUMERIC(10, 2) NULL,
	MaximumRange Numeric(10, 2) NULL,
	UnitOfMeasureId INT NOT NULL,
	IsEnabled BIT,
	TenantId INT,
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (SampleTypeId) REFERENCES SampleType,
	FOREIGN KEY (ParameterDataTypeId) REFERENCES ParameterDataType,
	FOREIGN KEY (UnitOfMeasureId) REFERENCES UnitOfMeasure,
	FOREIGN KEY (TenantId) REFERENCES ClientCompany
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tipo de muestra al que le pertenece este parámetro de tipo de muestra',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'SampleTypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Código del parámetro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'Code'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Descripción amigable del parámetro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'DefaultDescription'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tipo de dato del parámetro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'ParameterDataTypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Dígitos decimales que permite el parámetro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'DecimalDigits'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Rango mínimo de valor que requiere este parámetro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'MinimumRange'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Rango máximo de valor que requiere este parámetro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'MaximumRange'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Referencia a la unidad de medida de este parámetro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'UnitOfMeasureId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Cliente al que le pertenece este parámetro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeParameter',
    @level2type = N'COLUMN',
    @level2name = N'TenantId'