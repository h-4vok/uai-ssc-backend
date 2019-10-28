CREATE PROCEDURE sp_Patient_delete	
	@Id INT
AS
BEGIN

	DELETE
		Patient

	WHERE		Id = @Id

END