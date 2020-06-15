CREATE PROCEDURE [dbo].[uspCreateForum]
	@Id NVARCHAR(32),
	@Name NVARCHAR(255),
	@Description NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON

	IF EXISTS (SELECT TOP 1 [Name] FROM [dbo].[Forums] WHERE [Name] = @Name)
	BEGIN
		DECLARE @message_text NVARCHAR(MAX) = FORMATMESSAGE('Forum sa imenom %s već postoji', @Name);
		THROW 50000, @message_text, 1
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[Forums] ([Id], [Name], [Description]) VALUES (@Id, @Name, @Description)
	END
END