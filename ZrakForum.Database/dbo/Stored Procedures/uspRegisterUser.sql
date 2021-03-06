﻿CREATE PROCEDURE [dbo].[uspRegisterUser]
	@Id NVARCHAR(32),
	@Username NVARCHAR(255),
	@PasswordHash NVARCHAR(48),
	@ImageUrl NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON

	IF EXISTS (SELECT TOP 1 [Username] FROM [dbo].[Users] WHERE [Username] = @Username)
	BEGIN
		DECLARE @message_text NVARCHAR(MAX) = FORMATMESSAGE('Korisničko ime %s je već u upotrebi', @Username);
		THROW 50000, @message_text, 1
	END
	ELSE
	BEGIN
		BEGIN TRANSACTION [Tran1]
			BEGIN TRY
				INSERT INTO [dbo].[Users] ([Id], [Username], [PasswordHash], [ImageUrl]) VALUES (@Id, @Username, @PasswordHash, @ImageUrl)
				INSERT INTO [dbo].[UserRoles] ([UserId], [RoleId]) SELECT @Id, [Id] AS roleId FROM [dbo].[Roles] WHERE [Name] = 'Member'
			    COMMIT TRANSACTION [Tran1]
			END TRY
			BEGIN CATCH
			    ROLLBACK TRANSACTION [Tran1];
				THROW 50000, 'Neočekivana greška prilikom registracije korisnika. Molimo pokušajte kasnije', 1
			END CATCH
	END
END
