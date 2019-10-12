-- Setup ssc login
IF NOT EXISTS (SELECT [name]
                FROM [sys].[database_principals]
                WHERE [type] = N'S' AND [name] = N'ssc')
BEGIN
	CREATE USER ssc FOR LOGIN ssc;
	EXEC sp_addrolemember N'db_owner', N'ssc';
END

-- Satellite Data: Provinces
INSERT Province ( Name )
SELECT
	Name = data.Name
FROM (
	SELECT Name = 'Ciudad Autónoma de Buenos Aires' UNION ALL
	SELECT Name = 'Buenos Aires' UNION ALL
	SELECT Name = 'Catamarca' UNION ALL
	SELECT Name = 'Chaco' UNION ALL
	SELECT Name = 'Chubut' UNION ALL
	SELECT Name = 'Córdoba' UNION ALL
	SELECT Name = 'Corrientes' UNION ALL
	SELECT Name = 'Entre Ríos' UNION ALL
	SELECT Name = 'Formosa' UNION ALL
	SELECT Name = 'Jujuy' UNION ALL
	SELECT Name = 'La Pampa' UNION ALL
	SELECT Name = 'La Rioja' UNION ALL
	SELECT Name = 'Mendoza' UNION ALL
	SELECT Name = 'Neuquén' UNION ALL
	SELECT Name = 'Río Negro' UNION ALL
	SELECT Name = 'Salta' UNION ALL
	SELECT Name = 'San Juan' UNION ALL
	SELECT Name = 'Santa Cruz' UNION ALL
	SELECT Name = 'Santa Fe' UNION ALL
	SELECT Name = 'Santiago del Estero' UNION ALL
	SELECT Name = 'Tierra del Fuego' UNION ALL
	SELECT Name = 'Tucumán'
) data
LEFT  JOIN	Province P
		ON	data.Name = p.Name
WHERE		p.Name IS NULL

-- Initial Data: Default Roles
INSERT Role ( 
	Name, 
	IsPlatformRole,
	IsEnabled
)
SELECT
	Name = data.Name, 
	IsPlatformRole = data.IsPlatformRole,
	IsEnabled = 1
FROM	(
	SELECT Name = 'No Registrado', IsPlatformRole = 1 UNION ALL
	SELECT Name = 'Administrador de Sistema', IsPlatformRole = 1 UNION ALL
	SELECT Name = 'Científico Ejecutor', IsPlatformRole = 0 UNION ALL
	SELECT Name = 'Científico Auditor', IsPlatformRole = 0 UNION ALL
	SELECT Name = 'Controlador de Calidad', IsPlatformRole = 0 UNION ALL
	SELECT Name = 'Administrador de Cliente', IsPlatformRole = 0
) data
LEFT  JOIN	Role R
		ON	data.Name = r.Name
WHERE		r.Name IS NULL

