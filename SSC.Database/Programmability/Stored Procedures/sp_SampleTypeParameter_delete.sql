CREATE PROCEDURE sp_SampleTypeParameter_delete
	@Id INT
AS
BEGIN

	DELETE
		SampleTypeParameter
	
	WHERE
		Id = @Id

END