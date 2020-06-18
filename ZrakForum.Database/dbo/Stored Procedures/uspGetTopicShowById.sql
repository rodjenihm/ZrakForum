CREATE PROCEDURE [dbo].[uspGetTopicShowById]
	@Id NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	IF NOT EXISTS (SELECT TOP 1 [Id] FROM [dbo].[Topics] WHERE [Id] = @Id)
	BEGIN
		DECLARE @message_text NVARCHAR(MAX) = FORMATMESSAGE('Tema čiji je Id %s ne postoji', @Id);
		THROW 50000, @message_text, 1
	END
	ELSE
	BEGIN
		SELECT
		t.[Id] AS TopicId, t.[Title] AS TopicTitle,
		r.[Id], r.[Text], r.[AuthorId], u.[Username] AS AuthorUsername, r.[CreatedAt] AS ReplyAt
		FROM [dbo].[Topics] t
		INNER JOIN [dbo].[Replies] r ON r.[TopicId] = t.[Id]
		INNER JOIN [dbo].[Users] u ON u.[Id] = r.[AuthorId]
		WHERE t.[Id] = @Id
	END
END
