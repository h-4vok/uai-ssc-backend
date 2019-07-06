CREATE TABLE [dbo].[PhoneType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name NVARCHAR(200) NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico del tipo de teléfono',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PhoneType',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Descripción del tipo de teléfono',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PhoneType',
    @level2type = N'COLUMN',
    @level2name = N'Name'