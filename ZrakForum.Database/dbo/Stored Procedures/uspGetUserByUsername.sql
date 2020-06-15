CREATE PROCEDURE [dbo].[uspGetUserByUsername]
	@Username NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON

	SELECT [CreatedAt], [Id], [Username], [PasswordHash] FROM [dbo].[Users] WHERE [Username] = @Username
END