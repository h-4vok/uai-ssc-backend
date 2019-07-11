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
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Orden de trabajo que es dueña de este registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrderExpectedSample',
    @level2type = N'COLUMN',
    @level2name = N'WorkOrderId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Muestra padre relacionada a esta muestra hija',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrderExpectedSample',
    @level2type = N'COLUMN',
    @level2name = N'ParentSampleId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Factor de dilución a utilizar para generar la muestra hija',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrderExpectedSample',
    @level2type = N'COLUMN',
    @level2name = N'DilutionFactor'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Volumen a utilizar de la muestra padre para generar esta muestra hija',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrderExpectedSample',
    @level2type = N'COLUMN',
    @level2name = N'VolumeToUse'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Volumen resultante esperada en la muestra hija',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrderExpectedSample',
    @level2type = N'COLUMN',
    @level2name = N'ResultingVolume'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Unidad de medida del volumen referenciado',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrderExpectedSample',
    @level2type = N'COLUMN',
    @level2name = N'UnitOfMeasureId'