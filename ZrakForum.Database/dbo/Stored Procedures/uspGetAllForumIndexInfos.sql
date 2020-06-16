CREATE PROCEDURE [dbo].[uspGetAllForumIndexInfos]
AS
BEGIN
	SET NOCOUNT ON

	SELECT
	[Id], [Name], [Description], [TopicsCount], [RepliesCount], [LastPostedBy], [LastPostedIn], [LastPostedAt]
	FROM (SELECT
		f.[Id], f.[Name], f.[Description],
		dense_rank() OVER (PARTITION BY f.[Name] ORDER BY t.[Title])
		+ dense_rank() OVER (PARTITION BY f.[Name] ORDER BY t.[Title] DESC)
		- 1
		- CASE COUNT(t.Title) OVER (PARTITION BY f.[Name]) WHEN COUNT(*) OVER (PARTITION BY f.[Name]) THEN 0 ELSE 1 END
		AS TopicsCount,
		count(r.[Id]) OVER (PARTITION BY f.[Name]) AS RepliesCount,
		u.[Username] as LastPostedBy, t.[Title] as LastPostedIn, r.[CreatedAt] AS LastPostedAt,
		ROW_NUMBER() OVER (PARTITION BY f.[Name] ORDER BY r.[CreatedAt] DESC) AS rc
		FROM [dbo].[Forums] f
		LEFT JOIN [dbo].[Topics] t on t.ForumId = f.Id
		LEFT JOIN [dbo].[Replies] r on r.TopicId = t.Id
		LEFT JOIN [dbo].[Users] u ON u.Id = r.AuthorId) temp1
	WHERE rc = 1
END