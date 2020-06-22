CREATE PROCEDURE [dbo].[uspGetSentMessagesByUserId]
	@UserId NVARCHAR(32)
AS
BEGIN	
	SET NOCOUNT ON

	IF NOT EXISTS (SELECT TOP 1 [Id] FROM [dbo].[Users] WHERE [Id] = @UserId)
	BEGIN
		DECLARE @message_text NVARCHAR(MAX) = FORMATMESSAGE('Korisnik čiji je Id %s ne postoji', @UserId);
		THROW 50000, @message_text, 1
	END
	ELSE
	BEGIN
		SELECT
		m.[CreatedAt] AS SentAt, m.[Id], m.[Subject], m.[Text], m.[ReceiverId], u.[Username] AS ReceiverUsername
		FROM [dbo].[Messages] m
		INNER JOIN [dbo].[Users] u ON u.[Id] = m.[ReceiverId]
		WHERE m.[SenderId] = @UserId
		ORDER BY m.[CreatedAt] DESC
	END
END