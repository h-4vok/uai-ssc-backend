CREATE TABLE ClinicRun
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	CurrentAssigneeId INT,
	ClinicRunStatusId INT NOT NULL,
	ClinicRunStageId INT NOT NULL,
	PrimaryAssigneeId INT,
	AuditorAssigneeId INT,
	QualityControlAssigneeId INT,
	TenantId INT,
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (CurrentAssigneeId) REFERENCES PlatformUser,
	FOREIGN KEY (ClinicRunStatusId) REFERENCES ClinicRunStatus,
	FOREIGN KEY (ClinicRunStageId) REFERENCES ClinicRunStage,
	FOREIGN KEY (PrimaryAssigneeId) REFERENCES PlatformUser,
	FOREIGN KEY (AuditorAssigneeId) REFERENCES PlatformUser,
	FOREIGN KEY (QualityControlAssigneeId) REFERENCES PlatformUser,
	FOREIGN KEY (TenantId) REFERENCES ClientCompany
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRun',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N's',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRun',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRun',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRun',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRun',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'A quién actualmente se encuentra asignado este ensayo clínico.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRun',
    @level2type = N'COLUMN',
    @level2name = N'CurrentAssigneeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Estado del ensayo clínico.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRun',
    @level2type = N'COLUMN',
    @level2name = N'ClinicRunStatusId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Etapa en la que se encuentra el ensayo clínico.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRun',
    @level2type = N'COLUMN',
    @level2name = N'ClinicRunStageId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Científico ejecutor del ensayo clínico.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRun',
    @level2type = N'COLUMN',
    @level2name = N'PrimaryAssigneeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Científico auditor del ensayo clínico.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRun',
    @level2type = N'COLUMN',
    @level2name = N'AuditorAssigneeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Controlador de calidad del ensayo clínico.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRun',
    @level2type = N'COLUMN',
    @level2name = N'QualityControlAssigneeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Cliente al que le pertenece este ensayo clínico.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRun',
    @level2type = N'COLUMN',
    @level2name = N'TenantId'