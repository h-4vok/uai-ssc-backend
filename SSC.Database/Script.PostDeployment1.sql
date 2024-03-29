﻿
-- Setup ssc login
IF NOT EXISTS (SELECT [name]
FROM [sys].[database_principals]
WHERE [type] = N'S' AND [name] = N'ssc')
BEGIN
	CREATE USER ssc FOR LOGIN ssc;
	EXEC sp_addrolemember N'db_owner', N'ssc';
	EXEC sp_addrolemember N'db_backupoperator', N'ssc';
END

-- Satellite Data: Provinces
INSERT Province
	( Name )
SELECT
	Name = data.Name
FROM (
																																																																			SELECT Name = 'Ciudad Autónoma de Buenos Aires'
	UNION ALL
		SELECT Name = 'Buenos Aires'
	UNION ALL
		SELECT Name = 'Catamarca'
	UNION ALL
		SELECT Name = 'Chaco'
	UNION ALL
		SELECT Name = 'Chubut'
	UNION ALL
		SELECT Name = 'Córdoba'
	UNION ALL
		SELECT Name = 'Corrientes'
	UNION ALL
		SELECT Name = 'Entre Ríos'
	UNION ALL
		SELECT Name = 'Formosa'
	UNION ALL
		SELECT Name = 'Jujuy'
	UNION ALL
		SELECT Name = 'La Pampa'
	UNION ALL
		SELECT Name = 'La Rioja'
	UNION ALL
		SELECT Name = 'Mendoza'
	UNION ALL
		SELECT Name = 'Neuquén'
	UNION ALL
		SELECT Name = 'Río Negro'
	UNION ALL
		SELECT Name = 'Salta'
	UNION ALL
		SELECT Name = 'San Juan'
	UNION ALL
		SELECT Name = 'Santa Cruz'
	UNION ALL
		SELECT Name = 'Santa Fe'
	UNION ALL
		SELECT Name = 'Santiago del Estero'
	UNION ALL
		SELECT Name = 'Tierra del Fuego'
	UNION ALL
		SELECT Name = 'Tucumán'
) data
	LEFT JOIN Province P
	ON	data.Name = p.Name
WHERE		p.Name IS NULL

-- Initial Data: Default Roles
INSERT Role
	(
	Name,
	IsPlatformRole,
	IsEnabled
	)
SELECT
	Name = data.Name,
	IsPlatformRole = data.IsPlatformRole,
	IsEnabled = 1
FROM (
																			SELECT Name = 'No Registrado', IsPlatformRole = 1
	UNION ALL
		SELECT Name = 'Administrador de Sistema', IsPlatformRole = 1
	UNION ALL
		SELECT Name = 'Científico Ejecutor', IsPlatformRole = 0
	UNION ALL
		SELECT Name = 'Científico Auditor', IsPlatformRole = 0
	UNION ALL
		SELECT Name = 'Controlador de Calidad', IsPlatformRole = 0
	UNION ALL
		SELECT Name = 'Administrador de Cliente', IsPlatformRole = 0
) data
	LEFT JOIN Role R
	ON	data.Name = r.Name
WHERE		r.Name IS NULL

-- Satellite Data: Permissions
INSERT Permission
	(
	Code,
	Name,
	CreatedDate,
	UpdatedDate
	)
SELECT
	Code = aux.Code,
	Name = aux.Name,
	CreatedDate = GETDATE(),
	UpdatedDate = GETDATE()
FROM (
																																																																																											SELECT Code = 'CLIENT_BILLING_MANAGEMENT', Name = 'Gestión de Facturación de Clientes'
	UNION ALL
		SELECT Code = 'CLIENT_MANAGEMENT', Name = 'Gestión de Clientes'
	UNION ALL
		SELECT Code = 'LANGUAGES_MANAGEMENT', Name = 'Gestión de Idiomas de la plataforma'
	UNION ALL
		SELECT Code = 'NEWS_MANAGEMENT', Name = 'Gestión de Noticias'
	UNION ALL
		SELECT Code = 'PLATFORM_ADMIN', Name = 'El usuario es Administrador de la plataforma y no puede ser deshabilitado/eliminado.'
	UNION ALL
		SELECT Code = 'PLATFORM_BACKUP', Name = 'Puede accionar un resguardo de base de datos.'
	UNION ALL
		SELECT Code = 'PLATFORM_RESTORE', Name = 'Puede accionar una restauración de base de datos.'
	UNION ALL
		SELECT Code = 'ROLES_MANAGEMENT', Name = 'Gestión de Roles de la plataforma'
	UNION ALL
		SELECT Code = 'ROLES_REPORT', Name = 'Acceso al Reporte de Roles de la plataforma'
	UNION ALL
		SELECT Code = 'UNIT_OF_MEASURE_MANAGEMENT', Name = 'Gestión de Unidades de Medida'
	UNION ALL
		SELECT Code = 'USERS_MANAGEMENT', Name = 'Gestión de Usuarios de la plataforma'
	UNION ALL
		SELECT Code = 'USERS_REPORT', Name = 'Acceso al Reporte de Usuarios de la plataforma'
	UNION ALL
		SELECT Code = 'MEMBER_MANAGEMENT', Name = 'Gestión de Usuarios Miembro'
	UNION ALL
		SELECT Code = 'MEMBER_REPORT', Name = 'Acceso al Reporte de Miembros'
	UNION ALL
		SELECT Code = 'PATIENTS_MANAGEMENT', Name = 'Gestión de Pacientes'
	UNION ALL
		SELECT Code = 'PAYMENT_METHOD_MANAGEMENT', Name = 'Gestión de Forma de Pago'
	UNION ALL
		SELECT Code = 'RUN_EXECUTION_CANCEL', Name = 'Cancelación de lotes de ejecución'
	UNION ALL
		SELECT Code = 'RUN_EXECUTION_PRIMARY', Name = 'Generación y Ejecución primaria de lotes de ejecución'
	UNION ALL
		SELECT Code = 'RUN_EXECUTION_QA', Name = 'Control final de calidad de lotes de ejecución'
	UNION ALL
		SELECT Code = 'RUN_EXECUTION_QC', Name = 'Control de calidad de lotes de ejecución'
	UNION ALL
		SELECT Code = 'SAMPLE_FUNCTION_MANAGEMENT', Name = 'Gestión de Funciones de Muestra'
	UNION ALL
		SELECT Code = 'SAMPLE_FUNCTION_REPORT', Name = 'Acceso al Reporte de Funciones de Muestra'
	UNION ALL
		SELECT Code = 'SAMPLE_MANAGEMENT', Name = 'Gestión de Muestras de Paciente y de Control'
	UNION ALL
		SELECT Code = 'SAMPLE_TYPE_MANAGEMENT', Name = 'Gestión de Tipos de Muestra'
	UNION ALL
		SELECT Code = 'SAMPLE_TYPE_REPORT', Name = 'Acceso al Reporte de Tipos de Muestra'
	UNION ALL
		SELECT Code = 'USERS_INVITE', Name = 'Puede invitar a nuevos miembros a la plataforma.'
	UNION ALL
		SELECT Code = 'WORK_ORDER_CREATE', Name = 'Creación de Órdenes de Trabajo'
	UNION ALL
		SELECT Code = 'WORK_ORDER_EXECUTE', Name = 'Ejecución de Órdenes de Trabajo'
	UNION ALL
		SELECT Code = 'WORK_ORDER_REPORT', Name = 'Listar órdenes de trabajo'
	UNION ALL
		SELECT Code = 'SAMPLE_TYPE_PARAMETERS_MANAGEMENT', Name = 'Gestionar Tipos de Parámetro de Muestra' 
) AS aux
	LEFT JOIN Permission P
	ON	aux.Code = p.Code
WHERE		p.Code IS NULL

-- Default Platform Menu and Menu Items
EXEC sp_PlatformMenu_create 'configuration-menu', 'menu.platform.configuration-menu', 1, 1
EXEC sp_PlatformMenuItem_fullCreate 'configuration-menu', 1, '/configuration/unit-of-measure', 'menu.platform.configuration.unit-of-measure', 'UNIT_OF_MEASURE_MANAGEMENT'
EXEC sp_PlatformMenuItem_fullCreate 'configuration-menu', 2, '/configuration/sample-type', 'menu.platform.configuration.sample-type', 'SAMPLE_TYPE_MANAGEMENT', 'SAMPLE_TYPE_REPORT'
EXEC sp_PlatformMenuItem_fullCreate 'configuration-menu', 3, '/configuration/sample-type-parameter','menu.platform.configuration.sample-type-parameter', 'SAMPLE_TYPE_PARAMETERS_MANAGEMENT'
EXEC sp_PlatformMenuItem_fullCreate 'configuration-menu', 4, '/configuration/sample-function', 'menu.platform.configuration.sample-function', 'SAMPLE_FUNCTION_REPORT', 'SAMPLE_FUNCTION_MANAGEMENT'
EXEC sp_PlatformMenuItem_fullCreate 'configuration-menu', 5, '/configuration/language', 'menu.platform.configuration.language', 'LANGUAGES_MANAGEMENT'
EXEC sp_PlatformMenuItem_fullCreate 'configuration-menu', 6, '/configuration/client-billing', 'menu.platform.configuration.clients-and-billing', 'CLIENT_MANAGEMENT'
EXEC sp_PlatformMenuItem_fullCreate 'configuration-menu', 7, '/configuration/platform-menu', 'menu.platform.configuration.platform-menu', 'PLATFORM_ADMIN'

EXEC sp_PlatformMenu_create 'security-menu', 'menu.platform.security-menu', 2, 1
EXEC sp_PlatformMenuItem_fullCreate 'security-menu', 1, '/security/user', 'menu.platform.security.user', 'USERS_MANAGEMENT', 'USERS_REPORT'
EXEC sp_PlatformMenuItem_fullCreate 'security-menu', 2, '/security/role', 'menu.platform.security.role', 'ROLES_MANAGEMENT', 'ROLES_REPORT'
EXEC sp_PlatformMenuItem_fullCreate 'security-menu', 3, '/security/log', 'menu.platform.security.logging', 'PLATFORM_ADMIN'
EXEC sp_PlatformMenuItem_fullCreate 'security-menu', 4, '/security/backup', 'menu.platform.security.backup', 'PLATFORM_BACKUP', 'PLATFORM_RESTORE'
EXEC sp_PlatformMenuItem_fullCreate 'security-menu', 5, '/security/parameter', 'menu.platform.security.parameters', 'PLATFORM_ADMIN'

EXEC sp_PlatformMenu_create 'inventory-menu', 'menu.platform.inventory-menu', 3, 1
EXEC sp_PlatformMenuItem_fullCreate 'inventory-menu', 1, '/inventory/patient', 'menu.platform.inventory.patient', 'PATIENTS_MANAGEMENT'
EXEC sp_PlatformMenuItem_fullCreate 'inventory-menu', 2, '/inventory/sample', 'menu.platform.inventory.sample', 'SAMPLE_MANAGEMENT'

EXEC sp_PlatformMenu_create 'management-menu', 'menu.platform.management-menu', 4, 1
EXEC sp_PlatformMenuItem_fullCreate 'management-menu', 1, '/management/member', 'menu.platform.management.members', 'MEMBER_MANAGEMENT', 'MEMBER_REPORT'
EXEC sp_PlatformMenuItem_fullCreate 'management-menu', 2, '/management/payment-type', 'menu.platform.management.payment-type', 'PAYMENT_METHOD_MANAGEMENT'
EXEC sp_PlatformMenuItem_fullCreate 'management-menu', 3, '/management/billing', 'menu.platform.management.billing', 'CLIENT_BILLING_MANAGEMENT'
EXEC sp_PlatformMenuItem_fullCreate 'management-menu', 4, '/management/receipt-return-request', 'menu.platform.management.receipt-return-request', 'PLATFORM_ADMIN'
EXEC sp_PlatformMenuItem_fullCreate 'management-menu', 5, '/management/product-question', 'menu.platform.management.product-question', 'PLATFORM_ADMIN'
EXEC sp_PlatformMenuItem_fullCreate 'management-menu', 6, '/management/chat-statistics', 'menu.platform.management.chat-statistics', 'PLATFORM_ADMIN'
EXEC sp_PlatformMenuItem_fullCreate 'management-menu', 7, '/management/profit-report', 'menu.platform.management.profit-report', 'PLATFORM_ADMIN'

EXEC sp_PlatformMenu_create 'marketing-menu', 'menu.platform.marketing-menu', 5, 1
EXEC sp_PlatformMenuItem_fullCreate  'marketing-menu', 1, '/marketing/feedback-form', 'menu.platform.marketing.feedback-form', 'PLATFORM_ADMIN'
EXEC sp_PlatformMenuItem_fullCreate  'marketing-menu', 2, '/marketing/survey-form', 'menu.platform.marketing.survey-form', 'PLATFORM_ADMIN'
EXEC sp_PlatformMenuItem_fullCreate  'marketing-menu', 3, '/marketing/site-news', 'menu.platform.marketing.site-news', 'NEWS_MANAGEMENT'
EXEC sp_PlatformMenuItem_fullCreate  'marketing-menu', 4, '/marketing/newsletter/new', 'menu.platform.marketing.newsletter.new', 'NEWS_MANAGEMENT'
EXEC sp_PlatformMenuItem_fullCreate  'marketing-menu', 4, '/marketing/site-news-category', 'menu.platform.marketing.site-news-category', 'NEWS_MANAGEMENT'

--EXEC sp_PlatformMenu_create 'support-menu', 'menu.platform.support-menu', 6, 1
--EXEC sp_PlatformMenuItem_fullCreate  'support-menu', 1, '/support/support-ticket', 'menu.platform.support.support-ticket', 'PLATFORM_ADMIN'
--EXEC sp_PlatformMenuItem_fullCreate  'support-menu', 2, '/support/chat-conversation', 'menu.platform.support.chat-conversation', 'PLATFORM_ADMIN'

EXEC sp_PlatformMenu_create 'work-order-menu', 'menu.platform.work-order-menu', 7, 1
EXEC sp_PlatformMenuItem_fullCreate 'work-order-menu', 1, '/work-order/work-order', 'menu.platform.work-order.batches', 'WORK_ORDER_CREATE', 'WORK_ORDER_EXECUTE', 'WORK_ORDER_REPORT'
EXEC sp_PlatformMenuItem_fullCreate 'work-order-menu', 2, '/work-order/run', 'menu.platform.work-order.runs', 'RUN_EXECUTION_CANCEL', 'RUN_EXECUTION_PRIMARY','RUN_EXECUTION_QA','RUN_EXECUTION_QC'

-- Satellite Data: Initial Roles
INSERT Role
	(
	Name,
	IsPlatformRole,
	IsEnabled,
	CreatedDate,
	UpdatedDate
	)
SELECT
	Name = aux.Name,
	IsPlatformRole = aux.IsPlatformRole,
	IsEnabled = 1,
	CreatedDate = GETDATE(),
	UpdatedDate = GETDATE()
FROM (
																			SELECT Name = 'Usuario No Registrado', IsPlatformRole = 0
	UNION ALL
		SELECT Name = 'Administrador de Sistema', IsPlatformRole = 1
	UNION ALL
		SELECT Name = 'Científico Ejecutor', IsPlatformRole = 0
	UNION ALL
		SELECT Name = 'Científico Auditor', IsPlatformRole = 0
	UNION ALL
		SELECT Name = 'Controlador de Calidad', IsPlatformRole = 0
	UNION ALL
		SELECT Name = 'Administrador de Cliente', IsPlatformRole = 0 
) AS aux
	LEFT JOIN Role R
	ON	aux.Name = r.Name
WHERE		r.Name IS NULL

-- Role to Permissions - Administrador de Sistema
IF(NOT EXISTS(SELECT TOP 1
	1
FROM RolePermission RP INNER JOIN Role R ON rp.RoleId = r.Id
WHERE r.Name = 'Administrador de Sistema'))
BEGIN
	INSERT RolePermission
		(
		RoleId,
		PermissionId,
		CreatedDate,
		UpdatedDate
		)
	SELECT
		RoleId = r.Id,
		PermissionId = p.Id,
		CreatedDate = GETDATE(),
		UpdatedDate = GETDATE()
	FROM Role R
	CROSS JOIN	Permission P
	WHERE		R.Name = 'Administrador de Sistema'
		AND P.Code IN (
		'CLIENT_MANAGEMENT',
		'LANGUAGES_MANAGEMENT',
		'NEWS_MANAGEMENT',
		'PLATFORM_ADMIN',
		'PLATFORM_BACKUP',
		'PLATFORM_RESTORE',
		'ROLES_MANAGEMENT',
		'ROLES_REPORT',
		'UNIT_OF_MEASURE_MANAGEMENT',
		'USERS_MANAGEMENT',
		'USERS_REPORT',
		'SAMPLE_TYPE_PARAMETERS_MANAGEMENT'
	)
END

