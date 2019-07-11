CREATE TABLE WorkOrder
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	WorkOrderStatusId INT NOT NULL,
	TenantId INT NOT NULL,
	RequestDate SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	WorkOrderTypeId INT NULL,
	CurrentlyAssignedUserId INT,
	[CreatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[CreatedBy] INT,
	[UpdatedDate] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	[UpdatedBy] INT,

	FOREIGN KEY (WorkOrderStatusId) REFERENCES WorkOrderStatus,
	FOREIGN KEY (TenantId) REFERENCES ClientCompany,
	FOREIGN KEY (WorkOrderTypeId) REFERENCES WorkOrderType,
	FOREIGN KEY (CurrentlyAssignedUserId) REFERENCES PlatformUser
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id autonumérico de la tabla',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrder',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de creación del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrder',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario que creó el registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrder',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de última actualización del registro',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrder',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario de la última actualización',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrder',
    @level2type = N'COLUMN',
    @level2name = N'UpdatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Estado de la orden de trabajo',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrder',
    @level2type = N'COLUMN',
    @level2name = N'WorkOrderStatusId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Cliente al que le pertenece esta orden de trabajo',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrder',
    @level2type = N'COLUMN',
    @level2name = N'TenantId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha en la que se crea la orden de trabajo',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrder',
    @level2type = N'COLUMN',
    @level2name = N'RequestDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tipo de orden de trabajo',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrder',
    @level2type = N'COLUMN',
    @level2name = N'WorkOrderTypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Usuario asignado actualmente a esta orden de trabajo',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorkOrder',
    @level2type = N'COLUMN',
    @level2name = N'CurrentlyAssignedUserId'