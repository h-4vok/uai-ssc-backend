CREATE TABLE [dbo].[Permission]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Code] NVARCHAR(50) NOT NULL,
	Name NVARCHAR(700) NOT NULL,
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
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Código único del permiso.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'Code'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id de usuario que creó el registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última modificación del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id de usuario de última modificación del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Nombre del permiso.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'Name'