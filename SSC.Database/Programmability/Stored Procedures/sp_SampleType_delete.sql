CREATE PROCEDURE sp_SampleType_delete
	@Id INT
AS
BEGIN

	DELETE SampleTypeToParameter WHERE SampleTypeId = @Id
	DELETE SampleType WHERE Id = @Id

END