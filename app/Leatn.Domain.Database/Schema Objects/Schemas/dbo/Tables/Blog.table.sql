	CREATE TABLE [dbo].[Blog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](400) NOT NULL,
	[Keywords] [nvarchar](400) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[UserId] [int] NOT NULL
)