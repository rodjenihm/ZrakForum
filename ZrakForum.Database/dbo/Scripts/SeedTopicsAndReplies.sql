DECLARE @rodjenihmId NVARCHAR(32) = (SELECT [Id] FROM [dbo].[Users] WHERE [Username] = 'rodjenihm')
DECLARE @zracenjeId NVARCHAR(32) = (SELECT [Id] FROM [dbo].[Users] WHERE [Username] = 'zracenje')
DECLARE @mikaId NVARCHAR(32) = (SELECT [Id] FROM [dbo].[Users] WHERE [Username] = 'mika')

DECLARE @politikaId NVARCHAR(32) = (SELECT [Id] FROM [dbo].[Forums] WHERE [Name] = 'Politika')
DECLARE @sportId NVARCHAR(32) = (SELECT [Id] FROM [dbo].[Forums] WHERE [Name] = 'Sport')

DECLARE @vucicUVlasotincu NVARCHAR(32) = replace(newid(), '-', '')
DECLARE @lokalniIzbori NVARCHAR(32) = replace(newid(), '-', '')
DECLARE @vlasinaSampionVlasotinca NVARCHAR(32) = replace(newid(), '-', '')

exec uspCreateTopic @vucicUVlasotincu, 'Vučić u Vlasotincu', 'Predsednik Vučić dolazi u naš mali grad', @rodjenihmId, @politikaId

insert into replies ([Id], [Text], [AuthorId], [TopicId])
values
(replace(newid(), '-', ''), 'Baš me briga, iskreno.',
@rodjenihmId, @vucicUVlasotincu)

exec uspCreateTopic @lokalniIzbori, 'Lokalni izbori', 'Za koga ćete glasati na lokalu i zašto?', @mikaId, @politikaId

insert into replies ([Id], [Text], [AuthorId], [TopicId])
values
(replace(newid(), '-', ''), 'Glasam za gospodina Zračenje jer je gospodin čovek',
@rodjenihmId, @lokalniIzbori)

insert into replies ([Id], [Text], [AuthorId], [TopicId])
values
(replace(newid(), '-', ''), 'Možda jeste gospodin al je lud ko struja',
@mikaId, @lokalniIzbori)

insert into replies ([Id], [Text], [AuthorId], [TopicId])
values
(replace(newid(), '-', ''), 'Čekaj, što sam lud?!',
@zracenjeId, @lokalniIzbori)

exec uspCreateTopic @vlasinaSampionVlasotinca, 'Vlasina šampion Vlasotinca', 'FK Vlasina je opravdala ulogu favorita u lokalnoj beton ligi', @rodjenihmId, @sportId

insert into replies ([Id], [Text], [AuthorId], [TopicId])
values
(replace(newid(), '-', ''), 'Svaka čast. Duel protiv petlića OŠ Siniša Janjić je bio neizvesan',
@zracenjeId, @vlasinaSampionVlasotinca)

insert into replies ([Id], [Text], [AuthorId], [TopicId])
values
(replace(newid(), '-', ''), 'Znaš ti što!',
@mikaId, @lokalniIzbori)