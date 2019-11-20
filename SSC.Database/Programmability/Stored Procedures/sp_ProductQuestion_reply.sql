CREATE PROCEDURE sp_ProductQuestion_reply	
	@Id INT,
	@ReplyBy INT,
	@Reply NVARCHAR(500)
AS
BEGIN

	UPDATE
		ProductQuestion

	SET
		RepliedDate = GETDATE(),
		Reply = @Reply,
		ReplyBy = @ReplyBy

	WHERE
		Id = @Id
	
END