-- Role to Permissions - Científico Ejecutor
IF(NOT EXISTS(SELECT TOP 1
	1
FROM RolePermission RP INNER JOIN Role R ON rp.RoleId = r.Id
WHERE r.Name = 'Científico Ejecutor'))
BEGIN
	INSERT RolePermission
		(
		RoleId,
		PermissionId,
		CreatedDate,
		UpdatedDate
		)
	SELECT
		RoleId = r.Id,
		PermissionId = p.Id,
		CreatedDate = GETDATE(),
		UpdatedDate = GETDATE()
	FROM Role R
	CROSS JOIN	Permission P
	WHERE		R.Name = 'Científico Ejecutor'
		AND P.Code IN (
		'RUN_EXECUTION_CANCEL',
		'RUN_EXECUTION_PRIMARY',
		'SAMPLE_FUNCTION_REPORT',
		'SAMPLE_TYPE_REPORT',
		'SAMPLE_MANAGEMENT',
		'WORK_ORDER_CREATE',
		'WORK_ORDER_EXECUTE',
		'WORK_ORDER_REPORT'
	)
END

-- Role to Permissions - Científico Auditor
IF(NOT EXISTS(SELECT TOP 1
	1
FROM RolePermission RP INNER JOIN Role R ON rp.RoleId = r.Id
WHERE r.Name = 'Científico Auditor'))
BEGIN
	INSERT RolePermission
		(
		RoleId,
		PermissionId,
		CreatedDate,
		UpdatedDate
		)
	SELECT
		RoleId = r.Id,
		PermissionId = p.Id,
		CreatedDate = GETDATE(),
		UpdatedDate = GETDATE()
	FROM Role R
	CROSS JOIN	Permission P
	WHERE		R.Name = 'Científico Auditor'
		AND P.Code IN (
		'RUN_EXECUTION_CANCEL',
		'RUN_EXECUTION_QA',
		'SAMPLE_FUNCTION_REPORT',
		'SAMPLE_TYPE_REPORT',
		'SAMPLE_MANAGEMENT',
		'WORK_ORDER_REPORT'
	)
END

-- Role to Permissions - Controlador de Calidad
IF(NOT EXISTS(SELECT TOP 1
	1
FROM RolePermission RP INNER JOIN Role R ON rp.RoleId = r.Id
WHERE r.Name = 'Controlador de Calidad'))
BEGIN
	INSERT RolePermission
		(
		RoleId,
		PermissionId,
		CreatedDate,
		UpdatedDate
		)
	SELECT
		RoleId = r.Id,
		PermissionId = p.Id,
		CreatedDate = GETDATE(),
		UpdatedDate = GETDATE()
	FROM Role R
	CROSS JOIN	Permission P
	WHERE		R.Name = 'Controlador de Calidad'
		AND P.Code IN (
		'RUN_EXECUTION_CANCEL',
		'RUN_EXECUTION_QC',
		'SAMPLE_FUNCTION_REPORT',
		'SAMPLE_TYPE_REPORT',
		'SAMPLE_MANAGEMENT',
		'WORK_ORDER_REPORT'
	)
END

-- Role to Permissions - Administrador de Cliente
IF(NOT EXISTS(SELECT TOP 1
	1
FROM RolePermission RP INNER JOIN Role R ON rp.RoleId = r.Id
WHERE r.Name = 'Administrador de Cliente'))
BEGIN
	INSERT RolePermission
		(
		RoleId,
		PermissionId,
		CreatedDate,
		UpdatedDate
		)
	SELECT
		RoleId = r.Id,
		PermissionId = p.Id,
		CreatedDate = GETDATE(),
		UpdatedDate = GETDATE()
	FROM Role R
	CROSS JOIN	Permission P
	WHERE		R.Name = 'Administrador de Cliente'
		AND P.Code IN (
		'MEMBER_MANAGEMENT',
		'MEMBER_REPORT',
		'PATIENTS_MANAGEMENT',
		'PAYMENT_METHOD_MANAGEMENT',
		'RUN_EXECUTION_CANCEL',
		'RUN_EXECUTION_PRIMARY',
		'RUN_EXECUTION_QA',
		'RUN_EXECUTION_QC',
		'SAMPLE_FUNCTION_MANAGEMENT',
		'SAMPLE_FUNCTION_REPORT',
		'SAMPLE_MANAGEMENT',
		'SAMPLE_TYPE_MANAGEMENT',
		'SAMPLE_TYPE_REPORT',
		'USERS_INVITE',
		'WORK_ORDER_CREATE',
		'WORK_ORDER_EXECUTE',
		'WORK_ORDER_REPORT'
	)
END

-- Initial Admin account
IF (NOT EXISTS(SELECT TOP 1
	1
FROM PlatformUser
WHERE UserName = 'admin@ssc.com'))
BEGIN
	INSERT PlatformUser
		(
		UserName,
		Password,
		IsBlocked,
		IsEnabled,
		FirstName,
		LastName,
		IsEnabledInCompany,
		LoginFailures,
		CreatedDate,
		UpdatedDate,
		CreatedBy,
		UpdatedBy
		)
	SELECT
		UserName = 'admin@ssc.com',
		Password = '1A4+OYh1+avWgZilfsAZY1hBt+Y=',
		IsBlocked = 0,
		IsEnabled = 1,
		FirstName = 'Christian',
		LastName = 'Guzman',
		IsEnabledInCompany = 1,
		LoginFailures = 0,
		CreatedDate = GETDATE(),
		UpdatedDate = GETDATE(),
		CreatedBy = 1,
		UpdatedBy = 1

	DECLARE @adminUserId INT
	SET @adminUserId = SCOPE_IDENTITY()

	-- Relate admin account to the admin role
	INSERT UserRole
		(
		UserId,
		RoleId,
		CreatedDate,
		UpdatedDate
		)
	SELECT
		UserId = @adminUserId,
		RoleId = r.Id,
		CreatedDate = GETDATE(),
		UpdatedDate = GETDATE()
	FROM Role R
	WHERE		R.Name = 'Administrador de Sistema'
END

-- Satellite Data: Pricing Plans
INSERT PricingPlan
	(
	Code,
	Name,
	UserLimit,
	ClinicRehearsalLimit,
	PatientSampleLimit,
	ControlSampleLimit,
	AnualDiscountPercentage,
	Price
	)
SELECT
	Code = data.Code,
	Name = data.Name,
	UserLimit = data.UserLimit,
	ClinicRehearsalLimit = data.ClinicRehearsalLimit,
	PatientSampleLimit = data.PatientSampleLimit,
	ControlSampleLimit = data.ControlSampleLimit,
	AnualDiscountPercentage = data.AnualDiscountPercentage,
	Price = data.Price
FROM (
										SELECT
			Code = 'pricing-plan--free',
			Name = 'Gratuito',
			UserLimit = 5,
			ClinicRehearsalLimit = 10,
			PatientSampleLimit = 1000,
			ControlSampleLimit = 1000,
			AnualDiscountPercentage = NULL,
			Price = 0
	UNION ALL
		SELECT
			Code = 'pricing-plan--premium',
			Name = 'Premium',
			UserLimit = 50,
			ClinicRehearsalLimit = NULL,
			PatientSampleLimit = 5000,
			ControlSampleLimit = 5000,
			AnualDiscountPercentage = 10,
			Price = 17500
	UNION ALL
		SELECT
			Code = 'pricing-plan--corporate',
			Name = 'Corporativo',
			UserLimit = NULL,
			ClinicRehearsalLimit = NULL,
			PatientSampleLimit = NULL,
			ControlSampleLimit = NULL,
			AnualDiscountPercentage = 20,
			Price = 50000
) data
	LEFT JOIN PricingPlan PP
	ON	data.Code = pp.Code
WHERE		pp.CODE IS NULL

-- Support Ticket Statuses
INSERT SupportTicketStatus
	(
	Code,
	TranslationKey
	)
	SELECT
		Code = 'SENT',
		TranslationKey = 'support-ticket-status.sent'
UNION ALL
	SELECT
		Code = 'RESPONDED',
		TranslationKey = 'support-ticket-status.replied'
UNION ALL
	SELECT
		Code = 'CLOSED',
		TranslationKey = 'support-ticket-status.closed'
UNION ALL
	SELECT
		Code = 'CANCELLED',
		TranslationKey = 'support-ticket-status.cancelled'

-- Default Site News Categories
INSERT SiteNewsCategory (
	Description
)
VALUES ( 'General' ), ( 'Investigación Clínica' ), ( 'Avances en Software Médico' ), ( 'Ofertas' )

-- Approved Credit Cards (for testing)
EXEC sp_ApprovedCreditCard_create '5258116611881129', 'CHRISTIAN A GUZMAN', 747, '1129'
EXEC sp_ApprovedCreditCard_create '379500550031649', 'CHRISTIAN A GUZMAN', 4569, '1025'
EXEC sp_ApprovedCreditCard_create '5165887744556699', 'GUZMAN CHRISTIAN A', 333, '1018'
EXEC sp_ApprovedCreditCard_create '4111321432143214', 'CHRISTIAN A GUZMAN', 111, '1026'
EXEC sp_ApprovedCreditCard_create '4517666866676669', 'GUZMAN CHRISTIAN', 222, '0822'

-- Receipt Types
INSERT ReceiptType (
	Code,
	Description,
	IsSale,
	CreatedBy,
	UpdatedBy
)
SELECT
	Code = 'purchase-bill',
	Description = 'Factura',
	IsSale = 1,
	CreatedBy = @adminUserId,  
	UpdatedBy = @adminUserId
UNION
SELECT
	Code = 'credit-note',
	Description = 'Nota de Crédito',
	IsSale = 1,
	CreatedBy = @adminUserId,  
	UpdatedBy = @adminUserId

INSERT TransactionType (
	Description,
	CreatedBy,
	UpdatedBy
)
SELECT
	Description = 'Compra',
	CreatedBy = @adminUserId,
	UpdatedBy = @adminUserId
UNION
SELECT
	Description = 'Retorno',
	CreatedBy = @adminUserId,
	UpdatedBy = @adminUserId

-- System Languages (Initial)
IF(NOT EXISTS(SELECT TOP 1
	1
FROM SystemLanguage
WHERE Code = 'es'))
BEGIN
	INSERT SystemLanguage
		(
		Code,
		Name,
		CreatedBy,
		CreatedDate
		)
	SELECT
		Code = 'es',
		Name = 'Español',
		CreatedBy = 1,
		UpdatedBy = 1
END

-- Audit Types
INSERT AuditType
	(
	Id,
	Name,
	CreatedBy,
	CreatedDate,
	UpdatedBy,
	UpdatedDate
	)
SELECT
	Id = data.Id,
	Name = data.Name,
	CreatedBy = 1,
	CreatedDate = GETUTCDATE(),
	UpdatedBy = 1,
	UpdatedDate = GETUTCDATE()
FROM (
							SELECT Id = 1, Name = 'Information'
	UNION
		SELECT Id = 2, Name = 'Error'
) AS data
	LEFT JOIN AuditType AT
	ON	data.Id = at.Id

WHERE		at.Id IS NULL

-- ParameterDataType
INSERT ParameterDataType
	(
	Code,
	CreatedDate,
	CreatedBy,
	UpdatedDate,
	UpdatedBy
	)
SELECT
	Code = data.Code,
	CreatedDate = GETUTCDATE(),
	CreatedBy = 1,
	UpdatedDate = GETUTCDATE(),
	UpdatedBy = 1
FROM (
							SELECT Code = 'INTEGER'
	UNION ALL
		SELECT Code = 'DECIMAL'
) AS data
	LEFT JOIN ParameterDataType ORIG
	ON	orig.Code = data.Code
WHERE		orig.Code IS NULL

-- Default client user for testing
INSERT ClientCompany
	(
	Name,
	CurrentPricingPlanId,
	IsEnabled,
	ApiToken
	)
SELECT
	Name = 'Default Company',
	CurrentPricingPlanId = 2,
	IsEnabled = 1,
	ApiToken = '8kz/12jLWPeHh7cL6Br11yCyRSE='

DECLARE @DefaultCompanyId INT
SET @DefaultCompanyId = SCOPE_IDENTITY()

INSERT ClientCompanyAddress
	(
	ClientCompanyId,
	StreetName,
	StreetNumber,
	City,
	PostalCode,
	Department,
	ProvinceId
	)
SELECT
	ClientCompanyId = @DefaultCompanyId,
	StreetName = 'Calle Falsa',
	StreetNumbe = '123',
	City = 'Avellaneda',
	PostalCode = '1870',
	Department = '2',
	ProvinceId = 2

INSERT ClientCompanyBillingInformation
	(
	Id,
	LegalName,
	TaxCode,
	StreetName,
	StreetNumber,
	City,
	PostalCode,
	Department,
	ProvinceId
	)
SELECT
	Id = @DefaultCompanyId,
	LegalName = 'Default Company',
	TaxCode = '20330749076',
	StreetName = 'Calle Falsa',
	StreetNumber = '123',
	City = 'Avellaneda',
	PostalCode = '1870',
	Department = '2',
	ProvinceId = 2

INSERT ClientCompanyCreditCard
	(
	ClientId,
	Number,
	Owner,
	CCV,
	ExpirationDateMMYY,
	IsDefault
	)
SELECT
	ClientId = @DefaultCompanyId,
	Number = '0000000000000000000',
	Owner = 'GUZMANOV CHRISTOFF',
	CCV = '878',
	ExpirationDateMMYY = '0120',
	IsDefault = 1
UNION SELECT
	ClientId = @DefaultCompanyId,
	Number = '379500000007154',
	Owner = 'GUZMANOV CHRISTOFF',
	CCV = '7777',
	ExpirationDateMMYY = '0924',
	IsDefault = 0
UNION SELECT
	ClientId = @DefaultCompanyId,
	Number = '5258001100300093',
	Owner = 'GUZMANOV CHRISTOFF',
	CCV = '878',
	ExpirationDateMMYY = '0120',
	IsDefault = 0
UNION SELECT
	ClientId = @DefaultCompanyId,
	Number = '4704555500002222',
	Owner = 'GUZMANOV CHRISTOFF',
	CCV = '111',
	ExpirationDateMMYY = '0120',
	IsDefault = 0

EXEC sp_PlatformUser_createTestUser 'test@test.com', @DefaultCompanyId
EXEC sp_PlatformUser_createTestUser 'test1@test.com', @DefaultCompanyId
EXEC sp_PlatformUser_createTestUser 'test2@test.com', @DefaultCompanyId
EXEC sp_PlatformUser_createTestUser 'test3@test.com', @DefaultCompanyId
EXEC sp_PlatformUser_createTestUser 'test4@test.com', @DefaultCompanyId
EXEC sp_PlatformUser_createTestUser 'test5@test.com', @DefaultCompanyId
EXEC sp_PlatformUser_createTestUser 'test6@test.com', @DefaultCompanyId
EXEC sp_PlatformUser_createTestUser 'test7@test.com', @DefaultCompanyId
EXEC sp_PlatformUser_createTestUser 'test8@test.com', @DefaultCompanyId
EXEC sp_PlatformUser_createTestUser 'test9@test.com', @DefaultCompanyId
EXEC sp_PlatformUser_createTestUser 'test10@test.com', @DefaultCompanyId

-- Patient Types
INSERT PatientType
	(
	Code,
	Description,
	CreatedBy,
	UpdatedBy
	)
SELECT
	Code = data.Code,
	Description = data.Description,
	CreatedBy = 1,
	UpdatedBy = 1
FROM (
													SELECT Code = 'HUMAN', Description = 'Humano'
	UNION ALL
		SELECT Code = 'ANIMAL', Description = 'Animal'
	UNION ALL
		SELECT Code = 'INSECT', Description = 'Insecto'
	UNION ALL
		SELECT Code = 'OTRO', Description = 'Otro'
) as data
	LEFT JOIN PatientType PT
	ON	data.Code = pt.Code
WHERE		pt.Code IS NULL

-- SystemLanguages
IF(NOT EXISTS(SELECT TOP 1
	1
FROM SystemLanguage
WHERE Code = 'en'))
BEGIN
	INSERT SystemLanguage
		(
		Code,
		Name,
		CreatedBy,
		CreatedDate
		)
	SELECT
		Code = 'en',
		Name = 'English',
		CreatedBy = 1,
		UpdatedBy = 1
END

-- Default unit of measures
EXEC sp_UnitOfMeasure_create
	@Code = 'ml',
	@DefaultDescription = 'mililitros',
	@CreatedBy = 1


-- System Language Entries (Initial - Spanish) - Part 1
INSERT SystemLanguageEntry
	(
	SystemLanguageId,
	EntryKey,
	Translation,
	CreatedBy,
	UpdatedBy
	)
SELECT
	SystemLanguageId = sl.Id,
	EntryKey = data.k,
	Translation = (CASE WHEN sl.Code = 'es' THEN data.es ELSE data.en END),
	CreatedBy = 1,
	UpdatedBy = 1
