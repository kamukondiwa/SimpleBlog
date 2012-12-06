Print 'Tag Data Insert'

IF NOT EXISTS (SELECT * FROM [Tag])
BEGIN
SET IDENTITY_INSERT [Tag] ON
BEGIN TRANSACTION
INSERT INTO [Leatn].[dbo].[Tag]([Id],[Name],[TagId]) VALUES(1,'Tags',NULL)
INSERT INTO [Leatn].[dbo].[Tag]([Id],[Name],[TagId]) VALUES(2,'Development',1)
INSERT INTO [Leatn].[dbo].[Tag]([Id],[Name],[TagId]) VALUES(3,'SQL',2)
INSERT INTO [Leatn].[dbo].[Tag]([Id],[Name],[TagId]) VALUES(4,'Open Source',2)
INSERT INTO [Leatn].[dbo].[Tag]([Id],[Name],[TagId]) VALUES(5,'ASP.NET MVC',2)
INSERT INTO [Leatn].[dbo].[Tag]([Id],[Name],[TagId]) VALUES(6,'NHibernate',2)
COMMIT TRANSACTION
SET IDENTITY_INSERT [Tag] OFF
END