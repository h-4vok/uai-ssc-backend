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
	Translation = (CASE WHEN sl.Code = 'es' THEN data.es ELSE data.en END),
	CreatedBy = 1,
	UpdatedBy = 1
FROM	(
	SELECT k = 'app.title', 
		es = 'Sample Supply Chain', 
		en = 'Sample Supply Chain' 
	UNION SELECT k = 'app.home.slogan', 
		es = 'La solución integral para la administración de muestras de tu laboratorio.', 
		en = 'Your one stop shop for sample supply management in your lab.' 
	UNION SELECT k = 'app.marketing.menu.pricing', 
		es = 'Precios',
		en = 'Pricing'
	UNION SELECT k = 'app.marketing.menu.about-us', 
		es = 'Sobre Nosotros',
		en = 'About Us'
	UNION SELECT k = 'app.marketing.menu.platform', 
		es = 'Ingresar',
		en = 'Sign in'
	UNION SELECT k = 'home.card.tracking.header',
		es = 'Preparado para su negocio',
		en = 'Ready for your business'
	UNION SELECT k = 'home.card.tracking.title',
		es = 'Gestión y Seguimiento de Muestras',
		en = 'Sample Management and Tracking'
	UNION SELECT k = 'home.card.tracking.subtitle',
		es = 'Sea capaz de gestionar y seguir todas las muestras de sus depósitos distribuídas en ubicaciones geográficas diferentes.',
		en = 'Be capable of managing and tracking all your samples from all your geographically distributed warehouses.'
	UNION SELECT k = 'home.card.all.start-now',
		es = '¡Empiece Ahora!',
		en = 'Start Now!'
	UNION SELECT k = 'home.card.compliance.header',
		es = 'No gaste en auditorías',
		en = 'Do not waste your money in auditing'
	UNION SELECT k = 'home.card.compliance.title',
		es = 'Compliance',
		en = 'Compliance'
	UNION SELECT k = 'home.card.compliance.subtitle',
		es = 'No se preocupe más por todos los formularios que debe presentar a las diferentes instituciones controladoras. Hacemos el trabajo por usted.',
		en = 'Do not worry anymore about all the forms you must present to the different controlling institutions. We do the heavy lifting for you.'
	UNION SELECT k = 'home.card.custom-runs.header',
		es = 'Libertad para definir sus investigaciones',
		en = 'Freedom to define your researches'
	UNION SELECT k = 'home.card.custom-runs.title',
		es = 'Customización de Ensayos Clínicos',
		en = 'Customize all your Clinic Runs'
	UNION SELECT k = 'home.card.custom-runs.subtitle',
		es = 'Con una plataforma capaz de configurarse para realizar los ensayos clínicos de cualquier forma que usted y su equipo necesite.',
		en = 'Use a platform able to be configured to run your clinic runs in any way you and your team needs.'
	UNION SELECT k = 'home.card.inventory.header',
		es = 'No pierda rastro de sus caros recursos',
		en = 'Do not lose tracking of your expensive resources'
	UNION SELECT k = 'home.card.inventory.title',
		es = 'Inventariado',
		en = 'Inventory'
	UNION SELECT k = 'home.card.inventory.subtitle',
		es = 'Mantenga completo control de todas sus muestras automáticamente seleccionando el mejor conjunto de las mismas para sus ensayos.',
		en = 'Keep full control of all your samples by automatically selecting the best possible group for your clinic runs.'
	UNION SELECT k = 'pricing-plan.free.title',
		es = 'Gratuito',
		en = 'Free'
	UNION SELECT k = 'pricing-plan.free.subheader',
		es = 'Para probar la plataforma',
		en = 'Test our platform'
	UNION SELECT k = 'pricing-plan.free.price',
		es = 'USD 0',
		en = 'USD 0'
	UNION SELECT k = 'pricing-plan.free.billFrequency',
		es = '/mes',
		en = '/month'
	UNION SELECT k = 'pricing-plan.free.planDescription',
		es = 'Suscripción gratuita para probar',
		en = 'Free subscription for testing purposes'
	UNION SELECT k = 'pricing-plan.free.patientSamplesDescription',
		es = 'Hasta 1000 muestras de pacientes',
		en = 'Up to 1000 patient samples'
	UNION SELECT k = 'pricing-plan.free.controlSamplesDescription',
		es = 'Hasta 1000 muestras de control',
		en = 'Up to 1000 control samples'
	UNION SELECT k = 'pricing-plan.free.userAccountsDescription',
		es = 'Hasta 5 cuentas de usuario',
		en = 'Up to 5 user accounts'
	UNION SELECT k = 'pricing-plan.free.runExecutionsDescription',
		es = 'Hasta 10 ensayos clinicos por mes',
		en = 'Up to 10 clinic runs each month'
	UNION SELECT k = 'pricing-plan.free.signUpDescription',
		es = 'Probar la plataforma',
		en = 'Try the platform'
	UNION SELECT k = 'pricing-plan.premium.title',
		es = 'Premium',
		en = 'Premium'
	UNION SELECT k = 'pricing-plan.premium.subheader',
		es = 'Para laboratorios pequeños y medianos',
		en = 'For small and medium sized organizations'
	UNION SELECT k = 'pricing-plan.premium.price',
		es = 'USD 17.500',
		en = 'USD 17.500'
	UNION SELECT k = 'pricing-plan.premium.billFrequency',
		es = '/mes',
		en = '/month'
	UNION SELECT k = 'pricing-plan.premium.planDescription',
		es = 'Suscripción mensual o anual (con descuento)',
		en = 'Monthly subscription or anual subscription at discount'
	UNION SELECT k = 'pricing-plan.premium.patientSamplesDescription',
		es = 'Hasta 5000 muestras de pacientes por mes',
		en = 'Up to 5000 patient samples a month'
	UNION SELECT k = 'pricing-plan.premium.controlSamplesDescription',
		es = 'Hasta 5000 muestras de control por mes',
		en = 'Up to 5000 control samples a month'
	UNION SELECT k = 'pricing-plan.premium.userAccountsDescription',
		es = 'Hasta 50 cuentas de usuario',
		en = 'Up to 50 user accounts'
	UNION SELECT k = 'pricing-plan.premium.runExecutionsDescription',
		es = 'Sin límite de ensayos clínicos',
		en = 'No clinic run limits'
	UNION SELECT k = 'pricing-plan.premium.signUpDescription',
		es = 'Comenzar a operar',
		en = 'Start Working'
	UNION SELECT k = 'pricing-plan.corporate.title',
		es = 'Corporativo',
		en = 'Corporate'
	UNION SELECT k = 'pricing-plan.corporate.subheader',
		es = 'La solución completa de SSC',
		en = 'Our most complete solution'
	UNION SELECT k = 'pricing-plan.corporate.price',
		es = 'USD 50.000',
		en = 'USD 50.000'
	UNION SELECT k = 'pricing-plan.corporate.billFrequency',
		es = '/mes',
		en = '/month'
	UNION SELECT k = 'pricing-plan.corporate.planDescription',
		es = 'Suscripción mensual o anual (con descuento)',
		en = 'Monthly subscription or anual subscription at discount'
	UNION SELECT k = 'pricing-plan.corporate.patientSamplesDescription',
		es = 'Sin límite de muestras de pacientes',
		en = 'Unlimited patient samples'
	UNION SELECT k = 'pricing-plan.corporate.controlSamplesDescription',
		es = 'Sin límite de muestras de control',
		en = 'Unlimited control samples'
	UNION SELECT k = 'pricing-plan.corporate.userAccountsDescription',
		es = 'Sin límite de cuentas de usuario',
		en = 'Unlimited user accounts'
	UNION SELECT k = 'pricing-plan.corporate.runExecutionsDescription',
		es = 'Sin límite de ensayos clínicos',
		en = 'Unlimited clinic runs'
	UNION SELECT k = 'pricing-plan.corporate.signUpDescription',
		es = 'Operatoria profesional',
		en = 'Professional Operations'
	UNION SELECT k = 'sign-in.page.title',
		es = 'Autenticarse',
		en = 'Sign in'
	UNION SELECT k = 'sign-in.email',
		es = 'Correo electrónico',
		en = 'E-mail'
	UNION SELECT k = 'sign-in.password',
		es = 'Contraseña',
		en = 'Password'
	UNION SELECT k = 'sign-in.login',
		es = 'Autenticarse',
		en = 'Sign In'
	UNION SELECT k = 'sign-in.forgot-password',
		es = 'Olvidé mi contraseña',
		en = 'Forgot my password'
	UNION SELECT k = 'sign-in.sign-up',
		es = 'Registrar nueva cuenta',
		en = 'Sign up a new account'
) AS data
CROSS JOIN		SystemLanguage SL
LEFT  JOIN		SystemLanguageEntry SLE
		ON		sle.SystemLanguageId = sl.Id
		AND		sle.EntryKey = data.k

WHERE			sle.EntryKey IS NULL

