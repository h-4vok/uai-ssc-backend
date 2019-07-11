CREATE TABLE ClinicRunInvalidation
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	ClinicRunId INT NOT NULL,
	SampleId INT NOT NULL,
	Comments NVARCHAR(MAX) NOT NULL,
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (ClinicRunId) REFERENCES ClinicRun,
	FOREIGN KEY (SampleId) REFERENCES Sample
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunInvalidation',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunInvalidation',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunInvalidation',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunInvalidation',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunInvalidation',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Ensayo clínico al que le pertenece esta invalidación.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunInvalidation',
    @level2type = N'COLUMN',
    @level2name = N'ClinicRunId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Referencia a la muestra invalidada.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunInvalidation',
    @level2type = N'COLUMN',
    @level2name = N'SampleId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Comentarios indicando el motivo de esta invalidación.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunInvalidation',
    @level2type = N'COLUMN',
    @level2name = N'Comments'