CREATE TABLE [dbo].Dates (
	[Id] bigint NOT NULL,
	Dt   date NOT NULL)

insert into [dbo].Dates values
('1', '01.01.2021'),
('1', '10.01.2021'),
('1', '30.01.2021'),
('2', '15.01.2021'),
('2', '30.01.2021')

select * from dbo.Dates

SELECT Id, dt as ed,
 LAG( dt, 1, null) OVER (PARTITION BY  id
     ORDER BY dt, dt) AS sd
  FROM dbo.Dates
