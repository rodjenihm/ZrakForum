CREATE PROCEDURE [dbo].[uspCreateTopic]
	@Id NVARCHAR(32),
	@Title NVARCHAR(255),
	@Description NVARCHAR(MAX),
	@AuthorId NVARCHAR(32),
	@ForumId NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRANSACTION [Trans2]
		BEGIN TRY
			INSERT INTO [dbo].[Topics] ([Id], [Title], [Description], [AuthorId], [ForumId])
				VALUES (@Id, @Title, @Description, @AuthorId, @ForumId)

			INSERT INTO [dbo].[Replies] ([Id], [Text], [AuthorId], [TopicId])
				VALUES (REPLACE(NEWID(), '-', ''), @Description, @AuthorId, @Id)

			COMMIT TRANSACTION [Tran2]
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION [Tran2];
			THROW 50000, 'Neočekivana greška prilikom dodavanja teme. Molimo pokušajte kasnije', 1
		END CATCH
END