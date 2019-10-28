CREATE TABLE SampleTypeToParameter
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	SampleTypeId INT NOT NULL,
	ParameterTypeId INT NOT NULL,
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,
	
	FOREIGN KEY (SampleTypeId) REFERENCES [SampleType],
	FOREIGN KEY (ParameterTypeId) REFERENCES SampleTypeParameter
)

GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeToParameter',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id del tipo de muestra',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeToParameter',
    @level2type = N'COLUMN',
    @level2name = N'SampleTypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id del tipo de parámetro de muestra',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeToParameter',
    @level2type = N'COLUMN',
    @level2name = N'ParameterTypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeToParameter',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeToParameter',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeToParameter',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que actualizó último el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleTypeToParameter',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'