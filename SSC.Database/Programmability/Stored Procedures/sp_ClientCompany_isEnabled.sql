CREATE PROCEDURE sp_ClientCompany_isEnabled
	@Id INT
AS
BEGIN
	
	SELECT IsEnabled FROM ClientCompany WHERE Id = @Id

END