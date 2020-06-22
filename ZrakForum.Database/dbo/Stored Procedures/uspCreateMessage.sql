CREATE PROCEDURE [dbo].[uspCreateMessage]
	@Id NVARCHAR(32),
	@Subject NVARCHAR(30),
	@Text NVARCHAR(MAX),
	@SenderId NVARCHAR(32),
	@ReceiverId NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	IF NOT EXISTS (SELECT TOP 1 [Id] FROM [dbo].[Users] WHERE [Id] = @ReceiverId)
	BEGIN
		DECLARE @message_text NVARCHAR(MAX) = FORMATMESSAGE('Korisnik čiji je Id %s ne postoji', @ReceiverId);
		THROW 50000, @message_text, 1
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[Messages] ([Id], [Subject], [Text], [SenderId], [ReceiverId]) VALUES (@Id, @Subject, @Text, @SenderId,@ReceiverId)
	END
END