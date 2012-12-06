CREATE TABLE [dbo].[BlogPost](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](400) NOT NULL,
	[Keywords] [nvarchar](400) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[BlogId] [int] NOT NULL,
	[PostDate] [datetime] NOT NULL
) 