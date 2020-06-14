CREATE PROCEDURE [dbo].[uspGetForumById]
	@Id NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	SELECT [CreatedAt], [Id], [Name], [Description] FROM [dbo].[Forums] WHERE [Id] = @Id
END
