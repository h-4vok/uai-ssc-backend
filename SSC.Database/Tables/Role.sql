CREATE TABLE [dbo].[Role]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(200) NOT NULL,
	[IsPlatformRole] BIT NOT NULL DEFAULT(0),
	IsEnabled BIT NOT NULL DEFAULT(1),
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Role',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Nombre del Rol predeterminado.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Role',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Indica si el rol es de plataforma (sólo para administradores) o es utilizable por clientes.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Role',
    @level2type = N'COLUMN',
    @level2name = N'IsPlatformRole'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Role',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id de usuario que creó el registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Role',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última modificación del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Role',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id de usuario de la última modificación del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Role',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'1 si el registro está habilitado',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Role',
    @level2type = N'COLUMN',
    @level2name = N'IsEnabled'