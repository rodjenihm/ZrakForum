CREATE PROCEDURE [dbo].[uspCreateForum]
	@Id NVARCHAR(32),
	@Name NVARCHAR(255),
	@Description NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON

	IF EXISTS (SELECT TOP 1 [Name] FROM [dbo].[Forums] WHERE [Name] = @Name)
	BEGIN
		DECLARE @message_text NVARCHAR(MAX) = FORMATMESSAGE('Forum sa imenom %s već postoji', @Name)
		RAISERROR(@message_text, 16, 1, 'Name')
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[Forums] ([Id], [Name], [Description]) VALUES (@Id, @Name, @Description)
	END
END