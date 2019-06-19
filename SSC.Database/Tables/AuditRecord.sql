CREATE TABLE [dbo].[AuditRecord]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	UserName NVARCHAR(200) NOT NULL,
	Message NVARCHAR(MAX) NOT NULL,
	AuditTypeId INT NOT NULL,

	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT (GETDATE()), 
    FOREIGN KEY (AuditTypeId) REFERENCES AuditType
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico del registro de bitácora.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditRecord',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Nombre de usuario que generó la aserción.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditRecord',
    @level2type = N'COLUMN',
    @level2name = N'UserName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Mensaje que se registró.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditRecord',
    @level2type = N'COLUMN',
    @level2name = N'Message'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tipo de registro de bitácora',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditRecord',
    @level2type = N'COLUMN',
    @level2name = N'AuditTypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditRecord',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'