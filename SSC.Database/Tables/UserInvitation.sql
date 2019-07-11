CREATE TABLE UserInvitation
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	ClientId INT NOT NULL,
	InvitationToken NVARCHAR(500) NOT NULL,
	Email NVARCHAR(500) NOT NULL,
	DefaultRoleId INT NOT NULL,
	[Name] NVARCHAR(500) NOT NULL,
	ExpirationDate SMALLDATETIME NOT NULL,
	IsUsed BIT NOT NULL DEFAULT(0),
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (ClientId) REFERENCES ClientCompany,
	FOREIGN KEY (DefaultRoleId) REFERENCES [Role]
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserInvitation',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserInvitation',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserInvitation',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserInvitation',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserInvitation',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Cliente que creó esta invitación',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserInvitation',
    @level2type = N'COLUMN',
    @level2name = N'ClientId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Token generado para esta invitación específica',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserInvitation',
    @level2type = N'COLUMN',
    @level2name = N'InvitationToken'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Email al que se le envió la invitación',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserInvitation',
    @level2type = N'COLUMN',
    @level2name = N'Email'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Rol por defecto que tendrá el usuario invitado al registrarse con este token',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserInvitation',
    @level2type = N'COLUMN',
    @level2name = N'DefaultRoleId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Nombre del usuario invitado',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserInvitation',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de expiración de la invitación',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserInvitation',
    @level2type = N'COLUMN',
    @level2name = N'ExpirationDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Indica si la invitación fué utilizada',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserInvitation',
    @level2type = N'COLUMN',
    @level2name = N'IsUsed'