CREATE PROCEDURE [dbo].[uspGetReceivedMessagesByUserId]
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
		m.[CreatedAt] AS ReceivedAt, m.[Id], m.[Subject], m.[Text], m.[SenderId], u.[Username] AS SenderUsername
		FROM [dbo].[Messages] m
		INNER JOIN [dbo].[Users] u ON u.[Id] = m.[SenderId]
		WHERE m.[ReceiverId] = @UserId
		ORDER BY m.[CreatedAt] DESC
	END
END