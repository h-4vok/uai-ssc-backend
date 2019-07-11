CREATE TABLE QueuedMail
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	MailTo NVARCHAR(1500) NOT NULL,
	MailCc NVARCHAR(1500) NULL,
	MailBcc NVARCHAR(1500) NULL,
	Subject NVARCHAR(500) NOT NULL,
	Body NVARCHAR(MAX) NOT NULL,
	QueuedDate SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	ToPublishDate SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	SendDate SMALLDATETIME NULL,
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'QueuedMail',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'QueuedMail',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'QueuedMail',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'QueuedMail',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'QueuedMail',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Campo Recipiente del email',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'QueuedMail',
    @level2type = N'COLUMN',
    @level2name = N'MailTo'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Campo CC del email',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'QueuedMail',
    @level2type = N'COLUMN',
    @level2name = N'MailCc'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Campo BCC del email',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'QueuedMail',
    @level2type = N'COLUMN',
    @level2name = N'MailBcc'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Título del email',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'QueuedMail',
    @level2type = N'COLUMN',
    @level2name = N'Subject'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Cuerpo del email',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'QueuedMail',
    @level2type = N'COLUMN',
    @level2name = N'Body'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'En qué fecha se encoló este email',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'QueuedMail',
    @level2type = N'COLUMN',
    @level2name = N'QueuedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'En qué fecha debe mandarse este email',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'QueuedMail',
    @level2type = N'COLUMN',
    @level2name = N'ToPublishDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de efectivo envío del mail',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'QueuedMail',
    @level2type = N'COLUMN',
    @level2name = N'SendDate'