FROM (
																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																										SELECT k = 'app.title',
			es = 'Sample Supply Chain',
			en = 'Sample Supply Chain'
	UNION
		SELECT k = 'app.home.slogan',
			es = 'La solución integral para la administración de muestras de tu laboratorio.',
			en = 'Your one stop shop for sample supply management in your lab.'
	UNION
		SELECT k = 'app.marketing.menu.pricing',
			es = 'Precios',
			en = 'Pricing'
	UNION
		SELECT k = 'app.marketing.menu.about-us',
			es = 'Sobre Nosotros',
			en = 'About Us'
	UNION
		SELECT k = 'app.marketing.menu.platform',
			es = 'Ingresar',
			en = 'Sign in'
	UNION
		SELECT k = 'home.card.tracking.header',
			es = 'Preparado para su negocio',
			en = 'Ready for your business'
	UNION
		SELECT k = 'home.card.tracking.title',
			es = 'Gestión y Seguimiento de Muestras',
			en = 'Sample Management and Tracking'
	UNION
		SELECT k = 'home.card.tracking.subtitle',
			es = 'Sea capaz de gestionar y seguir todas las muestras de sus depósitos distribuídas en ubicaciones geográficas diferentes.',
			en = 'Be capable of managing and tracking all your samples from all your geographically distributed warehouses.'
	UNION
		SELECT k = 'home.card.all.start-now',
			es = '¡Empiece Ahora!',
			en = 'Start Now!'
	UNION
		SELECT k = 'home.card.compliance.header',
			es = 'No gaste en auditorías',
			en = 'Do not waste your money in auditing'
	UNION
		SELECT k = 'home.card.compliance.title',
			es = 'Compliance',
			en = 'Compliance'
	UNION
		SELECT k = 'home.card.compliance.subtitle',
			es = 'No se preocupe más por todos los formularios que debe presentar a las diferentes instituciones controladoras. Hacemos el trabajo por usted.',
			en = 'Do not worry anymore about all the forms you must present to the different controlling institutions. We do the heavy lifting for you.'
	UNION
		SELECT k = 'home.card.custom-runs.header',
			es = 'Libertad para definir sus investigaciones',
			en = 'Freedom to define your researches'
	UNION
		SELECT k = 'home.card.custom-runs.title',
			es = 'Customización de Ensayos Clínicos',
			en = 'Customize all your Clinic Runs'
	UNION
		SELECT k = 'home.card.custom-runs.subtitle',
			es = 'Con una plataforma capaz de configurarse para realizar los ensayos clínicos de cualquier forma que usted y su equipo necesite.',
			en = 'Use a platform able to be configured to run your clinic runs in any way you and your team needs.'
	UNION
		SELECT k = 'home.card.inventory.header',
			es = 'No pierda rastro de sus caros recursos',
			en = 'Do not lose tracking of your expensive resources'
	UNION
		SELECT k = 'home.card.inventory.title',
			es = 'Inventariado',
			en = 'Inventory'
	UNION
		SELECT k = 'home.card.inventory.subtitle',
			es = 'Mantenga completo control de todas sus muestras automáticamente seleccionando el mejor conjunto de las mismas para sus ensayos.',
			en = 'Keep full control of all your samples by automatically selecting the best possible group for your clinic runs.'
	UNION
		SELECT k = 'pricing-plan.free.title',
			es = 'Gratuito',
			en = 'Free'
	UNION
		SELECT k = 'pricing-plan.free.subheader',
			es = 'Para probar la plataforma',
			en = 'Test our platform'
	UNION
		SELECT k = 'pricing-plan.free.price',
			es = 'USD 0',
			en = 'USD 0'
	UNION
		SELECT k = 'pricing-plan.free.billFrequency',
			es = '/mes',
			en = '/month'
	UNION
		SELECT k = 'pricing-plan.free.planDescription',
			es = 'Suscripción gratuita para probar',
			en = 'Free subscription for testing purposes'
	UNION
		SELECT k = 'pricing-plan.free.patientSamplesDescription',
			es = 'Hasta 1000 muestras de pacientes',
			en = 'Up to 1000 patient samples'
	UNION
		SELECT k = 'pricing-plan.free.controlSamplesDescription',
			es = 'Hasta 1000 muestras de control',
			en = 'Up to 1000 control samples'
	UNION
		SELECT k = 'pricing-plan.free.userAccountsDescription',
			es = 'Hasta 5 cuentas de usuario',
			en = 'Up to 5 user accounts'
	UNION
		SELECT k = 'pricing-plan.free.runExecutionsDescription',
			es = 'Hasta 10 ensayos clinicos por mes',
			en = 'Up to 10 clinic runs each month'
	UNION
		SELECT k = 'pricing-plan.free.signUpDescription',
			es = 'Probar la plataforma',
			en = 'Try the platform'
	UNION
		SELECT k = 'pricing-plan.premium.title',
			es = 'Premium',
			en = 'Premium'
	UNION
		SELECT k = 'pricing-plan.premium.subheader',
			es = 'Para laboratorios pequeños y medianos',
			en = 'For small and medium sized organizations'
	UNION
		SELECT k = 'pricing-plan.premium.price',
			es = 'USD 17.500',
			en = 'USD 17.500'
	UNION
		SELECT k = 'pricing-plan.premium.billFrequency',
			es = '/mes',
			en = '/month'
	UNION
		SELECT k = 'pricing-plan.premium.planDescription',
			es = 'Suscripción mensual o anual (con descuento)',
			en = 'Monthly subscription or anual subscription at discount'
	UNION
		SELECT k = 'pricing-plan.premium.patientSamplesDescription',
			es = 'Hasta 5000 muestras de pacientes por mes',
			en = 'Up to 5000 patient samples a month'
	UNION
		SELECT k = 'pricing-plan.premium.controlSamplesDescription',
			es = 'Hasta 5000 muestras de control por mes',
			en = 'Up to 5000 control samples a month'
	UNION
		SELECT k = 'pricing-plan.premium.userAccountsDescription',
			es = 'Hasta 50 cuentas de usuario',
			en = 'Up to 50 user accounts'
	UNION
		SELECT k = 'pricing-plan.premium.runExecutionsDescription',
			es = 'Sin límite de ensayos clínicos',
			en = 'No clinic run limits'
	UNION
		SELECT k = 'pricing-plan.premium.signUpDescription',
			es = 'Comenzar a operar',
			en = 'Start Working'
	UNION
		SELECT k = 'pricing-plan.corporate.title',
			es = 'Corporativo',
			en = 'Corporate'
	UNION
		SELECT k = 'pricing-plan.corporate.subheader',
			es = 'La solución completa de SSC',
			en = 'Our most complete solution'
	UNION
		SELECT k = 'pricing-plan.corporate.price',
			es = 'USD 50.000',
			en = 'USD 50.000'
	UNION
		SELECT k = 'pricing-plan.corporate.billFrequency',
			es = '/mes',
			en = '/month'
	UNION
		SELECT k = 'pricing-plan.corporate.planDescription',
			es = 'Suscripción mensual o anual (con descuento)',
			en = 'Monthly subscription or anual subscription at discount'
	UNION
		SELECT k = 'pricing-plan.corporate.patientSamplesDescription',
			es = 'Sin límite de muestras de pacientes',
			en = 'Unlimited patient samples'
	UNION
		SELECT k = 'pricing-plan.corporate.controlSamplesDescription',
			es = 'Sin límite de muestras de control',
			en = 'Unlimited control samples'
	UNION
		SELECT k = 'pricing-plan.corporate.userAccountsDescription',
			es = 'Sin límite de cuentas de usuario',
			en = 'Unlimited user accounts'
	UNION
		SELECT k = 'pricing-plan.corporate.runExecutionsDescription',
			es = 'Sin límite de ensayos clínicos',
			en = 'Unlimited clinic runs'
	UNION
		SELECT k = 'pricing-plan.corporate.signUpDescription',
			es = 'Operatoria profesional',
			en = 'Professional Operations'
	UNION
		SELECT k = 'sign-in.page.title',
			es = 'Autenticarse',
			en = 'Sign in'
	UNION
		SELECT k = 'sign-in.email',
			es = 'Correo electrónico',
			en = 'E-mail'
	UNION
		SELECT k = 'sign-in.password',
			es = 'Contraseña',
			en = 'Password'
	UNION
		SELECT k = 'sign-in.login',
			es = 'Autenticarse',
			en = 'Sign In'
	UNION
		SELECT k = 'sign-in.forgot-password',
			es = 'Olvidé mi contraseña',
			en = 'Forgot my password'
	UNION
		SELECT k = 'sign-in.sign-up',
			es = 'Registrar nueva cuenta',
			en = 'Sign up a new account'
	UNION
		SELECT k = 'sign-up--initial.page.title',
			es = 'Registración',
			en = 'Sign up'
	UNION
		SELECT k = 'sign-up--initial.name',
			es = 'Nombre',
			en = 'Name'
	UNION
		SELECT k = 'sign-up--initial.lastName',
			es = 'Apellido',
			en = 'Last Name'
	UNION
		SELECT k = 'sign-up--initial.email',
			es = 'Correo electrónico',
			en = 'E-mail'
	UNION
		SELECT k = 'sign-up--initial.password',
			es = 'Contraseña',
			en = 'Password'
	UNION
		SELECT k = 'sign-up--initial.repeatPassword',
			es = 'Repetir contraseña',
			en = 'Repeat password'
	UNION
		SELECT k = 'sign-up--initial.password-strength.minChar',
			es = 'La contraseña debe tener al menos 8 caracteres',
			en = 'Password must be at least 8 characters long'
	UNION
		SELECT k = 'sign-up--initial.password-strength.oneNumber',
			es = 'Debe utilizar al menos un número',
			en = 'Must use at least one number'
	UNION
		SELECT k = 'sign-up--initial.password-strength.oneLowerCaseChar',
			es = 'Debe utilizar al menos una letra minúscula',
			en = 'Must use at least one lower case character'
	UNION
		SELECT k = 'sign-up--initial.password-strength.oneUpperCaseChar',
			es = 'Debe utilizar al menos una letra mayúscula',
			en = 'Must use at least one upper case character'
	UNION
		SELECT k = 'sign-up--initial.password-strength.oneSpecialSymbol',
			es = 'Debe utilizar un caractér especial de entre: (! @ + # $ ^ & *)',
			en = 'Must use at least one special character: (! @ + # $ ^ & *)'
	UNION
		SELECT k = 'sign-up--initial.continue',
			es = 'Continuar',
			en = 'Continue'
	UNION
		SELECT k = 'sign-up--company.page.title',
			es = 'Datos de la compañía',
			en = 'Company information'
	UNION
		SELECT k = 'sign-up--company.name',
			es = 'Nombre de la organización',
			en = 'Company Name'
	UNION
		SELECT k = 'sign-up--company.province',
			es = 'Provincia',
			en = 'Province'
	UNION
		SELECT k = 'sign-up--company.city',
			es = 'Ciudad',
			en = 'City'
	UNION
		SELECT k = 'sign-up--company.street',
			es = 'Calle',
			en = 'Street'
	UNION
		SELECT k = 'sign-up--company.streetNumber',
			es = 'Número',
			en = 'Street Number'
	UNION
		SELECT k = 'sign-up--company.department',
			es = 'Departamento',
			en = 'Department'
	UNION
		SELECT k = 'sign-up--company.postalCode',
			es = 'Código Postal',
			en = 'Postal Code'
	UNION
		SELECT k = 'sign-up--company.continue',
			es = 'Continuar',
			en = 'Continue'
	UNION
		SELECT k = 'sign-up--payment-data.page.title',
			es = 'Datos de Tarjeta de Crédito',
			en = 'Credit Card Payment Info'
	UNION
		SELECT k = 'sign-up--payment-data.creditCardNumber',
			es = 'Número de tarjeta',
			en = 'Credit card number'
	UNION
		SELECT k = 'sign-up--payment-data.creditCardHolder',
			es = 'Titular como figura en la tarjeta',
			en = 'Credit card holder'
	UNION
		SELECT k = 'sign-up--payment-data.ccv',
			es = 'CCV',
			en = 'CCV'
	UNION
		SELECT k = 'sign-up--payment-data.expirationDate',
			es = 'Fecha de expiración (MMYY)',
			en = 'Expiration Date (MMYY)'
	UNION
		SELECT k = 'sign-up--payment-data.continue',
			es = 'Continuar',
			en = 'Continue'
	UNION
		SELECT k = 'sign-up--billing.page.title',
			es = 'Datos de Facturación',
			en = 'Company Billing Information'
	UNION
		SELECT k = 'sign-up--billing.name',
			es = 'Denominación Fiscal',
			en = 'Company Legal Name'
	UNION
		SELECT k = 'sign-up--billing.taxCode',
			es = 'Número de identificación fiscal',
			en = 'Company Tax Code'
	UNION
		SELECT k = 'sign-up--billing.province',
			es = 'Provincia',
			en = 'Province'
	UNION
		SELECT k = 'sign-up--billing.city',
			es = 'Ciudad',
			en = 'City'
	UNION
		SELECT k = 'sign-up--billing.street',
			es = 'Calle',
			en = 'Street'
	UNION
		SELECT k = 'sign-up--billing.streetNumber',
			es = 'Número',
			en = 'Street number'
	UNION
		SELECT k = 'sign-up--billing.department',
			es = 'Departamento',
			en = 'Department'
	UNION
		SELECT k = 'sign-up--billing.postalCode',
			es = 'Código Postal',
			en = 'Postal Code'
	UNION
		SELECT k = 'sign-up--billing.continue',
			es = 'Continuar',
			en = 'Continue'
	UNION
		SELECT k = 'sign-up--confirm-pending.page.title',
			es = 'Verificación por correo',
			en = 'Check your e-mail inbox'
	UNION
		SELECT k = 'sign-up--confirm-pending.page.subtitle',
			es = 'Hemos enviado por correo electrónico un código de verificación. Utilice el link del correo o coloque el código aquí para finalizar su registro.',
			en = 'We have sent you a verification code to your e-mail inbox. Use the link from the e-mail or just type the verification code here.'
	UNION
		SELECT k = 'sign-up--confirm-pending.verificationCode',
			es = 'Código de Verificación',
			en = 'Verification Code'
	UNION
		SELECT k = 'sign-up--confirm-pending.validate',
			es = 'Validar',
			en = 'Validate'
	UNION
		SELECT k = 'menu.platform.configuration-menu',
			es = 'Configuración',
			en = 'Configuration'
	UNION
		SELECT k = 'menu.platform.configuration.sample-type',
			es = 'Gestión de Tipos de Muestra',
			en = 'Sample Types Management'
	UNION
		SELECT k = 'menu.platform.configuration.sample-type-parameter',
			es = 'Parámetros de tipos de muestra',
			en = 'Sample Type Parameters'
	UNION
		SELECT k = 'menu.platform.configuration.sample-function',
			es = 'Funciones de Muestra',
			en = 'Sample Functions Management'
	UNION
		SELECT k = 'menu.platform.configuration.language',
			es = 'Gestión de Idiomas',
			en = 'Languages Management'
	UNION
		SELECT k = 'menu.platform.configuration.clients-and-billing',
			es = 'Clientes y Facturación',
			en = 'Clients and Billing'
	UNION
		SELECT k = 'menu.platform.security-menu',
			es = 'Seguridad',
			en = 'Security'
	UNION
		SELECT k = 'menu.platform.security.user',
			es = 'Gestión de Usuarios',
			en = 'Users Management'
	UNION
		SELECT k = 'menu.platform.security.role',
			es = 'Gestión de Roles',
			en = 'Security Roles Management'
	UNION
		SELECT k = 'menu.platform.security.logging',
			es = 'Bitácora',
			en = 'Logs'
	UNION
		SELECT k = 'menu.platform.security.backup',
			es = 'Resguardos',
			en = 'Backups'
	UNION
		SELECT k = 'menu.platform.security.parameters',
			es = 'Parametrización',
			en = 'System Parameters'
	UNION
		SELECT k = 'menu.platform.inventory-menu',
			es = 'Inventario',
			en = 'Inventory'
	UNION
		SELECT k = 'menu.platform.inventory.patient',
			es = 'Gestión de Pacientes',
			en = 'Patients Management'
	UNION
		SELECT k = 'menu.platform.inventory.sample',
			es = 'Gestión de Muestras',
			en = 'Samples Management'
	UNION
		SELECT k = 'menu.platform.management-menu',
			es = 'Gestión',
			en = 'Management'
	UNION
		SELECT k = 'menu.platform.marketing-menu',
			es = 'Investigación de Marketing',
			en = 'Marketing Research'
	UNION
		SELECT k = 'menu.platform.management.members',
			es = 'Usuarios Miembro',
			en = 'Member Users'
	UNION
		SELECT k = 'menu.platform.management.payment-type',
			es = 'Formas de Pago',
			en = 'Payment Method'
	UNION
		SELECT k = 'menu.platform.management.billing',
			es = 'Facturación',
			en = 'Billing'
	UNION
		SELECT k = 'menu.platform.work-order-menu',
			es = 'Órdenes de Trabajo',
			en = 'Work Orders'
	UNION
		SELECT k = 'menu.platform.work-order.batches',
			es = 'Lotes de Ejecución',
			en = 'Batch Executions'
	UNION
		SELECT k = 'menu.platform.work-order.runs',
			es = 'Ejecuciones de Ensayo',
			en = 'Run Executions'
	UNION
		SELECT k = 'menu.platform.sign-out',
			es = 'Cerrar Sesión',
			en = 'Sign Out'
	UNION
		SELECT k = 'configuration.language.language',
			es = 'Seleccionar el Idioma',
			en = 'Pick a Language'
	UNION
		SELECT k = 'configuration.language.edit',
			es = 'Editar',
			en = 'Edit'
	UNION
		SELECT k = 'configuration.language.grid.key',
			es = 'Clave',
			en = 'Key'
	UNION
		SELECT k = 'configuration.language.grid.translation',
			es = 'Traducción',
			en = 'Translation'
	UNION
		SELECT k = 'configuration.editLanguageEntry.title',
			es = 'Editar Clave de Diccionario',
			en = 'Edit Dictionary Key'
	UNION
		SELECT k = 'configuration.editLanguageEntry.key',
			es = 'Clave',
			en = 'Key'
	UNION
		SELECT k = 'configuration.editLanguageEntry.translation',
			es = 'Traducción',
			en = 'Translation'
	UNION
		SELECT k = 'configuration.editLanguageEntry.confirm',
			es = 'Confirmar',
			en = 'Confirm'
	UNION
		SELECT k = 'configuration.editLanguageEntry.cancel',
			es = 'Cancelar',
			en = 'Cancel'
	UNION
		SELECT k = 'security.listRoles.refresh',
			es = 'Refrescar',
			en = 'Refresh'
	UNION
		SELECT k = 'security.listRoles.new',
			es = 'Nuevo',
			en = 'New'
	UNION
		SELECT k = 'security.listRoles.edit',
			es = 'Editar',
			en = 'Edit'
	UNION
		SELECT k = 'security.listRoles.enable',
			es = 'Habilitar',
			en = 'Enable'
	UNION
		SELECT k = 'security.listRoles.disable',
			es = 'Inhabilitar',
			en = 'Disable'
	UNION
		SELECT k = 'security.listRoles.delete',
			es = 'Eliminar',
			en = 'Delete'
	UNION
		SELECT k = 'security.listRoles.export',
			es = 'Exportar',
			en = 'Export'
	UNION
		SELECT k = 'security.listRoles.grid.id',
			es = 'Id',
			en = 'Id'
	UNION
		SELECT k = 'security.listRoles.grid.name',
			es = 'Nombre',
			en = 'Name'
	UNION
		SELECT k = 'security.listRoles.grid.quantityOfUsers',
			es = '# de Usuarios',
			en = '# of Users'
	UNION
		SELECT k = 'security.listRoles.grid.quantityOfPermissions',
			es = '# de Permisos',
			en = '# of Permissions'
	UNION
		SELECT k = 'security.listRoles.grid.isEnabled',
			es = 'Habilitado',
			en = 'Enabled'
	UNION
		SELECT k = 'security.editRole.title.new',
			es = 'Nuevo Rol de Seguridad',
			en = 'New Security Role'
	UNION
		SELECT k = 'security.editRole.title.edit',
			es = 'Editar Rol de Seguridad',
			en = 'Edit Security Role'
	UNION
		SELECT k = 'security.editRole.name',
			es = 'Nombre del Rol',
			en = 'Role name'
	UNION
		SELECT k = 'security.editRole.grid.id',
			es = 'Id',
			en = 'Id'
	UNION
		SELECT k = 'security.editRole.grid.code',
			es = 'Código',
			en = 'Code'
	UNION
		SELECT k = 'security.editRole.grid.name',
			es = 'Nombre',
			en = 'Name'
	UNION
		SELECT k = 'security.editRole.confirm',
			es = 'Confirmar',
			en = 'Confirm'
	UNION
		SELECT k = 'about-us.title',
			es = 'Sobre Nosotros',
			en = 'About Us'
	UNION
		SELECT k = 'about-us.text',
			es = 'Somos la plataforma de gestión de muestras clínicas y ensayos de investigación número uno del mercado. Nuestro compromiso constante con la calidad y con nuestros clientes nos diferencia en el mercado.',
			en = 'We are the research contract organization platform number one of the market. Our constant commitment to quality and to our clients is our differentiator in the CRO software landscape.'
	UNION
		SELECT k = 'about-us.contact',
			es = 'Contacto',
			en = 'Contact'
	UNION
		SELECT k = 'about-us.address',
			es = 'Av. Paseo Colón 524, 1er Piso',
			en = '524 Paseo Colón Aveneu, 1st floor'
	UNION
		SELECT k = 'validator.ui.mandatory-string-spec',
			es = 'El campo ${propLabel} no puede ser vacio.',
			en = 'The field ${propLabel} cannot be empty.'
	UNION
		SELECT k = 'validator.ui.email-spec',
			es = 'El campo ${propLabel} no cumple con las reglas indicadas.',
			en = 'The field ${propLabel} is not a valid e-mail address.'
	UNION
		SELECT k = 'validator.ui.is-number-spec',
			es = 'El campo ${propLabel} debe ser numérico.',
			en = 'The field ${propLabel} must have a numeric value.'
	UNION
		SELECT k = 'validator.ui.mandatory-selection-spec',
			es = 'El campo ${propLabel} es obligatorio.',
			en = 'The field ${propLabel} selection is mandatory.'
	UNION
		SELECT k = 'validator.ui.password-strength-spec',
			es = 'El campo ${propLabel} no cumple con las reglas indicadas.',
			en = 'The field ${propLabel} does not comply with the indicated rules.'
	UNION
		SELECT k = 'validator.ui.string-max-length-spec',
			es = 'El campo ${propLabel} no puede superar los ${maxLength} caracteres.',
			en = 'The field ${propLabel} cannot have more than ${maxLength} characters.'
	UNION
		SELECT k = 'validator.ui.string-min-length-spec',
			es = 'El campo ${propLabel} debe superar los ${minLength} caracteres.',
			en = 'The field ${propLabel} cannot have less than ${minLength} characters.'
	UNION
		SELECT k = 'spinner.please-wait',
			es = 'Por favor espere...',
			en = 'Please wait...'
	UNION
		SELECT k = 'tos.title',
			es = 'Términos y Condiciones de uso de Sample Supply Chain',
			en = 'Terms of Service for Sample Supply Chain'
	UNION
		SELECT k = 'tos.text-intro',
			es = 'Esta Web pertenece a la Empresa HAVOK INTERNATIONAL S.R.L. (en adelante LA EMPRESA) y su acceso y utilización está sujeta a la aceptación y cumplimiento de los términos y condiciones que se exponen a continuación:',
			en = 'This website belongs to HAVOK INTERNATIONAL S.R.L. (from now on THE COMPANY) and its access and utilization is subject to acceptance and fullfilling of the terms and conditions exposed here:'
	UNION
		SELECT k = 'tos.text-01.title',
			es = '1. LA RESPONSABILIDAD',
			en = '1. RESPONSIBILITY'
	UNION
		SELECT k = 'tos.text-01.txt',
			es = 'LA EMPRESA se reserva el derecho de modificar en forma unilateral, sin mediar previo aviso, ni comunicación al USUARIO y/o VISITANTE, estos Términos y Condiciones, el diseño, la presentación o su configuración, los servicios ofrecidos, los requisitos de registro o de utilización de la página, sin que ello genere derecho a reclamo o indemnización alguna en favor del USUARIO y/o VISITANTE.\n\n
La utilización de los servicios y/o herramientas digitales, existentes en la página, requerirán del USUARIO y/o VISITANTE la aceptación de términos y condiciones que completan las previsiones contenidas en la presente en cuanto no se opongan a ellas. \n\n
LA EMPRESA no se responsabilizará por la existencia, actualización, veracidad, privacidad, funcionamiento, modificaciones, contenidos, ofertas y legalidad de los sitios de terceros vinculados a través del presente sitio web. LA EMPRESA no será responsable por las transacciones efectuadas entre el USUARIO y/o VISITANTE y los sitios con vínculos de la página. \n\n
El USUARIO y/o VISITANTE no podrá, remover, eliminar, aumentar, añadir, ni de cualquier otra forma modificar total o parcialmente el Contenido. Tampoco  podrá volcar términos o utilizar expresiones injuriosas, intimidatorias, calumniantes o contrarias a las buenas costumbres. No podrá transmitir información o material que pueda, concreta o eventualmente, violar derechos de un tercero o que contenga virus o cualquier otro componente dañino. \n\n
LA EMPRESA se reserva el derecho de extraer y editar en su totalidad o de manera fraccionada, cualquier mensaje o material suscripto o remitido por el USUARIO y/o VISITANTE. Así mismo, el USUARIO y/o VISITANTE garantiza a LA EMPRESA el permiso para la utilización de cualquier información, sugerencia, idea, dibujo o concepto vertido, con el propósito que LA EMPRESA la utilice para la obtención de información estadística que permita mejorar el servicio, sin ningún derecho de compensación en favor del USUARIO y/o VISITANTE.\n\n
El USUARIO y/o VISITANTE se obliga a usar el Sitio de conformidad con estos Términos y Condiciones, en forma diligente, correcta y lícita, y conforme con la moral y las buenas costumbres. El USUARIO y/o VISITANTE responderá por los daños y perjuicios de toda naturaleza que LA EMPRESA pueda sufrir, directa o indirectamente, como consecuencia del incumplimiento de cualquiera de las obligaciones derivadas de estos Términos y Condiciones. \n\n
LA EMPRESA podrá suspender transitoriamente o finalizar la publicación de la página sin aviso previo y en cualquier momento, sin que ello genere derecho a indemnización alguna en favor del USUARIO y/o VISITANTE.\n\n
El USUARIO y/o VISITANTE reconoce y acepta que el uso de esta página es bajo su propio y exclusivo riesgo. \n\n
El USUARIO y/o VISITANTE reconoce y acepta que ni LA EMPRESA, ni los directores, empleados o representantes de cualquiera de ellos, es responsable por daños que surjan de o resulten del uso de esta página, incluyendo cualquier error, omisión, interrupción, falla, eliminación de archivos o correos electrónicos (e-mails), defectos, virus, y/o demoras en la operación o transmisión y/o de cualquier otro tipo. \n\n
La página puede ser utilizada por el USUARIO y/o VISITANTE en forma totalmente libre y gratuita.',
			en = 'LA EMPRESA se reserva el derecho de modificar en forma unilateral, sin mediar previo aviso, ni comunicación al USUARIO y/o VISITANTE, estos Términos y Condiciones, el diseño, la presentación o su configuración, los servicios ofrecidos, los requisitos de registro o de utilización de la página, sin que ello genere derecho a reclamo o indemnización alguna en favor del USUARIO y/o VISITANTE.\n\n
La utilización de los servicios y/o herramientas digitales, existentes en la página, requerirán del USUARIO y/o VISITANTE la aceptación de términos y condiciones que completan las previsiones contenidas en la presente en cuanto no se opongan a ellas. \n\n
LA EMPRESA no se responsabilizará por la existencia, actualización, veracidad, privacidad, funcionamiento, modificaciones, contenidos, ofertas y legalidad de los sitios de terceros vinculados a través del presente sitio web. LA EMPRESA no será responsable por las transacciones efectuadas entre el USUARIO y/o VISITANTE y los sitios con vínculos de la página. \n\n
El USUARIO y/o VISITANTE no podrá, remover, eliminar, aumentar, añadir, ni de cualquier otra forma modificar total o parcialmente el Contenido. Tampoco  podrá volcar términos o utilizar expresiones injuriosas, intimidatorias, calumniantes o contrarias a las buenas costumbres. No podrá transmitir información o material que pueda, concreta o eventualmente, violar derechos de un tercero o que contenga virus o cualquier otro componente dañino. \n\n
LA EMPRESA se reserva el derecho de extraer y editar en su totalidad o de manera fraccionada, cualquier mensaje o material suscripto o remitido por el USUARIO y/o VISITANTE. Así mismo, el USUARIO y/o VISITANTE garantiza a LA EMPRESA el permiso para la utilización de cualquier información, sugerencia, idea, dibujo o concepto vertido, con el propósito que LA EMPRESA la utilice para la obtención de información estadística que permita mejorar el servicio, sin ningún derecho de compensación en favor del USUARIO y/o VISITANTE.\n\n
El USUARIO y/o VISITANTE se obliga a usar el Sitio de conformidad con estos Términos y Condiciones, en forma diligente, correcta y lícita, y conforme con la moral y las buenas costumbres. El USUARIO y/o VISITANTE responderá por los daños y perjuicios de toda naturaleza que LA EMPRESA pueda sufrir, directa o indirectamente, como consecuencia del incumplimiento de cualquiera de las obligaciones derivadas de estos Términos y Condiciones. \n\n
LA EMPRESA podrá suspender transitoriamente o finalizar la publicación de la página sin aviso previo y en cualquier momento, sin que ello genere derecho a indemnización alguna en favor del USUARIO y/o VISITANTE.\n\n
El USUARIO y/o VISITANTE reconoce y acepta que el uso de esta página es bajo su propio y exclusivo riesgo. \n\n
El USUARIO y/o VISITANTE reconoce y acepta que ni LA EMPRESA, ni los directores, empleados o representantes de cualquiera de ellos, es responsable por daños que surjan de o resulten del uso de esta página, incluyendo cualquier error, omisión, interrupción, falla, eliminación de archivos o correos electrónicos (e-mails), defectos, virus, y/o demoras en la operación o transmisión y/o de cualquier otro tipo. \n\n
La página puede ser utilizada por el USUARIO y/o VISITANTE en forma totalmente libre y gratuita.'
	UNION
		SELECT k = 'tos.text-02.title',
			es = '2. SITIOS ENLAZADOS',
			en = '2. LINKED WEBSITES'
	UNION
		SELECT k = 'tos.text-02.txt',
			es = 'A través de la presente página se pone a su disposición dispositivos técnicos de enlace (tales como, entre otros, links, banners, botones), directorios y herramientas de búsqueda que les permiten acceder a páginas web pertenecientes a terceros (en adelante los “SITIOS ENLAZADOS”). La instalación de estos enlaces en las páginas de LA EMPRESA se limita a facilitar a los USUARIO y/o VISITANTE, la búsqueda y acceso, a la información disponible de los sitios enlazados en Internet, y no presupone que existe ninguna clase de vínculo o asociación entre LA EMPRESA, sus subsidiarias o afiliadas y los operadores de los sitios enlazados. LA EMPRESA no controla, ni hacen propios los servicios, información, datos, archivos, productos y cualquier clase de material existente en los sitios enlazados. Por lo tanto, el USUARIO y/o VISITANTE, debe extremar la prudencia en la valoración y utilización de los servicios, información, datos, archivos, productos y cualquier clase de material existente en los sitios enlazados. \n\n
LA EMPRESA no garantiza ni asume responsabilidad alguna por los daños y perjuicios que de cualquier naturaleza pueda causarse por: \n\n
a) El funcionamiento, disponibilidad, accesibilidad o continuidad de sitios enlazados. \n\n
b) El mantenimiento de los servicios, información, datos, archivos, productos y cualquier clase de material existente en los sitios enlazados. \n\n
c) Las obligaciones y ofertas existentes en los sitios enlazados.',
			en = 'A través de la presente página se pone a su disposición dispositivos técnicos de enlace (tales como, entre otros, links, banners, botones), directorios y herramientas de búsqueda que les permiten acceder a páginas web pertenecientes a terceros (en adelante los “SITIOS ENLAZADOS”). La instalación de estos enlaces en las páginas de LA EMPRESA se limita a facilitar a los USUARIO y/o VISITANTE, la búsqueda y acceso, a la información disponible de los sitios enlazados en Internet, y no presupone que existe ninguna clase de vínculo o asociación entre LA EMPRESA, sus subsidiarias o afiliadas y los operadores de los sitios enlazados. LA EMPRESA no controla, ni hacen propios los servicios, información, datos, archivos, productos y cualquier clase de material existente en los sitios enlazados. Por lo tanto, el USUARIO y/o VISITANTE, debe extremar la prudencia en la valoración y utilización de los servicios, información, datos, archivos, productos y cualquier clase de material existente en los sitios enlazados. \n\n
