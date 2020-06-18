CREATE PROCEDURE [dbo].[uspGetForumShowById]
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
		SELECT
		temp2.*, u.[Username] AS LastReplyBy
		FROM
		(
			SELECT DISTINCT
			temp1.*,
			COUNT(r.[Id]) OVER (PARTITION BY [Title]) AS RepliesCount, r.[AuthorId] AS LastReplyById, r.[CreatedAt] AS LastReplyAt,
			ROW_NUMBER() OVER (PARTITION BY [Title] ORDER BY r.[CreatedAt] DESC) AS rn
			FROM
			(
				SELECT
				f.[Id] AS ForumId, f.[Name] AS ForumName,
				t.[Id], t.[Title], t.[Description],
				u.[Username] AS StartedBy, t.[CreatedAt] AS StartedAt
				FROM [dbo].[Forums] f
				LEFT JOIN [dbo].[Topics] t ON t.[ForumId] = f.[Id]
				LEFT JOIN [dbo].[Users] u ON u.[Id] = t.[AuthorId]
				WHERE f.[Id] = @Id
			) temp1
			LEFT JOIN [dbo].[Replies] r ON r.[TopicId] = temp1.[Id]
		) temp2
		LEFT JOIN [dbo].[Users] u ON u.[Id] = temp2.LastReplyById
		WHERE temp2.[rn] = 1
	END
END