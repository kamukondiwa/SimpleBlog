CREATE TABLE [dbo].[BlogPostComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Body] [nvarchar](400) NOT NULL,
	[CommentDate] [datetime] NOT NULL,
	[BlogPostId] [int] NOT NULL
)