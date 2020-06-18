CREATE PROCEDURE [dbo].[uspGetForumWithTopicsByIdAsync]
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
		SELECT *
		FROM [dbo].[Forums] f 
		LEFT JOIN [dbo].[Topics] t ON t.ForumId = f.Id
		LEFT JOIN [dbo].[Users] u ON u.Id = t.AuthorId
		WHERE f.[Id] = @Id
	END
END