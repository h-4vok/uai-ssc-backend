CREATE TABLE WorkOrderExpectedSample
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	WorkOrderId INT NOT NULL,
	ParentSampleId INT NOT NULL,
	DilutionFactor NUMERIC(10, 2) NOT NULL DEFAULT(1),
	VolumeToUse NUMERIC(10, 2),
	ResultingVolume NUMERIC(10, 2),
	UnitOfMeasureId INT NOT NULL,
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (WorkOrderId) REFERENCES WorkOrder,
	FOREIGN KEY (ParentSampleId) REFERENCES Sample,
	FOREIGN KEY (UnitOfMeasureId) REFERENCES UnitOfMeasure
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrderExpectedSample',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrderExpectedSample',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrderExpectedSample',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrderExpectedSample',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrderExpectedSample',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'