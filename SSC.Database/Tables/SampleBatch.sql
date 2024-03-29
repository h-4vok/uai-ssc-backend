﻿CREATE TABLE SampleBatch
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Barcode NVARCHAR(500) NOT NULL,
	EntryDate SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	SampleBatchOriginId INT NOT NULL,
	TenantId INT NOT NULL,
	PatientId INT NULL,
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (SampleBatchOriginId) REFERENCES SampleBatchOrigin,
	FOREIGN KEY (TenantId) REFERENCES ClientCompany,
	FOREIGN KEY (PatientId) REFERENCES Patient
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleBatch',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleBatch',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleBatch',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleBatch',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleBatch',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Código de barra de la caja de muestras',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleBatch',
    @level2type = N'COLUMN',
    @level2name = N'Barcode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de ingreso de la caja',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleBatch',
    @level2type = N'COLUMN',
    @level2name = N'EntryDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tipo de origen de las muestras de la caja',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleBatch',
    @level2type = N'COLUMN',
    @level2name = N'SampleBatchOriginId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Cliente al que le pertenece esta caja',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleBatch',
    @level2type = N'COLUMN',
    @level2name = N'TenantId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Paciente del cual provienen las muestras',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SampleBatch',
    @level2type = N'COLUMN',
    @level2name = N'PatientId'