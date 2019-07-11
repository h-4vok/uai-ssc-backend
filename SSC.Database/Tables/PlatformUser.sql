CREATE TABLE [dbo].[PlatformUser]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[UserName] NVARCHAR(200) NOT NULL,
	[Password] NVARCHAR(200) NOT NULL,
	[IsBlocked] BIT NOT NULL DEFAULT(0),
	[IsEnabled] BIT NOT NULL DEFAULT (1),
	FirstName NVARCHAR(200),
	LastName NVARCHAR(200),
	ClientId INT,
	TitleInCompany NVARCHAR(200) NULL,
	IsEnabledInCompany  BIT NOT NULL DEFAULT(1),
	[LoginFailures] INT NOT NULL DEFAULT(0),
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (ClientId) REFERENCES ClientCompany
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Correo electrónico que sirve como nombre de usuario.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'UserName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Contraseña actual del usuario, encriptada irreversiblemente.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'Password'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Es 1 si el usuario se encuentra bloqueado por repetidos intentos fallidos de autenticarse.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'IsBlocked'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Contador de intentos fallidos de autenticación. Se reinicia a cero cuando se bloquea al usuario.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'LoginFailures'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id de usuario que creó el registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id de usuario que realizó la última actualización.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Indica si el usuario se encuentra habilitado por los administradores de SSC',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'IsEnabled'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Primer nombre de la persona.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'FirstName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Apellido de la persona',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'LastName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Cliente al que corresponde este usuario',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'ClientId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Título de esta persona en la empresa cliente',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'TitleInCompany'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Indica si el usuario se encuentra habilitado por el administrador del cliente',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PlatformUser',
    @level2type = N'COLUMN',
    @level2name = N'IsEnabledInCompany'