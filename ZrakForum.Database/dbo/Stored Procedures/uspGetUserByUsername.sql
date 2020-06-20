CREATE PROCEDURE [dbo].[uspGetUserByUsername]
	@Username NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON

	IF NOT EXISTS (SELECT TOP 1 [Username] FROM [dbo].[Users] WHERE [Username] = @Username)
	BEGIN
		DECLARE @message_text NVARCHAR(MAX) = FORMATMESSAGE('Korisničko ime %s ne postoji', @Username);
		THROW 50000, @message_text, 1
	END
	ELSE
	BEGIN
		SELECT [CreatedAt], [Id], [Username], [FirstName], [LastName], [PasswordHash], [ImageUrl] FROM [dbo].[Users] WHERE [Username] = @Username
	END
END