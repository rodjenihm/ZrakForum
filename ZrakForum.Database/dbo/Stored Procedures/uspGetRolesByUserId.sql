CREATE PROCEDURE [dbo].[uspGetRolesByUserId]
	@UserId NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	IF NOT EXISTS (SELECT TOP 1 [Id] FROM [dbo].[Users] WHERE [Id] = @UserId)
	BEGIN
		DECLARE @message_text NVARCHAR(MAX) = FORMATMESSAGE('Korisnik čiji je Id %s ne postoji', @UserId)
		RAISERROR(@message_text, 16, 1)
	END
	ELSE
	BEGIN
		SELECT r.* FROM [dbo].[UserRoles] ur INNER JOIN [dbo].[Roles] r ON r.Id = ur.RoleId WHERE ur.UserId = @UserId
	END
END