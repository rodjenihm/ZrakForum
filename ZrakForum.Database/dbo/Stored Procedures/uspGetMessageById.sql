CREATE PROCEDURE [dbo].[uspGetMessageById]
	@Id NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	IF NOT EXISTS (SELECT TOP 1 [Id] FROM [dbo].[Messages] WHERE [Id] = @Id)
	BEGIN
		DECLARE @message_text NVARCHAR(MAX) = FORMATMESSAGE('Poruka čiji je Id %s ne postoji', @Id);
		THROW 50000, @message_text, 1
	END
	ELSE
	BEGIN
		SELECT
		*
		FROM [dbo].[Messages]
		WHERE [Id] = @Id
	END
END