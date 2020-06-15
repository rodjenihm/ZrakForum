CREATE PROCEDURE [dbo].[uspGetForumById]
	@Id NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	IF NOT EXISTS (SELECT TOP 1 [Id] FROM [dbo].[Forums] WHERE [Id] = @Id)
	BEGIN
		DECLARE @message_text NVARCHAR(MAX) = FORMATMESSAGE('Forum čiji je Id %s ne postoji', @Id);
		THROW 50000, @message_text, 1
	END
	ELSE
	BEGIN
		SELECT [CreatedAt], [Id], [Name], [Description] FROM [dbo].[Forums] WHERE [Id] = @Id
	END
END