LA EMPRESA no garantiza ni asume responsabilidad alguna por los daños y perjuicios que de cualquier naturaleza pueda causarse por: \n\n
a) El funcionamiento, disponibilidad, accesibilidad o continuidad de sitios enlazados. \n\n
b) El mantenimiento de los servicios, información, datos, archivos, productos y cualquier clase de material existente en los sitios enlazados. \n\n
c) Las obligaciones y ofertas existentes en los sitios enlazados.'
	UNION
		SELECT k = 'tos.text-03.title',
			es = '3. POLÍTICA DE PRIVACIDAD',
			en = '3. PRIVACY POLICY'
	UNION
		SELECT k = 'tos.text-03.txt',
			es = 'La utilización e ingreso a la presente página web de LA EMPRESA, será considerado como aceptación de los términos de esta Política de Privacidad por parte del USUARIO y/o VISITANTE. \n\n
Los datos personales que el USUARIO y/o VISITANTE brinde libre y voluntariamente a LA EMPRESA, tales como nombres, correo electrónico, DNI, teléfono y/o número de legajo, y/o cualquier otro que voluntariamente suministre a LA EMPRESA cuando ello sea necesario para brindarle un servicio específico, son incluidos en archivos automatizados, procesados bajo normas de estricta confidencialidad y protección de datos. \n\n
El USUARIO y/o VISITANTE podrá brindar información con respecto a sus gustos, evaluaciones y preferencias. LA EMPRESA utilizará dicha información para elaborar publicidad y/o perfeccionar el servicio brindado.\n\n
No obstante lo anterior y en cumplimiento con las leyes aplicables, LA EMPRESA coopera con las autoridades gubernamentales nacionales, provinciales y municipales, e internacionales en cualquier investigación en relación con el contenido, ya sean personales o privadas, transmitidas a LA EMPRESA a través de este Sitio.',
			en = 'La utilización e ingreso a la presente página web de LA EMPRESA, será considerado como aceptación de los términos de esta Política de Privacidad por parte del USUARIO y/o VISITANTE. \n\n