-- Satellite Data: Permissions
INSERT Permission (
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
	SELECT Code = 'CLIENT_BILLING_MANAGEMENT', Name = 'Gestión de Facturación de Clientes' UNION ALL
	SELECT Code = 'CLIENT_MANAGEMENT', Name = 'Gestión de Clientes' UNION ALL
	SELECT Code = 'LANGUAGES_MANAGEMENT', Name = 'Gestión de Idiomas de la plataforma' UNION ALL
	SELECT Code = 'NEWS_MANAGEMENT', Name = 'Gestión de Noticias' UNION ALL
	SELECT Code = 'PLATFORM_ADMIN', Name = 'El usuario es Administrador de la plataforma y no puede ser deshabilitado/eliminado.' UNION ALL
	SELECT Code = 'PLATFORM_BACKUP', Name = 'Puede accionar un resguardo de base de datos.' UNION ALL
	SELECT Code = 'PLATFORM_RESTORE', Name = 'Puede accionar una restauración de base de datos.' UNION ALL
	SELECT Code = 'ROLES_MANAGEMENT', Name = 'Gestión de Roles de la plataforma' UNION ALL
	SELECT Code = 'ROLES_REPORT', Name = 'Acceso al Reporte de Roles de la plataforma' UNION ALL
	SELECT Code = 'UNIT_OF_MEASURE_MANAGEMENT', Name = 'Gestión de Unidades de Medida' UNION ALL
	SELECT Code = 'USERS_MANAGEMENT', Name = 'Gestión de Usuarios de la plataforma' UNION ALL
	SELECT Code = 'USERS_REPORT', Name = 'Acceso al Reporte de Usuarios de la plataforma' UNION ALL
	SELECT Code = 'MEMBER_MANAGEMENT', Name = 'Gestión de Usuarios Miembro' UNION ALL
	SELECT Code = 'MEMBER_REPORT', Name = 'Acceso al Reporte de Miembros' UNION ALL
	SELECT Code = 'PATIENTS_MANAGEMENT', Name = 'Gestión de Pacientes' UNION ALL
	SELECT Code = 'PAYMENT_METHOD_MANAGEMENT', Name = 'Gestión de Forma de Pago' UNION ALL
	SELECT Code = 'RUN_EXECUTION_CANCEL', Name = 'Cancelación de lotes de ejecución' UNION ALL
	SELECT Code = 'RUN_EXECUTION_PRIMARY', Name = 'Generación y Ejecución primaria de lotes de ejecución' UNION ALL
	SELECT Code = 'RUN_EXECUTION_QA', Name = 'Control final de calidad de lotes de ejecución' UNION ALL
	SELECT Code = 'RUN_EXECUTION_QC', Name = 'Control de calidad de lotes de ejecución' UNION ALL
	SELECT Code = 'SAMPLE_FUNCTION_MANAGEMENT', Name = 'Gestión de Funciones de Muestra' UNION ALL
	SELECT Code = 'SAMPLE_FUNCTION_REPORT', Name = 'Acceso al Reporte de Funciones de Muestra' UNION ALL
	SELECT Code = 'SAMPLE_MANAGEMENT', Name = 'Gestión de Muestras de Paciente y de Control' UNION ALL
	SELECT Code = 'SAMPLE_TYPE_MANAGEMENT', Name = 'Gestión de Tipos de Muestra' UNION ALL
	SELECT Code = 'SAMPLE_TYPE_REPORT', Name = 'Acceso al Reporte de Tipos de Muestra' UNION ALL
	SELECT Code = 'USERS_INVITE', Name = 'Puede invitar a nuevos miembros a la plataforma.' UNION ALL
	SELECT Code = 'WORK_ORDER_CREATE', Name = 'Creación de Órdenes de Trabajo' UNION ALL
	SELECT Code = 'WORK_ORDER_EXECUTE', Name = 'Ejecución de Órdenes de Trabajo' UNION ALL
	SELECT Code = 'WORK_ORDER_REPORT', Name = 'Listar órdenes de trabajo'
) AS aux
LEFT  JOIN	Permission P
		ON	aux.Code = p.Code
WHERE		p.Code IS NULL

-- Satellite Data: Initial Roles
INSERT Role (
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
	SELECT Name = 'Usuario No Registrado', IsPlatformRole = 0 UNION ALL
	SELECT Name = 'Administrador de Sistema', IsPlatformRole = 1 UNION ALL
	SELECT Name = 'Científico Ejecutor', IsPlatformRole = 0 UNION ALL
	SELECT Name = 'Científico Auditor', IsPlatformRole = 0 UNION ALL
	SELECT Name = 'Controlador de Calidad', IsPlatformRole = 0 UNION ALL
	SELECT Name = 'Administrador de Cliente', IsPlatformRole = 0 
) AS aux
LEFT  JOIN	Role R
		ON	aux.Name = r.Name
WHERE		r.Name IS NULL

