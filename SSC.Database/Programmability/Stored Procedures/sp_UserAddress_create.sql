CREATE PROCEDURE sp_UserAddress_create
	@StreetName NVARCHAR(200),
	@StreetNumber NVARCHAR(200),
	@City NVARCHAR(200),
	@PostalCode NVARCHAR(70),
	@Department NVARCHAR(200),
	@ProvinceId INT,
	@CreatedBy INT = NULL
AS
BEGIN

	INSERT PlatformUserAddress (
		StreetName,
		StreetNumber,
		City,
		PostalCode,
		Department,
		ProvinceId,
		CreatedBy
	)
	SELECT
		StreetName = @StreetName,
		StreetNumber = @StreetNumber,
		City = @City,
		PostalCode = @PostalCode,
		Department = @Department,
		ProvinceId = @ProvinceId,
		CreatedBy = @CreatedBy

END