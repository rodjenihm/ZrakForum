insert into userroles (UserId, RoleId)
select u.Id, r.Id from users u inner join roles r on r.Name = 'Moderator' or r.Name = 'Admin'  where u.Username = 'admin'

insert into userroles (UserId, RoleId)
select u.Id, r.Id from users u inner join roles r on r.Name = 'Moderator' or r.Name = 'Admin'  where u.Username = 'rodjenihm'

insert into userroles (UserId, RoleId)
select u.Id, r.Id from users u inner join roles r on r.Name = 'Moderator' where u.Username = 'zracenje'