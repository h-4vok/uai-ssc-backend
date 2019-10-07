CREATE PROCEDURE sp_Role_update
	@id INT,
	@name NVARCHAR(300),
	@updatedBy INT
AS
BEGIN

	UPDATE
		[Role]
	SET	
		Name		 = @name,
		UpdatedBy    = @updatedBy,
		UpdatedDate  = GETDATE()
	WHERE Id = @id

END