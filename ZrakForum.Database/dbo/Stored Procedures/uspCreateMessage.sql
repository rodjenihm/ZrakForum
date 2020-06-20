CREATE PROCEDURE [dbo].[uspCreateMessage]
	@Id NVARCHAR(32),
	@Text NVARCHAR(MAX),
	@SenderId NVARCHAR(32),
	@ReceiverId NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO [dbo].[Messages] ([Id], [Text], [SenderId], [ReceiverId]) VALUES (@Id, @Text, @SenderId,@ReceiverId)
END