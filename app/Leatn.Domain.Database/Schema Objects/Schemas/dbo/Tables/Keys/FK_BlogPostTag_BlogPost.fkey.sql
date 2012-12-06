ALTER TABLE [dbo].[BlogPostTag] 
WITH CHECK ADD CONSTRAINT [FK_BlogPostTag_BlogPost] 
FOREIGN KEY([BlogPostId])
REFERENCES [dbo].[BlogPost] ([Id]) 