CREATE TABLE [dbo].[Messages]
(
	[CreatedAt] DATETIME2(7) NOT NULL DEFAULT GETDATE(),
	[Id] NVARCHAR(32) NOT NULL PRIMARY KEY,
	[SenderId] NVARCHAR(32) NOT NULL,
	[ReceiverId] NVARCHAR(32) NOT NULL, 
    CONSTRAINT [FK_Messages_Users_Sender] FOREIGN KEY ([SenderId]) REFERENCES [Users]([Id]),
    CONSTRAINT [FK_Messages_Users_Receiver] FOREIGN KEY ([ReceiverId]) REFERENCES [Users]([Id])
)
