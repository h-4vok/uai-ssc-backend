CREATE PROCEDURE sp_SampleType_deleteParameters
	@Id INT
AS
BEGIN

	DELETE
		SampleTypeToParameter

	WHERE		SampleTypeId = @Id

END