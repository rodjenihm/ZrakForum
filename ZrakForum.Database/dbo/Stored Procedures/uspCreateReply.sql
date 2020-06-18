CREATE PROCEDURE [dbo].[uspCreateReply]
	@Id NVARCHAR(32),
	@Text NVARCHAR(255),
	@AuthorId NVARCHAR(32),
	@TopicId NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	IF NOT EXISTS (SELECT TOP 1 [Id] FROM [dbo].[Topics] WHERE [Id] = @TopicId)
	BEGIN
		DECLARE @message_text NVARCHAR(MAX) = FORMATMESSAGE('Tema čiji je Id %s ne postoji', @TopicId);
		THROW 50000, @message_text, 1
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[Replies] ([Id], [Text], [AuthorId], [TopicId]) VALUES (@Id, @Text, @AuthorId, @TopicId)
	END
END
