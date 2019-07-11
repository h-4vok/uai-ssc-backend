CREATE TABLE ClinicRunExecutionResult
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	ClinicRunExecutionId INT NOT NULL,
	Barcode NVARCHAR(500) NOT NULL,
	Volume NUMERIC(10, 2) NOT NULL,
	IsTrashed BIT NOT NULL DEFAULT(0),
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (ClinicRunExecutionId) REFERENCES ClinicRunExecution
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunExecutionResult',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunExecutionResult',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunExecutionResult',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunExecutionResult',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunExecutionResult',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Ejecución correspondiente a este resultado.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunExecutionResult',
    @level2type = N'COLUMN',
    @level2name = N'ClinicRunExecutionId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Código de barra de la muestra.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunExecutionResult',
    @level2type = N'COLUMN',
    @level2name = N'Barcode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Volumen remanente de la muestra.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunExecutionResult',
    @level2type = N'COLUMN',
    @level2name = N'Volume'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Indica si la muestra se ha echado a perder por algún motivo.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ClinicRunExecutionResult',
    @level2type = N'COLUMN',
    @level2name = N'IsTrashed'