Los datos personales que el USUARIO y/o VISITANTE brinde libre y voluntariamente a LA EMPRESA, tales como nombres, correo electrónico, DNI, teléfono y/o número de legajo, y/o cualquier otro que voluntariamente suministre a LA EMPRESA cuando ello sea necesario para brindarle un servicio específico, son incluidos en archivos automatizados, procesados bajo normas de estricta confidencialidad y protección de datos. \n\n
El USUARIO y/o VISITANTE podrá brindar información con respecto a sus gustos, evaluaciones y preferencias. LA EMPRESA utilizará dicha información para elaborar publicidad y/o perfeccionar el servicio brindado.\n\n
No obstante lo anterior y en cumplimiento con las leyes aplicables, LA EMPRESA coopera con las autoridades gubernamentales nacionales, provinciales y municipales, e internacionales en cualquier investigación en relación con el contenido, ya sean personales o privadas, transmitidas a LA EMPRESA a través de este Sitio.'
	UNION
		SELECT k = 'tos.text-04.title',
			es = '4. TERMINACIÓN DEL ACCESO',
			en = '4. ACCESS TERMINATION'
	UNION
		SELECT k = 'tos.text-04.txt',
			es = 'LA EMPRESA podrá, en cualquier momento, terminar o suspender el acceso que el USUARIO y/o VISITANTE tenga a todo o parte de este sitio, sin aviso previo, y sin que ello genere derecho a reclamo o indemnización alguna. Ni la terminación o suspensión del acceso, ni cualquier acción o inacción del USUARIO y/o VISITANTE, terminará las disposiciones de estos Términos y Condiciones, los que permanecerán en plena fuerza y vigor de forma indefinida, sujetas sólo a cualquier cambio que LA EMPRESA efectúe. ',
			en = 'LA EMPRESA podrá, en cualquier momento, terminar o suspender el acceso que el USUARIO y/o VISITANTE tenga a todo o parte de este sitio, sin aviso previo, y sin que ello genere derecho a reclamo o indemnización alguna. Ni la terminación o suspensión del acceso, ni cualquier acción o inacción del USUARIO y/o VISITANTE, terminará las disposiciones de estos Términos y Condiciones, los que permanecerán en plena fuerza y vigor de forma indefinida, sujetas sólo a cualquier cambio que LA EMPRESA efectúe. '
	UNION
		SELECT k = 'tos.text-05.title',
			es = '5. VIOLACIONES DEL SISTEMA O BASES DE DATOS',
			en = '5. SYSTEM OR DATABASE VIOLATIONS'
	UNION
		SELECT k = 'tos.text-05.txt',
			es = 'Es ilícita cualquier acción o uso de dispositivos, software, u otros instrumentos tendientes a interferir tanto en las actividades y operatoria de LA EMPRESA, así como en las ofertas, descripciones, cuentas o bases de datos de LA EMPRESA. Cualquier intromisión, tentativa o actividad violatoria o contraria a las leyes sobre derechos de propiedad intelectual, seguridad de los sistemas, y/o a las prohibiciones estipuladas en este documento harán pasible a su responsable de las acciones legales pertinentes, y a las sanciones previstas por este acuerdo.',
			en = 'Es ilícita cualquier acción o uso de dispositivos, software, u otros instrumentos tendientes a interferir tanto en las actividades y operatoria de LA EMPRESA, así como en las ofertas, descripciones, cuentas o bases de datos de LA EMPRESA. Cualquier intromisión, tentativa o actividad violatoria o contraria a las leyes sobre derechos de propiedad intelectual, seguridad de los sistemas, y/o a las prohibiciones estipuladas en este documento harán pasible a su responsable de las acciones legales pertinentes, y a las sanciones previstas por este acuerdo.'
	UNION
		SELECT k = 'tos.text-06.title',
			es = '6. JURISDICCIÓN',
			en = '6. JURISDICTION'
	UNION
		SELECT k = 'tos.text-06.txt',
			es = 'Es ilícita cualquier acción o uso de dispositivos, software, u otros instrumentos tendientes a interferir tanto en las actividades y operatoria de LA EMPRESA, así como en las ofertas, descripciones, cuentas o bases de datos de LA EMPRESA. Cualquier intromisión, tentativa o actividad violatoria o contraria a las leyes sobre derechos de propiedad intelectual, seguridad de los sistemas, y/o a las prohibiciones estipuladas en este documento harán pasible a su responsable de las acciones legales pertinentes, y a las sanciones previstas por este acuerdo.',
			en = 'Es ilícita cualquier acción o uso de dispositivos, software, u otros instrumentos tendientes a interferir tanto en las actividades y operatoria de LA EMPRESA, así como en las ofertas, descripciones, cuentas o bases de datos de LA EMPRESA. Cualquier intromisión, tentativa o actividad violatoria o contraria a las leyes sobre derechos de propiedad intelectual, seguridad de los sistemas, y/o a las prohibiciones estipuladas en este documento harán pasible a su responsable de las acciones legales pertinentes, y a las sanciones previstas por este acuerdo.'
	UNION
		SELECT k = 'app.marketing.menu.tos',
			es = 'Términos y Servicios',
			en = 'Terms of Service'
	UNION
		SELECT k = 'security.role.field.name',
			es = 'Nombre',
			en = 'Name'
	UNION
		SELECT k = 'security.role.field.permissions',
			es = 'Permisos',
			en = 'Permissions'
	UNION
		SELECT k = 'validator.api.mandatory-string',
			es = 'El campo {0} es obligatorio.',
			en = 'The field {0} is mandatory.'
	UNION
		SELECT k = 'validator.api.max-string-length',
			es = 'El campo {0} supera los {1} caracteres.',
			en = 'The field {0} character length should be at most {1} characters.'
	UNION
		SELECT k = 'validator.api.min-string-length',
			es = 'El campo {0} debe tener al menos {1} caracteres.',
			en = 'The field {0} character length should be at least {1} characters.'
	UNION
		SELECT k = 'validator.api.valid-email-address',
			es = 'El campo {0} no es un correo electrónico válido.',
			en = 'The field {0} is not a valid email.'
	UNION
		SELECT k = 'validator.api.not-null',
			es = 'El campo {0} no puede ser vacío.',
			en = 'The field {0} cannot be empty.'
	UNION
		SELECT k = 'validator.api.mandatory-dropdown-selection',
			es = 'El campo {0} es obligatorio.',
			en = 'The field {0} is mandatory.'
	UNION
		SELECT k = 'validator.api.is-number',
			es = 'El campo {0} no es un número válido.',
			en = 'The field {0} is not a valid number.'
	UNION
		SELECT k = 'validator.api.date-format',
			es = 'El campo {0} no tiene el formato de fecha esperado "{1}".',
			en = 'The field {0} does not present the expected date format "{1}".'
	UNION
		SELECT k = 'validator.api.list-not-empty',
			es = 'Debe seleccionar al menos un elemento para el campo {0}.',
			en = 'You must select at least one element for field {0}.'
	UNION
		SELECT k = 'email.verification-email.subject',
			es = 'Verifique su cuenta de SSC',
			en = 'Verify your account at SSC'
	UNION
		SELECT k = 'validator.ui.sign-up--verify-failed',
			es = 'No se pudo verificar la cuenta.',
			en = 'The account could not be verified.'
	UNION
		SELECT k = 'validator.ui.sign-up--verify-success',
			es = 'Su cuenta ha sido verificada. Puede ahora ingresar a la plataforma Sample Supply Chain.',
			en = 'Your account has been verified. You can now enter the Sample Supply Chain platform.'
	UNION
		SELECT k = 'email.welcome-email.subject',
			es = 'Bienvenido a SSC',
			en = 'Welcome to SSC'
	UNION
		SELECT k = 'forgot-password.submit-message',
			es = 'Se ha enviado un correo electrónico a la cuenta indicada. Siga los pasos para recuperar su cuenta.',
			en = 'An email has been sent to the indicated account. Follow the steps indicated to recover your password.'
	UNION
		SELECT k = 'forgot-password.page.title',
			es = 'Recuperar contraseña',
			en = 'Recover your password'
	UNION
		SELECT k = 'forgot-password.recover-password',
			es = 'Recuperar contraseña',
			en = 'Recover password'
	UNION
		SELECT k = 'forgot-password.validation.user-not-exists',
			es = 'El usuario indicado no existe en la plataforma. Verifique el e-mail ingresado',
			en = 'The indicated user does not exist in the platform. Verify the e-mail input.'
	UNION
		SELECT k = 'forgot-password.validation.user-not-enabled',
			es = 'El usuario se encuentra deshabilitado. Si considera que esto es un error contacte a nuestra Mesa de Ayuda.',
			en = 'The user is disabled. If you consider this to be a mistake please contact our Help Desk.'
	UNION
		SELECT k = 'email.forgot-password.subject',
			es = 'Recupere su contraseña en SSC',
			en = 'Recover your SSC password'
) AS data
CROSS JOIN		SystemLanguage SL
	LEFT JOIN SystemLanguageEntry SLE
	ON		sle.SystemLanguageId = sl.Id
		AND sle.EntryKey = data.k

WHERE			sle.EntryKey IS NULL
	AND data.k <> ''

-- System Language Entries (Initial - Spanish) - Part 2
INSERT SystemLanguageEntry
	(
	SystemLanguageId,
	EntryKey,
	Translation,
	CreatedBy,
	UpdatedBy
	)
SELECT
	SystemLanguageId = sl.Id,
	EntryKey = data.k,
	Translation = (CASE WHEN sl.Code = 'es' THEN data.es ELSE data.en END),
	CreatedBy = 1,
	UpdatedBy = 1
FROM (
													SELECT k = 'forgot-password.token-invalid',
			es = 'No se pudo validar su pedido de blanquear la contraseña. Por favor, vuelva a intentarlo.',
			en = 'We could not validate your password reset request. Please, try again.'
	UNION
		SELECT k = 'forgot-password.password-reset-success',
			es = 'La contraseña ha sido cambiada con éxito.',
			en = 'Password reset has been a success.'
	UNION
		SELECT k = 'forgot-password.password-mismatch',
			es = 'Las contraseñas no coinciden.',
			en = 'Passwords do not match.'
	UNION
		SELECT k = 'recover-password.page.title',
			es = 'Recupere su contraseña',
			en = 'Recover your password'
) AS data
CROSS JOIN		SystemLanguage SL
	LEFT JOIN SystemLanguageEntry SLE
	ON		sle.SystemLanguageId = sl.Id
		AND sle.EntryKey = data.k

WHERE			sle.EntryKey IS NULL
	AND data.k <> ''

