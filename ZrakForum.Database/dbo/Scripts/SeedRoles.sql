INSERT INTO [dbo].[Roles] ([Id], [Name]) VALUES
(REPLACE(NEWID(), '-', ''), 'Member'),
(REPLACE(NEWID(), '-', ''), 'Moderator'),
(REPLACE(NEWID(), '-', ''), 'Admin')