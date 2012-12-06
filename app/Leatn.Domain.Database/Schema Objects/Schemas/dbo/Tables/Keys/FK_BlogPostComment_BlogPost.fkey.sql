ALTER TABLE [dbo].[BlogPostComment] 
WITH CHECK ADD CONSTRAINT [FK_BlogPostComment_BlogPost] 
FOREIGN KEY([BlogPostId])
REFERENCES [dbo].[BlogPost] ([Id])