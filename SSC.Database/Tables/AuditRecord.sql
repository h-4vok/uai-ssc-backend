CREATE TABLE [dbo].[AuditRecord]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	UserReference NVARCHAR(200) NOT NULL,
	Message NVARCHAR(MAX) NOT NULL,
	AuditTypeId INT NOT NULL,
	ClientId INT NULL,
	ErrorType NVARCHAR(500) NULL,
	ErrorSource NVARCHAR(500) NULL,
	StackTrace NVARCHAR(MAX) NULL,

	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT (GETDATE()), 
    FOREIGN KEY (AuditTypeId) REFERENCES AuditType,
	FOREIGN KEY (ClientId) REFERENCES ClientCompany
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
    @level2name = N'UserReference'
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
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Cliente al que le pertenece este registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditRecord',
    @level2type = N'COLUMN',
    @level2name = N'ClientId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'En caso de excepciones, el tipo de la Exception.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditRecord',
    @level2type = N'COLUMN',
    @level2name = N'ErrorType'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'La fuente del error según la exception capturada.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditRecord',
    @level2type = N'COLUMN',
    @level2name = N'ErrorSource'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'El stack trace del error.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AuditRecord',
    @level2type = N'COLUMN',
    @level2name = N'StackTrace'