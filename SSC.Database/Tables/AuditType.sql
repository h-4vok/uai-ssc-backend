CREATE TABLE [dbo].[AuditType]
(
	[Id] INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(200) NOT NULL,
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id único del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditType',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditType',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id de usuario que creó el registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditType',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditType',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id de usuario que realizó la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditType',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Descripción del tipo de registro de auditoría.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditType',
    @level2type = N'COLUMN',
    @level2name = N'Name'