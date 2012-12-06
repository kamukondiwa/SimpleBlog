CREATE TABLE [dbo].[BlogPostTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BlogPostId] [int] NOT NULL,
	[TagId] [int] NOT NULL
) 