-- More Language Entries
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.grid.id',
	@es = 'Id',
	@en = 'Id'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.grid.clientName',
	@es = 'Cliente',
	@en = 'Client'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.grid.userName',
	@es = 'Cuenta',
	@en = 'Account'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.grid.isDisabled',
	@es = 'Deshabilitado',
	@en = 'Disabled'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.grid.isBlocked',
	@es = 'Bloqueado',
	@en = 'Blocked'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.grid.countOfRoles',
	@es = '# de Roles',
	@en = '# of Roles'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.grid.countOfPermissions',
	@es = '# de Permisos',
	@en = '# of Permissions'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.grid.isPlatformAdmin',
	@es = 'Es Administrador',
	@en = 'Is Admin'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.isDisabled.true',
	@es = 'No Habilitado',
	@en = 'Disabled'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.isDisabled.false',
	@es = 'Habilitado',
	@en = 'Enabled'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.isBlocked.true',
	@es = 'Bloqueado',
	@en = 'Blocked'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.isAdmin.true',
	@es = 'Sí',
	@en = 'Yes'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.refresh',
	@es = 'Ejecutar',
	@en = 'Execute'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.new',
	@es = 'Nuevo',
	@en = 'New'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.edit',
	@es = 'Editar',
	@en = 'Edit'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.enable',
	@es = 'Habilitar',
	@en = 'Enable'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.disable',
	@es = 'Deshabilitar',
	@en = 'Disable'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listUsers.delete',
	@es = 'Eliminar',
	@en = 'Delete'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'user-business.create.exists',
	@es = 'El nombre de usuario {0} ya existe.',
	@en = 'The username {0} is already taken.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.user.username',
	@es = 'Nombre de usuario',
	@en = 'UserName'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'user-model.create.company-or-role',
	@es = 'El cliente es obligatorio o el usuario debe ser especificado como usuario de la plataforma.',
	@en = 'The client is mandatory or the user must have a platform role.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.editUser.title.edit',
	@es = 'Editar Usuario',
	@en = 'Edit User'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.editUser.title.new',
	@es = 'Nuevo Usuario',
	@en = 'New User'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.editUser.confirm',
	@es = 'Confirmar',
	@en = 'Confirm'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.user.clientCompany',
	@es = 'Cliente',
	@en = 'Client'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'welcome-text',
	@es = 'Bienvenido a Sample Supply Chain',
	@en = 'Welcome to Sample Supply Chain'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'event-type.info',
	@es = 'Información',
	@en = 'Information'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'event-type.error',
	@es = 'Error',
	@en = 'Error'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listLogs.grid.id',
	@es = 'Id',
	@en = 'Id'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listLogs.grid.createddate',
	@es = 'Fecha de Registro',
	@en = 'Log Date'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listLogs.grid.user',
	@es = 'Usuario',
	@en = 'User'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listLogs.grid.event-type',
	@es = 'Tipo de Evento',
	@en = 'Event Type'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listLogs.grid.message',
	@es = 'Mensaje',
	@en = 'Message'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listLogs.refresh',
	@es = 'Refrescar',
	@en = 'Refresh'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.listLogs.read',
	@es = 'Consultar',
	@en = 'Read'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.read-log.title',
	@es = 'Registro de Bitácora',
	@en = 'Log Record'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.read-log.event-type-description',
	@es = 'Tipo de Evento',
	@en = 'Event Type'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.read-log.date',
	@es = 'Fechad el Evento',
	@en = 'Event Date'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.read-log.user',
	@es = 'Usuario',
	@en = 'User'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.read-log.client-id',
	@es = 'Id del Cliente',
	@en = 'Client Id'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.read-log.message',
	@es = 'Mensaje',
	@en = 'Message'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'contact-us.title',
	@es = 'Contactate con nosotros',
	@en = 'Contact Us'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'contact-us.text',
	@es = 'A continuación te mostramos las formas de contacto con Sample Supply Chain.',
	@en = 'Below you will find all the contact information you need to get in touch with Sample Supply Chain.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'app.marketing.menu.contact-us',
	@es = 'Contacto',
	@en = 'Contact Us'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'privacy-policy.title',
	@es = 'Políticas de Privacidad y Seguridad',
	@en = 'Privacy and Security Policies'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'privacy-policy.text-intro',
	@es = 'En cumplimiento con lo establecido por la Ley Federal de Transparencia y Acceso a la Información Pública Gubernamental le informamos nuestra política de privacidad y manejo de datos personales y hacemos el siguiente compromiso:',
	@en = 'In compliance with the provisions of the Federal Law on Transparency and Access to Government Public Information, we inform you of our privacy and personal data management policy and make the following commitment:'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'privacy-policy.text-01.txt',
	@es = 'Reunimos información de carácter no personal, como el tipo de explorador, sistema operativo y página Web visitadas, con el objeto de contribuir a la administración de nuestros sitios Web.',
	@en = 'We collect non-personal information, such as the type of browser, operating system and Web page visited, in order to contribute to the administration of our Web sites.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'privacy-policy.text-02.txt',
	@es = 'Utilizamos cookies y otras tecnologías de Internet para administrar nuestro sitio Web y nuestros programas de correo electrónico, pero no para reunir o almacenar información personal.',
	@en = 'We use cookies and other Internet technologies to manage our website and our email programs, but not to collect or store personal information.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'privacy-policy.text-03.txt',
	@es = 'Los datos que le solicitamos en los formularios de contacto, red social o cualquier tipo de formulario colocado dentro de nuestro Sitio Web únicamente serán utilizados para  poder establecer contacto con usted en relación a su petición o comentario.',
	@en = 'The data that we request in the contact forms, social network or any type of form placed within our Website will only be used to establish contact with you in relation to your request or comment.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'privacy-policy.text-04.txt',
	@es = 'Los datos que ingrese en cualquiera de los formularios dentro del Sitio Web no serán difundidos, distribuidos o comercializados.',
	@en = 'The data that you enter in any of the forms within the Website will not be disseminated, distributed or commercialized.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'privacy-policy.text-05.txt',
	@es = 'En caso de que desee ser removido de nuestra base de datos podrá, en cualquier momento, solicitar la baja de la información mediante correo electrónico a admin@ssc.com, o por escrito a la siguiente dirección: Av. Paseo Colón 524, Capital Federal, Argentina.',
	@en = 'If you wish to be removed from our database, you may, at any time, request the withdrawal of the information by email to admin@ssc.com, or in writing to the following address: Av. Paseo Colón 524, Federal Capital, Argentina.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'privacy-policy.text-06.txt',
	@es = 'Su petición o comentario puede ser incluido dentro de los informes estadísticos que se elaboren para el seguimiento de avances institucionales del Gobierno Federal. No obstante, dichos informes serán meramente estadísticos y no incluirán información que permita identificarle en lo individual. ',
	@en = 'Your request or comment can be included in the statistical reports that are prepared for the monitoring of institutional advances of the Federal Government. However, these reports will be purely statistical and will not include information to identify you individually.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'app.marketing.menu.privacy-policy',
	@es = 'Políticas de Privacidad',
	@en = 'Privacy Policy'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.is-enabled.enabled',
	@es = 'Habilitado',
	@en = 'Enabled'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.is-enabled.disabled',
	@es = 'Deshabilitado',
	@en = 'Disabled'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.id',
	@es = 'Id',
	@en = 'Id'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.code',
	@es = 'Código',
	@en = 'Code'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.description',
	@es = 'Descripción',
	@en = 'Description'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.model.sample-parameter-type.data-type-name',
	@es = 'Tipo de Dato',
	@en = 'Data Type'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.model.sample-parameter-type.minimum-range',
	@es = 'Rango Mínimo',
	@en = 'Minimum Range'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.model.sample-parameter-type.maximum-range',
	@es = 'Rango Máximo',
	@en = 'Maximum Range'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.model.sample-parameter-type.decimal-digits',
	@es = 'Cant. de Decimales',
	@en = 'Decimal Digits'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.model.sample-parameter-type.updated-date',
	@es = 'Fecha de actualización',
	@en = 'Last update date'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.model.sample-parameter-type.updated-by',
	@es = 'Actualizado por',
	@en = 'Last update by'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'security.model.sample-parameter-type.isEnabled',
	@es = '¿Habilitado?',
	@en = 'Is Enabled?'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.refresh',
	@es = 'Refrescar',
	@en = 'Refresh'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.new',
	@es = 'Nuevo',
	@en = 'New'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.edit',
	@es = 'Editar',
	@en = 'Edit'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.enable',
	@es = 'Habilitar',
	@en = 'Enable'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.disable',
	@es = 'Deshabilitar',
	@en = 'Disable'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.delete',
	@es = 'Eliminar',
	@en = 'Delete'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.export',
	@es = 'Exportar',
	@en = 'Export'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'sample-parameter-type.validation.invalid-decimal',
	@es = 'La cantidad de decimales debe ser mayor a cero.',
	@en = 'The amount of decimal digits must be more than zero.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'sample-parameter-type.validation.invalid-ranges',
	@es = 'El rango mínimo debe ser igual o menor al rango máximo.',
	@en = 'The minimum range must be equal or below the maximum range.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = '"sample-parameter-type.validation.code-exists',
	@es = 'El código del parámetro ya existe.',
	@en = 'The code already exists.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.configuration.unit-of-measure',
	@es = 'Gestionar Unidades de Medida',
	@en = 'Unit of Measures Management'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'configuration.editUnitOfMeasure.title.new',
	@es = 'Nueva Unidad de Medida',
	@en = 'New Unit Of Measure'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.confirm',
	@es = 'Confirmar',
	@en = 'Confirm'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'unit-of-measure.validation.code-not-unique',
	@es = 'El código ingresado ya existe.',
	@en = 'The desired Code already exists.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.isenabled',
	@es = 'Habilitado',
	@en = 'Enabled'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'configuration.sample-type-parameter.title.edit',
	@es = 'Editar Tipo de Parámetro de Muestra',
	@en = 'Edit Sample Parameter Type'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'configuration.sample-type-parameter.title.new',
	@es = 'Nuevo Tipo de Parámetro de Muestra',
	@en = 'New Sample Parameter Type'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.parameter-data-type',
	@es = 'Tipo de Dato',
	@en = 'Data Type'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.sample-type-parameter.decimal-digits',
	@es = 'Cant. de Dígitos Decimales',
	@en = 'Decimal Digits'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.sample-type-parameter.minimum-range',
	@es = 'Rango Mínimo',
	@en = 'Minimum Range'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.sample-type-parameter.maximum-range',
	@es = 'Rango Máximo',
	@en = 'Maximum Range'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.unit-of-measure',
	@es = 'Unidad de Medida',
	@en = 'Unit of Measure'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'validator.api.mandatory-decimal',
	@es = 'El campo "{0}" es requerido.',
	@en = 'The field "{0}" is required.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'sample-function.exists',
	@es = 'El código indicado ya existe.',
	@en = 'This code already exists.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'sample-function.forbidden-code',
	@es = 'El código no puede ser X, S o C',
	@en = 'The code cannot be X, S or C'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'configuration.sample-function.title.edit',
	@es = 'Editar Función de Muestra',
	@en = 'Edit Sample Function'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'configuration.sample-function.title.new',
	@es = 'Nueva Función de Muestra',
	@en = 'New Sample Function'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.name',
	@es = 'Nombre',
	@en = 'Name'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.patient.patient-type',
	@es = 'Tipo de Paciente',
	@en = 'Patient Type'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.patient.client-company',
	@es = 'Cliente',
	@en = 'Tenant'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.patient.invalid-delete',
	@es = 'Error al intentar eliminar el paciente indicado.',
	@en = 'Error when trying to delete the indicated patient.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.patient.available-samples',
	@es = '# de Muestras Disponibles',
	@en = '# of Available Samples'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.patient.used-samples',
	@es = '# de Muestras Utilizables',
	@en = '# of Available Samples'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.patient.total-samples',
	@es = '# de Muestras Total',
	@en = '# of Total Samples'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'inventory.patient.title.edit',
	@es = 'Editar Paciente',
	@en = 'Edit Patient'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'inventory.patient.title.new',
	@es = 'Nuevo Paciente',
	@en = 'New Patient'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'model.patient-type',
	@es = 'Tipo de Paciente',
	@en = 'Patient Type'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'sample-type.validation.exists',
	@es = 'Ya existe un tipo de muestra con este código.',
	@en = 'A sample type with this code already exists.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'sample-type.validation.used',
	@es = 'Una o más muestras utilizan el tipo de muestra seleccionado.',
	@en = 'One or more samples use the selected sample type.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.last-update',
	@es = 'Última Actualización',
	@en = 'Last Update'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.last-update-by',
	@es = 'Actualización por',
	@en = 'Last Update By'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'configuration.sample-type.title.edit',
	@es = 'Editar Tipo de Muestra',
	@en = 'Edit Sample Type'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'configuration.sample-type.title.new',
	@es = 'Nuevo Tipo de Muestra',
	@en = 'New Sample Type'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.account-menu',
	@es = 'Mi Cuenta',
	@en = 'My Account'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.account.change-password',
	@es = 'Cambio de contraseña',
	@en = 'Change Password'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'account.change-password.page.title',
	@es = 'Cambio de Contraseña',
	@en = 'Change your Password'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'change-password.currentPassword',
	@es = 'Contraseña Actual',
	@en = 'Current Password'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'change-password.password1',
	@es = 'Ingrese una nueva contraseña',
	@en = 'Input a new password'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'change-password.password2',
	@es = 'Repita la nueva contraseña',
	@en = 'Repeat the new password'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'change-password.success',
	@es = 'Su contraseña ha sido actualizada con éxito.',
	@en = 'Your password has been successfully changed.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'change-password.validation.password-no-match',
	@es = 'La contraseña actual no coincide. Vuelva a intentarlo.',
	@en = 'The current password does not match. Try again.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'change-password.validation.empty-passwords',
	@es = 'Debe llenar todos los campos.',
	@en = 'You must fill in all the input boxes.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'change-password.validation.new-password-no-match',
	@es = 'Las contraseñas no coinciden.',
	@en = 'The passwords do not match.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'email.password-changed.subject',
	@es = 'SSC - Su contraseña ha sido actualizada',
	@en = 'SSC - Password has been updated'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-search.page.title',
	@es = 'Catálogo de Servicios',
	@en = 'Service Catalog'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-search.page.open-filters',
	@es = 'Abrir Filtros',
	@en = 'Open Filters'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-search.page.name-filter',
	@es = 'Filtrar por nombre',
	@en = 'Filter by name'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-search.page.rating-filter',
	@es = 'Mínimo de rating',
	@en = 'Minimum rating'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-search.page.price-range-filter',
	@es = 'Rango de precios',
	@en = 'Price range'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-search.page.apply-filter',
	@es = 'Aplicar filtros',
	@en = 'Apply filters'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'app.marketing.menu.catalog',
	@es = 'Catálogo',
	@en = 'Services'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-card.patient-sample-limit',
	@es = 'Hasta ${value} muestras de pacientes.',
	@en = 'Up to ${value} patient samples.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-card.patient-sample-unlimited',
	@es = 'Sin límite de muestras de pacientes.',
	@en = 'No limit on patient samples.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-card.control-sample-limit',
	@es = 'Hasta ${value} muestras de control.',
	@en = 'Up to ${value} control samples.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-card.control-sample-unlimited',
	@es = 'Sin límite de muestras de control.',
	@en = 'No limit on control samples.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-card.run-limit',
	@es = 'Hasta ${value} ensayos clínicos al mes.',
	@en = 'Up to ${value} clinic runs each month.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-card.run-unlimited',
	@es = 'Sin límite de ensayos clínicos.',
	@en = 'Unlimited clinic runs.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-card.user-limit',
	@es = 'Hasta ${value} cuentas de usuario.',
	@en = 'Up to ${value} user accounts.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-card.no-user-limit',
	@es = 'Sin límite de cuentas de usuario.',
	@en = 'No user account limit.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.compare',
	@es = 'Comparar',
	@en = 'Compare'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.close',
	@es = 'Cerrar',
	@en = 'Close'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.yes',
	@es = 'Sí',
	@en = 'Yes'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.no',
	@es = 'No',
	@en = 'No'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-compare.grid.row.user-limit',
	@es = 'Límite de Usuarios',
	@en = 'User Accounts Limit'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-compare.grid.row.patient-sample-limit',
	@es = 'Límite de Muestras de Pacientes',
	@en = 'Patient Sample Limit'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-compare.grid.row.control-sample-limit',
	@es = 'Límite de Muestras de Control',
	@en = 'Control Sample Limit'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-compare.grid.row.run-limit',
	@es = 'Límite de Ensayos Clínicos',
	@en = 'Clinic Run Execution Limit'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-compare.grid.row.price',
	@es = 'Precio',
	@en = 'Price'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.free',
	@es = 'Gratis',
	@en = 'Free'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.no-limit',
	@es = 'Sin Límite',
	@en = 'No Limit'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.remove-compare',
	@es = 'Remover',
	@en = 'Remove'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-search.page.open-compare',
	@es = 'Abrir Comparación',
	@en = 'Open Compare'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'app.marketing.menu.faq',
	@es = 'FAQ',
	@en = 'FAQ'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'faq.what-is-ssc.header',
	@es = 'Qué es Sample Supply Chain',
	@en = 'What is Sample Supply Chain'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'faq.what-is-ssc.subheader',
	@es = 'Conoce nuestro servicio',
	@en = 'Get to know our service'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'faq.what-is-ssc.details',
	@es = 'Sample Supply Chain, o abreviando SSC, es una plataforma digital de control y administración de ensayos clínicos. Creada con la necesidad de ayudar a las organizaciones de investigación por contrato, SSC trae una revolucionaria forma de administrar sus estudios a la vez que logra disminuir sus costos operativos y tecnológicos.',
	@en = 'Sample Supply Chain, or abbreviating SSC, is a digital platform for control and administration of clinical trials. Created with the need to help contract research organizations, SSC brings a revolutionary way to manage their studies while reducing their operational and technological costs.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'faq.how-to-operate.details',
	@es = 'Para operar con la plataforma primero debe crear su cuenta. Ingrese a la opción "Ingresar" y luego registre una nueva cuenta. La plataforma ofrece distintos planes de servicio, incluído un plan gratuito con limitaciones que puede utilizar para usar la plataforma de forma legal y gratuita y poder entender qué es lo que ofrecemos.',
	@en = 'To operate with the platform you must first create your account. Enter the "Login" option and then register a new account. The platform offers different service plans, including a free plan with limitations that you can use to use the platform legally and free of charge and understand what we offer.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'faq.how-to-operate.header',
	@es = '¿Cómo empezar a operar?',
	@en = 'How to start operating?'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'faq.how-to-operate.subheader',
	@es = 'Inicie su trabajo hoy mismo',
	@en = 'Start working today!'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'faq.diff-samples.header',
	@es = '¿Qué tipos de muestra maneja SSC?',
	@en = 'What types of samples SSC handles?'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'faq.diff-samples.subheader',
	@es = 'Conozca sobre nuestra división',
	@en = 'Know about our typification'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'faq.diff-samples.details',
	@es = 'Conocemos su organización y su negocio. No todas las muestras son iguales ni provienen del mismo origen. Nuestra plataforma correctamente divide entre muestras de pacientes y muestras de control. Usted tendrá completo control para tipificar sus muestras con diferentes tipos de funciones clínicas, y además podrá tipificar a sus pacientes con la tipificación que prefiera.',
	@en = 'We know your organization and your business. Not all samples are the same or come from the same origin. Our platform correctly divides between patient samples and control samples. You will have complete control to typify your samples with different types of clinical functions, and you can also typify your patients with the type you prefer.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'backup.backup-success',
	@es = 'El resguardo se ha realizado exitosamente.',
	@en = 'The backup has been completed successfully.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'backup.restore-success',
	@es = 'La base de datos se ha restaurado exitosamente.',
	@en = 'The database restore has been completed successfully.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'backup.filepath',
	@es = 'Ubicación',
	@en = 'FilePath'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'backup.date',
	@es = 'Fecha de Resguardo',
	@en = 'Backup Date'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'backup.createdby',
	@es = 'Realizado por',
	@en = 'Performed by'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'backup.doBackup',
	@es = 'Generar Resguardo',
	@en = 'Perform Backup'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'backup.doRestore',
	@es = 'Restaurar el resguardo seleccionado',
	@en = 'Restore from selected backup'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.view-details',
	@es = 'Ver Detalle',
	@en = 'View Details'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-detail.average.rating',
	@es = 'Valoración Promedio',
	@en = 'Average Rating'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.account.leave-comment',
	@es = 'Comentar tu experiencia',
	@en = 'Comment your experience'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'leave-comment.title',
	@es = 'Deje su comentario sobre nuestro servicio:',
	@en = 'Leave us a comment about our service:'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'leave-comment.comment',
	@es = 'Describa su experiencia con la plataforma',
	@en = 'Describe your experience with the platform'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'leave-comment.already-done',
	@es = 'Continuaremos mejorando nuestro servicio para usted.',
	@en = 'We will continue improving our service for you.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'leave-comment.already-done-title',
	@es = '¡Muchas gracias por su comentario!',
	@en = 'Thank you so much for your comment!'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-compare.grid.row.rating',
	@es = 'Valoración',
	@en = 'Rating'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.configuration.platform-menu',
	@es = 'Navegación de Plataforma',
	@en = 'Platform Navigation Management'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-menu.translation-key',
	@es = 'Clave de Traducción',
	@en = 'Translation Key'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-menu.menu-order',
	@es = 'Orden en el Menú',
	@en = 'Menu Order'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'configuration.platform-menu.title.edit',
	@es = 'Editar Menú de Plataforma',
	@en = 'Edit Platform Menu'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'configuration.platform-menu.title.new',
	@es = 'Nuevo Menú de Plataforma',
	@en = 'New Platform Menu'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-menu-item.menu-order',
	@es = 'Orden en el Menú',
	@en = 'Menu Order'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-menu-item.relative-route',
	@es = 'Ruta Relativa',
	@en = 'Relative Route'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-menu.validation.need-menu-items',
	@es = 'Debe especificar al menos un ítem dentro del menú.',
	@en = 'You must at least have one menu item for your menu.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-menu-item.edit.title',
	@es = 'Edición de ítem de menú',
	@en = 'Platform Menu Item Edition'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-menu-item.validation.relative-route',
	@es = 'Debe especificar una ruta relativa para el link del menú.',
	@en = 'The menu item needs a relative route to point to.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-menu-item.validation.menu-order',
	@es = 'El orden del item debe ser mayor a 0.',
	@en = 'The menu order must be greater than 0.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-menu-item.validation.translation-key',
	@es = 'Debe seleccionar una clave de traducción.',
	@en = 'You must pick a translation key.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-menu-item.validation.required-permissions',
	@es = 'El ítem debe depender de al menos un permiso de la plataforma.',
	@en = 'The menu item must depend at least from one platform security permission.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-menu-item.grid.page-title',
	@es = 'Página de la plataforma',
	@en = 'Page'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'search-back-office.search-term-input',
	@es = 'Indique su criterio de búsqueda',
	@en = 'Please type in what you are looking for'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.search',
	@es = 'Buscar',
	@en = 'Search'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.marketing.feedback-form',
	@es = 'Gestión de Fichas de Opinión',
	@en = 'Feedback Forms Management'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'feedback-form.is-current.true',
	@es = 'ACTUAL',
	@en = 'CURRENT'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'feedback-form.is-current.false',
	@es = 'No',
	@en = 'No'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.created-date',
	@es = 'Fecha de Creación',
	@en = 'Created Date'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'feedback-form.is-current',
	@es = 'Es la actual',
	@en = 'Is current'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'feedback-form.action.set-is-current',
	@es = 'Convertir en Actual',
	@en = 'Set To Current'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'marketing.feedback-form.title.new',
	@es = 'Nueva Ficha de Opinión',
	@en = 'New Feedback Form'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'feedback-form-question.question',
	@es = 'Pregunta',
	@en = 'Question'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'feedback-form-question.validation.question',
	@es = 'Debe especificar una pregunta.',
	@en = 'You must specify a question.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'feedback-form-question.validation.choices',
	@es = 'Debe tener al menos 2 opciones.',
	@en = 'You must have at least 2 choices.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'feedback-form-question.edit.title',
	@es = 'Pregunta de Ficha de Opinión',
	@en = 'Feedback Form Question'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'feedback-form-question.question',
	@es = 'Especifique el enunciado de la pregunta',
	@en = 'Specify the question description'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'feedback-form-question-choice.choice-title',
	@es = 'Opción',
	@en = 'Choice'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'feedback-form-question.validation.empty-choice',
	@es = 'Una o más opciones están vacías.',
	@en = 'One or more choices are empty.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'feedback-form-question.grid.question',
	@es = 'Enunciado',
	@en = 'Question'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'submitted-feedback-form.page.title',
	@es = 'Bienvenido a Sample Supply Chain',
	@en = 'Welcome to Sample Supply Chain'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'submitted-feedback-form.page.subtitle',
	@es = 'Por favor tómese unos segundos para opinar sobre la experiencia y seguridad del proceso de registración.',
	@en = 'Please take a few seconds to give us your opinion about the experience and security of the sign up process.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'submitted-feedback-form.validation.choice-null',
	@es = 'Una o más preguntas no han sido respondidas.',
	@en = 'One or more questions have not been answered.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'submitted-feedback-form.thank-you',
	@es = 'Muchas Gracias!',
	@en = 'Thank you!'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'survey-form.question-title',
	@es = 'Pregunta de Encuesta',
	@en = 'Survey Question'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.marketing.survey-form',
	@es = 'Gestión de Encuestas',
	@en = 'Surveys Management'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'marketing.survey-form.title.edit',
	@es = 'Editar Encuesta',
	@en = 'Edit Survey Form'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'marketing.survey-form.title.new',
	@es = 'Nueva Encuesta',
	@en = 'New Survey Form'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'survey-choice.choice-title',
	@es = 'Opción',
	@en = 'Choice'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'survey-form.choices',
	@es = 'Opciones',
	@en = 'Choices'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'survey-form.choices.choice-title-empty',
	@es = 'Una o más opciones están vacías.',
	@en = 'One or more options are empty.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'survey-form.expiration-date',
	@es = 'Fecha de Expiración',
	@en = 'Expiration Date'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'survey-form.choices.need-more-than-one',
	@es = 'Debe haber al menos dos opciones.',
	@en = 'You must have at least two options.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'survey-submission.hello',
	@es = '¡Danos tu opinión!',
	@en = 'Give us your opinion!'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'survey-results.page.title',
	@es = 'Resultados de la Encuesta',
	@en = 'Survey Results'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.compare-results',
	@es = 'Comparar Resultados',
	@en = 'Compare Results'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.view-results',
	@es = 'Ver Resultados',
	@en = 'View Results'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.percentage',
	@es = 'Porcentaje',
	@en = 'Percentage'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.count',
	@es = 'Cantidad',
	@en = 'Count'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'survey-results.compare.page.title',
	@es = 'Comparar Encuestas',
	@en = 'Compare Surveys'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'feedback-form-results.page.title',
	@es = 'Resultados de Ficha de opinión',
	@en = 'Feedback Form Results'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.marketing.site-news',
	@es = 'Gestión de Noticias',
	@en = 'News Management'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'site-news-article.title',
	@es = 'Título',
	@en = 'Title'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'site-news-article.author',
	@es = 'Autor',
	@en = 'Author'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'site-news-article.publication-date',
	@es = 'Fecha de Publicación',
	@en = 'Publication Date'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'marketing.site-news.title.edit',
	@es = 'Editar Noticia',
	@en = 'Edit News Article'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'marketing.site-news.title.new',
	@es = 'Nueva Noticia',
	@en = 'New News Article'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'site-news.author',
	@es = 'Autor',
	@en = 'Author'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'site-news.title',
	@es = 'Título',
	@en = 'Title'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'site-news.content',
	@es = 'Contenido',
	@en = 'Content'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'site-news.publication-date',
	@es = 'Fecha de Publicación',
	@en = 'Publication Date'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'app.marketing.menu.blog',
	@es = 'Blog',
	@en = 'Blog'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'blog.page.title',
	@es = 'Noticias de SSC',
	@en = 'SSC News'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'blog.article-by',
	@es = 'Escrito por ',
	@en = 'Written by '

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'blog.go-to-subscribe',
	@es = 'Suscribirse a nuestro Newsletter',
	@en = 'Subscribe to our Newsletter'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'send-newsletter.page.title',
	@es = 'Enviar Newsletter',
	@en = 'Send Newsletter'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'send-newsletter.page.subtitle',
	@es = 'Ingrese las fechas entre las cuales se tomarán las noticias a enviar en el newsletter.',
	@en = 'Input the dates between which the news articles will be used to be sent into the newsletter.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'send-newsletter.date-from',
	@es = 'Fecha desde',
	@en = 'Date From'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'send-newsletter.date-to',
	@es = 'Fecha hasta',
	@en = 'Date To'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.marketing.newsletter.new',
	@es = 'Enviar Newsletter',
	@en = 'Send Newsletter'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'subscribe-newsletter.title',
	@es = 'Suscribirse al Newsletter',
	@en = 'Subscribe to our Newsletter'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'subscribe-newsletter.subttitle',
	@es = 'Indique su e-mail para empezar a recibir el newsletter de SSC.',
	@en = 'Type in your e-mail to start receiving our newsletter.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'subscribe-newsletter.email',
	@es = 'Su correo electrónico',
	@en = 'Your e-mail'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'subscribe-newsletter.success',
	@es = 'Se ha suscrito al newsletter!',
	@en = 'You have subscribed to our newsletter!'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'subscribe-newsletter.email-exists',
	@es = 'Ya se encuentra suscripto.',
	@en = 'You are already subscribed.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'subscribe-newsletter.email-does-not-exist',
	@es = 'Usted no se encuentra suscripto.',
	@en = 'You are not subscribed.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'newsletter-email.subject',
	@es = 'Newsletter de SSC',
	@en = 'SSC Newsletter'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'newsletter.unsubscribe.success',
	@es = 'Su suscripción al newsletter ha sido cancelada.',
	@en = 'Your newsletter subscription has been cancelled.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'support-ticket-status.sent',
	@es = 'Enviado',
	@en = 'Sent'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'support-ticket-status.replied',
	@es = 'Respondido',
	@en = 'Replied'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'support-ticket-status.closed',
	@es = 'Cerrado',
	@en = 'Closed'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'support-ticket-status.cancelled',
	@es = 'Cancelado',
	@en = 'Cancelled'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'support-ticket-conversation.model.content',
	@es = 'Mensaje',
	@en = 'Message'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'support-ticket.model.subject',
	@es = 'Asunto',
	@en = 'Subject'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'support-ticket.model.status-code',
	@es = 'Estado',
	@en = 'Status'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'support-ticket.model.content',
	@es = 'Mensaje',
	@en = 'Message'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.management.tickets',
	@es = 'Mensajería a Soporte',
	@en = 'Support Messaging'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.cancel',
	@es = 'Cancelar',
	@en = 'Cancel'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'support-ticket.action.reply',
	@es = 'Responder',
	@en = 'Reply'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'start-support-ticket.page.title',
	@es = 'Nuevo Ticket a Soporte',
	@en = 'New Support Ticket'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'support-ticket.validation.cannot-reply-closed-or-cancelled',
	@es = 'No se puede responder un ticket que está cerrado o cancelado.',
	@en = 'Cannot reply a ticket that is closed or cancelled.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.close',
	@es = 'Cerrar',
	@en = 'Close'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.support-menu',
	@es = 'Soporte',
	@en = 'Support'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.support.support-ticket',
	@es = 'Gestionar Tickets',
	@en = 'Support Tickets'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'chat-drawer.tip',
	@es = 'Puede comunicarse y hablar con nuestro soporte en vivo. Envíe un mensaje en instantes un especialista se comunicará con usted.',
	@en = 'You can communicate and talk to one of our support spokesperson right now. Send a message and in about minutes a specialist will get back to you.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-chat.grid.user-id',
	@es = 'Id de Usuario',
	@en = 'User Id'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-chat.grid.user-name',
	@es = 'Cuenta',
	@en = 'Account'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-chat.grid.pending-count',
	@es = 'Mensajes Pendientes',
	@en = 'Pending Messages'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-chat.grid.needs-reply',
	@es = 'Necesita Contestación',
	@en = 'Requires Reply'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'platform-chat.action.reply',
	@es = 'Contestar',
	@en = 'Reply'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.support.chat-conversation',
	@es = 'Mensajería de Chat',
	@en = 'Chat Messaging'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'client-management.action.view-transactions',
	@es = 'Ver Transacciones',
	@en = 'View Transactions'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'client-management.action.view-status',
	@es = 'Ver Estado de Cuenta',
	@en = 'View Account Status'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'client-company.model.legal-name',
	@es = 'Razón Social',
	@en = 'Legal Name'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'client-company.model.tax-code',
	@es = 'CUIT',
	@en = 'Tax Code'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'client-company.model.selected-plan-description',
	@es = 'Plan de Servicio',
	@en = 'Service Plan'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'client-company.model.selected-payment-type',
	@es = 'Método de Pago',
	@en = 'Payment Method'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'client-company.model.last-bill-expiration-date',
	@es = 'Vencimiento Última Factura',
	@en = 'Expiration Last Bill'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'client-company.model.balance-status-description',
	@es = 'Estado de Cuenta',
	@en = 'Balance Status'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'sign-in.validation.client-disabled',
	@es = 'El acceso se encuentra bloqueado. Contacte a un administrador.',
	@en = 'Access is blocked. Please contact an administrator.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'backup.invalid-path',
	@es = 'El formato del path es inválido.',
	@en = 'The path formato is invalid.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'backup.dir-not-exists',
	@es = 'El directorio no existe.',
	@en = 'The directory does not exist.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'backup.file-exists',
	@es = 'El archivo ya existe. Por seguridad, no se pueden reemplazar archivos existentes con nuevos resguardos.',
	@en = 'The file already exists. For security, existing files will not be replaced by new backup files.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'backup.file-must-end-with-bkp',
	@es = 'El archivo debe tener la extensión .bkp',
	@en = 'The file must have the .bkp extension'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'backup.doRestoreFrom',
	@es = 'Restaurar desde',
	@en = 'Restore from'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'restore.invalid-file',
	@es = 'El archivo de backup ingresado es inválido o no está correctamente formateado.',
	@en = 'El backup file selected is invalid or it is not correctly formatted.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'restore.from.tip',
	@es = 'Seleccione y suba un archivo de BKP para hacer la restauración de base de datos.',
	@en = 'Select and upload a BKP file to restore the database.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'site-news.thumbnail-image',
	@es = 'Seleccione una imagen de portada',
	@en = 'Select a thumbnail image'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'site-news.validation.missing-thumbnail',
	@es = 'Debe seleccionar una imagen de portada.',
	@en = 'You must select a thumbnail image.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.cannot-delete-in-use',
	@es = 'El registro se encuentra en uso. No puede eliminarse.',
	@en = 'The record is in use. It cannot be deleted.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.marketing.site-news-category',
	@es = 'Categorías de Noticias',
	@en = 'Site News Categories'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'marketing.site-news-category.title.edit',
	@es = 'Editar Categoría de Noticia',
	@en = 'Edit Site News Category'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'marketing.site-news-category.title.new',
	@es = 'Nueva Categoría de Noticia',
	@en = 'New Site News Category'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'site-news.category',
	@es = 'Categorías',
	@en = 'Categories'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'newsletter.invalid-date-range',
	@es = 'El rango de fechas seleccionado es inválido.',
	@en = 'The selected date range is invalid.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'client-landing.your-plan',
	@es = 'Tu plan:',
	@en = 'Your plan:'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'client-landing.action.manage',
	@es = 'Gestionar',
	@en = 'Manage'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'client-landing.expiration-date',
	@es = 'Plan válido hasta:',
	@en = 'Plan valid until:'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'client-landing.action.buy',
	@es = 'Comprar',
	@en = 'Buy'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.select',
	@es = 'Seleccionar',
	@en = 'Select'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'buy-more.months',
	@es = 'Extender Un mes',
	@en = 'Extend One Month'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'buy-more.years',
	@es = 'Extender Un Año',
	@en = 'Extend One Year'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment-methods.tab.credit-card',
	@es = 'Tarjeta de Crédito',
	@en = 'Credit Card'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment-methods.tab.credit-note',
	@es = 'Nota de Crédito',
	@en = 'Credit Note'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-card-select',
	@es = 'Tarjeta de Crédito Guardada',
	@en = 'Saved Credit Card'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-card-number',
	@es = 'Número de Tarjeta de Crédito',
	@en = 'Credit Card Number'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-card.number',
	@es = 'Número de Tarjeta de Crédito',
	@en = 'Credit Card Number'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-card-ccv',
	@es = 'Código CCV',
	@en = 'CCV Code'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-card-expiration',
	@es = 'Fecha de Expiración (Formato MM/YY)',
	@en = 'Expiration Date (MM/YY Format)'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-card-holder',
	@es = 'Titular',
	@en = 'Holder'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.save-credit-card',
	@es = 'Guardar tarjeta de crédito',
	@en = 'Save credit card'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.new-credit-card',
	@es = 'Nueva Tarjeta',
	@en = 'New Card'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.selected',
	@es = 'Seleccionado',
	@en = 'Selected'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-card.validation.invalid-number',
	@es = 'El número de tarjeta de crédito es inválido o no existe.',
	@en = 'The credit card number is invalid or does not exist.'

EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-card.validation.process-error',
	@es = 'Un error ha ocurrido procesando su pago. Por favor vuelva a intentarlo más tarde.',
	@en = 'An error has occurred while processing your payment. Please try again later.'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-card.validation.declined',
	@es = 'La tarjeta de crédito que ha ingresado ha sido rechazada. Por favor, intente pagar con otra tarjeta de crédito o contacte a su emisor.',
	@en = 'The credit card you have entered has been declined. Please, try paying with a different card or contact your issuer.'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-card.validation.data-mismatch',
	@es = 'Uno o varios datos no coinciden o no son válidos con la tarjeta ingresadas.',
	@en = 'There is invalid data or a data mismatch against the indicated credit card.'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-card.validation.expired',
	@es = 'Ha ingresado una fecha de expiración que ya ha caducado. Por favor, intente con otra tarjeta de crédito o corrija el campo.',
	@en = 'You have entered an expiration date that has already passed. Please, try with a different card or correct the data input.'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-card.validation.ccv-empty',
	@es = 'El campo CCV no es válido.',
	@en = 'The CVC is not valid.'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-card.validation.date-invalid-format',
	@es = 'Formato de fecha debe ser MMYY.',
	@en = 'The date format must be MMYY'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment-method.type.credit-card',
	@es = 'Tarjeta de Crédito',
	@en = 'Credit Card'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment-method.grid.type',
	@es = 'Forma de Pago',
	@en = 'Payment Method'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment-method.grid.reference',
	@es = 'Referencia',
	@en = 'Referencia'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment-method.grid.value',
	@es = 'Importe',
	@en = 'Value'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment-method.grid.remainder',
	@es = 'Remanente',
	@en = 'Remainder'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'purchase.extension.month',
	@es = 'Extensión 1 Mes',
	@en = 'Extended 1 Month'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'purchase.extension.year',
	@es = 'Extensión 12 Meses',
	@en = 'Extended 12 Months'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'purchase.payment-part.credit-note',
	@es = 'Nota de Crédito',
	@en = 'Credit Note'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'purchase.payment-part.credit-card',
	@es = 'Tarjeta de Crédito',
	@en = 'Credit Card'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'purchase-bill-detail.title',
	@es = 'Detalle de la Compra',
	@en = 'Purchase Detail'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'purchase-bill-detail.concept',
	@es = 'Concepto',
	@en = 'Concept'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'purchase-bill-detail.amount',
	@es = 'Importe',
	@en = 'Total'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment-methods-tabs.title',
	@es = 'Especificar formas de pago',
	@en = 'Specify Payment Methods'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.account.my-service-status',
	@es = 'Estado de Servicio',
	@en = 'Service Status'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'transaction.date',
	@es = 'Fecha',
	@en = 'Date'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'transaction.receipt-type',
	@es = 'Tipo Comprobante',
	@en = 'Receipt Type'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'transaction.receipt-number',
	@es = 'Número Cbte.',
	@en = 'Receipt Number'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'transaction.description',
	@es = 'Servicio',
	@en = 'Service'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'transaction.amount',
	@es = 'Importe',
	@en = 'Amount'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'client-landing.account-status',
	@es = 'Estado de Cuenta',
	@en = 'Account Transactions'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'transaction-type.purchase-bill',
	@es = 'Factura',
	@en = 'Purchase Bill'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'transaction-type.credit-note',
	@es = 'Nota de Crédito',
	@en = 'Credit Note'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'account-transactions.actions.view-receipt',
	@es = 'Ver Comprobante',
	@en = 'View Receipt'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.goback',
	@es = 'Volver',
	@en = 'Go Back'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.print',
	@es = 'Imprimir',
	@en = 'Print'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'account-transactions.actions.request-return',
	@es = 'Solicitar Devolución',
	@en = 'Request Return'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'request-return.typography.are-you-sure',
	@es = '¿Está seguro de solicitar una anulación de la siguiente compra?',
	@en = 'Are you sure that you wish to request a cancellation of the following purchase?'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'request-return.typography.bill-row-header',
	@es = 'Factura Comprobante:',
	@en = 'Purchase Bill:'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'request-return.typography.admin-notice',
	@es = 'Un administrador de Sample Supply Chain revisará su pedido y se pondrá en contacto con usted.',
	@en = 'An admin from Sample Supply Chain will review your request and get in contact with you.'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'request-return.typography.expiration-date-notice',
	@es = 'Recuerde que la fecha de vencimiento de su servicio se verá afectada al aplicarse la devolución.',
	@en = 'Remember that the expiration date of your service will be affected by applying the return.'
	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'request-return.typography.credit-note-notice',
	@es = 'De aprobarse la devolución, usted recibirá una nota de crédito que podrá utilizar en nuestra plataforma.',
	@en = 'By approving the return, you will receive a credit note that you can use in our platform.'

	
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'request-for-return.validation.already-exists',
	@es = 'Ya existe un pedido de devolución para esta compra.',
	@en = 'A request for return already exists for this purchase.'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'transaction.status-code.finalized',
	@es = 'Finalizada',
	@en = 'Finalized'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'transaction.status-code.return-requested',
	@es = 'Devolución Pedida',
	@en = 'Return Requested'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'transaction.status-code.return-approved',
	@es = 'Anulada',
	@en = 'Returned'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'transaction.status-code.emitted',
	@es = 'Emitida',
	@en = 'Emitted'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'transaction.status',
	@es = 'Estado',
	@en = 'Status'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.approve',
	@es = 'Aprobar',
	@en = 'Approve'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.action.reject',
	@es = 'Rechazar',
	@en = 'Reject'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'receipt-return-request.status.approved',
	@es = 'Aprobado',
	@en = 'Approved'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'receipt-return-request.status.rejected',
	@es = 'Rechazado',
	@en = 'Reject'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'receipt-return-request.status.pending',
	@es = 'Pendiente',
	@en = 'Pending'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.management.receipt-return-request',
	@es = 'Pedidos de Devolución',
	@en = 'Receipt Return Requests'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'receipt-return-request.grid.receipt-number',
	@es = 'Factura',
	@en = 'Bill'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'receipt-return-request.grid.status',
	@es = 'Estado',
	@en = 'Status'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'receipt-return-request.grid.request-date',
	@es = 'Fecha de Pedido',
	@en = 'Request Date'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'receipt-return-request.grid.review-by',
	@es = 'Revisado Por',
	@en = 'Reviewed By'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'receipt-return-request.grid.review-date',
	@es = 'Fecha de Revisión',
	@en = 'Review Date'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'receipt-return-request.validation.bad-expiration-after',
	@es = 'De aprobarse la devolución la fecha de vencimiento del servicio del cliente quedaría en el pasado. Debe rechazar la devolución y comunicarle al usuario el problema.',
	@en = 'If the return were to be approved then the service plan expiration date of the client would be set into the past. You must reject the return and communicate the problem to the user.'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'request-for-return.validation.not-purchase-bill',
	@es = 'El comprobante seleccionado no es una factura.',
	@en = 'The receipt selected is not a purchase bill.'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'receipt-return-request.grid.related-credit-note-number',
	@es = 'Nota de Crédito',
	@en = 'Credit Note'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'account-transactions.actions.view-credit-note',
	@es = 'Ver Nota de Crédito',
	@en = 'View Credit Note'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'reject-return-request.page.title',
	@es = 'Rechazo de Devolución',
	@en = 'Rejection of Return Request'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'reject-return-request.page.help',
	@es = 'Debe especificar un mensaje para el usuario sobre el rechazo de su pedido de devolución. Debe ingresar al menos 50 caracteres explicando el motivo del rechazo.',
	@en = 'You must specify a message for the user that requested the purchase return. You must input at least 50 characters explaining why you are rejecting the request.'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'reject-return-request.rejection-text',
	@es = 'Motivo de Rechazo',
	@en = 'Rejection Motive'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'receipt-return-request.validation.rejection-motive-too-short',
	@es = 'Debe especificar un motivo de rechazo de al menos 50 caracteres.',
	@en = 'You must specify a rejection motive of at least 50 characters.'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment.credit-note-select',
	@es = 'Seleccionar una nota de crédito',
	@en = 'Select a credit note'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment-methods.credit-note-already-selected',
	@es = 'Esta nota de crédito ya se encuentra seleccionada.',
	@en = 'This credit note is already selected.'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'payment-method.type.credit-note',
	@es = 'Nota de Crédito',
	@en = 'Credit Note'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'buy-more.validation.combined-payment-not-needed',
	@es = 'Las notas de crédito especificadas ya cubren el importe. Puede remover la tarjeta de crédito.',
	@en = 'The selected credit notes already cover the expense. You can remove the credit card.'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'buy-more.validation.amount-not-met',
	@es = 'Las notas de crédito especificadas no cubren el importe. Agregue otra nota de crédito o especifique una tarjeta de crédito.',
	@en = 'The selected credit notes do not cover the expense. Add another credit note or specify a credit card.'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'buy-more.validation.too-many-credit-notes',
	@es = 'Ha especificado demasiadas notas de crédito. Puede cubrir el importe con menos notas. Revise y vuelva a intentarlo.',
	@en = 'You have selected too many credit notes. You can cover the expense with less credit notes. Review and try again.'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-detail.no-scoring-yet',
	@es = 'Sin valoraciones aún ',
	@en = 'No scoring yet '

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-detail.your-question',
	@es = 'Escriba su pregunta',
	@en = 'Write your question'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-detail.action.send-question',
	@es = 'Enviar Pregunta',
	@en = 'Send Question'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-detail.question-sent',
	@es = 'Nuestros especialistas pronto responderán su pregunta.',
	@en = 'Our specialists will soon answer your question.'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-detail.your-name',
	@es = 'Indique su nombre',
	@en = 'Tell us your name'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-question.question-by',
	@es = 'Su Nombre',
	@en = 'Your Name'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-question.question',
	@es = 'Pregunta',
	@en = 'Question'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'validator.api.int-positive-non-zero',
	@es = 'El campo {0} debe ser mayor a cero.',
	@en = 'The field {0} must be above zero.'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-question.reply',
	@es = 'Respuesta',
	@en = 'Reply'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.management.product-question',
	@es = 'Preguntas y Respuestas',
	@en = 'Questions and Answers'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-question.field.question-by',
	@es = 'Pregunta Por',
	@en = 'Question By'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-question.field.posted-date',
	@es = 'Fecha Pregunta',
	@en = 'Posted Date'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-question.field.pricing-plan-name',
	@es = 'Servicio',
	@en = 'Pricing Plan'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-question.field.replied-date',
	@es = 'Fecha Respuesta',
	@en = 'Replied Date'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-question.action.reply',
	@es = 'Responder',
	@en = 'Reply'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'management.product-question.reply.title',
	@es = 'Responder al usuario',
	@en = 'Reply to user'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'management.product-question.reply.field.reply',
	@es = 'Respuesta',
	@en = 'Reply'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'management.product-question.reply.field.question-by',
	@es = 'Pregunta por:',
	@en = 'Question by:'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'management.product-question.reply.field.question',
	@es = 'Pregunta:',
	@en = 'Question:'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'management.product-question.reply.field.posted-date',
	@es = 'Fecha de la Pregunta',
	@en = 'Posted Date'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'management.product-question.reply.field.pricing-plan-name',
	@es = 'Plan de Servicio',
	@en = 'Pricing Plan'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-detail.scores',
	@es = 'Valoraciones',
	@en = 'Scores by Users'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'product-detail.questions',
	@es = 'Preguntas',
	@en = 'Questions'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'subscribe-newsletter.categories',
	@es = 'Categorías',
	@en = 'Categories'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'chat-statistics-chart.title',
	@es = 'Efectividad en Respuestas al Cliente por Día',
	@en = 'Effectivity on Responses to Clients by Day'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'view-chat-stats.page.title',
	@es = 'Estadísticas de la Mensajería',
	@en = 'Chat Messaging Statistics'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'chat-statistics-chart.axis-y',
	@es = 'Porcentaje de Efectividad',
	@en = 'Effectivity Percentage'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.management.chat-statistics',
	@es = 'Estadísticas de Mensajería',
	@en = 'Chat Messaging Stats'

		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'view-profit-report.page.title',
	@es = 'Reporte de Utilidades',
	@en = 'Profit Report'
	
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'view-profit-report.filter.date-from',
	@es = 'Fecha desde',
	@en = 'Date From'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'view-profit-report.filter.date-to',
	@es = 'Fecha hasta',
	@en = 'Date To'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'menu.platform.management.profit-report',
	@es = 'Reporte de Utilidades',
	@en = 'Profit Report'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'profit-report-chart.title',
	@es = 'Utilidades',
	@en = 'Profit'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'profit-report-chart.axis-y',
	@es = 'Facturación',
	@en = 'Gross Income'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'new-backup-fs.browse-folder',
	@es = 'Seleccionar Carpeta',
	@en = 'Pick Folder'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'backup.doBackupTo',
	@es = 'Resguardar En',
	@en = 'Backup To'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.action.continue',
	@es = 'Ejecutar/Continuar',
	@en = 'Execute/Continue'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'start-work-order.page.title',
	@es = 'Crear Orden de Trabajo',
	@en = 'Create Work Order'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'start-work-order.page.select-your-samples',
	@es = 'Seleccionar Muestras',
	@en = 'Select Samples'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'start-work-order.page.selected-samples',
	@es = 'Configurar Salida',
	@en = 'Configure Output'

