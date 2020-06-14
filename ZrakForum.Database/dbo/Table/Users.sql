﻿CREATE TABLE [dbo].[Users]
(
	[CreatedAt] DATETIME2(7) NOT NULL DEFAULT GETDATE(),
	[Id] NVARCHAR(32) NOT NULL PRIMARY KEY,
	[Username] NVARCHAR(255) NOT NULL,
	[PasswordHash] NVARCHAR(48) NOT NULL
)

GO

CREATE UNIQUE INDEX [IX_Users_Username] ON [dbo].[Users] ([Username])
