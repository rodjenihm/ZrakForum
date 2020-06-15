CREATE PROCEDURE [dbo].[uspRegisterUser]
	@Id NVARCHAR(32),
	@Username NVARCHAR(255),
	@PasswordHash NVARCHAR(48)
AS
BEGIN
	SET NOCOUNT ON

	IF EXISTS (SELECT TOP 1 [Username] FROM [dbo].[Users] WHERE [Username] = @Username)
	BEGIN
		DECLARE @message_text NVARCHAR(MAX) = FORMATMESSAGE('Korisničko ime %s je već u upotrebi', @Username)
		RAISERROR(@message_text, 16, 1, 'Username')
	END
	ELSE
	BEGIN
		BEGIN TRANSACTION [Tran1]
			BEGIN TRY
				INSERT INTO [dbo].[Users] ([Id], [Username], [PasswordHash]) VALUES (@Id, @Username, @PasswordHash)
				INSERT INTO [dbo].[UserRoles] ([UserId], [RoleId]) SELECT @Id, [Id] AS roleId FROM [dbo].[Roles] WHERE [Name] = 'Member'
			    COMMIT TRANSACTION [Tran1]
			END TRY
			BEGIN CATCH
			    ROLLBACK TRANSACTION [Tran1]
				RAISERROR('Neočekivana greška prilikom registracije korisnika. Molimo pokušajte kasnije', 16, 1)
			END CATCH
	END
END
