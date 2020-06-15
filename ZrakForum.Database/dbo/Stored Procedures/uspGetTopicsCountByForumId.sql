CREATE PROCEDURE [dbo].[uspGetTopicsCountByForumId]
	@ForumId NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	IF NOT EXISTS (SELECT TOP 1 [Id] FROM [dbo].[Forums] WHERE [Id] = @ForumId)
	BEGIN
		DECLARE @message_text NVARCHAR(MAX) = FORMATMESSAGE('Forum čiji je Id %s ne postoji', @ForumId);
		THROW 50000, @message_text, 1
	END
	ELSE
	BEGIN
		SELECT count([Id]) FROM [dbo].[Topics] WHERE ForumId = @ForumId
	END
END