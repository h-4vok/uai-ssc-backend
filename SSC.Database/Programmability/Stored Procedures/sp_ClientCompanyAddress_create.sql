CREATE PROCEDURE sp_ClientCompanyAddress_create
	@ClientCompanyId INT,
	@StreetName NVARCHAR(200),
	@StreetNumber NVARCHAR(200),
	@City NVARCHAR(200),
	@PostalCode NVARCHAR(70),
	@Department NVARCHAR(200),
	@ProvinceId INT 
AS
BEGIN

	INSERT ClientCompanyAddress (
		ClientCompanyId,
		StreetName,
		StreetNumber,
		City,
		PostalCode,
		Department,
		ProvinceId
	)
	SELECT
		ClientCompanyId = @ClientCompanyId,
		StreetName = @StreetName,
		StreetNumber = @StreetNumber,
		City = @City,
		PostalCode = @PostalCode,
		Department = @Department,
		ProvinceId = @ProvinceId

	SELECT SCOPE_IDENTITY()

END