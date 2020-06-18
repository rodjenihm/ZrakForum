CREATE PROCEDURE [dbo].[uspCreateTopic]
	@Id NVARCHAR(32),
	@Title NVARCHAR(255),
	@Description NVARCHAR(MAX),
	@AuthorId NVARCHAR(32),
	@ForumId NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO [dbo].[Topics] ([Id], [Title], [Description], [AuthorId], [ForumId])
		VALUES (@Id, @Title, @Description, @AuthorId, @ForumId)
END