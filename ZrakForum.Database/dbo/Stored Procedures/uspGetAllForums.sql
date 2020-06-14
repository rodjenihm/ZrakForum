CREATE PROCEDURE [dbo].[uspGetAllForums]
AS
BEGIN
	SET NOCOUNT ON

	SELECT [CreatedAt], [Id], [Name], [Description] FROM [dbo].[Forums]
END