-- Role to Permissions - Administrador de Sistema
IF(NOT EXISTS(SELECT TOP 1 1 FROM RolePermission RP INNER JOIN Role R ON rp.RoleId = r.Id WHERE r.Name = 'Administrador de Sistema'))
BEGIN
	INSERT RolePermission (
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
	FROM		Role R
	CROSS JOIN	Permission P
	WHERE		R.Name = 'Administrador de Sistema'
	AND			P.Code IN (
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
		'USERS_REPORT'
	)
END

-- Role to Permissions - Científico Ejecutor
IF(NOT EXISTS(SELECT TOP 1 1 FROM RolePermission RP INNER JOIN Role R ON rp.RoleId = r.Id WHERE r.Name = 'Científico Ejecutor'))
BEGIN
	INSERT RolePermission (
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
	FROM		Role R
	CROSS JOIN	Permission P
	WHERE		R.Name = 'Científico Ejecutor'
	AND			P.Code IN (
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
IF(NOT EXISTS(SELECT TOP 1 1 FROM RolePermission RP INNER JOIN Role R ON rp.RoleId = r.Id WHERE r.Name = 'Científico Auditor'))
BEGIN
	INSERT RolePermission (
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
	FROM		Role R
	CROSS JOIN	Permission P
	WHERE		R.Name = 'Científico Auditor'
	AND			P.Code IN (
		'RUN_EXECUTION_CANCEL',
		'RUN_EXECUTION_QA',
		'SAMPLE_FUNCTION_REPORT',
		'SAMPLE_TYPE_REPORT',
		'SAMPLE_MANAGEMENT',
		'WORK_ORDER_REPORT'
	)
END

-- Role to Permissions - Controlador de Calidad
IF(NOT EXISTS(SELECT TOP 1 1 FROM RolePermission RP INNER JOIN Role R ON rp.RoleId = r.Id WHERE r.Name = 'Controlador de Calidad'))
BEGIN
	INSERT RolePermission (
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
	FROM		Role R
	CROSS JOIN	Permission P
	WHERE		R.Name = 'Controlador de Calidad'
	AND			P.Code IN (
		'RUN_EXECUTION_CANCEL',
		'RUN_EXECUTION_QC',
		'SAMPLE_FUNCTION_REPORT',
		'SAMPLE_TYPE_REPORT',
		'SAMPLE_MANAGEMENT',
		'WORK_ORDER_REPORT'
	)
END

-- Role to Permissions - Administrador de Cliente
IF(NOT EXISTS(SELECT TOP 1 1 FROM RolePermission RP INNER JOIN Role R ON rp.RoleId = r.Id WHERE r.Name = 'Administrador de Cliente'))
BEGIN
	INSERT RolePermission (
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
	FROM		Role R
	CROSS JOIN	Permission P
	WHERE		R.Name = 'Administrador de Cliente'
	AND			P.Code IN (
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
IF (NOT EXISTS(SELECT TOP 1 1 FROM PlatformUser WHERE UserName = 'admin@ssc.com'))
BEGIN
	INSERT PlatformUser (
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
	INSERT UserRole (
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
	FROM		Role R
	WHERE		R.Name = 'Administrador de Sistema'
END

-- Satellite Data: Pricing Plans
INSERT PricingPlan (
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
LEFT  JOIN	PricingPlan PP
		ON	data.Code = pp.Code
WHERE		pp.CODE IS NULL

-- System Languages (Initial)
INSERT SystemLanguage (
	Code,
	Name,
	CreatedBy,
	UpdatedBy
)
SELECT
	Code = data.Code,
	Name = data.Name,
	CreatedBy = 1,
	UpdatedBy = 1
FROM	(
	SELECT Code = 'es', Name = 'Español' UNION
	SELECT Code = 'en', Name = 'English'
) AS data
LEFT  JOIN	SystemLanguage SL
		ON	sl.Code = data.Code

WHERE		sl.Code IS NULL

-- System Language Entries (Initial - Spanish)
INSERT SystemLanguageEntry (
	SystemLanguageId,
	EntryKey,
	Translation,
	CreatedBy,
	UpdatedBy
)
SELECT
	SystemLanguageId = sl.Id,
	EntryKey = data.k,
	Translation = data.t,
	CreatedBy = 1,
	UpdatedBy = 1
FROM	(
	SELECT k = 'app.title', t = 'SAMPLE SUPPLY CHAIN' UNION
	SELECT k = 'app.home.slogan', t = 'La solución integral para la administración de muestras de tu laboratorio.' UNION
	SELECT k = 'app.marketing.menu.pricing', t = 'Precios' UNION
	SELECT k = 'app.marketing.menu.about-us', t = 'Sobre Nosotros' UNION
	SELECT k = 'app.marketing.menu.platform', t = 'Ingresar'
) AS data
INNER JOIN		SystemLanguage SL
		ON		sl.Code = 'es'

LEFT  JOIN		SystemLanguageEntry SLE
		ON		sle.SystemLanguageId = sl.Id
		AND		sle.EntryKey = data.k

WHERE			sle.EntryKey IS NULL

-- System Language Entries (Initial - English)
INSERT SystemLanguageEntry (
	SystemLanguageId,
	EntryKey,
	Translation,
	CreatedBy,
	UpdatedBy
)
SELECT
	SystemLanguageId = sl.Id,
	EntryKey = data.k,
	Translation = data.t,
	CreatedBy = 1,
	UpdatedBy = 1
FROM	(
	SELECT k = 'app.title', t = 'SAMPLE SUPPLY CHAIN' UNION
	SELECT k = 'app.home.slogan', t = 'Your one stop shop for sample supply management in your lab.' UNION
	SELECT k = 'app.marketing.menu.pricing', t = 'Pricing' UNION
	SELECT k = 'app.marketing.menu.about-us', t = 'About Us' UNION
	SELECT k = 'app.marketing.menu.platform', t = 'Login'
) AS data
INNER JOIN		SystemLanguage SL
		ON		sl.Code = 'en'

LEFT  JOIN		SystemLanguageEntry SLE
		ON		sle.SystemLanguageId = sl.Id
		AND		sle.EntryKey = data.k

WHERE			sle.EntryKey IS NULL

