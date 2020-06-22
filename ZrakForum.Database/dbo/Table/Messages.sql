﻿CREATE TABLE [dbo].[Messages]
(
	[CreatedAt] DATETIME2(7) NOT NULL DEFAULT GETDATE(),
	[Id] NVARCHAR(32) NOT NULL PRIMARY KEY,
	[SenderId] NVARCHAR(32) NOT NULL,
	[ReceiverId] NVARCHAR(32) NOT NULL, 
	[Text] NVARCHAR(MAX) NOT NULL,
	[Subject] NVARCHAR(30) NOT NULL
)
