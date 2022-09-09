CREATE TABLE [dbo].Clients (
	[Id] bigint NOT NULL,
	ClientName  nvarchar(200)  NOT NULL)

CREATE TABLE [dbo].ClientContacts  (
	[Id] bigint NOT NULL,
	ClientId bigint NOT NULL,
	ContactType nvarchar(255) not null, 
	ContactValue nvarchar(255)   NOT NULL)

insert into [dbo].Clients values
('0', 'Name0'),
('1', 'Name1'),
('2', 'Name2'),
('3', 'Name3')

insert into [dbo].[ClientContacts] values
('0', '0', 'type1', '666'),
('1', '0', 'type1', '662'),
('2', '1', 'type1', '666'),
('3', '1', 'type2', '661'),
('4', '1', 'type2', '661'),
('5', '2', 'type2', '661')

SELECT  COUNT(*) AmountContact, a.ClientName
FROM    [dbo].Clients a
        INNER JOIN [dbo].[ClientContacts] b
            ON a.Id = b.ClientId
GROUP BY a.ClientName

SELECT  a.Id, a.ClientName
FROM    [dbo].Clients a
        LEFT JOIN [dbo].[ClientContacts] b
            ON a.Id = b.ClientId
GROUP BY a.Id, a.ClientName
HAVING COUNT(b.ClientId) >= 2