/** Datos de prueba **/
EXEC sp_testData_createSampleSatellite
EXEC sp_testData_createSamples
		
/** Volvemos a las traducciones **/
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'expected-child.action.edit',
	@es = 'Configurar',
	@en = 'Configure'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'expected-child-sample.grid.parent-barcode',
	@es = 'Muestra Padre',
	@en = 'Parent Barcode'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'expected-child-sample.grid.ExpectedChildQuantity',
	@es = 'Cant. Hijos Pedida',
	@en = 'Childs Count Requested'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'expected-child-sample.grid.DilutionFactor',
	@es = 'Factor de dilución',
	@en = 'Dilution factor'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'expected-child-sample.grid.ResultingVolume',
	@es = 'Volumen Resultante (por Muestra)',
	@en = 'Resulting Volume (per Sample)'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'expected-child-sample.grid.UnitOfMeasureCode',
	@es = 'Unidad de Medida',
	@en = 'Unit of Measure'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.start.validation.parent-samples-empty',
	@es = 'Muestras Padre',
	@en = 'Parent Samples'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'validator.api.decimal-positive-non-zero',
	@es = 'El valor {0} no puede ser vacío, negativo o cero.',
	@en = 'The value {0} cannot be empty, negative or zero.'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.start.field.expected-child-quantity',
	@es = 'Cantidad de Hijos Esperada',
	@en = 'Expected Childs Quantity'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.start.field.dilution-factor',
	@es = 'Factor de dilución',
	@en = 'Dilution factor'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.start.field.resulting-volume',
	@es = 'Volumen Resultante',
	@en = 'Resulting Volume'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.grid.StatusDescription',
	@es = 'Estado',
	@en = 'Status'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.grid.CreatedBy',
	@es = 'Manager',
	@en = 'Manager'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.grid.RequestDate',
	@es = 'Fecha pedido',
	@en = 'Request date'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.grid.QuantityOfParentSamples',
	@es = '# de Muestras Padre',
	@en = '# of Parent Samples'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.grid.QuantityOfExpectedChildSamples',
	@es = '# de Muestras Hija',
	@en = '# of Child Samples'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.grid.CurrentlyAssignedTo',
	@es = 'Asignado a',
	@en = 'Assigned to'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'check-work-order.dialog.confirm',
	@es = 'Las muestras que no han sido confirmadas serán marcadas como Estado Desconocido y no se utilizarán en esta órden de trabajo. ¿Desea continuar?',
	@en = 'The samples that have not been confirmed will be marked as Status Unknown and will not be used in this work order. Do you wish to continue?'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'global.scan-barcode',
	@es = 'Escanee o Escriba el código de barras',
	@en = 'Scan or type the barcode'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'check-work-order.checked',
	@es = 'Comprobada',
	@en = 'Checked'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'parent-sample-search.grid.Checked',
	@es = 'Comprobado',
	@en = 'Checked'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'parent-sample-search.grid.Barcode',
	@es = 'Código',
	@en = 'Barcode'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'parent-sample-search.grid.SampleTypeCode',
	@es = 'Tipo',
	@en = 'Type'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'parent-sample-search.grid.AvailableVolume',
	@es = 'Volumen',
	@en = 'Volume'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'parent-sample-search.grid.UnitOfMeasureCode',
	@es = 'Unidad',
	@en = 'Unit of Measure'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'check-barcode.empty',
	@es = 'Ingrese o escanee un código de barra para comprobar una muestra.',
	@en = 'Type or scan a barcode to check the sample.'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'check-barcode.not-found',
	@es = 'El código de barras ingresado no ha sido encontrado en esta órden.',
	@en = 'The barcode you scanned has not been found in this work order.'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'check-barcode.success',
	@es = 'Muestra comprobada',
	@en = 'Sample checked'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'check-samples.all-unchecked',
	@es = 'No puede continuar sin al menos comprobar una muestra.',
	@en = 'Cannot continue. At least one sample must be checked.'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'execute-work-order.aliquot',
	@es = 'Ingresar Alícuota',
	@en = 'Enter Aliquot'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'execute-work-order.grid.ParentBarcode',
	@es = 'Muestra Padre',
	@en = 'Parent Sample'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'execute-work-order.grid.ChildBarcode',
	@es = 'Muestra Hija',
	@en = 'Child Sample'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'execute-work-order.grid.DilutionFactor',
	@es = 'Factor de Dilución',
	@en = 'Dilution Factor'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'execute-work-order.grid.VolumeToUse',
	@es = 'Vol. a Usar',
	@en = 'Vol. to Use'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'execute-work-order.grid.ResultingVolume',
	@es = 'Vol. Esperado',
	@en = 'Vol. Expected'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'execute-work-order.grid.UnitOfMeasureCode',
	@es = 'Unidad',
	@en = 'UOM'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'execute-work-order.grid.UsedParentVolume',
	@es = 'Vol. Usado',
	@en = 'Vol. Used'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'execute-work-order.grid.FinalChildVolume',
	@es = 'Vol. Final',
	@en = 'Final Volume'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.action.complete',
	@es = 'Finalizar',
	@en = 'Complete'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.start.validation.expected-childs-empty',
	@es = 'Muestras de Salida',
	@en = 'Output Samples'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'work-order.start.field.too-much-volume',
	@es = 'No hay suficiente volumen en la muestra {0} para la configuración establecida. Se dispone de {1}{3} y se está requiriendo {2}{3}.',
	@en = 'There is not enough volume in sample {1} for the requested output. There is {1}{3} available and {2}{3} is required.'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = 'execute-work-order.print-aliquot-labels',
	@es = 'Imprimir Códigos de Barra',
	@en = 'Print Barcode Labels'
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = '',
	@es = '',
	@en = ''
		
EXEC sp_SystemLanguageEntry_addOrUpdate
	@k = '',
	@es = '',
	@en = ''