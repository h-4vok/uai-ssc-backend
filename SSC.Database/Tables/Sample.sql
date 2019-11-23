CREATE TABLE Sample
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	SampleTypeId INT NOT NULL,
	SampleFunctionId INT NOT NULL,
	InitialVolume NUMERIC(10,2) NOT NULL,
	CurrentVolume NUMERIC(10, 2) NOT NULL,
	UnitOfMeasureId INT NOT NULL,
	StatusCode NVARCHAR(100) NOT NULL DEFAULT('available'),
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (SampleTypeId) REFERENCES SampleType,
	FOREIGN KEY (SampleFunctionId) REFERENCES SampleFunction,
	FOREIGN KEY (UnitOfMeasureId) REFERENCES UnitOfMeasure
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Sample',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Sample',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Sample',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Sample',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Sample',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tipo de muestra',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Sample',
    @level2type = N'COLUMN',
    @level2name = N'SampleTypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tipo de función de muestra',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Sample',
    @level2type = N'COLUMN',
    @level2name = N'SampleFunctionId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Volumen inicial original de la muestra',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Sample',
    @level2type = N'COLUMN',
    @level2name = N'InitialVolume'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Volumen actual/saldo de la muestra',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Sample',
    @level2type = N'COLUMN',
    @level2name = N'CurrentVolume'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Unidad de medida de la muestra',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Sample',
    @level2type = N'COLUMN',
    @level2name = N'UnitOfMeasureId'